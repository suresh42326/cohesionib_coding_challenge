using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Repos
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(string id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(string id);
    }
}
