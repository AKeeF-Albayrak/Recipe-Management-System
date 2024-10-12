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
        public bool AddEntity(Recipe entity)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            string sql = $"""
                    INSERT INTO Recipes  (Id ,RecipeName , Category , PreparationTime , Instructions)
                    VALUES ('{Guid.NewGuid()}', '{entity.RecipeName}', '{entity.Category}', '{entity.PreparationTime}',
                    '{entity.Instructions}');
                """;

            connection.Query(sql);

            connection.Close();

            return true;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipe>> GetAllEntitiesByOrderAsync(IngredientSortingType type)
        {
            throw new NotImplementedException();
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

        /*public async Task<bool> UpdateEntity(Recipe entity)
        {
            throw new NotImplementedException();
        }*/
    }
}
