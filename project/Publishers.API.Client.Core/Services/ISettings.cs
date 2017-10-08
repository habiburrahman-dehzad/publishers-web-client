using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publishers.API.Client.Core.Services
{
    public interface ISettings
    {
        string PublishersBaseUrl { get; }
    }
}
