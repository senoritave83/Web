<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Empresas.aspx.vb"  ValidateRequest="False" Inherits="ITC.Empresa" %>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();">
		<div id="Tudo">
			<form runat="Server" id="frm">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Empresas</h3>
				<fieldset>
    				<legend>Filtro de Cadastros</legend>
					
					<label>Nome Fantasia</label>
					<asp:TextBox CssClass="inputG" ID="txtFantasia" Runat="server" Width=40% MaxLength="50"></asp:TextBox>
					<br /><br />
					
					<label>Razão Social</label>
					<asp:TextBox ID="txtRazaoSocial" CssClass="inputG"  MaxLength="50" Width=40% Runat="server"></asp:TextBox>
					<br /><br />
					
					<label>Data Inicial</label>
					<asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" MaxLength="10" Width="100" Runat="server" ID="txtDataInicial" CssClass="inputP" onfocus="displayCalendar(document.forms[0].txtDataInicial,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataInicial,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataInicial,'dd/mm/yyyy',this)" style="cursor:pointer;"></asp:TextBox>
					<br />
					<label>Data Final</label>
					<asp:TextBox onBlur="VerificaData(this);" onKeyDown="FormataData(this, event);" MaxLength="10" Width="100" Runat="server" ID="txtDataFinal" CssClass="inputP" onfocus="displayCalendar(document.forms[0].txtDataFinal,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataFinal,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataFinal,'dd/mm/yyyy',this)" style="cursor:pointer;"></asp:TextBox>
					<br /><br />

					<label>Ordenar por</label>
					<uc1:ComboBox CssClass="inputG" id="cboOrdernar" runat="server"></uc1:ComboBox><br /><br />
					<label>Status</label>
					<uc1:ComboBox CssClass="inputG" id="cboStatus" runat="server"></uc1:ComboBox>
					<br /><br />
									
					<label>&nbsp;</label>
					<asp:button Text="Pesquisar" id="btnProcurar" runat="server"/>
   				</fieldset>
		   		
				<asp:DataGrid CssClass="Lista" id="dtgEmpresas" PagerStyle-Mode=NumericPages runat="server" AllowPaging="True" OnPageIndexChanged="doPaging" AllowSorting="True" PageSize="15" BorderColor="#ffffff" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
					<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
					<FooterStyle BackColor=#ffffff ForeColor=#FFFFFF></FooterStyle>
					<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
					<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="white" BackColor="#999999" Mode="NumericPages"></PagerStyle>
					<Columns>
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
						<asp:BoundColumn  HeaderStyle-Font-Bold=True DataField="RazaoSocial" HeaderText="Razão Social"  ItemStyle-Width=30%></asp:BoundColumn>
						<asp:BoundColumn  HeaderStyle-Font-Bold=True DataField="Endereco" HeaderText="Endereço"  ItemStyle-Width=25%></asp:BoundColumn>
						<asp:BoundColumn  HeaderStyle-Font-Bold=True DataField="Estado" HeaderText="Estado&nbsp;&nbsp;"  ItemStyle-Width=3%></asp:BoundColumn>
						<asp:BoundColumn  HeaderStyle-Font-Bold=True DataField="Atualizacao" HeaderText="Atualização"  ItemStyle-Width=10%></asp:BoundColumn>
					</Columns>
				</asp:DataGrid>
				<table width=100% id="tblNav" runat=server> 
					<tr>
						<td width="90%">&nbsp;</td>
						<td>
							<uc1:BarraNavegacao id="nav" runat="server"></uc1:BarraNavegacao>
						</td>
					</tr>
				</table>
			</form>
			<uc1:Rodape runat="server"></uc1:Rodape>
		</div>
   </body>
</HTML>
