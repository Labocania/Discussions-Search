using System.Collections.Generic;
using System.Text.Json;
using ForumSearch.Models;

namespace ForumSearch
{
    public class CategoryDeserializer
    {
        public JsonDocument Document { get; private set; }
        public readonly List<Category> Categories = new();

        public CategoryDeserializer(JsonDocument document)
        {
            Document = document;
            using (Document)
            {
                foreach (JsonElement element in Document.RootElement.GetProperty("root").EnumerateArray())
                {
                    Categories.Add(element.ToObject<Category>());
                }
            }
        }
    }

    // Credits: https://stackoverflow.com/a/59047063 User: https://stackoverflow.com/users/3744182/dbc
    // Converts JsonElement straight to C# class.
    public static partial class JsonExtensions
    {
        public static T ToObject<T>(this JsonElement element, JsonSerializerOptions options = null)
        {
            var bufferWriter = new System.Buffers.ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(bufferWriter))
                element.WriteTo(writer);
            return JsonSerializer.Deserialize<T>(bufferWriter.WrittenSpan, options);
        }

        public static T ToObject<T>(this JsonDocument document, JsonSerializerOptions options = null)
        {
            if (document == null)
                throw new System.ArgumentNullException(nameof(document));
            return document.RootElement.ToObject<T>(options);
        }
    }
}
