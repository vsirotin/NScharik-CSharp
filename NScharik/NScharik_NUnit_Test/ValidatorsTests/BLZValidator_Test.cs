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
	/// Testet automatisch die Klasse NScharik.Validators.BLZValidator mit Hilfe von NUinit Framework.
	/// </summary>
	public class BLZ_ValidatorTest
	{

		[Test]
		public void MainTest()
		{
			BLZValidator validator = new BLZValidator();
			ValidatorTestHelper vth = new ValidatorTestHelper();
			vth.DoTest(validator, 
				new string[]{//----------Positive Liste---------------------
								"23567",
								"123", 
								"896745323",
								"12345678901234567890"
							},
				new string[]{//---------Negative Liste ---------------------
								"K12345", //Buchstaben sind nicht erlaubt
								"1234 56 2", //Leerzeichnen nicht erlaubt
								"12345!", //Sonderzeichnungen sind nicht erlaubt
								"<", //HTTP-Symbolen besonders testen
								">",
								"&",
								"?",
								"=",
								"1234-56", //Minus nicht erlaubt
								"345/234", //Falsches Zeichnensatz
								"123456789012345678901" //String ist zu lang
							}
				);
		}

	}
}
