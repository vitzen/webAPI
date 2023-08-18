namespace Payments.Model.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public UserInfo Info { get; set; }

    public List<Transaction>? TransactionsList { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Info: {Info}";
    }
}

