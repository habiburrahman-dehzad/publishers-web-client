using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Publishers.API.Client.Core.Models
{
    public class BookModel
    {
        [DataMember(Name = "_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [DataMember(Name = "Title")]
        public string Title { get; set; }

        [DataMember(Name = "Publisher")]
        public string Publisher { get; set; }

        [DataMember(Name = "Desciption")]
        public string Description { get; set; }

        [Display(Name = "Authors")]
        [DataMember(Name = "Authors")]
        [BsonRepresentation(BsonType.Array)]
        public IList<string> Authors { get; set; }
    }
}
