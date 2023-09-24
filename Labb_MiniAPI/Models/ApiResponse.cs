using System.Net;

namespace Labb_MiniAPI.Models
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            ErrorMessages = new List<string>();
        }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
