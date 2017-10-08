using MongoDB.Bson;
using MongoDB.Driver;
using Publishers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.API.Services.MongoDB
{
    public class MongoFacade : IMongoFacade
    {
        public MongoFacade(ISettingsProvider settingsProvider)
        {
            var urlBuilder = new MongoUrlBuilder(settingsProvider.MongoURL);
            var client = new MongoClient(urlBuilder.ToMongoUrl());
            var database = client.GetDatabase(settingsProvider.DatabaseName);
            Books = database.GetCollection<Book>(settingsProvider.BookCollectionName);
        }

        public IMongoCollection<Book> Books { get; set; }

        public IQueryable<Book> Find(Expression<Func<Book, bool>> predicate)
            => Books.Find(predicate).ToEnumerable().AsQueryable();

        public IQueryable<Book> FindAll()
            => Books.Find(new BsonDocument()).ToEnumerable().AsQueryable();
    }
}
