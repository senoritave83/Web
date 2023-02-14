<%@ Control Language="vb" AutoEventWireup="false" Codebehind="BarraBotoes.ascx.vb" Inherits="xmlinkwm.BarraBotoes" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table width="100%" class='fundo'>
	<tr>
		<td width="25%" align="middle">
			<asp:Button CssClass="Botao" ID="btnIncluir" Text="   Novo   " Runat="server" CausesValidation="false" Width="80%"></asp:Button>
		</td>
		<td width="25%" align="middle">
			<asp:Button CssClass="Botao" ID="btnExcluir" Text="   Excluir   " Runat="server" CausesValidation="false" Width="80%"></asp:Button>
		</td>
		<td width="25%" align="middle">
			<asp:Button CssClass="Botao" ID="btnAtualizar" Text="  Salvar  " Runat="server" Width="80%"></asp:Button>
		</td>
		<td width="25%" align="middle">
			<asp:Button CssClass="Botao" ID="btnVoltar" Text="  Voltar  " Runat="server" CausesValidation="false" Width="80%"></asp:Button>
		</td>
	</tr>
</table>
