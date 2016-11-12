<%@ Register TagPrefix="cc1" Namespace="NScharik.AspNet.Controls" Assembly="NScharik" %>
<%@ Register TagPrefix="uc1" TagName="Address_RelationValidator" Src="Controls/Address_RelationValidator.ascx" %>
<%@ Page language="c#" Codebehind="Test_FieldsOnUserControlWithGroupValidation.aspx.cs" AutoEventWireup="false" Inherits="NScharik.AspNet.Tests.Test_FieldsOnUserControlWithGroupValidation" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Test_FieldsOnUserControlWithGroupValidation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<h1>Test-Seite für einen benutzerdefinierten Control mit FieldValidators und 
			Gruppen-Validierung</h1>
		<p>Diese Test-Seite testet einen benutzerdefinierten Address-Control mit 
			eingebauten FieldValidator-Objekten. Bei "Adresse" soll entweder eine Telefonnummer 
			oder eine Email-Adresse gesetzt werden. Dieser Zusammenhang wird in Control auch validiert.</p>
		<form id="Form1" method="post" runat="server">
			<uc1:Address_RelationValidator id="Address_RelationValidator1" runat="server"></uc1:Address_RelationValidator>
			<p></p>
			<cc1:FormValidator id="FormValidator1" runat="server"></cc1:FormValidator>
			<P></P>
			<p>
				<asp:Button id="Button_Test" runat="server" Text="Test!"></asp:Button>
			</p>
		</form>
	</body>
</HTML>
