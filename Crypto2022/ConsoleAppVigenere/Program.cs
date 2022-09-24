using ConsoleAppVigenere;

Console.Write("Plaintext: ");
var plaintext = Helper.GetPlaintext();  

Console.Write("Passphrase: ");
var passphrase = Helper.GetPassphrase();

/*
Console.Write("Passphrase: ");
var passphrase = Console.ReadLine();

var plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext!);
Console.Write("Bytes for plaintext : ");
foreach (var b in plaintextBytes)
{
    Console.Write(b + " ");
}

var passphraseBytes = System.Text.Encoding.UTF8.GetBytes(passphrase!);
Console.Write("\nBytes for plaintext : ");
foreach (var b in passphraseBytes)
{
    Console.Write(b + " ");
}
*/