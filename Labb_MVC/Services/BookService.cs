using ModelsLib.Models;
using ModelsLib.Models.MVC_Tools;

namespace Labb_MVC.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IHttpClientFactory _client;
        public BookService(IHttpClientFactory client, IConfiguration config) : base(client)
        {
            _client = client;
        }
        public async Task<T> CreateBookAsync<T>(BookDTO bookDTO)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = StaticDetails.ApiType.POST,
                Url = StaticDetails.BookApiBase + $"/api/book/",
                Data = bookDTO
            });
        }

        public async Task<T> DeleteAsync<T>(int id)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.BookApiBase + $"/api/book/{id}"

            });
        }

        public async Task<T> GetAllBooks<T>()
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType= StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/api/book/"

            });
        }

        public async Task<T> GetBookByID<T>(int id)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + $"/api/book/{id}"

            });
        }

        public async Task<T> SearchBookAsync<T>(string searchRequest)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + $"/api/book/search/{searchRequest}",

            });
        }

        public async Task<T> UpdateBookAsync<T>(BookDTO bookDTO, int id)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                apiType = StaticDetails.ApiType.PUT,
                Url = StaticDetails.BookApiBase + $"/api/book/{id}",
                Data = bookDTO
            });
        }
    }
}
