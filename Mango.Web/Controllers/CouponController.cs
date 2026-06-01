using Mango.Web.Models;
using Mango.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto> list = new();

            ResponseDto response =
                await _couponService.GetAllCouponsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>
                    (Convert.ToString(response.Result));
            }

            return View(list);
        }

        public IActionResult CreateCoupon()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto response =
                    await _couponService.CreateCoupounAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] =
                        "Coupon created successfully";

                    return RedirectToAction(nameof(CouponIndex));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> DeleteCoupon(int id)
        {
            ResponseDto response =
                await _couponService.GetAllCouponsByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                CouponDto? model =
                    JsonConvert.DeserializeObject<CouponDto>
                    (Convert.ToString(response.Result));

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCoupon(CouponDto couponDto)
        {
            ResponseDto? response =
                await _couponService.DeleteCouponAsync(couponDto.CouponId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] =
                    "Coupon deleted successfully";

                return RedirectToAction(nameof(CouponIndex));
            }

            TempData["error"] =
                "Error while deleting coupon";

            return View(couponDto);
        }
    }
}