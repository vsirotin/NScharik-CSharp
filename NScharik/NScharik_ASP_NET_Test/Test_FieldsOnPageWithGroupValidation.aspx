<%@ Page language="c#" Codebehind="Test_FieldsOnPageWithGroupValidation.aspx.cs" AutoEventWireup="false" Inherits="NScharik.AspNet.Tests.Test_FieldsOnPageWithGroupValidation" %>
<%@ Register TagPrefix="cc1" Namespace="NScharik.AspNet.Controls" Assembly="NScharik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test_FieldsOnPageWithGroupValidation</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<h1>Relation-Test</h1>
		<p>
			Dieser Test testet Situationen, in denen die Felder voneinander abhängig sind. 
			In unserem Fall muss mindestens eine Telefonnummer gesetzt werden.
		</p>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" border="1">
				<TR>
					<TD style="WIDTH: 197px">Telefonnnummer-Büro</TD>
					<TD>
						<asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
						<cc1:FieldValidator id="FieldValidator1" runat="server" ControlToValidate="TextBox1" ValidationClass="NScharik.Validators.TelephoneNumberValidator"></cc1:FieldValidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 197px">Telefonnummer privat</TD>
					<TD>
						<asp:TextBox id="TextBox2" runat="server"></asp:TextBox>
						<cc1:FieldValidator id="FieldValidator2" runat="server" ControlToValidate="TextBox2" ValidationClass="NScharik.Validators.TelephoneNumberValidator"></cc1:FieldValidator></TD>
				</TR>
			</TABLE>
			<p>
				<asp:Button id="Button1" runat="server" Text="Beide Telefonnnummer setzen"></asp:Button>
				<asp:Button id="Button2" runat="server" Text="Telefonnnummer Büro setzen"></asp:Button>
				<asp:Button id="Button3" runat="server" Text="Telefonnnummer privat setzen"></asp:Button>
				<asp:Button id="Button4" runat="server" Text="Keine Telefonnnummer setzen"></asp:Button>
				<asp:Button id="Button5" runat="server" Text="Fehlerhafte Daten setzen"></asp:Button>
				<asp:Button id="Button6" runat="server" Text="Manuell gesetzte Daten prüfen"></asp:Button>
			</p>
			<p>
				<cc1:FormValidator id="FormValidator1" runat="server"></cc1:FormValidator>
			</p>
		</form>
	</body>
</HTML>
