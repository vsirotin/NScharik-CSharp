using System;
using System.Collections;
using System.Diagnostics;
using System.Text.RegularExpressions;

using NScharik.Utils;

namespace NScharik.Validators
{
	/// <summary>
	/// Abstrakte Basis-Klasse für konkrete Validators wie Name-Validator oder Datum-Validator.
	/// </summary>
	public abstract class FieldValidatorBase
	{
		public const string EXCEPTION_MSG_ERROR_TEXT_REQUIREMENT_NOT_SET = "Error-Text for requirement check not set.";
		public const string EXCEPTION_MSG_MAX_LENGTH_NOT_SET = "MaxLength not set.";
		public const string EXCEPTION_MSG_MIN_LENGTH_NOT_SET = "MinLength not set.";
		public const string EXCEPTION_MSG_ERROR_TEXT_MAX_LENGTH_NOT_SET = "Error-Text for String-MaxLength Validation not set.";
		public const string EXCEPTION_MSG_ERROR_TEXT_REGEX_NOT_SET = "Character Set (Regular Expression) not set.";
		public const string EXCEPTION_MSG_ERROR_TEXT_REGEX_NEGATIVE_NOT_SET = "Negative Filter (Regular Expression) not set.";
		public const string EXCEPTION_MSG_ERROR_TEXT_REGEX_POSITIVE_NOT_SET = "Positive Filter (Regular Expression) not set.";

		public const string KEY_ERR_TXT_MAX_LENGTH = "StringTooLong";
		public const string ERR_TXT_MAX_LENGTH = "Text ist zu lang.";

		public const string KEY_ERR_TXT_MIN_LENGTH = "StringTooShort";
		public const string ERR_TXT_MIN_LENGTH = "Text ist zu kurz.";

		public const string KEY_ERR_TXT_CHARACTER_SET = "CharacterSetFalse";
		public const string ERR_TXT_CHARACTER_SET = "Zeichensatz ist falsch.";

		public const string KEY_ERR_TXT_REQUIRED_FIELD = "RequiredFieldNotSet";
		public const string ERR_TXT_REQUIRED_FIELD = "Pflichtenfeld ist nicht gesetzt.";

	
		public const string KEY_MIN_LENGTH = "Minimale Eingabetext-Länge";
		public const string KEY_MAX_LENGTH = "Maximale Eingabetext-Länge";
		public const string KEY_REGEX_POSITIVE = "Positiver Regex-Filter";
		public const string KEY_REGEX_NEGATIVE = "Negativer Regex-Filter";

		private static Hashtable errorMessagesTemplate = null;

		/// Map (Hashtable) mit Fehlermeldungen. 
		/// Key – Fehlermeldungstyp, Value – Fehlermeldungstext. 
		private Hashtable errorMessages = null;


		private static Hashtable validationParamsTemplate = null;

		/// Map (Hashtable) mit Validierungsparameter. 
		/// Key – Parametertyp, Value – Parameter-Wert. 
		private Hashtable validationParams = null;

		//True, wenn das Feld ein Pflichtenfeld ist. 
		private bool isRequirement = false; 

		//Eingabe-String in Originalform, die vom validierten Objekt ermittelt wurde. 
		private string val;

		//Der Fehlermeldungstext für gefundenen Fehler. 
		private string myErrorText;

		static FieldValidatorBase()
		{
			//Setzen allgemeine  Voreinstellungen fest.
			validationParamsTemplate = new Hashtable();
			validationParamsTemplate.Add(KEY_MAX_LENGTH, "" + uint.MaxValue);
			validationParamsTemplate.Add(KEY_MIN_LENGTH, "" + 0);
			validationParamsTemplate.Add(KEY_REGEX_POSITIVE, "");
			validationParamsTemplate.Add(KEY_REGEX_NEGATIVE, "");

			errorMessagesTemplate = new Hashtable();
			errorMessagesTemplate.Add(KEY_ERR_TXT_MAX_LENGTH, ERR_TXT_MAX_LENGTH);
			errorMessagesTemplate.Add(KEY_ERR_TXT_MIN_LENGTH, ERR_TXT_MIN_LENGTH);
			errorMessagesTemplate.Add(KEY_ERR_TXT_CHARACTER_SET, ERR_TXT_CHARACTER_SET);
			errorMessagesTemplate.Add(KEY_ERR_TXT_REQUIRED_FIELD, ERR_TXT_REQUIRED_FIELD);

		}

		protected FieldValidatorBase()
		{
			//Klonen allgemeine  Voreinstellungen
			validationParams = (Hashtable)validationParamsTemplate.Clone();
			errorMessages = (Hashtable)errorMessagesTemplate.Clone();
			
			//Setzen absolut notwendige Parameter fest. 
			//In konkreten Validators können diese Parameters überschrieben werden. 
			MaxLength = 100;
			RegExNegativ = @"['<''>''&''?''=']";
		}


		/// <summary>
		/// Eingabe-String in Originalform, die vom validierten Objekt ermittelt wurde. 
		/// </summary>
		public string Value
		{
			set{val = value;}
			get{return val;}
		}

		/// <summary>
		/// True, wenn das Feld ein Pflichtenfeld ist.
		/// </summary>
		public virtual bool IsRequired
		{
			set{isRequirement = value;}
			get{return isRequirement;}
		}

		/// <summary>
		/// Liefert den Fehlermeldungstext für gefundenen Fehler oder null, wenn kein Fehler gefunden worden.
		/// </summary>
		public string ErrorText
		{
			get{return myErrorText;}
		}
		
		/// <summary>
		/// Minimale Länge von Eingabe-String. 
		/// </summary>
		protected uint MaxLength
		{
			set{ValidationParams[FieldValidatorBase.KEY_MAX_LENGTH] = "" + value;}
			get
			{
				string s = (string)ValidationParams[FieldValidatorBase.KEY_MAX_LENGTH];
				return uint.Parse(s);
			}
		}

		/// <summary>
		/// Maximale Länge von Eingabe-String. 
		/// </summary>
		protected uint MinLength
		{
			set{ValidationParams[FieldValidatorBase.KEY_MIN_LENGTH] = "" + value;}
			get
			{
				string s = (string)ValidationParams[FieldValidatorBase.KEY_MIN_LENGTH];
				return uint.Parse(s);
			}
		}

		/// <summary>
		/// //Regulärer Ausdruck für die Prüfung des Zeichensatzes. Positives Filter 
		/// </summary>
		public virtual string RegExPositiv
		{
			set
			{   
				if(FieldValidatorBase.StringNotSet(value))
				{
					throw new FieldValidatorException(FieldValidatorBase.EXCEPTION_MSG_ERROR_TEXT_REGEX_POSITIVE_NOT_SET);
				}
				ValidationParams[FieldValidatorBase.KEY_REGEX_POSITIVE] = value;
			}
			get{return (string)ValidationParams[FieldValidatorBase.KEY_REGEX_POSITIVE];}
		}

		/// <summary>
		/// //Regulärer Ausdruck für die Prüfung des Zeichensatzes. Negatives Filter 
		/// </summary>
		public virtual string RegExNegativ
		{
			set
			{   
				if(FieldValidatorBase.StringNotSet(value))
				{
					throw new FieldValidatorException(FieldValidatorBase.EXCEPTION_MSG_ERROR_TEXT_REGEX_NEGATIVE_NOT_SET);
				}
				ValidationParams[FieldValidatorBase.KEY_REGEX_NEGATIVE] = value;
			}
			get{return (string)ValidationParams[FieldValidatorBase.KEY_REGEX_NEGATIVE];}
		}

		/// <summary>
		/// Fehlermeldungstext für den Fall, wenn Pflichtenfeld nicht gesetzt ist. 
		/// </summary>
		public virtual string ErrorTextRequirement
		{
			set
			{   
				if(FieldValidatorBase.StringNotSet(value))
				{
					throw new FieldValidatorException(FieldValidatorBase.EXCEPTION_MSG_ERROR_TEXT_REQUIREMENT_NOT_SET);
				}
				ErrorMessages[FieldValidatorBase.KEY_ERR_TXT_REQUIRED_FIELD] = value;
			}
			get{return (string)ErrorMessages[FieldValidatorBase.KEY_ERR_TXT_REQUIRED_FIELD];}
		}


		/// <summary>
		/// Fehlermeldungs-Text für zu lange Eingabe-String.  
		/// </summary>
		public virtual string ErrorTextMaxLength
		{
			set
			{
				if(FieldValidatorBase.StringNotSet(value))
				{
					throw new FieldValidatorException(FieldValidatorBase.EXCEPTION_MSG_MAX_LENGTH_NOT_SET);
				}
				ErrorMessages[FieldValidatorBase.KEY_ERR_TXT_MAX_LENGTH] = value;
			}
			get{return (string)ErrorMessages[FieldValidatorBase.KEY_ERR_TXT_MAX_LENGTH];}
		}

		/// <summary>
		/// Fehlermeldungs-Text für zu lange Eingabe-String.  
		/// </summary>
		public virtual string ErrorTextMinLength
		{
			set
			{
				if(FieldValidatorBase.StringNotSet(value))
				{
					throw new FieldValidatorException(FieldValidatorBase.EXCEPTION_MSG_MIN_LENGTH_NOT_SET);
				}
				ErrorMessages[FieldValidatorBase.KEY_ERR_TXT_MIN_LENGTH] = value;
			}
			get{return (string)ErrorMessages[FieldValidatorBase.KEY_ERR_TXT_MIN_LENGTH];}
		}

		/// <summary>
		/// //Fehlermeldung für den Fall, wenn der reguläre Ausdruck für die Prüfung des Zeichensatzes nicht gesetzt ist. 
		/// </summary>
		public virtual string ErrorTextCharacterSet
		{
			set
			{
				if(FieldValidatorBase.StringNotSet(value))
				{
					throw new FieldValidatorException(FieldValidatorBase.EXCEPTION_MSG_MAX_LENGTH_NOT_SET);
				}
				ErrorMessages[FieldValidatorBase.KEY_ERR_TXT_CHARACTER_SET] = value;
			}
			get{return (string)ErrorMessages[FieldValidatorBase.KEY_ERR_TXT_CHARACTER_SET];;}
		}

		/// <summary>
		/// Liefert bzw. setzt fest eine Map (Hashtable) mit Fehlermeldungen. 
		/// Key – Fehlermeldungstyp, Value – Fehlermeldungstext. 
		/// </summary>
		public virtual Hashtable ErrorMessages
		{
			get
			{
				if(errorMessages == null)
				{
					errorMessages = (Hashtable)errorMessagesTemplate.Clone();
				}
				return errorMessages;
			}
			set{errorMessages = value;}
		}

		/// <summary>
		/// Liefert bzw. setzt fest eine Map (Hashtable) mit Validierungsparameter. 
		/// Key – Parametertyp, Value – Parameter-Wert. 
		/// </summary>
		public virtual Hashtable ValidationParams
		{
			get
			{
				if(validationParams == null)
				{
					validationParams = (Hashtable)validationParamsTemplate.Clone();
				}
				return validationParams;
			}
			set{validationParams = value;}
		}

		

		protected virtual bool IsEmpty
		{
			get
			{
				if((val == null) || (val.Length == 0)){return true;}
				return false;
			}
		}

		/// <summary>
		/// Validiert gegebenen String. 
		/// </summary>
		/// <returns>Fehlermeldungstext oder null</returns>
		public virtual string Validate()
		{
			//Stufe 1: Ist das Feld ein Pflichtenfeld?
			if(IsRequired)
			{
				if(IsEmpty)
				{
					myErrorText = (string)ErrorMessages[FieldValidatorBase.KEY_ERR_TXT_REQUIRED_FIELD];
					return myErrorText;
				}
			}
			else
			{
				if(IsEmpty)
				{
					//Das ist kein Pflichtenfeld. Der Eingabetext ist nicht gesetzt  –> Wir beenden die Validierung. 
					return null;
				}
			}

			//Stufe 2: String-Lange prüfen. 
			myErrorText = CheckLength();
			if(myErrorText != null){return myErrorText;}

			//Stufe 3: Zeichensatz prüfen. 
			myErrorText = CheckCharacterSet();
			if(myErrorText != null){return myErrorText;}

			//Stufe 4: Prüfung durch Objekt-Umwandlung
			myErrorText = CheckObjectSerialization();
			if(myErrorText != null){return myErrorText;}

			//Stufe 5: Plausibilitätsprüfung durchführen
			myErrorText = CheckPlausibility();

			return myErrorText;
		}

		/// <summary>
		/// Prüft String-Lange
		/// </summary>
		/// <returns>string bei Fehler. Null, wenn kein Fehler gefunden wurde.</returns>
		protected virtual string CheckLength()
		{
			if(MaxLength == uint.MaxValue)
			{
				throw new FieldValidatorException(EXCEPTION_MSG_MAX_LENGTH_NOT_SET);
			}
			
			if(val.Length > MaxLength)
			{
				return (string)ErrorMessages[FieldValidatorBase.KEY_ERR_TXT_MAX_LENGTH];
			}

			if(MinLength == 0){return null;}
			if(val.Length < MinLength)
			{
				return (string)ErrorMessages[FieldValidatorBase.KEY_ERR_TXT_MIN_LENGTH];
			}

			return null;
		}

		/// <summary>
		/// Prüft den Zeichensatz.
		/// </summary>
		/// <returns>string bei Fehler. Null, wenn kein Fehler gefunden wurde.</returns>
		protected virtual string CheckCharacterSet()
		{	
			string characterSetRegExPositiv = (string)ValidationParams[FieldValidatorBase.KEY_REGEX_POSITIVE];
			//Positives Filter verwenden
			if((characterSetRegExPositiv != null) && (characterSetRegExPositiv.Length > 0))
			{
				if(!Regex.IsMatch(val, characterSetRegExPositiv))
				{
					return GenerateErrorText();
				}
			}

			string characterSetRegExNegativ = (string)ValidationParams[FieldValidatorBase.KEY_REGEX_NEGATIVE];
			//Negatives Filter verwenden
			if((characterSetRegExNegativ == null) || (characterSetRegExNegativ.Length == 0)){return null;}
			if(Regex.IsMatch(val, characterSetRegExNegativ))
			{
				return GenerateErrorText();
			}

			return null;

		}



		private string GenerateErrorText()
		{

			return (string)ErrorMessages[FieldValidatorBase.KEY_ERR_TXT_CHARACTER_SET];
		}

		/// <summary>
		/// Führt die Prüfung durch Objekt-Umwandlung durch.
		/// </summary>
		/// <returns>string bei Fehler. Null, wenn kein Fehler gefunden wurde.</returns>
		protected virtual string CheckObjectSerialization()
		{
			return null;
		}

		/// <summary>
		/// Führt die Plausibilitätsprüfung durch. 
		/// </summary>
		/// <returns>string bei Fehler. Null, wenn kein Fehler gefunden wurde.</returns>
		protected virtual string CheckPlausibility()
		{
			return null;
		}

		protected static bool StringNotSet(string s)
		{
			if((s == null) || (s.Length == 0)){return true;}
			return false;
		}

	}

	public class FieldValidatorException : Exception
	{

		//Msg soll immer gesetzt werden.
		private FieldValidatorException(){}

		public FieldValidatorException(string msg): base(msg)
		{
			Trace.WriteLine("!!!FieldValidatorException=" + msg);

		}


	}
}
