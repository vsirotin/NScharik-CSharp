<%@ Register TagPrefix="uc1" TagName="BankInfo" Src="Controls/BankInfo.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="NScharik.AspNet.Controls" Assembly="NScharik" %>
<%@ Page language="c#" Codebehind="Test_FieldAndUserControlsOnPage.aspx.cs" AutoEventWireup="false" Inherits="NScharik.AspNet.Tests.Test_FieldAndUserControlsOnPage" %>
<%@ Register TagPrefix="uc1" TagName="Address" Src="Controls/Address.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test_FieldAndUserControlsOnPage</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<h1>Test-Seite mit mehreren UserControls mit FieldValidators und Eingabenfeldern 
			direkt auf der Seite</h1>
		<p>Diese Test-Seite testet mehrere benutzerdefinierte Controls mit eingebauten 
			FieldValidator-Objekten sowie die Eingabefelder mit verknüpften 
			FieldValidator-Objekten, die direkt auf der Seite platziert sind. Dabei werden 
			nicht nur einzelne Felder, sondern auch die Zusammenhänge zwischen 
			unterschiedlichen Feldern validiert.
		</p>
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" runat="server">Anschrift:</asp:Label>
			<p>
				<uc1:Address id="Address1" runat="server"></uc1:Address>
			</p>
			<p>
				<asp:Label id="Label2" runat="server">Bank-Info</asp:Label>
			</p>
			<p>
				<uc1:BankInfo id="BankInfo1" runat="server"></uc1:BankInfo>
			</p>
			<p>
				<asp:Label id="Label3" runat="server">Email:</asp:Label>
			</p>
			<p>
				<asp:TextBox id="TextBox1" runat="server" Width="330px"></asp:TextBox>
				<cc1:FieldValidator id="FieldValidator1" runat="server" IsRequired="True" ValidationClass="NScharik.Validators.EmailValidator"
					ControlToValidate="TextBox1"></cc1:FieldValidator>
			</p>
			<p>
				<cc1:FormValidator id="FormValidator1" runat="server"></cc1:FormValidator>
			</p>
			<p>
				<asp:Button id="Button_Test" runat="server" Text="Test!"></asp:Button>
			</p>
		</form>
	</body>
</HTML>
