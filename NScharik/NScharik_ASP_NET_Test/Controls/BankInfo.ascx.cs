namespace NScharik.AspNet.Tests.Controls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Zusammenfassung f�r BankInfo1.
	/// </summary>
	public class BankInfo1 : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.TextBox TextBox_KontoInhaber;
		protected System.Web.UI.WebControls.TextBox TextBox_Kontonummer;
		protected System.Web.UI.WebControls.TextBox TextBox_BLZ;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Bank;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_BLZ;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_Kontonummer;
		protected NScharik.AspNet.Controls.FieldValidator FieldValidator_KontoInhaber;
		protected System.Web.UI.WebControls.TextBox TextBox_Bank;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Hier Benutzercode zur Seiteninitialisierung einf�gen
		}

		#region Vom Web Form-Designer generierter Code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: Dieser Aufruf ist f�r den ASP.NET Web Form-Designer erforderlich.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Erforderliche Methode f�r die Designerunterst�tzung
		///		Der Inhalt der Methode darf nicht mit dem Code-Editor ge�ndert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
