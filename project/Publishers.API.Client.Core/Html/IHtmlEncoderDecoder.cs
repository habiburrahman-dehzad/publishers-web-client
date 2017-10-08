using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Publishers.API.Client.Core.Html
{
    /// <summary>
    /// This interface helps isolate the HomeController and other controllers to depend on Controller.Server property.
    /// This way unit tesing the controllers will be easy, by creating mock object of the interface and injecting into
    /// controller.
    /// </summary>
    public interface IHtmlEncoderDecoder
    {
        void SetupServer(HttpServerUtilityBase server);
        string HtmlDecode(string s);
        string HtmlEncode(string s);
    }
}
