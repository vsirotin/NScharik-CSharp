using System;

namespace NScharik.Validators
{
	/// <summary>
	/// Validator für die Kontonummer.
	/// </summary>
	public class KontoNummerValidator :FieldValidatorBase
	{
		public KontoNummerValidator()
		{
			//Nur 8 Ziffern sind erlaubt. Andere Kombinationen nicht.
			base.MaxLength = 8;
			base.MinLength = 8;
			base.RegExPositiv = @"^\d{8}$";
		}
	}
}
