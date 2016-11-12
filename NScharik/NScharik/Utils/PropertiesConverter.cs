using System;
using System.Collections;

namespace NScharik.Utils
{
	/// <summary>
	/// Die Klasse enthält Hilfs-Methoden für die Konvertierung 
	/// eines Properties-String in eine HashTable und umgekehrt.
	/// Zum Beispiel wird String @„Param1=’Value1’  Param2=’Value2’“ 
	/// in Hashtable mit zwei Elementen konvertiert. 
	/// </summary>
	public class PropertiesConverter
	{
		private PropertiesConverter()
		{
		}

		[STAThread]
		public static Hashtable DeCodePropString(string PropString)
		{
			if((PropString == null) || (PropString.Length == 0)){return null;}

			Hashtable res = new Hashtable();
			//Wir bearbeiten einzelen Paars nacheinander
			int pos1 = 0;
			int pos2 = 0;
			int len = PropString.Length;
			while(pos2 < len)
			{
				pos2 = PropString.IndexOf(";", pos1);
				if(pos2 < 0){pos2 = len;}
				int twoItemsLen = pos2 - pos1;
				string sTwoItems = PropString.Substring(pos1, pos2 - pos1);
				
				//Finden Grenze zwischen Items
				int posBound = sTwoItems.IndexOf(":");
				if(posBound < 0)
				{
					throw new Exception("In Property String In property string separator : not found. Error- Position after position " + pos1);
				}
				string key = sTwoItems.Substring(0, posBound);
				string val = sTwoItems.Substring(posBound + 1, twoItemsLen - posBound - 1);
				key = key.TrimStart();
				key = key.TrimEnd();

				val = val.TrimStart();
				val = val.TrimEnd();

				res.Add(key, val);
				pos1 = pos2 + 1;
			}
			return res;

		}

		[STAThread]
		public static string CodePropString(Hashtable Properties)
		{
			if((Properties == null) || (Properties.Count == 0)){return null;}
			string res = "";
			IDictionaryEnumerator e = Properties.GetEnumerator();
			while(e.MoveNext())
			{
				if(res.Length > 0){res +="; ";}
				string key = (string)e.Key;
				string val = (string)e.Value;
				res += key + ": " + val;
			}
			return res;
		}
	}
}
