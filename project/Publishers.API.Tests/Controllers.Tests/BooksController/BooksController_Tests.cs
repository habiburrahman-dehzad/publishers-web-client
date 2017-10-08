using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Publishers.Domain.Entities;
using MongoDB.Bson;
using System.Web.Http;

namespace Publishers.API.Tests.Controllers.Tests.BooksController
{
    /// <summary>
    /// An in memory implementation of the IEntityRepository<T> for test purposes. This implementation holds a list
    /// of books which is created in the <see cref="Mother"/> class.
    /// </summary>
    public class BooksRepository : IEntityRepository<Book>
    {
        public List<Book> _books;

        public BooksRepository(List<Book> books)
        {
            _books = books;
        }

        public IQueryable<Book> FindBy(Expression<Func<Book, bool>> predicate)
        {
            return _books.AsQueryable<Book>().Where(predicate);
        }

        public IQueryable<Book> GetAll()
        {
            return _books.AsQueryable();
        }

        public Book GetSingle(ObjectId key)
        {
            return _books.Find(b => b._id == key);
        }
    }

    [TestClass]
    public class GettingBooksWithDeferentQueries
    {
        BooksRepository _booksRepository;

        [TestInitialize]
        public void Setup()
        {
            _booksRepository = new BooksRepository(Mother.CreateListOfBookModels());
        }

        [TestMethod]
        public void ShouldReturnAllBooksWithPublisherName()
        {
            // Arrange
            var publisherName = "MIT Press";
            var controller = new API.Controllers.BooksController(_booksRepository);
            var bCollect = _booksRepository._books.Where(b => b.Publisher.Contains(publisherName));

            // Act
            var books = controller.Get(publisherName);

            // Assert
            Assert.AreEqual(bCollect.Count(), books.Count);
        }

        [TestMethod]
        public void ShoudReturnAllBooksOfAnAuthorWhenTheAuthorNameIsGiven()
        {
            // Arrange
            var author = "Kevin Lynch";
            var controller = new API.Controllers.BooksController(_booksRepository);
            var bCollect = _booksRepository._books.Where(b => b.Authors.Any(s => s.Contains(author)));

            // Act
            var books = controller.GetByAuthor(author);

            // Assert
            Assert.AreEqual(bCollect.Count(), books.Count);
        }

        [TestMethod]
        public void ShouldReturnAllBooksWhenNoParameterIsGiven()
        {
            // Arrange
            var controller = new API.Controllers.BooksController(_booksRepository);

            // Act
            var books = controller.Get();

            // Assert
            Assert.AreEqual(_booksRepository._books.Count, books.Count);
        }

        [TestMethod]
        public void ShouldReturnTheCorrecObjectWhenIdIsGiven()
        {
            // Arrange
            var controller = new API.Controllers.BooksController(_booksRepository);
            ObjectId id = ObjectId.GenerateNewId();
            _booksRepository._books[0]._id = id;

            // Act
            Book b = controller.GetById(id);

            // Assert
            Assert.IsNotNull(b);
            Assert.AreEqual(b, _booksRepository._books[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void ShouldThrowExceptionIfBookWithIdNotFound()
        {
            // Arrange
            var controller = new API.Controllers.BooksController(_booksRepository);
            ObjectId id = ObjectId.GenerateNewId();
            _booksRepository._books[0]._id = ObjectId.GenerateNewId();

            // Act
            Book b = controller.GetById(id);

            // Assert
            // Should not reach this far
            Assert.Fail();
        }
    }
}
