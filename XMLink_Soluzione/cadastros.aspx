<%@ Page Language="vb" AutoEventWireup="false" Codebehind="cadastros.aspx.vb" Inherits="xmlinkwm.cadastros"%>
<%@ Register TagPrefix="uc1" TagName="titulo" Src="inc/titulo.ascx" %>
<%@ Register TagPrefix="uc1" TagName="inc_menu" Src="inc/inc_menu.ascx" %>
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
										<uc1:titulo id="Titulo1" runat="server" Titulo="Cadastros do sistema" Descricao="Nesta p�gina voc� tem acesso a todos os cadastros usados pelo sistema" imagem="imagens/config.gif"></uc1:titulo>
									</td>
								</tr>
								<tr vAlign="top" height="100%">
									<td colSpan="2">
										<table height="100%" width="100%">
											<tr>
												<td runat="server" id="tdCadUsuarios" visible="false" colspan="2">
                                                    <div style="float:left;">
                                                        <A href="usuarios.aspx"><IMG src="imagens/operator4848.png" border="0"></A>
                                                    </div>
                                                    <div style="padding-left:85px">
                                                        <A class="TextDefaultBold" href="usuarios.aspx">OPERADORES / ADMINISTRADORES</A><br>
													    <font class="TextDefault">Cadastre e edite os dados dos operadores e 
														    administradores do sistema</font>
                                                    </div>
												</td>
												<td><A href="clientes.aspx"><IMG src="imagens/cliente.jpg" border="0"></A>
												</td>
												<td><A class="TextDefaultBold" href="clientes.aspx">CLIENTES</A><br>
													<font class="TextDefault">Cadastro e edite os dados de seus clientes</font>
												</td>
											</tr>
											<tr>
												<td><A href="vendedores.aspx"><IMG src="imagens/responsavel6060.jpg" border="0"></A>
												</td>
												<td><A class="TextDefaultBold" href="vendedores.aspx">VENDEDORES</A><br>
													<font class="TextDefault">Cadastre e edite os dados dos vendedores</font>
												</td>
												<td><A href="grupos.aspx"><IMG src="imagens/group6060.jpg" border="0"></A>
												</td>
												<td><A class="TextDefaultBold" href="grupos.aspx">GRUPOS</A><br>
													<font class="TextDefault">Cadastre e edite grupos de trabalho dos vendedores 
														Digitais</font>
												</td>
											</tr>
											<tr>
												<td><A href="categorias.aspx"><IMG src="imagens/categorias.jpg" border="0"></A>
												</td>
												<td><A class="TextDefaultBold" href="categorias.aspx">CATEGORIAS</A><br>
													<font class="TextDefault">Cadastre e edite as categorias de produtos</font>
												</td>
												<td><A href="condicoes.aspx"><IMG src="imagens/condicao.gif" border="0"></A>
												</td>
												<td><A class="TextDefaultBold" href="condicoes.aspx">CONDI��ES DE PAGAMENTO</A><br>
													<font class="TextDefault">Cadastre e edite as condi��es de pagamentos</font>
												</td>
											</tr>
											<tr>
												<td><A href="formapagamento.aspx"><IMG src="imagens/money2.gif" border="0"></A>
												</td>
												<td><A class="TextDefaultBold" href="formapagamento.aspx">FORMA DE PAGAMENTO</A><br>
													<font class="TextDefault">Cadastre e edite as Formas de Pagamento</font>
												</td>
												<td><A href="produtos.aspx"><IMG src="imagens/settings.jpg" border="0"></A>
												</td>
												<td><A class="TextDefaultBold" href="produtos.aspx">PRODUTOS</A><br>
													<font class="TextDefault">Cadastre e edite os Produtos da sua empresa</font>
												</td>
											</tr>
											<tr>
												<td>
													<A href="campanhas.aspx"><IMG src="imagens/categorias.jpg" border="0"></A>
												</td>
												<td><A class="TextDefaultBold" href="campanhas.aspx">CAMPANHAS</A><br>
													<font class="TextDefault">Cadastre e edite as Formas de Pagamento</font>
												</td>
												<td><A href="distribuidores.aspx"><IMG src="imagens/responsavel6060.jpg" border="0"></A></td>
												<td><A class="TextDefaultBold" href="distribuidores.aspx">DISTRIBUIDORES DIRETOS</A><br>
													<font class="TextDefault">Cadastre e edite os distribuidores.</font></td>
												<td>&nbsp;</td>
											</tr>
										</table>
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
</HTML>
