﻿using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Digbyswift.Experian.Core.Extensions;

public static class ObjectExtensions
{
    public static string Serialize(this object obj)
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
    }

    public static async Task<T> DeserializeAsync<T>(this Stream stream) where T : class
    {
        return await JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
    }
}