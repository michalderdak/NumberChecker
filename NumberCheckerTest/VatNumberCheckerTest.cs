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
        [TestCase(EUCountry.AT, "ATU15416707", "ATU15416707")]
        [TestCase(EUCountry.AT, "AT 15416707", "ATU15416707")]
        [TestCase(EUCountry.AT, "AT-9999999", null)]

        //Belgium
        [TestCase(EUCountry.BE, "BE0427155930", "BE0427155930")]
        [TestCase(EUCountry.BE, "0427.155.930", "BE0427155930")]
        [TestCase(EUCountry.BE, "BE427155930", "BE0427155930")]
        [TestCase(EUCountry.BE, "BE1999999", null)]

        //Bulgaria
        //Legal entities
        [TestCase(EUCountry.BG, "BG175074752", "BG175074752")]
        [TestCase(EUCountry.BG, "130460283", "BG130460283")]
        [TestCase(EUCountry.BG, "BG127015636", "BG127015636")]
        //Individuals
        [TestCase(EUCountry.BG, "7111 042 925", "BG7111042925")]
        [TestCase(EUCountry.BG, "BG7111042922", null)]
        [TestCase(EUCountry.BG, "752316 926 3", "BG7523169263")]
        [TestCase(EUCountry.BG, "8032056031", "BG8032056031")]
        [TestCase(EUCountry.BG, "8019010008", null)]

        //Croatia
        [TestCase(EUCountry.HR, "HR24640993045", "HR24640993045")]
        [TestCase(EUCountry.HR, "HR 24640993045", "HR24640993045")]
        [TestCase(EUCountry.HR, "HR24640993044", null)]

        //Cyprus
        [TestCase(EUCountry.CY, "CY90000005D", "CY90000005D")]
        [TestCase(EUCountry.CY, "CY-10259033P", "CY10259033P")]
        [TestCase(EUCountry.CY, "90000005D", "CY90000005D")]
        [TestCase(EUCountry.CY, "CY90000006D", null)]
        [TestCase(EUCountry.CY, "CY90000005", null)]
        [TestCase(EUCountry.CY, "CY900000058", null)]

        //Czech
        //Legal entities
        [TestCase(EUCountry.CZ, "CZ00177041", "CZ00177041")]
        [TestCase(EUCountry.CZ, "CZ 45274649", "CZ45274649")]
        [TestCase(EUCountry.CZ, "26185610", "CZ26185610")]
        [TestCase(EUCountry.CZ, "26185611", null)]
        //Special cases
        [TestCase(EUCountry.CZ, "CZ640903926", "CZ640903926")]
        //Individuals
        [TestCase(EUCountry.CZ, "CZ710319/2745", "CZ7103192745")]
        [TestCase(EUCountry.CZ, "951215/9624", "CZ9512159624")]
        [TestCase(EUCountry.CZ, "7103192746", null)]
        [TestCase(EUCountry.CZ, "590312/123", null)]
        [TestCase(EUCountry.CZ, "530312/123", "CZ530312123")]

        //Denmark
        [TestCase(EUCountry.DK, "DK 13585628", "DK13585628")]
        [TestCase(EUCountry.DK, "DK 13585627", null)]
        [TestCase(EUCountry.DK, "DK 29 40 34 73", "DK29403473")]
        [TestCase(EUCountry.DK, "13590400", "DK13590400")]

        //Estonia
        [TestCase(EUCountry.EE, "EE 100 366 327", "EE100366327")]
        [TestCase(EUCountry.EE, "100594102", "EE100594102")]
        [TestCase(EUCountry.EE, "EE100594103", null)]
        [TestCase(EUCountry.EE, "EE 100 931 55", null)]

        //Finland
        [TestCase(EUCountry.FI, "FI20774740", "FI20774740")]
        [TestCase(EUCountry.FI, "FI 20774741", null)]

        //France
        [TestCase(EUCountry.FR, "23334175221", "FR23334175221")]
        [TestCase(EUCountry.FR, "84 323 140 391", null)]
        [TestCase(EUCountry.FR, "FRK7399859412", "FRK7399859412")]
        [TestCase(EUCountry.FR, "4Z123456782", "FR4Z123456782")]
        [TestCase(EUCountry.FR, "IO334175221", null)]

        //Germany
        [TestCase(EUCountry.DE, "DE 136,695 976", "DE136695976")]
        [TestCase(EUCountry.DE, "DE136695976", "DE136695976")]
        [TestCase(EUCountry.DE, "136695978", null)]

        //Greece
        [TestCase(EUCountry.EL, "EL094468339", "EL094468339")]
        [TestCase(EUCountry.EL, "EL 094259216 ", "EL094259216")]
        [TestCase(EUCountry.EL, "EL 123456781", null)]

        //Hungry
        [TestCase(EUCountry.HU, "HU-12892312", "HU12892312")]
        [TestCase(EUCountry.HU, "HU-12892313", null)]

        //Ireland
        [TestCase(EUCountry.IE, "IE 6433435F", "IE6433435F")]
        [TestCase(EUCountry.IE, "IE 6433435OA", "IE6433435OA")]
        [TestCase(EUCountry.IE, "6433435E", null)]
        [TestCase(EUCountry.IE, "8D79739I", "IE8D79739I")]
        [TestCase(EUCountry.IE, "8 ?79739J", null)]

        //Italy
        [TestCase(EUCountry.IT, "IT 00743110157", "IT00743110157")]
        [TestCase(EUCountry.IT, "00743110158", null)]

        //Latvia
        [TestCase(EUCountry.LV, "LV 4000 3521 600", "LV40003521600")]
        [TestCase(EUCountry.LV, "40003521601", null)]
        [TestCase(EUCountry.LV, "161175-19997", "LV16117519997")]
        [TestCase(EUCountry.LV, "161375-19997", null)]

        //Lithuania
        [TestCase(EUCountry.LT, "119511515", "LT119511515")]
        [TestCase(EUCountry.LT, "LT 100001919017", "LT100001919017")]
        [TestCase(EUCountry.LT, "100001919018", null)]
        [TestCase(EUCountry.LT, "100004801610", "LT100004801610")]
        [TestCase(EUCountry.LT, "100006425312", "LT100006425312")]
        [TestCase(EUCountry.LT, "116818416", "LT116818416")]
        [TestCase(EUCountry.LT, "633557219", "LT633557219")]
        [TestCase(EUCountry.LT, "114294716", "LT114294716")]
        [TestCase(EUCountry.LT, "799079219", "LT799079219")]
        [TestCase(EUCountry.LT, "100009953010", "LT100009953010")]
        [TestCase(EUCountry.LT, "100009500418", "LT100009500418")]
        [TestCase(EUCountry.LT, "100009232328", null)]

        //Luxembourg
        [TestCase(EUCountry.LU, "LU 150 274 42", "LU15027442")]
        [TestCase(EUCountry.LU, "150 274 43", null)]

        //Malta
        [TestCase(EUCountry.MT, "MT 1167-9112", "MT11679112")]
        [TestCase(EUCountry.MT, "1167-9113", null)]

        //Netherlands
        [TestCase(EUCountry.NL, "004495445B01", "NL004495445B01")]
        [TestCase(EUCountry.NL, "NL4495445B01", "NL004495445B01")]
        [TestCase(EUCountry.NL, "123456789B90", null)]

        //Poland
        [TestCase(EUCountry.PL, "PL 8567346215", "PL8567346215")]
        [TestCase(EUCountry.PL, "PL 8567346216", null)]

        //Portuguese
        [TestCase(EUCountry.PT, "PT 501 964 843", "PT501964843")]
        [TestCase(EUCountry.PT, "PT 501 964 842", null)]

        //Romania
        [TestCase(EUCountry.RO, "RO 185 472 90", "RO18547290")]
        [TestCase(EUCountry.RO, "185 472 91", null)]
        [TestCase(EUCountry.RO, "1630615123457", "RO1630615123457")]

        //Slovakia
        //Legal entities
        [TestCase(EUCountry.SK, "SK 202 274 96 19", "SK2022749619")]
        [TestCase(EUCountry.SK, "SK 202 274 96 18", null)]
        //Individuals
        [TestCase(EUCountry.SK, "710319/2745", "SK7103192745")]
        [TestCase(EUCountry.SK, "SK 991231123", "SK991231123")]
        [TestCase(EUCountry.SK, "7103192746", null)]
        [TestCase(EUCountry.SK, "1103492745", null)]
        [TestCase(EUCountry.SK, "590312/123", null)]
        [TestCase(EUCountry.SK, "9512159624", "SK9512159624")]

        //Slovenia
        [TestCase(EUCountry.SI, "SI 5022 3054", "SI50223054")]
        [TestCase(EUCountry.SI, "SI 50223055", null)]

        //Spain
        [TestCase(EUCountry.ES, "ES B-58378431", "ESB58378431")]
        [TestCase(EUCountry.ES, "B64717838", "ESB64717838")]
        [TestCase(EUCountry.ES, "B64717839", null)]
        [TestCase(EUCountry.ES, "54362315K", "ES54362315K")]
        [TestCase(EUCountry.ES, "X-5253868-R", "ESX5253868R")]
        [TestCase(EUCountry.ES, "J99216582", "ESJ99216582")]
        [TestCase(EUCountry.ES, "J99216583", null)]
        [TestCase(EUCountry.ES, "J992165831", null)]
        [TestCase(EUCountry.ES, "M-1234567-L", "ESM1234567L")]
        [TestCase(EUCountry.ES, "O-1234567-L", null)]
        [TestCase(EUCountry.ES, "J99216582", "ESJ99216582")]
        [TestCase(EUCountry.ES, "54362315-K", "ES54362315K")]
        [TestCase(EUCountry.ES, "54362315Z", null)]
        [TestCase(EUCountry.ES, "54362315", null)]
        [TestCase(EUCountry.ES, "x-2482300w", "ESX2482300W")]
        [TestCase(EUCountry.ES, "x-2482300a", null)]
        [TestCase(EUCountry.ES, "X2482300", null)]

        //Sweden
        [TestCase(EUCountry.SE, "SE556042722001", "SE556042722001")]
        [TestCase(EUCountry.SE, "123456789101", null)]
        [TestCase(EUCountry.SE, "1234567897", "SE123456789701")]
        [TestCase(EUCountry.SE, "1234567891", null)]

        //United Kingdom
        [TestCase(EUCountry.GB, "GB 980 7806 84", "GB980780684")]
        [TestCase(EUCountry.GB, "802311781", null)]
        [TestCase(EUCountry.GB, "GBGD345", "GBGD345")]
        [TestCase(EUCountry.GB, "GBGD555", null)]
        [TestCase(EUCountry.GB, "GBHA555", "GBHA555")]
        [TestCase(EUCountry.GB, "GBHA444", null)]
        [TestCase(EUCountry.GB, "GBGD888819501", "GBGD888819501")]
        [TestCase(EUCountry.GB, "GBGD888855501", null)]
        [TestCase(EUCountry.GB, "GBHA888858301", "GBHA888858301")]
        [TestCase(EUCountry.GB, "GBHA888844401", null)]
        public void Validation(EUCountry euCountry, string vat, string expectedResult)
        {
            try
            {
                Assert.IsTrue(expectedResult == VatChecker.Validate(vat, euCountry).ToString());
            }
            catch (Exception e)
            {
                Assert.IsNull(expectedResult);
            }
        }
    }
}
