using System;

namespace NScharik.Validators
{
	/// <summary>
	/// Validator für Telefonnummer
	/// </summary>
	public class TelephoneNumberValidator : FieldValidatorBase
	{
		public TelephoneNumberValidator()
		{
			base.MaxLength = 50;
			base.RegExNegativ = @"(['<''>''&''?''=''!''§''$''%'';'':'',''.'])|([a-zA-Z])";
			base.ErrorTextCharacterSet = "Bitte geben Sie eine gültige Telefonnummer ein";
		}

		/// <summary>
		/// Führt die Prüfung durch Objekt-Umwandlung durch.
		/// </summary>
		/// <returns>string bei Fehler. Null, wenn kein Fehler gefunden wurde.</returns>
		protected override string CheckObjectSerialization()
		{
			//Wir verwenden hier folgendes Algorithmus: Wenn mindesten drei Ziffern in String vorhanden sind, 
			//wir bewerten den String als eine Telefonnummer. 
			int count = 0;
			for(int i = 0; i < base.Value.Length; i++)
			{
				if(char.IsDigit(base.Value[i])){count++;}
			}
			if(count < 3)
			{
				return base.ErrorTextCharacterSet;
			}
			return null;
		}
	}
}
