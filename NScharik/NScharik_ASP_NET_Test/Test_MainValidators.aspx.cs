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
	/// Zusammenfassung für Test_MainValidators.
	/// </summary>
	public class Test_MainValidators : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button_Test;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.TextBox TextBox5;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator2;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator3;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator4;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator5;
		protected NScharik.AspNet.Controls.FormValidator FormValidator1;
		protected System.Web.UI.WebControls.Label Label_ValidationResult;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator1;
	
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
			this.Button_Test.Click += new System.EventHandler(this.Button_Test_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button_Test_Click(object sender, System.EventArgs e)
		{
			bool validationResult =FormValidator1.Validate();
			Label_ValidationResult.Text = "Validierungs-Resultat: " + validationResult;
		}
	}
}
