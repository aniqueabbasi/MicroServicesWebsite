namespace Mango.Web.Models
{
    //👉 “We use DTO to hide sensitive data, control API response, and decouple database from client.”
    public class CouponDto
    {

        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }

    }
}
