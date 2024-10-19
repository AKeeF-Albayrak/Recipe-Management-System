using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LezzetKitabi.Domain.Contracts;
using Microsoft.Data.SqlClient;
using static Dapper.SqlMapper;
using LezzetKitabi.Application.Services;
using System.ComponentModel;
using System.Data.Common;
namespace LezzetKitabi.Data.Repositories.Concrete
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly string _connectionString;
        public IngredientRepository()
        {
            _connectionString = ConstVariables.ConnectionString;
        }
        public bool AddEntity(Ingredient entity)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string checkSql = "SELECT COUNT(*) FROM Ingredients WHERE IngredientName = @IngredientName";

            int ingredientCount = connection.ExecuteScalar<int>(checkSql, new { IngredientName = entity.IngredientName });
            if (ingredientCount > 0)
            {
                return false;
            }
            string sql = """
            INSERT INTO Ingredients (Id, IngredientName, TotalQuantity, Unit, UnitPrice)
            VALUES (@Id, @IngredientName, @TotalQuantity, @Unit, @UnitPrice);
            """;

            connection.Execute(sql, new
            {
                Id = Guid.NewGuid(),
                IngredientName = entity.IngredientName,
                TotalQuantity = entity.TotalQuantity,
                Unit = entity.Unit,
                UnitPrice = entity.UnitPrice
            });

            return true;
        }
        public async Task<List<Ingredient>> GetAllIngredientsByOrderAndFilterAsync(IngredientSortingType sortingType,List<FilterCriteria> filterCriteriaList = null)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            string sql = "SELECT * FROM Ingredients WHERE 1=1";

            var parameters = new DynamicParameters();

            filterCriteriaList ??= new List<FilterCriteria>();

            var nameFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Malzeme Adi");
            if (nameFilter != null)
            {
                sql += " AND IngredientName LIKE @Name";
                parameters.Add("Name", $"%{nameFilter.Value}%");
            }

            var priceFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Fiyat");
            if (priceFilter != null)
            {
                var prices = priceFilter.Value.Split('-');
                if (prices.Length == 2)
                {
                    if (decimal.TryParse(prices[0].Trim(), out decimal minPrice))
                    {
                        sql += " AND UnitPrice >= @MinPrice";
                        parameters.Add("MinPrice", minPrice);
                    }
                    if (decimal.TryParse(prices[1].Trim(), out decimal maxPrice))
                    {
                        sql += " AND UnitPrice <= @MaxPrice";
                        parameters.Add("MaxPrice", maxPrice);
                    }
                }
            }

            var stockFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Stok");
            if (stockFilter != null)
            {
                var stocks = stockFilter.Value.Split('-');
                if (stocks.Length == 2)
                {
                    if (int.TryParse(stocks[0].Trim(), out int minStock))
                    {
                        sql += " AND Stock >= @MinStock";
                        parameters.Add("MinStock", minStock);
                    }
                    if (int.TryParse(stocks[1].Trim(), out int maxStock))
                    {
                        sql += " AND Stock <= @MaxStock";
                        parameters.Add("MaxStock", maxStock);
                    }
                }
            }

            var unitFilter = filterCriteriaList.FirstOrDefault(f => f.FilterType == "Birim");
            if (unitFilter != null)
            {
                sql += " AND Unit = @Unit";
                parameters.Add("Unit", unitFilter.Value);
            }

            switch (sortingType)
            {
                case IngredientSortingType.A_from_Z:
                    sql += " ORDER BY IngredientName ASC";
                    break;
                case IngredientSortingType.Z_from_A:
                    sql += " ORDER BY IngredientName DESC";
                    break;
                case IngredientSortingType.Expensive_to_Cheapest:
                    sql += " ORDER BY UnitPrice DESC";
                    break;
                case IngredientSortingType.Cheapest_to_Expensive:
                    sql += " ORDER BY UnitPrice ASC";
                    break;
                default:
                    sql += " ORDER BY IngredientName ASC";
                    break;
            }

            List<Ingredient> ingredients = (await connection.QueryAsync<Ingredient>(sql, parameters)).ToList();

            return ingredients;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            string checkSql = "SELECT COUNT(*) FROM RecipeIngredients WHERE IngredientID = @Id";

            int ingredientUsageCount = await connection.ExecuteScalarAsync<int>(checkSql, new { Id = id });

            if (ingredientUsageCount > 0)
            {
                return false;
            }
            string deleteSql = "DELETE FROM Ingredients WHERE Id = @Id";

            int rowsAffected = await connection.ExecuteAsync(deleteSql, new { Id = id });

            return rowsAffected > 0;
        }
        public async Task<Ingredient> GetEntityById(Guid id)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            string sql = "SELECT * FROM Ingredients WHERE Id = @Id";
            var ingredient = await connection.QueryFirstOrDefaultAsync<Ingredient>(sql, new { Id = id });

            return ingredient;
        }
        public async Task<bool> UpdateIngredientAsync(Ingredient ingredient)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            string sql = @"
            UPDATE Ingredients 
            SET IngredientName = @IngredientName, 
                TotalQuantity = @TotalQuantity, 
                Unit = @Unit, 
                UnitPrice = @UnitPrice
            WHERE Id = @Id";

            var affectedRows = await connection.ExecuteAsync(sql, new
            {
                IngredientName = ingredient.IngredientName,
                TotalQuantity = ingredient.TotalQuantity,
                Unit = ingredient.Unit,
                UnitPrice = ingredient.UnitPrice,
                Id = ingredient.Id
            });
            return affectedRows > 0;
        }
    }
}
