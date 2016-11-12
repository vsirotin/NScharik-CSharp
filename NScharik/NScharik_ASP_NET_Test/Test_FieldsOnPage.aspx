<%@ Page language="c#" Codebehind="Test_FieldsOnPage.aspx.cs" AutoEventWireup="false" Inherits="NScharik.AspNet.Tests.Test_FieldsOnPage" %>
<%@ Register TagPrefix="AspNetValidator" Namespace="NScharik.AspNet.Controls" Assembly="NScharik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test_FieldsOnPage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<h1>Test-Seite für FieldValidator-Objekte direkt auf der Seite</h1>
		<p>Diese Test-Seite testet mehrere Eingabefelder mit verknüpften 
			FieldValidator-Objekten, die direkt auf der Seite platziert sind</p>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="500" border="0">
				<TR>
					<TD style="WIDTH: 85px">Bank</TD>
					<TD style="WIDTH: 157px"><asp:textbox id="TextBox_Bank" runat="server"></asp:textbox></TD>
					<TD>
						<aspnetvalidator:FieldValidator id="FieldValidator_Bank" runat="server" ControlToValidate="TextBox_Bank" ValidationClass="NScharik.Validators.GenericValidator"
							IsRequired="True"></aspnetvalidator:FieldValidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 85px">Bankleitzahl</TD>
					<TD style="WIDTH: 157px"><asp:textbox id="TextBox_Bankleitzahl" runat="server"></asp:textbox></TD>
					<TD>
						<aspnetvalidator:FieldValidator id="FieldValidator_Bankleitzahl" runat="server" ControlToValidate="TextBox_Bankleitzahl"
							ValidationClass="NScharik.Validators.BLZValidator" IsRequired="True"></aspnetvalidator:FieldValidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 85px">Kontonummer</TD>
					<TD style="WIDTH: 157px"><asp:textbox id="TextBox_Kontonummer" runat="server"></asp:textbox></TD>
					<TD>
						<aspnetvalidator:FieldValidator id="FieldValidator_Kontonummer" runat="server" ControlToValidate="TextBox_Kontonummer"
							IsRequired="True" ValidationClass="NScharik.Validators.KontoNummerValidator"></aspnetvalidator:FieldValidator></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 85px">Kontoinhaber</TD>
					<TD style="WIDTH: 157px"><asp:textbox id="TextBox_Kontoinhaber" runat="server"></asp:textbox></TD>
					<TD>
						<P>
							<aspnetvalidator:FieldValidator id="FieldValidator_Kontoinhaber" runat="server" ControlToValidate="TextBox_Kontoinhaber"
								IsRequired="True" ValidationClass="NScharik.Validators.NameValidator"></aspnetvalidator:FieldValidator></P>
					</TD>
				</TR>
			</TABLE>
			<p>
				<aspnetvalidator:FormValidator id="FormValidator1" runat="server"></aspnetvalidator:FormValidator>
			</p>
			<p>
				<asp:Button id="Button_TestIt" runat="server" Text="Test!"></asp:Button></p>
		</form>
	</body>
</HTML>
