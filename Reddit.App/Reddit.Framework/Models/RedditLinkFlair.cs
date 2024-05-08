using System.Text.Json.Serialization;

namespace Reddit.Framework.Models
{
    [Serializable]
    public class RedditLinkFlair
    {
        [JsonPropertyName("e")]
        public string? E { get; set; }

        [JsonPropertyName("t")]
        public string? T { get; set; }
    }
}