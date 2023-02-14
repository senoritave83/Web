<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Obras.aspx.vb" ValidateRequest="False" Inherits="ITC.Obras"%>
<%@ Register TagPrefix="uc1" TagName="Rodape" Src="Inc/Rodape.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Top" Src="Inc/Top.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ComboBox" Src="Inc/ComboBox.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BarraNavegacao" Src="Inc/BarraNavegacao.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<head>
		<!-- #include file='inc/header.aspx' -->
	</head>
	<body onload="vertical();horizontal();" >
		<div id="Tudo">
			<form runat="Server" id="frm">
				<uc1:top id="Top1" runat="server"></uc1:top>
				<h3>Cadastro de Obras</h3>
				<fieldset>
    				<legend>Filtro de Cadastros</legend>
					
					<label>Código ITC</label>
					<asp:TextBox CssClass="inputG" ID="txtCodigoITC" Runat="server" Width=40% MaxLength="50"></asp:TextBox>
					<br /><br />
					
					<label>Razão Social</label>
					<asp:TextBox ID="txtRazaoSocial" CssClass="inputG"  MaxLength="50" Width=40% Runat="server"></asp:TextBox>
					<br /><br />
					
					<label>Data Inicial</label>
					<asp:TextBox onKeyDown="return FormataData(this, event);" onBlur="VerificaData(this);" MaxLength="10" Width="100" Runat="server" CssClass="inputG" ID="txtDataInicio" onfocus="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataInicio,'dd/mm/yyyy',this)" style="cursor:pointer;" ></asp:TextBox><asp:CompareValidator Runat=server CssClass="inputG" ErrorMessage=* ControlToValidate=txtDataInicio Type=Date Operator=DataTypeCheck ID="Comparevalidator2"></asp:CompareValidator><br /><br />
					<label>Data Final</label>
					<asp:TextBox onKeyDown="return FormataData(this, event);" onBlur="VerificaData(this);" MaxLength="10" Width="100" Runat="server" CssClass="inputG" ID="txtDataFim" onfocus="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)" onclick="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)" /> <img src="img/ico_calendario.jpg" onclick="displayCalendar(document.forms[0].txtDataFim,'dd/mm/yyyy',this)" style="cursor:pointer;"></asp:TextBox></asp:TextBox><asp:CompareValidator Runat=server CssClass="inputG" ErrorMessage=* ControlToValidate=txtDataFim Type=Date Operator=DataTypeCheck ID="Comparevalidator1" NAME="Comparevalidator1"></asp:CompareValidator>
					<br /><br />

					<label>Ordenar por</label>
					<uc1:ComboBox CssClass="inputG" id="cboOrdernar" runat="server"></uc1:ComboBox><br /><br />
					<label>Status</label>
					<uc1:ComboBox CssClass="inputG" id="cboStatus" runat="server"></uc1:ComboBox>
					<br /><br />
									
					<label>&nbsp;</label>
					<asp:button Text="Pesquisar" id="btnProcurar" runat="server"/>
   				</fieldset>
	   			
				<asp:DataGrid CssClass="Lista" id="dtgObras" PagerStyle-Mode=NumericPages runat="server" AllowPaging="True" OnPageIndexChanged="doPaging" AllowSorting="True" PageSize="15" BorderColor="#ffffff" BorderStyle="None" BackColor="White" CellPadding="3" GridLines="none" AutoGenerateColumns="False" width="100%">
					<HeaderStyle BackColor=#999999 ForeColor=#FFFFFF></HeaderStyle>
					<FooterStyle BackColor=#ffffff ForeColor=#ffffff></FooterStyle>
					<AlternatingItemStyle BackColor=#EFEFEF></AlternatingItemStyle>
					<PagerStyle HorizontalAlign="Center" PageButtonCount=15 ForeColor="white" BackColor="#999999" Mode="NumericPages"></PagerStyle>
					<Columns>
							<asp:TemplateColumn ItemStyle-Width=25>
								<ItemTemplate>
									<a href="obrasdet.aspx?Codigo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><img src='img/ico_status_ok.gif' border=0 ></a>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn ItemStyle-VerticalAlign=Middle HeaderText="Código ITC" ItemStyle-Wrap=False HeaderStyle-Font-Bold=True>
								<ItemTemplate>
									<a href="obrasdet.aspx?Codigo=<%# CryptographyEncoded(DataBinder.Eval(Container.DataItem, "Codigo"))%>"><asp:Label ID="Label9" Runat=server Font-Bold=True><%# DataBinder.Eval(Container.DataItem, "CodigoAntigo")%></asp:Label></a>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderStyle-Font-Bold=True HeaderText="Nome Fantasia" HeaderStyle-Width=20%>
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "FANTASIA")%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderStyle-Font-Bold=True HeaderText="Nome da Obra" HeaderStyle-Width=35%>
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "PROJETO")%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderStyle-Font-Bold=True HeaderText="Endereço" HeaderStyle-Width=30%>
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "ENDERECO")%>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderStyle-Font-Bold=True HeaderText="Atualização" HeaderStyle-Width=10%>
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "ATUALIZACAO")%>
								</ItemTemplate>
							</asp:TemplateColumn>
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
		<uc1:Rodape runat="server" ID="Rodape"></uc1:Rodape>
	   </div> 
    </body>
</HTML>
