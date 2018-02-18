using System;
using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class LV : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 11)
            {
                throw new InvalidLengthException();
            }

            if (CharUnicodeInfo.GetDigitValue(vat[0]) > 3 && !LegalChecksum(vat) && !ValidateDate(vat) && !IndividualChecksum(vat))
            {
                throw new InvalidChecksumException();
            }

            return vat;
        }

        /// <summary>
        /// Calculates and compares checksum for legal entities
        /// </summary>
        private bool LegalChecksum(string vat)
        {
            int[] weights = {9, 1, 4, 8, 3, 10, 2, 5, 7, 6, 1};
            int sum = 0;

            for (int i = 0; i < weights.Length; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            return Mod(sum, 11) == 3;
        }

        /// <summary>
        /// Calculates and compares checksum for individuals
        /// </summary>
        private bool IndividualChecksum(string vat)
        {
            int[] weights = {10, 5, 8, 4, 2, 1, 6, 3, 7, 9};
            int checkDigit = CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            vat = vat.Substring(0, vat.Length - 1);
            int sum = 0;

            for (int i = 0; i < weights.Length; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = 1 + sum;

            return Mod(Mod(check, 11), 10) == checkDigit;
        }

        private bool ValidateDate(string vat)
        {
            int day = Convert.ToInt32(vat.Substring(0, 2));
            int month = Convert.ToInt32(vat.Substring(2, 2));
            int year = Convert.ToInt32(vat.Substring(4, 2));
            year += 1800 + CharUnicodeInfo.GetDigitValue(vat[6]) * 100;

            try
            {
                DateTime dateTime = new DateTime(year, month, day);
                return dateTime <= DateTime.Now;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
