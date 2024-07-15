using Carter;
using Web.Builders;
using Web.Common.Constants;
using Web.Common.Models;

namespace Web.Endpoints;

public class CouponCodeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/coupon-code")
            .WithTags("Coupon Code Endpoints");

        group.MapPost("/generate", GenerateCouponCodeAsync)
            .Produces<GenerateCouponCodeResponse>();

        group.MapGet("/validate", ValidateCouponCodeAsync)
            .Produces<ValidateCouponCodeResponse>();
    }

    private static Task<IResult> GenerateCouponCodeAsync(GenerateCouponCodeRequest request)
    {
        var builder = new CouponCodeBuilder()
            .SetAvailableChars(CouponCodeConstant.CouponCodeCharacters)
            .SetLength(CouponCodeConstant.CouponCodeLength)
            .SetCount(request.Count);

        var couponCodes = builder.Build().ToList();
        var response = new GenerateCouponCodeResponse
        {
            CouponCodes = couponCodes
        };
        return Task.FromResult(Results.Ok(response));
    }

    private static Task<IResult> ValidateCouponCodeAsync([AsParameters] ValidateCouponCodeRequest request)
    {
        var builder = new CouponCodeBuilder()
            .SetAvailableChars(CouponCodeConstant.CouponCodeCharacters)
            .SetLength(CouponCodeConstant.CouponCodeLength);

        var isValid = builder.Validate(request.CouponCode);    
        var response = new ValidateCouponCodeResponse
        {
            IsValid = isValid
        };
        return Task.FromResult(Results.Ok(response));
    }
}