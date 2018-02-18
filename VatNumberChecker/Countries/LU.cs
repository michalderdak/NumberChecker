using System;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class LU : CountryBase
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
        /// Calculates and compares checksum
        /// </summary>
        private bool Checksum(string vat)
        {
            string checkDigits = vat.Substring(vat.Length - 2, 2);
            vat = vat.Substring(0, 6);

            string check = Mod(Convert.ToInt32(vat), 89).ToString("D2");

            return checkDigits == check;
        }
    }
}
