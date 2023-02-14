<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="justificar.aspx.vb" Inherits="formulario_justificar" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Justificar
    <asp:DropDownList runat='server' ID='cboJustificativa' DataTextField='TipoJustificativa' DataValueField='IDTipoJustificativa' />
    <asp:Button runat='server' ID='btnVoltar' Text='Voltar' />
    <asp:Button runat='server' ID='btnGravar' Text='Gravar' />
</asp:Content>

