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
        public bool AddEntity(RecipeIngredient entity)
        {
            throw new NotImplementedException();
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

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RecipeIngredient> GetEntityById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateEntity(RecipeIngredient entity)
        {
            throw new NotImplementedException();
        }
    }
}
