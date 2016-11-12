<%@ Page language="c#" Codebehind="Test_MainValidators.aspx.cs" AutoEventWireup="false" Inherits="NScharik.AspNet.Tests.Test_MainValidators" %>
<%@ Register TagPrefix="cc1" Namespace="NScharik.AspNet.Controls" Assembly="NScharik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test_MainValidators</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<h1>Test für Haupt-Validators</h1>
		<p>Diese Test-Seite gibt einen allgemeinen Überblick über die wichtigsten 
			FieldValidator Typen und allgemeine Validierungsfehler</p>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1">
				<TR>
					<TD>Das Feld ist ein Pflichtenfeld.
					</TD>
					<TD><asp:textbox id="TextBox1" runat="server"></asp:textbox><cc1:fieldvalidator id="FieldValidator1" runat="server" ValidationClass="NScharik.Validators.NameValidator"
							ControlToValidate="TextBox1" IsRequired="True"></cc1:fieldvalidator></TD>
				</TR>
				<TR>
					<TD>Der Eingabetext ist zu lang.
					</TD>
					<TD><asp:textbox id="TextBox2" runat="server">aaaaa1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890</asp:textbox><cc1:fieldvalidator id="FieldValidator2" runat="server" ValidationClass="NScharik.Validators.NameValidator"
							ControlToValidate="TextBox2"></cc1:fieldvalidator></TD>
				</TR>
				<TR>
					<TD>Der Zeichensatz ist falsch (kein Name.)
					</TD>
					<TD>
						<P><asp:textbox id="TextBox3" runat="server">Was???</asp:textbox><cc1:fieldvalidator id="FieldValidator3" runat="server" ValidationClass="NScharik.Validators.NameValidator"
								ControlToValidate="TextBox3"></cc1:fieldvalidator></P>
					</TD>
				</TR>
				<TR>
					<TD>Der Zeichensatz ist falsch (kein BLZ.)
					</TD>
					<TD><asp:textbox id="TextBox4" runat="server">DDD-321</asp:textbox><cc1:fieldvalidator id="FieldValidator4" runat="server" ValidationClass="NScharik.Validators.BLZValidator"
							ControlToValidate="TextBox4"></cc1:fieldvalidator></TD>
				</TR>
				<TR>
					<TD>Der Zeichensatz ist falsch (keine Telephonnummer)</TD>
					<TD><asp:textbox id="TextBox5" runat="server">a15</asp:textbox><cc1:fieldvalidator id="FieldValidator5" runat="server" ValidationClass="NScharik.Validators.TelephoneNumberValidator"
							ControlToValidate="TextBox5"></cc1:fieldvalidator></TD>
				</TR>
			</TABLE>
			<cc1:formvalidator id="FormValidator1" runat="server" Formatter="NScharik.ValidationErrorFormatters.AlphabeticalFormatter"></cc1:formvalidator>
			<p>
				<asp:Label id="Label_ValidationResult" runat="server"></asp:Label>
			</p>
			<p>
				<asp:button id="Button_Test" runat="server" Text="Test!"></asp:button>
			</p>
		</form>
	</body>
</HTML>
