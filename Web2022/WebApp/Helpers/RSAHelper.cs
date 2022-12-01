namespace WebApp.Helpers;

public class RSAHelper
{
   
   public static long ValidateP(long p)
   { 
      bool isValid;
      do
      { 
         isValid = true;

         if (p < 0)
         {
            p = Math.Abs(p);
         }
         if (p < 3)
         {
            p = GenerateRandomPrime();
            isValid = false;
         }
      } while (isValid == false);

      if (IsPrime(p)) return p;
        
      for (p -= 1; !IsPrime(p); p--){}

      return p;
   }
   
   
   public static long ValidateQ(long p, long q)
   { 
      bool isValid;
      do
      { 
         isValid = true;

         if (q < 0)
         {
            q = Math.Abs(q);
            isValid = false;
         }
         if (q < 3)
         {
            q = GenerateRandomPrime();
            isValid = false;
         }

         if (p == q)
         {
            q = GenerateRandomPrime();
            isValid = false;
         }
      } while (isValid == false);

      if (IsPrime(q)) return q;
        
      for (q -= 1; !IsPrime(q); q--){}

      return q;
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
      var p = rand.Next(100, 10000);
      for (; !IsPrime(p); p = rand.Next(100, 10000)){} 
        
      return p;
   }

   
   public static long CalculateE(long m, long e)
   {
         long gcd;
         do
         {
            e++;
            gcd = Gcd(m, e);
         } while (gcd != 1 && e < m);

         if (e > m)
         {
            throw new ApplicationException("e > m");
         }

         return e;
   }

   
   private static long Gcd(long a, long b)
   {
      return a == 0 ? b : Gcd(b % a, a);
   }

   
   private static long ComputeModPow(long msg, long e, long n)
   {
      var temp = msg % n;
      e -= 1;
      for (; e > 1; e--)
      {
         temp = temp * msg % n;
      }
        
      return temp * msg % n;
   }

   
   public static string EncryptTextBytes(List<long> byteList, long e, long n)
   {
      var encryptedByteList = new List<long>();
      foreach (var b in byteList)
      {
         encryptedByteList.Add(ComputeModPow(b, e, n));
      }

      return string.Join(" ", encryptedByteList);
   }
}