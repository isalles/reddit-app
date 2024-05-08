using System.Text.Json.Serialization;

namespace Reddit.Framework.Models
{
    [Serializable]
    public class RedditPostData
    {
        [JsonPropertyName("approved_at_utc")]
        public string? ApprovedAtUTC { get; set; }

        [JsonPropertyName("subreddit")]
        public string? Subreddit { get; set; }

        [JsonPropertyName("selftext")]
        public string? SelfText { get; set; }

        [JsonPropertyName("author_fullname")]
        public string? AuthorFullName { get; set; }

        [JsonPropertyName("saved")]
        public bool Saved { get; set; }

        [JsonPropertyName("mod_reason_title")]
        public string? ModReasonTitle { get; set; }

        [JsonPropertyName("gilded")]
        public int Gilded { get; set; }

        [JsonPropertyName("clicked")]
        public bool Clicked { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("link_flair_richtext")]
        public List<RedditLinkFlair>? LinkFlairRichtext { get; set; }

        [JsonPropertyName("subreddit_name_prefixed")]
        public string? SubredditNamePrefixed { get; set; }

        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        [JsonPropertyName("pwls")]
        public int Pwls { get; set; }

        [JsonPropertyName("link_flair_css_class")]
        public string? LinkFlairCSSClass { get; set; }

        [JsonPropertyName("downs")]
        public int Downs { get; set; }

        [JsonPropertyName("thumbnail_height")]
        public int? ThumbnailHeight { get; set; }

        [JsonPropertyName("top_awarded_type")]
        public string? TopAwardType { get; set; }

        [JsonPropertyName("hide_score")]
        public bool HideScore { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("quarantine")]
        public bool Quarantine { get; set; }

        [JsonPropertyName("link_flair_text_color")]
        public string? LinkFlairTextColor { get; set; }

        [JsonPropertyName("upvote_ratio")]
        public double UpvoteRatio { get; set; }

        [JsonPropertyName("author_flair_background_color")]
        public string? AuthorFlairBackgroundColor { get; set; }

        [JsonPropertyName("subreddit_type")]
        public string? SubredditType { get; set; }

        [JsonPropertyName("ups")]
        public int Ups { get; set; }

        [JsonPropertyName("total_awards_received")]
        public int? TopAwardsReceived { get; set; }

        [JsonPropertyName("media_embed")]
        public object? MediaEmbed { get; set; }

        [JsonPropertyName("thumbnail_width")]
        public int? ThumbnailWidth { get; set; }

        [JsonPropertyName("author_flair_template_id")]
        public string? AuthorFlairTemplateId { get; set; }

        [JsonPropertyName("is_original_content")]
        public bool IsOriginalContent { get; set; }

        [JsonPropertyName("author")]
        public string? Author { get; set; }
    }
}