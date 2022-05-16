using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

public class HTTPTest : MonoBehaviour
{

    private async void Start()
    {

        var client = new HttpClient();

        var result = await client.SendAsync(
            new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://reqbin.com/echo"),
                Content = new StringContent(
                    JsonConvert.SerializeObject(new Dictionary<string, string> { { "hello", "world" } }),
                    Encoding.UTF8, "application/json"),
            });

        var response = await result.Content.ReadAsStringAsync();

        Debug.Log(response);

    }

}
