<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Letras.ascx.vb" Inherits="Controls.Letras" %>
<div class='Letras'>
<asp:Repeater runat=server ID='rptLetras'>
<ItemTemplate>
    <asp:LinkButton runat='server' ID='LinkButton' CommandName='Filtrar' CssClass='<%# IIF(ViewState("CurrentLetter") = Container.dataItem, "SelectedLetra", "Letra") %>' CommandArgument='<%# Container.dataItem %>'><%# Container.dataItem %></asp:LinkButton>
</ItemTemplate>
</asp:Repeater>
</div>
