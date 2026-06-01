using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    //To handle API calls from one common place.
    public interface IBaseService
    {
        //“Create an asynchronous reusable method that takes request 
        //information and returns API response.”



        Task<ResponseDto? >SendAsync<T>(RequestDto requestDto);
    }
}
