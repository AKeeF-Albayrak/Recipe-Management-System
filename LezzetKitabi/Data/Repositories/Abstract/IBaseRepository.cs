using LezzetKitabi.Domain.Entities;
using LezzetKitabi.Domain.Enums;
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
        Task<T> GetEntityById(Guid id);
        Task<int> UpdateEntity(T entity);
    }
}
