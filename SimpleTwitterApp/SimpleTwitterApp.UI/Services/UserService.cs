using SimpleTwitterApp.UI.Models;
using System.Collections.Generic;

namespace SimpleTwitterApp.UI.Services
{
    public interface IUserService
    {
        List<UserModel> GetAll();
    }

    public class UserService : IUserService
    {
        public List<UserModel> GetAll()
        {
            ITwitterApiRestClient twitterApiRestClient = new TwitterApiRestClient();
            IApiConfigService apiConfigService = new ApiConfigService();
            var userModel = twitterApiRestClient.GetAll<List<UserModel>>(apiConfigService.UsersGetAllEndPoint);
            return userModel;
        }
    }
}