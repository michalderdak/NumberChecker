using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class DK : CountryBase
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
            int sum = 0;
            int[] weights = {2, 7, 6, 5, 4, 3, 2, 1};

            for (int i = 0; i < 8; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            return Mod(sum, 11) == 0;
        }
    }
}
