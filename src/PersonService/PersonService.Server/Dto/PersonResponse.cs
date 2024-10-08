using System.Text.Json.Serialization;

namespace PersonService.Server.Dto;

public class PersonResponse(int id,
    string name,
    int? age,
    string? address,
    string? work)
{
    [JsonPropertyName("id")]
    [JsonRequired]
    public int Id { get; set; } = id;

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
