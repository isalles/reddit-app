#region Usings

using Microsoft.Extensions.Configuration;
using Reddit.Console.Utility;
using Reddit.Framework.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

#endregion

namespace Reddit.Console.Services
{
    internal class ApiCalls
    {
        #region Fields

        private static IConfigurationRoot _configuration =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        #endregion

        #region

        public static async Task<List<RedditPostData>> GetSubredditPosts(string subreddit)
        {
            var redditApiUrl = new AppSettings(_configuration).GetSetting("RedditApi");

            var posts = new List<RedditPostData>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(redditApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"api/Reddit/GetTopPosts?subreddit={subreddit}");

                response.EnsureSuccessStatusCode();

                posts = await response.Content.ReadFromJsonAsync<List<RedditPostData>>();
            }

            return posts;
        }

        #endregion
    }
}