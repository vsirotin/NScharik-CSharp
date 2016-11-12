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
	/// Testet automatisch die Klasse NScharik.Validators.NameValidator mit Hilfe von NUinit Framework.
	/// </summary>
	public class NameValidator_Test
	{
		[Test]
		public void MainTest()
		{
			NameValidator validator = new NameValidator();
			ValidatorTestHelper vth = new ValidatorTestHelper();
			vth.DoTest(validator, 
				new string[]{//----------Positive Liste---------------------
								"Müller",
								"ÖöÄäÜüß", //Alle Umlaute sind erlaubt
								"Hans Müller",
								"Hans Müller Junior",
								"Dr. Otto",
								"Dr. Jurgen Otto",
								"Frau Grafin Wintzerode",
								"Mr. Jones",
								"Wilhelm II"
							},
				new string[]{//---------Negative Liste ---------------------
								"Omar Ibn Said Amman III", //Zu lange Name
								"Wilhelm 2", //Zahlen sind nicht erlaubt
								"Ich!", //Sonderzeichnungen sind nicht erlaubt
								"<", //HTTP-Symbolen besonders testen
								">",
								"&",
								"?",
								"=",
								"Mamma-Mia", //Minus nicht erlaubt
								"HierInterval  zwei Leerzeichen",
								"<", //HTTP-Symbolen besonders testen
								">",
								"&",
								"?",
								"=",
								"1234-56", //Minus nicht erlaubt
								"345/234" //Falsches Zeichnensatz
							}
				);
		}
	}
}
