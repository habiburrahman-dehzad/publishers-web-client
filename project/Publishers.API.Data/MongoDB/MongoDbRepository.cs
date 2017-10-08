using MongoDB.Bson;
using MongoDB.Driver;
using Publishers.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Publishers.API.Services.MongoDB
{
    /// <summary>
    /// This class acts as an in-memory collection of books, with methods to find by some 
    /// predicates or all of the books. It uses the <see cref="MongoFacade"/> to do its
    /// job.
    /// </summary>
    public class MongoDbRepository : IEntityRepository<Book>
    {
        private IMongoFacade _mongoServer;
        public MongoDbRepository(IMongoFacade mongoServer)
        {
            _mongoServer = mongoServer;
        }

        public IQueryable<Book> FindBy(
            Expression<Func<Book, bool>> predicate) => _mongoServer.Find(predicate);

        public IQueryable<Book> GetAll() => _mongoServer.FindAll();

        public Book GetSingle(
            ObjectId id) => _mongoServer.Find(b => b._id == id).SingleOrDefault();
    }
}
