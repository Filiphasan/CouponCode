using System.Text.Json.Serialization;

namespace Web.Common.Models.BillOcr;

public class BillOcrResponse
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [JsonPropertyName("locale")]
    public string? Locale { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    
    [JsonPropertyName("boundingPoly")]
    public BillOcrBoundingPoly BoundingPoly { get; set; } = null!;
}

public class BillOcrBoundingPoly
{
    [JsonPropertyName("vertices")]
    public BillOcrBoundingPolyVertices[] Vertices { get; set; } = [];
}

public class BillOcrBoundingPolyVertices
{
    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }
}