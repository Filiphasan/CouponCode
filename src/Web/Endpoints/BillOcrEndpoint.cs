using Carter;
using Web.Services.Interfaces;

namespace Web.Endpoints;

public class BillOcrEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/bill-ocrs")
            .WithTags("Bill OCR Endpoints");

        group.MapGet("", GetBillOcrResponseAsync)
            .Produces<string>();
    }

    private static async Task<IResult> GetBillOcrResponseAsync(IBillOcrService billOcrService)
    {
        var response = await billOcrService.GetBillOcrStringAsync();
        return Results.Ok(response);
    }
}