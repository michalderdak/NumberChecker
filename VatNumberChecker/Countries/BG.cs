using System;
using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class BG : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 9 && vat.Length != 10)
            {
                throw new InvalidLengthException();
            }

            if (vat.Length == 9 && !ChecksumLegal(vat))
            {
                throw new InvalidChecksumException();
            }

            if (vat.Length == 10 && !ValidDate(vat))
            {
                throw new InvalidFormatException();
            }

            if (vat.Length == 10 && !(ChecksumOther(vat) || Egn(vat) || Pnf(vat)))
            {
                throw new InvalidChecksumException();
            }  

            return vat;
        }

        /// <summary>
        /// Checks the checksum for legal entities, last digit is the check digit.
        /// </summary>
        private bool ChecksumLegal(string vat)
        {
            int checkDigit = CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            vat = vat.Substring(0, vat.Length - 1);
            int sum = 0;

            for (int i = 0; i < vat.Length; i++)
            {
                sum += (i + 1) * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = Mod(sum, 11);

            if (check == 10)
            {
                sum = 0;

                for (int i = 0; i < vat.Length; i++)
                {
                    sum += (i + 3) * CharUnicodeInfo.GetDigitValue(vat[i]);
                }

                check = Mod(sum, 11);
            }

            return Mod(check, 10) == checkDigit;
        }

        /// <summary>
        /// Validates the check digit for others - individuals, foreigners, ...
        /// </summary>
        private bool ChecksumOther(string vat)
        {
            int checkDigit = CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            vat = vat.Substring(0, vat.Length - 1);
            int[] weights = { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            int sum = 0;

            for (int i = 0; i < vat.Length; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = Mod(11 - sum, 11);

            return check == checkDigit;
        }
        
        /// <summary>
        /// Validates the check digit for foreigner personal number
        /// </summary>
        private bool Pnf(string vat)
        {
            int checkDigit = CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            vat = vat.Substring(0, vat.Length - 1);
            int[] weights = { 21, 19, 17, 13, 11, 9, 7, 3, 1 };
            int sum = 0;

            for (int i = 0; i < vat.Length; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = Mod(sum, 10);

            return check == checkDigit;
        }

        /// <summary>
        /// Validates the check digit for personal number
        /// </summary>
        private bool Egn(string vat)
        {
            int checkDigit = CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            vat = vat.Substring(0, vat.Length - 1);
            int[] weights = {2, 4, 8, 5, 10, 9, 7, 3, 6};
            int sum = 0;

            for (int i = 0; i < vat.Length; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = Mod(Mod(sum, 11), 10);

            return check == checkDigit;
        }

        /// <summary>
        /// Validates birth date in personal number
        /// </summary>
        private bool ValidDate(string vat)
        {
            int year = Convert.ToInt32(vat.Substring(0, 2)) + 1900;
            int month = Convert.ToInt32(vat.Substring(2, 2));
            int day = Convert.ToInt32(vat.Substring(4, 2));

            if (month > 40)
            {
                year += 100;
                month -= 40;
            }
            else if (month > 20)
            {
                year -= 100;
                month -= 20;
            }

            try
            {
                DateTime dateTime = new DateTime(year, month, day);
                return dateTime <= DateTime.Now;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}