using System.Numerics;
using ConsoleAppDH;

// codes used in input validation function to differentiate output
int pCode = 0, gCode = 1, pXCode = 2, pYCode = 3;

Console.WriteLine("Hello, Diffie Hellman!");

Console.Write("Public key P (prime) [generate randomly]: ");
int p;
var isPrime = int.TryParse(Console.ReadLine()?.Trim(), out p);
if (!isPrime)
{
    p = Helper.ValidateInput(pCode);
}

// TODO: Check, that it is a prime
// TODO: Generate for user the biggest prime under user specified value
p = Helper.CheckPrime(p);

// Console.Write("Public key G (base number): ");
// var g = int.Parse(Console.ReadLine()?.Trim());
// 
// Console.Write("PersonX private key A: ");
// var a = int.Parse(Console.ReadLine()?.Trim());
// 
// Console.Write("PersonY private key B: ");
// var b = int.Parse(Console.ReadLine()?.Trim());
// 
// // TODO: memory overflow (int cannot contain 5^15) 
// // var computeX =  (long)Math.Pow(g, a)  % p;
// // TODO: implement your own ModPow, using long/int
// var computeX = (long) BigInteger.ModPow(g, a,p);
// Console.WriteLine($"PersonX computed: {computeX}");
// 
// // var computeY =  (long)Math.Pow(g, b)  % p;
// var computeY = (long) BigInteger.ModPow(g, b,p);
// 
// Console.WriteLine($"PersonY computed: {computeY}");
// 
// // var computeX2 = (long) Math.Pow(computeY, a) % p;
// var computeX2 = (long) BigInteger.ModPow(computeY, a, p);
// Console.WriteLine($"PersonX received {computeY} and computed: {computeX2}");
// 
// // var computeY2 = (long) Math.Pow(computeX, b) % p;
// var computeY2 = (long) BigInteger.ModPow(computeX, b, p);
// Console.WriteLine($"PersonY received {computeX} and computed: {computeY2}");


// TODO: Prime number control
// TODO: Prime number generator
// TODO: ModPow algorithm (normal int cannot contain 5^15)
// TODO: Bruteforce the keys