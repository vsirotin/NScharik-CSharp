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
	/// Zusammenfassung für EmailValidator_Test.
	/// </summary>
	public class EmailValidator_Test
	{
		[Test]
		public void MainTest()
		{
			EmailValidator validator = new EmailValidator();
			ValidatorTestHelper vth = new ValidatorTestHelper();
			vth.DoTest(validator, 
				new string[]{//----------Positive Liste---------------------
								"a.b@c.d",
								"A.B@C.D",
								"name.vorname-etwas@firma.domain", 
								"name.vorname-etwas@firma.domain",
								"name.vorname-etwas@firma-abteilung.subdomain1.subdomain2.domain"
							},
				new string[]{//---------Negative Liste ---------------------
								"a.b@c", //Kein Domain
								"a.b.com", //Kein @-Zeichnen
								"a.b@c:d", //Doppelpunkt
								"a.b@@c..d", //@-Zeichnen steht zwei Mal
								"<a.b@c.d", //HTTP-Symbolen besonders testen
								">a.b@c.d",
								"a.b@c.d&",
								"?a.b@c.d",
								"a.b@c.d=s",
								"a.b@c blank.d", //Leerzeichnen  nicht erlaubt
								"345/234" //Falsches Zeichnensatz
							}
					);
		}
	}
}
