using System.Globalization;

namespace VatNumberChecker.Countries
{
    public abstract class CountryBase
    {
        public virtual bool StripLetters => true;
        
        /// <summary>
        /// Validates VAT number according to specific euCountry
        /// </summary>
        public abstract string Validate(string vat);
        
        /// <summary>
        /// Function used for modulus in x by m. Reason to use this function is that it never
        /// returns negative number
        /// </summary>
        protected int Mod(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }

        /// <summary>
        /// Function used for modulus in x by m. Reason to use this function is that it never
        /// returns negative number
        /// </summary>
        protected long Mod(long x, int m)
        {
            long r = x % m;
            return r < 0 ? r + m : r;
        }

        protected int LuhnChecksum(string number)
        {
            int[] deltas = { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };
            int checksum = 0;
            char[] chars = number.ToCharArray();

            for (int i = chars.Length - 1; i > -1; i--)
            {
                int j = chars[i] - 48;
                checksum += j;
                if (Mod(i - chars.Length, 2) == 0)
                {
                    checksum += deltas[j];
                }
            }

            return Mod(checksum, 10);
        }

        protected int Mod1110(string number)
        {
            int check = 5;

            foreach (char n in number)
            {
                if (check == 0)
                {
                    check = 10;
                }

                check = (Mod(check * 2, 11) + CharUnicodeInfo.GetDigitValue(n)) % 10;
            }

            return check;
        }
    }
}