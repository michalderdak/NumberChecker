using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class SE : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length == 10)
            {
                vat = vat + "01";
            }

            if (vat.Length == 11)
            {
                vat = vat + "1";
            }

            if (vat.Length != 12)
            {
                throw new InvalidLengthException();
            }

            if (!vat.Substring(vat.Length - 2).Equals("01"))
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
            vat = vat.Substring(0, 10);

            return LuhnChecksum(vat) == 0;
        }
    }
}
