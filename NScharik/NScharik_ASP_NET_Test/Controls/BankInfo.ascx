<%@ Control Language="c#" AutoEventWireup="false" Codebehind="BankInfo.ascx.cs" Inherits="NScharik.AspNet.Tests.Controls.BankInfo1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="NScharik.AspNet.Controls" Assembly="NScharik" %>
<TABLE id="Table1" cellSpacing="1" cellPadding="1" style="WIDTH: 350px">
	<TR>
		<TD>Bank</TD>
		<TD>
			<asp:TextBox id="TextBox_Bank" runat="server"></asp:TextBox>
			<cc1:FieldValidator id="FieldValidator_Bank" runat="server" ControlToValidate="TextBox_Bank" IsRequired="True"
				ValidationClass="NScharik.Validators.GenericValidator"></cc1:FieldValidator></TD>
	</TR>
	<TR>
		<TD>BLZ</TD>
		<TD>
			<asp:TextBox id="TextBox_BLZ" runat="server"></asp:TextBox>
			<cc1:FieldValidator id="FieldValidator_BLZ" runat="server" ControlToValidate="TextBox_BLZ" ValidationClass="NScharik.Validators.BLZValidator"
				IsRequired="True"></cc1:FieldValidator></TD>
	</TR>
	<TR>
		<TD>Kontonummer</TD>
		<TD>
			<asp:TextBox id="TextBox_Kontonummer" runat="server"></asp:TextBox>
			<cc1:FieldValidator id="FieldValidator_Kontonummer" runat="server" ControlToValidate="TextBox_Kontonummer"
				ValidationClass="NScharik.Validators.KontoNummerValidator" IsRequired="True"></cc1:FieldValidator></TD>
	</TR>
	<TR>
		<TD>Konto-Inhaber</TD>
		<TD>
			<asp:TextBox id="TextBox_KontoInhaber" runat="server"></asp:TextBox>
			<cc1:FieldValidator id="FieldValidator_KontoInhaber" runat="server" ControlToValidate="TextBox_KontoInhaber"
				ValidationClass="NScharik.Validators.NameValidator" IsRequired="True"></cc1:FieldValidator></TD>
	</TR>
</TABLE>
