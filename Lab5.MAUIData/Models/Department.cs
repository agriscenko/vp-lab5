using System.Text.Json.Serialization;

namespace Lab5.MAUIData.Models;

public class Department
{
    [JsonPropertyName("id")]
	public int Id { get; set; }

    [JsonPropertyName("code")]
	public required string Code { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("floornumber")]
    public required int FloorNumber { get; set; }
}
