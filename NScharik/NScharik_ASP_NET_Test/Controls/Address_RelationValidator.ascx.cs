using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using NScharik.Validators;

namespace NScharik.AspNet.Tests.Controls
{

	/// <summary>
	///		Zusammenfassung für Address_RelationValidator.
	/// </summary>
	public class Address_RelationValidator : System.Web.UI.UserControl, IRelationValidator
	{
		protected System.Web.UI.WebControls.TextBox EMail;
		protected System.Web.UI.WebControls.TextBox Telefon;
		protected System.Web.UI.WebControls.TextBox Ort;
		protected System.Web.UI.WebControls.TextBox PLZ;
		protected System.Web.UI.WebControls.TextBox Strasse;
		protected System.Web.UI.WebControls.TextBox Vorname;
		protected System.Web.UI.WebControls.TextBox Name;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Anrede;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Name;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Vorname;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Strasse;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_PLZ;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Ort;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Telefon;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Email;
		protected System.Web.UI.WebControls.TextBox Anrede;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Hier Benutzercode zur Seiteninitialisierung einfügen
		}

		//Implementierung von Interface IRelationValidator
		public string[] ValidateRelations()
		{
			string telefon = Telefon.Text;
			string email = EMail.Text;
			if(StringIsEmpty(telefon) && StringIsEmpty(email))
			{
				return new string[]{"Bei Adresse soll entweder Telefonnummer oder Email gesetzt werden."};
			}
			return null; 
		}

		private bool StringIsEmpty(string s)
		{
			if((s == null) || (s.Length == 0)){return true;}
			return false;
		}

		#region Vom Web Form-Designer generierter Code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: Dieser Aufruf ist für den ASP.NET Web Form-Designer erforderlich.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Erforderliche Methode für die Designerunterstützung
		///		Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
