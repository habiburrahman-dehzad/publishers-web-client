using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Publishers.API.Routing
{
    public class ObjectIdRouteConstraint : IHttpRouteConstraint
    {
        public bool Match(
            HttpRequestMessage request,
            IHttpRoute route,
            string parameterName,
            IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {

            if (values[parameterName] != RouteParameter.Optional)
            {
                object value;
                if (values.TryGetValue(parameterName, out value))
                {
                    string input = Convert.ToString(value, CultureInfo.InvariantCulture);

                    ObjectId result;
                    if (ObjectId.TryParse(input, out result))
                    {
                        return true;
                    }
                }

                return false;
            }

            return true;
        }
    }
}
