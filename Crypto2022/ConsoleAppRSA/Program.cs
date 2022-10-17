using ConsoleAppRSA;

Console.WriteLine("Hello, RSA!");

// TODO: validate inputs
// TODO: check prime

// private key p
Console.Write("\nPrime p (prime, absolute value taken when negative) [generate randomly]: ");
var p = Helper.ValidatePrime();
Console.WriteLine("The biggest possible prime in user defined range: " + p);

// private key q
Console.Write("\nPrime q (prime, absolute value taken when negative) [generate randomly]: ");
var q = Helper.ValidatePrime();
Console.WriteLine("The biggest possible prime in user defined range: " + q);

// public key
var n = p * q; 

var m = (p - 1) * (q - 1);

long e = 1;
long gcd = 0;
do
{
    e++;
    gcd = Helper.Gcd(m, e);
} while (gcd != 1 && e < m);

if (e > m)
{
    throw new ApplicationException("e > m");
}

Console.Write($"e: {e}");