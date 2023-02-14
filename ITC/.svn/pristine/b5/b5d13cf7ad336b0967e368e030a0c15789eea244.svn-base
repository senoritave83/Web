<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UsuariosSistema.aspx.vb"  ValidateRequest="False" Inherits="ITC.UsuariosSistema"%>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="inc/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="inc/combobox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="inc/rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraBotoes" Src="inc/BarraBotoes.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();">
		<form id="frmCad" runat="server" action="UsuariosSistema.aspx">
			<div id="Tudo">
				
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Usuários</h3>

				<table align="center" cellspacing=0 cellpadding=0 width=100% id=tblResult runat=server>
					<tr>
						<td align="center">
							<asp:DataGrid id="dtgUsuarios"  CssClass="Lista" runat="server" BorderColor="#ffffff" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="99%">
								<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
								<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<PagerStyle HorizontalAlign="Center" PageButtonCount=10 ForeColor="white" BackColor="#999999" Mode="NumericPages"></PagerStyle>
								<Columns>
									<asp:TemplateColumn ItemStyle-Width=2%>
										<ItemTemplate>
											<a href="usuariossistemadet.aspx?idusuario=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "USU_USUARIO_INT_PK"))%>"><img src='img/ico_status_ok.gif' border=0 ></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="Nome do Usuário" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="usuariossistemadet.aspx?idusuario=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "USU_USUARIO_INT_PK"))%>"><asp:Label ID=lblCodigo Runat=server ><%# DataBinder.Eval(Container.DataItem, "USU_USUARIO_CHR")%></asp:Label></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="USU_LOGIN_CHR" HeaderText="Login" HeaderStyle-Font-Bold=True ItemStyle-Width=25%></asp:BoundColumn>
									<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="DESCRICAOGRUPO" HeaderText="Grupo" HeaderStyle-Font-Bold=True ItemStyle-Width=25%></asp:BoundColumn>
									<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="tipo" HeaderText="Tipo" HeaderStyle-Font-Bold=True ItemStyle-Width=15%></asp:BoundColumn>
								</Columns>
							</asp:DataGrid>
						</td>
					</tr>
				</table>
				<uc1:Rodape id="Rodape1" runat="server"></uc1:Rodape>
			</div>
		</form>		
	</body>
</HTML>
