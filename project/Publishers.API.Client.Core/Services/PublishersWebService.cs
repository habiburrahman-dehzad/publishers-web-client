using Newtonsoft.Json;
using Publishers.API.Client.Core.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Publishers.API.Client.Core.Services
{
    /// <summary>
    /// This class is responsible for communicating with the publishers web service. It sends requests and recieves the
    /// response, and processes the returned data. All the interactions with publishers web service is centeralized here.
    /// </summary>
    public class PublishersWebService : IPublishersWebService
    {
        private IRestClient _restClient;
        private ISettings _settings;

        private const string GET_ALL_BOOKS_ROUTE = "api/all_books";
        private const string GET_SINGLE_BOOKS_ROUTE = "api/single_book/{id}";
        private const string GET_ANY_CONTROLLER_ROUTE = "api/{controller}/{id}";

        public PublishersWebService(IRestClient restClient, ISettings settings)
        {
            _restClient = restClient;
            _settings = settings;
            _restClient.BaseUrl = new Uri(_settings.PublishersBaseUrl);
        }

        public IEnumerable<BookModel> GetAllBooks()
        {
            var request = new RestRequest(GET_ALL_BOOKS_ROUTE, Method.GET) { RequestFormat = DataFormat.Json };

            var response = _restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);

            var books = JsonConvert.DeserializeObject<List<BookModel>>(response.Content);

            return books;
        }

        public BookModel GetSingleBook(string id)
        {
            var request = new RestRequest(GET_SINGLE_BOOKS_ROUTE.Replace("{id}", id), Method.GET) { RequestFormat = DataFormat.Json };

            var response = _restClient.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.ErrorMessage);

            var book = JsonConvert.DeserializeObject<BookModel>(response.Content);

            return book;
        }
    }
}
