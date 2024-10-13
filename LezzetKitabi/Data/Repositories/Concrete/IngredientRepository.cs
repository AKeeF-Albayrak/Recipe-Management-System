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

            string sql = $"""
                    INSERT INTO Ingredients  (Id, IngredientName, TotalQuantity, Unit, UnitPrice)
                    VALUES ('{Guid.NewGuid()}', '{entity.IngredientName}', '{entity.TotalQuantity}', '{entity.Unit}',
                    '{entity.UnitPrice}');
                    """;

            connection.Query(sql);

            return true;
        }
        public async Task<List<Ingredient>> GetAllIngredientsByOrderAsync(IngredientSortingType _sortingtype)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();  // Asenkron açma işlemi
            }
            string sql = string.Empty;

            switch (_sortingtype)
            {
                case IngredientSortingType.A_from_Z:
                    sql = "SELECT * FROM Ingredients ORDER BY IngredientName ASC;";
                    break;
                case IngredientSortingType.Z_from_A:
                    sql = "SELECT * FROM Ingredients ORDER BY IngredientName DESC;";
                    break;
                case IngredientSortingType.Expensive_to_Cheapest:
                    sql = "SELECT * FROM Ingredients ORDER BY UnitPrice DESC;";
                    break;
                case IngredientSortingType.Cheapest_to_Expensive:
                    sql = "SELECT * FROM Ingredients ORDER BY UnitPrice ASC;";
                    break;
                /*case IngredientSortingType.AscendingStock:
                    sql = "SELECT * FROM Ingredients ORDER BY ASC;";
                    break;
                case IngredientSortingType.DescendingStock:
                    sql = "SELECT * FROM Ingredients ORDER BY UnitPrice ASC;";
                    break;*/
                default:
                    sql = "SELECT * FROM Ingredients;"; 
                    break;
            }

            // Asenkron sorgu ve listeye dönüştürme
            List<Ingredient> ingredients = (await connection.QueryAsync<Ingredient>(sql)).ToList();

            return ingredients;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            string sql = "DELETE FROM Ingredients WHERE Id = @Id";

            int rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });

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
        public async Task<int> UpdateEntity(Ingredient ingredient)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            string sql = @"
                   UPDATE Ingredients 
                   SET IngredientName = @IngredientName, 
                   TotalStock = @TotalStock, 
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

            return affectedRows;
        }
    }
}
