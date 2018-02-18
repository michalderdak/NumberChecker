using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class EE : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 9)
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
            int[] weights = {3, 7, 1, 3, 7, 1, 3, 7, 1};
            int sum = 0;

            for (int i = 0; i < vat.Length; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = Mod(sum, 10);

            return check == 0; 
        }
    }
}
