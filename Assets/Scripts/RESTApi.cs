using Assets.Scripts.Models;
using System.Net.Http;
using Cysharp.Threading.Tasks;
using UnityEngine;
public static class RESTApi
{
    private static HttpClient httpClient = new HttpClient();//http клиент

    public static async UniTask<string> POSTApi(RESTDto dto)// пост запрос
    {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://wadahub.manerai.com/api/inventory/status");
        string json = JsonUtility.ToJson(dto);
        StringContent stringContent = new StringContent(json, null, "application/json");
        httpRequestMessage.Content = stringContent;
        httpRequestMessage.Headers.Add("Authorization", "Bearer kPERnYcWAY46xaSy8CEzanosAgsWM84Nx7SKM4QBSqPq6c7StWfGxzhxPfDh8MaP");

        var result = await httpClient.SendAsync(httpRequestMessage);
        Debug.Log(result.StatusCode);

        string text = await result.Content.ReadAsStringAsync();
        return text;
    }
}
