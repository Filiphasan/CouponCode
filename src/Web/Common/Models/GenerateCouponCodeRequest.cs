namespace Web.Common.Models;

public class GenerateCouponCodeRequest
{
    public int Count { get; set; }
}

public class GenerateCouponCodeResponse
{
    public List<string> CouponCodes { get; set; } = [];
}