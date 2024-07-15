namespace Web.Common.Models;

public class ValidateCouponCodeRequest
{
    public string CouponCode { get; set; } = string.Empty;
}

public class ValidateCouponCodeResponse
{
    public bool IsValid { get; set; }
}