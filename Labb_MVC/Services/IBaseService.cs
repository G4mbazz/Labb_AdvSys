using ModelsLib.Models.MVC_Tools;

namespace Labb_MVC.Services
{
    public interface IBaseService : IDisposable
    {
        ResponseDTO ResponseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
