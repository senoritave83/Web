<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="exportar.aspx.vb" Inherits="home_exportar" %>

<%@ Register src="../include/Paginate.ascx" tagname="Paginate" tagprefix="uc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register src="../include/SelectCliente.ascx" tagname="SelectCliente" tagprefix="uc2" %>

<%@ Register src="../include/SelectResponsaveis.ascx" tagname="SelectResponsaveis" tagprefix="uc3" %>

<%@ Register Src="~/include/MaskFormater.ascx" TagName="MaskFormater" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="menuEsquerdo" Runat="Server">
	<dl>
    <dt class="current" style="border-bottom:none;"><a href="default.aspx">Lista de OS</a></dt>
    <dd class="current"><a href="exportar.aspx"'>Exportar</a></dd>
    <dd><asp:HyperLink ID="hplRecados" runat="server" NavigateUrl="recados.aspx?&">Recados</asp:HyperLink></dd>
    <dd class="last"><asp:HyperLink ID="hplResumo" runat="server" NavigateUrl="resumo.aspx?&">Resumo</asp:HyperLink></dd>
    </dl>
    <dt style="border-top:1px #D7D2CB solid;"><a href="novaordem.aspx">Nova O.S.</a></dt>
    <dt><a href="pasta.aspx">Pastas</a></dt>

	<script type='text/javascript'>
	    function fncSelect() 
		    {
		    var cboFormato = document.getElementById('<%=cboFormato.ClientID %>');
		    var txtSeparador = document.getElementById('<%=txtSeparador.ClientID %>');
		    var chk0 = document.getElementById('<%=chkSeparador.ClientID %>_0');
		    var chk1 = document.getElementById('<%=chkSeparador.ClientID %>_1');
		    var chk2 = document.getElementById('<%=chkSeparador.ClientID %>_2');
		    
		    if (cboFormato.selectedIndex == 1)
				{
				txtSeparador.disabled = true;
				chk0.disabled = true;
				chk1.disabled = true;
				chk2.disabled = true;
				}
			else
				{
				    chk0.disabled = false;
				    chk1.disabled = false;
				    chk2.disabled = false;
				    if (chk2.checked == true)
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Ajuda" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat='server'></asp:ScriptManager>
	<table width="100%" height="100%" border="0" cellpadding='0' cellspacing='0' style='text-align:left;'>
		<tr class="Header1">
			<td><font class='TextDefault' style="color:White;">&nbsp;Exportar dados</font></td>
		</tr>
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" /></td>
        </tr>
        <tr class='Header2'>
            <td>Filtrar as ordens de servi&ccedil;o por:</td>
        </tr>
        <tr>
            <td>
                <br />
		         <table width="100%" style="text-align:left;">
                    <tr>
                        <td>
                            <font class='cinza1'>Cliente</font>
                            <br />
                            <uc2:SelectCliente ID="SelectCliente1" runat="server" />
                        </td>
                        <td>
                            <font class='cinza1'>Respons&aacute;vel</font>
                            <br />
                            <uc3:SelectResponsaveis ID="SelectResponsaveis1" runat="server" />
                        </td>
                        <td>
                            <font class='cinza1'>Status</font>
                            <br />
                            <asp:DropDownList cssclass="formulario" id="cboStatus" runat="server" DataTextField='ors_Status_chr' DataValueField='ors_Status_chr' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font class='cinza1'>De</font>
                            <br />
                            <uc4:MaskFormater ID="txtDataInicial" runat="server" Width="140px" MaxLength='10' cssclass="formulario"/>
                        </td>
                        <td>
                            <font class='cinza1'>At&eacute;</font>
                            <br />
                            <uc4:MaskFormater ID="txtDataFinal" runat="server" Width="140px" MaxLength='10' cssclass="formulario"/>
                        </td>
                    </tr>                    
                </table>
            </td>
        </tr>
		<tr>
			<td style="height: 10px"></td>			
		</tr>
		<tr style="background-color:White;">
		    <td>
		        <table width='100%' cellpadding='5' cellspacing='5' class="fdo_cinza">
					<tr class="Header2">
						<td colspan="2" style="height: 30px">
							<font class='TextDefault'>Definir parametros da exporta&ccedil;&atilde;o</font><br>
						</td>
					</tr>		        	
		            <tr valign="top" height=50>
			            <td style="width: 266px; padding-top:15px;">
				            <font class='TextDefault'>Formato do arquivo</font><br>
				            <asp:DropDownList Runat="server" ID='cboFormato' AutoPostBack='true'>
					            <asp:ListItem Value='Text'>Texto delimitado</asp:ListItem>
					            <asp:ListItem Value='XML' Selected="True">XML</asp:ListItem>
				            </asp:DropDownList>
			            </td>
			            <td>
				                    <font class='TextDefault'>Separador</font><br>
				                    <asp:RadioButtonList runat='server' ID='chkSeparador' AutoPostBack='true'>
				                        <asp:ListItem Selected='True'>Ponto-e-Virgula</asp:ListItem>
				                        <asp:ListItem>Tab</asp:ListItem>
				                        <asp:ListItem>Outro:</asp:ListItem>
				                    </asp:RadioButtonList>
				                    <asp:TextBox Runat="server" ID='txtSeparador' Width=50 Enabled=false CssClass=Caixa>;</asp:TextBox>
			            </td>
		            </tr>
		            <tr valign="top" height=50>
			            <td style="width: 266px">
				            <asp:CheckBox Runat="server" ID='chkResposta' Text='Incluir Respostas' CssClass=TextDefault></asp:CheckBox>
			            </td>
			            <td>
				            <asp:Button Runat="server" ID='btnExportar' Text='Exportar' CssClass='Botao'/>
				            
			            </td>
		            </tr>
		            <tr height=*>
			            <td colspan=2>&nbsp;</td>
		            </tr>
		        </table>
		    </td>
		</tr>
	</table>
</asp:Content>

