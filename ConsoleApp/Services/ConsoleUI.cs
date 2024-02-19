using ConsoleApp.Factories;

namespace ConsoleApp.Services;

public class ConsoleUI(UserService userService)
{
    private readonly UserService _userService = userService;

    public async Task MainMenu()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1. Create Consultant");
            var option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    await MenuOptionOne(); 
                    break;
            }

            Console.ReadKey();
        }
    }

    public async Task MenuOptionOne()
    {
        var userRegistration = UserFactory.Create();

        Console.Clear();
        Console.WriteLine("CREATE CONSULTANT");
        
        Console.Write("Enter first name: ");
        userRegistration.FirstName = Console.ReadLine()!;
        
        Console.Write("Enter last name: ");
        userRegistration.LastName = Console.ReadLine()!;
        
        Console.Write("Enter email: ");
        userRegistration.Email = Console.ReadLine()!;

        var result = await _userService.GetUserAsync(userRegistration);
        if (result != null)
        {
            Console.WriteLine("User with same email already exists.");
        }
        else
        {
            await _userService.CreateUserAsync(userRegistration);
        }
    
    }
}
