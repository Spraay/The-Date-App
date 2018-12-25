using App;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Service.Abstract;

namespace App.Service
{

    public abstract partial class Service<TEntity, TIDKey, TDbContext> : IService<TEntity, TIDKey, TDbContext> where TEntity : class where TDbContext : DbContext 
    {
        private readonly TDbContext _context;
        public Service(TDbContext context)                      => _context = context;

        public TEntity Get(TIDKey id)                           => _context.Set<TEntity>().Find(id);

        public ICollection<TEntity> GetList()                   => _context.Set<TEntity>().ToList();

        public void Create(TEntity entity)                      => _context.Add(entity).Context.SaveChangesAsync();

        public void Delete(TIDKey id)                           => _context.Remove(Get(id)).Context.SaveChangesAsync();
    }
    public abstract partial class Service<TEntity, TIDKey, TDbContext> : IService<TEntity, TIDKey, TDbContext> where TEntity : class where TDbContext : DbContext
    {
        public async Task<TEntity> GetAsync(TIDKey id)          => await _context.Set<TEntity>().FindAsync(id);
        
        public async Task CreateAsync(TEntity entity)           => await _context.AddAsync(entity);

        public async Task DeleteAsync(TIDKey id)                => await _context.Remove(await GetAsync(id)).Context.SaveChangesAsync();
           
        public async Task<ICollection<TEntity>> GetListAsync()  => await _context.Set<TEntity>().ToListAsync(); 
    }
}
