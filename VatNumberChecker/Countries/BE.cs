using System;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class BE : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 9 && vat.Length != 10)
            {
                throw new InvalidLengthException();
            }

            if (vat.Length == 9)
            {
                vat = "0" + vat;
            }

            if (!Checksum(vat))
            {
                throw new InvalidChecksumException();
            }

            return vat;
        }

        /// <summary>
        /// Calculates the checksum and compares it with check
        /// </summary>
        private bool Checksum(string vat)
        {
            if (vat[0] != '0' && vat[0] != '1')
            {
                return false;
            }

            int a = Convert.ToInt32(vat.Substring(0, vat.Length - 2));
            int b = Convert.ToInt32(vat.Substring(vat.Length - 2));

            return Mod(a + b, 97) == 0;
        }
    }
}