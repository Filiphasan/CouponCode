using Web.Builders;
using Web.Common.Constants;

namespace WebTest;

public class CouponCodeTests
{
    [Fact]
    public void CouponCode_GenerateAndValidateCodes_ReturnsSuccess()
    {
        const int count = 10_000_000;

        var codes = new CouponCodeBuilder()
            .SetAvailableChars(CouponCodeConstant.CouponCodeCharacters)
            .SetLength(CouponCodeConstant.CouponCodeLength)
            .SetCount(count)
            .Build()
            .ToList();

        Assert.Equal(count, codes.Count);
        Assert.Equal(count, codes.Distinct().Count());

        foreach (var code in codes)
        {
            var isValid = new CouponCodeBuilder()
                .SetAvailableChars(CouponCodeConstant.CouponCodeCharacters)
                .SetLength(CouponCodeConstant.CouponCodeLength)
                .Validate(code);

            Assert.True(isValid);
        }
    }
}