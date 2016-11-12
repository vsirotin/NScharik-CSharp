using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using NScharik.Utils;

namespace NScharik.AspNet.Controls
{
	/// <summary>
	/// Die Klasse für Bearbeitung Benutzer-Eingaben über Key/Value Listen 
	/// in einem Dialog in Design-Modus. 
	/// </summary>
	public class KeyValueEditorDlg : System.Windows.Forms.Form
	{
		private const string TAB_KEY = "Eigenschaft";
		private const string TAB_VALUE = "Wert";
		private const string MAIN_TABLE = "MAIN_TABLE";

		private string resultAsString = "AA";

		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button buttonSet;
		private DataSet myDataSet;

		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button_Abbrechen;


		public KeyValueEditorDlg()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

		}

		public string KeyValuesAsString
		{
			get
			{
				DataTable table = myDataSet.Tables[MAIN_TABLE];
				int count = table.Rows.Count;
				Hashtable ht = new Hashtable();
				for(int i = 0; i < count; i++)
				{
					DataRow r = table.Rows[i];
					string key = (string)r[TAB_KEY];
					string val = (string)r[TAB_VALUE];
					ht.Add(key, val); 
				}
				string res = PropertiesConverter.CodePropString(ht);
				return res;
			}
			set
			{
				Hashtable mapKeyToValue = PropertiesConverter.DeCodePropString(value);
				SetDataGrid(mapKeyToValue);
				dataGrid1.SetDataBinding(myDataSet, MAIN_TABLE);
			}
			
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.buttonSet = new System.Windows.Forms.Button();
			this.button_Abbrechen = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(24, 16);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(440, 200);
			this.dataGrid1.TabIndex = 0;
			// 
			// buttonSet
			// 
			this.buttonSet.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonSet.Location = new System.Drawing.Point(24, 232);
			this.buttonSet.Name = "buttonSet";
			this.buttonSet.TabIndex = 1;
			this.buttonSet.Text = "Setzen";
			this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
			// 
			// button_Abbrechen
			// 
			this.button_Abbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Abbrechen.Location = new System.Drawing.Point(120, 232);
			this.button_Abbrechen.Name = "button_Abbrechen";
			this.button_Abbrechen.TabIndex = 2;
			this.button_Abbrechen.Text = "Abbrechen";
			// 
			// KeyValueEditorDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 273);
			this.Controls.Add(this.button_Abbrechen);
			this.Controls.Add(this.buttonSet);
			this.Controls.Add(this.dataGrid1);
			this.Name = "KeyValueEditorDlg";
			this.Text = "Validierungs-Parameter";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private void buttonSet_Click(object sender, System.EventArgs e)
		{
			DataTable table = myDataSet.Tables[MAIN_TABLE];
			DataColumn cKey = table.Columns[TAB_KEY];
			DataColumn cValue = table.Columns[TAB_VALUE];
			int len = cKey.MaxLength;
			resultAsString = "" + len;

		}

		public string ResultAsString
		{
			get{return resultAsString;}
		}



		private void SetUp()
		{
			// Create a DataSet with two tables and one relation.
			MakeDataSet();
			/* Bind the DataGrid to the DataSet. The dataMember
			specifies that the Customers table should be displayed.*/
			dataGrid1.SetDataBinding(myDataSet, "Customers");
		}

		private void SetDataGrid(Hashtable mapKeyToValue)
		{
			myDataSet = new DataSet("myDataSet");
      
			// Create two DataTables.
			DataTable table = new DataTable(MAIN_TABLE);


			DataColumn cKey = new DataColumn(TAB_KEY);
			cKey.ReadOnly = true;
			DataColumn cValue = new DataColumn(TAB_VALUE);
			table.Columns.Add(cKey);
			table.Columns.Add(cValue);
			
			// Add the tables to the DataSet.
			myDataSet.Tables.Add(table);
			
			/* Populates the tables. For each customer and order, 
			creates two DataRow variables. */

			IDictionaryEnumerator e = mapKeyToValue.GetEnumerator();
			while(e.MoveNext())
			{
				string key = (string)e.Key;
				string val = (string)e.Value;
				DataRow r = table.NewRow();
				r[TAB_KEY] = key;
				r[TAB_VALUE] = val;
				table.Rows.Add(r);

			}
			
		}


		// Create a DataSet with two tables and populate it.
		private void MakeDataSet()
		{
			// Create a DataSet.
			myDataSet = new DataSet("myDataSet");
      
			// Create two DataTables.
			DataTable tCust = new DataTable("Customers");
			DataTable tOrders = new DataTable("Orders");

			// Create two columns, and add them to the first table.
			DataColumn cCustID = new DataColumn("CustID", typeof(int));
			DataColumn cCustName = new DataColumn("CustName");
			DataColumn cCurrent = new DataColumn("Current", typeof(bool));
			tCust.Columns.Add(cCustID);
			tCust.Columns.Add(cCustName);
			tCust.Columns.Add(cCurrent);

			// Create three columns, and add them to the second table.
			DataColumn cID = 
				new DataColumn("CustID", typeof(int));
			DataColumn cOrderDate = 
				new DataColumn("orderDate",typeof(DateTime));
			DataColumn cOrderAmount = 
				new DataColumn("OrderAmount", typeof(decimal));
			tOrders.Columns.Add(cOrderAmount);
			tOrders.Columns.Add(cID);
			tOrders.Columns.Add(cOrderDate);

			// Add the tables to the DataSet.
			myDataSet.Tables.Add(tCust);
			myDataSet.Tables.Add(tOrders);

			// Create a DataRelation, and add it to the DataSet.
			DataRelation dr = new DataRelation
				("custToOrders", cCustID , cID);
			myDataSet.Relations.Add(dr);
   
			/* Populates the tables. For each customer and order, 
			creates two DataRow variables. */
			DataRow newRow1;
			DataRow newRow2;

			// Create three customers in the Customers Table.
			for(int i = 1; i < 4; i++)
			{
				newRow1 = tCust.NewRow();
				newRow1["custID"] = i;
				// Add the row to the Customers table.
				tCust.Rows.Add(newRow1);
			}
			// Give each customer a distinct name.
			tCust.Rows[0]["custName"] = "Customer1";
			tCust.Rows[1]["custName"] = "Customer2";
			tCust.Rows[2]["custName"] = "Customer3";

			// Give the Current column a value.
			tCust.Rows[0]["Current"] = true;
			tCust.Rows[1]["Current"] = true;
			tCust.Rows[2]["Current"] = false;

			// For each customer, create five rows in the Orders table.
			for(int i = 1; i < 4; i++)
			{
				for(int j = 1; j < 6; j++)
				{
					newRow2 = tOrders.NewRow();
					newRow2["CustID"]= i;
					newRow2["orderDate"]= new DateTime(2001, i, j * 2);
					newRow2["OrderAmount"] = i * 10 + j  * .1;
					// Add the row to the Orders table.
					tOrders.Rows.Add(newRow2);
				}
			}
		}


	}
}
