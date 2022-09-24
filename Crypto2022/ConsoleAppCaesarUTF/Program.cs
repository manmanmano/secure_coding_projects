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

// shift the bytes
var b64Text = System.Convert.ToBase64String(plainTextBytes);
Console.WriteLine("B64 text: " + b64Text);

// unshift the bytes
var decryptedBytes = System.Convert.FromBase64String(b64Text);
var decryptedText = System.Text.Encoding.UTF8.GetString(decryptedBytes);

Console.WriteLine("decrypted text: " + decryptedText);