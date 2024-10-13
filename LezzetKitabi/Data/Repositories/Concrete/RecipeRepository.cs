using Dapper;
using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Contracts;
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
        public async Task<List<Recipe>> GetAllRecipesByOrderAsync(RecipeSortingType sortingType)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            string sql = string.Empty;

            switch (sortingType)
            {
                case RecipeSortingType.A_from_Z:
                    sql = "SELECT * FROM Recipes ORDER BY RecipeName ASC;";
                    break;
                case RecipeSortingType.Z_from_A:
                    sql = "SELECT * FROM Recipes ORDER BY RecipeName DESC;";
                    break;
                case RecipeSortingType.Fastest_to_Slowst:
                    sql = "SELECT * FROM Recipes ORDER BY PreparationTime ASC;";
                    break;
                case RecipeSortingType.Slowest_to_Fastest:
                    sql = "SELECT * FROM Recipes ORDER BY PreparationTime DESC;";
                    break;
                /*case RecipeSortingType.Cheapest_to_Expensive:
                    sql = "SELECT * FROM Recipes ORDER BY TotalCost ASC;";
                    break;
                case RecipeSortingType.Expensive_to_Cheapest:
                    sql = "SELECT * FROM Recipes ORDER BY TotalCost DESC;";
                    break;*/
                default:
                    sql = "SELECT * FROM Recipes;";
                    break;
            }

            // Asenkron sorgu ve listeye dönüştürme
            List<Recipe> recipes = (await connection.QueryAsync<Recipe>(sql)).ToList();

            return recipes;
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
    }
}
