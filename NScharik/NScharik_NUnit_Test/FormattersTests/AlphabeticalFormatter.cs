using System;
using NUnit.Framework;
using System.Diagnostics;
using NScharik;
using NScharik.NUnitTests;
using NScharik.ValidationErrorFormatters;
using NScharik.Utils;

namespace NScharik.NUnitTests.FormattersTests
{
	[TestFixture]
	/// <summary>
	/// Testet automatisch die Klasse NScharik.ValidationErrorFormatters.AlphabeticalFormatter mit Hilfe von NUinit Framework.
	/// </summary>
	public class AlphabeticalFormatter_Test
	{
		/// <summary>
		/// Testet Methode AlphabeticalFormatter.GetIndexAsString_Test()
		/// </summary>
		[Test]
		public void GetIndexAsString_Test()
		{
			NUnitTrace.WriteLine("-------Start AlphabeticalFormatter_Test.GetIndexAsString_Test");
			NUnitTrace.WriteLine("Man erwartet in diesem Test Ausgabe in Form: a), b), c) ...z), a1), b1),c1)..z1), a2)...");
			AlphabeticalFormatter alphabeticalFormatter = new AlphabeticalFormatter();
			alphabeticalFormatter.Suffix = ")";
			ValidationErrorFactory validationErrorFactory = new ValidationErrorFactory(alphabeticalFormatter);
			//Wir generieren mehrere Fehlermeldungen. 
			//Die Ergebnisse sollen leider auch visuell in Standard Out bei 
			//NUnit-Console geprüft werden. 
			for(int i = 0; i < 60; i++)
			{
				ValidationError validationError = validationErrorFactory.CreateValidationError("Test-Text");
				string errorText = alphabeticalFormatter.GetIndexAsString(validationError);
				NUnitTrace.WriteLine("errorText=" + errorText); 
			}
			NUnitTrace.WriteLine("-------Fin GetIndexAsString_Test");
		}
	}
}

