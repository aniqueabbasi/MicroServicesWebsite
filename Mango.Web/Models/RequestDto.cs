using static Mango.Web.utility.Sd;

namespace Mango.Web.Models
{
    public class  RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.Get;
        public string URl { get; set; }

        public object? Data { get; set; }
        public string AccessToken { get; set; }


    }
}
