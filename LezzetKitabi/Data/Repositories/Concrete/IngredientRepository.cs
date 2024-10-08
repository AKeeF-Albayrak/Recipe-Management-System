using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LezzetKitabi.Data.Repositories.Concrete
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IDbConnection _dbConnection;

        public IngredientRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            var sql = "SELECT * FROM Ingredients";
            return await _dbConnection.QueryAsync<Ingredient>(sql);
        }

        public async Task<Ingredient> GetByIdAsync(Guid id)
        {
            var sql = "SELECT * FROM Ingredients WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Ingredient>(sql, new { Id = id });
        }

        public async Task AddAsync(Ingredient ingredient)
        {
            var sql = "INSERT INTO Ingredients (IngredientName, TotalQuantity, Unit, UnitPrice) VALUES (@IngredientName, @TotalQuantity, @Unit, @UnitPrice)";
            await _dbConnection.ExecuteAsync(sql, ingredient);
        }

        public async Task UpdateAsync(Ingredient ingredient)
        {
            var sql = "UPDATE Ingredients SET IngredientName = @IngredientName, TotalQuantity = @TotalQuantity, Unit = @Unit, UnitPrice = @UnitPrice WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, ingredient);
        }

        public async Task DeleteAsync(Guid id)
        {
            var sql = "DELETE FROM Ingredients WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }

}
