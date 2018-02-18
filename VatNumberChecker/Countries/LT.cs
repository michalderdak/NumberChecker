using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class LT : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 9 && vat.Length != 12)
            {
                throw new InvalidLengthException();
            }

            if (vat.Length == 9 && vat[7] != '1')
            {
                throw new InvalidFormatException();
            }

            if (vat.Length == 12 && vat[10] != '1')
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
        /// Calculates and compare checksum
        /// </summary>
        private bool Checksum(string vat)
        {
            int sum = 0;
            int checkDigit = CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            vat = vat.Substring(0, vat.Length - 1);

            for (int i = 0; i < vat.Length; i++)
            {
                sum += (1 + Mod(i, 9)) * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = Mod(sum, 11);

            if (check == 10)
            {
                for (int i = 0; i < vat.Length; i++)
                {
                    sum += (1 + Mod(i + 2, 9)) * CharUnicodeInfo.GetDigitValue(vat[i]);
                }
            }

            return checkDigit == Mod(Mod(check, 11), 10);
        }

    }
}
