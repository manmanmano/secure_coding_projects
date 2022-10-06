namespace ConsoleAppDH;


public class Helper
{
    public static int ValidatePrime()
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
                Console.WriteLine("P cannot be 0 nor 1!");
                Console.Write("Public key P (prime) [generate randomly]: ");
                isValid = false;
            }
            
        } while (isValid == false);

        p = Math.Abs(p);

        if (IsPrime(p)) return p;
        
        for (p -= 1; !IsPrime(p); p--){}

        return p;
    }


    public static int ValidateBase(int p)
    {
        bool isValid;
        var g = 0;
        do
        { 
            isValid = true;
            
            var input = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Base cannot be left blank!");
                Console.Write("Public key G (base number): ");
                isValid = false;
            }
            else if (!int.TryParse(input, out g))
            {
                Console.WriteLine("Base must be an integer!");
                Console.Write("Public key G (base number): ");
                isValid = false;
            }
            else switch (g)
            {
                case 0 or 1:
                    // no 0 or 1
                    Console.WriteLine("Base cannot be 0 nor 1!");
                    Console.Write("Public key G (base number): ");
                    isValid = false;
                    break;
                case < 0:
                    do
                    {
                        g += p;
                    } while (g < 1);
                    break;
            }
            
        } while (isValid == false);

        return g;
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