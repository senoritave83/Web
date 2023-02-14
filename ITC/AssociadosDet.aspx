<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AssociadosDet.aspx.vb"  ValidateRequest="False" Inherits="ITC.AssociadosDet"%>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
  <HEAD>
		<!-- #include file='inc/header.aspx' -->
  </HEAD>
	<body onload="vertical();horizontal();" >
		<form id="frmDica" runat="server">
			<div id="Tudo">

				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Associados</h3><br >
				<table cellspacing="0" cellpadding="0" width="100%">
					<tr>
						<td>
							<table id="tblAssociadosDet" bgcolor="#efefef" runat="server" width="100%" CellPadding="1" CellSpacing="2">
                         <TBODY>
								<tr>
									<td colspan=4>
										<h3>Dados Gerais</h3>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Código</td>
									<td colspan="3">
										<asp:Label ID="lblCodigo" Runat="server" CssClass="f8"></asp:Label>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Status</td>
									<td>
										<uc1:ComboBox CssClass="f8" id="cboIdStatus" runat="server"></uc1:ComboBox>
									</td>
									<td align="right" CssClass="f8" Width="30%" Wrap="False">Vendedor(a)</td>
									<td align="left">
										<asp:Label CssClass="f8"  id="lblVendedor" runat="server"></asp:Label>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Fantasia</td>
									<td colspan="3" Wrap="False" align="left">
										<asp:TextBox runat="server" CssClass="f8" Width="300" ID="txtFantasia" MaxLength="255" ReadOnly=True></asp:TextBox>
										<asp:label runat="server" CssClass="f8" ID="label">Módulo</asp:label>&nbsp;
										<asp:TextBox runat="server" CssClass="f8" ID="txtModulo" MaxLength="30" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Razão Social</td>
									<td colspan="3">
										<asp:TextBox CssClass="f8" runat="server" Width="99%" ID="txtRazaoSocial" MaxLength="255" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Tipo Pessoa</td>
									<td>
										<uc1:ComboBox CssClass="f8" id="cboTipoPessoa" name="cboTipoPessoa" runat="server"></uc1:ComboBox>
									</td>
									<td CssClass="f8">Data da Ativação</td>
									<td align="left">
										<asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" CssClass="f8" runat="server" Width="100" ID="txtDataAtivacao" MaxLength="10" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Ramo</td>
									<td>
										<uc1:ComboBox CssClass="f8" id="cboIdRamo" runat="server"></uc1:ComboBox>
									</td>
									<td CssClass="f8" Width="30%">Atividade</td>
									<td>
										<uc1:ComboBox CssClass="f8" id="cboIdAtividade" runat="server"></uc1:ComboBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8">Forma de Pagamento</td>
									<td>
										<uc1:ComboBox CssClass="f8" id="cboIdFormaPagamento" runat="server"></uc1:ComboBox>
									</td>
									<td CssClass="f8" Width="30%">Posição</td>
									<td>
										<uc1:ComboBox CssClass="f8" id="cboIdPosicao" runat="server"></uc1:ComboBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">CPF / CNPJ</td>
									<td>
										<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtCNPJ" onKeyDown="FormataCNPJ(this, event);"
											MaxLength="18" ReadOnly=True></asp:TextBox>
									</td>
									<td CssClass="f8" Width="30%">IE / RG</td>
									<td>
										<asp:TextBox CssClass="f8" runat="server" Width="182px" ID="txtInscricaoEstadual" MaxLength="50" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%" Wrap="False">Nº de Funcionários</td>
									<td>
										<asp:TextBox CssClass="f8" runat="server" Width="200px" ID="txtNumFunc" MaxLength="20" ReadOnly=True></asp:TextBox>
									</td>
									<td CssClass="f8" Width="30%" Wrap="False">Primeiro Contrato</td>
									<td colspan="3">
										<asp:TextBox CssClass="f8" runat="server" Width="100px" ID="txtPrimeiroContrato" MaxLength="10" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8">Web Site</td>
									<td colspan="3">
										<asp:TextBox CssClass="f8" runat="server" Width="96%" ID="txtWebSite" MaxLength="150" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">E-Mail</td>
									<td colspan="3">
										<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtEmail" MaxLength="35" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Endereço Skype</td>
									<td colspan="3">
										<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtSkype" MaxLength="35" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Início Plano</td>
									<td>
										<asp:TextBox onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);" CssClass="f8"
											runat="server" Width="100" ID="txtDataInicioPlano" MaxLength="10" ReadOnly=True></asp:TextBox>
									</td>
									<td CssClass="f8" Width="30%">Fim Plano</td>
									<td>
										<asp:TextBox onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);" CssClass="f8" runat="server" Width="100" ID="txtDataFimPlano" MaxLength="10" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Prazo do Plano</td>
									<td colspan="3">
										<asp:Label CssClass="f8" Runat="server" ID="lblObservacoes" ForeColor="#FF0000"></asp:Label>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Observações</td>
									<td colspan="3">
										<asp:TextBox ID="txtObservacoes" MaxLength="1000" TextMode="MultiLine" Runat="server" CssClass="f8"
											rows="2" Width="96%" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Imagem do Guia</td>
									<td colspan="3">
										<asp:TextBox ID="txtImagemGuia" MaxLength="100" Runat="server" CssClass="f8" rows="2" Width="96%" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td colspan="4">
										<h3>Endereço</h3>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Endereço</td>
									<td colspan="3">
										<asp:TextBox CssClass="f8" runat="server" Width="96%" ID="txtEndereco" MaxLength="255" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Bairro</td>
									<td>
										<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtComplemento" MaxLength="255" ReadOnly=True></asp:TextBox>
									</td>
									<td CssClass="f8" Width="30%">CEP</td>
									<td>
										<asp:TextBox CssClass="f8" runat="server" Width="182px" ID="txtCEP" onKeyDown="javascript:FormataCEP(this, event);"
											MaxLength="9" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Cidade</td>
									<td>
										<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtCidade" MaxLength="255" ReadOnly=True></asp:TextBox>
									</td>
									<td CssClass="f8" Width="30%">UF</td>
									<td>
										<uc1:ComboBox CssClass="f8" id="cboIdEstado" runat="server"></uc1:ComboBox>
									</td>
								</tr>
								<tr>
									<td colspan="4">
										<h3>Endereço de Cobrança</h3>
									</td>
								</tr>
								<tr>
									<td CssClass="f8">Endereço de Cobrança</td>
									<td colspan="3">
										<asp:TextBox runat="server" CssClass="f8" Width="96%" ID="txtEnderecoCobranca" MaxLength="255" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Bairro</td>
									<td>
										<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtComplementoCobranca" MaxLength="255" ReadOnly=True></asp:TextBox>
									</td>
									<td CssClass="f8" Width="30%">CEP</td>
									<td>
										<asp:TextBox CssClass="f8" runat="server" Width="182px" onKeyDown="javascript:FormataCEP(this, event);"
											ID="txtCEPCobranca" MaxLength="9" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Cidade</td>
									<td>
										<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtCidadeCobranca" MaxLength="255" ReadOnly=True></asp:TextBox>
									</td>
									<td CssClass="f8" Width="30%">UF</td>
									<td>
										<uc1:ComboBox CssClass="f8" id="cboIdEstadoCobranca" runat="server"></uc1:ComboBox>
									</td>
								</tr>
								<tr>
									<td colspan="4">
										<h3>Endereço de Faturamento</h3>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Endereço de Faturamento</td>
									<td colspan="3">
										<asp:TextBox CssClass="f8" runat="server" Width="96%" ID="txtEnderecoFaturamento" MaxLength="255" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Bairro</td>
									<td>
										<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtComplementoFaturamento" MaxLength="255" ReadOnly=True></asp:TextBox>
									</td>
									<td CssClass="f8" Width="30%">CEP</td>
									<td>
										<asp:TextBox CssClass="f8" runat="server" Width="182px" onKeyDown="javascript:FormataCEP(this, event);"
											ID="txtCEPFaturamento" MaxLength="9" ReadOnly=True></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Width="30%">Cidade</td>
									<td>
										<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtCidadeFaturamento" MaxLength="255" ReadOnly=True></asp:TextBox>
									</td>
									<td CssClass="f8" Width="30%">UF</td>
									<td>
										<uc1:ComboBox CssClass="f8" id="cboIdEstadoFaturamento" runat="server"></uc1:ComboBox>
									</td>
								</tr>
								<tr>
									<td align="center" CssClass="f8" colspan="4">
									<h3>Cadastro de Associados</h3>
									</td>
								</tr>
								<tr>
									<td CssClass="f8" Wrap="False">Descrição dos Produtos</td>
									<td colspan="3" Wrap="False" valign="middle" align="left">
										<asp:TextBox CssClass="f8" ID="txtProduto" Runat="server" TextMode="MultiLine" Rows="3" Width="98%" ReadOnly="True"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										&nbsp;
									</td>
								</tr>
								<tr>
									<td width="75%" colspan=2>
										&nbsp;
									</td>
									<td align=right colspan=2>
										<p align=right><asp:Button CausesValidation=False Runat="server" ID="btnAssinatura" Text="Dados de Assinatura"></asp:Button>&nbsp;
										<asp:Button CausesValidation=False Runat="server" ID="btnProdutos" Text="Visualizar Produtos"></asp:Button></p>
									</td>
								</tr></ASP:TABLE>
						</td>
					</tr>
				</table>
				<br>
				<table cellspacing="0" cellpadding="0" width="100%">
					<tr>
						<td>
							<table cellspacing="0" cellpadding="0" width="100%">
								<tr>
									<td width="100%" align="center"><h3>Contatos</h3></td>
								</tr>
							</table>
							<asp:DataGrid id="dtgContatos" CssClass="f8" runat="server" AllowPaging="False" AllowSorting="False" backcolor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
								<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF Font-Bold=True></HeaderStyle>
								<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<Columns>
									<asp:TemplateColumn HeaderText='Nome'>
										<ItemTemplate>
											<a href='contatoassociados.aspx?idcontato=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDContato"))%>&idassociado=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDAssociado"))%>'>
												<%# DataBinder.Eval(Container.DataItem, "NomeContato")%>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField='DescricaoCargo' HeaderText="Cargo" />
									<asp:BoundColumn DataField='Funcao' HeaderText="Funcão" />
									<asp:BoundColumn DataField='CTelefone' HeaderText="Telefone" />
									<asp:BoundColumn DataField='CFax' HeaderText="Fax" />
                                    <asp:BoundColumn DataField='CCelular' HeaderText="Celular" />
									<asp:BoundColumn DataField='EMail' HeaderText="E-Mail" />
                                    <asp:BoundColumn DataField='Skype' HeaderText="Skype" />
								</Columns>
							</asp:DataGrid>
						</td>
					</tr>
				</table>
				<br class=clear >
				<table cellspacing="0" cellpadding="0" width="100%">
					<tr>
						<td>
							<table cellspacing="0" cellpadding="0" width="100%">
								<tr>
									<td width="100%" align="center"><h3>Usuários Cadastrados</h3></td>
								</tr>
							</table>
							<asp:DataGrid id="dtgUsuarios" CssClass="f8" runat="server" AllowPaging="False" AllowSorting="False" backcolor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
								<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF Font-Bold=True></HeaderStyle>
								<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<Columns>
									<asp:TemplateColumn HeaderText='Nome'>
										<ItemTemplate>
											<a href='usuariosdet.aspx?codigo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "USU_USUARIO_INT_PK"))%>&idassociado=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "EMP_IDEMPRESA_INT_FK"))%>'>
												<%# DataBinder.Eval(Container.DataItem, "USU_USUARIO_CHR")%>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField='USU_LOGIN_CHR' HeaderText="Login" />
									<asp:BoundColumn DataField='DescricaoCargo' HeaderText="Cargo" />
									<asp:BoundColumn DataField='Tipo' HeaderText="Tipo de Usuário" />
									<asp:TemplateColumn HeaderText='Situação'>
										<ItemTemplate>
											<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "USU_INDATIVO_IND") = 1, "Ativo", "Inativo")%>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid>
						</td>
					</tr>
				</table>
				<br class=clear >
				<table align=center>
					<tr>
						<td width="100%" align=center>
							<input type=button value=Voltar onclick='location.href="associados.aspx"'>		
						</td>
					</tr>
				</table>
				<uc1:Rodape id="Rodapé" runat="server"></uc1:Rodape>
		</form></TD></TR></TBODY>
  <DIV></DIV>
  <DIV></DIV></DIV>
	</body>
</HTML>
