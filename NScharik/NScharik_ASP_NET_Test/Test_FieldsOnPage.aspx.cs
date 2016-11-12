using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace NScharik.AspNet.Tests
{
	/// <summary>
	/// Zusammenfassung für Test_FieldsOnPage.
	/// </summary>
	public class Test_FieldsOnPage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox_Bank;
		protected System.Web.UI.WebControls.TextBox TextBox_Bankleitzahl;
		protected System.Web.UI.WebControls.TextBox TextBox_Kontonummer;
		protected System.Web.UI.WebControls.Button Button_TestIt;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator1;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator2;
		protected NScharik.AspNet.Controls.FormValidator FormValidator1;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Bank;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Bankleitzahl;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Kontonummer;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Kontoinhaber;
		protected System.Web.UI.WebControls.TextBox TextBox_Kontoinhaber;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Hier Benutzercode zur Seiteninitialisierung einfügen
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
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Button_TestIt.Click += new System.EventHandler(this.Button_TestIt_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button_TestIt_Click(object sender, System.EventArgs e)
		{
			FormValidator1.Validate();
		}
	}
}
