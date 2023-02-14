<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpresasDet.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.EmpresasDet" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register src="~/inc/BarraBotoes2.ascx" tagname="BarraBotoes2" tagprefix="uc2" %>

<HTML>
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
		<table height="100%" cellSpacing="0" cellPadding="0" width="100%">
						<tr>
							<td vAlign="top" align="center">
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
							<td vAlign="top" align="center">
								<form id="frmCad" runat="server">
									<IMG src="imagens/TituloCadastroEmpresas.jpg" border="0" width="354" height="40">
									<table cellspacing="0" cellpadding="0" width="90%" border="1" bordercolor="#003c6e">
										<tr>
											<td>
												<asp:table id="tblEmpresasDet" runat="server" BackColor="#EFEFEF" CellSpacing="0" CellPadding="2"
													width="100%">
													<asp:TableRow>
														<asp:TableCell ColumnSpan="4" CssClass="f10" Width="30%" Text="<b>DADOS CADASTRAIS</b>" HorizontalAlign="Center" 
															BackColor="#003C6E" ForeColor="#FFFFFF"></asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="C&oacute;digo"></asp:TableCell>
														<asp:TableCell ColumnSpan="3">
															<asp:Label ID="lblCodigo" Runat="server" CssClass="f8"></asp:Label>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="Data"></asp:TableCell>
														<asp:TableCell>
															<asp:textbox onKeyDown="return FormataData(this, event);" onBlur="VerificaData(this);" MaxLength="10" 
																ID="txtAtualizacao" Runat="server" CssClass="f8"></asp:textbox>
															<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator8" Runat="server" ErrorMessage="*" ControlToValidate="txtAtualizacao"></asp:RequiredFieldValidator>
															<asp:Label ID="Label1" Runat="server" CssClass="f8"></asp:Label>
															<asp:Label ID="lblvendedor" Runat="server" CssClass="f8">&nbsp;&nbsp;&nbsp;&nbsp;Vendedor&nbsp;&nbsp;</asp:Label>
															<uc1:ComboBox id="cboVendedor" runat="server"></uc1:ComboBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="Fantasia"></asp:TableCell>
														<asp:TableCell ColumnSpan="3">
															<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtFantasia" MaxLength="255"></asp:TextBox>
															<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator2" Runat="server" ErrorMessage="*" ControlToValidate="txtFantasia"></asp:RequiredFieldValidator>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="Empresa"></asp:TableCell>
														<asp:TableCell ColumnSpan="3">
															<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtRazaoSocial" MaxLength="255"></asp:TextBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="Endere&ccedil;o"></asp:TableCell>
														<asp:TableCell ColumnSpan="3">
															<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtEndereco" MaxLength="255"></asp:TextBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="Bairro"></asp:TableCell>
														<asp:TableCell ColumnSpan="3">
															<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtComplemento" MaxLength="255"></asp:TextBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="UF"></asp:TableCell>
														<asp:TableCell>
															<uc1:ComboBox autopostback="true" CssClass="f8" id="cboEstado" runat="server"></uc1:ComboBox>
														</asp:TableCell>
														<asp:TableCell CssClass="f8" Width="30%" Text="Cidade"></asp:TableCell>
														<asp:TableCell>
															<uc1:ComboBox CssClass="f8" id="cboCidade" runat="server"></uc1:ComboBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="CEP"></asp:TableCell>
														<asp:TableCell>
															<asp:TextBox onKeyDown="javascript:FormataCEP(this, event);" CssClass="f8" runat="server" Width="250px" 
																ID="txtCEP" MaxLength="9"></asp:TextBox>
														</asp:TableCell>
														<asp:TableCell CssClass="f8" Width="30%" Text="CNPJ"></asp:TableCell>
														<asp:TableCell>
															<asp:TextBox onKeydown="JavaScript:FormataCNPJ(this,event);" CssClass="f8" runat="server" Width="250px" ID="txtCNPJ" MaxLength="18"></asp:TextBox>
															<asp:CustomValidator Runat="server" ErrorMessage="*" CssClass="f8" ControlToValidate="txtCNPJ" ClientValidationFunction="CPFValidate"></asp:CustomValidator>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="IE"></asp:TableCell>
														<asp:TableCell>
															<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtInscricaoEstadual" MaxLength="50"></asp:TextBox>
														</asp:TableCell>
														<asp:TableCell CssClass="f8" Width="30%" Text="IM"></asp:TableCell>
														<asp:TableCell>
															<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtInscricaoMunicipal" MaxLength="50"></asp:TextBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="Atividade"></asp:TableCell>
														<asp:TableCell ColumnSpan="3">
															<uc1:ComboBox CssClass="f8" id="cboIdAtividade" runat="server"></uc1:ComboBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="Pesquisador"></asp:TableCell>
														<asp:TableCell>
															<uc1:ComboBox CssClass="f8" id="cboPesquisador" runat="server"></uc1:ComboBox>
														</asp:TableCell>
														<asp:TableCell CssClass="f8" Width="30%" Text="Nº da Revisao"></asp:TableCell>
														<asp:TableCell>
															<asp:TextBox CssClass="f8" runat="server" Width="250px" ID="txtNrDaRevisao" MaxLength="0"></asp:TextBox>
															<asp:CompareValidator CssClass="f8" id="Comparevalidator2" runat="server" ErrorMessage="*" ControlToValidate="txtNrDaRevisao" 
																Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="Web Site"></asp:TableCell>
														<asp:TableCell ColumnSpan="3">
															<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtWebSite" MaxLength="150"></asp:TextBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="E-Mail"></asp:TableCell>
														<asp:TableCell ColumnSpan="3">
															<asp:TextBox CssClass="f8" runat="server" Width="330px" ID="txtEmail" MaxLength="60"></asp:TextBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="E-Mail Secundário"></asp:TableCell>
														<asp:TableCell ColumnSpan="3">
															<asp:TextBox CssClass="f8" runat="server" Width="330px" ID="txtEmail2" MaxLength="60"></asp:TextBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="Endereço Skype"></asp:TableCell>
														<asp:TableCell ColumnSpan="3">
															<asp:TextBox CssClass="f8" runat="server" Width="330px" ID="txtSkype" MaxLength="60"></asp:TextBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text="Status"></asp:TableCell>
														<asp:TableCell ColumnSpan="3">
															<uc1:ComboBox id="cboStatus" runat="server"></uc1:ComboBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Text="Observação" Wrap="False"></asp:TableCell>
														<asp:TableCell ColumnSpan="3" Wrap="False" VerticalAlign="Middle" HorizontalAlign="left">
															<asp:TextBox CssClass="f8" ID="txtObservacao" Runat="server" TextMode="MultiLine" Rows="3" Width="90%"></asp:TextBox>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell CssClass="f8" Width="30%" Text=""></asp:TableCell>
														<asp:TableCell ColumnSpan="2">
															<asp:CheckBox CssClass="f8" Runat="server" ID="chkDemo" Text="Demo"></asp:CheckBox>
														</asp:TableCell>
														<asp:TableCell HorizontalAlign="Right">
                                                            <uc2:BarraBotoes2 ID="BarraBotoes21" runat="server"></uc2:BarraBotoes2>
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell ColumnSpan="4">
															<marquee>
																<asp:Label CssClass="f8" Visible="True" ForeColor="#FF0000" ID="lblMensagem" Runat="server">CADASTRO INCOMPLETO - Verificar cadastro de contatos</asp:Label>
															</marquee>
														</asp:TableCell>
													</asp:TableRow>
												</asp:table>
											</td>
										</tr>
									</table>
									<br>
									<table cellspacing="0" cellpadding="0" width="90%" border="1" bordercolor="#003c6e">
										<tr>
											<td>
												<asp:table id="Table1" runat="server" BackColor="#EFEFEF" CellSpacing="0" CellPadding="0" width="100%">
													<asp:TableRow BackColor="#003C6E">
														<asp:TableCell ForeColor="#FFFFFF" HorizontalAlign="Center" CssClass="f10" Text="<b>CONTATOS NA EMPRESA</b>" ColumnSpan="3" />
														<asp:TableCell HorizontalAlign="right">
															<asp:ImageButton CssClass="f8" ID='btnAdicionarContato' Runat="server" ImageUrl="Imagens/BotaoNovoContato.gif" BorderStyle="None" CausesValidation="False" />
														</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell HorizontalAlign="Center" ColumnSpan="4" Height="5">&nbsp;</asp:TableCell>
													</asp:TableRow>
													<asp:TableRow>
														<asp:TableCell HorizontalAlign="Center" ColumnSpan="4">
															<asp:DataGrid id="dtgContatos" CssClass="f8" runat="server" AllowPaging="False" AllowSorting="False" 
																BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
																<HeaderStyle BackColor="#003C6E" ForeColor="#FFFFFF"></HeaderStyle>
																<FooterStyle BackColor="#003C6E" ForeColor="#FFFFFF"></FooterStyle>
																<AlternatingItemStyle BackColor="#EFEFEF"></AlternatingItemStyle>
																<PagerStyle HorizontalAlign="Center" PageButtonCount="15" ForeColor="Black" BackColor="#999999"
																	Mode="NumericPages"></PagerStyle>
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
														</asp:TableCell>
													</asp:TableRow>
												</asp:table>
											</td>
										</tr>
									</table>
								</form>
							</td>
						</tr>
					</table>
					<script language="vbscript">
						Sub CPFValidate(source, arguments)
							Numero = arguments.value
							Numero = replace(replace(replace(Numero, ".", ""), "-", ""), "/", "")
							CNPJ = (Len(Numero) = 14)
							Temp = Mid(Numero, 1, len(Numero) - 2)
							for j = 1 to 2 
								k = 2
								Soma = 0
								i = Len(Temp)
								Do While i >= 1
									Y = Cint(Mid(Temp, i, 1))
									Soma = Soma + (Y * k)
									k = k + 1
									if k > 9 and CNPJ then k = 2
									i = i - 1
								loop
								Digito = 11 - (Soma mod 11)
								if Digito >= 10 then Digito = 0
								Temp = Temp & CStr(Digito)
							next
							arguments.IsValid = (temp = Numero)
							end sub
							
					</script>		
			<uc1:rodape id="Rodape1" runat="server"></uc1:rodape>
	</body>
</HTML>
