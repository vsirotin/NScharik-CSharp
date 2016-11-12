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
	/// Zusammenfassung für GenericValidator_Test.
	/// </summary>
	public class GenericValidator_Test
	{
		[Test]
		public void MainTest()
		{
			GenericValidator validator = new GenericValidator();
			ValidatorTestHelper vth = new ValidatorTestHelper();
			vth.DoTest(validator, 
				new string[]{//----------Positive Liste---------------------
								"aa 23567",
								"123", 
								"xx896745323rrr",
								"1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" //100 Symbolenolen
							},
				new string[]{//---------Negative Liste ---------------------
								"<", //HTTP-Symbolen besonders testen
								">",
								"&",
								"?",
								"=",
								"12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901" //Text ist zu lang. 101 Symbol
							}
				);
		}

	}
}
