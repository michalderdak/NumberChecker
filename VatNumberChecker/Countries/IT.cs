using System;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class IT : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 11)
            {
                throw new InvalidLengthException();
            }

            if (!Checksum(vat) && LuhnChecksum(vat) != 0)
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
            int number = Convert.ToInt32(vat.Substring(7, 3));

            if ((number >= 1 && number <= 100) || number == 120 || number == 121 || number == 888 || number == 999)
            {
                return true;
            }

            return false;
        }
    }
}
