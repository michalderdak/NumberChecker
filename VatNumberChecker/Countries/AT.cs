using System;
using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class AT : CountryBase
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

            return String.Format("U{0}", vat);
        }

        /// <summary>
        /// Calculates the checksum and compares it with check
        /// </summary>
        private bool Checksum(string vat)
        {
            int checkDigit = CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            vat = vat.Substring(0, vat.Length - 1);

            int result = 6 - Mod(LuhnChecksum(vat), 10);

            if (result < 0)
            {
                result += 10;
            }

            return result == checkDigit;
        }
    }
}