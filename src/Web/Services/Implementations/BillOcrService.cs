using System.Text;
using System.Text.Json;
using Web.Common.Models.BillOcr;
using Web.Services.Interfaces;

namespace Web.Services.Implementations;

public class BillOcrService : IBillOcrService
{
    private readonly IWebHostEnvironment _hostEnvironment;

    public BillOcrService(IWebHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    /// <summary>
    /// Simulate bill ocr request
    /// </summary>
    /// <returns></returns>
    private async Task<BillOcrResponse[]> GetBillOcrResponseAsync()
    {
        var path = Path.Combine(_hostEnvironment.WebRootPath, "Bills", "BillResponse.json");
        var json = await File.ReadAllTextAsync(path);
        var response = JsonSerializer.Deserialize<BillOcrResponse[]>(json) ?? [];
        return response;
    }

    public async Task<string> GetBillOcrStringAsync()
    {
        var response = await GetBillOcrResponseAsync();
        var stringBuilder = new StringBuilder();
        var descriptions = response.Where(x => x.Locale == null).ToList();

        var processedDescriptions = new HashSet<Guid>();
        foreach (var ocrItem in descriptions)
        {
            var lineBuilder = new StringBuilder();
            if (!processedDescriptions.Add(ocrItem.Id))
            {
                continue;
            }

            var relativeOcrItems = GetRelatedBillOcrItems(ocrItem, response);
            foreach (var relativeOcrItem in relativeOcrItems)
            {
                processedDescriptions.Add(relativeOcrItem.Id);
            }

            lineBuilder.AppendJoin(' ', [ocrItem.Description, ..relativeOcrItems.Select(x => x.Description)]);
            var lineString = lineBuilder.ToString();
            stringBuilder.AppendLine(lineString);
            Console.WriteLine(lineString);
        }

        return stringBuilder.ToString();
    }

    private static BillOcrResponse[] GetRelatedBillOcrItems(BillOcrResponse billOcrItem, IEnumerable<BillOcrResponse> response)
    {
        var lineHeight = billOcrItem.BoundingPoly.Vertices[2].Y - billOcrItem.BoundingPoly.Vertices[0].Y;
        var minY = billOcrItem.BoundingPoly.Vertices[0].Y - lineHeight * 2 / 3;
        var maxY = billOcrItem.BoundingPoly.Vertices[2].Y + lineHeight * 2 / 3;
        return response
            .Where(x => x.Id != billOcrItem.Id)
            .Where(x => x.BoundingPoly.Vertices[0].Y > minY && x.BoundingPoly.Vertices[2].Y < maxY)
            .OrderBy(x => x.BoundingPoly.Vertices[0].X)
            .ToArray();
    }
}