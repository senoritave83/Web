<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Roteiro.ascx.vb" Inherits="Controls.Roteiro" %>
        <asp:Panel runat='server' ID='pnlRoteiro'>
		    <asp:Panel runat='server' ID='pnlDia'>
		        <asp:label Runat="server">Dia:</asp:label><a href='javascript:fncLimparChecks("<%=chkDia.ClientID%>_");' class='LinkLimpar'>Limpar</a><br>
			    <asp:checkboxlist id="chkDia" Runat="server" Width="100%" RepeatDirection="Horizontal" RepeatColumns="5">
				    <asp:ListItem Value="1">1</asp:ListItem>
				    <asp:ListItem Value="2">2</asp:ListItem>
				    <asp:ListItem Value="4">3</asp:ListItem>
				    <asp:ListItem Value="8">4</asp:ListItem>
				    <asp:ListItem Value="16">5</asp:ListItem>
				    <asp:ListItem Value="32">6</asp:ListItem>
				    <asp:ListItem Value="64">7</asp:ListItem>
			    </asp:checkboxlist>
			    
		    </asp:Panel>
		    <asp:Panel runat='server' ID='pnlMes'>
		        <asp:label id="Label3" Runat="server">M&ecirc;s:&nbsp;</asp:label><a href='javascript:fncLimparChecks("<%=chkMes.ClientID%>_");' class='LinkLimpar'>Limpar</a><br>
			    <asp:checkboxlist id="chkMes" Runat="server" Width="100%" RepeatDirection="Horizontal" RepeatColumns="2">
				    <asp:ListItem Value="1">Janeiro</asp:ListItem>
				    <asp:ListItem Value="2">Fevereiro</asp:ListItem>
				    <asp:ListItem Value="4">Março</asp:ListItem>
			    </asp:checkboxlist>
			    
			</asp:Panel> 
		    <asp:Panel runat='server' ID='pnlDiaSemana'>
		        <asp:label id="Label5" CssClass="TextoNegrito" Runat="server">Dia da Semana:&nbsp;</asp:label><a href='javascript:fncLimparChecks("<%=chkDiaSemana.ClientID%>_");' class='LinkLimpar'>Limpar</a><br>
			    <asp:checkboxlist id="chkDiaSemana" Runat="server" Width="100%" RepeatDirection="Horizontal" RepeatColumns="1">
				    <asp:ListItem Value="1">Domingo</asp:ListItem>
				    <asp:ListItem Value="2">Segunda-Feira</asp:ListItem>
			    </asp:checkboxlist>
		    </asp:Panel>
        </asp:Panel>
        <script>
            function fncLimparChecks(vID)
            {
                var elms = document.getElementsByTagName("input");
                for (var i = 0; i < elms.length; i++)
                {
                    var el = elms[i];
                    if (el.id.substring(0, vID.length) == vID)
                    {
                        el.checked = false;
                    }
                }
            }
        </script>
