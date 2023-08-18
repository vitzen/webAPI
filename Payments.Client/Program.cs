using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
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

var url = "http://localhost:5194/payments/";
HttpClient httpClient = new HttpClient()
{
    BaseAddress = new Uri(url)
};

var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
var response = await httpClient.PostAsJsonAsync($"createUser", user);
if (response.IsSuccessStatusCode)
{
    var createdUser = await response.Content.ReadFromJsonAsync<User>();
    Console.WriteLine(createdUser);
}