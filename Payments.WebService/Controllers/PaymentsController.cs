using Microsoft.AspNetCore.Mvc;
using Payments.Db;
using Payments.Model.Models;

namespace Payments.WebService.Controllers;

[Route("[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly PaymentsManager _paymentsManager;

    public PaymentsController(PaymentsManager paymentsManager)
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
    public async Task<OkObjectResult> CreateUser(User user)
    {
        return Ok(await _paymentsManager.CreateUser(user));
    }
}