namespace Payments.Model.Models;

public class UserInfo
{
    public int Id { get; set; }
    public int userId { get; set; }
    public string Comment { get; set; }
    public byte Age { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, userId: {userId}, Comment: {Comment}, Age: {Age}";
    }
}