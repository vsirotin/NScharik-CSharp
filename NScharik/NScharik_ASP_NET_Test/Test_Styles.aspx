<%@ Register TagPrefix="cc1" Namespace="NScharik.AspNet.Controls" Assembly="NScharik" %>
<%@ Page language="c#" Codebehind="Test_Styles.aspx.cs" AutoEventWireup="false" Inherits="NScharik.AspNet.Tests.Test_Styles" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test_Styles</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="styles/test_style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<h1>Test-Seite für Style-Steuerung (BackColor des validierten Feldes )</h1>
		<p class="MsoNormal">Erwartung: Die Hintergrundfarbe des validierten Feldes ändert 
			sich bei fehlerhaften Daten nur dann, wenn sie in HTML nicht als Style gesetzt 
			wurden.
		</p>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="1">
				<TR vAlign="top">
					<TD style="WIDTH: 398px"></TD>
					<TD>
						<p>Erwartete Darstellung ohne Validierungsfehler</p>
					</TD>
					<TD>Erwartete Darstellung mit Validierungsfehler</TD>
					<TD>
						<p>Erwartete Darstellung mit Validierungsfehler programmgesteuerte Style-Änderung</p>
					</TD>
					<TD>Ergebnis</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 398px">Keine Einstellungen in FormValidator
					</TD>
					<TD><asp:textbox id="TextBox7" runat="server" ReadOnly="True">D-45721</asp:textbox></TD>
					<TD><asp:textbox id="TextBox12" runat="server" ReadOnly="True" CssClass="validtion_error_in_field">Das ist Kein BLZ</asp:textbox><asp:label id="Label4" runat="server" CssClass="error_index">1)</asp:label></TD>
					<TD><asp:textbox id="TextBox1" runat="server" ReadOnly="True" CssClass="validtion_error_in_field1">Das ist Kein BLZ</asp:textbox><asp:label id="Label1" runat="server" CssClass="error_index1">1)</asp:label></TD>
					<TD><asp:textbox id="TextBox4" runat="server"></asp:textbox><cc1:fieldvalidator id="FieldValidator1" runat="server" ValidationClass="NScharik.Validators.PLZValidator"
							ControlToValidate="TextBox4"></cc1:fieldvalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 398px">Default-Einstellungen in Design-Modus. BackColor ist 
						direkt in HTML gesetzt.</TD>
					<TD><asp:textbox id="TextBox8" runat="server" ReadOnly="True" BackColor="Lime">D-45721</asp:textbox></TD>
					<TD><asp:textbox id="TextBox11" runat="server" ReadOnly="True" BackColor="Lime">Das ist Kein BLZ</asp:textbox><asp:label id="Label5" runat="server" CssClass="error_index">1)</asp:label></TD>
					<TD><asp:textbox id="TextBox2" runat="server" ReadOnly="True" BackColor="Lime">Das ist Kein BLZ</asp:textbox><asp:label id="Label2" runat="server" CssClass="error_index1">1)</asp:label></TD>
					<TD><asp:textbox id="TextBox5" runat="server" BackColor="Lime"></asp:textbox><cc1:fieldvalidator id="FieldValidator2" runat="server" ValidationClass="NScharik.Validators.PLZValidator"
							ControlToValidate="TextBox5"></cc1:fieldvalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 398px">
						<P class="MsoNormal">Programmgesteuerte Style-Änderung. BackColor ist in Style 
							gesetzt.</P>
					</TD>
					<TD><asp:textbox id="TextBox9" runat="server" ReadOnly="True" CssClass="test_style">D-45721</asp:textbox></TD>
					<TD><asp:textbox id="TextBox10" runat="server" ReadOnly="True" CssClass="validtion_error_in_field">Das ist Kein BLZ</asp:textbox><asp:label id="Label6" runat="server" CssClass="error_index">1)</asp:label></TD>
					<TD><asp:textbox id="TextBox3" runat="server" ReadOnly="True" CssClass="validtion_error_in_field1">Das ist Kein BLZ</asp:textbox><asp:label id="Label3" runat="server" CssClass="error_index1">1)</asp:label></TD>
					<TD><asp:textbox id="TextBox6" runat="server" CssClass="test_style"></asp:textbox><cc1:fieldvalidator id="FieldValidator3" runat="server" ValidationClass="NScharik.Validators.PLZValidator"
							ControlToValidate="TextBox6"></cc1:fieldvalidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 398px"></TD>
					<TD>
						<asp:LinkButton id="LinkButton1" runat="server">Fehlerfreie Daten setzen</asp:LinkButton></TD>
					<TD>
						<asp:LinkButton id="LinkButton2" runat="server">Fehlerhafte Daten setzen</asp:LinkButton></TD>
					<TD>
						<asp:LinkButton id="LinkButton3" runat="server">Fehlerhafte Daten setzen und Feld-Style ändern</asp:LinkButton></TD>
					<TD></TD>
				</TR>
			</TABLE>
			<p><cc1:formvalidator id="FormValidator1" runat="server" CssClassForValidatedField="validtion_error_in_field"
					CssClassForIndex="error_index"></cc1:formvalidator></p>
		</form>
	</body>
</HTML>
