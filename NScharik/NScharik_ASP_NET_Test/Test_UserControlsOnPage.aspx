<%@ Register TagPrefix="uc1" TagName="Address" Src="Controls/Address.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BankInfo" Src="Controls/BankInfo.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="NScharik.AspNet.Controls" Assembly="NScharik" %>
<%@ Page language="c#" Codebehind="Test_UserControlsOnPage.aspx.cs" AutoEventWireup="false" Inherits="NScharik.AspNet.Tests.Test_UserControlsOnPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test_UserControlsOnPage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<h1>Test-Seite mit mehreren UserControls mit FieldValidators</h1>
		<p>Diese Test-Seite testet mehrere benutzerdefinierte Controls mit eingebauten 
			FieldValidator-Objekten
		</p>
		<form id="Form1" method="post" runat="server">
			<p><uc1:bankinfo id="BankInfo1" runat="server"></uc1:bankinfo></p>
			<p>
				<uc1:Address id="Address1" runat="server"></uc1:Address>
			</p>
			<p>
				<cc1:FormValidator id="FormValidator1" runat="server"></cc1:FormValidator>
			</p>
			<p>
				<asp:Button id="Button_Test" runat="server" Text="Test"></asp:Button>
			</p>
		</form>
	</body>
</HTML>
