using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class PL : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 10)
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
        private bool Checksum(string vat)
        {
            int[] weights = {6, 5, 7, 2, 3, 4, 5, 6, 7, -1};
            int sum = 0;

            for(int i = 0; i < vat.Length; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            return Mod(sum, 11) == 0;
        }
    }
}
