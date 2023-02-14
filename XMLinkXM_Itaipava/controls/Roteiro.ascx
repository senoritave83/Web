<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Roteiro.ascx.vb" Inherits="Controls.Roteiro" %>
        <asp:Panel runat='server' ID='pnlRoteiro'>
		    <asp:Panel runat='server' ID='pnlDiaSemana'>
			    <asp:checkboxlist id="chkDiaSemana" Runat="server" Width="100%" RepeatDirection="Horizontal" RepeatColumns="1">
				    <asp:ListItem Value="1">Domingo</asp:ListItem>
				    <asp:ListItem Value="2">Segunda-Feira</asp:ListItem>
			    </asp:checkboxlist>
		    </asp:Panel>
        </asp:Panel>
