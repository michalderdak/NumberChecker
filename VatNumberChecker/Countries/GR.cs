using System;
using System.Text.RegularExpressions;
using VatNumberChecker.Exceptions;
using VatNumberChecker.Models;

namespace VatNumberChecker.Countries
{
    public class GR : CountryBase
    {
        public override bool StripLetters => false;
        public override string Validate(string vat)
        {
            vat = vat.ToUpper().Replace("EL", string.Empty).Replace("GR", string.Empty);

            if (vat.Length == 8)
            {
                vat = "0" + vat;
            }

            if (!Regex.IsMatch(vat, @"^\d{9}$"))
            {
                throw new InvalidFormatException();
            }

            int[] multipliers = { 256, 128, 64, 32, 16, 8, 4, 2 };

            int sum = Sum(vat, multipliers);
            int checkDigit = sum % 11;

            if (checkDigit > 9)
                checkDigit = 0;

            bool isValid = checkDigit == ToInt(vat[8]);
            if (!isValid)
                throw new InvalidChecksumException();

            return vat;
        }

        private static int Sum(string input, int[] multipliers, int start = 0)
        {
            int sum = 0;

            for (var index = start; index < multipliers.Length; index++)
            {
                var digit = multipliers[index];
                sum += ToInt(input[index]) * digit;
            }

            return sum;
        }

        private static int ToInt(char c)
        {
            return Convert.ToInt32(c) - Convert.ToInt32('0');
        }
    }

    public class VatNumberGR : VatNumber
    {
        public VatNumberGR(EUCountry euCountry, string number) : base (euCountry, number)
        {
        }

        public override string ToString()
        {
            return "EL" + Number;
        }
    }
}
