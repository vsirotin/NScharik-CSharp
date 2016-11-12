using System;

namespace NScharik.Validators
{
	/// <summary>
	/// ASP.NET Seiten und Controls, bei denen die Zusammenhänge zwischen 
	/// Eingabefeldern geprüft werden sollen, implementieren diese Schnittstelle.  
	/// </summary>
	public interface IRelationValidator
	{
		string[] ValidateRelations();
	}
}
