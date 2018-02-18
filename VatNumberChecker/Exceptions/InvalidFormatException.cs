using System;

namespace VatNumberChecker.Exceptions
{
    public class InvalidFormatException : Exception
    {
        public InvalidFormatException(string message = "Invalid format of VAT number") : base(message)
        {
            
        }
    }
}
