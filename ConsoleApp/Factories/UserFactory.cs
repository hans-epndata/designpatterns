using ConsoleApp.Models;

namespace ConsoleApp.Factories;

public class UserFactory
{
    public static UserRegistration Create()
    {
        return new UserRegistration();
    }
}
