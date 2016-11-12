using System;
using System.Diagnostics;

namespace NScharik.NUnitTests
{
	/// <summary>
	/// Zusammenfassung für NUnitTrace.
	/// </summary>
	public class NUnitTrace
	{
		static NUnitTrace()
		{
			Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
			Trace.AutoFlush = true;
			Trace.WriteLine("Start NUnitTrace ");
		}

		public static void WriteLine(string s)
		{
			Trace.WriteLine(s);
		}
	}
}
