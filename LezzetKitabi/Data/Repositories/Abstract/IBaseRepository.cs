using LezzetKitabi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace LezzetKitabi.Data.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        bool AddEntity(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<List<T>> GetAllEntitiesAsync();
        //Task<bool> UpdateEntity(T entity);  // Güncelleme işlemi
        Task<T> GetEntityById(Guid id);  // ID ile varlık getir
    }
}
