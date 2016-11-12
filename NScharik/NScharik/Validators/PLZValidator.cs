using System;

namespace NScharik.Validators
{
	/// <summary>
	/// Validator für Postleitzahl
	/// </summary>
	public class PLZValidator : FieldValidatorBase
	{
		public PLZValidator()
		{
			base.RegExPositiv = @"^([D]-\d{5})$|^([D] \d{5})$|^(\d{5})$"; //Beispiel: D-12345, D 12345, 12345
			base.MaxLength = 7;
			base.MinLength = 5;
		}
	}
}
