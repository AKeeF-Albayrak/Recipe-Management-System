using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Entities;
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

namespace LezzetKitabi.Data.Repositories.Concrete
{
    public class IngredientRepository : IIngredientRepository
    {
        public bool AddEntity(Ingredient entity)
        {
            var connection = new SqlConnection(ConstVariables.ConnectionString);

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

            connection.Close();

            return true;
        }

        public async Task<List<Ingredient>> GetAllEntitiesAsync()
        {
            using var connection = new SqlConnection(ConstVariables.ConnectionString);

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();  // Asenkron açma işlemi
            }

            // Malzeme adını alfabetik sıraya göre getir
            string sql = "SELECT * FROM Ingredients ORDER BY IngredientName;";

            // Asenkron sorgu ve listeye dönüştürme
            List<Ingredient> ingredients = (await connection.QueryAsync<Ingredient>(sql)).ToList();

            return ingredients;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using var connection = new SqlConnection(ConstVariables.ConnectionString);

            // Bağlantı durumu kapalıysa, açın
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            // SQL sorgusu
            string sql = "DELETE FROM Ingredients WHERE Id = @Id";

            // Sorguyu çalıştır ve etkilenen satır sayısını al
            int rowsAffected = await connection.ExecuteAsync(sql, new { Id = id });

            // Eğer etkilenen satır varsa, silme işlemi başarılı demektir
            return rowsAffected > 0;
        }
    }
}
