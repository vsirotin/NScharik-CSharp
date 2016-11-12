using System;

namespace NScharik.Validators
{
	/// <summary>
	/// Validator für Name-Feld.
	/// </summary>
	public class NameValidator : FieldValidatorBase
	{
		public NameValidator()
		{
			base.MaxLength = 100;
			base.RegExPositiv = @"^(\w+\. \w+ \w+)$|^(\w+\. \w+)$|^(\w+ \w+ \w+)$|^(\w+ \w+)$|^(\w+)$";
			base.RegExNegativ = @"\d";

		}
	}
}
