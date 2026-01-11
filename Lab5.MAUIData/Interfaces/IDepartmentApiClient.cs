namespace Lab5.MAUIData.Interfaces;

public interface IDepartmentApiClient
{
    Task<T[]> GetItemsAsync<T>(string url) where T : class;

    Task DeleteItemAsync(string url);

    Task UpdateItemAsync<T>(string url, T entity) where T : class;
}
