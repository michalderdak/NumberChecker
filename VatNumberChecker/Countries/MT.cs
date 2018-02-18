using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class MT : CountryBase
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
            int[] weights = {3, 4, 6, 7, 8, 9, 10, 1};
            int sum = 0;

            for (int i = 0; i < vat.Length; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            return Mod(sum, 37) == 0;
        }
    }
}
