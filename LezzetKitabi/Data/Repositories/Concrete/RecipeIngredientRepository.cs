using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Contracts;
using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Services.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LezzetKitabi.Domain.Dtos.CrossTableDtos;

namespace LezzetKitabi.Data.Repositories.Concrete
{
    public class RecipeIngredientRepository : IRecipeIngredientRepository
    {
        private readonly string _connectionString;
        public RecipeIngredientRepository()
        {
            _connectionString = ConstVariables.ConnectionString;
        }
        public async Task AddRangeAsync(List<AddRecipeIngredientDto> recipeIngredients)
        {
            const string query = "INSERT INTO RecipeIngredients (RecipeID, IngredientID, IngredientAmount) VALUES (@RecipeID, @IngredientID, @IngredientAmount)";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                await connection.ExecuteAsync(query, recipeIngredients);
            }
        }
        public async Task<List<Ingredient>> GetIngredientsByRecipeIdAsync(Guid recipeId)
        {
            using var connection = new SqlConnection(_connectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            string sql = @"
            SELECT i.Id, i.IngredientName, ri.IngredientAmount AS TotalQuantity, i.Unit, i.UnitPrice
            FROM RecipeIngredients ri
            INNER JOIN Ingredients i ON ri.IngredientID = i.Id
            WHERE ri.RecipeID = @RecipeID";

            var ingredients = await connection.QueryAsync<Ingredient>(sql, new { RecipeID = recipeId });

            return ingredients.ToList();
        }
    }
}
