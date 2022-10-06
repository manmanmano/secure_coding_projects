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
            if (string.IsNullOrWhiteSpace(input))
            {
                return GenerateRandomPrime();
            }
            
            if (!int.TryParse(input, out p))
            {
                Console.WriteLine("P must be an integer!");
                Console.Write("Public key P (prime) [generate randomly]: ");
                isValid = false;
            }
            else if (p is 0 or 1)
            {
                // no 0 or 1
                Console.WriteLine("P cannot be 0 or 1!");
                Console.Write("Public key P (prime) [generate randomly]: ");
                isValid = false;
            }
            
        } while (isValid == false);

        p = Math.Abs(p);

        if (IsPrime(p)) return p;
        
        for (p -= 1; !IsPrime(p); p--){}

        return p;
    }

    
    private static int GenerateRandomPrime()
    {
        var rand = new Random();
        var p = rand.Next(2, 1000);
        for (; !IsPrime(p); p = rand.Next(2, 1000)){} 
        
        return p;
    }
    
    
    private static bool IsPrime(int p)
    {
        var isPrime = true;
        for (var i = p - 1; i > 1; i--)
        {
            if (p % i != 0) continue;
            isPrime = false;
            break;
        }

        return isPrime;
    }
    
}