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
        public List<UserModel> GetAll()
        {
            return new List<UserModel>()
            {
                new UserModel()
                {
                    UserId = 11
                },
                new UserModel()
                {
                    UserId = 12
                }
            };
        }
    }
}