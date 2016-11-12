using System;
using NUnit.Framework;
using NScharik.Validators;

namespace NScharik.NUnitTests.ValidatorsTests
{
	/// <summary>
	/// Klasse für Automatisierung von typischen Validierungs-Testaufgaben. 
	/// </summary>
	public class ValidatorTestHelper
	{
		FieldValidatorBase fieldValidator;
		
		public ValidatorTestHelper(){}
		
		/// <summary>
		/// Ein generischer Test für die Validator-Klassen. 
		/// Weil wir in diesem Test einige Fehler provozieren, 
		/// können/sollen in Debug-Modus auf der Konsole die Fehlermeldungen kommen wie:
		/// !!!FieldValidatorException=Error-Text for requirement check not set.
		/// !!!FieldValidatorException=MaxLength not set. 
		/// !!!FieldValidatorException=MinLength not set.
		/// </summary>
		/// <param name="fieldValidator">Der Validator, der getestet sein muss</param>
		/// <param name="positiveList">Eine Liste von String-Objekten, die vom Validator akzeptiert werden müssen</param>
		/// <param name="negativeList">Eine Liste von String-Objekten, die vom Validator abgelehnt werden müssen</param>
		public void DoTest(FieldValidatorBase fieldValidator, string[] positiveList, string[] negativeList)
		{
			this.fieldValidator = fieldValidator;
			CheckPositivTestCases(positiveList);
			CheckNegativTestCases(negativeList);
			CheckRequirement();
			CheckRequirementNotRequired();
			CheckExceptions();
		}

		/// <summary>
		/// Bei diesem Test alle gegebenen Strings solle akzeptiert werden. 
		/// </summary>
		/// <param name="fieldValidator">Validator</param>
		/// <param name="ValueList">Liste der Test-Strings</param>
		private void CheckPositivTestCases(string[] ValueList)
		{
			fieldValidator.ErrorTextCharacterSet = "Bitte verwenden Sie nur erlaubte Zeichen!"; 
			for(int i = 0; i < ValueList.Length; i++)
			{
				string val = ValueList[i];
				fieldValidator.Value = val;
				string validationError = fieldValidator.Validate();
				Assertion.AssertNull(validationError);
			}
		}

		/// <summary>
		/// Bei diesem Test soll keine von  gegebenen Strings akzeptiert werden. 
		/// </summary>
		/// <param name="fieldValidator">Validator</param>
		/// <param name="ValueList">Liste der Test-Strings</param>
		private void CheckNegativTestCases(string[] ValueList)
		{
			fieldValidator.ErrorTextCharacterSet = "Bitte verwenden Sie nur erlaubte Zeichen!"; 
			for(int i = 0; i < ValueList.Length; i++)
			{
				string val = ValueList[i];
				fieldValidator.Value = val;
				string validationError = fieldValidator.Validate();
				Assertion.AssertNotNull(validationError);
			}
		}

		/// <summary>
		/// Testet Methode NScharik.Validators.AspNetValidators.NameValidator.Validate(). Aspekt: Pflichtenfeld.  
		/// Situation: Das Feld ist ein Pflichtenfeld. Wert ist nicht gesetzt und (danach) ein leeres String.  
		/// </summary>
		private void CheckRequirement()
		{ 
			fieldValidator.IsRequired = true;
			
			fieldValidator.Value = null;
			string validationError = fieldValidator.Validate();
			Assertion.AssertNotNull(validationError);
	
			fieldValidator.Value = "";
			validationError = fieldValidator.Validate();
			Assertion.AssertNotNull(validationError);
		}

		/// <summary>
		/// Testet Methode NScharik.Validators.AspNetValidators.NameValidator.Validate(). Aspekt: Pflichtenfeld.  
		/// Situation: Das Feld ist kein Pflichtenfeld. Wert ist nicht gesetzt und (danach) ein leeres String. 
		/// Erwartung: Keine Fehlermeldungen.    
		/// </summary>
		private void CheckRequirementNotRequired()
		{ 
			fieldValidator.IsRequired = false;

			fieldValidator.Value = null;
			string validationError = fieldValidator.Validate();
			Assertion.AssertNull(validationError);
	
			fieldValidator.Value = "";
			validationError = fieldValidator.Validate();
			Assertion.AssertNull(validationError);
		}

		/// <summary>
		/// In diesem Test werden konsequent alle Error-Text getestet, 
		/// ob eine Exception ausgelöst wird, wenn man versucht entsprechenden Error-Text auf null 
		/// oder als leer Zeile festlegen. 
		/// </summary>
		private void CheckExceptions()
		{
			string ERROR_TEXT = "FieldValidatorException wurde nicht ausgeloest!!!";
			bool ok = true;
			//ErrorTextRequirement testen
			try
			{
				ok = false;
				fieldValidator.ErrorTextRequirement = null;
			}
			catch(FieldValidatorException)
			{
				//OK. Wie erwartet
				ok = true;
			}
			Assertion.Assert(ERROR_TEXT, ok);

			try
			{
				ok = false;
				fieldValidator.ErrorTextRequirement = "";
			}
			catch(FieldValidatorException)
			{
				//OK. Wie erwartet
				ok = true;
			}
			Assertion.Assert(ERROR_TEXT, ok);

			//ErrorTextCharacterSet testen
			try
			{
				ok = false;
				fieldValidator.ErrorTextCharacterSet = null;
			}
			catch(FieldValidatorException)
			{
				//OK. Wie erwartet
				ok = true;
			}
			Assertion.Assert(ERROR_TEXT, ok);

			try
			{
				ok = false;
				fieldValidator.ErrorTextCharacterSet = "";
			}
			catch(FieldValidatorException)
			{
				//OK. Wie erwartet
				ok = true;
			}
			Assertion.Assert(ERROR_TEXT, ok);

			//ErrorTextMaxLength testen
			try
			{
				ok = false;
				fieldValidator.ErrorTextMaxLength = null;
			}
			catch(FieldValidatorException)
			{
				//OK. Wie erwartet
				ok = true;
			}
			Assertion.Assert(ERROR_TEXT, ok);

			try
			{
				ok = false;
				fieldValidator.ErrorTextMaxLength = "";
			}
			catch(FieldValidatorException)
			{
				//OK. Wie erwartet
				ok = true;
			}
			Assertion.Assert(ERROR_TEXT, ok);

			//ErrorTextMinLength testen
			try
			{
				ok = false;
				fieldValidator.ErrorTextMinLength = null;
			}
			catch(FieldValidatorException)
			{
				//OK. Wie erwartet
				ok = true;
			}
			Assertion.Assert(ERROR_TEXT, ok);

			try
			{
				ok = false;
				fieldValidator.ErrorTextMinLength = "";
			}
			catch(FieldValidatorException)
			{
				//OK. Wie erwartet
				ok = true;
			}
			Assertion.Assert(ERROR_TEXT, ok);
		}

		
	}
}

