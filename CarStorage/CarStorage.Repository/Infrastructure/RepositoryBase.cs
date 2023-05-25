using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Repository.Infrastructure;

public abstract class RepositoryBase<TContext, TEntity> : SimpleRepositoryBase<TContext>, IRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    public RepositoryBase(TContext context) : base(context)
    {

    }
    public TEntity Add(TEntity t, bool save = true)
    {
        _context.Set<TEntity>().Add(t);
        if(save) _context.SaveChanges();
        return t;
    }

    public IEnumerable<TEntity> AddAll(IEnumerable<TEntity> entities, bool save = true)
    {
        _context.Set<TEntity>().AddRange(entities);
        if (save) _context.SaveChanges();
        return entities;
    }

    public async Task<IEnumerable<TEntity>> AddAllAsync(IEnumerable<TEntity> entities, bool save = true)
    {
        _context.Set<TEntity>().AddRange(entities);
        if (save) await _context.SaveChangesAsync();
        return entities;
    }

    public async Task<TEntity> AddAsync(TEntity t, bool save = true)
    {
        await _context.Set<TEntity>().AddAsync(t);
        if (save) await _context.SaveChangesAsync();
        return t;
    }

    public int Count()
    {
        return _context.Set<TEntity>().Count();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Set<TEntity>().CountAsync();
    }

    public void Delete(TEntity entity, bool save = true)
    {
        _context.Set<TEntity>().Remove(entity);
        if (save) _context.SaveChanges();
    }

    public async Task<int> DeleteAsync(TEntity t)
    {
        _context.Set<TEntity>().Remove(t);
        return await _context.SaveChangesAsync();
    }

    public TEntity Find(Expression<Func<TEntity, bool>> match)
    {
        return _context.Set<TEntity>().SingleOrDefault(match);
    }

    public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
    {
        return _context.Set<TEntity>().Where(match).ToList();
    }

    public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
    {
        return await _context.Set<TEntity>().Where(match).ToListAsync();
    }

    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
    {
        return await _context.Set<TEntity>().SingleOrDefaultAsync(match);
    }

    public TEntity Get(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public ICollection<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> GetFirstOrDefaultBy(Expression<Func<TEntity, bool>> expression)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public TEntity Update(TEntity updated, int key, bool save = true)
    {
        if (updated == null)
            return null;

        TEntity existing = _context.Set<TEntity>().Find(key);
        if(existing != null)
        {
            _context.Entry(existing).CurrentValues.SetValues(updated);
            if(save) _context.SaveChanges();
        }
        return existing;
    }

    public async Task<TEntity> UpdateAsync(TEntity updated, object key, bool save = true)
    {
        if (updated == null)
            return null;

        TEntity existing = await _context.Set<TEntity>().FindAsync(key);
        if (existing != null)
        {
            _context.Entry(existing).CurrentValues.SetValues(updated);
            if (save) await _context.SaveChangesAsync();
        }
        return existing;
    }
}
