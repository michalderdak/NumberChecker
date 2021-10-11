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
        public static VatNumber Validate(string vat, EUCountry euCountry)
        {
            string countryCode = euCountry.ToString().ToUpper();
            vat = vat.ToUpper();

            CountryBase countryBase;

            switch (euCountry)
            {
                case EUCountry.AT:
                    countryBase = new AT();
                    break;
                case EUCountry.BE:
                    countryBase = new BE();
                    break;
                case EUCountry.BG:
                    countryBase = new BG();
                    break;
                case EUCountry.CY:
                    countryBase = new CY();
                    break;
                case EUCountry.CZ:
                    countryBase = new CZ();
                    break;
                case EUCountry.DE:
                    countryBase = new DE();
                    break;
                case EUCountry.DK:
                    countryBase = new DK();
                    break;
                case EUCountry.EE:
                    countryBase = new EE();
                    break;
                case EUCountry.EL:
                    countryBase = new EL();
                    break;
                case EUCountry.ES:
                    countryBase = new ES();
                    break;
                case EUCountry.FI:
                    countryBase = new FI();
                    break;
                case EUCountry.FR:
                    countryBase = new FR();
                    break;
                case EUCountry.GB:
                    countryBase = new GB();
                    break;
                case EUCountry.HR:
                    countryBase = new HR();
                    break;
                case EUCountry.HU:
                    countryBase = new HU();
                    break;
                case EUCountry.IE:
                    countryBase = new IE();
                    break;
                case EUCountry.IT:
                    countryBase = new IT();
                    break;
                case EUCountry.LT:
                    countryBase = new LT();
                    break;
                case EUCountry.LU:
                    countryBase = new LU();
                    break;
                case EUCountry.LV:
                    countryBase = new LV();
                    break;
                case EUCountry.MT:
                    countryBase = new MT();
                    break;
                case EUCountry.NL:
                    countryBase = new NL();
                    break;
                case EUCountry.PL:
                    countryBase = new PL();
                    break;
                case EUCountry.PT:
                    countryBase = new PT();
                    break;
                case EUCountry.RO:
                    countryBase = new RO();
                    break;
                case EUCountry.SE:
                    countryBase = new SE();
                    break;
                case EUCountry.SI:
                    countryBase = new SI();
                    break;
                case EUCountry.SK:
                    countryBase = new SK();
                    break;
                case EUCountry.GR:
                    countryBase = new GR();
                    return new VatNumberGR(euCountry, countryBase.Validate(StripNoLetters(vat, countryCode)));
                default:
                    throw new InvalidCountryException();
            }

            if (countryBase.StripLetters)
            {
                return new VatNumber(euCountry, countryBase.Validate(Strip(vat)));
            }

            return new VatNumber(euCountry, countryBase.Validate(StripNoLetters(vat, countryCode)));
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

