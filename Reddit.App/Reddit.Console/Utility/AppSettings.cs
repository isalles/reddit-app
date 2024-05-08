#region Usings

using Microsoft.Extensions.Configuration;

#endregion

namespace Reddit.Console.Utility
{
    public class AppSettings
    {
        #region Properties

        private readonly IConfiguration _configuration;

        #endregion

        #region Constructors

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        #region Methods

        public string GetConnectionString(string connectionString)
        {
            return _configuration.GetConnectionString(connectionString);
        }

        public string GetSetting(string setting)
        {
            return _configuration[setting];
        }

        #endregion
    }
}