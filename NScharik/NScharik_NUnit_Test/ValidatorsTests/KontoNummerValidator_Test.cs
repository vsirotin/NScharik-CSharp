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
	/// Zusammenfassung für KontoNummerValidator_Test.
	/// </summary>
	public class KontoNummerValidator_Test
	{
		[Test]
		public void MainTest()
		{
			KontoNummerValidator validator = new KontoNummerValidator();
			ValidatorTestHelper vth = new ValidatorTestHelper();
			vth.DoTest(validator, 
				new string[]{//----------Positive Liste---------------------
								"12345678",
								"00123456", 

							},
				new string[]{//---------Negative Liste ---------------------
								"1234<567", //HTTP-Symbolen besonders testen
								"1234>567",
								"1234&567",
								"1234567?",
								"=1234567",
								"1234-5678", //Falsche Lange
								"1234/567" //Falsches Zeichnensatz
							}
				);
		}

	}
}
