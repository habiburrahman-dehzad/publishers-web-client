using Publishers.API.Client.Core.Models;
using Publishers.API.Client.Core.Services;
using Publishers.API.Client.MembershipService.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MongoDB.Bson;
using Publishers.API.Client.Core.ViewModels;
using Publishers.API.Client.Data.MongoDB;

namespace Publishers.API.Client.Core.Controllers
{
    [Authorize]
    public class LibraryController : Controller
    {
        private IPublishersWebService _publishersWebService;
        private IBookDemandsRepository _bookDemandsRepository;

        public LibraryController(IPublishersWebService publishersWebService, IBookDemandsRepository bookDemandsRepository)
        {
            _publishersWebService = publishersWebService;
            _bookDemandsRepository = bookDemandsRepository;
        }

        public ActionResult Index()
        {
            try
            {
                var books = _publishersWebService.GetAllBooks();
                return View(books);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "An error occured while trying to retrieve the list of books. Either the Publishers Web Service is not running"
                    + " or the service can not retrieve the data from cloud hosted database.";
                return View("Error");
            }
        }

        public ActionResult PlaceDemand(string id)
        {
            try
            {
                var book = _publishersWebService.GetSingleBook(id);
                return View(book);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "An error occured while trying to retrieve the list of books. Either the Publishers Web Service is not running"
                    + " or the service can not retrieve the data from cloud hosted database.";
                return View("Error");
            }
        }

        public ActionResult Demand(string bookId)
        {
            try
            {
                var userid = User.Identity.GetUserId();

                var demand = _bookDemandsRepository.GetSingle(bookId);

                // If this book is in demand then add this user to the list
                if (demand != null)
                {
                    _bookDemandsRepository.AddUserToDemand(demand._id, userid);
                }
                else
                {
                    demand = new BookDemandModel
                    {
                        _id = bookId,
                        UserIds = new List<string> { userid }
                    };
                    _bookDemandsRepository.InsertDemand(demand);
                }

                return View();
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "An error occured while trying to place the demand. The database server may not be running. "
                    + "Contact your system administrator";
                return View("Error");
            }
        }

        public ActionResult UsersDemands()
        {
            try
            {
                var userid = User.Identity.GetUserId();

                var demands = _bookDemandsRepository.GetDemands(userid).ToList();

                if (demands == null || demands.Count() == 0)
                {
                    ViewBag.Message = "You have not palced placed demand for any book.";
                    return View();
                }

                DemandsViewModel model = new DemandsViewModel();
                model.Books = new List<BookModel>();
                foreach (var item in demands)
                {
                    var book = _publishersWebService.GetSingleBook(item._id);
                    model.Books.Add(book);
                }

                return View(model);
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "An error occured while trying to retrieve your demands. The database server may not be running. "
                    + "Contact your system administrator";
                return View("Error");
            }
        }

        public ActionResult SubmitBookInformation(string bookTitle, string author)
        {
            var missingBook = new MissingBook
            {
                BookTitle = bookTitle,
                BookAuthor = author
            };

            _bookDemandsRepository.AddMissingBook(missingBook);

            return RedirectToAction("Index");
        }
    }
}
