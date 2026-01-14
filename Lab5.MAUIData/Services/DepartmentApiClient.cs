using Lab5.MAUIData.Interfaces;
using System.Text.Json;

namespace Lab5.MAUIData.Services;

public class DepartmentApiClient : IDepartmentApiClient
{
    private readonly HttpClient _httpClient;

    public static string BaseAddress =
        DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5205" : "http://localhost:5205";

    public DepartmentApiClient()
    {
        _httpClient = new HttpClient();
    }

    public async Task<T[]> GetItemsAsync<T>(string url) where T : class
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseAddress}/{url}");
        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var items = JsonSerializer.Deserialize<T[]>(json, options);

        return items;
    }

    public async Task DeleteItemAsync(string url)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"{BaseAddress}/{url}");
        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateItemAsync<T>(string url, T entity) where T : class
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"{BaseAddress}/{url}");
        var content = new StringContent(JsonSerializer.Serialize(entity), null, "application/json");

        request.Content = content;

        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
    }
}
