namespace ConsoleAppRSA;

public class Helper
{
   public static long ValidatePrime()
   { 
      bool isValid;
      long p;
      do
      { 
         isValid = true;
            
         var input = Console.ReadLine()?.Trim();
         if (string.IsNullOrWhiteSpace(input))
         {
                
            return GenerateRandomPrime();
         }
         
         if (!long.TryParse(input, out p))
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
   
   
   private static bool IsPrime(long p)
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
   
   
   private static long GenerateRandomPrime()
   {
      var rand = new Random();
      var p = rand.Next(3, 1000);
      for (; !IsPrime(p); p = rand.Next(3, 1000)){} 
        
      return p;
   }

   
   public static long Gcd(long a, long b)
   {
      return a == 0 ? b : Gcd(b % a, a);
   }
}