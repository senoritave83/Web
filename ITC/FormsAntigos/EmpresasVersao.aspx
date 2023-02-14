<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EmpresasVersao.aspx.vb" Inherits="ITC.EmpresasVersao"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<div id="Tudo">
			<form runat="Server" id="frm">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Empresas</h3>
				<asp:DataGrid CssClass="Lista" id="dtgEmpresasVersao" PagerStyle-Mode=NumericPages runat="server" AllowPaging="True" OnPageIndexChanged="doPaging" AllowSorting="True" PageSize="15" BorderColor="#ffffff" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
					<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
					<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
					<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
					<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="white" BackColor="#999999" Mode="NumericPages"></PagerStyle>
					<Columns>
						<asp:BoundColumn  HeaderStyle-Font-Bold=True DataField="emv_versao_int" HeaderText="Versão"  ItemStyle-Width=30%></asp:BoundColumn>
						<asp:TemplateColumn ItemStyle-Width=20>
							<ItemTemplate>
								<a href="empresasdet.aspx?Codigo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><img src='img/ico_status_ok.gif' border=0 ></a>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn ItemStyle-VerticalAlign=Middle ItemStyle-HorizontalAlign=Left HeaderText="Fantasia" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True ItemStyle-Width=30%>
							<ItemTemplate>
								<a href="empresasdet.aspx?Codigo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><asp:Label ID=lblCodigo Runat=server Font-Bold=True><%# DataBinder.Eval(Container.DataItem, "Fantasia")%>&nbsp;&nbsp;</asp:Label></a>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn  HeaderStyle-Font-Bold=True DataField="emv_data_dtm" HeaderText="Data de Modificação"  ItemStyle-Width=15%></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
			</form>
			<uc1:Rodape runat="server" ID="Rodape1"></uc1:Rodape>
		</div>
   </body>
</HTML>
