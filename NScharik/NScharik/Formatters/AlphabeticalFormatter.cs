using System;
using NScharik.Utils;

namespace NScharik.ValidationErrorFormatters
{
	/// <summary>
	/// Formatierungs-Klasse für Ausgabe Indexen in alphabetischer Form. 
	/// Daten werden wie folgt formatiert : a), b), c) ...z), a1), b1),c1)..z1), a2)...
	/// </summary>
	public class AlphabeticalFormatter : ValidationErrorFormatter
	{
		const string letters = "abcdefghijklmnopqrstuvwxyz";
		static readonly int lenLetters;

		static AlphabeticalFormatter()
		{
			lenLetters = letters.Length;
		}


		/// <summary>
		/// Daten werden wie folgt formatiert : a), b), c) ...z), a1), b1),c1)..z1), a2)...
		/// </summary>
		/// <param name="Error">ValidationError-Objekt</param>
		/// <returns>Formatiertes String</returns>
		override public string GetIndexAsString(ValidationError Error)
		{
			int ind = (int)Error.Index - 1;
			if(ind < lenLetters)
			{
				return "" + letters[(int)Error.Index - 1] + base.Suffix; 
			}
			int indLetter = ind  % lenLetters;
			int indSuffix = ind/lenLetters;
			string pref = "" + letters[indLetter] + indSuffix;
			return pref + base.Suffix;
		}
	}
}
