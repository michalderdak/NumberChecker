using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class FI : CountryBase
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
        /// Calculates and comapres checksum with 0
        /// </summary>
        private bool Checksum(string vat)
        {
            int[] weights = {7, 9, 10, 5, 8, 4, 2, 1};
            int sum = 0;

            for (int i = 0; i < vat.Length; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = Mod(sum, 11);

            return check == 0;
        }
    }
}
