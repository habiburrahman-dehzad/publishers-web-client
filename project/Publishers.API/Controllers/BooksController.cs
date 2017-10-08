using MongoDB.Bson;
using Publishers.API.ModelBinder;
using Publishers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Publishers.API.Controllers
{
    /// <summary>
    /// This is the main controller of the publishers web service. This controller queries the pusblishers database,
    /// retrieves the requested books or book and returns to the client.
    /// </summary>
    public class BooksController : ApiController
    {
        private readonly IEntityRepository<Book> _booksRepository;

        public BooksController(IEntityRepository<Book> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IList<Book> Get(string publisher)
        {
            try
            {
                return _booksRepository.FindBy(b => b.Publisher.Contains(publisher)).ToList();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        public IList<Book> Get()
        {
            try
            {
                var books = _booksRepository.GetAll().ToList();
                return books;
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        public IList<Book> GetByAuthor(string author)
        {
            try
            {
                return _booksRepository.FindBy(b => b.Authors.Any(s => s.Contains(author))).ToList();
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        public Book GetById([ModelBinder(typeof(ObjectIdModelBinder))] ObjectId id)
        {
            Book result;
            try
            {
                result = _booksRepository.GetSingle(id);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return result;
        }
    }
}
