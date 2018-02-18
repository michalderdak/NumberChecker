using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class RO : CountryBase
    {
        //Missing validation for length 13 - couldn't find any reliable source
        public override string Validate(string vat)
        {
            if (vat.Length != 13 && !(vat.Length >= 2 && vat.Length <= 10))
            {
                throw new InvalidLengthException();
            }
            
            if (vat[0] == '0')
            {
                throw new InvalidFormatException();
            }

            if (vat.Length >= 2 && vat.Length <= 10 && !Checksum(vat))
            {
                throw new InvalidChecksumException();
            }

            return vat;
        }

        /// <summary>
        /// Calculates and compares checksum for vat numbers with length between 2 and 10
        /// </summary>
        private bool Checksum(string vat)
        {
            int[] weights = {7, 5, 3, 2, 1, 7, 5, 3, 2};
            int checkDigit = CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            vat = vat.Substring(0, vat.Length - 1);

            if (vat.Length < 9)
            {
                int length = 9 - vat.Length;

                for (int i = 0; i < length; i++)
                {
                    vat = "0" + vat;
                }
            }

            int sum = 0;

            for (int i = 0; i < vat.Length; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = sum * 10;

            return checkDigit == Mod(Mod(check, 11), 10);
        }
    }
}
