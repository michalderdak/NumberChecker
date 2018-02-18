using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class DE : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 9)
            {
                throw new InvalidLengthException();
            }

            if (vat[0] == '0')
            {
                throw new InvalidFormatException();
            }

            if (Mod1110(vat) != 1)
            {
                throw new InvalidChecksumException();
            }

            return vat;
        }
    }
}
