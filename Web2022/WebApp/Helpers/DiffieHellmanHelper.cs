namespace WebApp.Helpers;

public class DiffieHellmanHelper
{
    private static int GenerateRandomNum()
    {
        var rand = new Random();
        var p = rand.Next(2, 500);
        
        return p;
    }
    
    public static int ValidatePrime(int p)
    {
        if (p < 0)
        { 
            // Deal with absolute value of the number in input
            p = Math.Abs(p);
        }
        else if (p < 3)
        {
            // no less or equal to two, cannot be two because key must always be p - 1, if p is 2 key cannot be p - 1
            // because then it would be 1 and keys must be > 1
            p = 3;
        }
        
        if (IsPrime(p)) return p;
        
        for (p -= 1; !IsPrime(p); p--){}

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
    
    
    public static int ValidateBase(int p, int g)
    {
        bool isValid;
        do
        { 
            isValid = true;
            if (g > p)
            {
                g %= p;
                isValid = false;
            }
            else if (g == p)
            {
                g -= 1;
                isValid = false;
            }
            else switch (g)
            {
                case 0 or 1:
                    g = 2;
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


    public static int ValidateKey(int p, int key)
    {
        bool isValid;
        do
        {
            isValid = true;

            if (key < 0)
            {
                key = ;
                isValid = false;
            }
            else if (key is 0 or 1)
            {
                key = 2;
                isValid = false;
            }
            else if (key > p)
            {
                key = ReduceKey(key, p);
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
}