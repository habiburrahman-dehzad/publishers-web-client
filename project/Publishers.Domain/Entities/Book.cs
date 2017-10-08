using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.Domain.Entities
{
    /// <summary>
    /// This class represents a book which is a domain entity of the web service. The books
    /// are saved in the Book collection of the MongoDB database. The names of the properties
    /// match the names in the MongoDB Book collection.
    /// </summary>
    public class Book
    {
        public ObjectId _id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public IList<string> Authors { get; set; }
    }
}
