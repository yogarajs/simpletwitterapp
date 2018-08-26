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

        public UserRepository()
        {

        }

        public List<UserModel> GetAll()
        {
            return users;
        }

        public UserModel GetByUserName(string userName)
        {
            return users.FirstOrDefault(x => x.Username == userName);
        }
    }
}