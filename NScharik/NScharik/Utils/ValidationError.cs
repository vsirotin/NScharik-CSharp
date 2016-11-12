using System;
using NScharik.ValidationErrorFormatters;

namespace NScharik.Utils
{
	/// <summary>
	/// Klasse für die Bearbeitung Fehlermeldungen während des Validierungs-Vorgangs.
	/// </summary>
	public class ValidationError
	{
		private uint index;
		private string errrorText;
		private ValidationErrorFormatter formatter;
		private ValidationError()
		{
		}

		internal ValidationError(uint Index, string ErrorText, ValidationErrorFormatter Formatter)
		{
			index = Index;
			errrorText = ErrorText;
			formatter = Formatter;
		}


		public uint Index
		{
			get{return index;}
		}

		public string IndexFormatted
		{
			get{return formatter.GetIndexAsString(this);}
		}

		public string ErrorText
		{
			get{return errrorText;}
		}
	}

	/// <summary>
	/// Factory-Klasse für das Anlegen neuen ValidationError-Objkten.
	/// </summary>
	public class ValidationErrorFactory
	{
		private ValidationErrorFormatter formatter;
		private uint index = 1;

		public ValidationErrorFactory(ValidationErrorFormatter Formatter)
		{
			formatter = Formatter;
		}

		public ValidationError CreateValidationError(string ErrorText)
		{
			return new ValidationError(index++, ErrorText, formatter);
		}

	}
}
