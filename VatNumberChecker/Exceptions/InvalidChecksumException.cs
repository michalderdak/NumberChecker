using System;

namespace VatNumberChecker.Exceptions
{
    public class InvalidChecksumException : Exception
    {
        public InvalidChecksumException(string message = "Invalid checksum") : base(message)
        {
            
        }
    }
}
