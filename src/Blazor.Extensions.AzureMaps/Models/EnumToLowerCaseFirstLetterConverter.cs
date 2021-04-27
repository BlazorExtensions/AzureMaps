using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blazor.Extensions.AzureMaps
{
    internal class EnumToLowerCaseFirstLetterConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct
    {
        private static readonly Type _supportedType = typeof(TEnum);

        public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var source = reader.GetString();
            if (source == null) return default(TEnum);
            var target = string.Create(source.Length, source, (chars, state) =>
            {
                state.AsSpan().CopyTo(chars);
                chars[0] = char.ToUpperInvariant(chars[0]);
            });

            return Enum.Parse<TEnum>(target);
        }

        public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
        {
            var source = value!.ToString();
            var target = string.Create(source!.Length, source, (chars, state) =>
            {
                state.AsSpan().CopyTo(chars);
                chars[0] = char.ToLowerInvariant(chars[0]);
            });
            writer.WriteStringValue(target);
        }
    }
}