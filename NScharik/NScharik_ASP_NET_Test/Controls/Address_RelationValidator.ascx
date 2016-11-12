<%@ Register TagPrefix="cc1" Namespace="NScharik.AspNet.Controls" Assembly="NScharik" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Address_RelationValidator.ascx.cs" Inherits="NScharik.AspNet.Tests.Controls.Address_RelationValidator" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" border="0">
	<TR>
		<TD colSpan="3"></TD>
	</TR>
	<TR>
		<TD>Anrede</TD>
		<TD>
			<asp:TextBox id="Anrede" runat="server"></asp:TextBox>
			<cc1:FieldValidator id="FieldValidator_Anrede" runat="server" ControlToValidate="Anrede" IsRequired="True"
				ValidationClass="NScharik.Validators.GenericValidator"></cc1:FieldValidator></TD>
	</TR>
	<TR>
		<TD>Name</TD>
		<TD>
			<asp:textbox id="Name" Runat="server"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_Name" runat="server" ControlToValidate="Name" IsRequired="True"
				ValidationClass="NScharik.Validators.NameValidator"></cc1:FieldValidator></TD>
	</TR>
	<TR>
		<TD>Vorname</TD>
		<TD>
			<asp:textbox id="Vorname" Runat="server"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_Vorname" runat="server" ControlToValidate="Vorname" ValidationClass="NScharik.Validators.NameValidator"></cc1:FieldValidator></TD>
	</TR>
	<TR>
		<TD>Strasse</TD>
		<TD>
			<asp:textbox id="Strasse" Runat="server"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_Strasse" runat="server" ControlToValidate="Strasse" IsRequired="True"
				ValidationClass="NScharik.Validators.GenericValidator"></cc1:FieldValidator></TD>
	</TR>
	<TR>
		<TD>PLZ</TD>
		<TD>
			<asp:textbox id="PLZ" Runat="server" width="50"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_PLZ" runat="server" ValidationClass="NScharik.Validators.PLZValidator"
				ControlToValidate="PLZ"></cc1:FieldValidator></TD>
	</TR>
	<TR>
		<TD>Ort</TD>
		<TD>
			<asp:textbox id="Ort" Runat="server"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_Ort" runat="server" IsRequired="True" ControlToValidate="Ort"></cc1:FieldValidator></TD>
	</TR>
	<TR>
		<TD>Telefon</TD>
		<TD>
			<asp:textbox id="Telefon" Runat="server"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_Telefon" runat="server" ControlToValidate="Telefon" ValidationClass="NScharik.Validators.TelephoneNumberValidator"></cc1:FieldValidator></TD>
	</TR>
	<TR>
		<TD>E-Mail</TD>
		<TD>
			<asp:textbox id="EMail" Runat="server"></asp:textbox>
			<cc1:FieldValidator id="FieldValidator_Email" runat="server" ControlToValidate="EMail"></cc1:FieldValidator></TD>
	</TR>
</TABLE>
