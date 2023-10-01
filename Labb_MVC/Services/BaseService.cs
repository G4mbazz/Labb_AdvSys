using ModelsLib.Models.MVC_Tools;
using Newtonsoft.Json;
using System.Text;

namespace Labb_MVC.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDTO ResponseModel { get; set; }
        public IHttpClientFactory Httpclient { get; set; }

        public BaseService(IHttpClientFactory httpclient)
        {
            Httpclient = httpclient;
            ResponseModel = new ResponseDTO();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = Httpclient.CreateClient("Labb_AdvSysApi");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                HttpResponseMessage apiResp = null;
                switch (apiRequest.apiType)
                {
                    case ModelsLib.Models.StaticDetails.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case ModelsLib.Models.StaticDetails.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ModelsLib.Models.StaticDetails.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ModelsLib.Models.StaticDetails.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                }
                apiResp = await client.SendAsync(message);
                var apiCont = await apiResp.Content.ReadAsStringAsync();
                var apiRespDTO = JsonConvert.DeserializeObject<T>(apiCont);
                return apiRespDTO;

            }
            catch (Exception e)
            {
                var respDto = new ResponseDTO()
                {
                    ErrorMessage = "Error",
                    ErrorMessages = new List<string>() { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var resp = JsonConvert.SerializeObject(respDto);
                var apiRespDTO = JsonConvert.DeserializeObject<T>(resp);
                return apiRespDTO;
            }
     
        }
    }
}
