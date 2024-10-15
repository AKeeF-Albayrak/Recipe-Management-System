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
        public async Task<List<Ingredient>> GetAllIngredientsByOrderAndFilterAsync(
            IngredientSortingType _sortingtype,
            string name = null,  // Name parametresi geri eklendi, boş olabilmesi için null
            decimal? minPrice = null,
            decimal? maxPrice = null,
            int? minStock = null,
            int? maxStock = null,
            string unit = null)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();  // Asenkron açma işlemi
            }

            // SQL başlangıç noktası
            string sql = "SELECT * FROM Ingredients WHERE 1=1";  // Dinamik koşul eklemek için başlangıç.

            // Filtreleme işlemleri
            if (!string.IsNullOrEmpty(name))  // Name filtresi
            {
                sql += " AND IngredientName LIKE @Name"; // LIKE ile filtreleme
            }
            if (minPrice.HasValue)  // Minimum fiyat filtresi
            {
                sql += " AND UnitPrice >= @MinPrice";
            }
            if (maxPrice.HasValue)  // Maksimum fiyat filtresi
            {
                sql += " AND UnitPrice <= @MaxPrice";
            }
            if (minStock.HasValue)  // Minimum stok filtresi
            {
                sql += " AND Stock >= @MinStock";
            }
            if (maxStock.HasValue)  // Maksimum stok filtresi
            {
                sql += " AND Stock <= @MaxStock";
            }
            if (!string.IsNullOrEmpty(unit))  // Birim filtresi
            {
                sql += " AND Unit = @Unit";
            }

            // Sıralama işlemleri
            switch (_sortingtype)
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

            // Parametrelerin atanması
            var parameters = new
            {
                Name = $"%{name}%",  // LIKE ile arama için "%" eklenir
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                MinStock = minStock,
                MaxStock = maxStock,
                Unit = unit
            };

            // Asenkron sorgu ve listeye dönüştürme
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
