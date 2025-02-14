﻿using LezzetKitabi.Data.Repositories.Abstract;
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
using LezzetKitabi.Domain.Dtos.IngredientDtos;
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
            INSERT INTO Ingredients (Id, IngredientName, TotalQuantity, Unit, UnitPrice, Image)
            VALUES (@Id, @IngredientName, @TotalQuantity, @Unit, @UnitPrice, @Image);
            """;


            connection.Execute(sql, new
            {
                Id = Guid.NewGuid(),
                IngredientName = entity.IngredientName,
                TotalQuantity = entity.TotalQuantity,
                Unit = entity.Unit,
                UnitPrice = entity.UnitPrice,
                Image = entity.Image ?? GlobalVariables.BaseIngredientImage
            });

            return true;
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
        public async Task<bool> UpdateIngredientAsync(IngredientUpdateDto ingredient)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            string checkSql = @"
                    SELECT COUNT(1) 
                    FROM Ingredients 
                    WHERE IngredientName = @IngredientName 
                    AND Id != @Id";

            var isNameTaken = await connection.ExecuteScalarAsync<int>(checkSql, new
            {
                IngredientName = ingredient.IngredientName,
                Id = ingredient.Id
            });

            if (isNameTaken > 0)
            {
                MessageBox.Show("Ayni ada sahip bir malzeme bulunmaktadir lutfen tekrar deneyiniz!","Basarisiz",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            string updateSql = @"
                        UPDATE Ingredients 
                        SET IngredientName = @IngredientName, 
                            TotalQuantity = @TotalQuantity, 
                            Unit = @Unit, 
                            UnitPrice = @UnitPrice,
                            Image = @Image
                        WHERE Id = @Id";

            var affectedRows = await connection.ExecuteAsync(updateSql, new
            {
                IngredientName = ingredient.IngredientName,
                TotalQuantity = ingredient.TotalQuantity,
                Unit = ingredient.Unit,
                UnitPrice = ingredient.UnitPrice,
                Image = ingredient.Image,
                Id = ingredient.Id
            });

            return affectedRows > 0;
        }
        public async Task<List<Ingredient>> GetAllIngredientsByOrderAndFilterAsync(IngredientSortingType sortingType, List<FilterCriteria> filterCriteriaList = null, int page = -1)
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
                        sql += " AND TotalQuantity >= @MinStock";
                        parameters.Add("MinStock", minStock);
                    }
                    if (int.TryParse(stocks[1].Trim(), out int maxStock))
                    {
                        sql += " AND TotalQuantity <= @MaxStock";
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
            if(page > 0)
            {
                int pageSize = 18;
                int offset = (page - 1) * pageSize;

                sql += $" OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";
                parameters.Add("Offset", offset);
                parameters.Add("PageSize", pageSize);
            }
            else
            {
                sql += ";";
            }

            List<Ingredient> ingredients = (await connection.QueryAsync<Ingredient>(sql, parameters)).ToList();

            return ingredients;
        }
    }
}
