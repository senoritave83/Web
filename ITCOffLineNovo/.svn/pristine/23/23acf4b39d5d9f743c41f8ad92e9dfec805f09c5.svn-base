<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Obras.aspx.vb" Inherits="ITCOffLine.Obras" ValidateRequest="False" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table width="100%" height="450" cellspacing="0" cellpadding="0">
			<tr>
				<td valign="top" align="middle">
					<table width="100%" bgcolor="#809EB7" cellspacing="0">
						<tr>
							<td width="100%">
								<uc1:Top id="Top1" runat="server"></uc1:Top>
							</td>
						</tr>
						<tr>
							<td width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td valign="top" align="middle">
					<form id="frmCad" runat="server">
						<img src='imagens/TituloCadastroObras.jpg' border=0 width="294" height="40">
						<br>
						<table cellspacing=0 cellpadding=0 width=90% border=1 bordercolor=#003C6E>
							<tr>
								<td>		
									<table cellspacing=0 cellpadding=0 width="100%" border="0" bgcolor="#003C6E">
										<tr>
											<td width="20%" colspan="5" align="middle">
												<asp:label Runat=server CssClass="f8" ForeColor=#FFFFFF ID="Label4"><strong>FILTROS</strong></asp:Label>
											</td>
										</tr>
									</table>
									<table width="100%" border="0" >
										<tr>
											<td align="right" nowrap>
												<asp:label Runat=server CssClass="f8" ID="Label2">Código ITC</asp:Label>
											</td>
											<td align="left" width="100" nowrap colspan=4>
												<asp:TextBox CssClass="f8"  ID="txtCodigoITC" Runat="server" MaxLength="20"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td align="right" nowrap>
												<asp:label Runat=server CssClass="f8" ID="Label3">Razão Social da Empresa</asp:label>
											</td>
											<td align="left" colspan=4 nowrap>
												<asp:TextBox ID="txtRazaoSocial" CssClass="f8" MaxLength="50" Width="100%" Runat="server"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td align="right" nowrap>
												<asp:label Runat=server CssClass="f8" ID="Label1">Data Inicial</asp:Label>
											</td>
											<td align="left" nowrap colspan=4>
												<asp:TextBox onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);" CssClass=f8 ID="txtDataInicio" MaxLength="10" Width="100" Runat="server"></asp:TextBox>
												<asp:label Runat=server CssClass="f8" ID="Label5">Data Final</asp:Label>
												<asp:TextBox onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);"  CssClass=f8 ID="txtDataFim" Width="100" MaxLength="10" Runat="server"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td align="right">
												<asp:label Runat=server CssClass="f8" ID="Label6">Ordenar por:</asp:label>
											</td>
											<td><uc1:ComboBox CssClass="f8" id="cboOrdernar" runat="server"></uc1:ComboBox></td>
											<td align="right">
												<asp:label Runat=server CssClass="f8" ID="Label7">Status:</asp:label>
											</td>
											<td><uc1:ComboBox CssClass="f8" id="cboStatus" runat="server"></uc1:ComboBox></td>
											<td  align="middle" width="20%" nowrap>
												<asp:Button runat="server" ID="btnProcurar" Text="OK" CssClass="Botao" CausesValidation="false" /></asp:ImageButton>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<br>
						<table cellspacing=0 cellpadding=0 width=90% border=1 bordercolor=#003C6E>
							<tr>
								<td>
									<asp:DataGrid ItemStyle-Wrap=False CssClass=f8 id="dtgObras" runat="server" AllowPaging="True" OnPageIndexChanged="doPaging" AllowSorting="True" PageSize="8" BorderColor="#999999" BorderStyle=NotSet BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
									<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
									<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
									<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
									<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
									<Columns>
											<asp:TemplateColumn ItemStyle-Width=25>
												<ItemTemplate>
													<a href="obrasdet.aspx?Codigo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><img src='imagens/bolaverde.gif' border=0 width="25" height="25" ></a>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="CÓDIGO ITC" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True>
												<ItemTemplate>
													<a href="obrasdet.aspx?Codigo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><asp:Label ID="Label8" Runat=server Font-Bold=True><%# DataBinder.Eval(Container.DataItem, "CodigoAntigo")%></asp:Label></a>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderStyle-Font-Bold=True HeaderText="Razão Social da Empresa" HeaderStyle-Width=22%>
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "RAZAOSOCIAL")%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderStyle-Font-Bold=True HeaderText="Nome Fantasia da Empresa" HeaderStyle-Width=22%>
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "FANTASIA")%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderStyle-Font-Bold=True HeaderText="Nome da Obra" HeaderStyle-Width=22%>
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "PROJETO")%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderStyle-Font-Bold=True HeaderText="Endereço" HeaderStyle-Width=22%>
												<ItemTemplate>
													<%# DataBinder.Eval(Container.DataItem, "ENDERECO")%>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="" >
												<ItemTemplate>
													<%# iif(DataBinder.Eval(Container.DataItem, "ApagarRegistro")=1, "<IMG SRC='IMAGENS/CLOCK3.GIF' BORDER='0' ALT='AGUARDANDO ATUALIZAÇÃO'>", IIf(DataBinder.Eval(Container.DataItem, "AtualizarSite")=1, "<IMG SRC='IMAGENS/CLOCK3.GIF' BORDER='0' ALT='AGUARDANDO ATUALIZAÇÃO'>", "&nbsp;"))%>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:DataGrid>
								</td>
							</tr>
						</table>
						<table cellspacing=0 cellpadding=0 width=90% border=0>
							<tr>
								<td>		
								<uc1:BarraBotoes id="Barra" runat="server"></uc1:BarraBotoes>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
		</table>
		<uc1:Rodape Id="Rodape1" runat="server"></uc1:Rodape>
	</body>
</HTML>
