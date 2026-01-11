using System.Text.Json.Serialization;

namespace Lab5.MAUIData.Models;

public class Employee
{
    [JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("firstname")]
    public required string FirstName { get; set; }

	[JsonPropertyName("lastname")]
    public required string LastName { get; set; }
}
