<%@ Page Language="VB" AutoEventWireup="false" CodeFile="selcliente.aspx.vb" Inherits="home_selcliente" %>
<%@ Register src="../include/Paginate.ascx" tagname="Paginate" tagprefix="uc1" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Equipe Online</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../css/estilos.css" type="text/css" rel="StyleSheet">
		<style type="text/css">
		.style1 {
			background-color: #C0C0C0;
		}
		</style>
	</HEAD>
		<script>
			function fncVolta(vNome, vEndereco, vReferencia)
				{
				opener.fncVolta(vNome, vEndereco, vReferencia);
				opener.newwindow = null;
				opener.focus();
				self.close();
				}
		</script>
	<body MS_POSITIONING="GridLayout" rightmargin="0" leftmargin="0" topmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" height="100%" border="0" cellpadding='0' cellspacing='0' class="Rows2">
				<tr height="30" class='Header1'>
					<td style="padding-left:10px">
						<font class='baixotit'>Selecionar Cliente</font><br>
					</td>
				</tr>
				<tr height="20" class='Header2'>
					<td class="style1">
						<font class='baixotit'>Filtrar por:</font>
						<asp:TextBox Runat="server" ID='txtFiltro' CssClass='formulario'></asp:TextBox>
						<asp:ImageButton Runat="server" ID='btnFiltrar' AlternateText="Ok" ImageUrl="../images/buttons/Filtrar.png" ImageAlign="AbsBottom"></asp:ImageButton>
						<asp:ImageButton runat='server' ID='btnLimpar' AlternateText="Apagar" ImageUrl="../images/buttons/btn_apagar_secundario.png" ImageAlign="AbsBottom" Visible='false' />
					</td>
				</tr>
				<tr valign="top">
					<td style="height:290px;">
					    <div style="overflow:auto;height:285px;background-color:white;">
						<asp:DataGrid Runat="server" ID='dtgGrid' Width="100%" GridLines="Horizontal" AutoGenerateColumns="False" BorderStyle="none" EnableViewState='false' CellPadding='0' CellSpacing='0' ShowHeader='true' AllowSorting="true">
							<ItemStyle CssClass='griditem' VerticalAlign='Top'></ItemStyle>
							<Columns>
								<asp:TemplateColumn HeaderStyle-BackColor="#999999
								" HeaderStyle-ForeColor='white' HeaderStyle-Font-Size='7' HeaderText='CLIENTE' SortExpression='Cliente'>
									<ItemTemplate>
										<a href='javascript:fncVolta("<%# CStr(DataBinder.Eval(Container.DataItem, "cli_Cliente_chr")).replace(chr(34), "\" & chr(34))%>", "<%# CStr(DataBinder.Eval(Container.DataItem, "cli_Endereco_chr")).replace(chr(34), "\" & chr(34))%>", "<%# CStr(DataBinder.Eval(Container.DataItem, "cli_Referencia_chr")).replace(chr(34), "\" & chr(34))%>");'>
											<%# DataBinder.Eval(Container.DataItem, "cli_Cliente_chr")%>
										</a>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:DataGrid>
						<asp:Label Runat="server" ID='lblMensagem' CssClass='cinza1' Visible="false">Não foi possível encontrar o cliente!</asp:Label>
						<asp:Literal Runat="server" ID='ltrScript' />
						</div> 
					</td>
				</tr>
				<tr class='header2'>
				    <td>
                        <uc1:Paginate ID="Paginate1" runat="server" />
				    </td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
