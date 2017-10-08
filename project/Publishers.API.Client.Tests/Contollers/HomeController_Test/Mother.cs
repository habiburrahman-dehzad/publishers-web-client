using Publishers.API.Client.Core.Models;
using System.Collections.Generic;

namespace Publishers.API.Client.Tests.Contollers.HomeController_Test
{
    /// <summary>
    /// This class is used as a helper class to generate data for the unit tests. It centeralizes the creation
    /// of the data to reduce complexity of the test classes and help easily change the creation of the data.
    /// </summary>
    public class Mother
    {
        /// <summary>
        /// Creates an in memory list of book models similar to the documents of the MongoDB database for testing purposes.
        /// </summary>
        /// <returns></returns>
        public static List<BookModel> CreateListOfBookModels()
        {
            List<BookModel> books = new List<BookModel>();
            books.Add(new BookModel
            {

                Title = "The Unseen Hand",
                Publisher = "Publius Press",
                Description = "Ralph Epperson contends that the major events of the past, " +
                              "the revolutions, the wars, the depressions and the revolutions, " +
                              "have been planned years in advance by an international conspiracy. " +
                              "He puts forward his Conspiratorial View of History.",
                Authors = new List<string> { "A. Ralph Epperson" }
            });

            books.Add(new BookModel
            {
                Title = "The Ecclesiastical Organisation of the Church of the East, 1318-1913",
                Publisher = "Peeters Publishers",
                Description = "This careful and scholarly study assembles and discusses the available evidence " +
                              "for the ecllesiastical organisation of the Church of the East (the so-called Nestorian " +
                              "church) in the Middle East between the fourteenth and twentieth centuries. The author " +
                              "has built on the work of the late J.M. Fiey, but has covered a wider geographical area " +
                              "and used a much wider range of sources.",
                Authors = new List<string> { "David Wilmshurst" }
            });

            books.Add(new BookModel
            {
                Title = "The Image of the City",
                Publisher = "MIT Press",
                Description = "The classic work on the evaluation of city form.",
                Authors = new List<string> { "Kevin Lynch" }
            });

            books.Add(new BookModel
            {
                Title = "The Image of the Country",
                Publisher = "Peeters Publishers",
                Description = "This is another book from Kevin on the evolution of the country form.",
                Authors = new List<string> { "Kevin Lynch" }
            });

            books.Add(new BookModel
            {
                Title = "The Origins of Music",
                Publisher = "MIT Press",
                Description = "The book can be viewed as representing the birth of evolutionary biomusicology.",
                Authors = new List<string> { "Nils Lennart Wallin", "Bjorn Merker" }
            });

            return books;
        }
    }
}
