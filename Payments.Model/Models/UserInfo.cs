namespace Payments.Model.Models;

public class UserInfo
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Comment { get; set; }
    public byte Age { get; set; }
    public User? User { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, userId: {UserId}, Comment: {Comment}, Age: {Age}";
    }
}