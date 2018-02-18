using System;
using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class ES : CountryBase
    {
        public override bool StripLetters => false;

        public override string Validate(string vat)
        {
            if (vat.Length != 9)
            {
                throw new InvalidLengthException();
            }

            if (Char.IsDigit(vat[0]) && !IndividualChecksum(vat) &&
                ("XYZ".IndexOf(vat[0]) != -1 && !ForeignChecksum(vat)) && !Checksum(vat))
            {
                throw new InvalidChecksumException();
            }

            return vat;
        }

        /// <summary>
        /// Calculates and compares checksum for individuals
        /// </summary>
        private bool IndividualChecksum(string vat)
        {
            char checkChar = vat[vat.Length - 1];
            vat = vat.Substring(0, vat.Length - 1);

            string alphabet = "TRWAGMYFPDXBNJZSQVHLCKE";

            int check = Mod(Convert.ToInt32(vat), 23);

            return checkChar == alphabet[check];
        }

        /// <summary>
        /// Calculates and compares checksum for foreigners
        /// </summary>
        private bool ForeignChecksum(string vat)
        {
            vat = "XYZ".IndexOf(vat[0]) + vat.Substring(1);

            return IndividualChecksum(vat);
        }

        /// <summary>
        /// Calculates and compares checksum for other
        /// </summary>
        private bool Checksum(string vat)
        {
            if (vat[0] == 'K' || vat[0] == 'L' || vat[0] == 'M')
            {
                return IndividualChecksum(vat.Substring(1));
            }

            char checkChar = vat[vat.Length - 1];
            vat = vat.Substring(0, vat.Length - 1);
            string alphabet = "0123456789";
            char check = alphabet[10 - LuhnChecksum(vat.Substring(1) + "0")];

            return (check.ToString() + "JABCDEFGHI"[CharUnicodeInfo.GetDigitValue(check)]).Contains(checkChar.ToString());
        }
    }
}
