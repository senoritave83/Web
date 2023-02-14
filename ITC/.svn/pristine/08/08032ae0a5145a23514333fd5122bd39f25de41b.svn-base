<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Produtos.aspx.vb"  ValidateRequest="False" Inherits="ITC.Produtos"%>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<form id="frmCad" runat="server">
			<div id="Tudo">
				
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Produtos</h3>
				<br class=clear />
				
				<fieldset>
    				<legend>Filtro de Produtos</legend>
					
					<label>Descrição do Produto</label>
					<asp:TextBox CssClass="inputG" ID="txtProduto" Runat="server" MaxLength="100" Width="100%"></asp:TextBox>
					<br /><br />
					
					<label>&nbsp;</label>
					<p align=right><asp:Button CssClass=f8 ID="btnProcurar" Runat="server" Text=Pesquisar></asp:Button></p>
   				</fieldset>
				<br class=clear />
				
				<table cellspacing=0 cellpadding=0 width=100%>
					<tr>
						<td>
							<asp:DataGrid id="dtgProdutos" CssClass="f8" runat="server" AllowPaging="True" PageSize=15 AllowSorting="False" backcolor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
								<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF Font-Bold=True></HeaderStyle>
								<FooterStyle BackColor=#003C6E ForeColor=#FFFFFF></FooterStyle>
								<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
								<Columns>
									<asp:TemplateColumn ItemStyle-Width=25 HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="produtosdet.aspx?p=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdProduto"))%>"><img src='img/ico_status_ok.gif' border=0 ></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderStyle-HorizontalAlign=Center HeaderText="DESCRIÇÃO DO PRODUTO" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True>
										<ItemTemplate>
											<a href="produtosdet.aspx?p=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "IdProduto"))%>"><asp:Label ID=lblCodigo Runat=server ><%# DataBinder.Eval(Container.DataItem, "DescricaoProduto")%></asp:Label></a> 
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Visible=False HorizontalAlign="Center" PageButtonCount=15 ForeColor="white" BackColor="#999999" Mode="NumericPages"></PagerStyle>
							</asp:DataGrid>
						</td>
					</tr>
				</table>
				<table width=100% id="tblNav" runat=server> 
					<tr>
						<td width="90%">&nbsp;</td>
						<td>
							<uc1:BarraNavegacao id="nav" runat="server"></uc1:BarraNavegacao>
						</td>
					</tr>
				</table>
				<table width=100%> 
					<tr>
						<td width="45%">&nbsp;</td>
						<td width="55%">
							<asp:Button ID=btnIncluir Text=Incluir Runat=server></asp:Button>
						</td>
					</tr>
				</table>
			</form>
			<uc1:Rodape runat="server" ID="Rodape"></uc1:Rodape>
		</div>
   </body>
</HTML>
