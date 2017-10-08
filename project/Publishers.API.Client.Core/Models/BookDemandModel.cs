using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.API.Client.Core.Models
{
    public class BookDemandModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public IList<string> UserIds { get; set; }
    }
}
