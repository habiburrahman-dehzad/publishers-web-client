using Publishers.API.Client.Core.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.API.Client.Core.Services
{
    public class DefaultSettings : ISettings
    {
        public string PublishersBaseUrl => Settings.Default.PublishersBaseUrl;
    }
}
