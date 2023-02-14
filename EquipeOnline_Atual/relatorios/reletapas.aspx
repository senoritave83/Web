<%@ Page Title="" Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="reletapas.aspx.vb" Inherits="relatorios_reletapas" %>
<%@ Register src="../include/caminhao.ascx" tagname="caminhao" tagprefix="uc1" %>
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
    <table width="101%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr> 
            <td class='Linha1' style="height: 10px"><img src="../images/transpa.gif" height="1" /></td>
        </tr>
        <tr class='Header2' align='left'> 
            <td>
                Relat&oacute;rio de etapas realizadas 
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
							<uc1:MaskFormater ID="txtDataInicial" runat="server" Width="100px" MaxLength='10' cssclass="formulario"/>
						</td>                                                
						<td align='left' style="padding:0px 10px 0px 10px;">
							<font class='Cinza1'>At&eacute;</font>
							<br />
							<uc1:MaskFormater ID="txtDataFinal" runat="server" Width="100px" MaxLength='10' cssclass="formulario"/>
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
		        <asp:Repeater runat='server' ID='rptRelatorio'>
		            <HeaderTemplate>
                        <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdRelatorio" style="width:100%;border-collapse:collapse;">
                            <tr class="Header2" align="left">
                                <th scope="col">#OS</th><th scope="col">R&#225;dio</th><th scope="col">In&iacute;cio</th><th scope="col">Executando</th><th scope="col">FInalizado</th><th scope="col">Final</th><th scope="col">Completado</th>
                            </tr>
		            </HeaderTemplate>
		            <ItemTemplate>
		                <tr>
		                    
		                </tr>
		            </ItemTemplate>
		            <FooterTemplate>
		                </table>
		            </FooterTemplate>
		        </asp:Repeater>
		        <asp:GridView runat='server' ShowFooter='true' ID='grdRelatorio' AutoGenerateColumns='false' Width='100%' CellSpacing='0' CssClass="GridView">
		            <HeaderStyle CssClass="Header2" HorizontalAlign='Left' />
		            <RowStyle HorizontalAlign='Left' />
		            <FooterStyle Font-Bold='true' />
		            <Columns>
		                <asp:BoundField DataField='OrdemServico' HeaderText='#OS' />
		                <asp:BoundField DataField='Responsavel' HeaderText='R&aacute;dio' />
                        <asp:TemplateField Visible='false'>
                            <ItemTemplate>
                                <%#Eval("Etapa1") %>
                                <uc1:caminhao ID="caminhao1" runat="server" Realizadas='<%#Eval("Realizadas")%>' Etapas='<%#Eval("Etapas")%>'  Visible='<%#IIF(Eval("Realizadas") = 0, True, False)%>' />
                            </ItemTemplate>
                        </asp:TemplateField>		                
                        <asp:TemplateField Visible='false'>
                            <ItemTemplate>
                                <%#Eval("Etapa2") %>
                                <uc1:caminhao ID="caminhao1" runat="server" Realizadas='<%#Eval("Realizadas")%>' Etapas='<%#Eval("Etapas")%>'  Visible='<%#IIF(Eval("Realizadas") = 1, True, False)%>' />
                            </ItemTemplate>
                        </asp:TemplateField>		                
                        <asp:TemplateField Visible='false'>
                            <ItemTemplate>
                                <%#Eval("Etapa3") %>
                                <uc1:caminhao ID="caminhao1" runat="server" Realizadas='<%#Eval("Realizadas")%>' Etapas='<%#Eval("Etapas")%>'  Visible='<%#IIF(Eval("Realizadas") = 2, True, False)%>' />
                            </ItemTemplate>
                        </asp:TemplateField>		                
                        <asp:TemplateField Visible='false'>
                            <ItemTemplate>
                                <%#Eval("Etapa4") %>
                                <uc1:caminhao ID="caminhao1" runat="server" Realizadas='<%#Eval("Realizadas")%>' Etapas='<%#Eval("Etapas")%>'  Visible='<%#IIF(Eval("Realizadas") = 3, True, False)%>' />
                            </ItemTemplate>
                        </asp:TemplateField>		                
                        <asp:TemplateField Visible='false'>
                            <ItemTemplate>
                                <%#Eval("Etapa5") %>
                                <uc1:caminhao ID="caminhao1" runat="server" Realizadas='<%#Eval("Realizadas")%>' Etapas='<%#Eval("Etapas")%>'  Visible='<%#IIF(Eval("Realizadas") = 4, True, False)%>' />
                            </ItemTemplate>
                        </asp:TemplateField>		                
                        <asp:TemplateField Visible='false'>
                            <ItemTemplate>
                                <%#Eval("Etapa6") %>
                                <uc1:caminhao ID="caminhao1" runat="server" Realizadas='<%#Eval("Realizadas")%>' Etapas='<%#Eval("Etapas")%>'  Visible='<%#IIF(Eval("Realizadas") = 5, True, False)%>' />
                            </ItemTemplate>
                        </asp:TemplateField>		                
                        <asp:TemplateField Visible='false'>
                            <ItemTemplate>
                                <%#Eval("Etapa7") %>
                                <uc1:caminhao ID="caminhao1" runat="server" Realizadas='<%#Eval("Realizadas")%>' Etapas='<%#Eval("Etapas")%>'  Visible='<%#IIF(Eval("Realizadas") = 6, True, False)%>' />
                            </ItemTemplate>
                        </asp:TemplateField>		                
                        <asp:TemplateField Visible='false'>
                            <ItemTemplate>
                                <%#Eval("Etapa8") %>
                                <uc1:caminhao ID="caminhao1" runat="server" Realizadas='<%#Eval("Realizadas")%>' Etapas='<%#Eval("Etapas")%>'  Visible='<%#IIF(Eval("Realizadas") = 7, True, False)%>' />
                            </ItemTemplate>
                        </asp:TemplateField>		                
                        <asp:TemplateField Visible='false'>
                            <ItemTemplate>
                                <%#Eval("Etapa9") %>
                                <uc1:caminhao ID="caminhao1" runat="server" Realizadas='<%#Eval("Realizadas")%>' Etapas='<%#Eval("Etapas")%>'  Visible='<%#IIF(Eval("Realizadas") = 8, True, False)%>' />
                            </ItemTemplate>
                        </asp:TemplateField>		                
                        <asp:TemplateField Visible='True' HeaderText=''>
                            <ItemTemplate>
                                <uc1:caminhao ID="caminhao1" runat="server" Realizadas='<%#Eval("Realizadas")%>' Etapas='<%#Eval("Etapas")%>'  Visible='<%#IIF(Eval("Realizadas") = Eval("Etapas"), True, False)%>' />
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
    <dt><span lang="pt-br"><a href="relstatus.aspx">O.S por status</a></span></dt>
    <dt><span lang="pt-br"><a href="relradios.aspx">O.S por r&aacute;dio</a></span></dt>
    <dt><span lang="pt-br"><a href="relclientes.aspx">O.S por cliente</a> </span></dt>
    <dt><span lang="pt-br"><a href="relperiodo.aspx">O.S por per&iacute;odo </a> </span></dt>
    <dt><span lang="pt-br"><a href="relperformance.aspx">Performance por r&aacute;dio</a> </span></dt>
    <dt class="current"><span lang="pt-br"><a href="reletapas.aspx">Etapas </a> </span></dt>
    <dt><span lang="pt-br"><a href="relsla.aspx">Tempo Limite de Atendimento</a> </span></dt>
    </dl>    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
</asp:Content>

