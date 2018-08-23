using System;
using System.Configuration;
using System.Web;
using Newtonsoft.Json;
using RestSharp;

namespace SimpleTwitterApp.UI.Services
{
    public interface ITwitterApiRestClient
    {
        void AddTweet<T>(T model);

        T GetAll<T>();
    }

    public class TwitterApiRestClient : ITwitterApiRestClient
    {
        RestClient mRestClient;

        public TwitterApiRestClient()
        {
            mRestClient = new RestClient(ConfigurationManager.AppSettings["Twitter_API_Url"]);
        }

        public void AddTweet<T>(T model)
        {
            throw new NotImplementedException();
        }

        public T GetAll<T>()
        {
            var request = new RestRequest("/tweet", Method.GET) { RequestFormat = DataFormat.Json };
            var response = mRestClient.Execute(request);
            T responseEntity = default(T);

            if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 300)
            {
                responseEntity = JsonConvert.DeserializeObject<T>(response.Content);
            }
            else
            {
                throw new HttpException((int)response.StatusCode, response.ErrorMessage);
            }
            return responseEntity;
        }
    }
}