using System;

namespace VatNumberChecker.Models
{
    public class VatNumber
    {
        private EuropeanCountry _europeanCountry;
        private string _number;

        /// <summary>
        /// EU europeanCountry prefix of VAT number
        /// </summary>
        public EuropeanCountry EuropeanCountry
        {
            get { return _europeanCountry; }
            set { _europeanCountry = value; }
        }

        /// <summary>
        /// Actual VAT number without europeanCountry prefix
        /// </summary>
        public String Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public VatNumber(EuropeanCountry europeanCountry, string number)
        {
            _europeanCountry = europeanCountry;
            _number = number;
        }

        public override string ToString()
        {
            return EuropeanCountry.ToString().ToUpper() + Number;
        }
    }

    /// <summary>
    /// EU state members
    /// </summary>
    public enum EuropeanCountry
    {
        BE = 0,
        BG = 1,
        CZ = 2,
        DK = 3,
        DE = 4,
        EE = 5,
        IE = 6,
        EL = 7,
        ES = 8,
        FR = 9,
        HR = 10,
        IT = 11,
        CY = 12,
        LV = 13,
        LT = 14,
        LU = 15,
        HU = 16,
        MT = 17,
        NL = 18,
        AT = 19,
        PL = 20,
        PT = 21,
        RO = 22,
        SI = 23,
        SK = 24,
        FI = 25,
        SE = 26,
        GB = 27,
    }
}
