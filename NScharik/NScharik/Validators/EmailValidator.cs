using System;

namespace NScharik.Validators
{
	/// <summary>
	/// Die Klase für die Validierung Email-Eingaben. 
	/// </summary>
	public class EmailValidator : FieldValidatorBase
	{
		public EmailValidator()
		{
			base.RegExPositiv = @"^\w[-.\w]*\@[-.\w]+([-.\w]+)*\.[-.\w]*$"; //Beispiel: a@b.nl hanz.mueller@t-online.de

			base.MaxLength = 100;
			base.MinLength = 6;
			base.ErrorTextCharacterSet = "Email-Adresse ist falsch";
		}
	}
}
