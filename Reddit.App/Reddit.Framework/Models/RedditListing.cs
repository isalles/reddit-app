using System.Text.Json.Serialization;

namespace Reddit.Framework.Models
{
    [Serializable]
    public class RedditListing
    {
        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("data")]
        public RedditListingData? Data { get; set; }
    }
}