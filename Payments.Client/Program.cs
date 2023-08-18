using Payments.Model.Models;

var user = new User()
{
    Name = "UserName",
    Info = new UserInfo()
    {
        Age = 30,
        Comment = "User comment",
    },
};

var url = "https://localhost:7186/payments";
HttpClient httpClient = new HttpClient()
{
    BaseAddress = new Uri(url)
};