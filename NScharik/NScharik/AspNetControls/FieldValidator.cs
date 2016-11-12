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
using System.Reflection;

using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Data;
using NScharik.Validators;
using NScharik.Utils;

using System.Web.UI.HtmlControls;


namespace NScharik.AspNet.Controls
{
	[
	ToolboxBitmap(typeof(FieldValidator),"images/FieldValidator.ico"),
	Designer(typeof(FieldValidatorDesigner))
	]

	/// <summary>
	/// GUI-Klasse für Einbindung von konkreten Validators für ASP.NET – Controls (Input-Field).
	/// </summary>
	public class FieldValidator : System.Web.UI.WebControls.Label
	{
		private const string PARENT_VOT_VALID = "FieldValidator can be used only on page or UserControl!";
		private const string DEFAULT_CSS_CLASS_OF_VALIDATED_FIELD = "DefCssClassOfValField";
		//Typ des Validierungs-Object
		private FieldValidatorBase myValidator; 
		
		//ID des validierten Steuerelementes.
		private string vlidatedControlID;
		
		//Typ des Validierungs-Algorithmus
		private string validationClass = "NScharik.Validators.GenericValidator"; 
		
		//Definiert, ob das Feld ein Pflichtenfeld ist. 
		private bool isRequired = false;

		/// <summary>
		/// Führt den Validierungs-Vorgang für verknüpften Eingabenfeld 
		/// mit Hilfe des zugeordneten Validator durch. 
		/// </summary>
		/// <returns></returns>
		public string Validate()
		{
			if(myValidator == null){return null;}

			myValidator.IsRequired = isRequired;
			System.Web.UI.WebControls.TextBox textBoxToValidate = FindValidatedControl();
			if(textBoxToValidate == null)
			{
				throw new FieldValidatorException("VlidatedControl is not set or not exist!");
			}
			myValidator.Value = textBoxToValidate.Text;
			return myValidator.Validate();
		}

		/// <summary>
		/// Sucht den Controll, der validiert werden soll (In Parent-Element). 
		/// </summary>
		/// <returns>TextBox, der validiert werden soll</returns>
		private System.Web.UI.WebControls.TextBox FindValidatedControl()
		{
			if(this.Parent is System.Web.UI.HtmlControls.HtmlForm)
			{
				return FindValidatedControl((System.Web.UI.HtmlControls.HtmlForm)this.Parent);
			}
			else if(this.Parent is System.Web.UI.UserControl)
			{
				return FindValidatedControl((System.Web.UI.UserControl)this.Parent);
			}
			throw new FieldValidatorException(PARENT_VOT_VALID);
		}
		
		/// <summary>
		/// Sucht den Controll, der validiert werden soll (In Form). 
		/// </summary>
		/// <param name="form">Form, wo man den Control sucht</param>
		/// <returns>TextBox, der validiert werden soll</returns>
		private System.Web.UI.WebControls.TextBox FindValidatedControl(System.Web.UI.HtmlControls.HtmlForm form)
		{
			foreach(object obj in form.Controls)
			{
				if(obj is System.Web.UI.WebControls.TextBox)
				{
					System.Web.UI.WebControls.TextBox tb = (System.Web.UI.WebControls.TextBox)obj;
					string controlID = tb.ID;
					if(controlID.Equals(vlidatedControlID))
					{
						return tb;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Sucht den Controll, der validiert werden soll (In UserControl). 
		/// </summary>
		/// <param name="ctrl">UserControl, wo man den verknüpften Control sucht</param>
		/// <returns>TextBox, der validiert werden soll</returns>
		private System.Web.UI.WebControls.TextBox FindValidatedControl(System.Web.UI.UserControl ctrl)
		{
			foreach(object obj in ctrl.Controls)
			{
				if(obj is System.Web.UI.WebControls.TextBox)
				{
					System.Web.UI.WebControls.TextBox tb = (System.Web.UI.WebControls.TextBox)obj;
					string controlID = tb.ID;
					if(controlID.Equals(vlidatedControlID))
					{
						return tb;
					}
				}
			}
			return null;
		}

		[Category("Validation"),
		EditorAttribute("NScharik.AspNet.Controls.ControlToValidateEditor", 
			typeof(System.Drawing.Design.UITypeEditor)),
		Description("ID des validierten Steuerelementes.")
		]
		public string ControlToValidate
		{
			get{return vlidatedControlID;}
			set{vlidatedControlID = value;}
		}

		[
		Category("Validation"),
		EditorAttribute("NScharik.AspNet.Controls.ValidationClassEditor", 
			typeof(System.Drawing.Design.UITypeEditor)),
		Description("Typ des Validierungs-Algorithmus.")
		]
		public string ValidationClass
		{
			get{return validationClass;}
			set
			{
				validationClass = value;
				SetValidationClass(validationClass);
				this.ErrorMessages = "";
			}
		}

		[
		Category("Validation"),
		Description("Definiert, ob das Feld ein Pflichtenfeld ist.")
		]
		public bool IsRequired
		{
			get{return isRequired;}
			set{isRequired = value;}
		}

		[
		Category("Appearance"),
		Browsable(false)
		]
		public override string Text
		{
			get{return base.Text;}
			set{base.Text = value;}
		}


		string validationParams;
		[
		Category("Validation"),
		EditorAttribute("NScharik.AspNet.Controls.ValidationParamsEditor", 
			typeof(System.Drawing.Design.UITypeEditor)),
		Description("Parameter von Validierungs-Algorithmus.")
		]
		public string ValidationParams
		{
			get
			{
				if((validationParams == null) || (validationParams.Length == 0))
				{
					Hashtable ht = myValidator.ValidationParams;
					validationParams = PropertiesConverter.CodePropString(ht);

				}
				return validationParams;
				
			}
			set
			{
				validationParams = value;
				myValidator.ValidationParams = PropertiesConverter.DeCodePropString(validationParams);
			}
		}


		string errorMessages;
		[
		Category("Validation"),
		EditorAttribute("NScharik.AspNet.Controls.ErrorMessagesEditor", 
			typeof(System.Drawing.Design.UITypeEditor)),
		Description("Fehlermeldungen des Validierungs-Algorithmus.")
		]
		public string ErrorMessages
		{
			get
			{
				if((errorMessages == null) || (errorMessages.Length == 0))
				{
					Hashtable ht = myValidator.ErrorMessages;
					errorMessages = PropertiesConverter.CodePropString(ht);

				}
				return errorMessages;
				
			}
			set
			{
				errorMessages = value;
				myValidator.ErrorMessages = PropertiesConverter.DeCodePropString(errorMessages);
			}
		}

		/// <summary>
		/// Legt eine neue Instanz der Validierungs-Klasse an. 
		/// </summary>
		protected void SetValidationClass(string ValidationClass)
		{
			System.Runtime.Remoting.ObjectHandle oh = System.Activator.CreateInstance(null, ValidationClass);
			myValidator = (FieldValidatorBase)oh.Unwrap();
		}

		/// <summary>
		/// Setzt default Style von validierten Field zurück
		/// </summary>
		public void ResetDefaultStyle()
		{
			System.Web.UI.WebControls.TextBox tb = this.FindValidatedControl();
			if(tb == null)
			{
				Debug.WriteLine("!!!Warning: TextBox for Validator ist nicht gesetzt!");
				return;
			}
			if(tb.Attributes[DEFAULT_CSS_CLASS_OF_VALIDATED_FIELD] != null)
			{
				ResetDefaultStyle(tb);
			}
		}

		/// <summary>
		/// Sucht in den gesamten Fehlermeldungsliste „eigenen“ Fehler und wenn ihn findet, 
		/// zeigt den Index von Fehler-Text. 
		/// </summary>
		/// <param name="ValidationErrors">Gesamte Fehlermeldungsliste</param>
		public void ShowErrorsIndex(ValidationError[] ValidationErrors, string cssClassForValidatedField, string cssClassForIndex)
		{
			//Suchen Validated Control für diesen Validator
			System.Web.UI.WebControls.TextBox tb = this.FindValidatedControl();
			if(tb == null)
			{
				Debug.WriteLine("!!!Warning: TextBox for Validator ist nicht gesetzt!");
				return;
			}
			if(tb.Attributes[DEFAULT_CSS_CLASS_OF_VALIDATED_FIELD] == null)
			{
				tb.Attributes[DEFAULT_CSS_CLASS_OF_VALIDATED_FIELD] = tb.CssClass;
			}

			if(myValidator == null)
			{
				Debug.WriteLine("!!!Warning: myValidator == null! FieldValidator ID=" + this.ID);
				return;
			}

			string errorText = myValidator.ErrorText;
			if((errorText == null) || (errorText.Length == 0))
			{
				base.Text = "";
				ResetDefaultStyle(tb);
				return;
			}

			if(ValidationErrors != null)
			{
				foreach(ValidationError ve in ValidationErrors)
				{
					if(ve.ErrorText.Equals(errorText))
					{
						string inf = ve.IndexFormatted;
						if(cssClassForIndex != null)
						{
							base.CssClass = cssClassForIndex;
						}
						base.Text = inf;
						if(cssClassForValidatedField != null)
						{
							tb.CssClass = cssClassForValidatedField;
						}
						return;
					}
				}
			}

			//Sonst - Wiederherstellung von Default Style
			ResetDefaultStyle(tb);
		}

		private void ResetDefaultStyle(System.Web.UI.WebControls.TextBox tb)
		{
			tb.CssClass = tb.Attributes[DEFAULT_CSS_CLASS_OF_VALIDATED_FIELD]; 
		}


	}

	#region ValidationClassEditor
    
	/// <summary>
	/// Klasse für Bearbeitung ValidationClass-Attribute in Design-Modus
	/// </summary>
	public class ValidationClassEditor : System.Drawing.Design.UITypeEditor
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
					FieldValidator instance = (FieldValidator)context.Instance;
					System.Windows.Forms.ListBox listBox = new System.Windows.Forms.ListBox();
					SetValues(ref listBox);
					listBox.Click += new System.EventHandler(this.ValidationClassEditor_Click);

					editorService.DropDownControl(listBox);
					int ind = listBox.SelectedIndex;
					string res = instance.ValidationClass;
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
			Type tb = Type.GetType("NScharik.Validators.FieldValidatorBase");
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

		private void ValidationClassEditor_Click(object sender, System.EventArgs e) 
		{
			editorService.CloseDropDown();
		}
	}

	#endregion


	#region ControlToValidateEditor
	/// <summary>
	/// Klasse für Bearbeitung ControlToValidate-Attribute in Design-Modus
	/// </summary>
	public class ControlToValidateEditor : System.Drawing.Design.UITypeEditor 
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
					FieldValidator instance = (FieldValidator)context.Instance;
					System.Windows.Forms.ListBox listBox = new System.Windows.Forms.ListBox();
					FindControlToValidateID(ref listBox, instance);
					listBox.Click += new System.EventHandler(this.ControlToValidate_Click);

					editorService.DropDownControl(listBox);
					int ind = listBox.SelectedIndex;
					string res = "";
					if(ind >= 0)
					{
						res = (string)listBox.Items[ind];
					}
					return res;
				}
			}
			return base.EditValue(context, provider, value);
		}

		private void FindControlToValidateID(ref System.Windows.Forms.ListBox aListBox, FieldValidator instance)
		{

			System.Web.UI.Page page = (System.Web.UI.Page)instance.Page;
			if((page.Controls.Count == 1) && (page.Controls[0] is System.Web.UI.UserControl))
			{	//Der Fall, wenn FielValidator auf einen UserControl platziert. 
				//In diesem Fall erzeugt Visual Studio in Design Mode eine Pseudo-Seite.
				System.Web.UI.UserControl ctrl = (System.Web.UI.UserControl)page.Controls[0];
				FindControlToValidateID(ctrl, ref aListBox);
				return;
			}

			foreach(object obj in page.Controls)
			{

				if(obj is System.Web.UI.WebControls.TextBox)
				{
					System.Web.UI.WebControls.TextBox tb = (System.Web.UI.WebControls.TextBox)obj;
					string id = tb.ID;
					aListBox.Items.Add(id);
				}
			}
			aListBox.Sorted = true;
		}

		private void FindControlToValidateID(System.Web.UI.UserControl ctrl, ref System.Windows.Forms.ListBox aListBox)
		{
			foreach(object obj in ctrl.Controls)
			{

				if(obj is System.Web.UI.WebControls.TextBox)
				{
					System.Web.UI.WebControls.TextBox tb = (System.Web.UI.WebControls.TextBox)obj;
					string id = tb.ID;
					aListBox.Items.Add(id);
				}
			}
			aListBox.Sorted = true;
		}

		private void ControlToValidate_Click(object sender, System.EventArgs e) 
		{
			editorService.CloseDropDown();
		}
	}

	#endregion

	
	#region ValidationParamsEditor
    
	/// <summary>
	/// Klasse für Bearbeitung ValidationParams-Liste in Design-Modus
	/// </summary>
	public class ValidationParamsEditor : System.ComponentModel.Design.CollectionEditor 
	{

		public ValidationParamsEditor(Type t) : base(t)
		{
		}

		IWindowsFormsEditorService   editorService;
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			if( context != null ) 
			{
				return UITypeEditorEditStyle.Modal;
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
					FieldValidator instance = (FieldValidator)context.Instance;
					System.Windows.Forms.DataGrid Grid1 = new System.Windows.Forms.DataGrid();
					KeyValueEditorDlg dlg = new KeyValueEditorDlg();
					dlg.KeyValuesAsString = instance.ValidationParams;
					dlg.Text = "Validierungs-Parametr";
					System.Windows.Forms.DialogResult dialogResult = editorService.ShowDialog(dlg);
					string res = instance.ErrorMessages;
					if(dialogResult == System.Windows.Forms.DialogResult.OK)
					{
						res = dlg.KeyValuesAsString;
					}
					return res;
				}
			}
			return base.EditValue(context, provider, value);
		}



	}

	#endregion

	#region ErrorMessagesEditor
	/// <summary>
	/// Klasse für Bearbeitung ErrorMessages-Liste in Design-Modus
	/// </summary>
	public class ErrorMessagesEditor : System.ComponentModel.Design.CollectionEditor 
	{

		public ErrorMessagesEditor(Type t) : base(t)
		{
		}

		IWindowsFormsEditorService   editorService;
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			if( context != null ) 
			{
				return UITypeEditorEditStyle.Modal;
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
					FieldValidator instance = (FieldValidator)context.Instance;
					System.Windows.Forms.DataGrid Grid1 = new System.Windows.Forms.DataGrid();
					KeyValueEditorDlg dlg = new KeyValueEditorDlg();
					dlg.KeyValuesAsString = instance.ErrorMessages;
					dlg.Text = "Validierungs-Fehlermeldungen";
					System.Windows.Forms.DialogResult dialogResult = editorService.ShowDialog(dlg);
					string res = instance.ErrorMessages;
					if(dialogResult == System.Windows.Forms.DialogResult.OK)
					{
						res = dlg.KeyValuesAsString;
					}
					return res;
				}
			}
			return base.EditValue(context, provider, value);
		}
	}
		#endregion

	#region FieldValidatorDesigner

	/// <summary>
	/// Klasse für Bearbeitung FieldValidator-Attribute in Design-Modus
	/// </summary>
	public class FieldValidatorDesigner : System.Web.UI.Design.TextControlDesigner 
	{
	}

	#endregion

}




