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
	/// Zusammenfassung für Test_Styles.
	/// </summary>
	public class Test_Styles : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.TextBox TextBox5;
		protected System.Web.UI.WebControls.TextBox TextBox6;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator1;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox TextBox7;
		protected System.Web.UI.WebControls.TextBox TextBox8;
		protected System.Web.UI.WebControls.TextBox TextBox9;
		protected NScharik.AspNet.Controls.FormValidator FormValidator1;
		protected System.Web.UI.WebControls.TextBox TextBox10;
		protected System.Web.UI.WebControls.TextBox TextBox11;
		protected System.Web.UI.WebControls.TextBox TextBox12;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.LinkButton LinkButton2;
		protected System.Web.UI.WebControls.LinkButton LinkButton3;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator3;
	
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
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.LinkButton2.Click += new System.EventHandler(this.LinkButton2_Click);
			this.LinkButton3.Click += new System.EventHandler(this.LinkButton3_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			string inputText = "D-45721";
			TextBox4.Text = inputText;
			TextBox5.Text = inputText;
			TextBox6.Text = inputText;
			
			FormValidator1.Validate();
		}

		private void LinkButton2_Click(object sender, System.EventArgs e)
		{
			string inputText = "Das ist Kein BLZ";
			TextBox4.Text = inputText;
			TextBox5.Text = inputText;
			TextBox6.Text = inputText;
			
			FormValidator1.Validate();
		
		}

		private void LinkButton3_Click(object sender, System.EventArgs e)
		{
			string inputText = "Das ist Kein BLZ";
			TextBox4.Text = inputText;
			TextBox5.Text = inputText;
			TextBox6.Text = inputText;

			FormValidator1.CssClassForValidatedField = "validtion_error_in_field1";
			FormValidator1.CssClassForIndex ="error_index1";
			
			FormValidator1.Validate();
		}
	}
}
