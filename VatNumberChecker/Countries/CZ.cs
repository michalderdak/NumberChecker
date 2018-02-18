using System;
using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class CZ : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 8 && vat.Length != 9 && vat.Length != 10)
            {
                throw new InvalidLengthException();
            }

            if (vat.Length == 8 && !vat.StartsWith("9") && !ChecksumLegal(vat))
            {
                throw new InvalidChecksumException();
            }

            if (vat.Length == 9 && vat.StartsWith("6") && !ChecksumSpecial(vat))
            {
                throw new InvalidChecksumException();
            }

            if ((vat.Length == 10 || (vat.Length == 9 && !vat.StartsWith("6"))) && !ChecksumIndividual(vat))
            {
                throw new InvalidChecksumException();
            }

            return vat;
        }

        /// <summary>
        /// Compares the check digit for 8 digit legal entities
        /// </summary>
        private bool ChecksumLegal(string vat)
        {
            int checkDigit = CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            vat = vat.Substring(0, vat.Length - 1);

            int sum = 0;

            for (int i = 0; i < vat.Length; i++)
            {
                sum += (8 - i) * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = Mod(11 - sum, 11);

            if (check == 0)
            {
                return Mod(1, 10) == checkDigit;
            }

            return Mod(check, 10) == checkDigit;
        }



        /// <summary>
        /// Compares the check digit for special cases
        /// </summary>
        private bool ChecksumSpecial(string vat)
        {
            int checkDigit = CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            vat = vat.Substring(1, vat.Length - 2);

            int sum = 0;

            for (int i = 0; i < vat.Length; i++)
            {
                sum += (8 - i) * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            sum = Mod(sum, 11);

            return 8 - Mod(Mod(10 - sum, 11), 10) == checkDigit;
        }

        /// <summary>
        /// Checks first 6 digits for valid date time and calculates checksum for last digit
        /// </summary>
        protected bool ChecksumIndividual(string vat)
        {
            DateTime? dateTime = GetDate(vat);

            if (!dateTime.HasValue)
            {
                return false;
            }

            if (vat.Length == 10)
            {
                int check = Mod(Convert.ToInt32(vat.Substring(0, vat.Length - 1)), 11);

                if (dateTime < new DateTime(1985, 1, 1))
                {
                    check = Mod(check, 10);
                }

                return check == CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            }

            return true;
        }

        private DateTime? GetDate(string vat)
        {
            int year = Convert.ToInt32(vat.Substring(0, 2)) + 1900;
            int month = Mod(Mod(Convert.ToInt32(vat.Substring(2, 2)), 50), 20);
            int day = Convert.ToInt32(vat.Substring(4, 2));

            if (vat.Length == 9)
            {
                if (year >= 1980)
                {
                    year -= 100;
                }

                if (year > 1953)
                {
                    return null;
                }
            }

            else if (year < 1954)
            {
                year += 100;
            }

            try
            {
                DateTime? dateTime = new DateTime(year, month, day);

                if (dateTime <= DateTime.Now)
                {
                    return dateTime;
                }

                return null;
            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}
