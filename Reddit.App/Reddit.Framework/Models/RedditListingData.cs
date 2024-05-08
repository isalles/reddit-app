using System.Text.Json.Serialization;

namespace Reddit.Framework.Models
{
    [Serializable]
    public class RedditListingData
    {
        [JsonPropertyName("after")]
        public string? After { get; set; }

        [JsonPropertyName("dist")]
        public int Dist { get; set; }

        [JsonPropertyName("modhash")]
        public string? Modhash { get; set; }

        [JsonPropertyName("geofilter")]
        public object? GeoFilter { get; set; }

        [JsonPropertyName("children")]
        public List<RedditPost>? Children { get; set; }

        [JsonPropertyName("before")]
        public object? Before { get; set; }
    }
}