# VATNumberChecker
.NET Library for parsing, validation and reformatting standart numbers

Currently supports EU VAT numbers only

# Usage
```C#

  VatNumber vatNumber = Validate("vatnumber", Country.DK);
  
  vatNumber.ToString(); //Returns EU country prefix + VAT number - DK12345678
  vatNumber.Number //Returns actual VAT number without country prefix
  vatNumber.EUCountry //Returns enum EUCountry which indicates country prefix for VAT number
  
```
