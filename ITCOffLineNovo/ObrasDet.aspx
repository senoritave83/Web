<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ObrasDet.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.ObrasDet" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="~/inc/BarraBotoes2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>

<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<script language="javascript">				
			function EE(IdObra, IdEmpresa, IdModalidade, NomeEmpresa)
			{
			
				if(confirm("Confirma Exclusão da Empresa\n" + NomeEmpresa.toUpperCase()))
				{
					var win = window.open('ObrasExcluirEmpresa.aspx?IdObra=' + IdObra + '&IdEmpresa=' + IdEmpresa + '&IdModalidade=' + IdModalidade,'ExcluirEmpresa', 'width=300, height=100, top=100, left=100');
				}
			
			}
			function EnviaAgradecimento(Codigo)
			{
				var win = window.open('Agradecimento.aspx?c=' + Codigo, 'CartaAgradecimento', 'width=400, height=200, scrollbars=no');
            }
            function SomenteNumero(e) {
                var tecla = (window.event) ? event.keyCode : e.which;
                if ((tecla > 47 && tecla < 58)) return true;
                else {
                    if (tecla == 8 || tecla == 0) return true;
                    else return false;
                }
            }
		</script>
		<table cellSpacing="0" cellPadding="0" width="100%" border="0" bordercolor=#ff0000>
			<tr>
				<td vAlign="top" align="center">
					<table cellSpacing="0" width="100%" bgcolor="#809eb7">
						<tr>
							<td width="100%"><uc1:top id="Top1" runat="server"></uc1:top></td>
						</tr>
						<tr>
							<td width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
		<table cellSpacing="0" cellPadding="0" width="750" align="center" border="0" bordercolor=#ff0000>
			<tr>
				<td vAlign="top" align="center" width="100%">
					<form id="frmCad" action="ObrasDet.aspx" runat="server">
						<img src='imagens/TituloCadastroObras.jpg' border="0" width="294" height="40">
						<table cellspacing=0 cellpadding=0 width="768" border="1" bordercolor=#003c6e>
							<tr>
								<td>
									<Table bgcolor="#efefef" width="768" id="tblCadastro" align="center" cellpadding="0" cellspacing="0"  border="0">
										<TR bgcolor="#003c6e">
											<TD ColSpan="4" Align="center"><font class="f10" color="#ffffff"><b>DADOS CADASTRAIS</b></font></TD>
											<TD colspan="2"><asp:Button BorderStyle=None Text="Versões Anteriores" CssClass="f8" ID="btnVersoes" Runat="server" CausesValidation="False" /></TD>
										</TR>
										<TR>
											<TD align="right"><font class="f8" color="#000000">Código:&nbsp;</font></TD>
											<TD nowrap width="150">
												<asp:Label ID="lblCodigo" Runat="server" CssClass="f8"></asp:Label>&nbsp;&nbsp;&nbsp;
											</TD>
											<TD nowrap width="150" align="right">
												<font class="f8" color="#000000">Data do Cadastro:&nbsp;</font>
											</TD>
											<TD nowrap>
												<asp:TextBox onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);" CssClass="f8" Width="100" runat="server" ID="txtDataCadastro" MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtPublicacao" Runat="server" ID="Requiredfieldvalidator4" ErrorMessage="*" CssClass="f8"></asp:RequiredFieldValidator>
											</TD>
										</tr>
										<TR>
											<TD nowrap align="right"><font class="f8" color="#000000">Código ITCNet:&nbsp;</font></TD>
											<TD nowrap>
												<asp:TextBox runat="server" Width="100" ID="txtCodigoAntigo" MaxLength="15" CssClass="f8"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" Runat="server" CssClass="f8" ErrorMessage="*" ControlToValidate="txtCodigoAntigo" id="RequiredFieldValidator1"></asp:RequiredFieldValidator>
											</TD>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Data:&nbsp;</font>
											</TD>
											<TD nowrap>
												<asp:TextBox onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);" CssClass="f8" Width="100" runat="server" ID="txtPublicacao" MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="txtPublicacao" Runat="server" ID="re" ErrorMessage="*" CssClass="f8"></asp:RequiredFieldValidator>
											</TD>
										</tr>
										<tr>
											<TD nowrap align="right">
												<asp:Label ID="lblvendedor" Runat="server" CssClass="f8">&nbsp;&nbsp;Vendedor:&nbsp;</asp:Label>
											</TD>
											<TD nowrap>
												<uc1:ComboBox id="cboVendedor" runat="server"></uc1:ComboBox>
											</TD>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Pesquisador:&nbsp;</font>
											</TD>
											<TD nowrap>
												<uc1:ComboBox Style="width:230px;" id="cboPesquisadores" runat="server"></uc1:ComboBox>
											</TD>
										</TR>
										<TR>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Revisão:&nbsp;</font>
											</TD>
											<TD nowrap colspan="5">
												<asp:TextBox CssClass="f8" Width="50" runat="server" ID="txtNrDaRevisao" MaxLength="0"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" Runat="server" CssClass="f8" ErrorMessage="*" ControlToValidate="txtNrdaRevisao" ID="Requiredfieldvalidator2"></asp:RequiredFieldValidator><asp:CompareValidator Runat="server" ID="comp" ControlToValidate="txtNrDaRevisao" ErrorMessage="*" CssClass="f8" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
											</td>
										</TR>
										<TR>
											<TD Width="20%" align="right"><font class="f8" color="#000000">Nome da Obra:&nbsp;</font></TD>
											<TD nowrap colspan="5">
												<asp:TextBox Style="width:575px;" CssClass="f8" runat="server" ID="txtProjeto" MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator Display="Dynamic" Runat="server" CssClass="f8" ErrorMessage="*" ControlToValidate="txtProjeto" ID="Requiredfieldvalidator3" NAME="Requiredfieldvalidator1"></asp:RequiredFieldValidator>
											</TD>
										</TR>
										<TR>
											<TD align="right"><font class="f8" color="#000000">Endereço:&nbsp;</font></TD>
											<TD nowrap colspan="5">
												<asp:TextBox Style="width:575px;" CssClass="f8" runat="server" ID="txtEndereco" MaxLength="255"></asp:TextBox>
											</TD>
										</TR>
										<TR>
											<TD align="right"><font class="f8" color="#000000">Bairro:&nbsp;</font></TD>
											<TD nowrap>
												<asp:TextBox CssClass="f8" runat="server" Width="200" ID="txtComplemento" MaxLength="50"></asp:TextBox>
											</TD>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Cidade:&nbsp;</font>
											</TD>
											<TD nowrap>
												<uc1:ComboBox Style="Width:230px" id="cboCidade" runat="server"></uc1:ComboBox>
											</TD>
										</tr>
										<tr>
											<TD align="right"><font class="f8" color="#000000">UF:&nbsp;</font></TD>
											<TD nowrap>
												<uc1:ComboBox autopostback="true" id="cboEstado" runat="server"></uc1:ComboBox>
											</TD>
											<TD nowrap align="right">
												<font class="f8" color="#000000">CEP:&nbsp;</font>
											</TD>
											<TD nowrap>
												<asp:TextBox CssClass="f8" runat="server" onKeyDown="javascript:FormataCEP(this, event);" ID="txtCEP" Width=100 MaxLength="9"></asp:TextBox>
											</TD>
										</TR>
										<TR>
											<TD align=right><font class="f8" color="#000000">Segmento de Atuação:&nbsp;</font></TD>
											<TD nowrap colspan=1>
												<uc1:ComboBox Style="width:350" id="cboIdSubTipo" runat="server" autopostback="true"></uc1:ComboBox>
											</TD>
											<TD align="right"><font class="f8" color="#000000">Subtipo:&nbsp;</font></TD>
											<TD nowrap colspan=1>
												<uc1:ComboBox Style="width:350" id="cboTipo" runat="server"></uc1:ComboBox>
											</TD>
										</TR>
										<TR>
											<TD align="right"><font class="f8" color="#000000">Fase:&nbsp;</font></TD>
											<TD nowrap>
												<uc1:ComboBox id="cboIDFase" runat="server"></uc1:ComboBox>
											</TD>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Estágio Atual:&nbsp;</font>
											</TD>
											<TD nowrap>
												<uc1:ComboBox id="cboEstagio" runat="server"></uc1:ComboBox>
											</TD>
										</TR>
										<TR>
											<TD nowrap align="right"><font class="f8" color="#000000">Início da Obra:&nbsp;</font></TD>
											<TD nowrap>
												<asp:TextBox onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);" CssClass="f8" runat="server" ID="txtInicio" MaxLength="10"></asp:TextBox>
											</TD>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Término da Obra:&nbsp;</font>
											</TD>
											<TD nowrap>
												<asp:TextBox onBlur="VerificaData(this);" onKeyDown="return FormataData(this, event);" CssClass="f8" runat="server" ID="txtTermino" MaxLength="10"></asp:TextBox>
											</TD>
										</TR>
										<TR>
											<TD nowrap align="right"><font class="f8" color="#000000">Início / Término:&nbsp;</font></TD>
											<TD nowrap colspan="7">
												<asp:TextBox Style="width:80%" CssClass="f8" TextMode="SingleLine" runat="server" ID="txtInicioTermino" MaxLength="50" onblur="if(document.frmCad.txtInicioTermino.value == '') {document.frmCad.txtInicioTermino.value = ' '};"></asp:TextBox>
												<asp:CustomValidator Display="Dynamic" Runat="server" ControlToValidate="txtVazio" ClientValidationFunction="ValidateIT" ErrorMessage="*" CssClass="f8" id="CustomValidator1"></asp:CustomValidator>
												<script language="vbscript">

													Sub ValidateIT(source, arguments)
														if document.frmCad.txtInicioTermino.value = "" Then
															if document.frmCad.txtInicio.value = "" or document.frmCad.txtTermino.value = "" Then
																arguments.IsValid = false
															else
																arguments.IsValid = true
															end if
														else
															arguments.IsValid = true
														end if
													end sub
												</script>
												<asp:TextBox runat="server" Width="0%" ID="txtVazio" text="TESTE" onfocus="document.frmCad.txtAreaConstruida.focus();" />
											</TD>
										</TR>
										<TR>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Valor (US$ 1.000):&nbsp;</font>
											</TD>
											<TD nowrap>
												<asp:TextBox CssClass="f8" runat="server" ID="txtValor" MaxLength="0" onkeypress="return SomenteNumero(event)"></asp:TextBox>
											</TD>
											<TD nowrap align="right"><font class="f8" color="#000000">Área Construída (m²):&nbsp;</font></TD>
											<TD nowrap>
												<asp:TextBox CssClass="f8" runat="server" ID="txtAreaConstruida" MaxLength="0" onkeypress="return SomenteNumero(event)"></asp:TextBox><asp:CompareValidator Display="Dynamic" Runat="server" ErrorMessage="*" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtAreaConstruida" id="Comparevalidator5"></asp:CompareValidator>
											</TD>
										</TR>
										<TR>
											<TD nowrap align="right">
												&nbsp;
											</TD>
											<TD nowrap colspan="3">
												<uc1:ComboBox id="cboIdTipoCotacao" runat="server"></uc1:ComboBox>&nbsp;
											</TD>
											<td>
												<asp:TextBox CssClass="f8" runat="server" ID="txtValorDolar" Width="50" MaxLength="10" ></asp:TextBox>
											</td>
										</TR>
										<TR>
											<TD nowrap align="right"><font class="f8" color="#000000">Matéria Prima:&nbsp;</font></TD>
											<TD nowrap>
												<asp:TextBox CssClass="f8" runat="server" ID="txtMateriaPrima" MaxLength="50"></asp:TextBox>&nbsp;&nbsp;
											</TD>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Capacidade de Produção:&nbsp;</font>
											</TD>
											<TD nowrap>
												<asp:TextBox CssClass="f8" runat="server" ID="txtCapacidadeDeProducao" MaxLength="20"></asp:TextBox>
											</TD>
										</TR>
										<TR>
											<TD valign="top" align="right"><font class="f8" color="#000000"><br>Descrição:&nbsp;</font></TD>
											<TD nowrap colspan=4>
												<br>
												<font class="f8" color="#000000">Construção de&nbsp;</font><asp:TextBox CssClass="f8" runat="server" ID="txtDescEdificios" MaxLength="15" Width="50"></asp:TextBox>
												<font class="f8" color="#000000">edifício(s) residencial(ais)&nbsp;</font>
												<asp:TextBox CssClass="f8" runat="server" ID="txtDescCasas" MaxLength="15" Width="50"></asp:TextBox><font class="f8" color="#000000">&nbsp;casa(s)&nbsp;</font>
												<asp:TextBox CssClass="f8" runat="server" ID="txtDescCond" MaxLength="15" Width="50"></asp:TextBox><font class="f8" color="#000000">&nbsp;condomínios de casa(s) com&nbsp;</font><br>
												<asp:TextBox CssClass="f8" runat="server" ID="txtDescPavim" MaxLength="15" Width="50"></asp:TextBox><font class="f8" color="#000000">&nbsp;pavimento(s)&nbsp;</font>
												<asp:TextBox CssClass="f8" runat="server" ID="txtDescApart" MaxLength="15" Width="50"></asp:TextBox><font class="f8" color="#000000">&nbsp;apartamento(s) por andar&nbsp;</font>
												<asp:TextBox CssClass="f8" runat="server" ID="txtDescDormit" MaxLength="15" Width="50"></asp:TextBox><font class="f8" color="#000000">&nbsp;dormitório(s)&nbsp;</font>
												<asp:TextBox CssClass="f8" runat="server" ID="txtDescSuites" MaxLength="15" Width="50"></asp:TextBox><font class="f8" color="#000000">&nbsp;suítes(s)&nbsp;</font>
												<asp:TextBox CssClass="f8" runat="server" ID="txtDescBanh" MaxLength="15" Width="50"></asp:TextBox><font class="f8" color="#000000">&nbsp;banheiro(s)&nbsp;</font><br>
												<asp:TextBox CssClass="f8" runat="server" ID="txtDescLavabo" MaxLength="15" Width="50"></asp:TextBox><font class="f8" color="#000000">&nbsp;lavabo(s)&nbsp;</font>
												<asp:TextBox CssClass="f8" runat="server" ID="txtDescSala" MaxLength="15" Width="50"></asp:TextBox><font class="f8" color="#000000">&nbsp;sala(s) de estar / jantar&nbsp;</font>
												<asp:TextBox CssClass="f8" runat="server" ID="txtDescCopa" MaxLength="15" Width="50"></asp:TextBox><font class="f8" color="#000000">&nbsp;copa(s) / cozinha(s)&nbsp;</font><br>
												<asp:TextBox CssClass="f8" runat="server" ID="txtDescAreaServ" MaxLength="15" Width="50"></asp:TextBox><font class="f8" color="#000000">&nbsp;área(s) de serviço / terraço(s) / varanda(s)&nbsp;</font>
												<asp:TextBox CssClass="f8" runat="server" ID="txtDescDepend" MaxLength="15" Width="50"></asp:TextBox><font class="f8" color="#000000">&nbsp;dependência(s) de empregada&nbsp;</font><br>
												<font class="f8" color="#000000">outros:&nbsp;</font><asp:TextBox CssClass="f8" runat="server" ID="txtDescOutros" MaxLength="1000" Width="500"></asp:TextBox>
											</TD>
										</TR>
										<TR>
											<TD valign="top" align="right"><font class="f8" color="#000000"><br>Área de Lazer:&nbsp;</font></TD>
											<TD nowrap colspan="4">
												<br>
												<table width="500">
													<tr>
														<td><asp:CheckBox CssClass="f8" runat="server" ID="chkSalaoFestas"></asp:CheckBox>&nbsp;<font class="f8" color="#000000">Salão de festas</font></td>
														<td><asp:CheckBox CssClass="f8" runat="server" ID="chkSalaoJogos"></asp:CheckBox>&nbsp;<font class="f8" color="#000000">Salão de jogos</font></td>
														<td><asp:CheckBox CssClass="f8" runat="server" ID="chkPiscina"></asp:CheckBox>&nbsp;<font class="f8" color="#000000">Piscina</font></td>
														<td><asp:CheckBox CssClass="f8" runat="server" ID="chkSauna"></asp:CheckBox>&nbsp;<font class="f8" color="#000000">Sauna</font></td>
													</tr>
													<tr>
														<td><asp:CheckBox CssClass="f8" runat="server" ID="chkChurrasqueira"></asp:CheckBox>&nbsp;<font class="f8" color="#000000">Churrasqueira</font></td>
														<td><asp:CheckBox CssClass="f8" runat="server" ID="chkQuadra"></asp:CheckBox>&nbsp;<font class="f8" color="#000000">Quadra</font></td>
														<td><asp:CheckBox CssClass="f8" runat="server" ID="chkFitness"></asp:CheckBox>&nbsp;<font class="f8" color="#000000">Fitness</font></td>
														<td><asp:CheckBox CssClass="f8" runat="server" ID="chkGourmet"></asp:CheckBox>&nbsp;<font class="f8" color="#000000">Gourmet</font></td>
													</tr>
													<tr>
														<td><asp:CheckBox CssClass="f8" runat="server" ID="chkPlayground"></asp:CheckBox>&nbsp;<font class="f8" color="#000000">Playground</font></td>
														<td><asp:CheckBox CssClass="f8" runat="server" ID="chkSpa"></asp:CheckBox>&nbsp;<font class="f8" color="#000000">Spa</font></td>
														<td><asp:CheckBox CssClass="f8" runat="server" ID="chkBrinquedoteca"></asp:CheckBox>&nbsp;<font class="f8" color="#000000">Brinquedoteca</font></td>
													</tr>
												</table>
												<font class="f8" color="#000000">Outros&nbsp;</font><asp:TextBox CssClass="f8" runat="server" ID="txtLazerOutros" MaxLength="1000" Width="500"></asp:TextBox>
											</TD>
										</TR>
										<TR>
											<TD valign="top" align="right"><font class="f8" color="#000000"><br>Informações&nbsp;&nbsp;<br>Adicionais:&nbsp;</font></TD>
											<TD nowrap colspan="4">
												<br>
												<table width="600">
													<tr>
														<td align="right"><font class="f8" color="#000000">Total de Unidades:&nbsp;</font></td>
														<td><asp:TextBox CssClass="f8" runat="server" ID="txtInfoAdicTotalunid" MaxLength="15" Width="80"></asp:TextBox></td>
														<td align="right"><font class="f8" color="#000000">Área Útil (m²):&nbsp;</font></td>
														<td><asp:TextBox CssClass="f8" runat="server" ID="txtInfoAdicAreaUtil" MaxLength="15" Width="80"></asp:TextBox></td>
														<td align="right"><font class="f8" color="#000000">Área do Terreno (m²):&nbsp;</font></td>
														<td><asp:TextBox CssClass="f8" runat="server" ID="txtInfoAdicAreaTerreno" MaxLength="15" Width="80"></asp:TextBox></td>
													</tr>
													<tr>
														<td align="right"><font class="f8" color="#000000">Elevado(es):&nbsp;</font></td>
														<td><asp:TextBox CssClass="f8" runat="server" ID="txtInfoAdicElevador" MaxLength="15" Width="60"></asp:TextBox></td>
														<td align="right"><font class="f8" color="#000000">Vagas por Apartamento:&nbsp;</font></td>
														<td><asp:TextBox CssClass="f8" runat="server" ID="txtInfoAdicVagasApart" MaxLength="15" Width="80"></asp:TextBox></td>
														<td align="right"><font class="f8" color="#000000">Coberturas:&nbsp;</font></td>
														<td><asp:TextBox CssClass="f8" runat="server" ID="txtInfoAdicCoberturas" MaxLength="15" Width="60"></asp:TextBox></td>
													</tr>
												</table>
											</TD>
										</TR>
										<TR>
											<TD nowrap align="right"><font class="f8" color="#000000">Ar Condicionado:&nbsp;</font></TD>
											<TD nowrap>
												<asp:TextBox CssClass="f8" runat="server" ID="txtInfoAdicArCond" MaxLength="50" Width="200"></asp:TextBox>&nbsp;&nbsp;
											</TD>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Aquecimento:&nbsp;</font>
											</TD>
											<TD nowrap>
												<asp:TextBox CssClass="f8" runat="server" ID="txtInfoAdicAquecimento" MaxLength="50" Width="200"></asp:TextBox>&nbsp;&nbsp;
											</TD>
										</TR>
										<TR>
											<TD nowrap align="right"><font class="f8" color="#000000">Fundações:&nbsp;</font></TD>
											<TD nowrap>
												<asp:TextBox CssClass="f8" runat="server" ID="txtInfoAdicFundacoes" MaxLength="50" Width="200"></asp:TextBox>&nbsp;&nbsp;
											</TD>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Estrutura:&nbsp;</font>
											</TD>
											<TD nowrap>
												<asp:TextBox CssClass="f8" runat="server" ID="txtInfoAdicEstrutura" MaxLength="50" Width="200"></asp:TextBox>&nbsp;&nbsp;
											</TD>
										</TR>
										<TR>
											<TD nowrap align="right"><font class="f8" color="#000000">Acabamento:&nbsp;</font></TD>
											<TD nowrap>
												<asp:TextBox CssClass="f8" runat="server" ID="txtInfoAdicAcabamento" MaxLength="50" Width="200"></asp:TextBox>&nbsp;&nbsp;
											</TD>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Fachada:&nbsp;</font>
											</TD>
											<TD nowrap>
												<asp:TextBox CssClass="f8" runat="server" ID="txtInfoAdicFachada" MaxLength="50" Width="200"></asp:TextBox>&nbsp;&nbsp;
												<br>
											</TD>
										</TR>
										<tr>
											<td>
												&nbsp;
											</td>
										</tr>
										<TR>
											<TD valign="top" align="right"><font class="f8" color="#000000">Descrições&nbsp;&nbsp;<br>Complementares:&nbsp;</font></TD>
											<TD nowrap colspan="4">
												<asp:TextBox Columns="80" Rows="5" TextMode="MultiLine" cssclass="f8" runat="server" onkeypress="javascript:textCounter(this,this.form.counter,999);" ID="txtDescProj1" Width="575"></asp:TextBox><br>&nbsp;
											</TD>
										</TR>
										<TR>
											<TD align="right"><font class="f8" color="#000000">Status:&nbsp;</font></TD>
											<TD nowrap colspan="5">
												<uc1:ComboBox id="cboStatus" runat="server"></uc1:ComboBox>
												<asp:CheckBox CssClass="f8" Runat="server" ID="chkDemo" Text="Demo"></asp:CheckBox>
												<asp:Label CssClass="f8" Runat="server" ID="lblAgradece" Text="Agradece"></asp:Label>
											</TD>
										</TR>
										<tr>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Foto:&nbsp;</font>
											</TD>
											<TD nowrap colspan="5">
												<asp:TextBox style="width:400px;" CssClass="f8" runat="server" ID="txtFoto" MaxLength="50"></asp:TextBox>&nbsp;&nbsp;
											</TD>
										</tr>
										<tr>
											<TD nowrap align="right">
												<font class="f8" color="#000000">Mapa:&nbsp;</font>
											</TD>
											<TD nowrap colspan="5">
												<asp:TextBox style="width:400px;" CssClass="f8" runat="server" ID="txtMapa" MaxLength="50"></asp:TextBox>&nbsp;&nbsp;
											</TD>
										</tr>
										<TR>
											<TD align=right colspan="5">
												<uc1:BarraBotoes id="Barra" runat="server"></uc1:BarraBotoes>
											</TD>
										</TR>

										<TR>
											<TD align="center" colspan="5">
												<marquee><asp:Label CssClass="f8" Visible="True" ForeColor="#FF0000" ID="lblMensagem" Runat="server">&nbsp;</asp:Label></marquee>
											</TD>
										</TR>
									</Table>
								</td>
							</tr>
						</table>
						<br>
						<Table width="100%" id="tblCadastroContatos" align="center" cellpadding="0" cellspacing="0" border="0">
							<TR bgcolor="#003c6e">
								<TD Align="center"><font class="f10" color="#ffffff"><b>CONTATOS</b></font></TD>
							</TR>
							<TR>
								<TD Align="center" Font-Bold="True" Font-Name="verdana" Font-Size="10" Width="100%" Text="">
									<table cellspacing=0 cellpadding=0 width="100%" border=1 bordercolor=#003c6e>
										<tr>
											<td>
												<asp:DataGrid id="dtgContatos" CssClass="f8" runat="server" AllowPaging="False" AllowSorting="False" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
													<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
													<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
													<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
													<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
													<Columns>
														<asp:TemplateColumn HeaderText='Nome do Contato'>
															<ItemTemplate>
																<a href='contatosobras.aspx?idcontato=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDContato"))%>&idobra=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDObra"))%>'>
																	<%# DataBinder.Eval(Container.DataItem, "NomeContato")%>
																</a>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField='Fantasia' HeaderText="Empresa" />
														<asp:BoundColumn DataField='DescricaoCargo' HeaderText="Cargo" />
														<asp:BoundColumn DataField='CTelefone' HeaderText="Tel/Fax/Cel/PABX/Obra" />
														<asp:BoundColumn DataField='CFax' HeaderText="Tel/Fax/Cel/PABX/Obra" />
														<asp:BoundColumn DataField='EMail' HeaderText="E-Mail" />
													</Columns>
												</asp:DataGrid>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
							<TR>
								<TD Align="center">
									<asp:ImageButton  BorderStyle=None ImageUrl="imagens/botaonovocontato.gif" CssClass="f8" ID="btnAdicionarContato" Runat="server" Text='Novo Contato' CausesValidation="False" />
								</TD>
							</TR>
						</Table>
						<br>
						<Table width="100%" id="tblCadastroEmpresasParticipantes" align="center" cellpadding="0" cellspacing="0" border="0">
							<TR bgcolor="#003c6e">
								<TD Align="center"><font class="f10" color="#ffffff"><b>EMPRESAS PARTICIPANTES</b></font></TD>
							</TR>
							<TR>
								<TD>
									<table cellspacing=0 cellpadding=0 width="100%" border=1 bordercolor=#003c6e>
										<tr>
											<td>
												<asp:DataGrid id="dtgEmpresasParticipantes" CssClass="f8" runat="server" AllowPaging="False" AllowSorting="False" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
													<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
													<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
													<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
													<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
													<Columns>
														<asp:TemplateColumn HeaderText='NOME FANTASIA DA EMPRESA'>
															<ItemTemplate>
																<a href='empresaobras.aspx?idobra=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdObra"))%>&idempresa=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDEmpresa"))%>&idmodalidade=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDModalidade"))%>'>
																	<%# DataBinder.Eval(Container.DataItem, "Fantasia")%>
																</a>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText='RAZÃO SOCIAL DA EMPRESA'>
															<ItemTemplate>
																<a href='empresaobras.aspx?idobra=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdObra"))%>&idempresa=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDEmpresa"))%>&idmodalidade=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IDModalidade"))%>'>
																	<%# DataBinder.Eval(Container.DataItem, "RazaoSocial")%>
																</a>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText='MODALIDADE'>
															<ItemTemplate>
																<%# DataBinder.Eval(Container.DataItem, "DESCRICAOMODALIDADE")%>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
							<TR>
								<TD Align="center">
									<asp:ImageButton BorderStyle=None ImageUrl="imagens/botaoadicionarempresa.gif" CssClass="f8" ID="btnAdicionarEmpresa" Runat="server" CausesValidation="False" />
								</TD>
							</TR>
						</Table>
						<br>
						<br>
					</form>
				</td>
			</tr>
		</table>
		<uc1:Rodape id="Rodape1" runat="server"></uc1:Rodape>
	</body>
</HTML>
