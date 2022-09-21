// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Console.Write("Shift amount: ");
var amount = int.Parse(Console.ReadLine() ?? string.Empty);

Console.Write("Plain text: ");
var plaintext = Console.ReadLine();

var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext!);
foreach (var b in plainTextBytes)
{
    Console.WriteLine(b);
}