using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Publishers.API.Client.Data.MongoDB;

namespace Publishers.API.Client.Core.Models
{
    /// <summary>
    /// This type is defined to create a unique interface to interacts with Mongo DB and save and retieve the book demands information.
    /// </summary>
    public interface IBookDemandsRepository
    {
        IQueryable<BookDemandModel> FindBy(Expression<Func<BookDemandModel, bool>> predicate);
        IQueryable<BookDemandModel> GetAll();
        BookDemandModel GetSingle(string bookId);
        IQueryable<BookDemandModel> GetDemands(string userId);
        void InsertDemand(BookDemandModel demand);
        void AddUserToDemand(string demandId, string userId);
        void RemoveUserFromDemand(string demandId, string userId);
        void DeleteDemand(string demandId);
        void AddMissingBook(MissingBook book);
    }
}
