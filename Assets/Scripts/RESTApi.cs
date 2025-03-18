using Assets.Scripts.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Cysharp.Threading.Tasks;
public static class RESTApi
{
    private static HttpClient httpClient = new HttpClient();

    public static async UniTask<string> POSTApi(RESTDto dto)
    {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://wadahub.manerai.com/api/inventory/status");
        httpRequestMessage.Headers.Add("Authorization", "Bearer kPERnYcWAY46xaSy8CEzanosAgsWM84Nx7SKM4QBSqPq6c7StWfGxzhxPfDh8MaP");
        string json = JsonConvert.SerializeObject(dto);
        StringContent stringContent = new StringContent(json, null, "application.json");
        httpRequestMessage.Content = stringContent;

        var result = await httpClient.SendAsync(httpRequestMessage);
        result.EnsureSuccessStatusCode();
        return await result.Content.ReadAsStringAsync();
    }
}
