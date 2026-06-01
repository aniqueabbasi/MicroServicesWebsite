using Mango.Web.Models;
using Mango.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using static Mango.Web.utility.Sd;


namespace Mango.Web.Service
{
    public class BaseService: IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //   
        public async Task<ResponseDto?> SendAsync<T>(RequestDto requestDto)
        {

            // Create HttpClient
            HttpClient client = _httpClientFactory.CreateClient("MangoAPI");

            // Create HttpRequestMessage
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");

            //token 
            message.RequestUri = new Uri(requestDto.URl); // Sets api end point

            if (requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json"); //Adds JSON body into request.
            }
            HttpResponseMessage apiResponse = null;
            switch(requestDto.ApiType)
            {
                case ApiType.Get:
                    message.Method = HttpMethod.Get;
                    break;
                case ApiType.Post:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.Put:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiType.Delete:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }
            apiResponse = await client.SendAsync(message);
            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new ResponseDto { IsSuccess = false, Message = "Not Found" };

                case HttpStatusCode.Forbidden:
                    return new ResponseDto { IsSuccess = false, Message = "  Access Denied" };

                case HttpStatusCode.Unauthorized:
                    return new ResponseDto { IsSuccess = false, Message = "Unauthorized " };

                case HttpStatusCode.InternalServerError:
                    return new ResponseDto { IsSuccess = false, Message = "Not Found" };


                default: 
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponseDto;
            }
        }
    }
}
