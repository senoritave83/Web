<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FollowUpEmpresa.aspx.vb"  ValidateRequest="False" Inherits="ITC.FollowUpEmpresa"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<div id="Tudo">
		
			<uc1:top id="Top1" runat="server"></uc1:top>
		    
			<h3>SIG's de Empresas</h3>
		    
			<form id="frmCad" runat="server">
				<fieldset>
    				<legend>Filtros</legend>
			      			      					
					<label>Código da Empresa</label>
					<asp:TextBox CssClass="inputG" ID="txtCodigo" Runat="server" MaxLength="100" Width="13%"></asp:TextBox>
					<br />
					
					<label>Nome da Empresa</label>
					<asp:TextBox CssClass="inputG" ID="txtEmpresa" Runat="server" MaxLength="100" Width="75%"></asp:TextBox>
					<br />
			        
					<label>&nbsp;</label>
					<asp:button Text="Pesquisar" id="btnProcurar" runat="server"/>
   				</fieldset>

				<table align="center" width=100% id=tblResult runat=server>
					<tr>
						<td align="center">
							<asp:DataGrid CssClass="Lista" id="dtgFollowUP" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" OnPageIndexChanged="doPaging"  BorderColor="#ffffff" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
								<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
								<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<PagerStyle HorizontalAlign="Center" PageButtonCount=10 ForeColor="white" BackColor="#999999" Mode="NumericPages"></PagerStyle>
									<Columns>
										<asp:TemplateColumn ItemStyle-Width=25>
											<ItemTemplate>
												<a href="followupEmpresalist.aspx?idEmpresa=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><img src='img/ico_status_ok.gif' border=0 ></a>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="<b>Nome Fantasia</b>" ItemStyle-Width=25%>
											<ItemTemplate>
												<a href="followupEmpresalist.aspx?idEmpresa=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><asp:Label ID="Label1" Runat=server ><%# DataBinder.Eval(Container.DataItem, "FANTASIA")%></asp:Label></a>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="<b>Razão Social</b>" ItemStyle-Width=30%>
											<ItemTemplate>
												<a href="followupEmpresalist.aspx?idEmpresa=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><asp:Label ID=lblCodigo Runat=server ><%# DataBinder.Eval(Container.DataItem, "RAZAOSOCIAL")%></asp:Label></a>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="<b>Endereço</b>" ItemStyle-Width=38%>
											<ItemTemplate>
												<a href="followupEmpresalist.aspx?idEmpresa=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><asp:Label ID="Label2" Runat=server ><%# DataBinder.Eval(Container.DataItem, "ENDERECO")%></asp:Label></a>
											</ItemTemplate>
										</asp:TemplateColumn>
										<asp:TemplateColumn HeaderText="<b>UF</b>" ItemStyle-Width=5%>
											<ItemTemplate>
												<a href="followupEmpresalist.aspx?idEmpresa=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><asp:Label ID="lblCNPJ" Runat=server ><%# DataBinder.Eval(Container.DataItem, "ESTADO")%></asp:Label></a>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
							</asp:DataGrid>
						</td>
					</tr>
				</table>
				<table width=100%>
					<tr>
						<td width="90%">&nbsp;</td>
						<td>
							<uc1:BarraNavegacao id="BarraNavegacao" runat="server"></uc1:BarraNavegacao>
						</td>
					</tr>
				</table>
				<br class=clear />
			</form>
			<uc1:Rodape id="Rodapé1" runat="server"></uc1:Rodape>
		</div>
	</body>
</HTML>
