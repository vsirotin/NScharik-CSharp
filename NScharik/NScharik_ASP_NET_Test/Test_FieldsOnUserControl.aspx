<%@ Register TagPrefix="uc1" TagName="Address" Src="Controls/Address.ascx" %>
<%@ Page language="c#" Codebehind="Test_FieldsOnUserControl.aspx.cs" AutoEventWireup="false" Inherits="NScharik.AspNet.Tests.Test_FieldsOnUserControl" %>
<%@ Register TagPrefix="cc1" Namespace="NScharik.AspNet.Controls" Assembly="NScharik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test_FieldsOnUserControl</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<h1>Test-Seite für einen benutzerdefinierten Control mit FieldValidators</h1>
		<p>Diese Test-Seite testet einen benutzerdefinierten Address-Control mit 
			eingebauten FieldValidator-Objekten.</p>
		<form id="Form1" method="post" runat="server">
			<uc1:Address id="Address1" runat="server"></uc1:Address>
			<p>
				<cc1:FormValidator id="FormValidator1" runat="server"></cc1:FormValidator>
			</p>
			<p>
				<asp:Button id="Button_Test" runat="server" Text="Test!"></asp:Button>
			</p>
		</form>
	</body>
</HTML>
