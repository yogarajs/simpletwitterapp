using System;
using System.Web;
using Newtonsoft.Json;
using RestSharp;

namespace SimpleTwitterApp.UI.Services
{
    public interface ITwitterApiRestClient
    {
        void Save<T>(T model, string endPoint);

        T GetAll<T>(string endPoint);

        T Get<T>(string endPoint);
    }

    public class TwitterApiRestClient : ITwitterApiRestClient
    {
        RestClient mRestClient;

        public TwitterApiRestClient()
        {
            IApiConfigService apiConfigService = new ApiConfigService();
            mRestClient = new RestClient(apiConfigService.TwitterApiUrl);
        }

        public void Save<T>(T model, string endPoint)
        {
            var request = new RestRequest(endPoint, Method.POST) { RequestFormat = DataFormat.Json };
            var requestBody = JsonConvert.SerializeObject(model);

            request.AddHeader("Authorization", "true");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/Json", requestBody, ParameterType.RequestBody);

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

        public T Get<T>(string endPoint)
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