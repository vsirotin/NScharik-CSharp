<%@ Register TagPrefix="cc1" Namespace="NScharik.AspNet.Controls" Assembly="NScharik" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Address.ascx.cs" Inherits="NScharik.AspNet.Validation.Controls.Address" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellSpacing="0" cellPadding="0" width="300" border="0">
	<tr>
		<td colSpan="3"></td>
	</tr>
	<tr>
		<td>Anrede</td>
		<TD>
			<asp:TextBox id="Anrede" runat="server"></asp:TextBox>
			<cc1:FieldValidator id="FieldValidator_Anrede" runat="server" ControlToValidate="Anrede" IsRequired="True"
				ValidationClass="NScharik.Validators.GenericValidator"></cc1:FieldValidator></TD>
	</tr>
	<TR>
		<td>Name</td>
		<td><asp:textbox id="Name" Runat="server"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_Name" runat="server" ControlToValidate="Name" IsRequired="True"
				ValidationClass="NScharik.Validators.NameValidator"></cc1:FieldValidator></td>
	</TR>
	<tr>
		<td>Vorname</td>
		<td><asp:textbox id="Vorname" Runat="server"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_Vorname" runat="server" ControlToValidate="Vorname" ValidationClass="NScharik.Validators.NameValidator"></cc1:FieldValidator></td>
	</tr>
	<tr>
		<td>Strasse</td>
		<td><asp:textbox id="Strasse" Runat="server"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_Strasse" runat="server" ControlToValidate="Strasse" IsRequired="True"
				ValidationClass="NScharik.Validators.GenericValidator"></cc1:FieldValidator></td>
	</tr>
	<tr>
		<td>PLZ</td>
		<td>
			<asp:textbox id="PLZ" Runat="server" width="50"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_PLZ" runat="server" ValidationClass="NScharik.Validators.PLZValidator"
				ControlToValidate="PLZ"></cc1:FieldValidator>
		</td>
	</tr>
	<tr>
		<td>Ort</td>
		<td>
			<asp:textbox id="Ort" Runat="server"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_Ort" runat="server" IsRequired="True" ControlToValidate="Ort"></cc1:FieldValidator>
		</td>
	</tr>
	<tr>
		<TD>Telefon</TD>
		<TD>
			<asp:textbox id="Telefon" Runat="server"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_Telefon" runat="server" ControlToValidate="Telefon" ValidationClass="NScharik.Validators.TelephoneNumberValidator"></cc1:FieldValidator></TD>
	</tr>
	<TR>
		<TD>E-Mail</TD>
		<TD>
			<asp:textbox id="EMail" Runat="server"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_Email" runat="server" ControlToValidate="EMail" ValidationClass="NScharik.Validators.EmailValidator"></cc1:FieldValidator></TD>
	</TR>
</table>
