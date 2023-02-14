<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="produtodet.aspx.vb" Inherits="xmlinkwm.produtodet"%>
<HTML>
	<!-- #INCLUDE FILE='inc/inc_header.ascx' -->
	<body MS_POSITIONING="GridLayout" topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
	<!-- #INCLUDE FILE='inc/inc_top.ascx' -->
	<table width="100%" cellpadding="0" cellspacing="0" height="100%">
		<tr>
			<td>
				<uc1:inc_menu id="Inc_menu1" runat="server"></uc1:inc_menu>
			</td>
			<td class='BackgrStripes' rowspan="2">&nbsp;</td>
		</tr>
		<tr height="100%">
			<td width="750" valign="top" align="middle">
				<!-- INICIO CONTEUDO -->
				<form id="Form1" method="post" runat="server">
					<table height="100%" width="730">
						<tr vAlign="center" height="60">
							<td>
								<uc1:titulo id="Titulo1" runat="server" Titulo="Cadastro de Produtos" Descricao="Cadastre e edite os dados dos produtos" imagem="imagens/responsavel6060.jpg"></uc1:titulo>
							</td>
						</tr>
						<tr valign="top" height="100%">
							<td>
								<TABLE cellPadding="1" width="100%" bgColor="dimgray">
									<TR vAlign="top" bgColor="white">
										<TD>
											<TABLE width="100%">
												<TR>
													<TD class="TextDefault">Código
														<asp:RequiredFieldValidator Runat="server" ID='valtxtCodigo' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' ControlToValidate='txtCodigo' />
														<BR>
														<asp:TextBox id="txtCodigo" Width="100%" CssClass="Caixa" Runat="server"></asp:TextBox></TD>
													<td class='TextDefault' colspan="2">Descrição
														<asp:RequiredFieldValidator Runat="server" ID="valtxtDescricao" ControlToValidate='txtDescricao' ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!'></asp:RequiredFieldValidator>
														<br>
														<asp:TextBox Runat="server" ID="txtDescricao" CssClass="Caixa" Width="100%" />
													</td>
												</TR>
												<TR>
													<TD class="TextDefault">Categoria
														<BR>
														<uc1:ComboBox id="cboCategoria" runat="server" DataValueField='cat_Categoria_int_PK' DataTextField='cat_Categoria_chr'></uc1:ComboBox>
													</TD>
													<TD class="TextDefault">Estoque
														<asp:RequiredFieldValidator Runat="server" ID="Requiredfieldvalidator1" ControlToValidate='txtEstoque' Display="Dynamic" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!' />
														<asp:CompareValidator runat="server" id='valComEstoque' ControlToValidate="txtEstoque" Type="Integer" Operator="DataTypeCheck" ErrorMessage='<img src="imagens/exclam2.gif"> Valor inválido!' />
														<BR>
														<asp:TextBox id="txtEstoque" Width="100%" CssClass="Caixa" Runat="server"></asp:TextBox>
													</TD>
													<TD class="TextDefault">Preço Unitário
														<asp:RequiredFieldValidator Runat="server" ID="Requiredfieldvalidator2" ControlToValidate='txtPrecoUnitario' Display="Dynamic" ErrorMessage='<img src="imagens/exclam2.gif"> Campo obrigatório!'></asp:RequiredFieldValidator>
														<asp:CompareValidator runat="server" id="Comparevalidator1" ControlToValidate="txtPrecoUnitario" Type="Currency" Operator="DataTypeCheck" ErrorMessage='<img src="imagens/exclam2.gif"> Valor inválido!' />
														<BR>
														<asp:TextBox id="txtPrecoUnitario" Width="100%" CssClass="Caixa" Runat="server"></asp:TextBox>
													</TD>
												</TR>
											</TABLE>
											<uc1:BarraBotoes id="BarraBotoes1" runat="server"></uc1:BarraBotoes></TD>
									</TR>
								</TABLE>
							</td>
						</tr>
						<tr>
							<td valign="top">
								<ul class='TextDefault'>
									<li>
										<b>Novo:</b>Cadastre um novo Produto.
									<li>
										<b>Excluir:</b>
									Exclua este registro da Lista de Produtos.
									<li>
										<b>Salvar:</b> Grave este registro na Lista de Produtos.</li>
								</ul>
							</td>
						</tr>
					</table>
				</form>
				<!-- FIM CONTEUDO -->
			</td>
		</tr>
	</table>
<!-- #INCLUDE FILE='inc/inc_rodape.ascx' -->
</body> 
</html> 
