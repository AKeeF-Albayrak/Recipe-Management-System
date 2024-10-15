using Dapper;
using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Contracts;
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
            var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                    INSERT INTO Recipes  (Id ,RecipeName , Category , PreparationTime , Instructions)
                    VALUES ('{entity.Id}', '{entity.RecipeName}', '{entity.Category}', '{entity.PreparationTime}',
                    '{entity.Instructions}');
                """;

            connection.Query(sql);

            connection.Close();

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

            string sql = @"SELECT r.Id, r.RecipeName, 
                          SUM(ri.IngredientAmount * i.UnitPrice) AS TotalCost,
                          (CASE WHEN SUM(ri.IngredientAmount) > 0 THEN 
                              SUM(CASE WHEN i.TotalQuantity IS NOT NULL AND i.TotalQuantity != '0' THEN ri.IngredientAmount / CAST(i.TotalQuantity AS FLOAT) * 100 ELSE 0 END) / COUNT(ri.IngredientID)
                           ELSE 0 END) AS AvailabilityPercentage
                   FROM Recipes r 
                   LEFT JOIN RecipeIngredients ri ON r.Id = ri.RecipeID 
                   LEFT JOIN Ingredients i ON ri.IngredientID = i.Id ";

            // Filtreleme işlemleri
            List<string> filters = new List<string>();

            // Fiyat aralığı filtresi
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

            // Hazırlama süresi filtresi
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

            // Kategori filtresi
            var categoryFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Kategori");
            if (categoryFilter != null)
            {
                string category = categoryFilter.Value;
                filters.Add($"(r.Category = '{category}')");
            }

            // Malzeme filtresi
            var ingredientFilters = filterCriteriaList
                .Where(f => f.FilterType == "Malzeme")
                .Select(f => $"(ri.IngredientID IN (SELECT Id FROM Ingredients WHERE IngredientName = '{f.Value}'))");

            filters.AddRange(ingredientFilters);

            // Name filtresi
            var nameFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Tarif Adi");
            if (nameFilter != null)
            {
                string name = nameFilter.Value;
                filters.Add($"(r.RecipeName LIKE '%{name}%')");
            }

            // Filtreleri sorguya ekleme
            if (filters.Count > 0)
            {
                sql += " WHERE " + string.Join(" AND ", filters);
            }

            // Gruplama ve sıralama
            sql += " GROUP BY r.Id, r.RecipeName ";

            // Sıralama
            switch (sortingType)
            {
                case RecipeSortingType.A_from_Z:
                    sql += "ORDER BY r.RecipeName ASC;";
                    break;
                case RecipeSortingType.Z_from_A:
                    sql += "ORDER BY r.RecipeName DESC;";
                    break;
                case RecipeSortingType.Fastest_to_Slowest:
                    sql += "ORDER BY r.PreparationTime ASC;";
                    break;
                case RecipeSortingType.Slowest_to_Fastest:
                    sql += "ORDER BY r.PreparationTime DESC;";
                    break;
                case RecipeSortingType.Cheapest_to_Expensive:
                    sql += "ORDER BY TotalCost ASC;";
                    break;
                case RecipeSortingType.Expensive_to_Cheapest:
                    sql += "ORDER BY TotalCost DESC;";
                    break;
                default:
                    sql += ";";
                    break;
            }

            // DTO'ya veri çekme
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
        public Task<int> UpdateEntity(Recipe recipe)
        {
            throw new NotImplementedException();//burada ingredient list olarak olmalı mı??
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
