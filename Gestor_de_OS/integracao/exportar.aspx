<%@ Page Language="VB" AutoEventWireup="false" CodeFile="exportar.aspx.vb" Inherits="integracao_exportar" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Equipe Online</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../css/estilos.css" rel="stylesheet" type="text/css" />
		<script>
		    function fncSelect() 
			    {
			    var cboFormato = document.getElementById('<%=cboFormato.ClientID %>');
			    var txtSeparador = document.getElementById('<%=txtSeparador.ClientID %>');
			    if (cboFormato.selectedIndex == 1)
					{
					txtSeparador.disabled = true;
					document.forms[0].chk1.disabled = true;
					document.forms[0].chk2.disabled = true;
					document.forms[0].chk3.disabled = true;
					}
				else
					{
					document.forms[0].chk1.disabled = false;
					document.forms[0].chk2.disabled = false;
					document.forms[0].chk3.disabled = false;
					if (document.forms[0].chk3.checked == true)
						{
						txtSeparador.disabled = false;
						}
					else
						{
						txtSeparador.disabled = true;
						}
					};
				}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout" rightmargin="0" leftmargin="0" topmargin="0" topmargin='0'>
		<form id="Form1" method="post" runat="server">
			<table width="100%" height="100%" border="0" cellpadding='0' cellspacing='0'>
				<tr class="Header1">
					<td><font class='TextDefault' style="color:White;">&nbsp;Exportar dados</font></td>
				</tr>
                <tr> 
                    <td class='Linha1'><img src="../images/transpa.gif" height="1" /></td>
                </tr>
				<tr class="Header2">
					<td>
						<font class='TextDefault'>&nbsp;Definir parametros da exportação</font><br>
					</td>
				</tr>
				<tr style="background-color:White;">
				    <td>
				        <table width='100%' cellpadding='5' cellspacing='5'>
				            <tr valign="top" height=50>
            				    
					            <td>
						            <font class='TextDefault'>Formato do arquivo</font><br>
						            <asp:DropDownList Runat="server" ID='cboFormato' onChange='fncSelect();'>
							            <asp:ListItem Value='Text'>Texto delimitado</asp:ListItem>
							            <asp:ListItem Value='XML' Selected="True">XML</asp:ListItem>
						            </asp:DropDownList>
					            </td>
					            <td>
						            <font class='TextDefault'>Separador</font><br>
						            <input type=radio name='chkSeparador' id=chk1 value=59 onclick='fncSelect();' disabled checked><span class=TextDefault>Ponto-e-Virgula</span><br>
						            <input type=radio name='chkSeparador' id=chk2 value=9 onclick='fncSelect();' disabled><span class=TextDefault>Tab</span><br>
						            <input type=radio name='chkSeparador' id=chk3 value=0 onclick='fncSelect();' disabled><span class=TextDefault>Outro:</span>
						            <asp:TextBox Runat="server" ID='txtSeparador' Width=50 Enabled=false CssClass=Caixa>;</asp:TextBox>
					            </td>
				            </tr>
				            <tr valign="top" height=50>
					            <td>
						            <asp:CheckBox Runat="server" ID='chkResposta' Text='Incluir Respostas' CssClass=TextDefault></asp:CheckBox>
					            </td>
					            <td>
						            <asp:Button Runat="server" ID='btnExportar' Text='Exportar' CssClass=Botao/>
					            </td>
				            </tr>
				            <tr height=*>
					            <td colspan=2>&nbsp;</td>
				            </tr>
				        </table>
				    </td>
				</tr>
				<tr height="25" class="Header2">
					<td height="25" class="TextSmall" align="middle">
						©<%=Year(Now)%> Nextel Telecomunicações Ltda.
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
