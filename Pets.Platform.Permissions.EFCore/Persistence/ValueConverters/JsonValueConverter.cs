using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Pets.Platform.Permissions.EFCore.Persistence.ValueConverters
{
    public class JsonValueConverter<T> : ValueConverter<T, string>
        where T : class
    {
        public JsonValueConverter(ConverterMappingHints mappingHints = null)
            : base(v => JsonHelper.Serialize(v), v => JsonHelper.Deserialize<T>(v), mappingHints)
        {

        }
    }

    public class JsonValueComparer<T> : ValueComparer<T>
        where T : class
    {
        public JsonValueComparer()
            : base((l,r) => JsonHelper.Serialize(l) == JsonHelper.Serialize(r), 
                  l => JsonHelper.Serialize(l).GetHashCode(), 
                  l => JsonHelper.Deserialize<T>(JsonHelper.Serialize(l))
                  )
        {

        }
    }

    internal static class JsonHelper
    {
        public static T Deserialize<T>(string json)
            where T : class
        {
            return string.IsNullOrWhiteSpace(json) ? null : JsonSerializer.Deserialize<T>(json);
        }

        public static string Serialize<T>(T obj)
            where T : class
        {
            return obj == null ? null : JsonSerializer.Serialize(obj);
        }
    }
}
