using ConsoleAppDH;


Console.WriteLine("Hello, Diffie Hellman!");

Console.Write("Public key P (prime, absolute value taken when negative) [generate randomly]: ");
var p = Helper.ValidatePrime();
Console.WriteLine("The biggest possible prime in user defined range is " + p);

Console.Write("Public key G (base number): ");
var g = Helper.ValidateBase(p);
Console.WriteLine("Base is " + g);

Console.Write("PersonX private key A: ");
var akey = Helper.ValidateKey("PersonX", "A", p);
Console.WriteLine("PersonX private key A is " + akey);

Console.Write("PersonY private key B: ");
var bkey = Helper.ValidateKey("PersonY", "B", p);
Console.WriteLine("PersonY private key B is " + bkey);

var computeX = Helper.ComputeKey(g, akey, p);
Console.WriteLine($"PersonX computed: {computeX}");

var computeY = Helper.ComputeKey(g, bkey, p);
Console.WriteLine($"PersonY computed: {computeY}");

var computeX2 = Helper.ComputeKey(computeY, akey, p);
Console.WriteLine($"PersonX received {computeY} and computed: {computeX2}");

var computeY2 = Helper.ComputeKey(computeX, bkey, p);
Console.WriteLine($"PersonY received {computeX} and computed: {computeY2}");


// TODO: ModPow algorithm (normal int cannot contain 5^15)
// TODO: Bruteforce the keys