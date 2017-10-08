using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Publishers.API.Services.MongoDB;
using Publishers.API.Tests.Controllers.Tests.BooksController;
using Publishers.Domain.Entities;
using Rhino.Mocks;
using System;
using System.Linq.Expressions;
using System.Linq;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Publishers.API.Data.Tests.MongoDB.Test.MongoDBRepository.Tests
{
    [TestClass]
    public class MongoDBRepository_Tests
    {
        IMongoFacade _mongoServer;
        List<Book> _books;

        [TestInitialize]
        public void Setup()
        {
            _mongoServer = MockRepository.GenerateMock<IMongoFacade>();
            _books = Mother.CreateListOfBookModels();
        }

        [TestMethod]
        public void GetAllReturnsAllTheBooks()
        {
            // Arrange
            _mongoServer.Stub(x => x.FindAll()).Return(_books.AsQueryable());

            IEntityRepository<Book> repository = new MongoDbRepository(_mongoServer);

            // Act
            var allBooks = repository.GetAll();

            // Assert
            _mongoServer.AssertWasCalled(x => x.FindAll());
            Assert.AreEqual(_books.Count, allBooks.Count());
        }

        [TestMethod]
        public void FindByWithAPredicateCallsMongoCollectionsFindWithThatPredicate()
        {
            // Arrange
            Expression<Func<Book, bool>> predicate = b => b.Publisher == "MIT Press";

            _mongoServer.Stub(x => x.Find(predicate)).Return(_books.AsQueryable().Where(predicate));

            IEntityRepository<Book> repository = new MongoDbRepository(_mongoServer);

            // Act
            var allBooks = repository.FindBy(predicate);

            // Assert
            _mongoServer.AssertWasCalled(x => x.Find(predicate));
            Assert.IsTrue(allBooks.SequenceEqual(_books.AsQueryable().Where(predicate)));
        }

        [TestMethod]
        public void GetSingleReturnsSingleBookBasedOnGivenValidId()
        {
            // Arrange
            var id = ObjectId.GenerateNewId();
            _books[0]._id = id;

            _mongoServer.Stub(x => x.Find(Arg<Expression<Func<Book, bool>>>.Is.Anything))
                .Return(_books.AsQueryable().Where(b => b._id == id));

            IEntityRepository<Book> repository = new MongoDbRepository(_mongoServer);

            // Act
            var book = repository.GetSingle(id);

            // Assert
            _mongoServer.AssertWasCalled(x => x.Find(Arg<Expression<Func<Book, bool>>>.Is.Anything));
            Assert.AreEqual(book, _books.Where(b => b._id == id).SingleOrDefault());
        }

        [TestMethod]
        public void GetSingleReturnsNullWhenGivenInvalidId()
        {
            // Arrange
            var id = ObjectId.GenerateNewId();
            _books[0]._id = ObjectId.GenerateNewId();

            _mongoServer.Stub(x => x.Find(Arg<Expression<Func<Book, bool>>>.Is.Anything))
                .Return(_books.AsQueryable().Where(b => b._id == id));

            IEntityRepository<Book> repository = new MongoDbRepository(_mongoServer);

            // Act
            var book = repository.GetSingle(id);

            // Assert
            _mongoServer.AssertWasCalled(x => x.Find(Arg<Expression<Func<Book, bool>>>.Is.Anything));
            Assert.IsNull(book);
        }
    }
}
