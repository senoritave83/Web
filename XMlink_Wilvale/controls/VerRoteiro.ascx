<%@ Control Language="VB" AutoEventWireup="false" CodeFile="VerRoteiro.ascx.vb" Inherits="Controls.VerRoteiro" %>
<asp:Panel runat='server' ID='pnlRoteiro'>
    <asp:Label runat='server' ID='lblHeaderDias' Text='Dias:'/> <asp:Label runat='server' ID='lblDias'> 12,13,14...</asp:Label><br />
    <asp:Label runat='server' ID='lblHeaderMes' Text='M&ecirc;ses:'/> <asp:Label runat='server' ID='lblMeses'>Janeiro, Fevereiro</asp:Label> <br />
    <asp:Label runat='server' ID='lblHeaderDiasSemana' Text='Dias da Semana:' /> <asp:Label runat='server' ID='lblDiasSemana'>Quinta e Sexta</asp:Label> <br />
</asp:Panel>