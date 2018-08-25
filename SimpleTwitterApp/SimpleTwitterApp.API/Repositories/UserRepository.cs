using SimpleTwitterApp.API.Models;
using System.Collections.Generic;

namespace SimpleTwitterApp.API.Repositories
{
    public interface IUserRepository
    {
        List<UserModel> GetAll();
    }

    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {

        }

        public List<UserModel> GetAll()
        {
            return new List<UserModel>()
            {
                new UserModel()
                {
                    UserId = 11,
                    FirstName = "FN",
                    MiddleName = "MN",
                    LastName = "LN"
                },
                new UserModel()
                {
                    UserId = 12,
                    FirstName = "FN",
                    MiddleName = "MN",
                    LastName = "LN"
                }
            };
        }
    }
}