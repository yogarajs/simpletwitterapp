using System;
using System.Data.Common;
using System.Data.Entity;

namespace SimpleTwitterApp.API.Contexts
{
    public interface ITweetContext : IDisposable
    {

    }

    public class TweetContext :DbContext
    {
        /// <summary>
        /// Constructor used for test case for creating connection
        /// </summary>
        /// <param name="connection">connectionstring</param>
        public TweetContext(DbConnection connection)
            : base(connection, true)
        {
        }
    }
}