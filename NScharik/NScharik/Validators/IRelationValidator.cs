using System;

namespace NScharik.Validators
{
	/// <summary>
	/// ASP.NET Seiten und Controls, bei denen die Zusammenh�nge zwischen 
	/// Eingabefeldern gepr�ft werden sollen, implementieren diese Schnittstelle.  
	/// </summary>
	public interface IRelationValidator
	{
		string[] ValidateRelations();
	}
}
