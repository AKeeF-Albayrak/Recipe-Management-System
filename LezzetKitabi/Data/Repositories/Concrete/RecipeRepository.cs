using Dapper;
using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Data.Repositories.Concrete
{
    public class RecipeRepository : IBaseRepository<Recipe>
    {
        private readonly IDbConnection _dbConnection;

        public RecipeRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            var sql = "SELECT * FROM Recipes";
            return await _dbConnection.QueryAsync<Recipe>(sql);
        }

        public async Task<Recipe> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Recipes WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Recipe>(sql, new { Id = id });
        }

        public async Task AddAsync(Recipe recipe)
        {
            var sql = "INSERT INTO Recipes (RecipeName, Category, PreparationTime, Instructions) VALUES (@RecipeName, @Category, @PreparationTime, @Instructions)";
            await _dbConnection.ExecuteAsync(sql, recipe);
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            var sql = "UPDATE Recipes SET RecipeName = @RecipeName, Category = @Category, PreparationTime = @PreparationTime, Instructions = @Instructions WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, recipe);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Recipes WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
