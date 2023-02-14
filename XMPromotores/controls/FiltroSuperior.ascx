<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FiltroSuperior.ascx.vb" Inherits="controls_FiltroSuperior" %>
<asp:Repeater runat='server' ID='rptSuperiores'>
    <ItemTemplate>
        <div class='FiltroItem'>
            <%# Eval("Cargo") %><br>
            <asp:DropDownList AutoPostBack='true' runat="server" ID="cboIDUsuario" DataTextField="Usuario" DataValueField="IDUsuario" OnSelectedIndexChanged='cboIDSuperior_SelectedIndexChanged'  />
        </div>
    </ItemTemplate>
</asp:Repeater>
