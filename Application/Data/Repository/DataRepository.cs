using System;
using Microsoft.EntityFrameworkCore;
using VLC.RecipeManagment.Application.Models.Recipes;
using VLC.RecipeManagment.Infrastructure;

namespace VLC.RecipeManagment.Application.Data.Repository
{
    public class DataRepository<T> : IRepository<T> where T : class
    {
        private readonly ApiDbContext _context;
        private readonly DbSet<T> _dbSet;

        public DataRepository(ApiDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();


        }

        public async Task<T> GetRecordByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task InsertRecordAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateRecordAsync(T entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecordAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();

        }


    }

}

