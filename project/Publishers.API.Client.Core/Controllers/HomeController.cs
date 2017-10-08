using Publishers.API.Client.Core.Models;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Publishers.API.Client.MembershipService.Services;
using Publishers.API.Client.Core.Services;
using Publishers.API.Client.Core.Html;

namespace Publishers.API.Client.Core.Controllers
{
    public class HomeController : Controller
    {
        public const string USER_MESSAGE_BODY =
            "<html><body><h1>From {0} &lt;{1}&gt;</h1><h2>Phone: {2}</h2><p style=\"white-space:pre;\">{3}</p><hr/><p>Date: {4}</body></html>";
        public const string USER_MESSAGE_RECEPIENT_NAME = "Habiburrahman Dehzad";
        public const string USER_MESSAGE_RECEPIENT_EMAIL = "rhabiblv@gmail.com";
        public const string USER_MESSAGE_SUBJECT_SUFFIX = "'s Message Through Contact Us Form";

        private IEmailService _emailService;
        private IHtmlEncoderDecoder _htmlEncoder;

        public HomeController(IEmailService emailService, IHtmlEncoderDecoder htmlEncoder)
        {
            _emailService = emailService;
            _htmlEncoder = htmlEncoder;
            _htmlEncoder.SetupServer(Server);
        }

        public ActionResult Index() => View();

        public ActionResult Contact() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(UserMessageModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fullName = _htmlEncoder.HtmlEncode(model.FullName);
                    var email = _htmlEncoder.HtmlEncode(model.Email);
                    var phone = _htmlEncoder.HtmlEncode(model.Phone);
                    var userMsg = _htmlEncoder.HtmlEncode(model.Message);

                    var formatedBody = string.Format(USER_MESSAGE_BODY, fullName, email, phone, userMsg, DateTime.Now);
                    var subject = fullName + USER_MESSAGE_SUBJECT_SUFFIX;

                    var toAddress = $"{USER_MESSAGE_RECEPIENT_NAME} <{USER_MESSAGE_RECEPIENT_EMAIL}>";

                    _emailService.Send(new IdentityMessage { Body = formatedBody, Destination = toAddress, Subject = subject });

                    return View("MessageSent");

                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = e.Message;
                    return View("Error");
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}