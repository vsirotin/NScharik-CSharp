using System;
using NScharik.Utils;

namespace NScharik.ValidationErrorFormatters
{
	/// <summary>
	/// Basis-Klasse f�r Formatter-Klassen.
	/// </summary>
	public abstract class ValidationErrorFormatter
	{
		private string suffix = ")";
		public ValidationErrorFormatter()
		{
		}

		public abstract string GetIndexAsString(ValidationError Error);
		
		public string Suffix
		{
			get{return suffix;}
			set{suffix = value;}
		}
	}
}
