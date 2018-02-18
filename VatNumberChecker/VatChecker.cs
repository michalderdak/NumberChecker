using System;
using System.Text.RegularExpressions;
using VatNumberChecker.Countries;
using VatNumberChecker.Exceptions;
using VatNumberChecker.Models;

namespace VatNumberChecker
{
    public class VatChecker
    {
        /// <summary>
        /// Validates VAT number
        /// </summary>
        /// <returns>Corrected VAT number in VatNumber object</returns>
        public static VatNumber Validate(string vat, Country country)
        {
            string countryCode = country.ToString().ToUpper();
            vat = vat.ToUpper();

            CountryBase countryBase;

            switch (country)
            {
                case Country.AT:
                    countryBase = new AT();
                    break;
                case Country.BE:
                    countryBase = new BE();
                    break;
                case Country.BG:
                    countryBase = new BG();
                    break;
                case Country.CY:
                    countryBase = new CY();
                    break;
                case Country.CZ:
                    countryBase = new CZ();
                    break;
                case Country.DE:
                    countryBase = new DE();
                    break;
                case Country.DK:
                    countryBase = new DK();
                    break;
                case Country.EE:
                    countryBase = new EE();
                    break;
                case Country.EL:
                    countryBase = new EL();
                    break;
                case Country.ES:
                    countryBase = new ES();
                    break;
                case Country.FI:
                    countryBase = new FI();
                    break;
                case Country.FR:
                    countryBase = new FR();
                    break;
                case Country.GB:
                    countryBase = new GB();
                    break;
                case Country.HR:
                    countryBase = new HR();
                    break;
                case Country.HU:
                    countryBase = new HU();
                    break;
                case Country.IE:
                    countryBase = new IE();
                    break;
                case Country.IT:
                    countryBase = new IT();
                    break;
                case Country.LT:
                    countryBase = new LT();
                    break;
                case Country.LU:
                    countryBase = new LU();
                    break;
                case Country.LV:
                    countryBase = new LV();
                    break;
                case Country.MT:
                    countryBase = new MT();
                    break;
                case Country.NL:
                    countryBase = new NL();
                    break;
                case Country.PL:
                    countryBase = new PL();
                    break;
                case Country.PT:
                    countryBase = new PT();
                    break;
                case Country.RO:
                    countryBase = new RO();
                    break;
                case Country.SE:
                    countryBase = new SE();
                    break;
                case Country.SI:
                    countryBase = new SI();
                    break;
                case Country.SK:
                    countryBase = new SK();
                    break;
                default:
                    throw new InvalidCountryException();
            }

            if (countryBase.StripLetters)
            {
                return new VatNumber(country, countryBase.Validate(Strip(vat)));
            }

            return new VatNumber(country, countryBase.Validate(StripNoLetters(vat, countryCode)));
        }

        private static string Strip(string vat)
        {
            Regex regexBasic = new Regex(@"[A-Za-z.,/'\s-]");
            return regexBasic.Replace(vat, String.Empty);
        }

        private static string StripNoLetters(string vat, string countryCode)
        {
            Regex regexNoLetters = new Regex(@"[.,/'\s-]");

            if (vat.StartsWith(countryCode, StringComparison.CurrentCultureIgnoreCase))
            {
                vat = vat.Substring(2);
            }

            return regexNoLetters.Replace(vat, String.Empty);
        }
    }
}

