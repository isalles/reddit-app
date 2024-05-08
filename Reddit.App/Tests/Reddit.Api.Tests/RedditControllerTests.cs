#region Usings

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Reddit.Api.Controllers;
using Reddit.Framework.Models;

#endregion

namespace Reddit.Api.Tests
{
    public class RedditControllerTests
    {
        #region Fields

        private Mock<ILogger<RedditController>> _loggerMock;
        private IConfiguration _configurationMock;
        private RedditController _controller;

        #endregion

        #region Constructor

        public RedditControllerTests()
        {
            _loggerMock = new Mock<ILogger<RedditController>>();

            var configValues = new Dictionary<string, string>
            {
                {"RedditBaseUrl", "http://www.reddit.com/r/"},
                {"RefreshToken", "2232384746267-sXGSqcMC8zWyLifwlyG8urTqaqnvUg"},
            };

            _configurationMock = new ConfigurationBuilder()
                                        .AddInMemoryCollection(configValues)
                                        .Build();

            _controller = new RedditController(
                _loggerMock.Object,
                _configurationMock
            );
        }

        #endregion

        #region Test Methods

        [Fact(DisplayName = "Test GetVersion")]
        public void GetVersion_Test()
        {
            var response = _controller.GetVersion();

            Assert.IsType<List<string>>(response);
            Assert.NotNull(response);
        }

        [Fact(DisplayName = "Test GetTopPostsAsync")]
        public async void GetTopPostsAsync_Test()
        {
            var subreddit = "funny";

            var response = await _controller.GetTopPostsAsync(subreddit);

            Assert.IsType<List<RedditPostData>>(response);
            Assert.NotNull(response);
        }

        #endregion
    }
}