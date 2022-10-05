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
                // If input is whitespace, null, or empty generate a random prime from 2 to 1000
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

        // Just deal with the absolute value of P
        p = Math.Abs(p);

        // If p is prime return it
        if (IsPrime(p)) return p;
        
        // Find biggest possible prime in user range, if user input is not prime
        for (p -= 1; !IsPrime(p); p--){}

        return p;
    }


    private static int GenerateRandomPrime()
    {
        var rand = new Random();
        var p = rand.Next(2, 1000);
        while (true)
        {
            if (IsPrime(p))
            {
                break;
            }

            p = rand.Next(2, 1000);
        }

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