using System;
using NUnit.Framework;
using System.Diagnostics;
using NScharik;
using NScharik.NUnitTests;
using NScharik.Validators;

namespace NScharik.NUnitTests.ValidatorsTests
{
	[TestFixture]
	/// <summary>
	/// Zusammenfassung für TelephoneNumberValidator_Test.
	/// </summary>
	public class TelephoneNumberValidator_Test
	{
		[Test]
		public void MainTest()
		{
			TelephoneNumberValidator validator = new TelephoneNumberValidator();
			ValidatorTestHelper vth = new ValidatorTestHelper();
			vth.DoTest(validator, 
				new string[]{//----------Positive Liste---------------------
								"02345-23456",
								"129476654", 
								"+49-0985-678-9087",
								"6778 090 000 012",
								"(0201)807-2322",
								"0201/807-2322"
							},
				new string[]{//---------Negative Liste ---------------------
								"K12345", //Buchstaben sind nicht erlaubt
								"12345!", //Sonderzeichnungen sind nicht erlaubt
								"2333<41", //HTTP-Symbolen besonders testen
								"45>890",
								"4555&66",
								"54?88",
								"4=5678",
								"21", //zu kurz
								"(2-/)+(1)" //zu wenig Ziffern
							}
				);
		}

	}
}
