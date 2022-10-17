namespace ConsoleAppRSA;

public class Helper
{
   public static string? ValidatePlaintext()
   {
      bool isEmpty;
      string? plaintext;
      do
      {
         plaintext = Console.ReadLine();
         isEmpty = false;
         if (string.IsNullOrWhiteSpace(plaintext))
         {
            Console.Write("Plaintext cannot be an empty string!\nPlaintext: ");
            isEmpty = true;
         }
      } while (isEmpty);

      return plaintext;
   }
   
   
   public static long ValidatePrime(string prime, long q = 0)
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
            Console.WriteLine(prime + " must be an integer!");
            Console.Write("Public key " + prime + " (prime, absolute value taken when negative) [generate randomly]: ");
            isValid = false;
         }
         else if (p < 3)
         {
            Console.WriteLine(prime + " cannot be smaller than 2!");
            Console.Write("Public key " + prime + " (prime, absolute value taken when negative) [generate randomly]: ");
            isValid = false;
         }
         else if (p == q)
         {
            Console.WriteLine("p and q cannot be equal!");
            Console.Write("Public key " + prime + " (prime, absolute value taken when negative) [generate randomly]: ");
            isValid = false;
         }
            
      } while (isValid == false);

      if (p < 0)
      {
         Console.WriteLine(prime + " is negative! Taking its absolute value.");
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

   
   public static List<long> EncryptTextBytes(List<long> byteList, long e, long n)
   {
      var encryptedByteList = new List<long>();
      foreach (var b in byteList)
      {
         encryptedByteList.Add(ComputeModPow(b, e, n));
      }

      return encryptedByteList;
   }
   

   public static long CalculateD(long m, long e, long k)
   {
      double d;
      do
      {
         d = (double)(1 + m * k) / e;
         k++;
      } while (d % e != 0);
      
      return (long)d;
   }
   
   
   public static byte[] DecryptTextBytes(List<long> byteList, long d, long n)
   {
      var decryptedByteList = new byte[byteList.Count];
      for (int i = 0; i < byteList.Count; i++)
      {
         decryptedByteList[i] = (byte)ComputeModPow(byteList[i], d, n);
         
      }
      
      return decryptedByteList;
   }

}