using Payments.Model.Models;

namespace Payments.Db;

public class PaymentsManager
{
    private readonly PaymentsDbContext _paymentsDbContext;

    public PaymentsManager(PaymentsDbContext paymentsDbContext)
    {
        _paymentsDbContext = paymentsDbContext;
    }

    /// <summary>
    /// Метод который возвращает через менеджер-обертку пользователей
    /// </summary>
    /// <returns></returns>
    public User[] GetUsers()
    {
        return _paymentsDbContext.Users.ToArray();
    }

    /// <summary>
    /// Метод который возвращает через менеджер-обертку транзакции по userId
    /// </summary>
    /// <returns></returns>
    public Transaction[] GetTransactionsByUserId(int userId)
    {
        return _paymentsDbContext.Transactions.Where(x => x.UserId == userId).ToArray();
    }
}