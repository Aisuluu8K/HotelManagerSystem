using System.Text.Json;

namespace HotelManagerSystem.Models.Responses;

public class Response
{
    public Response(int statusCode, bool success, string message)
    {
        StatusCode = statusCode;
        Success = success;
        Message = message;
    }

    public int StatusCode { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}