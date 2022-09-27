using System.Numerics;

Console.WriteLine("Hello, Diffie Hellman!");

// TODO: Check that it is a prime
// TODO: Generate for user the biggest prime under user specified input
Console.Write("Public key P (prime): ");
var p = int.Parse(Console.ReadLine()?.Trim());

Console.Write("Public key G (base number): ");
var g = int.Parse(Console.ReadLine()?.Trim());

Console.Write("Person X private key A: ");
var a = int.Parse(Console.ReadLine()?.Trim());

Console.Write("Person Y private key B: ");
var b = int.Parse(Console.ReadLine()?.Trim());

// TODO: Memory overflow (int cannot contain 5^15), applicate formulas
// TODO: Implement your own ModPow, using long/int

// var computeX = (long)Math.Pow(g, a) % p;
var computeX = (long)BigInteger.ModPow(g, a, p);
Console.WriteLine($"Person X computed: {computeX}");

// var computeY = (long)Math.Pow(g, b) % pa;
var computeY = (long)BigInteger.ModPow(g, b, p);
Console.WriteLine($"Person Y computed: {computeY}");

// var computeX2= (long)Math.Pow(g, b) % p;
var computeX2 = (long)BigInteger.ModPow(computeY, a, p);
Console.WriteLine($"Person X received {computeY} computed: {computeX2}");

// var computeY2= (long)Math.Pow(g, b) % p;
var computeY2 = (long)BigInteger.ModPow(computeX, a, p);
Console.WriteLine($"PersonX received {computeX} computed: {computeY2}");
