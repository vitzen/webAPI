using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payments.Db;
using Payments.Model.Models;

namespace Payments.WebService.Controllers;

[Route("[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly PaymentsManager _paymentsManager;

    public TransactionController(PaymentsManager paymentsManager)
    {
        _paymentsManager = paymentsManager;
    }

    /// <summary>
    /// Метод для получения транзакции по userId
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{userId}")]
    public ActionResult<Transaction[]> GetTransactionByUserId(int userId)
    {
        return Ok(_paymentsManager.GetTransactionsByUserId(userId));
    }

    /// <summary>
    /// Метод для создания транзакции
    /// </summary>
    /// <param name="transaction"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createTransaction")]
    public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
    {
        transaction = await _paymentsManager.CreateTransaction(transaction);
        return Ok(transaction);
    }
}