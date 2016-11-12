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
	/// Testet automatisch die Klasse NScharik.ValidationErrorFormatters.NumericalFormatter mit Hilfe von NUinit Framework.
	/// </summary>
	public class NumericalFormatter_Test
	{
		/// <summary>
		/// Testet Methode NumericalFormatter.GetIndexAsString_Test()
		/// </summary>		
		[Test]
		public void GetIndexAsString_Test()
		{
			NUnitTrace.WriteLine("-------Start GetIndexAsString_Test");
			NUnitTrace.WriteLine("Man erwartet in diesem Test Ausgabe in Form: 1]., 2]., 3]., 4]. ...");
			NumericalFormatter numericalFormatter = new NumericalFormatter();
			numericalFormatter.Suffix = "].";
			ValidationErrorFactory validationErrorFactory = new ValidationErrorFactory(numericalFormatter);
			//Wir generieren mehrere Fehlermeldungen. 
			//Die Ergebnisse sollen leider auch visuell in Standard Out bei 
			//NUnit-Console geprüft werden.  
			for(int i = 1; i < 50; i++)
			{
				ValidationError validationError = validationErrorFactory.CreateValidationError("Test-Text");
				string errorText = numericalFormatter.GetIndexAsString(validationError);
				NUnitTrace.WriteLine("errorText=" + errorText); 
			}
			NUnitTrace.WriteLine("-------Fin GetIndexAsString_Test");
		}
	}
}

