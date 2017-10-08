using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.API.Client.Data.Settings
{
    public class DefaultSettings : ISettings
    {
        public string BookDemandsCollection => Properties.Settings.Default.BookDemandsCollection;

        public string DatabaseName => Properties.Settings.Default.DatabaseName;

        public string MongoURL => Properties.Settings.Default.MongoURL;
    }
}
