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
            else if (p < 3)
            {
                // no less or equal to two, cannot be two because key must always be p - 1, if p is 2 key cannot be p - 1
                // because then it would be 1 and keys must be > 1
                Console.WriteLine("P cannot be smaller than 2!");
                Console.Write("Public key P (prime, absolute value taken when negative) [generate randomly]: ");
                isValid = false;
            }
            
        } while (isValid == false);

        if (p < 0)
        {
            Console.WriteLine("P is negative! Taking its absolute value.");
        }
        p = Math.Abs(p);

        if (IsPrime(p)) return p;
        
        for (p -= 1; !IsPrime(p); p--){}

        return p;
    }


    private static int GenerateRandomPrime()
    {
        var rand = new Random();
        var p = rand.Next(3, 1000);
        for (; !IsPrime(p); p = rand.Next(3, 1000)){} 
        
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
                    Console.WriteLine("Base negative, adding P until positive...");
                    break;
            }
            
        } while (isValid == false);

        return g;
    }


    public static int ValidateKey(string personName, string keyName, int p)
    {
        bool isValid;
        var key = 0;
        do
        {
            isValid = true;

            var input = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(personName + " private key " + keyName + " cannot be left blank!");
                Console.Write(personName + " private key " + keyName + ": ");
                isValid = false;
            }
            else if (!int.TryParse(input, out key) || key < 0)
            {
                Console.WriteLine(personName + " private key " + keyName + " must be a positive integer!");
                Console.Write(personName + " private key " + keyName + ": ");
                isValid = false;
            }
            else if (key is 0 or 1)
            {
                Console.WriteLine(personName + " private key " + keyName + " cannot be 0 nor 1!");
                Console.Write(personName + " private key " + keyName + ": ");
                isValid = false;
            }
            else if (key > p)
            {
                key = ReduceKey(key, p);
                Console.WriteLine(personName + " private key " + keyName + " is bigger than P, subtracting until key = P - 1. Key: " + key);
            }
        } while (isValid == false);

        return key;
    }


    private static int ReduceKey(int key, int p)
    {
        while (p <= key)
        {
            key--;
        }

        return key;
    }

    public static int ComputeKey(int g, int key, int p)
    {
        var temp = g % p;
        key -= 1;
        for (; key > 1; key--)
        {
            temp = temp * g % p;
        }
        
        return temp * g % p;
    }


    public static int BruteforceKey(int g, int p, int result)
    {
        int userKey;
        for (var key = 2; ; key++)
        {
            if (ComputeKey(g, key, p) != result) continue;
            userKey = key;
            break;
        }

        return userKey;
    }
}