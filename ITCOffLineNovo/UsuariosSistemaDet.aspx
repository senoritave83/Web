<%@ Register TagPrefix="uc2" TagName="ComboBox" Src="inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="inc/rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/combobox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="inc/Menu.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UsuariosSistemaDet.aspx.vb" ValidateRequest="False" Inherits="ITCOffLine.UsuariosSistemaDet" %>
<HTML>
<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
	<!-- #include file='inc/header.aspx' -->
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="GridLayout">
	
		<script language=javascript>
	
			function MascaraTelefone (keypress, objeto)
			{
				campo = eval (objeto);

				separador1 = '(';
				separador2 = ')';
				separador3 = '-';
				conjunto1 = 0;
				conjunto2 = 3;
				conjunto3 = 8;
				
				if (campo.value.length == conjunto1){
					campo.value = campo.value + separador1;
				}
				if (campo.value.length == conjunto2){
					campo.value = campo.value + separador2;
				}
				if (campo.value.length == conjunto3){
					campo.value = campo.value + separador3;
				}
			}
			
		</script>
		<table class="TableSup" id="tbl1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
			border="0">
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
			<tr bgColor="#ffffff" height="*">
				<td vAlign="top" align="center"><br>
					<form id="frmCad" action="UsuariosSistemaDet.aspx" runat="server">
						<img src="imagens/TituloCadastroUsuarios.jpg" border="0" width="443" height="40">
						<br>
						<table cellspacing="0" cellpadding="0" width="70%" border="1" bordercolor="#003c6e">
							<tr>
								<td>
									<asp:table id="tblObrasDet" runat="server" width="100%" HorizontalAlign="Center" BorderWidth="0"
										BackColor="#EFEFEF">
										<asp:TableRow BackColor="#003C6E">
											<asp:TableCell HorizontalAlign="Center" ColumnSpan="3" CssClass="f8" ForeColor="#FFFFFF" Width="100%"
												Text="DADOS CADASTRAIS"></asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell ColumnSpan=1 CssClass="f8" Width="30%" Text="Código"></asp:TableCell>
											<asp:TableCell HorizontalAlign="Left">
												<asp:Label ID="lblCodigo" Runat="server" CssClass="f8"></asp:Label>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell ColumnSpan=1 CssClass="f8" Width="30%" Text="Nome&nbsp;"><asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator1" Runat="server" ErrorMessage="O Nome é obrigatório" ControlToValidate="txtNome"></asp:RequiredFieldValidator></asp:TableCell>
											<asp:TableCell HorizontalAlign="Left">
												<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtNome" MaxLength="50"></asp:TextBox>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell  ColumnSpan=1 CssClass="f8" Width="30%" Text="Login&nbsp;"><asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator2" Runat="server" ErrorMessage="O login é obrigatório" ControlToValidate="txtLogin"></asp:RequiredFieldValidator></asp:TableCell>
											<asp:TableCell HorizontalAlign="Left">
												<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtLogin" MaxLength="20"></asp:TextBox>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell ColumnSpan=1 CssClass="f8" Width="30%" Text="E-Mail&nbsp;"><asp:RequiredFieldValidator Display="Dynamic" CssClass="f8" ID="Requiredfieldvalidator3" Runat="server" ErrorMessage="E-mail é obrigatório"
													ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
												<asp:RegularExpressionValidator ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" CssClass="f8" 
													Runat="server" ErrorMessage="E-mail Inválido" ControlToValidate="txtEmail" ID="Regularexpressionvalidator1"></asp:RegularExpressionValidator></asp:TableCell>
											<asp:TableCell HorizontalAlign="Left">
												<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtEmail" MaxLength="200"></asp:TextBox><br>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell ColumnSpan=1 CssClass="f8" Width="30%" Text="Fone 1&nbsp;"><asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator4" Runat="server" ErrorMessage="Fone 1 é obrigatório" ControlToValidate="txtTelefoneUsuario1"></asp:RequiredFieldValidator></asp:TableCell>
											<asp:TableCell HorizontalAlign="Left" Width="60%">
												<asp:TextBox CssClass="f8" runat="server" Width="30%" ID="txtTelefoneUsuario1" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox><br>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell ColumnSpan=1 CssClass="f8" Width="30%" Text="Fone 2&nbsp;"></asp:TableCell>
											<asp:TableCell HorizontalAlign="Left" Width="60%">
												<asp:TextBox CssClass="f8" runat="server" Width="30%" ID="txtTelefoneUsuario2" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox><br>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell ColumnSpan=1 CssClass="f8" Width="30%" Text="Celular"></asp:TableCell>
											<asp:TableCell HorizontalAlign="Left" Width="60%">
												<asp:TextBox CssClass="f8" runat="server" Width="30%" ID="txtCelularUsuario" MaxLength="13" onkeypress="MascaraTelefone(window.event.keyCode, this);"></asp:TextBox><br>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell ColumnSpan=1 CssClass="f8" Width="30%" Text="Cargo"></asp:TableCell>
											<asp:TableCell HorizontalAlign="Left" Width="60%">
												<uc1:ComboBox cssClass="f8" id="cboIdCargo" runat="server"></uc1:ComboBox>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell ColumnSpan=1 CssClass="f8" Width="30%" Text="Grupo"></asp:TableCell>
											<asp:TableCell HorizontalAlign="Left" Width="60%">
												<uc1:ComboBox cssClass="f8" id="cboIdGrupo" runat="server"></uc1:ComboBox>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell ColumnSpan=1 CssClass="f8" Width="30%" Text="Tipo"></asp:TableCell>
											<asp:TableCell HorizontalAlign="Left" Width="60%">
												<uc1:ComboBox cssClass="f8" id="cboTipoUsuario" runat="server" autopostback="true"></uc1:ComboBox>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow ID="Especifico">
											<asp:TableCell Visible=False CssClass="f8" Width="30%" Text="Gestor" ID="lblGestor"></asp:TableCell>
											<asp:TableCell Visible=False ID="lblGestorCbo" HorizontalAlign="Left" Width="60%">
												<uc1:ComboBox cssClass="f8" id="cboGestor" runat="server"></uc1:ComboBox>
											</asp:TableCell>
											<asp:TableCell Visible=False CssClass="f8" Width="30%" Text="Área" ID="lblArea"></asp:TableCell>
											<asp:TableCell Visible=False ID="lblAreaCbo" HorizontalAlign="Left" Width="60%">
												<uc1:ComboBox cssClass="f8" id="cboAreaITC" runat="server"></uc1:ComboBox>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell ColumnSpan="2">
												<asp:Literal Runat="server" ID="ltJavaScriptAlteraSenha" Text=""></asp:Literal>
											</asp:TableCell>
										</asp:TableRow>
										<asp:TableRow>
											<asp:TableCell ColumnSpan=2>
												<uc1:BarraBotoes id="Barra" runat="server"></uc1:BarraBotoes>
											</asp:TableCell>
											<asp:TableCell HorizontalAlign="Right">
												<asp:imagebutton id="btnReset" CssClass="f8" Runat="server" ImageUrl="Imagens/BotaoRenovarSenha.gif"
													BorderStyle="None"></asp:imagebutton>
											</asp:TableCell>
										</asp:TableRow>
									</asp:table>
									<tr bgColor="#EFEFEF">
										<td colspan="3" align='center'><asp:Label class="f10" ForeColor="red" Runat="server" ID="lblMensagem"></asp:Label></td>
									</tr>
								</td>
							</tr>
						</table>
						<br>
						<table width="70%" bgColor="#003366">
							<tr>
								<td align="right">
									<asp:datagrid id="dtgGrid" DataKeyField="ACA_ACAO_INT_PK" CssClass="f8" runat="server" BorderColor="#999999" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
										<HeaderStyle BackColor=#003C6E ForeColor=#FFFFFF></HeaderStyle>
										<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
										<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
										<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
										<Columns>
											<asp:TemplateColumn HeaderText='Habilitar'>
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
						<br>
					</form>
				</td>
			</tr>
			<tr vAlign="bottom" height="20">
				<td width="100%"><uc1:rodape id="Rodape1" runat="server"></uc1:rodape></td>
			</tr>
		</table>
	</body>
</HTML>
