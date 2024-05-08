#region Usings

using Reddit.Console.Services;
using Reddit.Framework.Models;

#endregion

namespace Reddit.Console
{
    internal class Program
    {
        #region Fields

        static string _subreddit;

        #endregion

        #region Main

        static async Task Main(string[] args)
        {
            System.Console.WriteLine("Starting up the Reddit Console\n");
            System.Console.WriteLine("To exit the console either close the window or type in 'exit'\n");

            bool continueLoop = true;

            _subreddit = string.Empty;

            do
            {
                System.Console.WriteLine("Enter in a subreddit to query:");
                _subreddit = System.Console.ReadLine();

                if (string.IsNullOrEmpty(_subreddit))
                {
                    System.Console.WriteLine("Please enter a valid subreddit name.");
                }

            } while (string.IsNullOrEmpty(_subreddit));

            do
            {
                await DetermineTopPosts();

            } while (continueLoop);
        }

        #endregion

        #region Methods

        private static async Task DetermineTopPosts()
        {
            var posts = await ApiCalls.GetSubredditPosts(_subreddit);
            var users = CountUserPosts(posts);

            var topPost = posts.OrderByDescending(p => p.Ups).Take(1).FirstOrDefault();
            var topUser = users.OrderByDescending(pair => pair.Value).FirstOrDefault();

            System.Console.Clear();

            System.Console.WriteLine($"Current top post from /r/{_subreddit}:\n");
            System.Console.WriteLine($"Tile: {topPost?.Title} | UpVotes: {topPost?.Ups}");

            System.Console.WriteLine($"\nCurrent top user posting in /r/{_subreddit}:\n");
            System.Console.WriteLine($"User: {topUser.Key}");
        }

        static Dictionary<string, int> CountUserPosts(List<RedditPostData> posts)
        {
            Dictionary<string, int> userPostCounts = [];

            foreach (var post in posts)
            {
                string author = post.Author;
                if (!string.IsNullOrEmpty(author))
                {
                    if (userPostCounts.ContainsKey(author))
                    {
                        userPostCounts[author]++;
                    }
                    else
                    {
                        userPostCounts[author] = 1;
                    }
                }
            }
            return userPostCounts;
        }

        #endregion
    }
}