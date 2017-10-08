using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using Publishers.API.Routing;
using System.Web.Http;

namespace Publishers.API.Tests.RoutingConstaints.Tests
{
    /// <summary>
    /// Tests of the <see cref="ObjectIdRouteConstraint"/> to make sure it filters incorrect object ids,
    /// and accepts correct object ids and optional parameters
    /// </summary>
    [TestClass]
    public class ObjectIdRouteConstraint_Tests
    {
        [TestMethod]
        public void WhenTheIdIsACorrectObjectIdItMustMatch()
        {
            // Arrange
            string paramName = "id";
            IDictionary<string, object> values = new Dictionary<string, object>();

            // give it a correct object id
            values.Add(paramName, ObjectId.GenerateNewId().ToString());

            var constraint = new ObjectIdRouteConstraint();

            // Act
            var result = constraint.Match(null, null, paramName, values, System.Web.Http.Routing.HttpRouteDirection.UriGeneration);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenIdIsNotCorrectObjectIdItMustNotMatch()
        {
            // Arrange
            string paramName = "id";
            string objId = ObjectId.GenerateNewId().ToString();

            // remove two last characters of the string to make it incorrect object id
            objId = objId.Remove(objId.Length - 3);

            IDictionary<string, object> values = new Dictionary<string, object>();
            values.Add(paramName, objId);

            var constraint = new ObjectIdRouteConstraint();

            // Act
            var result = constraint.Match(null, null, paramName, values, System.Web.Http.Routing.HttpRouteDirection.UriGeneration);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenParameterIsOptionalItReturnsTrue()
        {
            // Arrange
            string paramName = "id";

            IDictionary<string, object> values = new Dictionary<string, object>();
            values.Add(paramName, RouteParameter.Optional);

            var constraint = new ObjectIdRouteConstraint();

            // Act
            var result = constraint.Match(null, null, paramName, values, System.Web.Http.Routing.HttpRouteDirection.UriGeneration);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
