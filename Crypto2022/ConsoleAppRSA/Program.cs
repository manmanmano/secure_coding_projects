using ConsoleAppRSA;

Console.WriteLine("Hello, RSA!");

Console.Write("\nMessage: ");
var plaintext = Helper.ValidatePlaintext();

var plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext!);
Console.Write("Plaintext bytes: ");
// print out bytes of plaintext
foreach (var b in plaintextBytes) Console.Write(b + " ");

// convert plaintextBytes to long arraylist, bytes numbers will be to big for bytes type
var byteList = plaintextBytes.Select(b => (long)b).ToList();

// private key p
Console.Write("\n\nPrime p (prime, absolute value taken when negative) [generate randomly]: ");
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
Console.WriteLine("\nCalculated e: " + e);

var encryptedTextBytes = Helper.EncryptText(byteList, e, n);
Console.Write("\nText bytes after encryption: ");
foreach (var b in encryptedTextBytes) Console.Write(b + " ");