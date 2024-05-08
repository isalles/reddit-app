# region Usings

using Microsoft.AspNetCore.Mvc;
using Reddit.Framework.Models;
using System.Net.Http.Headers;
using System.Text.Json;

#endregion

namespace Reddit.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RedditController : ControllerBase
    {
        #region Fields

        private readonly IConfiguration _configuration;
        private readonly ILogger<RedditController> _logger;
        private readonly string? _baseApiUrl;
        private readonly string? _refreshToken;

        #endregion

        #region Constructors

        public RedditController(
            ILogger<RedditController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            _baseApiUrl = _configuration.GetValue<string>("RedditBaseUrl");
            _refreshToken = _configuration.GetValue<string>("RefreshToken");
        }

        #endregion

        #region GET Methods

        [HttpGet(Name = "GetVersion")]
        public IEnumerable<string> GetVersion()
        {
            return new List<string>
            {
                $"Information: {typeof(RedditController).Assembly.GetName().FullName}"
            };
        }

        [HttpGet(Name = "GetTopPostsAsync")]
        public async Task<List<RedditPostData>> GetTopPostsAsync(string subreddit)
        {
            var redditPosts = new List<RedditPostData>();

            string url = $"{_baseApiUrl}{subreddit}/new.json?sort=top";

            _logger.LogDebug("Starting up HttpClient in GetTopPostsAsync.");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _refreshToken);
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("test-app");

                _logger.LogDebug($"Making a GET request to {url}.");

                var response = await httpClient.GetAsync(url);

                var rateRemaining = response.Headers.GetValues("x-ratelimit-remaining").FirstOrDefault();

                _logger.LogDebug($"Retrieved rate limit remaing: {rateRemaining}.");

                if (Convert.ToInt32(rateRemaining) == 0) return redditPosts;

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogDebug($"Successful call to {url}.");

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var redditListing = JsonSerializer.Deserialize<RedditListing>(responseBody);

                    redditPosts = redditListing?.Data?.Children?.Select(child => child.Data).ToList();

                    _logger.LogDebug($"Deserialized response successfully.");
                }
                else
                {
                    _logger.LogDebug($"Failed to retrieve subreddit posts. Status code: {response.StatusCode}");
                }
            }

            return redditPosts;
        }

        #endregion
    }
}