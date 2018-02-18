using System;

namespace VatNumberChecker.Exceptions
{
    public class InvalidCountryException : Exception
    {
        public InvalidCountryException(string message = "Country VAT code has wrong format") : base(message)
        {
        }
    }
}
