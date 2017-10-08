using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.API.Client.Data.Settings
{
    public interface ISettings
    {
        string MongoURL { get; }
        string DatabaseName { get; }
        string BookDemandsCollection { get; }
    }
}
