using System;
using System.Linq;
using GeekTrust.Contracts;
using GeekTrust.Models;

namespace GeekTrust
{
    public class SeasarCipher : ICipher
    {

        public bool Decipher(SecretMessage message)
        {
            var emblemLength = message.Recipient.Emblem.Length;

            //Optimization: Ensure message length is sufficient to cover emblem length
            if (message.Content.Length < emblemLength)
                return default;

            var decipheredChars = message.Content
                                         .ToUpper()
                                         .ToCharArray()
                                         .Select(c => GetDecipheredChar(c, emblemLength))
                                         .ToArray();

            System.Diagnostics.Debug.WriteLine($"{message.Recipient.Name.PadRight(6, ' ')} :: {message.Recipient.Emblem.PadRight(10, ' ')} :: {new string(decipheredChars)}");

            var emblem = message.Recipient.Emblem.ToUpper();
            var matchIndex = -1;
            foreach (var c in decipheredChars)
            {
                matchIndex = emblem.IndexOf(c);
                if (matchIndex > -1)
                {
                    emblem = emblem.Remove(matchIndex, 1);

                    //Exit the loop if all characters have matched
                    if (emblem.Length == 0)
                        break;
                }
            }

            return emblem.Length == 0;
        }

        private char GetDecipheredChar(char c, int length)
        {
            var shiftedIndex = _allowedChars.IndexOf(c) - length;

            //Using <_allowedChars.Length> below ensures we dont have to update the below logic if the Cipher wheel changes
            var finalIndex = (shiftedIndex >= 0 ? shiftedIndex : shiftedIndex + _allowedChars.Length);

            return _allowedChars[finalIndex];
        }

        string _allowedChars = new string(Enumerable.Range(65, 26).Select(c => Convert.ToChar(c)).ToArray());

    }
}