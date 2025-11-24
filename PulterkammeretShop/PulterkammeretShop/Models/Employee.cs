namespace PulterkammeretShop.Models;

public class Employee : Account
{
    public Employee(int Id, string Name, string Password)
    {
        id = Id;
        name = Name;
        password = Password;
    }
}