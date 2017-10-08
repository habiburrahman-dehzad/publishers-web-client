using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Publishers.API.Client.Core.Controllers;
using Publishers.API.Client.Core.Models;
using Publishers.API.Client.MembershipService.Services;
using Rhino.Mocks;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Publishers.API.Client.Core.Html;

namespace Publishers.API.Client.Tests.Contollers.HomeController_Test
{
    [TestClass]
    public class HomeController_Tests
    {
        [TestMethod]
        public void TestingTheIndexAction()
        {
            // Arrange
            IEmailService service = MockRepository.GenerateMock<IEmailService>();
            IHtmlEncoderDecoder encoder = MockRepository.GenerateMock<IHtmlEncoderDecoder>();
            var controller = new HomeController(service, encoder);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestingContactPostAction()
        {
            // Arrange
            IEmailService service = MockRepository.GenerateMock<IEmailService>();
            IHtmlEncoderDecoder encoder = MockRepository.GenerateMock<IHtmlEncoderDecoder>();

            service.Stub(x => x.SendAsync(Arg<IdentityMessage>.Is.Anything)).Return(Task.FromResult<object>(null));
            encoder.Stub(x => x.HtmlEncode(Arg<string>.Is.Anything)).Return("hello");

            var controller = new HomeController(service, encoder);

            var message = new UserMessageModel()
            {
                Email = "hello@hello.com",
                FullName = "John",
                Phone = "1231231234",
                Message = "Hello there"
            };

            // Act
            var result = controller.Contact(message) as ViewResult;

            // Assert
            Assert.IsTrue(result.ViewName.Equals("MessageSent"));
        }

        [TestMethod]
        public void WhenEmailServiceThrowsExceptionContactActionReturnsErrorView()
        {
            // Arrange
            IEmailService service = MockRepository.GenerateMock<IEmailService>();
            IHtmlEncoderDecoder encoder = MockRepository.GenerateMock<IHtmlEncoderDecoder>();

            string error = "this is an error message";
            service.Stub(x => x.SendAsync(Arg<IdentityMessage>.Is.Anything)).Return(Task.FromResult<object>(null));
            encoder.Stub(x => x.HtmlEncode(Arg<string>.Is.Anything)).Throw(new System.Exception(error));

            var controller = new HomeController(service, encoder);

            var message = new UserMessageModel()
            {
                Email = "hello@hello.com",
                FullName = "John",
                Phone = "1231231234",
                Message = "Hello there"
            };

            // Act
            var result = controller.Contact(message) as ViewResult;

            // Assert
            Assert.IsTrue(result.ViewName.Equals("Error"));
        }
    }
}
