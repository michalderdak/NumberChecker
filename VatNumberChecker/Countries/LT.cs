using System;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class LT : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 9 && vat.Length != 12)
            {
                throw new InvalidLengthException();
            }

            if (vat.Length == 9 && vat[7] != '1')
            {
                throw new InvalidFormatException();
            }

            if (vat.Length == 12 && vat[10] != '1')
            {
                throw new InvalidFormatException();
            }

            if (!Checksum(vat))
            {
                throw new InvalidChecksumException();
            }

            return vat;
        }

        /// <summary>
        /// Calculates and compare checksum
        /// </summary>
        private bool Checksum(string vat)
        {
            int[] Multipliers = { 3, 4, 5, 6, 7, 8, 9, 1 };

            if (vat.Length == 9)
            {
                int sum = 0;
                for (int index = 0; index < 8; index++)
                {
                    sum += CharToInt(vat[index]) * (index + 1);
                }

                int checkDigit = sum % 11;
                if (checkDigit == 10)
                {
                    checkDigit = Sum(vat, Multipliers);
                }

                if (checkDigit == 10)
                {
                    checkDigit = 0;
                }
                
                bool isValid = checkDigit % 11 == CharToInt(vat[8]);

                return isValid;
            }

            return TemporarilyRegisteredTaxPayers(vat);
        }

        private bool TemporarilyRegisteredTaxPayers(string vat)
        {
            int[] multipliersTemporarily = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2 };
            int[] multipliersDoubleCheck = { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4 };

            int total = Sum(vat, multipliersTemporarily);

            if (total % 11 == 10)
            {
                total = Sum(vat, multipliersDoubleCheck);
            }

            total %= 11;
            if (total == 10)
            {
                total = 0;
            }

            bool isValid = total == CharToInt(vat[11]);
            return isValid;
        }

        private int CharToInt(char c)
        {
            return Convert.ToInt32(c) - Convert.ToInt32('0');
        }

        private int Sum(string input, int[] multipliers, int start = 0)
        {
            int num = 0;
            for (int i = start; i < multipliers.Length; i++)
            {
                int num2 = multipliers[i];
                num += CharToInt(input[i]) * num2;
            }
            return num;
        }
    }
}