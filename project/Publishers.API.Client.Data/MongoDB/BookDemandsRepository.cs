using Publishers.API.Client.Core.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Bson;
using Publishers.API.Client.Data.Settings;

namespace Publishers.API.Client.Data.MongoDB
{
    /// <summary>
    /// This class interacts with Mongo DB and saves, retieves the book demands information.
    /// </summary>
    public class BookDemandsRepository : IBookDemandsRepository
    {
        private ISettings _settingsProvider;

        public BookDemandsRepository(ISettings settingsProvider)
        {
            _settingsProvider = settingsProvider;
            var client = new MongoClient(_settingsProvider.MongoURL);
            var database = client.GetDatabase(_settingsProvider.DatabaseName);
            MissingBooks = database.GetCollection<MissingBook>("MissingBooks");
            BookDemands = database.GetCollection<BookDemandModel>(_settingsProvider.BookDemandsCollection);
        }

        public IMongoCollection<MissingBook> MissingBooks { get; set; }

        public IQueryable<BookDemandModel> FindBy(Expression<Func<BookDemandModel, bool>> predicate)
        {
            return BookDemands.Find(predicate).ToEnumerable().AsQueryable();
        }

        public IQueryable<BookDemandModel> GetAll()
        {
            return BookDemands.Find(new BsonDocument())
                    .ToEnumerable()
                    .AsQueryable();
        }

        public IQueryable<BookDemandModel> GetDemands(string userId)
        {
            return BookDemands.Find(b => b.UserIds.Any(s => s == userId))
                    .ToEnumerable()
                    .AsQueryable();
        }

        public BookDemandModel GetSingle(string bookId)
        {
            return BookDemands.Find(b => b._id == bookId).SingleOrDefault();
        }

        public void AddUserToDemand(string demandId, string userId)
        {
            var modification = Builders<BookDemandModel>.Update.Push(d => d.UserIds, userId);

            BookDemands.FindOneAndUpdate(b => b._id == demandId, modification);
        }

        public void RemoveUserFromDemand(string demandId, string userId)
        {
            var modification = Builders<BookDemandModel>.Update.Pull(d => d.UserIds, userId);

            BookDemands.FindOneAndUpdate(b => b._id == demandId, modification);
        }

        public void DeleteDemand(string demandId)
        {
            BookDemands.FindOneAndDelete(d => d._id == demandId);
        }

        public void AddMissingBook(MissingBook book)
        {
            MissingBooks.InsertOne(book);
        }

        public void InsertDemand(BookDemandModel demand)
        {
            BookDemands.InsertOne(demand);
        }

        public IMongoCollection<BookDemandModel> BookDemands { get; set; }
    }
}
