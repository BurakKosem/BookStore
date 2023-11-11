using Core.Entities;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntityBase, new()
    {

        private readonly DatabaseContext _context;

        public RepositoryBase(DatabaseContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            T entity = await Table.FindAsync(id);
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, bool tracking = true)
        {
            if (!tracking)
            {
                return filter != null ? Table.Where(filter).AsNoTracking() : Table.AsNoTracking(); 
            }
            else
            {
                return filter != null ? Table.Where(filter) : Table;
            }

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracking = true)
             => await Table.SingleOrDefaultAsync(filter);


        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
        public bool Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State != EntityState.Modified;
        }
    } 
}
