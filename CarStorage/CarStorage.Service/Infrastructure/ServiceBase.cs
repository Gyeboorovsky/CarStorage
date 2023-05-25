using CarStorage.Repository.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Service.Infrastructure;

/// <summary>
/// Base class for Services
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TRepository"></typeparam>
public class ServiceBase<TEntity, TRepository> : SimpleServiceBase, IServiceBase<TEntity>
    where TEntity : class
    where TRepository : IRepository<TEntity>
{
    protected readonly TRepository _repository;

    public ServiceBase(DbContext ctx, TRepository repository) : base(ctx)
    {
        _repository = repository;
    }

    /// <summary>
    /// Returns a single object with a primary key
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="id"></param>
    /// <returns>A single object with the provided PK or null</returns>
    public TEntity Get(int id)
    {
        return _repository.Get(id);
    }
    /// <summary>
    /// Returns a single object with a primary key
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="id"></param>
    /// <returns>A single object with the provided PK or null</returns>
    public async Task<TEntity> GetAsync(int id)
    {
        return await _repository.GetAsync(id);
    }
    /// <summary>
    /// Gets all objets in the database
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <returns>ICollection of every object in the database</returns>
    public ICollection<TEntity> GetAll()
    {
        return _repository.GetAll();
    }
    /// <summary>
    /// Gets all objets in the database
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <returns>ICollection of every object in the database</returns>
    public async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
    /// <summary>
    /// Returns a single object that matches the provided expression
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="match"></param>
    /// <returns> A single object which matches the expression filter.
    /// If more than one object is found or if zero are found, null is returned</returns>
    public TEntity Find(Expression<Func<TEntity, bool>> match)
    {
        return _repository.Find(match);
    }
    /// <summary>
    /// Returns a single object that matches the provided expression
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="match"></param>
    /// <returns> A single object which matches the expression filter.
    /// If more than one object is found or if zero are found, null is returned</returns>
    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
    {
        return await _repository.FindAsync(match);
    }
    /// <summary>
    /// Returns a collection of objects that matches the provided expression
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="match"></param>
    /// <returns>An ICollction of objects matching the expression filter</returns>
    public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
    {
        return _repository.FindAll(match);
    }
    /// <summary>
    /// Returns a collection of objects that matches the provided expression
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="match"></param>
    /// <returns>An ICollction of objects matching the expression filter</returns>
    public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
    {
        return await _repository.FindAllAsync(match);
    }
    /// <summary>
    /// Insert a single object to database
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="t"></param>
    /// <param name="save"></param>
    /// <returns>The resulting object including primary key after the insert</returns>
    public TEntity Add(TEntity t, bool save = true)
    {
        return _repository.Add(t, save);
    }
    /// <summary>
    /// Insert a single object to database
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="t"></param>
    /// <param name="save"></param>
    /// <returns>The resulting object including primary key after the insert</returns>
    public async Task<TEntity> AddAsync(TEntity t, bool save = true)
    {
        return await _repository.AddAsync(t, save);
    }
    /// <summary>
    /// Insert a collectino of objectc to database
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="t"></param>
    /// <param name="save"></param>
    /// <returns>The IEnumerable resulting list of inserted objects including primary key after the insert</returns>
    public IEnumerable<TEntity> AddAll(IEnumerable<TEntity> entities, bool save = true)
    {
        return _repository.AddAll(entities, save);
    }
    /// <summary>
    /// Insert a collectino of objectc to database
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="t"></param>
    /// <param name="save"></param>
    /// <returns>The IEnumerable resulting list of inserted objects including primary key after the insert</returns>
    public async Task<IEnumerable<TEntity>> AddAllAsync(IEnumerable<TEntity> entities, bool save = true)
    {
        return await _repository.AddAllAsync(entities, save);
    }
    /// <summary>
    /// Updates a single object based on provided PK
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="t"></param>
    /// <param name="key"></param>
    /// <param name="save"></param>
    /// <returns>The resulting updated object</returns>
    public TEntity Update(TEntity t, int key, bool save = true)
    {
        return _repository.Update(t, key, save);
    }
    /// <summary>
    /// Updates a single object based on provided PK
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="t"></param>
    /// <param name="key"></param>
    /// <param name="save"></param>
    /// <returns>The resulting updated object</returns>
    public async Task<TEntity> UpdateAsync(TEntity t, object key, bool save = true)
    {
        return await _repository.UpdateAsync(t, key, save);
    }
    /// <summary>
    /// Deletes a single object from database
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="entity"></param>
    /// <param name="save"></param>
    public void Delete(TEntity entity, bool save = true)
    {
        _repository.Delete(entity, save);
    }
    /// <summary>
    /// Deletes a single object from database
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="entity"></param>
    /// <param name="save"></param>
    public async Task<int> DeleteAsync(TEntity entity)
    {
        return await _repository.DeleteAsync(entity);
    }
    /// <summary>
    /// Gets the count of objeccts in the database
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <returns>Count of objects in database</returns>
    public int Count()
    {
        return _repository.Count();
    }
    /// <summary>
    /// Gets the count of objeccts in the database
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <returns>Count of objects in database</returns>
    public async Task<int> CountAsync()
    {
        return await _repository.CountAsync();
    }
    /// <summary>
    /// Commits all changes
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <returns></returns>
    public async Task<int> SaveChangesAsync()
    {
        return await _repository.SaveChangesAsync();
    }
    /// <summary>
    /// Gets the result of objects in database by expression
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="expression"></param>
    /// <returns>Object from database matched by expression</returns>
    public async Task<TEntity> GetFirstOrDefaultBy(Expression<Func<TEntity, bool>> expression)
    {
        return await _repository.GetFirstOrDefaultBy(expression);
    }
}
