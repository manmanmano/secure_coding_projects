﻿using ConsoleAppVigenere;

Console.WriteLine("Hello, Vigenere!");

// check plaintext is not empty
Console.Write("Plaintext: ");
var plaintext = Helper.GetPlaintext();  

// check passphrase is not empty
Console.Write("Passphrase: ");
var passphrase = Helper.GetPassphrase();

var plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext!);
Console.Write("\nPlaintext bytes: ");
// print out bytes of plaintext
foreach (var b in plaintextBytes) Console.Write(b + " ");

var passphraseBytes = System.Text.Encoding.UTF8.GetBytes(passphrase!);
// making it a list, so that I do not have to deal with memory allocation
List<int> passphraseInts = new List<int>();
// add passphraseBytes to list of int
foreach (var b in passphraseBytes)
{
    passphraseInts.Add(b);
}
Console.Write("\nPassphrase bytes: ");
// print out bytes of passphrase
foreach (var b in passphraseInts) Console.Write(b + " ");

// validate the key, either trim or make the key longer if not equal
Helper.ValidateKeyLength(plaintextBytes, passphraseInts);
Console.Write("\nPassphrase bytes after validation: ");
// print out bytes of new validated passphrase
foreach (var b in passphraseInts) Console.Write(b + " ");


// ENCRYPTION PHASE

var shiftedBytes = new byte[plaintextBytes.Length];
// encrypt with Vigenere's formula
for (int i = 0; i < plaintextBytes.Length; i++)
{
    shiftedBytes[i] = (byte)((plaintextBytes[i] + passphraseInts[i]) % 255);
}
// print out new bytes of shifted value
Console.Write("\n\nPlaintext bytes after Vigenere encryption: ");
foreach (var b in shiftedBytes) Console.Write(b + " ");

// encode the encrypted plaintext to base64 and print out
var b64Text = System.Convert.ToBase64String(shiftedBytes);
Console.Write("\nThe encrypted plaintext: " + b64Text);


// DECRYPTION PHASE

// get back unencoded bytes
var unencodedShiftedBytes = System.Convert.FromBase64String(b64Text);
// unshift/decrypt bytes with Vigenere's formula
for (int i = 0; i < shiftedBytes.Length; i++)
{
    unencodedShiftedBytes[i] = (byte)((unencodedShiftedBytes[i] - passphraseInts[i] + 255) % 255);
}
Console.Write("\n\nPlaintext bytes after Vigenere decryption: ");
foreach (var b in unencodedShiftedBytes) Console.Write(b + " ");

// decrypt bytes to text
var decryptedText = System.Text.Encoding.UTF8.GetString(unencodedShiftedBytes);
Console.WriteLine("\nThe decrypted plaintext: " + decryptedText);