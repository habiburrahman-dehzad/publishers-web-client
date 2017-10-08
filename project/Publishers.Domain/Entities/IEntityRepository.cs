using MongoDB.Bson;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Publishers.Domain.Entities
{
    /// <summary>
    /// The Entity Repository provides a readonly interface for the data, whether in-memory or in a data source. 
    /// Modifying, updating or deleting of the data is not allowed.
    /// </summary>
    /// <typeparam name="T">The genering parameter which could be any domain entity.</typeparam>
    public interface IEntityRepository<T> where T : class
    {
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetSingle(ObjectId id);
    }
}
