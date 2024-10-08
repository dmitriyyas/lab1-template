using System.Text.Json.Serialization;

namespace PersonService.Server.Dto;

public class PersonRequest(string name,
    int? age,
    string? address,
    string? work)
{
    [JsonPropertyName("name")]
    [JsonRequired]
    public string Name { get; set; } = name;

    [JsonPropertyName("age")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Age { get; set; } = age;

    [JsonPropertyName("address")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Address { get; set; } = address;

    [JsonPropertyName("work")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Work { get; set; } = work;
}
