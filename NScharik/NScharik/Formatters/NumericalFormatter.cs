using System;
using NScharik.Utils;

namespace NScharik.ValidationErrorFormatters
{
	/// <summary>
	/// Formatierungs-Klasse für Ausgabe Indexen in numerischer Form. 
	/// Daten werden wie folgt formatiert : 1), 2)...
	/// </summary>
	public class NumericalFormatter : ValidationErrorFormatter
	{

		override public string GetIndexAsString(ValidationError Error)
		{
			return "" + Error.Index + base.Suffix; 
		}
	}
}
