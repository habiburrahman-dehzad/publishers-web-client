using Publishers.API.Services.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.API.Services.MongoDB
{
    /// <summary>
    /// This is the default settins provider class which implements the <see cref="ISettingsProvider"/> interface and is provided to be used
    /// by <see cref="MongoDbRepository"/>. This implementation provides the connection string, database name and book collection name through
    /// default <see cref="Settings"/>. Any changes which are applied to the settings will be reflected here.
    /// </summary>
    public class DefaultSettingsProvider : ISettingsProvider
    {
        public string BookCollectionName => Settings.Default.BookCollectionName;

        public string MongoURL => Settings.Default.MongoURL;

        public string DatabaseName => Settings.Default.DatabaseName;
    }
}
