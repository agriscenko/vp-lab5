using System.Text.Json.Serialization;

namespace Lab5.MAUIData.Models;

public class Employee
{
    [JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("firstName")]
    public required string FirstName { get; set; }

	[JsonPropertyName("lastName")]
    public required string LastName { get; set; }

    [JsonPropertyName("phoneNumber")]
    public required string PhoneNumber { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }
}
