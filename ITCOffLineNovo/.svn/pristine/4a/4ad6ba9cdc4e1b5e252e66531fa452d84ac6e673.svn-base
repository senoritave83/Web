<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FormularioProposta.aspx.vb" Inherits="ITCOffLine.FormularioProposta"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Formul&aacute;rio da Proposta</title>
		<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
		<style type="text/css" >
			.f8 {font-size: 10px; FONT-FAMILY: Verdana, Tahoma, Arial; }
			.f8FormProp {padding-left:42px; font-size: 13px; FONT-FAMILY: Arial, Verdana, Tahoma; }
			.f8FormProp2 {padding-left:20px; font-size: 13px; FONT-FAMILY: Arial, Verdana, Tahoma; }
			.f8FormProp3 {padding-left:14px; font-size: 13px; FONT-FAMILY: Arial, Verdana, Tahoma; }
			.f8FormProp4 {font-size: 13px; FONT-FAMILY: Arial, Verdana, Tahoma; }
			.f8FormPropModulos {padding-left:42px; font-size: 13px; FONT-FAMILY: Arial, Verdana, Tahoma; }
		</style>
		<!--Fireworks CS5 Dreamweaver CS5 target.  Created Thu Mar 10 11:55:49 GMT-0300 (Hora oficial do Brasil) 2011-->
	</HEAD>
	<body bgColor="#ffffff">
		<table border="0" cellSpacing="0" cellPadding="0" width="800">
			<tr>
				<td rowspan="2" width="128"><img id="ImgFrmPropTopoTit" name="ImgFrmPropTopoTit" src="Imagens/FormularioProposta/FrmPropTopoTit.jpg" width="128" height="143" /></td>
				<td>
					<table border="0" width="100%">
						<tr>
							<td width="64%" class="f8FormProp">
								<font color="#F47025" size="6">
									<b>Proposta<br>
										Comercial
									</b>
								</font>
							</td>
							<td width="36%">
								<%= IIf(ViewState("IdTipoProposta")=1, "<img src='Imagens/FormularioProposta/logoitcPed.png' width='185' height='70'>", " <img src='Imagens/FormularioProposta/Guia_Negocios.png' width='185' height='85'>")%>
							</td>
						</tr>
						<tr>
							<td class="f8FormProp" colspan="2" height="20" valign="bottom">
								<b>N&ordm; <asp:Label Runat="server" ID="lblIdProposta"></asp:Label></b>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td colspan="2"><img id="ImgFormPropTracoLarTopo" name="ImgFormPropTracoLarTopo" src="Imagens/FormularioProposta/FormPropTracoLaranja.jpg" /></td>
			</tr>
			<tr>
				<td><IMG id="ImgFrmPropLarAC" border="0" name="ImgFrmPropLarAC" alt="" src="Imagens/FormularioProposta/FrmPropLarAC.jpg"
						width="128" height="89"></td>
				<td class="f8FormProp">
					<b>S&atilde;o Paulo,&nbsp;<asp:label id="lblDataProposta" Runat="server"></asp:label>
						<br><br>
						<asp:label id="lblEmpresaDestinatario" ForeColor="#F47025" Runat="server"></asp:label>&nbsp;|
						<asp:label id="lblDestinatario" Runat="server"></asp:label>
					</b>		
				</td>
			</tr>
			<tr>
				<td colspan="2"><IMG id="ImgFormPropTraco6" border="0" name="ImgFormPropTraco6" alt="" src="Imagens/FormularioProposta/FormPropTraco.jpg" width="800" height="8"></td>
			</tr>
			<tr>
				<td><img id="ImgFrmPropTitObjetivo" alt="" name="ImgFrmPropTitObjetivo" src="Imagens/FormularioProposta/FrmPropTitObjetivo.jpg" width="128" height="98" border="0" /></td>
				<td class="f8FormProp">
					<%= IIf(ViewState("IdTipoProposta") = 1, "<font size='3' style='font-weight:bold;'>Fornecimento de Informa&ccedil;&otilde;es sobre Obras no Brasil.</font>", "<font size='2' style='font-weight:bold;'>Divulga&ccedil;&atilde;o da Empresa, Produtos e Servi&ccedil;os no Guia de Neg&oacute;cios ITC.</font>")%>
				</td>
			</tr>
			<tr>
				<td colSpan="2"><IMG id="ImgFormPropTraco" border="0" name="ImgFormPropTraco" alt="" src="Imagens/FormularioProposta/FormPropTraco.jpg"
						width="800" height="8"></td>
			</tr>
			<tr>
				<td height="100%">
					<table cellSpacing="0" cellPadding="0" height="100%" runat="server" ID="Table1" border="0">
						<tr>
							<td width="50%"><IMG id="ImgFormPropTracoVar" border="0" name="ImgFormPropTracoVar" alt="" src="Imagens/FormularioProposta/FormPropTracoVar.jpg"
									width="128" height="100%"></td>
						</tr>
						<tr>
							<td height="143" width="128"><IMG id="ImgFormPropTitModulos" border="0" name="ImgFormPropTitModulos" alt="" src="Imagens/FormularioProposta/FormPropTitModulos.jpg"
									width="128" height="143"></td>
						</tr>
						<tr>
							<td width="50%"><IMG id="ImgFormPropTracoVar2" border="0" name="ImgFormPropTracoVar2" alt="" src="Imagens/FormularioProposta/FormPropTracoVar.jpg"
									width="128" height="100%"></td>
						</tr>
					</table>
				</td>
				<td class="f8FormPropModulos" >	
					<asp:Repeater id="rptOrcamentos" runat="server">
						<HeaderTemplate>
						</HeaderTemplate>
						<ItemTemplate>
							<asp:Repeater ID="rptLbl" DataSource='<%# ListarFormOrcamentos(DataBinder.Eval(Container.DataItem, "IdOrcamento"))%>' Runat="server" OnItemDataBound='rptLbl_ItemDataBound'>
								<ItemTemplate>
											
									<asp:Repeater ID="rptOrcamentosPlanos" DataSource='<%# ListarFormOrcamentosItem(DataBinder.Eval(Container.DataItem, "IdOrcamento"))%>' Runat="server">
										<HeaderTemplate>
										</HeaderTemplate>
											<ItemTemplate>
                                                <asp:Label runat="server">
												<b>M&oacute;dulo: </b><%= IIf(ViewState("IdTipoProposta") = 1, "Informa&ccedil;&otilde;es de obras no(s) segmento(s): ", "")%>
                                                </asp:Label>
												<asp:label IdOrcamento='<%#DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' id="lblModulo" Runat="server">
													<%# Server.HtmlEncode(DataBinder.Eval(Container.DataItem, "Plano"))%>
												</asp:label><br>
												<div runat="server" style="float:left; width:600px;">
													<b>Valor: (R$)</b>&nbsp;
													<asp:label IdOrcamento='<%#DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' id="lblValor" Runat="server">
														<%# FormatNumber(DataBinder.Eval(Container.DataItem, "Valor"),2)%>
													</asp:label>&nbsp;
													<asp:label IdOrcamento='<%#DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' id="lblCondPagmento" Runat="server">
														<%# DataBinder.Eval(Container.DataItem, "CondPagmento")%>
													</asp:label>&nbsp;
													<asp:label IdOrcamento='<%#DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' id="lblPeriodo" Runat="server">
														<%# DataBinder.Eval(Container.DataItem, "Periodo")%>
													</asp:label>
												</div>
												<div runat="server" style="float:left; width:260px;" Visible='<%# IIf(DataBinder.Eval(Container.DataItem, "Renovacao") <> 1, false, true)%>'>
													<b>Valor Renova&ccedil;&atilde;o: (R$)</b>&nbsp;
													<asp:label IdOrcamento='<%#DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' id="lblValorRenovacao" Runat="server">
														<%# FormatNumber(DataBinder.Eval(Container.DataItem, "ValorRenovacao"),2)%>
													</asp:label>
												</div>
												<br><br>
											</ItemTemplate>
									</asp:Repeater>
                                    									
									<div runat="server">
										<IMG id="ImgFormPropTracoMod"  runat="server" name="ImgFormPropTracoMod" alt="" src="Imagens/FormularioProposta/FormPropTracoMod.jpg">
									</div>
								</ItemTemplate>
							</asp:Repeater>
						</ItemTemplate>
										
						<FooterTemplate>
                            <div runat="server">
                            <b>Validade da Proposta:</b>
								<asp:label IdOrcamento='<%#DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' id="lblValidadeProposta" Runat="server">
                                    <%# Server.HtmlEncode(ViewState("ValidadeProposta"))%>
                                </asp:label><br>
                            </div>
							<div runat="server" Visible='<%# IIf(Viewstate("Observacao") = "", false, true)%>' style="width:580px;">
								<b>Observa&ccedil;&atilde;o:</b>
								<asp:label IdOrcamento='<%#DataBinder.Eval(Container.DataItem, "IdOrcamento")%>' id="lblObservacao" Runat="server">
									<%# Server.HtmlEncode(Viewstate("Observacao"))%>
								</asp:label>
							</div>
						</FooterTemplate>
																	
					</asp:Repeater>
				</td>
			</tr>
			<tr>
				<td colSpan="2"><IMG id="ImgFormPropTraco2" border="0" name="ImgFormPropTraco2" alt="" src="Imagens/FormularioProposta/FormPropTraco.jpg"
						width="800" height="8"></td>
			</tr>
			<tr>
				<td height="100%">
					<table cellSpacing="0" cellPadding="0" height="100%" runat="server" ID="Table2" border="0">
						<tr>
							<td width="50%"><IMG id="ImgFormPropTracoVar3" border="0" name="ImgFormPropTracoVar3" alt="" src="Imagens/FormularioProposta/FormPropTracoVar.jpg"
									width="128" height="100%"></td>
						</tr>
						<tr>
							<td height="143" width="128"><IMG id="ImgFormPropTitModulos2" border="0" name="ImgFormPropTitModulos2" alt="" src="Imagens/FormularioProposta/FormPropTitBeneficios.jpg"
									width="128" height="143"></td>
						</tr>
						<tr>
							<td width="50%"><IMG id="ImgFormPropTracoVar4" border="0" name="ImgFormPropTracoVar4" alt="" src="Imagens/FormularioProposta/FormPropTracoVar.jpg"
									width="128" height="100%"></td>
						</tr>
					</table>
				</td>
				<td rowSpan="2" valign="middle">
					<table border="0">
						<tr><%= IIf(ViewState("IdTipoProposta")=1, _
							"<td class='f8FormProp3' width='300' style='text-align:justify'>" & _
							    "<ul><li>Informa&ccedil;&otilde;es di&aacute;rias e detalhadas " & _
								"de obras, empresas, " & _
								"not&iacute;cias da constru&ccedil;&atilde;o " & _
								"e mercado imobili&aacute;rio.</li>" & _
								"<li>Acesso on-line.</li>" & _
								"<li><b>Banco retroativo</b> de 30 dias.</li>" & _
								"<li>2 (dois) logins de acesso por m&oacute;dulo.</li>" & _
								"<li>Controle e Monitoramento dos usu&aacute;rios.</li>" & _
								"<li>Canal direto com o pesquisador.</li></ul>" & _
							"</td>" & _
							"<td class='f8FormProp4' width='275' style='text-align:justify'>" & _
								"<ul><li><b>SIG - </b>Sistema de Informa&ccedil;&otilde;es Gerenciadas - </li>" & _
								" Agendamento, Controle e Acompanhamento das Negocia&ccedil;&otilde;es." & _
								"<li>Treinamento para toda equipe envolvida.</li>" & _
								"<li><b>Suporte t&eacute;cnico</b> permanente.</ul></li>" & _
							"</td>", _
							"<td class='f8FormProp3'>" & _
								"<ul><li>Destaque da empresa no portal (com logo e foto, localiza&ccedil;&atilde;o e produtos).</li>" & _
								"<li>Recebimento de cota&ccedil;&otilde;es diretas e online.</li>" & _
								"<li>Vitrine com os produtos.</li>" & _
								"<li>Divulga&ccedil;&atilde;o de lan&ccedil;amento de produtos, servi&ccedil;os e obras realizadas no site.</li>" & _
								"<li>Guia Segmentado na &aacute;rea da constru&ccedil;&atilde;o.</li></ul>" & _
							"</td>")%>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td colSpan="2"><IMG id="ImgFormPropTraco3" border="0" name="ImgFormPropTraco3" alt="" src="Imagens/FormularioProposta/FormPropTraco.jpg"
						width="800" height="8"></td>
			</tr>
			<tr>
				<td height="100%">
					<table cellSpacing="0" cellPadding="0" height="100%" runat="server" ID="Table3" border="0">
						<tr>
							<td width="50%"><IMG id="ImgFormPropTracoVar5" border="0" name="ImgFormPropTracoVar5" alt="" src="Imagens/FormularioProposta/FormPropTracoVar.jpg"
									width="128" height="100%"></td>
						</tr>
						<tr>
							<td height="143" width="128"><IMG id="ImgFormPropTitModulos3" border="0" name="ImgFormPropTitModulos3" alt="" src="Imagens/FormularioProposta/FormPropTitNegocios.jpg"
									width="128" height="143"></td>
						</tr>
						<tr>
							<td width="50%"><IMG id="ImgFormPropTracoVar6" border="0" name="ImgFormPropTracoVar6" alt="" src="Imagens/FormularioProposta/FormPropTracoVar.jpg"
									width="128" height="100%"></td>
						</tr>
					</table>
				</td>
				<td rowSpan="2" class="f8FormProp3">
				<%= IIf(ViewState("IdTipoProposta") = 1, _
				    "<ul><li>Relat&oacute;rios de An&aacute;lises de Dados.</li>" & _
				    "<li>Boletim Fatos e Obras.</li>" & _
				    "<li>Mat&eacute;ria de destaque no site da ITC por 7 dias.</li>" & _
				    "<li>Ranking ITC - as 100 Maiores da Constru&ccedil;&atilde;o.</li>" & _
				    "<li>Encontros ITC - Oportunidades de Novos Neg&oacute;cios.</li>" & _
				    "<li>Guia de Neg&oacute;cios ITC.</li>" & _
				    "<li>Banner rotativo.</li></ul>", _
				    "<ul><li>Informa&ccedil;&otilde;es de produtos mais pesquisados e em destaque.</li>" & _
				    "<li>Produtos sustent&aacute;veis.</li>" & _
				    "<li>Refor&ccedil;o de posicionamento de sua marca no mercado.</li>" & _
				    "<li>Aumento de visitas profissionais ao site de sua empresa.</li>" & _
				    "<li>Banner de divulga&ccedil;&atilde;o da empresa na home do Guia.</li></ul>")%>
				</td>	
			</tr>
			<tr>
				<td colSpan="2"><IMG id="ImgFormPropTraco4" border="0" name="ImgFormPropTraco4" alt="" src="Imagens/FormularioProposta/FormPropTraco.jpg"
						width="800" height="8"></td>
			</tr>
			<tr>
				<td height="100%">
					<table cellSpacing="0" cellPadding="0" height="100%">
						<tr>
							<td width="50%"><IMG id="ImgFormPropTracoVar7" border="0" name="ImgFormPropTracoVar7" alt="" src="Imagens/FormularioProposta/FormPropTracoVar.jpg"
									width="128" height="100%"></td>
						</tr>
						<tr>
							<td height="101" width="128"><IMG id="ImgFormPropTitContato" border="0" name="ImgFormPropTitContato" alt="" src="Imagens/FormularioProposta/FormPropTitContato.jpg"
									width="128" height="101"></td>
						</tr>
						<tr>
							<td width="50%"><IMG id="ImgFormPropTracoVar8" border="0" name="ImgFormPropTracoVar8" alt="" src="Imagens/FormularioProposta/FormPropTracoVar.jpg"
									width="128" height="100%"></td>
						</tr>
					</table>
				</td>
				<td class="f8FormProp">
					<b>
						<asp:label id="lblContato" Font-Size="12" ForeColor="#808080" Runat="server"></asp:label><br>
						Departamento de Vendas
					</b>
					<br>
						Tel. <asp:label ID="lblTelefonesVendedor" Runat="server"></asp:label>&nbsp;<asp:label ID="lblTelefoneVendedor2" Runat="server"></asp:label>&nbsp;<asp:label ID="lblCelularVendedor" Runat="server"></asp:label>
					<br>
					E-mail:&nbsp;<asp:label id="lblEmail" Runat="server"></asp:label>
				</td>
			</tr>
			<tr>
				<td colSpan="2"><IMG id="ImgFormPropTraco5" border="0" name="ImgFormPropTraco5" alt="" src="Imagens/FormularioProposta/FormPropTraco.jpg"
						width="800" height="8"></td>
			</tr>
			<tr>
				<td height="100%">
					<table cellSpacing="0" cellPadding="0" height="100%" runat="server" ID="Table4" border="0">
						<tr>
							<td width="50%"><IMG id="ImgFormPropTracoVar9" border="0" name="ImgFormPropTracoVar9" alt="" src="Imagens/FormularioProposta/FormPropTracoVar.jpg"
									width="128" height="100%"></td>
						</tr>
						<tr>
							<td height="100" width="128"><IMG id="ImgFormPropTitModulos4" border="0" name="ImgFormPropTitModulos4" alt="" src="Imagens/FormularioProposta/FormPropTitInfoITC.jpg"
									width="128" height="100"></td>
						</tr>
						<tr>
							<td width="50%"><IMG id="ImgFormPropTracoVar10" border="0" name="ImgFormPropTracoVar10" alt="" src="Imagens/FormularioProposta/FormPropTracoVar.jpg"
									width="128" height="100%"></td>
						</tr>
					</table>
				</td>
				<td rowSpan="2" class="f8FormProp">
					<font color="#F47025"><b>ITC - Informa&ccedil;&otilde;es da Constru&ccedil;&atilde;o</b></font><br>
					R. Conselheiro Brotero, 589 - Sobreloja 2<br>
					Barra Funda - CEP 01154-001 - S&atilde;o Paulo - SP
				</td>
			</tr>
			<tr>
				<td colSpan="2"><IMG id="ImgFormPropTracoLar" border="0" name="ImgFormPropTracoLar" alt="" src="Imagens/FormularioProposta/FormPropTracoLar.jpg"
						width="800" height="7"></td>
			</tr>
			<tr>
				<td><IMG id="ImgFormPropTitInfoITC2" border="0" name="ImgFormPropTitInfoITC2" alt="" src="Imagens/FormularioProposta/FormPropTitInfoITC2.jpg"
					width="128" height="110">
				</td>
				<td>
					<table border="0" width="100%">
						<tr>
							<td width="77%" class="f8FormProp">
								<font color="#F47025" size="3"><b>Bons neg&oacute;cios decorrem de boas parcerias!</b></font>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</body>
</HTML>
