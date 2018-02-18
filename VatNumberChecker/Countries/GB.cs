using System;
using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class GB : CountryBase
    {
        public override bool StripLetters => false;

        public override string Validate(string vat)
        {
            if (vat.Length != 5 && vat.Length != 9 && vat.Length != 11 && vat.Length != 12)
            {
                throw new InvalidLengthException();
            }

            if (vat.Length == 5)
            {
                if (((vat.StartsWith("GD") && Convert.ToInt32(vat.Substring(2)) < 500) ||
                     (vat.StartsWith("HA") && Convert.ToInt32(vat.Substring(2)) >= 500)))
                {
                    return vat;
                }

                throw new InvalidFormatException();
            }

            if (vat.Length == 11)
            {
                if ((vat.Substring(0, 6).Equals("GD8888") || vat.Substring(0, 6).Equals("HA8888")))
                {
                    if ((vat.StartsWith("GD") && Convert.ToInt32(vat.Substring(6, 3)) < 500) ||
                        (vat.StartsWith("HA") && Convert.ToInt32(vat.Substring(6, 3)) >= 500))
                    {
                        if (!GovernmentChecksum(vat))
                        {
                            throw new InvalidChecksumException();
                        }

                        return vat;
                    }

                    throw new InvalidFormatException();
                }

                throw new InvalidFormatException();
            }

            if ((vat.Length == 9 || vat.Length == 12) && !Checksum(vat))
            {
                throw new InvalidChecksumException();
            }

            return vat;
        }

        /// <summary>
        /// Calculates and compares checksum with check for others
        /// </summary>
        private bool Checksum(string vat)
        {
            vat = vat.Substring(0, 9);
            int[] weights = {8, 7, 6, 5, 4, 3, 2, 10, 1};
            int sum = 0;

            for (int i = 0; i < vat.Length; i++)
            {
                sum += weights[i] * CharUnicodeInfo.GetDigitValue(vat[i]);
            }

            int check = Mod(sum, 97);

            return check == 0 || check == 42 || check == 55;
        }

        /// <summary>
        /// Calculates and compares checksum for government numbers
        /// </summary>
        private bool GovernmentChecksum(string vat)
        {
            int checkDigits = Convert.ToInt32(vat.Substring(9, 2));
            int checksum = Mod(Convert.ToInt32(vat.Substring(6, 3)), 97);
            return checkDigits == checksum;
        }
    }
}
