# simpletwitterapp

Simple Twitter App

Technologies used
- Web API 2
- ASP.NET MVC
- EntityFramework
- SQL Server
- LINQ to data store and retrieve 

Functionalities completed
- List tweets from multiple users in UI
- Tweets are stored in [tweet] table
- user informations are stored in [user] table
- user device details are stored in [user_device] table
- Retrieve tweet for single user.
- Add new tweet for an user.

Best practices

- Separated Entity and Model in Web API
- Separated Entity and Column mapping i.e instead of doing using DataAnnotation configured in OnModelCreating()
- Used interface for all contracts and all methods are called via interface.
- Maintained all endpoints in Web.config
- Used contants.
- Used filters for authorization, exception handling (only for HTTP exception)
- Used partial views

Areas to improve in funtionality
- User registration
- AJAX implementation
- Web api authorization.

Areas to improve in development
- Need to implement dependency injection. (Now all the objects are created in constructor and all methods are called via interface so it is easy to implement constructor dependency injection with minimal code change)
- Unit testing
- Data validation
