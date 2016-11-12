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

using NScharik.Validators;

namespace NScharik.AspNet.Tests
{
	/// <summary>
	/// Zusammenfassung für Test_FieldsOnPageWithGroupValidation.
	/// </summary>
	public class Test_FieldsOnPageWithGroupValidation : System.Web.UI.Page, IRelationValidator
	{
		private const string TelephoneNumber1 = "1234-456-78";
		private const string TelephoneNumber2 = "0201-999-23451";
		private const string ERROR_TEXT = "Mindestens eine Telefonnummer muss gesetzt werden!";

		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator1;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator2;
		protected NScharik.AspNet.Controls.FormValidator FormValidator1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button Button4;
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.WebControls.Button Button6;
		protected System.Web.UI.WebControls.Button Button1;
	
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
			this.Button6.Click += new System.EventHandler(this.Button6_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = TelephoneNumber1;
			TextBox2.Text = TelephoneNumber2;
			FormValidator1.Validate();
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = TelephoneNumber1;
			TextBox2.Text = "";
			FormValidator1.Validate();
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			TextBox2.Text = TelephoneNumber2;
			FormValidator1.Validate();
		}

		private void Button4_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			TextBox2.Text = "";
			FormValidator1.Validate();
		}


		private void Button5_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "AAA";
			TextBox2.Text = "720SS";
			FormValidator1.Validate();
		}

		private void Button6_Click(object sender, System.EventArgs e)
		{
			FormValidator1.Validate();
		}

		/// <summary>
		/// Implementierung der Interface IRelationValidator
		/// </summary>
		/// <returns></returns>
		public string[] ValidateRelations()
		{
			if(((TextBox1.Text != null) && (TextBox1.Text.Length != 0)) 
				|| ((TextBox2.Text != null) && (TextBox2.Text.Length != 0)))
			{
				return null;
			}
			return new string[]{ERROR_TEXT};
	
		}
	}
}
