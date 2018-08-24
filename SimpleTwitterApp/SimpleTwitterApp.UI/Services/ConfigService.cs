using System.Configuration;

namespace SimpleTwitterApp.UI.Services
{
    public interface IApiConfigService
    {
        string TwitterApiUrl { get; }

        string TweesGetAllEndPoint { get; }

        string UsersGetAllEndPoint { get; }
    }

    public class ApiConfigService : IApiConfigService
    {     
        public string TwitterApiUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["Twitter_API_Url"];
            }
        }

        public string TweesGetAllEndPoint
        {
            get
            {
                return ConfigurationManager.AppSettings["Tweets_Endpoint"];
            }
        }

        public string UsersGetAllEndPoint
        {
            get
            {
                return ConfigurationManager.AppSettings["Users_Endpoint"];
            }
        }
    }
}