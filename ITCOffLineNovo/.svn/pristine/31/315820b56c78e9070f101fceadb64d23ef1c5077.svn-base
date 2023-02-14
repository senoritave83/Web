<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AssociadosTiposRegioes.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.AssociadosTiposRegioes" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<script language="javascript">
			function CA(IdColuna)
			{
				var trk=0;
				for (var i=0;i<frmCad.chkSelecao.length;i++)
					{
						var e = frmCad.chkSelecao[i];					
						if(e.value.indexOf(IdColuna)>-1)
						{
							e.checked = true;
						}
					}
			}
	
		</script>
		<table height="96%" cellSpacing="0" cellPadding="0" width="100%">
			<tr>
				<td vAlign="top" align="middle">
					<table cellSpacing="0" width="100%" bgColor="#809eb7">
						<tr>
							<td width="100%"><uc1:top id="Top1" runat="server"></uc1:top></td>
						</tr>
						<tr>
							<td width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td vAlign="top" align="middle" width="95%">
					<form id="frmCad" runat="server">
						<img src="imagens/TituloPermissoesUsuario.jpg" border="0" width="443" height="40">
						<br>
						<asp:table id="tblObrasDet" runat="server" width="96%" BorderWidth="0">
							<asp:TableRow>
								<asp:TableCell CssClass="f8" Width="10%" Text="<B>ASSOCIADO</B>"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left" ColumnSpan="3">
									<asp:Label ID="lblRazaoSocial" Runat="server" CssClass="f8"></asp:Label>
								</asp:TableCell>
							</asp:TableRow>
						</asp:table>
						<asp:table id="Table1" runat="server" width="96%" BorderWidth="0">
							<asp:TableRow>
								<asp:TableCell ColumnSpan="6">&nbsp;</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell HorizontalAlign="Center">
									<asp:ImageButton CssClass="f8" ID="btnGravarAlteracoes" Runat="server" ImageUrl="Imagens/botaosalvarassinatura.gif" BorderStyle=None></asp:ImageButton>
								</asp:TableCell>
								<asp:TableCell HorizontalAlign="Center">
									&nbsp;
								</asp:TableCell>
								<asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
									<asp:ImageButton CssClass="f8" ID="btnVoltar" Runat="server"  ImageUrl="Imagens/botaovoltar.gif" BorderStyle=None></asp:ImageButton>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell ColumnSpan="6">&nbsp;</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell HorizontalAlign="Center" ColumnSpan="6" Width="96%" VerticalAlign="Top">
									<asp:DataGrid CssClass="f8" id="dtgTiposRegioes" runat="server" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1" BackColor="White" CellPadding="3" GridLines="Horizontal" AutoGenerateColumns="False" width="100%" EnableViewState="false">
										<HeaderStyle HorizontalAlign="Center" ForeColor="#ffffff" BackColor="#003C6E"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" ></ItemStyle>
										<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="Tipos de Obras">
												<ItemTemplate>
													<%# "<font color='" & iif(DataBinder.Eval(Container.DataItem, "IdTipo")=3, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=4, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=5, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=6, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=7, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=9, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=19, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=22, "#FF0000", iif(DataBinder.Eval(Container.DataItem, "IdTipo")=37, "#FF0000","#00000"))))))))) & "'>" & DataBinder.Eval(Container.DataItem, "DESCRICAOTIPO") & "</font>"%>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:DataGrid>
								</asp:TableCell>
							</asp:TableRow>
						</asp:table><br>
						<br>
					</form>
				</td>
			</tr>
		</table>
		<uc1:rodape id="Rodape1" runat="server"></uc1:rodape>
	</body>
</HTML>
