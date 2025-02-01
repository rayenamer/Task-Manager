using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading;
using gestion_taches.Domain.interfaces;
using gestion_taches.Data;
using gestion_taches.Data.Context;

namespace gestion_taches.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private gestionTachesContext _context = null;
        private DbSet<TEntity> table = null;



        public GenericRepository(gestionTachesContext _context)
        {
            this._context = _context;
            table = _context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes)
        {
            try
            {
                IQueryable<TEntity> query = table;

                if (includes != null)
                {
                    query = includes(query);
                }
                if (condition != null)
                    return query.Where(condition).ToList();

                else
                    return query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> condition,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        {
            try
            {
                IQueryable<TEntity> query = table;

                if (includes != null)
                {
                    query = includes(query);
                }
                if (condition != null)
                    return query.Where(condition).FirstOrDefault();

                else
                    return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
        public TEntity Add(TEntity Entity)
        {
            table.Add(Entity);
            _context.SaveChanges();
            return Entity;
        }
        public TEntity Update(TEntity Entity)
        {
            table.Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            _context.SaveChanges();
            return Entity;
        }
        public TEntity Delete(Guid Id)
        {
            TEntity existing = table.Find(Id);
            if (existing == null)
                return null;
            else
            {
                table.Remove(existing);
                _context.SaveChanges();
                return existing;
            }


        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await table.FindAsync(id);
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        

    }
}
