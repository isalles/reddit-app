#region Usings

using Reddit.AuthTokenRetriever;
using System.Diagnostics;

#endregion

namespace Reddit.Token.Console
{
    /// <summary>
    /// This class is using the Reddit.NET class to optain the token to be used for the Reddit.Api project.
    /// </summary>
    public class Program
    {
        #region Fields

        const string _appId = "<APP_ID>";
        const string _appSecret = "<APP_SECRET>";
        const string _browserPath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

        #endregion

        #region Main

        static void Main(string[] args)
        {
            System.Console.WriteLine("Retrieving new token...");

            var token = AuthorizeUser(_appId, _appSecret);

            System.Console.WriteLine($"New Token: {token}");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Authorize the user and return the token using the Reddit.NET package.
        /// </summary>
        /// <param name="appId">The App Id for the Reddit registered app.</param>
        /// <param name="appSecret">The App secret used along with the App Id.</param>
        /// <param name="port">The default port number for the return callback.</param>
        /// <returns>A Reddit token will be returned if successful.</returns>
        public static string AuthorizeUser(string appId, string appSecret = null, int port = 8080)
        {
            var authTokenRetrieverLib = new AuthTokenRetrieverLib(appId, appSecret, port);

            authTokenRetrieverLib.AwaitCallback();

            OpenBrowser(authTokenRetrieverLib.AuthURL());

            System.Console.ReadKey();

            authTokenRetrieverLib.StopListening();

            return authTokenRetrieverLib.RefreshToken;
        }

        /// <summary>
        /// Opens a browser and proceeds to Reddit.com.
        /// </summary>
        /// <param name="authUrl">The requesting authoritive URL to Reddit.com.</param>
        /// <param name="browserPath">The path to the local browser installation.</param>
        public static void OpenBrowser(string authUrl, string browserPath = _browserPath)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(authUrl);
                Process.Start(processStartInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo(browserPath)
                {
                    Arguments = authUrl
                };
                Process.Start(processStartInfo);
            }
        }

        #endregion
    }
}