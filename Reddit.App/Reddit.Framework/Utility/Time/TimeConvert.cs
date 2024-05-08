using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reddit.Framework.Utility.Time
{
    public abstract class TimeConvert : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null && value is DateTime date && date != default(DateTime))
            {
                writer.WriteRawValue(ConvertToSeconds(date).ToString());
            }
            else
            {
                writer.WriteNull();
            }
        }

        public abstract long ConvertToSeconds(DateTime dateTime);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value != null)
            {
                var valueString = reader.Value.ToString();
                if (valueString?.Length > 0 &&
                    !bool.TryParse(valueString, out bool parsedBool))
                {
                    if (DateTime.TryParse(valueString, out DateTime parsedDate))
                    {
                        return parsedDate;
                    }

                    return ParseDateFromSeconds((long)Convert.ToDouble(valueString));
                }
            }

            return default(DateTime);
        }

        public abstract DateTime ParseDateFromSeconds(long seconds);
    }
}