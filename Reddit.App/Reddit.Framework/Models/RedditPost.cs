using System.Text.Json.Serialization;

namespace Reddit.Framework.Models
{
    [Serializable]
    public class RedditPost
    {
        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("data")]
        public RedditPostData? Data { get; set; }
    }
}