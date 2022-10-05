namespace ConsoleAppDH;

public class Helper
{
    public static int ValidateP()
    { 
        bool isValid;
        int p;
        do
        { 
            isValid = true;
            
            var input = Console.ReadLine()?.Trim();
            if (!int.TryParse(input, out p))
            {
                Console.WriteLine("P must be an integer!");
                isValid = false;
            }
            else if (p is 0 or 1)
            {
                Console.WriteLine("P cannot be 0 or 1!");
                isValid = false;
            }
            
            
        } while (isValid == false);

        // Just deal with the absolute value of P
        p = Math.Abs(p);

        if (!IsPrime(p))
        {
            for (var i = p - 1; i > 1; i--)
            {
                if (IsPrime(i))
                {
                    p = i;
                    break;
                }
            }
        }

        Console.WriteLine(p);
        return p;
    }

    
    private static bool IsPrime(int p)
    {
        var isPrime = true;
        for (var i = p - 1; i > 1; i--)
        {
            if (p % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        return isPrime;
    }
    
}