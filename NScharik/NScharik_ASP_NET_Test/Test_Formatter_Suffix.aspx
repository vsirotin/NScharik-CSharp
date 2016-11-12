<%@ Page language="c#" Codebehind="Test_Formatter_Suffix.aspx.cs" AutoEventWireup="false" Inherits="NScharik.AspNet.Tests.Test_Formatter_Suffix" %>
<%@ Register TagPrefix="cc1" Namespace="NScharik.AspNet.Controls" Assembly="NScharik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test_Formatter_Suffix</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<h1>Test-Seite für Formaters und Suffixes</h1>
		<p>Diese Test-Seite ermöglicht es, verschiedene Formatierungs-Suffixe im 
			Design-Modus festzusetzen und danach während der Laufzeit mit dem Ergebnis zu 
			vergleichen.
		</p>
		<p>
			Der Formatierungs-Suffix kann man als Eigenschaft des Objektes FormValidator 
			festlegen.
		</p>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="1">
				<TR>
					<TD>Erwartete Darstellung mit Validierungsfehler</TD>
					<TD>Ergebniss</TD>
				</TR>
				<TR>
					<TD>
						<asp:TextBox id="TextBox1" runat="server" ReadOnly="True">aa</asp:TextBox>
						<asp:Label id="Label1" runat="server">a] Text ist zu kurz.</asp:Label>
					<TD>
						<asp:TextBox id="TextBox2" runat="server">aa</asp:TextBox>
						<cc1:FieldValidator id="FieldValidator1" runat="server" ValidationClass="NScharik.Validators.BLZValidator"
							IsRequired="True" ControlToValidate="TextBox2"></cc1:FieldValidator></TD>
				</TR>
			</TABLE>
			<p>
				<cc1:FormValidator id="FormValidator1" runat="server" Formatter="NScharik.ValidationErrorFormatters.AlphabeticalFormatter"
					FormatSuffix="]"></cc1:FormValidator>
			</p>
			<p>
				<asp:Button id="Button1" runat="server" Text="Test!"></asp:Button>
			</p>
		</form>
	</body>
</HTML>
