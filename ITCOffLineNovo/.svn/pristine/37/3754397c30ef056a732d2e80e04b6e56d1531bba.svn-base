<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="Inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="Inc/BarraBotoes2.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UsuariosDet.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.UsuariosDet" %>
<HTML>
	<!-- #include file='inc/header.aspx' -->
	<script language="javascript">
	
		var p_Checked = false;
	
		function GetConfirm(text)
		{
			return confirm(text);
		}
	
		function checkAll(p_Obj)
		{
		
			p_Checked = !p_Checked;
			for (var i=0;i<frmCad.elements.length;i++)
				{
					var e = frmCad.elements[i];
					if ((e.type=='checkbox'))
						{
							e.checked = p_Checked;
						}
				}
		}
				
		</script>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout" background="imagens/itc_fundo.gif">
		<table height="450" cellSpacing="0" cellPadding="0" width="100%">
			<tr>
				<td vAlign="top" align="middle">
					<table cellSpacing="0" width="100%" bgColor="#809EB7">
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
						<img src="imagens/TituloControleUsuarios.jpg" border="0" width="443" height="40">
						<br>
						<table width="60%" align="Center" border="0" bgcolor="#003C6E">
							<tr bgcolor="#003C6E">
								<td align="Center" class="f8" Width="100%"><font color="White"><b>DADOS CADASTRAIS</b></font></td>
							</tr>
							<tr>
								<td width="100%" align="center">
									<table width="100%" align="Center" border="0" bgcolor="#EFEFEF">
										<tr>
											<td class="f8" Width="30%">Código</td>
											<td align="Left" colspan="3">
												<asp:Label ID="lblCodigo" Runat="server" class="f8"></asp:Label>&nbsp;
											</td>
										</tr>
										<tr>
											<td class="f8" Width="30%">Nome</td>
											<td align="Left" colspan="2">
												<asp:TextBox class="f8" runat="server" Width="90%" ID="txtNome" MaxLength="50"></asp:TextBox>
												<asp:RequiredFieldValidator class="f8" ID="Requiredfieldvalidator1" Runat="server" ErrorMessage="*" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
											</td>
										</tr>
										<tr>
											<td class="f8" Width="30%">Login</td>
											<td align="Left" colspan="2">
												<asp:TextBox class="f8" runat="server" Width="90%" ID="txtLogin" MaxLength="20"></asp:TextBox>
												<asp:RequiredFieldValidator class="f8" ID="Requiredfieldvalidator2" Runat="server" ErrorMessage="*" ControlToValidate="txtLogin"></asp:RequiredFieldValidator>
											</td>
										</tr>
										<tr>
											<td class="f8" Width="30%">E-Mail</td>
											<td align="Left" Width="60%" colspan="2">
												<asp:TextBox class="f8" runat="server" Width="90%" ID="txtEmail" MaxLength="200"></asp:TextBox>
												<asp:RequiredFieldValidator class="f8" ID="Requiredfieldvalidator4" Runat="server" ErrorMessage="*" ControlToValidate="txtEmpresa"></asp:RequiredFieldValidator>
												<asp:RegularExpressionValidator ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" class="f8" 
																			Runat="server" ErrorMessage="E-mail Inválido" ControlToValidate="txtEmail" ID="Regularexpressionvalidator1"></asp:RegularExpressionValidator>
											</td>
										</tr>
										<tr>
											<td class="f8" Width="30%">Empresa</td>
											<td align="Left" Width="60%" colspan="2">
												<asp:TextBox class="f8" runat="server" Width="90%" ID="txtEmpresa" MaxLength="50"></asp:TextBox>
												<asp:RequiredFieldValidator class="f8" ID="Requiredfieldvalidator3" Runat="server" ErrorMessage="*" ControlToValidate="txtEmpresa"></asp:RequiredFieldValidator>
											</td>
										</tr>
										<tr>
											<td class="f8" Width="30%">Cargo</td>
											<td align="Left" Width="60%" colspan="2">
												<uc1:ComboBox id="cboIdCargo" runat="server"></uc1:ComboBox>
											</td>
										</tr>
										<tr>
											<td class="f8" Width="30%">Tipo de Usuário</td>
											<td align="Left">
												<uc1:ComboBox id="cboTipoUsuario" autopostback="True" runat="server" ></uc1:ComboBox>
											</td>
											<td class="f8" Width="30%">
												<asp:ImageButton class="f8" Visible=False ID="btnPermissaoGestor" Runat="server" ImageUrl="Imagens/BotaoPermissoesGestor.gif" BorderStyle="None"></asp:ImageButton>
											</td>
										</tr>
										<tr ID="Especifico" runat="Server">
											<td Visible=False class="f8" Width="30%" ID="lblGestor" runat="Server">Gestor</td>
											<td Visible=False ID="lblGestorCbo" align="Left" Width="60%" runat="server">
												<uc1:ComboBox cssclass="f8" id="cboGestor" runat="server"></uc1:ComboBox>
											</td>
											<td>&nbsp;</td>
										</tr>
										<tr>
											<td class="f8" Width="30%">Situação</td>
											<td align="Left" Width="60%" colspan="2">
												<uc1:ComboBox id="cboIdSituacao" runat="server"></uc1:ComboBox>
											</td>
										</tr>
										<tr>
											<td colspan="3" align="Right">
												<uc1:BarraBotoes id="Barra" runat="server"></uc1:BarraBotoes>
											</td>
										</tr>
										<tr>
											<td colspan="3" align='center'><asp:Label class="f10" ForeColor="red" Runat="server" ID="lblMensagem"></asp:Label></td>
										</tr>
										<tr>
											<td colspan="3" align="Center">
												<table width="100%">
													<tr align="center">
														<td width="49%" align="center">
															<asp:ImageButton class="f8" ID="btnRedefinirSenha" Runat="server" ImageUrl="Imagens/BotaoRenovarSenha.gif" BorderStyle="None"></asp:ImageButton>
														</td>
														<td width="2%">&nbsp;</td>
														<td width="49%" align="center">
															<asp:ImageButton class="f8" ID="btnPermissoes" Runat="server" ImageUrl="Imagens/BotaoPermissoesUsuario.gif" BorderStyle="None"></asp:ImageButton>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<br>
						<br>
						<table width="70%" bgColor="#003C6E">
							<tr>
								<td align="right">
									<asp:datagrid id="dtgGrid" DataKeyField="ACA_ACAO_INT_PK" CssClass="f8" runat="server" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
										<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
										<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
										<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
										<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="<a href='javascript:checkAll();'><font color='White'>Habilitar</font></a>">
												<ItemTemplate>
													<asp:CheckBox Runat='server' id='chkPermissao' Checked='<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMISSAO")=1, true, false)%>'>
													</asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText='Seção'>
												<ItemTemplate>
													<font class=f8 color="<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMISSAO")= 0, "#FF0000", "#000000") %>"><%# DataBinder.Eval(Container.DataItem, "aca_Secao_chr")%></font>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText='Ação'>
												<ItemTemplate>
													<font class=f8 color="<%# Microsoft.VisualBasic.IIF(DataBinder.Eval(Container.DataItem, "PERMISSAO")= 0, "#FF0000", "#000000") %>"><%# DataBinder.Eval(Container.DataItem, "aca_Acao_chr")%></font>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
									</asp:datagrid>
									<asp:imagebutton id="btnGravar" CssClass="f8" Runat="server" ImageUrl="Imagens/BotaoSalvarPermissoes.gif" BorderStyle="None"></asp:imagebutton>
								</td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
		</table>
		<asp:Literal Runat="server" ID="ltJavaScriptAlteraSenha" Text=""></asp:Literal>
		<uc1:rodape id="Rodape1" runat="server"></uc1:rodape>
	</body>
</HTML>
