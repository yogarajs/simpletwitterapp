using SimpleTwitterApp.API.Contexts;
using SimpleTwitterApp.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTwitterApp.API.Repositories
{
    public interface IUserRepository
    {
        List<UserModel> GetAll();

        UserModel GetByUserName(string userName);
    }

    public class UserRepository : IUserRepository
    {
        static readonly List<UserModel> users = new List<UserModel>()
        {
                new UserModel()
                {
                    Username = "yogarajs",
                    Password = "4113",
                    FirstName = "FN",
                    MiddleName = "MN",
                    LastName = "LN"
                },
                new UserModel()
                {
                    Username = "rajans",
                    Password = "4113",
                    FirstName = "FN",
                    MiddleName = "MN",
                    LastName = "LN"
                }
        };

        readonly ITweetContext _tweetContext;

        public UserRepository()
        {
            _tweetContext = new TweetContext();
        }

        public List<UserModel> GetAll()
        {
            var users = from user in _tweetContext.Users
                        select new UserModel()
                        {
                            Username = user.Username,
                            FirstName = user.FirstName,
                            MiddleName = user.MiddleName,
                            LastName = user.LastName
                        };

            return users.ToList();
        }

        public UserModel GetByUserName(string userName)
        {
            var userModel = from user in _tweetContext.Users
                            where user.Username == userName
                            select new UserModel()
                            {
                                Username = user.Username,
                                FirstName = user.FirstName,
                                MiddleName = user.MiddleName,
                                LastName = user.LastName,
                                Password = user.Password
                            };

            return userModel.FirstOrDefault();
        }
    }
}