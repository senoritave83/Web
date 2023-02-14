<%@ Register TagPrefix="uc1" TagName="Menu" Src="inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/combobox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="inc/rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UsuariosSistemaDet.aspx.vb"  ValidateRequest="False" Inherits="ITC.UsuariosSistemaDet" %>
<%@ Register TagPrefix="uc2" TagName="ComboBox" Src="inc/ComboBox.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();">
		<form id="frmCad" action="UsuariosSistemaDet.aspx" runat="server">
			<div id="Tudo">
			
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Usuários</h3><br>
				
				<table cellspacing=0 cellpadding=0 width=100% runat="server" bordercolor=#003C6E>
					<tr>
						<td>
							<TABLE id="tblObrasDet" runat="server" width="100%" Align="Center" Border="0"  BGColor="#EFEFEF">
								<TR BGColor="#EFEFEF">
									<TD Align="Center" ColSpan="4" Class="f8" Width="100%"><font color="#EC6400" ><b>Dados Cadastrais</b></font></TD>
								</TR>
								<TR>
									<TD Class="f8" align=right>Código</TD>
									<TD ColSpan=3 Align="Left">
										<asp:Label ID="lblCodigo" Runat="server" CssClass="f8"></asp:Label>&nbsp;
										<asp:Label ID="lblCodigoInflate" Runat="server" CssClass="f8"></asp:Label>
									</TD>
								</TR>
								<TR>
									<TD Class="f8" align=right>Nome</TD>
									<TD ColSpan=3 Align="Left">
										<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtNome" MaxLength="50" ReadOnly=True></asp:TextBox>
										<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator1" Runat="server" ErrorMessage="*" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
									</TD>
								</TR>
								<TR>
									<TD Class="f8" align=right>Login</TD>
									<TD ColSpan=3 Align="Left">
										<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtLogin" MaxLength="20" ReadOnly=True></asp:TextBox>
										<asp:RequiredFieldValidator CssClass="f8" ID="Requiredfieldvalidator2" Runat="server" ErrorMessage="*" ControlToValidate="txtLogin"></asp:RequiredFieldValidator>
									</TD>
								</TR>
								<TR>
									<TD Class="f8" align=right>E-Mail</TD>
									<TD ColSpan=3 Align="Left">
										<asp:TextBox CssClass="f8" runat="server" Width="90%" ID="txtEmail" ReadOnly=True></asp:TextBox>
									</TD>
								</TR>
								<TR>
									<TD Class="f8" align=right>Cargo</TD>
									<TD ColSpan=3 Align="Left">
										<asp:DropDownList cssClass=f8 id="cboIdCargo" runat="server" DataTextField="DESCRICAOCARGO" DataValueField="IDCARGO"></asp:DropDownList>
									</TD>
								</TR>
								<TR>
									<TD Class="f8" align=right>Grupo</TD>
									<TD Align="Left">
										<asp:DropDownList cssClass=f8 id="cboIdGrupo" runat="server" DataTextField="DESCRICAOGRUPO" DataValueField="IDGRUPO"></asp:DropDownList>
									</TD>
									<TD Class="f8" align=right>Tipo</TD>
									<TD Align="Left">
										<asp:DropDownList cssClass=f8 id="cboTipoUsuario" runat="server"></asp:DropDownList>
									</TD>
								</TR>
								<TR>
									<TD ColSpan=3 Align=Right>
										<asp:button id="btnReset" Text="Renovar Senha" Runat="server" ></asp:button>
									</TD>
								</TR>
							</TABLE>
						</td>
					</tr>
				</table>
				<br>
				<table align="center" cellspacing=0 cellpadding=0 width=100% runat=server>
					<tr>
						<td align="right">
							<asp:datagrid id="dtgGrid" DataKeyField="ACA_ACAO_INT_PK" CssClass="Lista" runat="server" BorderColor="#ffffff" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="99%">
								<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
								<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<PagerStyle HorizontalAlign="Center" PageButtonCount=10 ForeColor="white" BackColor="#999999" Mode="NumericPages"></PagerStyle>
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
							<asp:button id="btnVoltar" Text="Voltar" Runat="server" ></asp:button>
						</td>
					</tr>
				</table>
				<uc1:rodape id="Rodape1" runat="server"></uc1:rodape>
			</div>
		</form>
	</body>
</HTML>
