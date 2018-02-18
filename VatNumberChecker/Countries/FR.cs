using System;
using VatNumberChecker.Exceptions;

namespace VatNumberChecker.Countries
{
    public class FR : CountryBase
    {
        public override bool StripLetters => false;

        public override string Validate(string vat)
        {
            if (vat.Length != 11)
            {
                throw new InvalidLengthException();
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
        public bool Checksum(string vat)
        {
            if (vat.Substring(2, 3) != "000" && LuhnChecksum(vat.Substring(2)) != 0)
            {
                return false;
            }
            
            if (Int64.TryParse(vat, out _) && Convert.ToInt32(vat.Substring(0, 2)) == Mod(Convert.ToInt64(vat.Substring(2) + "12"), 97))
            {
                return true;
            }

            int check = 0;
            string alphabet = "0123456789ABCDEFGHJKLMNPQRSTUVWXYZ";

            if (Char.IsNumber(vat[0]))
            {
                check = alphabet.IndexOf(vat[0]) * 24 + alphabet.IndexOf(vat[1]) - 10;
            }
            else
            {
                check = alphabet.IndexOf(vat[0]) * 34 + alphabet.IndexOf(vat[1]) - 100;
            }

            return Mod(Convert.ToInt32(vat.Substring(2)) + 1 + check / 11, 11) == Mod(check, 11);
        }
    }
}
