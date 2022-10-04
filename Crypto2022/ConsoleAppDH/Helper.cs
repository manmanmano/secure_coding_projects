namespace ConsoleAppDH;

public class Helper
{
    public static int ValidateInput(int functionCode)
    { 
        Console.WriteLine("Input must be an integer!");
        bool isInt;
        string? input;
        int p;
        do
        {
            isInt = true;
            switch (functionCode)
            {
                case 0:
                    Console.Write("Public key P (prime) [generate randomly]: ");
                    break;
            }
            input = Console.ReadLine()?.Trim();
            if (!int.TryParse(input, out p))
            {
                Console.WriteLine("Input must be an integer!");
                isInt = false;
            }
        } while (isInt == false);
        return p;
    }
    
    
    public static int CheckPrime(int prime)
    {
        var input = 0;
        if (prime == 0)
        {
        }
        return 0;
    }
}