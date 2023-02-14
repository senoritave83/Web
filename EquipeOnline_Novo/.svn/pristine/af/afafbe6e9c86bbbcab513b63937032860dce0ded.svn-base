<%@ Page Title="" Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="relstatus.aspx.vb" Inherits="relatorios_relstatus" %>
<%@ Register Assembly="Xceed.Chart.Server, Version=4.2.100.0, Culture=neutral, PublicKeyToken=ba83ff368b7563c6" Namespace="Xceed.Chart.Server" TagPrefix="xceedchart" %>
<%@ Register Src="~/include/MaskFormater.ascx" TagName="MaskFormater" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat='server' />
    <asp:Literal runat=server ID="ltScript"></asp:Literal>
    <script language="javascript">
        function verificaDatas() {
            
            var txtDataInicial = document.getElementById('<%=txtDataInicial.UID()%>');
            var txtDataFinal = document.getElementById('<%=txtDataFinal.UID()%>');

            if (validaDatas(txtDataInicial.value, txtDataFinal.value) == false) {
                alert('A data inicial deve ser menor ou igual a data final');
                return false;
            }
            return true;
        }
    </script>
    <table width="101%" align="center" cellpadding="0" cellspacing="0">        
        <tr> 
            <td class='Linha1'>
                <img src="../images/transpa.gif" height="1" alt=""/>
            </td>
        </tr>
        <tr class='Header2'> 
            <td>
                Relat&oacute;rio de O.S. por Status
            </td>
        </tr> 
	    <tr>
		    <td>
                <br />
			    <!-- INICIO CONTE&#65533;DO -->			    
				<table width="60%">
					<tr>
						<td align='left'>
							<font class='Cinza1'>De</font>
							<br />
							<uc1:MaskFormater ID="txtDataInicial" runat="server" Width="100px" MaxLength='10' cssclass="formulario"/>
						</td>                                                
						<td align='left' style="padding:0px 10px 0px 10px;">
							<font class='Cinza1'>At&eacute;</font>
							<br />
							<uc1:MaskFormater ID="txtDataFinal" runat="server" Width="100px" MaxLength='10' cssclass="formulario"/>
						</td>
						<td align='left'>
							<font class='Cinza1'>Tipo de Gr&aacute;fico</font>
							<br />
							<asp:DropDownList AutoPostBack=true Runat="server" ID='cboTipoGrafico' CssClass="ui-select"  Width="80">
                                <asp:ListItem Text="Tabular" Value="Tabular"></asp:ListItem>
                                <asp:ListItem Text="Barras" Value="Barras"></asp:ListItem>
                                <asp:ListItem Text="Linhas" Value="Linhas" Enabled=false></asp:ListItem>
                                <asp:ListItem Text="Pizza" Value="Pizza"></asp:ListItem>
                            </asp:DropDownList>
						</td>
						<td valign="bottom">
                            <br />
							<asp:ImageButton OnClientClick="return verificaDatas()" Runat="server" ID='btnExibir' onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('btnExibir','','../images/bt_exibir_over.gif',0)" ImageUrl="../images/buttons/exibir.png"></asp:ImageButton>
						</td>
					</tr>
                    <tr runat="server" id="trMensagem" visible="false">
                        <td colspan='4'><font class='Cinza1' style="color:red">Para melhor visualiza&ccedil;&atilde;o do Gr&aacute;fico em Linhas, recomendamos um per&iacute;odo de at&eacute; 30 dias</font></td>
                    </tr>
				</table>
                <br />
			</td>
		</tr>
		<tr valign="top" runat="server" id="repRow" visible="false" >
			<td align="center">
				<!-- relat&#65533;rio -->
			</td>
		</tr>			    
        <tr>
		    <td>
		        <asp:GridView runat='server' ShowFooter='true' ID='grdRelatorio' AutoGenerateColumns='false' Width='100%' CssClass="GridView">
		            <HeaderStyle CssClass="Header2" />
		            <RowStyle HorizontalAlign='Left' />
		            <FooterStyle Font-Bold='true' />
		            <Columns>
		                <asp:TemplateField HeaderText='Status' HeaderStyle-HorizontalAlign="Left">
		                    <ItemTemplate>
                                <a href='../home/default.aspx?status=<%#Eval("Status")%>&datainicial=<%=txtDataInicial.text%>&datafinal=<%=txtDataFinal.text%>'><%#Eval("Status")%></a>		                    
		                    </ItemTemplate>
		                </asp:TemplateField>
		                <asp:BoundField DataField='Qtd' HeaderText='Qtd' HeaderStyle-HorizontalAlign="Left" />
		            </Columns>
		        </asp:GridView>
		    </td>
	    </tr>
        <tr valign="top">
		    <td align="center">
                <xceedchart:ChartServerControl ID="chartEOL" runat="server"></xceedchart:ChartServerControl>
		    </td>
	    </tr>
        <tr class="Footer1">
        	<td>&nbsp;</td>
        </tr>	    
        <tr> 
            <td style="padding:5px 0 5px 0; text-align:right;">
                <img width="1" height="25" src="../images/transpa.gif" alt=""/>
                <asp:ImageButton Runat="server" ID='btnExportar'  ImageUrl="../images/buttons/exportar_rel.png"></asp:ImageButton>
                <input type="image"  src="../images/buttons/imprimir_rel.png" onclick="printReport();" value="Imprimir"/>
            </td>
        </tr>						
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt class="current"><span lang="pt-br"><a href="relstatus.aspx">O.S por status</a></span></dt>
    <dt><span lang="pt-br"><a href="relradios.aspx">O.S por respons&aacute;vel</a></span></dt>
    <dt><span lang="pt-br"><a href="relclientes.aspx">O.S por cliente</a> </span></dt>
    <dt><span lang="pt-br"><a href="relperiodo.aspx">O.S por per&iacute;odo </a> </span></dt>
    <dt><span lang="pt-br"><a href="relperformance.aspx">Performance por respons&aacute;vel</a> </span></dt>
    <dt><span lang="pt-br"><a href="reletapas.aspx">Etapas </a> </span></dt>
    <dt><span lang="pt-br"><a href="relsla.aspx">Tempo Limite de Atendimento</a> </span></dt>
    </dl>    
    
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
</asp:Content>

