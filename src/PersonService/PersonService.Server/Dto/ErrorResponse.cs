using System.Text.Json.Serialization;

namespace PersonService.Server.Dto;

public class ErrorResponse(string message)
{
    [JsonPropertyName("message")]
    [JsonRequired]
    public string Message { get; set; } = message;
}
