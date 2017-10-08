using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Publishers.API.Client.Core.Html
{
    public class HtmlEncoderDecoder : IHtmlEncoderDecoder
    {
        private HttpServerUtilityBase _server;
        public string HtmlDecode(string s)
        {
            return _server.HtmlDecode(s);
        }

        public string HtmlEncode(string s)
        {
            return _server.HtmlEncode(s);
        }

        public void SetupServer(HttpServerUtilityBase server)
        {
            _server = server;
        }
    }
}
