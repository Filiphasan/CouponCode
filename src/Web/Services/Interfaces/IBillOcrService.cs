namespace Web.Services.Interfaces;

public interface IBillOcrService
{
    Task<string> GetBillOcrStringAsync();
}