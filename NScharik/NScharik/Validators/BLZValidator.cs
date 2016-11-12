using System;

namespace NScharik.Validators
{
	/// <summary>
	/// Die Klase für die Validierung BLZ (Bankleitzahl) Eingaben. 
	/// </summary>
	public class BLZValidator : FieldValidatorBase
	{
		public BLZValidator()
		{
			base.RegExPositiv = @"^\d*$"; //Beispiel: 0536721 123896542

			base.MaxLength = 20;
			base.MinLength = 3;
		}
	}
}
