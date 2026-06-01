using Mango.Web.Models;
using Mango.Web.utility;
using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
    public class CouponServicecs : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponServicecs(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCoupounAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync<ResponseDto>(new RequestDto()
            {
                ApiType = Sd.ApiType.Post,
                Data = couponDto,
                URl = Sd.CouponApiBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync<ResponseDto>(new RequestDto()
            {
                ApiType = Sd.ApiType.Delete,
                URl = Sd.CouponApiBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync<ResponseDto>(new RequestDto()
            {
                ApiType = Sd.ApiType.Get,
                URl = Sd.CouponApiBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto?> GetAllCouponsByIdAsync(int id)
        {
            return await _baseService.SendAsync<ResponseDto>(new RequestDto()
            {
                ApiType = Sd.ApiType.Get,
                URl = Sd.CouponApiBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync<ResponseDto>(new RequestDto()
            {
                ApiType = Sd.ApiType.Get,
                URl = Sd.CouponApiBase + "/api/coupon/GetByCode/" + couponCode
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync<ResponseDto>(new RequestDto()
            {
                ApiType = Sd.ApiType.Get,
                Data = couponDto,
                URl = Sd.CouponApiBase + "/api/coupon"
            });
        }
    }
}