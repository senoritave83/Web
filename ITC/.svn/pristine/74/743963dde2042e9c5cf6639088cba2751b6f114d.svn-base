<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Associados.aspx.vb"  ValidateRequest="False" Inherits="ITC.Associados"%>
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
				<h3>Cadastro de Associados</h3>
				
				<fieldset>
    				<legend>Filtros</legend>
					
					<label>Código ITC</label>
					<asp:TextBox CssClass="inputG"  ID="txtCodigoITC" Style="width:20%" Runat="server" MaxLength="20"></asp:TextBox>
					<br />
					
					<label>CNPJ</label>
					<asp:TextBox ID="txtCNPJ" CssClass="inputG" onKeyDown="FormataCNPJ(this, event);" MaxLength="18" Style="width:17%"  Runat="server"></asp:TextBox>
					<br />
					
					<label>Razão Social ou Fantasia</label>
					<asp:TextBox CssClass="inputG" ID="txtRazaoSocial" Runat="server" MaxLength="100" Width="62%"></asp:TextBox>
					<br />
			        <br />
					<label>&nbsp;</label>
					<asp:button Text="Pesquisar" id="btnProcurar" runat="server"></asp:button>
   				</fieldset>

				<table align="center" cellspacing=0 cellpadding=0 width=100% id=tblResult runat=server>
					<tr>
						<td align="center">
							<asp:DataGrid CssClass="Lista" id="dtgAssociados" runat="server" AllowPaging="True" AllowSorting="True" PageSize="10" OnPageIndexChanged="doPaging"  BorderColor="#ffffff" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
							<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
							<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
							<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
							<PagerStyle HorizontalAlign="Center" PageButtonCount=10 ForeColor="white" BackColor="#999999" Mode="NumericPages"></PagerStyle>
								<Columns>
									<asp:TemplateColumn ItemStyle-Width=2%>
										<ItemTemplate>
											<a href="AssociadosDet.aspx?Codigo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><img src='img/ico_status_ok.gif' border=0 ></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="Código ITC" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True ItemStyle-Width=10%>
										<ItemTemplate>
											<a href="AssociadosDet.aspx?Codigo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><asp:Label ID="Label1" Runat=server ><%# Right("000000" & DataBinder.Eval(Container.DataItem, "Codigo"), 6)%></asp:Label></a>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="RazaoSocial" HeaderText="Razão Social" HeaderStyle-Font-Bold=True ItemStyle-Width=25%></asp:BoundColumn>
									<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="Fantasia" HeaderText="Nome Fantasia" HeaderStyle-Font-Bold=True ItemStyle-Width=25%></asp:BoundColumn>
									<asp:BoundColumn ItemStyle-VerticalAlign=Middle DataField="CNPJ" HeaderText="CNPJ" HeaderStyle-Font-Bold=True ItemStyle-Width=15%></asp:BoundColumn>
								</Columns>
							</asp:DataGrid>
						</td>
					</tr>
				</table>
				<table width=100% id=tblNav runat=server>
					<tr>
						<td width="90%">&nbsp;</td>
						<td>
							<uc1:BarraNavegacao id="Barranavegacao1" runat="server"></uc1:BarraNavegacao>
						</td>
					</tr>
				</table>

				<br class=clear />
				<uc1:Rodape id="Rodapé" runat="server"></uc1:Rodape>
			</div>
		</form>
	</body>
</HTML>
