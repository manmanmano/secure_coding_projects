using ConsoleAppRSA;

Console.WriteLine("Hello, RSA!");

// private key p
Console.Write("\nPrime p (prime, absolute value taken when negative) [generate randomly]: ");
var p = Helper.ValidatePrime("p");
Console.WriteLine("The biggest possible prime in user defined range: " + p);

// private key q
Console.Write("\nPrime q (prime, absolute value taken when negative) [generate randomly]: ");
var q = Helper.ValidatePrime("q", p);
Console.WriteLine("The biggest possible prime in user defined range: " + q);

// public key
var n = p * q; 

var m = (p - 1) * (q - 1);
var e = Helper.CalculateEulers(m, 1);
Console.Write("Calculated e: " + e);

var y = Helper.EncryptText();