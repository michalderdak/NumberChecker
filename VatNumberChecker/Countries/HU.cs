using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class HU : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 8)
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
        /// Calculates and compares chcecksum
        /// </summary>
        private bool Checksum(string vat)
        {
            int[] weights = {9, 7, 3, 1, 9, 7, 3, 1};
            int sum = 0;

            for (int i = 0; i < 8; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            return Mod(sum, 10) == 0;
        }
    }
}
