using SimpleTwitterApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleTwitterApp.UI.Services
{
    public interface ITwitterApiRestClient
    {
        void AddTweet<T>(T model);

        IEnumerable<T> GetAll<T>();
    }

    public class TwitterApiRestClient : ITwitterApiRestClient
    {
        public void AddTweet<T>(T model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }
    }
}