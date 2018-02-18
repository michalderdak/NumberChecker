using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class SI : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 8)
            {
                throw new InvalidLengthException();
            }

            if (vat[0] == '0')
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
        /// Calculates and compares checksum
        /// </summary>
        private bool Checksum(string vat)
        {
            int checkDigit = CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            vat = vat.Substring(0, vat.Length - 1);
            int sum = 0;

            for (int i = 0; i < vat.Length; i++)
            {
                sum += (8 - i) * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = 11 - Mod(sum, 11);

            if (check == 10)
            {
                return checkDigit == 0;
            }

            return check == checkDigit;
        }
    }
}
