using MongoDB.Driver;
using Publishers.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Publishers.API.Services.MongoDB
{
    /// <summary>
    /// This interface is responsible to hide the extension methods of the Mongo Collection and present a
    /// better interface to make unit tests easier. The extension methods are very difficult to mock.
    /// </summary>
    public interface IMongoFacade
    {
        IQueryable<Book> Find(Expression<Func<Book, bool>> predicate);
        IQueryable<Book> FindAll();
        IMongoCollection<Book> Books { get; set; }
    }

}
