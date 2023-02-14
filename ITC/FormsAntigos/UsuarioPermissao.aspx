<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UsuarioPermissao.aspx.vb"  ValidateRequest="False" Inherits="ITC.UsuarioPermissao"%>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body onload="vertical();horizontal();"  bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<script language="javascript">
			function MarcaTodosTipos()
			{
				var trk=0;
				for (var i=0;i<frmCad.elements.length;i++)
					{
						var e = frmCad.elements[i];
						if ((e.name != 'allbox') && (e.type=='checkbox'))
							{
								if(e.disabled==false)
								{
									if(e.name.indexOf('chkTipos')>-1)
									{
										e.checked = true;
									}
								}
							}
					}
			}
			
			function MarcaTodosRegioes()
			{
				var trk=0;
				for (var i=0;i<frmCad.elements.length;i++)
					{
						var e = frmCad.elements[i];
						if ((e.name != 'allbox') && (e.type=='checkbox'))
							{
								if(e.disabled==false)
								{
									if(e.name.indexOf('chkRegiao')>-1)
									{
										e.checked = true;
									}
								}
							}
					}
			}
			
			function MarcaTodosEstados()
			{
				var trk=0;
				for (var i=0;i<frmCad.elements.length;i++)
					{
						var e = frmCad.elements[i];
						if ((e.name != 'allbox') && (e.type=='checkbox'))
							{
								if(e.disabled==false)
								{
									if(e.name.indexOf('chkEstados')>-1)
									{
										e.checked = true;
									}
								}
							}
					}
			}
	
		</script>
		<table height="96%" cellSpacing="0" cellPadding="0" width="100%">
			<tr>
				<td vAlign="top" align="middle">
					<table cellSpacing="0" width="100%" bgColor="#F1F1F1">
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
					<form id="frmCad" action="ObrasDet.aspx" runat="server">
						<img src="imagens/TituloPermissoesUsuario.jpg" border="0">
						<br>
						<asp:table id="tblObrasDet" runat="server" width="96%" BorderWidth="0">
							<asp:TableRow BackColor="#003C6E">
								<asp:TableCell ForeColor="#FFFFFF" HorizontalAlign="Center" ColumnSpan="6" CssClass="f8" Width="30%" Text="DADOS DO USUÁRIO"></asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell Font-Bold="True" CssClass="f8" Width="30%" Text="Código"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left" ColumnSpan="3">
									<asp:Label ID="lblCodigo" Runat="server" Font-Bold="True" CssClass="f8"></asp:Label>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell Font-Bold="True" CssClass="f8" Width="30%" Text="Nome"></asp:TableCell>
								<asp:TableCell HorizontalAlign="Left" ColumnSpan="3">
									<asp:Label ID="lblNomeUsuario" Runat="server" Font-Bold="True" CssClass="f8"></asp:Label>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell ColumnSpan="6">&nbsp;</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell HorizontalAlign="Center">
									<asp:ImageButton CssClass="f8" ID="btnGravarAlteracoes" Runat="server" ImageUrl="Imagens/BotaoSalvarPermissoes.gif" BorderStyle="None"></asp:ImageButton>
								</asp:TableCell>
								<asp:TableCell HorizontalAlign="Center">
									&nbsp;
								</asp:TableCell>
								<asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
									<asp:ImageButton CssClass="f8" ID="btnVoltar" Runat="server" ImageUrl="Imagens/BotaoVoltar.gif" BorderStyle="None"></asp:ImageButton>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell ColumnSpan="6">&nbsp;</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow BackColor="#003C6E">
								<asp:TableCell HorizontalAlign="Center" CssClass="f8" ForeColor="#FFFFFF" Text="PERMISSÕES" ColumnSpan="6"></asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell HorizontalAlign="Center" ColumnSpan="6" Width="96%" VerticalAlign="Top">
									<table width="100%">
										<tr>
											<td width="40%" valign="top">
												<asp:DataGrid CssClass="f8" DataKeyField="IdTipo" id="dtgTipos" runat="server" BorderColor="#999999" BorderStyle=Outset BorderWidth="1" BackColor="White" CellPadding="0" CellSpacing=0 GridLines=None AutoGenerateColumns="False" width="100%">
													<HeaderStyle ForeColor="#ffffff" BackColor="#003C6E"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn HeaderStyle-Width="40%" HeaderText='<B>TIPOS</B> <input type="button" onclick="javascript:MarcaTodosTipos();" class="f8" value="TODOS" id="btnMarcarTodosTipos" NAME="btnMarcarTodosTipos">'>
															<ItemTemplate>
																<asp:CheckBox runat=server Enabled='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMITIDO")=1, true, false)%>' Text='<%# DataBinder.Eval(Container.DataItem, "DESCRICAOTIPO")%>' Checked='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMITIDO")=1, Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "ATIVADO")=1, true, false), false)%>' ID="chkTipos" />
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
												</asp:DataGrid>
											</td>
											<td width="60%" valign="top" colspan=5>
												<table width="100%" bgColor="#003c6e" border="0">
													<tr>
														<td noWrap align="middle"><font class="f8" color="#ffffff"><b>REGIÕES</b></FONT><input type="button" onclick="javascript:MarcaTodosRegioes();" class="f8" value="TODAS" id="btnMarcarTodosRegioes" NAME="btnMarcarTodosRegioes"></td>
													</tr>
												</table>
												<asp:Datalist CssClass="f8" DataKeyField="IdRegiao" id="dtlRegioes" runat="server" BorderColor="#999999" BorderStyle=Outset BorderWidth="1" BackColor="White" CellPadding="0" CellSpacing=0  GridLines="none" RepeatColumns=3 RepeatDirection=Horizontal width="100%">
													<ItemTemplate>
														<asp:CheckBox name=chkRegiao runat=server Enabled='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMITIDO")=1, true, false)%>' Text='<%# DataBinder.Eval(Container.DataItem, "DESCRICAOREGIAO").toUpper().Replace("<BR>", "")%>' Checked='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMITIDO")=1, Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "ATIVADO")=1, true, false), false)%>' ID="chkRegiao" />
													</ItemTemplate>
												</asp:Datalist>
												<BR>
												<table width="100%" bgColor="#003c6e" border="0">
													<tr>
														<td noWrap align="middle"><font class="f8" color="#ffffff"><b>REGIÕES</b><input type="button" onclick="javascript:MarcaTodosEstados();" class="f8" value="TODOS" id="btnMarcarTodosEstados" NAME="btnMarcarTodosEstados"></td>
													</tr>
												</table>
												<asp:Datalist CssClass="f8" DataKeyField="IdEstado" id="dtlEstados" runat="server" BorderColor="#999999" BorderStyle=Outset BorderWidth="1" BackColor="White" CellPadding="0" CellSpacing=0  GridLines="none" RepeatColumns=3 RepeatDirection=Horizontal width="100%">
													<ItemTemplate>
														<asp:CheckBox name=chkEstados runat=server Enabled='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMITIDO")=1, true, false)%>' Text='<%# DataBinder.Eval(Container.DataItem, "DESCRICAOESTADO")%>' Checked='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMITIDO")=1, Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "ATIVADO")=1, true, false), false)%>' ID="chkEstados" />
													</ItemTemplate>
												</asp:Datalist>
											</td>
										</tr>
									</table>
								</asp:TableCell>
							</asp:TableRow>
							<asp:TableRow>
								<asp:TableCell ColumnSpan="6" HorizontalAlign="Center">
									<asp:ImageButton CssClass="f8" ID="btnGravarAlteracoes_Down" Runat="server" ImageUrl="Imagens/BotaoSalvarPermissoes.gif" BorderStyle="None"></asp:ImageButton>
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
