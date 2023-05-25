using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStorage.Common.Extensions;

public static class HttpResponseMessageExtension
{
    public async static Task<string> GetModelAsString(this HttpResponseMessage message)
    {
        var modelAsString  = await message.Content.ReadAsStringAsync();
        return modelAsString;
    }

    public async static Task<T> AsModel<T>(this HttpResponseMessage message)
    {
        if (message.IsSuccessStatusCode)
        {
            var modelAsJSON = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(modelAsJSON);
        }
        return default(T);
    }
}
