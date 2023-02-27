using System;

namespace RecipeManager.Application.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetRecordByIdAsync(int id);
        Task InsertRecordAsync(T entity);
        Task DeleteRecordAsync(int entity);
        Task UpdateRecordAsync(T entity);

    }
}

