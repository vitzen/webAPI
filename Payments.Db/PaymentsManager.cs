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
    /// Метод для получения пользователя по userId
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public User GetUser(int userId)
    {
        return _paymentsDbContext.Users.FirstOrDefault(x => x.Id == userId);
    }

    /// <summary>
    /// Метод для создания пользователя по userId
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public User GetOrCreateUser(int userId)
    {
        var user = GetUser(userId);
        if (user == null)
        {
            user = new User()
            {
                Id = userId,
                Name = "newUser " + DateTime.Now
            };
            SaveUser(user);
        }

        return user;
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
    /// Метод для добавления пользователя в базу
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public User SaveUser(User user)
    {
        _paymentsDbContext.Users.Add(user);
        _paymentsDbContext.SaveChangesAsync();
        return user;
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
    /// Метод для добавления трансакции
    /// </summary>
    /// <param name="transaction"></param>
    /// <returns></returns>
    public Transaction CreateTransaction(int userId)
    {
        GetOrCreateUser(userId);

        Transaction transaction = new Transaction()
        {
            UserId = userId,
            CreatedDate = DateTime.UtcNow
        };

        _paymentsDbContext.Transactions.Add(transaction);
        _paymentsDbContext.SaveChanges();
        return transaction;
    }
}