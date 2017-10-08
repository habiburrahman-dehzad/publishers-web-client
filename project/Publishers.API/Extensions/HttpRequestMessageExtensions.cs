using Publishers.Domain.Entities;
using System.Net.Http;
using System.Web.Http.Dependencies;

namespace Publishers.API.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static IEntityRepository<Book> GetEntityRepository(this HttpRequestMessage request)
        {
            return request.GetService<IEntityRepository<Book>>();
        }

        private static TService GetService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));

            return service;
        }
    }
}
