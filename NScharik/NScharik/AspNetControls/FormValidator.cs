using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms.Design;
using System.Data;
using System.Collections.Specialized;
using System.Reflection;

using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using NScharik.Utils;
using NScharik.ValidationErrorFormatters;
using NScharik.Validators;

namespace NScharik.AspNet.Controls
{
	/// <summary>
	/// Die Klasse führt die Validierung der Eingabefelder mit Hilfe von FieldValidator-Objekten durch. 
	/// Die Klasse dient u.a. der Darstellung der indexierten Fehlermeldungsliste als eine zweispaltige Tabelle.
	/// Deswegen ist er vom ASP.NET Grid-Control abgeleitet und erbt u.a. meistens Eigenschaften von Geid-Control. 
	/// Im Design-Modus können Sie natürlich diese Eigenschaften festlegen. 
	/// </summary>
	public class FormValidator : System.Web.UI.WebControls.DataGrid
	{
		private const string INDEX = "INDEX";
		private const string ERROR_TXT = "ERROR_TXT";
	
		//Typ des Formatter-Algorithmus
		private string formatterClass = "NScharik.ValidationErrorFormatters.NumericalFormatter";
		
		//Formatter-Klasse. Default Value ist am Anfang an gesetzt.
		ValidationErrorFormatter myFormatter = new NumericalFormatter();
		private string formatSuffix;

		public FormValidator()
		{
			formatSuffix = myFormatter.Suffix;
		}

		/// <summary>
		/// Führt die Validierung der Eingabefelder mit Hilfe von FieldValidator-Objekten durch
		/// </summary>
		/// <returns>Liefert true, wenn Validierungs-Fehler gefunden worden</returns>
		public bool Validate()
		{

			//Schritt 1: Suchen die FieldValidator-Controls, die direkt auf der Seite platziert sind
			ArrayList fieldValidators = FindFieldValidationOnPage();

			if((fieldValidators == null) || (fieldValidators.Count == 0)){return false;} 
			
			//Schritt 2: Von jedem Control bekommen die Fehlermeldung
			StringCollection errors1 = ValidateFieldValidationOnPage(fieldValidators);
			
			//Schritt 3. Wenn die Seite oder ihre Controls die Relation-Validierung unterstützt dann führen wir die durch. 
			StringCollection errors2 = ValidateRelations();
			string[] errors = MergeCollections(errors1, errors2);
			if((errors == null) || (errors.Length == 0)){
				//Wiederherstellung von Default-Field-Styles
				ResetDefaultStyles(fieldValidators);
				return false;
			}

			//Schritt 4: Ordnen die Indexen den Fehlermeldungen zu
			ValidationError[] valerrs = Amalgamate(errors);

			//Schritt 5: Zeigen den Fehlermeldungs-Indexen in Controls an
			ShowErrorsIndexesInFieldValidators(fieldValidators, valerrs);
			//Schritt 6:  Zeigen den Fehlermeldungs-Indexen und Texten im Grid
			ShowErrorsInGrid(valerrs);

			return true;
		}

		/// <summary>
		/// Sucht die FieldValidator Objekte
		/// </summary>
		/// <returns>Liste von gefundenen FieldValidator Objekten</returns>
		protected ArrayList FindFieldValidationOnPage()
		{
			ArrayList lst = new ArrayList();
			HtmlForm form = (HtmlForm)base.Parent;
			foreach(object obj in form.Controls)
			{

				if(obj is FieldValidator)
				{
					lst.Add(obj);
				}
				else if(obj is System.Web.UI.UserControl)
				{
					System.Web.UI.UserControl ctrl = (System.Web.UI.UserControl)obj;
					FindFieldValidationOnUserControlRecursive(ctrl, ref lst);
				}
			}
			return lst;
		}
		
		/// <summary>
		/// Sucht die FieldValidator Objekte rekursiv
		/// </summary>
		/// <param name="ctrl">Untersuchten Control</param>
		/// <param name="lst">Liste von vorhandenen/gefundenen FieldValidator Objekten</param>
		protected void FindFieldValidationOnUserControlRecursive(System.Web.UI.UserControl ctrl, ref ArrayList lst)
		{
			foreach(object obj in ctrl.Controls)
			{
				if(obj is FieldValidator)
				{
					lst.Add(obj);
				}
				else if(obj is System.Web.UI.UserControl)
				{
					System.Web.UI.UserControl ctrlr = (System.Web.UI.UserControl)obj;
					FindFieldValidationOnUserControlRecursive(ctrlr, ref lst);
				}
			}
		}
		
		/// <summary>
		/// Führt die Validierung von Zusammenhängen unter validierten Objekten durch.
		/// </summary>
		/// <returns>Liste von Fehlermeldungen</returns>
		protected StringCollection ValidateRelations()
		{
			StringCollection lst = new StringCollection();
			System.Web.UI.Page page = base.Page;
			if(page is IRelationValidator)
			{
				IRelationValidator rv = (IRelationValidator)page;
				string[] ss = rv.ValidateRelations();
				if((ss != null) && (ss.Length > 0))
				{
					lst.AddRange(ss);
				}
			}
			foreach(object obj in page.Controls)
			{
				if(obj is System.Web.UI.HtmlControls.HtmlForm)
				{
					System.Web.UI.HtmlControls.HtmlForm form = (System.Web.UI.HtmlControls.HtmlForm)obj;
					foreach(object ctrl in form.Controls)
					{
						if(ctrl is System.Web.UI.UserControl)
						{
							System.Web.UI.UserControl userControl = (System.Web.UI.UserControl)ctrl;
							ValidateRelationsRecursive(userControl, ref lst);
						}
					}
				}
			}
			
			return lst;
		}
		
		/// <summary>
		/// Führt die Validierung von Zusammenhängen unter validierten Objekten durch (Rekursive).
		/// </summary>
		/// <returns>Liste von Fehlermeldungen</returns>
		private void ValidateRelationsRecursive(System.Web.UI.UserControl userControl, ref StringCollection lst)
		{
			if(userControl is IRelationValidator)
			{
				IRelationValidator rv = (IRelationValidator)userControl;
				string[] ss = rv.ValidateRelations();
				if((ss != null) && (ss.Length > 0))
				{
					lst.AddRange(ss);
				}
			}
			foreach(object ctrl in userControl.Controls)
			{
				if(ctrl is System.Web.UI.UserControl)
				{
					System.Web.UI.UserControl userCtrl = (System.Web.UI.UserControl)ctrl;
					ValidateRelationsRecursive(userCtrl, ref lst);
				}
			}
		}

		/// <summary>
		/// Meged zwei Kollektionen
		/// </summary>
		/// <param name="c1">Erste String-Kollektion</param>
		/// <param name="c2">Zweie String-Kollektion</param>
		/// <returns>Liste-Ergebnisse</returns>
		private string[] MergeCollections(StringCollection c1, StringCollection c2)
		{
			if((c1 != null) && (c1.Count > 0))
			{
				if((c2 != null) && (c2.Count > 0))
				{
					string[] ss2 = new string[c2.Count];
					c2.CopyTo(ss2, 0);
					c1.AddRange(ss2);
				}
				string[] res = new string[c1.Count];
				c1.CopyTo(res, 0);
				return res;
			}
			else if((c2 != null) && (c2.Count > 0))
			{
				string[] res = new string[c2.Count];
				c2.CopyTo(res, 0);
				return res;
			}
			return null;
		}

		/// <summary>
		/// Validiert nacheinander die Eingabe-Felder durch den Aufruf von jeweiligen FieldValidator Objekten.   
		/// </summary>
		/// <param name="fieldValidators">Liste von FieldValidator Objekten</param>
		/// <returns>Liste von Fehlermeldungen</returns>
		protected StringCollection ValidateFieldValidationOnPage(ArrayList fieldValidators)
		{
			StringCollection col = new StringCollection();
			foreach(FieldValidator fv in fieldValidators)
			{
				string err = fv.Validate();
				if((err != null) && (err.Length != 0))
				{
					//Keine Duplikaten werden geliefert
					if(col.IndexOf(err) < 0)
					{
						col.Add(err);
					}
				}
			}
			return col;
		}

		/// <summary>
		/// Erweitert pure Fehlermeldungen mit den Suffixen. 
		/// </summary>
		/// <param name="errors"></param>
		/// <returns></returns>
		protected ValidationError[] Amalgamate(string[] errors)
		{
			if(errors == null){return null;}

			ValidationError[] res = new ValidationError[errors.Length];
			myFormatter.Suffix = formatSuffix;
			for(uint i = 0; i < errors.Length; i++)
			{
				string err = errors[i];
				res[i] = new ValidationError(i + 1, err, myFormatter);
			}
			return res;
		}
		
		/// <summary>
		/// Ruft Field-Validator Objekte nacheinander und ordnet den Fehlermeldungs-Indexen zu.
		/// </summary>
		/// <param name="FieldValidators">Liste von FieldValidator Objekts</param>
		/// <param name="ValidationErrors">Liste von Fehlermeldungen</param>
		protected void ShowErrorsIndexesInFieldValidators(ArrayList FieldValidators, ValidationError[] ValidationErrors)
		{
			foreach(FieldValidator fv in FieldValidators)
			{
				fv.ShowErrorsIndex(ValidationErrors, cssClassForValidatedField, cssClassForIndex);
			}
		}

		/// <summary>
		/// Setz die defult Styles von validaten Fields zurück
		/// </summary>
		/// <param name="fieldValidators">Liste von validierten Fields</param>
		protected void ResetDefaultStyles(ArrayList fieldValidators)
		{
			foreach(FieldValidator fv in fieldValidators)
			{
				fv.ResetDefaultStyle();
			}
		}

		/// <summary>
		/// Zeigt die Fehlermeldungs-Liste
		/// </summary>
		/// <param name="valerrs"></param>
		protected void ShowErrorsInGrid(ValidationError[] valerrs)
		{
			if(valerrs == null)
			{
				base.DataSource = null;
				base.DataBind();
				return;
			}
			base.ShowHeader = false;
			DataTable dt = new DataTable();
			
			dt.Columns.Add(new DataColumn(INDEX, typeof(string)));
			dt.Columns.Add(new DataColumn(ERROR_TXT, typeof(string)));	
		
			for(int i = 0; i < valerrs.Length; i++)
			{
				ValidationError ve = valerrs[i];
				DataRow dr = dt.NewRow();
				dr[INDEX] = ve.IndexFormatted;
				dr[ERROR_TXT] = ve.ErrorText;
				
				dt.Rows.Add(dr);
			}

					
			DataView dv = new DataView(dt);
			base.DataSource = dv;
			base.DataBind();

		}
	
		[Category("Validation"),
		EditorAttribute("NScharik.AspNet.Controls.FormatterEditor", 
			typeof(System.Drawing.Design.UITypeEditor)),
		Description("Art der Fehlermeldungs-Index-Formatierung.")
		]
		public string Formatter
		{
			get{return formatterClass;}
			set
			{
				formatterClass = value;
				SetFormatterClass(formatterClass);
			}
		}

		private string cssClassForValidatedField;
		[
		Category("Validation"),
		Description("Css-Style für validierten Feld bei entdecktem Validierungsfehler.")
		]
		public string CssClassForValidatedField 
		{
			get{return cssClassForValidatedField;}
			set{cssClassForValidatedField  = value;}
		}

		private string cssClassForIndex;
		[
		Category("Validation"),
		Description("Css-Style für Fehlermeldungsindex.")
		]
		public string CssClassForIndex 
		{
			get{return cssClassForIndex;}
			set{cssClassForIndex  = value;}
		}

		[
		Category("Validation"),
		Description("Formatierungs-Suffix, der nach Fehlermeldungs-Index steht.")
		]
		public string FormatSuffix 
		{
			get{return formatSuffix ;}
			set{formatSuffix  = value;}
		}

		[
		Category("Data"),
		Browsable(false)
		]
		public override string DataKeyField
		{
			get{return base.DataKeyField;}
			set{base.DataKeyField = value;}
		}



		[
		Category("Data"),
		Browsable(false)
		]
		public override object DataSource
		{
			get{return base.DataSource;}
			set{base.DataSource = value;}
		}

		/// <summary>
		/// Legt eine neue Instanz der Validierungs-Klasse an. 
		/// </summary>
		protected void SetFormatterClass(string FormatterClass)
		{
			System.Runtime.Remoting.ObjectHandle oh = System.Activator.CreateInstance(null, FormatterClass);
			myFormatter = (ValidationErrorFormatter)oh.Unwrap();
		}

	}


	#region FormatterEditor
    /// <summary>
    /// Klasse für Bearbeitung Formatter-Attribute in Design-Modus
    /// </summary>
	public class FormatterEditor : System.Drawing.Design.UITypeEditor 
	{
		IWindowsFormsEditorService   editorService;
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			if( context != null ) 
			{
				return UITypeEditorEditStyle.DropDown;
			}
			return base.GetEditStyle(context);
		}
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) 
		{
			if( (context != null) && (provider != null) ) 
			{
				editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
				if( editorService != null ) 
				{
					System.Windows.Forms.ListBox listBox = new System.Windows.Forms.ListBox();
					FormValidator instance = (FormValidator)context.Instance;
					SetValues(ref listBox);
					listBox.Click += new System.EventHandler(this.Formatter_Click);

					editorService.DropDownControl(listBox);
					int ind = listBox.SelectedIndex;
					string res = instance.Formatter;
					if(ind >= 0)
					{
						res = (string)listBox.Items[ind];
					}
					return res;
				}
			}
			return base.EditValue(context, provider, value);
		}

		
		private void SetValues(ref System.Windows.Forms.ListBox aListBox)
		{
			Type tb = Type.GetType("NScharik.ValidationErrorFormatters.ValidationErrorFormatter");
			Assembly mainAssembly = Assembly.GetExecutingAssembly();
			Module[] mods = mainAssembly.GetModules();
			foreach(Module m in mods)
			{
				Type[] types = m.GetTypes();
				foreach(Type t in types)
				{
					string name = t.FullName;
					if(t.IsSubclassOf(tb))
					{
						aListBox.Items.Add(name);
					}
				}
			}
			aListBox.Sorted = true;

		}

		private void Formatter_Click(object sender, System.EventArgs e) 
		{
			editorService.CloseDropDown();
		}
	}

	#endregion

}
