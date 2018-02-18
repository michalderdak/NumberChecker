using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using VatNumberChecker;
using VatNumberChecker.Models;

namespace NumberCheckerTest
{
    [TestFixture]
    public class VatNumberCheckerTest
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        //Austria
        [TestCase(Country.AT, "ATU15416707", "ATU15416707")]
        [TestCase(Country.AT, "AT 15416707", "ATU15416707")]
        [TestCase(Country.AT, "AT-9999999", null)]

        //Belgium
        [TestCase(Country.BE, "BE0427155930", "BE0427155930")]
        [TestCase(Country.BE, "0427.155.930", "BE0427155930")]
        [TestCase(Country.BE, "BE427155930", "BE0427155930")]
        [TestCase(Country.BE, "BE1999999", null)]

        //Bulgaria
        //Legal entities
        [TestCase(Country.BG, "BG175074752", "BG175074752")]
        [TestCase(Country.BG, "130460283", "BG130460283")]
        [TestCase(Country.BG, "BG127015636", "BG127015636")]
        //Individuals
        [TestCase(Country.BG, "7111 042 925", "BG7111042925")]
        [TestCase(Country.BG, "BG7111042922", null)]
        [TestCase(Country.BG, "752316 926 3", "BG7523169263")]
        [TestCase(Country.BG, "8032056031", "BG8032056031")]
        [TestCase(Country.BG, "8019010008", null)]

        //Croatia
        [TestCase(Country.HR, "HR24640993045", "HR24640993045")]
        [TestCase(Country.HR, "HR 24640993045", "HR24640993045")]
        [TestCase(Country.HR, "HR24640993044", null)]

        //Cyprus
        [TestCase(Country.CY, "CY90000005D", "CY90000005D")]
        [TestCase(Country.CY, "CY-10259033P", "CY10259033P")]
        [TestCase(Country.CY, "90000005D", "CY90000005D")]
        [TestCase(Country.CY, "CY90000006D", null)]
        [TestCase(Country.CY, "CY90000005", null)]
        [TestCase(Country.CY, "CY900000058", null)]

        //Czech
        //Legal entities
        [TestCase(Country.CZ, "CZ00177041", "CZ00177041")]
        [TestCase(Country.CZ, "CZ 45274649", "CZ45274649")]
        [TestCase(Country.CZ, "26185610", "CZ26185610")]
        [TestCase(Country.CZ, "26185611", null)]
        //Special cases
        [TestCase(Country.CZ, "CZ640903926", "CZ640903926")]
        //Individuals
        [TestCase(Country.CZ, "CZ710319/2745", "CZ7103192745")]
        [TestCase(Country.CZ, "951215/9624", "CZ9512159624")]
        [TestCase(Country.CZ, "7103192746", null)]
        [TestCase(Country.CZ, "590312/123", null)]
        [TestCase(Country.CZ, "530312/123", "CZ530312123")]

        //Denmark
        [TestCase(Country.DK, "DK 13585628", "DK13585628")]
        [TestCase(Country.DK, "DK 13585627", null)]
        [TestCase(Country.DK, "DK 29 40 34 73", "DK29403473")]
        [TestCase(Country.DK, "13590400", "DK13590400")]

        //Estonia
        [TestCase(Country.EE, "EE 100 366 327", "EE100366327")]
        [TestCase(Country.EE, "100594102", "EE100594102")]
        [TestCase(Country.EE, "EE100594103", null)]
        [TestCase(Country.EE, "EE 100 931 55", null)]

        //Finland
        [TestCase(Country.FI, "FI20774740", "FI20774740")]
        [TestCase(Country.FI, "FI 20774741", null)]

        //France
        [TestCase(Country.FR, "23334175221", "FR23334175221")]
        [TestCase(Country.FR, "84 323 140 391", null)]
        [TestCase(Country.FR, "FRK7399859412", "FRK7399859412")]
        [TestCase(Country.FR, "4Z123456782", "FR4Z123456782")]
        [TestCase(Country.FR, "IO334175221", null)]

        //Germany
        [TestCase(Country.DE, "DE 136,695 976", "DE136695976")]
        [TestCase(Country.DE, "DE136695976", "DE136695976")]
        [TestCase(Country.DE, "136695978", null)]

        //Greece
        [TestCase(Country.EL, "EL094468339", "EL094468339")]
        [TestCase(Country.EL, "EL 094259216 ", "EL094259216")]
        [TestCase(Country.EL, "EL 123456781", null)]

        //Hungry
        [TestCase(Country.HU, "HU-12892312", "HU12892312")]
        [TestCase(Country.HU, "HU-12892313", null)]

        //Ireland
        [TestCase(Country.IE, "IE 6433435F", "IE6433435F")]
        [TestCase(Country.IE, "IE 6433435OA", "IE6433435OA")]
        [TestCase(Country.IE, "6433435E", null)]
        [TestCase(Country.IE, "8D79739I", "IE8D79739I")]
        [TestCase(Country.IE, "8 ?79739J", null)]

        //Italy
        [TestCase(Country.IT, "IT 00743110157", "IT00743110157")]
        [TestCase(Country.IT, "00743110158", null)]

        //Latvia
        [TestCase(Country.LV, "LV 4000 3521 600", "LV40003521600")]
        [TestCase(Country.LV, "40003521601", null)]
        [TestCase(Country.LV, "161175-19997", "LV16117519997")]
        [TestCase(Country.LV, "161375-19997", null)]

        //Lithuania
        [TestCase(Country.LT, "119511515", "LT119511515")]
        [TestCase(Country.LT, "LT 100001919017", "LT100001919017")]
        [TestCase(Country.LT, "100001919018", null)]
        [TestCase(Country.LT, "100004801610", "LT100004801610")]

        //Luxembourg
        [TestCase(Country.LU, "LU 150 274 42", "LU15027442")]
        [TestCase(Country.LU, "150 274 43", null)]

        //Malta
        [TestCase(Country.MT, "MT 1167-9112", "MT11679112")]
        [TestCase(Country.MT, "1167-9113", null)]

        //Netherlands
        [TestCase(Country.NL, "004495445B01", "NL004495445B01")]
        [TestCase(Country.NL, "NL4495445B01", "NL004495445B01")]
        [TestCase(Country.NL, "123456789B90", null)]

        //Poland
        [TestCase(Country.PL, "PL 8567346215", "PL8567346215")]
        [TestCase(Country.PL, "PL 8567346216", null)]

        //Portuguese
        [TestCase(Country.PT, "PT 501 964 843", "PT501964843")]
        [TestCase(Country.PT, "PT 501 964 842", null)]

        //Romania
        [TestCase(Country.RO, "RO 185 472 90", "RO18547290")]
        [TestCase(Country.RO, "185 472 91", null)]
        [TestCase(Country.RO, "1630615123457", "RO1630615123457")]

        //Slovakia
        //Legal entities
        [TestCase(Country.SK, "SK 202 274 96 19", "SK2022749619")]
        [TestCase(Country.SK, "SK 202 274 96 18", null)]
        //Individuals
        [TestCase(Country.SK, "710319/2745", "SK7103192745")]
        [TestCase(Country.SK, "SK 991231123", "SK991231123")]
        [TestCase(Country.SK, "7103192746", null)]
        [TestCase(Country.SK, "1103492745", null)]
        [TestCase(Country.SK, "590312/123", null)]
        [TestCase(Country.SK, "9512159624", "SK9512159624")]

        //Slovenia
        [TestCase(Country.SI, "SI 5022 3054", "SI50223054")]
        [TestCase(Country.SI, "SI 50223055", null)]

        //Spain
        [TestCase(Country.ES, "ES B-58378431", "ESB58378431")]
        [TestCase(Country.ES, "B64717838", "ESB64717838")]
        [TestCase(Country.ES, "B64717839", null)]
        [TestCase(Country.ES, "54362315K", "ES54362315K")]
        [TestCase(Country.ES, "X-5253868-R", "ESX5253868R")]
        [TestCase(Country.ES, "J99216582", "ESJ99216582")]
        [TestCase(Country.ES, "J99216583", null)]
        [TestCase(Country.ES, "J992165831", null)]
        [TestCase(Country.ES, "M-1234567-L", "ESM1234567L")]
        [TestCase(Country.ES, "O-1234567-L", null)]
        [TestCase(Country.ES, "J99216582", "ESJ99216582")]
        [TestCase(Country.ES, "54362315-K", "ES54362315K")]
        [TestCase(Country.ES, "54362315Z", null)]
        [TestCase(Country.ES, "54362315", null)]
        [TestCase(Country.ES, "x-2482300w", "ESX2482300W")]
        [TestCase(Country.ES, "x-2482300a", null)]
        [TestCase(Country.ES, "X2482300", null)]

        //Sweden
        [TestCase(Country.SE, "SE556042722001", "SE556042722001")]
        [TestCase(Country.SE, "123456789101", null)]
        [TestCase(Country.SE, "1234567897", "SE123456789701")]
        [TestCase(Country.SE, "1234567891", null)]

        //United Kingdom
        [TestCase(Country.GB, "GB 980 7806 84", "GB980780684")]
        [TestCase(Country.GB, "802311781", null)]
        [TestCase(Country.GB, "GBGD345", "GBGD345")]
        [TestCase(Country.GB, "GBGD555", null)]
        [TestCase(Country.GB, "GBHA555", "GBHA555")]
        [TestCase(Country.GB, "GBHA444", null)]
        [TestCase(Country.GB, "GBGD888819501", "GBGD888819501")]
        [TestCase(Country.GB, "GBGD888855501", null)]
        [TestCase(Country.GB, "GBHA888858301", "GBHA888858301")]
        [TestCase(Country.GB, "GBHA888844401", null)]
        public void Validation(Country country, string vat, string expectedResult)
        {
            try
            {
                Assert.IsTrue(expectedResult == VatChecker.Validate(vat, country).ToString());
            }
            catch (Exception e)
            {
                Assert.IsNull(expectedResult);
            }
        }
    }
}
