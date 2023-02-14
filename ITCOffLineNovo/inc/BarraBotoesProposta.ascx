<%@ Control Language="vb" AutoEventWireup="false" Codebehind="BarraBotoesProposta.ascx.vb" Inherits="ITCOffLine.BarraBotoesProposta" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<asp:Table Runat="server" id="Table2" BorderWidth="0" BorderColor="#003C6E" width="100%">
	<asp:TableRow>
		<asp:TableCell>
			<asp:Table Runat="server" id="Table1" BorderWidth="0" BorderColor="#000000" HorizontalAlign="Center" width="100%">
				<asp:TableRow>
					<asp:TableCell HorizontalAlign="Center" ID="TDBotaoIncluir" Wrap="False">
						<asp:Image style="cursor: hand;" ImageUrl='../imagens/BotaoIncluirProposta.gif' id="btnIncluir" Runat="server" BorderStyle="None"></asp:Image>
					</asp:TableCell>
					<asp:TableCell HorizontalAlign="Center" ID="TDBotaoApagar" Wrap="False">
						<asp:Image style="cursor: hand;" ImageUrl='../imagens/BotaoApagarProposta.gif' id="btnExcluir" Runat="server" BorderStyle="None"></asp:Image>
					</asp:TableCell>
					<asp:TableCell HorizontalAlign="Center" ID="TDBotaoAtualizar" Wrap="False">
						<asp:Image style="cursor: hand;" ImageUrl='../imagens/BotaoGravarProposta.gif' id="btnAtualizar" Runat="server" BorderStyle="None"></asp:Image>
					</asp:TableCell>
					<asp:TableCell HorizontalAlign="Center" ID="TDBotaoVoltar" Wrap="False">
						<asp:Image style="cursor: hand;" ImageUrl="../imagens/BotaoVoltar2.gif" id="btnVoltar" Runat="server" BorderStyle="None"></asp:Image>
					</asp:TableCell>
				</asp:TableRow>
			</asp:Table>
		</asp:TableCell>
	</asp:TableRow>
</asp:Table>