using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class HR : CountryBase
    {
        public override string Validate(string vat)
        {
            if (vat.Length != 11)
            {
                throw new InvalidLengthException();
            }

            if (Mod1110(vat) != 1)
            {
                throw new InvalidChecksumException();
            }

            return vat;
        }
    }
}