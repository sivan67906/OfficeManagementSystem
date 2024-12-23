﻿using System.Text.Json;

namespace OMS.UI.Utilities;

public class Utility
{
    public static Dictionary<string, List<string>> ExtractErrorsFromWebAPIResponse(string body)
    {
        var response = new Dictionary<string, List<string>>();

        var jsonElement = JsonSerializer.Deserialize<JsonElement>(body);
        var errorsJsonElement = jsonElement.GetProperty("errors");
        foreach (var fieldWithErrors in errorsJsonElement.EnumerateObject())
        {
            var field = fieldWithErrors.Name;
            var errors = new List<string>();
            foreach (var errorKind in fieldWithErrors.Value.EnumerateArray())
            {
                var error = errorKind.GetString();
                errors.Add(error);
            }
            response.Add(field, errors);
        }

        return response;
    }
}
