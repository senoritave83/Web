<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpresasDet.aspx.vb"  ValidateRequest="False" Inherits="ITC.EmpresasDet"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<!-- #include file='inc/header.aspx' -->
	</HEAD>
	<body onload="vertical();horizontal();">
		<form id="frmDica" runat="server">
			<div id="Tudo">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Empresas</h3>
				<br>
				<table id="tblEmpresasDet" runat="server" bgColor="#efefef" CellSpacing="0" CellPadding="2"
					width="100%">
					<tr>
						<td colspan="4" class="f10" Width="30%" align="center"><h3>Dados Cadastrais</h3>
						</td>
					</tr>
					<tr>
						<td>&nbsp;</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Código</td>
						<td colspan="3">
							<asp:Label ID="lblCodigo" Runat="server" CssClass="f8"></asp:Label>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Data de Publicação</td>
						<td>
							<asp:textbox onKeyDown="return FormataData(this, event);" onBlur="VerificaData(this);" MaxLength="10"
								ID="txtAtualizacao" Runat="server" CssClass="f8" ReadOnly="True"></asp:textbox>
						</td>
						<td HorizontalAlign="Right" class="f8" Width="30%" Text="Vendedora:"></td>
						<td HorizontalAlign="Left">
							<asp:Label CssClass="f8" id="lblVendedor" runat="server"></asp:Label>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Fantasia</td>
						<td colspan="3">
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtFantasia" MaxLength="255" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Empresa</td>
						<td colspan="3">
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtRazaoSocial" MaxLength="255" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Endereço</td>
						<td colspan="3">
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtEndereco" MaxLength="255" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Bairro</td>
						<td colspan="3">
							<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtComplemento" MaxLength="255" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Cidade</td>
						<td>
							<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtCidade" MaxLength="255" ReadOnly="True"></asp:TextBox>
						</td>
						<td class="f8" Width="30%" align="right">UF</td>
						<td>
							<uc1:ComboBox CssClass="f8" id="cboEstado" runat="server"></uc1:ComboBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">CEP</td>
						<td>
							<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtCEP" MaxLength="9" ReadOnly="True"></asp:TextBox>
						</td>
						<td class="f8" Width="30%" align="right">CNPJ</td>
						<td>
							<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtCNPJ" MaxLength="18" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">IE</td>
						<td>
							<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtInscricaoEstadual" MaxLength="50"
								ReadOnly="True"></asp:TextBox>
						</td>
						<td class="f8" Width="30%" align="right">IM</td>
						<td>
							<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtInscricaoMunicipal" MaxLength="50"
								ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Atividade</td>
						<td colspan="3">
							<uc1:ComboBox CssClass="f8" id="cboIdAtividade" runat="server"></uc1:ComboBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Pesquisador</td>
						<td>
							<uc1:ComboBox CssClass="f8" id="cboPesquisador" runat="server"></uc1:ComboBox>
						</td>
						<td class="f8" Width="30%" align="right">Nº da Revisão</td>
						<td>
							<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtNrDaRevisao" MaxLength="0" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Web Site</td>
						<td colspan="3">
							<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtWebSite" MaxLength="150" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">E-Mail</td>
						<td colspan="3">
							<asp:TextBox CssClass="f8" runat="server" Width="330px" ID="txtEmail" MaxLength="60" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">E-Mail Secundário</td>
						<td colspan="3">
							<asp:TextBox CssClass="f8" runat="server" Width="330px" ID="txtEmail2" MaxLength="60" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Endereço Skype</td>
						<td colspan="3">
							<asp:TextBox CssClass="f8" runat="server" Width="330px" ID="txtSkype" MaxLength="60" ReadOnly="True"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">Status</td>
						<td colspan="3">
							<uc1:ComboBox id="cboStatus" runat="server"></uc1:ComboBox>
						</td>
					</tr>
					<tr>
						<td class="f8" Width="30%">&nbsp;</td>
						<td colspan="2">
							<asp:CheckBox CssClass="f8" Runat="server" ID="chkDemo" Text="Demo"></asp:CheckBox>
						</td>
						<td align="right">
							&nbsp;
						</td>
					</tr>
					<tr>
						<td colspan="4">
							<marquee>
								<asp:Label CssClass="f8" Visible="True" ForeColor="#FF0000" ID="lblMensagem" Runat="server">CADASTRO INCOMPLETO - Verificar cadastro de contatos</asp:Label>
							</marquee>
						</td>
					</tr>
				</table>
				<br>
				<table id="Table1" runat="server" BackColor="#EFEFEF" CellSpacing="0" CellPadding="0" width="100%">
					<tr>
						<td class="f10" colspan="3"><h3>Contatos na Empresa</h3>
						</td>
					</tr>
					<tr>
						<td Align="center" colspan="4">
							<asp:DataGrid id="dtgContatos" CssClass="f8" runat="server" AllowPaging="False" AllowSorting="False"
								BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
								<HeaderStyle BackColor="#999999" ForeColor="#FFFFFF" Font-Bold="True"></HeaderStyle>
								<FooterStyle BackColor="#003C6E" ForeColor="#FFFFFF"></FooterStyle>
								<AlternatingItemStyle BackColor="#EFEFEF"></AlternatingItemStyle>
								<Columns>
									<asp:TemplateColumn HeaderText='Nome'>
										<ItemTemplate>
											<a href='contatosempresas.aspx?idcontato=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDContato"))%>&idempresa=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDEmpresa"))%>'>
												<%# DataBinder.Eval(Container.DataItem, "NomeContato")%>
											</a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField='DescricaoCargo' HeaderText="Cargo" />
									<asp:TemplateColumn HeaderText="Tel/Fax/Cel/PABX">
										<ItemTemplate>
											<%# iif(DataBinder.Eval(Container.DataItem, "DDD") <> "" and DataBinder.Eval(Container.DataItem, "Telefone") <> "", "(" & DataBinder.Eval(Container.DataItem, "DDD") & ")" & DataBinder.Eval(Container.DataItem, "Telefone"), "") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="Tel/Fax/Cel/PABX">
										<ItemTemplate>
											<%# iif(DataBinder.Eval(Container.DataItem, "DDDFax") <> "" and DataBinder.Eval(Container.DataItem, "Fax") <> "", "(" & DataBinder.Eval(Container.DataItem, "DDDFax") & ")" & DataBinder.Eval(Container.DataItem, "Fax"), "") %>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="E-Mail">
										<ItemTemplate>
											<%# iif(DataBinder.Eval(Container.DataItem, "Email") <> "" , "<a href='mailto:" & DataBinder.Eval(Container.DataItem, "Email") & "'><font class=f8>" & DataBinder.Eval(Container.DataItem, "Email") & "</font></a>", "") %>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid>
						</td>
					</tr>
					<tr>
						<td width="48%">
							&nbsp;
						</td>
					</tr>
					<tr>
						<td width="45%">
							&nbsp;
						</td>
						<td align="left">
							<input type="button" value="Voltar" onclick='location.href="empresas.aspx"'>
						</td>
					</tr>
				</table>
				<uc1:rodape id="Rodape" runat="server"></uc1:rodape>
			</div>
		</form>
	</body>
</HTML>
