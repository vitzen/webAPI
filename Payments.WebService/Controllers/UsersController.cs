using Microsoft.AspNetCore.Mvc;
using Payments.Db;
using Payments.Model.Models;

namespace Payments.WebService.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly PaymentsManager _paymentsManager;

    public UsersController(PaymentsManager paymentsManager)
    {
        _paymentsManager = paymentsManager;
    }

    [HttpGet]
    [Route("getUsers")]
    public ActionResult<User[]> GetUsers()
    {
        return Ok(_paymentsManager.GetUsers());
    }

    [HttpPost]
    [Route("createUser")]
    public OkObjectResult CreateUser(User user)
    {
        return Ok(_paymentsManager.SaveUser(user));
    }
} 