<%@ Page Title="" Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="relperformance.aspx.vb" Inherits="relatorios_relperformance" %>
<%@ Register src="../include/caminhao.ascx" tagname="caminhao" tagprefix="uc1" %>
<%@ Register Src="~/include/MaskFormater.ascx" TagName="MaskFormater" TagPrefix="uc2" %>
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
    <table width="101%" border="0" align="center" cellpadding="0" cellspacing="0">        
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" /></td>
        </tr>
        <tr class='Header2' align='left'> 
            <td>
                Relat&oacute;rio de performance por r&aacute;dio.
            </td>
        </tr> 
	    <tr>
		    <td>
                <br />
			    <!-- INICIO CONTE&#65533;DO -->			    
				<table width="59%">
					<tr>
						<td align='left'>
							<font class='Cinza1'>De</font>
							<br />
							<uc2:MaskFormater ID="txtDataInicial" runat="server" Width="100px" MaxLength='10' cssclass="formulario"/>
						</td>                                                
						<td align='left' style="padding:0px 10px 0px 10px;">
							<font class='Cinza1'>At&eacute;</font>
							<br />
							<uc2:MaskFormater ID="txtDataFinal" runat="server" Width="100px" MaxLength='10' cssclass="formulario"/>
						</td>
						<td valign="bottom">
                            <br />
							<asp:ImageButton OnClientClick="return verificaDatas()" Runat="server" ID='btnExibir' onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('btnExibir','','../images/bt_exibir_over.gif',0)" ImageUrl="../images/buttons/exibir.png"></asp:ImageButton>
						</td>
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
        <tr valign="top">
		    <td>
		        
		        <asp:GridView runat='server' ShowFooter='true' ID='grdRelatorio' AutoGenerateColumns='false' Width='100%' CssClass="GridView">
		            <HeaderStyle CssClass="Header2" HorizontalAlign='Left' />
		            <RowStyle HorizontalAlign='Left' />
		            <FooterStyle Font-Bold='true' />
		            <Columns>
		                <asp:TemplateField HeaderText='R&aacute;dio' ItemStyle-Width='150px'>
		                    <ItemTemplate>
                                <a href='../home/default.aspx?responsavel=<%#Eval("Responsavel")%>&datainicial=<%=txtDataInicial.text%>&datafinal=<%=txtDataFinal.text%>'><%#Eval("Responsavel")%></a>		                    
		                    </ItemTemplate>
		                </asp:TemplateField>
		                <asp:BoundField HeaderText='Telefone' DataField='Telefone' ItemStyle-Width='80px' />
		                <asp:TemplateField HeaderText='' ItemStyle-Width='50px' ItemStyle-HorizontalAlign='Center'>
		                    <ItemTemplate>
		                        (<%#Eval("Realizadas") %>/<%#Eval("Total") %>)
		                    </ItemTemplate>
		                </asp:TemplateField>
		                <asp:TemplateField>
		                    <ItemTemplate>
		                        <div style='width:100%'>
		                            <div style='width:<%# GetPercentage(Eval("Total"), Eval("Realizadas")) %>%;float:left;background-color:#FF9900;'>&nbsp;</div>
                                    <uc1:caminhao ID="caminhao1" runat="server" Etapas='<%#Eval("Total")%>' Realizadas='<%#Eval("Realizadas") %>' />
		                        </div> 
		                    </ItemTemplate>
		                </asp:TemplateField>
		            </Columns>
		        </asp:GridView>
		    </td>
	    </tr>
        <tr class='Footer1'>
        	<td>&nbsp;</td>
        </tr>		    
        <tr> 
            <td style="padding:5px 0 5px 0; text-align:right;">
                <img width="1" height="25" src="../images/transpa.gif" />
                <asp:ImageButton Runat="server" ID='btnExportar'   ImageUrl="../images/buttons/exportar_rel.png"></asp:ImageButton>
                <input type="image"  src="../images/buttons/imprimir_rel.png" onclick="printReport();" value="Imprimir"/>
            </td>
        </tr>						
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
</asp:Content>
<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><span lang="pt-br"><a href="relstatus.aspx">O.S por status</a></span></dt>
    <dt><span lang="pt-br"><a href="relradios.aspx">O.S por r&aacute;dio</a></span></dt>
    <dt><span lang="pt-br"><a href="relclientes.aspx">O.S por cliente</a> </span></dt>
    <dt><span lang="pt-br"><a href="relperiodo.aspx">O.S por per&iacute;odo </a> </span></dt>
    <dt class="current"><span lang="pt-br"><a href="relperformance.aspx">Performance por r&aacute;dio</a> </span></dt>
    <dt><span lang="pt-br"><a href="reletapas.aspx">Etapas </a> </span></dt>
    <dt><span lang="pt-br"><a href="relsla.aspx">Tempo Limite de Atendimento</a> </span></dt>
    </dl>    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
</asp:Content>

