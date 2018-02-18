using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class NL : CountryBase
    {
        public override bool StripLetters => false;

        public override string Validate(string vat)
        {
            vat = Compact(vat);

            if (vat.Length != 12)
            {
                throw new InvalidLengthException();
            }

            if (vat[9] != 'B')
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
        /// Repaires damaged vat number
        /// </summary>
        private string Compact(string vat)
        {
            string number = vat.Substring(0, vat.Length - 3);
            int length = 9 - number.Length;

            for (int i = 0; i < length; i++)
            {
                number = "0" + number;
            }

            return number + vat.Substring(vat.Length - 3);
        }

        /// <summary>
        /// Calculates and compares checksum
        /// </summary>
        private bool Checksum(string vat)
        {
            vat = vat.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < vat.Length - 1; i++)
            {
                sum += (9 - i) * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = sum - CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);

            return Mod(check, 11) == 0;
        }
    }
}
