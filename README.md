# unity-http-get-with-body-request

## Reproducing Issue

1. Create new project (no template)
1. Add `com.unity.nuget.newtonsoft-json` package via the Unity Package Manager.
1. Create new script with the name of `HTTPTest` and paste the following code into it:

   ```csharp
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
   ```

1. Hit play

## Results

If you are running this on macOS, you will get a valid response from the server.

However, if you are on Windows, you will get the following error:

```
ProtocolViolationException: Cannot send a content-body with this verb-type.
```

As they are both running .NET Standard 2.1, this doesn't feel like the expected result.
