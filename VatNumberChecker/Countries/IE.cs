using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class IE : CountryBase
    {
        public override bool StripLetters => false;

        public override string Validate(string vat)
        {
            if (vat.Length != 8 && vat.Length != 9)
            {
                throw new InvalidLengthException();
            }

            if (!Checksum(vat))
            {
                throw new InvalidChecksumException();
            }

            return vat;
        }

        /// <summary>
        /// Calculates and compares checksum
        /// </summary>
        /// <param name="vat"></param>
        /// <returns></returns>
        private bool Checksum(string vat)
        {
            string number;

            if ("ABCDEFGHIJKLMNOPQRSTUVWXYZ+*".Contains(vat[1].ToString()))
            {
                number = vat.Substring(2, 5) + vat[0];
                return vat[7] == CalculateCheck(number);
            }

            number = vat.Remove(7, 1);
            return vat[7] == CalculateCheck(number);
        }

        private char CalculateCheck(string vat)
        {
            string alphabet = "WABCDEFGHIJKLMNOPQRSTUV";

            int length = 7 - vat.Length;

            for (int i = 0; i < length; i++)
            {
                vat = "0" + vat;
            }

            int sum = 0;

            for (int i = 0; i < 7; i++)
            {
                sum += (8 - i) * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            return alphabet[Mod(sum + 9 * alphabet.IndexOf(vat.Substring(7)), 23)];
        }
    }
}
