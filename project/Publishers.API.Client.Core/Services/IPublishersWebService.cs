using Publishers.API.Client.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.API.Client.Core.Services
{
    public interface IPublishersWebService
    {
        IEnumerable<BookModel> GetAllBooks();
        BookModel GetSingleBook(string id);
    }
}
