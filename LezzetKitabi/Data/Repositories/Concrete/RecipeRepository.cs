using Dapper;
using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Contracts;
using LezzetKitabi.Domain.Dtos.CrossTableDtos;
using LezzetKitabi.Domain.Dtos.RecipeDtos;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Data.Repositories.Concrete
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly string _connectionString;
        public RecipeRepository()
        {
            _connectionString = ConstVariables.ConnectionString;
        }
        public bool AddEntity(Recipe entity)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = @"
            INSERT INTO Recipes (Id, RecipeName, Category, PreparationTime, Instructions, Image)
            VALUES (@Id, @RecipeName, @Category, @PreparationTime, @Instructions, @Image);";

            var parameters = new
            {
                Id = entity.Id,
                RecipeName = entity.RecipeName,
                Category = entity.Category,
                PreparationTime = entity.PreparationTime,
                Instructions = entity.Instructions,
                Image = entity.Image
            };

            connection.Execute(sql, parameters);

            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            string sql = "DELETE FROM Recipes WHERE Id = @Id";

            int rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });

            return rowsAffected > 0;
        }
        public async Task<List<RecipeViewGetDto>> GetAllRecipesByOrderAsync(RecipeSortingType sortingType, List<FilterCriteria> filterCriteriaList)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            string sql = @"WITH RecipeIngredientCount AS (
                        SELECT r.Id, COUNT(ri.IngredientID) AS IngredientCount
                        FROM Recipes r
                        LEFT JOIN RecipeIngredients ri ON r.Id = ri.RecipeID
                        GROUP BY r.Id)
                    SELECT r.Id, 
                           r.RecipeName, 
                           r.Category,       
                           r.Instructions,   
                           r.Image,          -- Image kolonu ekleniyor
                           SUM(ri.IngredientAmount * i.UnitPrice) AS TotalCost,
                           SUM(CASE 
                                 WHEN i.TotalQuantity IS NOT NULL AND i.TotalQuantity > 0 THEN
                                   (CASE 
                                     WHEN i.TotalQuantity >= ri.IngredientAmount THEN 100.0 / ric.IngredientCount
                                     ELSE (i.TotalQuantity / ri.IngredientAmount) * (100.0 / ric.IngredientCount)
                                   END)
                                 ELSE 0 
                               END) AS AvailabilityPercentage,
                           SUM(CASE WHEN i.TotalQuantity < ri.IngredientAmount 
                                    THEN (ri.IngredientAmount - i.TotalQuantity) * i.UnitPrice
                                    ELSE 0 END) AS MissingCost,
                           r.PreparationTime 
                    FROM Recipes r 
                    LEFT JOIN RecipeIngredients ri ON r.Id = ri.RecipeID 
                    LEFT JOIN Ingredients i ON ri.IngredientID = i.Id 
                    LEFT JOIN RecipeIngredientCount ric ON r.Id = ric.Id";

            filterCriteriaList ??= new List<FilterCriteria>();

            List<string> filters = new List<string>();

            var priceFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Fiyat");
            if (priceFilter != null)
            {
                var prices = priceFilter.Value.Split('-');
                if (prices.Length == 2)
                {
                    string minPrice = prices[0].Trim();
                    string maxPrice = prices[1].Trim();
                    if (!string.IsNullOrEmpty(minPrice))
                        filters.Add($"(i.UnitPrice >= {minPrice})");
                    if (!string.IsNullOrEmpty(maxPrice))
                        filters.Add($"(i.UnitPrice <= {maxPrice})");
                }
            }

            var ingredientFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Malzeme Sayisi");
            if (ingredientFilter != null)
            {
                var ingredientCounts = ingredientFilter.Value.Split('-');
                if (ingredientCounts.Length == 2)
                {
                    string minCount = ingredientCounts[0].Trim();
                    string maxCount = ingredientCounts[1].Trim();

                    if (!string.IsNullOrEmpty(minCount))
                    {
                        filters.Add($@"
            (SELECT COUNT(*) 
             FROM RecipeIngredients ri 
             WHERE ri.RecipeID = r.Id) >= {minCount}");
                    }

                    if (!string.IsNullOrEmpty(maxCount))
                    {
                        filters.Add($@"
            (SELECT COUNT(*) 
             FROM RecipeIngredients ri 
             WHERE ri.RecipeID = r.Id) <= {maxCount}");
                    }
                }
            }

            var timeFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Hazırlama Süresi");
            if (timeFilter != null)
            {
                var times = timeFilter.Value.Split('-');
                if (times.Length == 2)
                {
                    string minTime = times[0].Trim();
                    string maxTime = times[1].Trim();
                    if (!string.IsNullOrEmpty(minTime))
                        filters.Add($"(r.PreparationTime >= {minTime})");
                    if (!string.IsNullOrEmpty(maxTime))
                        filters.Add($"(r.PreparationTime <= {maxTime})");
                }
            }

            var categoryFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Kategori");
            if (categoryFilter != null)
            {
                string category = categoryFilter.Value;
                filters.Add($"(r.Category = '{category}')");
            }

            var ingredientFilters = filterCriteriaList
                .Where(f => f.FilterType == "Malzeme")
                .Select(f => $"(ri.IngredientID IN (SELECT Id FROM Ingredients WHERE IngredientName = '{f.Value}'))");

            filters.AddRange(ingredientFilters);

            var nameFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Tarif Adi");
            if (nameFilter != null)
            {
                string name = nameFilter.Value;
                filters.Add($@"
          (r.RecipeName LIKE '%{name}%' OR 
          r.Id IN (SELECT ri.RecipeID 
          FROM RecipeIngredients ri 
          JOIN Ingredients i ON ri.IngredientID = i.Id 
          WHERE i.IngredientName LIKE '%{name}%'))");
            }

            if (filters.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", filters);
            }

            sql += " GROUP BY r.Id, r.RecipeName, r.Category, r.Instructions, r.Image, r.PreparationTime";

            // Sıralama
            switch (sortingType)
            {
                case RecipeSortingType.A_from_Z:
                    sql += " ORDER BY r.RecipeName ASC;";
                    break;
                case RecipeSortingType.Z_from_A:
                    sql += " ORDER BY r.RecipeName DESC;";
                    break;
                case RecipeSortingType.Fastest_to_Slowest:
                    sql += " ORDER BY r.PreparationTime ASC;";
                    break;
                case RecipeSortingType.Slowest_to_Fastest:
                    sql += " ORDER BY r.PreparationTime DESC;";
                    break;
                case RecipeSortingType.Cheapest_to_Expensive:
                    sql += " ORDER BY TotalCost ASC;";
                    break;
                case RecipeSortingType.Expensive_to_Cheapest:
                    sql += " ORDER BY TotalCost DESC;";
                    break;
                case RecipeSortingType.Ascending_Percentage:
                    sql += " ORDER BY AvailabilityPercentage ASC;";
                    break;
                case RecipeSortingType.Descending_Percentage:
                    sql += " ORDER BY AvailabilityPercentage DESC;";
                    break;
                case RecipeSortingType.Increasing_Ingredients:
                    sql += @"
            ORDER BY 
            (SELECT COUNT(*) 
             FROM RecipeIngredients ri 
             WHERE ri.RecipeID = r.Id) ASC;";
                    break;
                case RecipeSortingType.Decrising_Ingredients:
                    sql += @"
            ORDER BY 
            (SELECT COUNT(*) 
             FROM RecipeIngredients ri 
             WHERE ri.RecipeID = r.Id) DESC;";
                    break;
                default:
                    sql += ";";
                    break;
            }

            var recipes = await connection.QueryAsync<RecipeViewGetDto>(sql);

            return recipes.ToList();
        }
        public async Task<Recipe> GetEntityById(Guid id)
        {
            using var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            string sql = "SELECT * FROM Recipes WHERE Id = @Id";
            var recipe = await connection.QueryFirstOrDefaultAsync<Recipe>(sql, new { Id = id });

            return recipe;
        }
        public async Task<bool> UpdateRecipeAsync(RecipeUpdateDto recipeUpdateDto)
        {
            using var connection = new SqlConnection(ConstVariables.ConnectionString);
            await connection.OpenAsync();

            using var transaction = connection.BeginTransaction();

            try
            {
                string checkRecipeNameSql = @"
        SELECT COUNT(1) 
        FROM Recipes 
        WHERE RecipeName = @RecipeName 
        AND Id != @Id";

                var isNameTaken = await connection.ExecuteScalarAsync<int>(checkRecipeNameSql, new
                {
                    RecipeName = recipeUpdateDto.RecipeName,
                    Id = recipeUpdateDto.Id
                }, transaction);

                if (isNameTaken > 0)
                {
                    MessageBox.Show("Aynı ada sahip bir tarif bulunmakta, lütfen tekrar deneyiniz!", "Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                string updateRecipeSql = @"
        UPDATE Recipes 
        SET RecipeName = @RecipeName, 
            Category = @Category, 
            PreparationTime = @PreparationTime, 
            Instructions = @Instructions,
            Image = @Image
        WHERE Id = @Id";

                var recipeUpdateResult = await connection.ExecuteAsync(updateRecipeSql, new
                {
                    RecipeName = recipeUpdateDto.RecipeName,
                    Category = recipeUpdateDto.Category,
                    PreparationTime = recipeUpdateDto.PreparationTime,
                    Instructions = recipeUpdateDto.Instructions,
                    Image = recipeUpdateDto.Image,
                    Id = recipeUpdateDto.Id
                }, transaction);

                if (recipeUpdateResult == 0)
                {
                    return false;
                }

                string getExistingIngredientsSql = @"
        SELECT i.Id, i.IngredientName, i.TotalQuantity, i.Unit, i.UnitPrice, i.Image, ri.IngredientAmount
        FROM RecipeIngredients ri
        JOIN Ingredients i ON i.Id = ri.IngredientID
        WHERE ri.RecipeID = @RecipeID";

                var existingIngredients = await connection.QueryAsync<Ingredient>(getExistingIngredientsSql, new
                {
                    RecipeID = recipeUpdateDto.Id
                }, transaction);

                var existingIngredientList = existingIngredients.ToList();

                var ingredientsToDelete = existingIngredientList
                    .Where(ei => !recipeUpdateDto.Ingredients.Any(ri => ri.Id == ei.Id))
                    .ToList();

                foreach (var ingredientToDelete in ingredientsToDelete)
                {
                    string deleteIngredientSql = @"
            DELETE FROM RecipeIngredients 
            WHERE RecipeID = @RecipeID AND IngredientID = @IngredientID";

                    await connection.ExecuteAsync(deleteIngredientSql, new
                    {
                        RecipeID = recipeUpdateDto.Id,
                        IngredientID = ingredientToDelete.Id
                    }, transaction);
                }

                var ingredientsToAdd = recipeUpdateDto.Ingredients
                    .Where(ri => !existingIngredientList.Any(ei => ei.Id == ri.Id))
                    .ToList();

                foreach (var ingredientToAdd in ingredientsToAdd)
                {
                    string insertIngredientSql = @"
                    INSERT INTO RecipeIngredients (RecipeID, IngredientID, IngredientAmount) 
                    VALUES (@RecipeID, @IngredientID, @IngredientAmount)";

                    await connection.ExecuteAsync(insertIngredientSql, new
                    {
                        RecipeID = recipeUpdateDto.Id,
                        IngredientID = ingredientToAdd.Id,
                        IngredientAmount = ingredientToAdd.TotalQuantity
                    }, transaction);
                }

                var ingredientsToUpdate = recipeUpdateDto.Ingredients
                    .Where(ri => existingIngredientList.Any(ei => ei.Id == ri.Id))
                    .ToList();

                foreach (var ingredientToUpdate in ingredientsToUpdate)
                {
                    string updateIngredientSql = @"
            UPDATE RecipeIngredients 
            SET IngredientAmount = @IngredientAmount 
            WHERE RecipeID = @RecipeID AND IngredientID = @IngredientID";

                    await connection.ExecuteAsync(updateIngredientSql, new
                    {
                        IngredientAmount = ingredientToUpdate.TotalQuantity,
                        RecipeID = recipeUpdateDto.Id,
                        IngredientID = ingredientToUpdate.Id
                    }, transaction);
                }

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public async Task<Recipe> GetRecipeByNameAsync(string name)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            string sql = "SELECT * FROM Recipes WHERE RecipeName = @RecipeName";
            var recipe = await connection.QueryFirstOrDefaultAsync<Recipe>(sql, new { RecipeName = name });

            return recipe;
        }
    }
}
