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

    /// <summary>
    /// Метод для добавления пользователя в базу
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<User> CreateUser(User user)
    {
        _paymentsDbContext.Users.Add(user);
        await _paymentsDbContext.SaveChangesAsync();
        return user;
    }

    /// <summary>
    /// Метод для добавления трансакции
    /// </summary>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public async Task<Transaction> CreateTransaction(Transaction transaction)
    {
        _paymentsDbContext.Transactions.Add(transaction);
        await _paymentsDbContext.SaveChangesAsync();
        return transaction;

    }
}