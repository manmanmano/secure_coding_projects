using ConsoleAppDH;


Console.WriteLine("Hello, Diffie Hellman!");

Console.Write("Public key P (prime, absolute value taken when negative) [generate randomly]: ");
var p = Helper.ValidatePrime();
Console.WriteLine("The biggest possible prime in user defined range: " + p);

Console.Write("Public key G (base number): ");
var g = Helper.ValidateBase(p);

Console.Write("PersonX private key A: ");
var akey = Helper.ValidateKey("PersonX", "A", p);

Console.Write("PersonY private key B: ");
var bkey = Helper.ValidateKey("PersonY", "B", p);

var computeX = Helper.ComputeKey(g, akey, p);
Console.WriteLine($"\nPersonX computed: {computeX}");

var computeY = Helper.ComputeKey(g, bkey, p);
Console.WriteLine($"PersonY computed: {computeY}");

var computeX2 = Helper.ComputeKey(computeY, akey, p);
Console.WriteLine($"PersonX received {computeY} and computed: {computeX2}");

var computeY2 = Helper.ComputeKey(computeX, bkey, p);
Console.WriteLine($"PersonY received {computeX} and computed: {computeY2}");

var bruteforceX = Helper.BruteforceKey(g, p, computeX);
Console.WriteLine($"\nPersonX bruteforced key: {bruteforceX}");

var bruteforceY = Helper.BruteforceKey(g, p, computeY);
Console.WriteLine($"PersonY bruteforced key: {bruteforceY}");