using SimpleTwitterApp.UI.Models;
using System.Collections.Generic;

namespace SimpleTwitterApp.UI.Services
{
    public interface IUserService
    {
        bool ValidateUser(string username, string password);

        List<UserModel> GetAll();
    }

    public class UserService : IUserService
    {
        ITwitterApiRestClient _twitterApiRestClient;
        IApiConfigService _apiConfigService;

        public UserService()
        {
            _twitterApiRestClient = new TwitterApiRestClient();
            _apiConfigService = new ApiConfigService();
        }

        public List<UserModel> GetAll()
        {
            var userModel = _twitterApiRestClient.GetAll<List<UserModel>>(_apiConfigService.UsersGetAllEndPoint);
            return userModel;
        }

        public bool ValidateUser(string username, string password)
        {
            var endpoint = $"{ _apiConfigService.UsersGetByUsernameEndPoint}{username}";
            var user = _twitterApiRestClient.Get<UserModel>(endpoint);
            return user != null && user.Password == password;
        }
    }
}