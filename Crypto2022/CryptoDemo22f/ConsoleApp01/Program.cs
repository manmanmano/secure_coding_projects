using ConsoleApp01;

Console.WriteLine("Hello, Caesar!");

string defaultAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!?.";
string defaultShiftAmount = "3";

var alphabet = Helper.GetUserAlphabet(defaultAlphabet);

var shiftAmount = Helper.CheckNumbersInInput(defaultShiftAmount, alphabet.Length);

Console.Write("Plaintext: ");
var plainText = Console.ReadLine();
var plainTextFixed = "";

if (plainText != null)
{
    foreach (var chr in plainText)
    {
        if (alphabet.Contains(chr))
        {
            plainTextFixed += chr;
        }
    }
    Console.WriteLine("Fixed text: " + plainTextFixed);

    var encryptedText = "";
    foreach (var chr in plainTextFixed)
    {
        var pos = alphabet.IndexOf(chr) + shiftAmount % alphabet.Length;
        pos = pos < 0 ? pos + alphabet.Length : pos;
        encryptedText += alphabet[pos];
    }
    Console.WriteLine("Encrypted text: " + encryptedText);
}