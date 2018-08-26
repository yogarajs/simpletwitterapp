using System.Configuration;

namespace SimpleTwitterApp.UI.Services
{
    public interface IApiConfigService
    {
        string TwitterApiUrl { get; }

        string TweetsEndPoint { get; }

        string TweetsGetAllByUsernameEndPoint { get; }

        string UsersGetAllEndPoint { get; }

        string UsersGetByUsernameEndPoint { get; }
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

        public string TweetsEndPoint
        {
            get
            {
                return ConfigurationManager.AppSettings["Tweets_Endpoint"];
            }
        }

        public string TweetsGetAllByUsernameEndPoint
        {
            get
            {
                return ConfigurationManager.AppSettings["Tweets_Get_All_By_Username_EndPoint"];
            }
        }

        public string UsersGetAllEndPoint
        {
            get
            {
                return ConfigurationManager.AppSettings["Users_Get_All_Endpoint"];
            }
        }

        public string UsersGetByUsernameEndPoint
        {
            get
            {
                return ConfigurationManager.AppSettings["Users_Get_By_Username_Endpoint"];
            }
        }
    }
}