using System;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class SK : CZ
    {
        public override string Validate(string vat)
        {
            if (ChecksumIndividual(vat))
            {
                return vat;
            }

            if (vat[0] == '0' && !(vat[2] == '2' || vat[2] == '3' || vat[2] == '4' || vat[2] == '7' || vat[2] == '8' |
                                   vat[2] == '9'))
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
        /// Calculates and compares checksum
        /// </summary>
        private bool Checksum(string vat)
        {
            return Mod(Convert.ToInt64(vat), 11) == 0;
        }
    }
}
