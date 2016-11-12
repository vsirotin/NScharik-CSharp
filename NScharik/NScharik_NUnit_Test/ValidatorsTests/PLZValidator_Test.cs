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
	/// Zusammenfassung für plzValidator_Test.
	/// </summary>
	public class PLZValidator_Test
	{
		[Test]
		public void MainTest()
		{
			PLZValidator validator = new PLZValidator();
			ValidatorTestHelper vth = new ValidatorTestHelper();
			vth.DoTest(validator, 
				new string[]{//----------Positive Liste---------------------
								"D-45721",
								"D 45721",
								"D-00000", 
								"12345",
								"67890"
							},
				new string[]{//---------Negative Liste ---------------------
								"D-123456", //Zu lange PLZ
								"DE-12345", //Nicht erlaubt
								"1234!", //Sonderzeichnungen sind nicht erlaubt
								"<12345", //HTTP-Symbolen besonders testen
								">12345",
								"45&123",
								"12?345",
								"1234=",
								"D+12345", //Nicht erlaubt
								"D  12345" //Zwei Leerzeichen"
							}
				);
		}

	}
}
