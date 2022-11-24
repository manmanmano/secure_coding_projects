using ConsoleAppCaesarUTF;

Console.WriteLine("Hello, Caesar UTF!");

// check plaintext is not empty
Console.Write("Plaintext: ");
var plaintext = Helper.GetPlaintext();  

var plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext!);
Console.Write("Plaintext bytes: ");
// print out bytes of plaintext
foreach (var b in plaintextBytes) Console.Write(b + " ");

Console.WriteLine();
var shiftAmount = Helper.ValidateShiftAmount();

var shiftedBytes = Helper.EncryptBytes(plaintextBytes, shiftAmount);

Console.Write("Bytes after shifting: ");
// print out bytes of plaintext
foreach (var b in shiftedBytes) Console.Write(b + " ");

// encode the shifted plaintext to base64 and print out
var b64Text = System.Convert.ToBase64String(shiftedBytes);
Console.Write("\nThe shifted plaintext in base64: " + b64Text);

// DECRYPT

// get back unencoded bytes
var unencodedShiftedBytes = System.Convert.FromBase64String(b64Text);

// unshift/decrypt bytes
var unshiftedBytes = Helper.UnshiftBytes(unencodedShiftedBytes, shiftAmount);
Console.Write("\nPlaintext bytes after unshifting: ");
foreach (var b in unshiftedBytes) Console.Write(b + " ");

// decrypt bytes to text
var decryptedText = System.Text.Encoding.UTF8.GetString(unshiftedBytes);
Console.WriteLine("\nThe decrypted plaintext: " + decryptedText);