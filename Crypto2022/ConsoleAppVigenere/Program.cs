using ConsoleAppVigenere;


Console.Write("Plaintext: ");
var plaintext = Helper.GetPlaintext();  

Console.Write("Passphrase: ");
var passphrase = Helper.GetPassphrase();

var encryptedString = Helper.EncryptText(plaintext, passphrase);
Console.WriteLine("\nThe encrypted string is: " + encryptedString);