using System;

namespace VatNumberChecker.Exceptions
{
    public class InvalidLengthException : Exception
    {
        public InvalidLengthException(string message = "Invalid length of VAT number") : base(message)
        {
        }
    }
}
