using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Repository.Infrastructure;

public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Returns a single object with a primary key
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="id"></param>
    /// <returns>A single object with the provided PK or null</returns>
    TEntity Get(int id);
    /// <summary>
    /// Returns a single object with a primary key
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="id"></param>
    /// <returns>A single object with the provided PK or null</returns>
    Task<TEntity> GetAsync(int id);
    /// <summary>
    /// Gets all objets in the database
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <returns>ICollection of every object in the database</returns>
    ICollection<TEntity> GetAll();
    /// <summary>
    /// Gets all objets in the database
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <returns>ICollection of every object in the database</returns>
    Task<ICollection<TEntity>> GetAllAsync();
    /// <summary>
    /// Returns a single object that matches the provided expression
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="match"></param>
    /// <returns> A single object which matches the expression filter.
    /// If more than one object is found or if zero are found, null is returned</returns>
    TEntity Find(Expression<Func<TEntity, bool>> match);
    /// <summary>
    /// Returns a single object that matches the provided expression
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="match"></param>
    /// <returns> A single object which matches the expression filter.
    /// If more than one object is found or if zero are found, null is returned</returns>
    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
    /// <summary>
    /// Returns a collection of objects that matches the provided expression
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="match"></param>
    /// <returns>An ICollction of objects matching the expression filter</returns>
    ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match);
    /// <summary>
    /// Returns a collection of objects that matches the provided expression
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="match"></param>
    /// <returns>An ICollction of objects matching the expression filter</returns>
    Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);
    /// <summary>
    /// Insert a single object to database
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="t"></param>
    /// <param name="save"></param>
    /// <returns>The resulting object including primary key after the insert</returns>
    TEntity Add(TEntity t, bool save = true);
    /// <summary>
    /// Insert a single object to database
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="t"></param>
    /// <param name="save"></param>
    /// <returns>The resulting object including primary key after the insert</returns>
    Task<TEntity> AddAsync(TEntity t, bool save = true);
    /// <summary>
    /// Insert a collectino of objectc to database
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="t"></param>
    /// <param name="save"></param>
    /// <returns>The IEnumerable resulting list of inserted objects including primary key after the insert</returns>
    IEnumerable<TEntity> AddAll(IEnumerable<TEntity> entities, bool save = true);
    /// <summary>
    /// Insert a collectino of objectc to database
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="t"></param>
    /// <param name="save"></param>
    /// <returns>The IEnumerable resulting list of inserted objects including primary key after the insert</returns>
    Task<IEnumerable<TEntity>> AddAllAsync(IEnumerable<TEntity> entities, bool save = true);
    /// <summary>
    /// Updates a single object based on provided PK
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="t"></param>
    /// <param name="key"></param>
    /// <param name="save"></param>
    /// <returns>The resulting updated object</returns>
    TEntity Update(TEntity updated, int key, bool save = true);
    /// <summary>
    /// Updates a single object based on provided PK
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="t"></param>
    /// <param name="key"></param>
    /// <param name="save"></param>
    /// <returns>The resulting updated object</returns>
    Task<TEntity> UpdateAsync(TEntity updated, object key, bool save = true);
    /// <summary>
    /// Deletes a single object from database
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <param name="entity"></param>
    /// <param name="save"></param>
    void Delete(TEntity entity, bool save = true);
    /// <summary>
    /// Deletes a single object from database
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="entity"></param>
    /// <param name="save"></param>
    Task<int> DeleteAsync(TEntity t);
    /// <summary>
    /// Gets the count of objeccts in the database
    /// </summary>
    /// <remarks>Synchronous</remarks>
    /// <returns>Count of objects in database</returns>
    int Count();
    /// <summary>
    /// Gets the count of objeccts in the database
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <returns>Count of objects in database</returns>
    Task<int> CountAsync();
    /// <summary>
    /// Commits all changes
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <returns></returns>
    Task<int> SaveChangesAsync();
    /// <summary>
    /// Gets the result of objects in database by expression
    /// </summary>
    /// <remarks>Asynchronous</remarks>
    /// <param name="expression"></param>
    /// <returns>Object from database matched by expression</returns>
    Task<TEntity> GetFirstOrDefaultBy(Expression<Func<TEntity, bool>> expression);
}
