Console.WriteLine("Hello, RSA!");

// TODO: validate inputs
// TODO: check prime

Console.Write("Prime p: ");
var p = long.Parse(Console.ReadLine()?.Trim());

Console.Write("Prime q: ");
var q = long.Parse(Console.ReadLine()?.Trim());

var n = p * q; 
var m = (p - 1) * (q - 1);

long e = 1;
long gcd = 0;
do
{
    e++;
    gcd = GCD(m, e);
} while (gcd != 1 && e < m);

if (e > m)
{
    throw new ApplicationException("e > m");
}

Console.Write($"e: {e}");

static long GCD(long a, long b)
{
    if (a == 0) return b;
    return GCD(b % a, a);
}