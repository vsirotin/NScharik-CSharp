using System;
using System.Collections;
using NScharik.Utils;
using NUnit.Framework;
using System.Diagnostics;

namespace NScharik.NUnitTests.UtilsTests
{
	[TestFixture]
	/// <summary>
	/// Test für die Klasse NScharik.Utils.PropertiesConverter
	/// Die Klasse PropertiesConverter wird bei NScharik Framework 
	/// bei Serialisierung/Deserialisierung Properties in/von HTML Text verwendet. 
	/// </summary>
	public class PropertiesConverter_Test
	{
		//Testen von Serialisierung Hashtable in Key-Value Pairs String 
		[Test]
		public void CodeOK1_Test()
		{
			NUnitTrace.WriteLine("-------Begin CodeOK1_Test");
			Hashtable ht = new Hashtable();
			ht.Add("Key1", "Value1");
			ht.Add("Key2", "Value2");
			ht.Add("Key3", "Value3");
			string res = PropertiesConverter.CodePropString(ht);
			Assertion.AssertNotNull(res);
			NUnitTrace.WriteLine("Result=" + res);
			NUnitTrace.WriteLine("-------Fin CodeOK1_Test");
		}
		
		//Testen von Deserialisierung String in Hashtable und
		//danach von Serialisierung Hashtable in Key-Value Pairs String 
		[Test]
		public void DeCodeCodeOK_Test()
		{
			NUnitTrace.WriteLine("-------Begin DeCodeCodeOK_Test");
			string test = @"Param1: Value1; Param2: Value2; Param3: Value3";
			Hashtable ht = PropertiesConverter.DeCodePropString(test);
			Assertion.AssertNotNull(ht);
			string res = PropertiesConverter.CodePropString(ht);
			Assertion.AssertNotNull(res);
			NUnitTrace.WriteLine("Test-String=" + test);
			NUnitTrace.WriteLine("Resultat-String=" + res);
			NUnitTrace.WriteLine("-------Fin DeCodeCodeOK_Test");
		}

		//Testen von Serialisierung Hashtable in Key-Value Pairs String und
		//danach von Deserialisierung String in Hashtable 
		[Test]
		public void CodeDeCodeOK_Test()
		{
			Hashtable ht = new Hashtable();
			ht.Add("Key1", "Value1");
			ht.Add("Key2", "Value2");
			ht.Add("Key3", "Value3");
			string res = PropertiesConverter.CodePropString(ht);
			Assertion.AssertNotNull(res);
			Hashtable ht1 = PropertiesConverter.DeCodePropString(res);
			Assertion.AssertNotNull(ht1);
			Assertion.AssertEquals(ht.Count, ht1.Count);
		}
		
		//Testen von Serialisierung NULL-Hashtable
		[Test]
		public void CodeNullData_Test()
		{
			string res = PropertiesConverter.CodePropString(null);
			Assertion.AssertNull(res);
		}

		//Testen von Serialisierung einer leeren Hashtable
		[Test]
		public void CodeEmptyTable_Test()
		{
			Hashtable ht = new Hashtable();
			string res = PropertiesConverter.CodePropString(ht);
			Assertion.AssertNull(res);
		}

		//Testen von Deserialisierung von Key-Value Pairs String in Hashtable  
		[Test]
		public void DeCodeOK1_Test()
		{
			string test = @"Param1: Value1; Param2: Value2; Param3: Value3";
			Hashtable ht = PropertiesConverter.DeCodePropString(test);
			Assertion.AssertNotNull(ht);
			Assertion.AssertEquals(3, ht.Count);
			Assertion.AssertEquals("Value2", ht["Param2"]);

		}

		//Testen von Formatierung-Prüfung
		[Test]
		[ExpectedException(typeof(Exception))]
		public void DeCodeBadData_Test()
		{
			//String ist falsch formatiert. Fehlt ein Doppelpunkt 
			string test = @"Param1: Value1; Param2: Value2; Param3 Value3";
			Hashtable ht = PropertiesConverter.DeCodePropString(test);
		}

		//Testen von NULL-String bei Deserialisierung
		[Test]
		public void DeCodeNull1_Test()
		{
			Hashtable ht = PropertiesConverter.DeCodePropString(null);
			Assertion.AssertNull(ht);
		}

		//Testen von leeren String bei Deserialisierung
		[Test]
		public void DeCodeEmptyString_Test()
		{
			Hashtable ht = PropertiesConverter.DeCodePropString("");
			Assertion.AssertNull(ht);
		}
	}
}
