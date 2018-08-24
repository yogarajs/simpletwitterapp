using System;
using System.Web;
using Newtonsoft.Json;
using RestSharp;

namespace SimpleTwitterApp.UI.Services
{
    public interface ITwitterApiRestClient
    {
        void AddTweet<T>(T model);

        T GetAll<T>(string endPoint);
    }

    public class TwitterApiRestClient : ITwitterApiRestClient
    {
        RestClient mRestClient;

        public TwitterApiRestClient()
        {
            IApiConfigService apiConfigService = new ApiConfigService();
            mRestClient = new RestClient(apiConfigService.TwitterApiUrl);
        }

        public void AddTweet<T>(T model)
        {
            throw new NotImplementedException();
        }

        public T GetAll<T>(string endPoint)
        {
            var request = new RestRequest(endPoint, Method.GET) { RequestFormat = DataFormat.Json };
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