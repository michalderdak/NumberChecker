using System.Globalization;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class EL : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 8 && vat.Length != 9)
            {
                throw new InvalidLengthException();
            }

            if (vat.Length == 8)
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
        /// Calculates and compare checksum with check
        /// </summary>
        private bool Checksum(string vat)
        {
            int checkDigit = CharUnicodeInfo.GetDigitValue(vat[vat.Length - 1]);
            vat = vat.Substring(0, vat.Length - 1);
            int check = 0;

            foreach (char c in vat)
            {
                check = check * 2 + CharUnicodeInfo.GetDigitValue(c);
            }

            return checkDigit == Mod(Mod(check * 2, 11), 10);
        }
    }
}
