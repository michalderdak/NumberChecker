using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class CY : CountryBase
    {
        public override bool StripLetters => false;

        public override string Validate(string vat)
        {
            if (vat.Length != 9)
            {
                throw new InvalidLengthException();
            }

            if (!Char.IsLetter(vat[vat.Length - 1]))
            {
                throw new InvalidFormatException();
            }

            if (!Checksum(vat))
            {
                throw new InvalidChecksumException();
            }

            return vat;
        }

        /// <summary>
        /// Calculates the checksum and compares it with check
        /// </summary>
        private bool Checksum(string vat)
        {
            char checkChar = vat[vat.Length - 1];
            vat = vat.Substring(0, vat.Length - 1);

            Dictionary<char, int> translation = new Dictionary<char, int>()
            {
                {'0', 1},
                {'1', 0},
                {'2', 5},
                {'3', 7},
                {'4', 9},
                {'5', 13},
                {'6', 15},
                {'7', 17},
                {'8', 19},
                {'9', 21}
            };

            int sum1 = vat.Where((x, i) => Mod(i, 2) == 1).Sum(CharUnicodeInfo.GetDigitValue);
            int sum2 = vat.Where((x, i) => Mod(i, 2) == 0).Sum(c => translation[c]);
            
            return checkChar == "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[Mod(sum1 + sum2, 26)];
        }
    }
}