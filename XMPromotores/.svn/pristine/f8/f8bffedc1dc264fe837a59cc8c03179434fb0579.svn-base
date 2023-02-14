<%@ Control Language="VB" AutoEventWireup="false" CodeFile="pergunta.ascx.vb" Inherits="control_pergunta" %>
<%@ Register src="ImageRotator.ascx" tagname="ImageRotator" tagprefix="uc1" %>
<asp:Panel runat='server' id='divControl' class='ControlPergunta'>
    <asp:PlaceHolder runat='server' ID='plhCaption'><asp:Label runat='server' ID='lblPergunta' /><br /></asp:PlaceHolder>
    <asp:RadioButtonList runat='server' ID='radLista' DataTextField='Resposta'></asp:RadioButtonList>
    <asp:CheckBoxList runat='server' ID='chkLista' DataTextField='Resposta' DataValueField='Unica'></asp:CheckBoxList>
    <asp:DropDownList runat='server' ID='cboLista' DataTextField='Resposta' DataValueField='Resposta' CssClass="Select"></asp:DropDownList>
    <asp:TextBox runat='server' ID='txtResposta' CssClass="formulario" Width="200px" />
    <asp:HiddenField runat='server' ID='hidUnica' />
    <uc1:ImageRotator ID="imgRotator" runat="server" />
    <asp:Label runat='server' ID='lblMensagem' ForeColor="red" EnableViewState="false" />
</asp:Panel>