using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.API.Services.MongoDB
{
    /// <summary>
    /// This interface abstracts the settings for the connection string, database name and book collection name
    /// for mongodb interactions. This interface is used by the <see cref="MongoDbRepository"/>.
    /// </summary>
    public interface ISettingsProvider
    {
        string BookCollectionName { get; }
        string MongoURL { get; }
        string DatabaseName { get; }
    }
}
