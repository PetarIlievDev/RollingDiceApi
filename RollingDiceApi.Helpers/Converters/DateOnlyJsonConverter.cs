using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RollingDiceApi.Helpers.Converters
{
    public sealed class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string Format = "MM/yyyy/dd";
        private const string FormatMonthAndYear = "MM/yyyy";
        private const string FormatYear = "yyyy";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var fullDataSuccess = DateOnly.TryParseExact(reader.GetString(), Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly result);
            if (fullDataSuccess)
            {
                return result;
            }
            var monthAndYearSuccess = DateOnly.TryParseExact(reader.GetString(), FormatMonthAndYear, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly resultMonthAndYear);
            if (monthAndYearSuccess)
            {
                return resultMonthAndYear;
            }
            var yearSuccess = DateOnly.TryParseExact(reader.GetString(), FormatYear, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly resultYear);
            if (yearSuccess)
            {
                return resultYear;
            }

            throw new JsonException("Invalid date");
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
        }
    }
}
