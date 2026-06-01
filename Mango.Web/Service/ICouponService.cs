using Mango.Web.Models;

namespace Mango.Web.Service
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetAllCouponsByIdAsync(int id);
        Task<ResponseDto?> CreateCoupounAsync(CouponDto couponDto);
        Task<ResponseDto?> GetAllCouponsAsync(CouponDto couponDto);

        Task<ResponseDto?> DeleteCouponAsync(int id);

    }
}
