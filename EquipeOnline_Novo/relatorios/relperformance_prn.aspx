<%@ Page Title="" Language="VB" MasterPageFile="~/Imprimir.master" AutoEventWireup="false" CodeFile="relperformance_prn.aspx.vb" Inherits="relatorios_relperformance_prn" %>
<%@ Register src="../include/caminhao.ascx" tagname="caminhao" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHelp" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" Runat="Server">
<table width="94%" border="0" align="center" cellpadding="0" cellspacing="0">        
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" /></td>
        </tr>
        <tr class='Header2' align='left'> 
            <td>
                <asp:Literal runat=server ID='ltTitulo'></asp:Literal>&nbsp;<%="- Emitido em " & Format(Now(), "dd/MM/yyyy") %>
            </td>
        </tr> 
		<tr valign="top" runat="server" id="repRow" visible="false" >
			<td align="center">
				<!-- relatório -->
			</td>
		</tr>
        <tr valign="top">
		    <td>
		        
		        <asp:GridView runat='server' ShowFooter='true' ID='grdRelatorio' AutoGenerateColumns='false' Width='100%' CssClass="GridView">
		            <HeaderStyle CssClass="Header2" HorizontalAlign='Left' />
		            <RowStyle HorizontalAlign='Left' />
		            <FooterStyle Font-Bold='true' />
		            <Columns>
		                <asp:TemplateField HeaderText='Respons&aacute;vel' ItemStyle-Width='150px'>
		                    <ItemTemplate>
                                <%#Eval("Responsavel")%>
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
            <td>
                <img width="1" height="25" src="../images/transpa.gif" />
            </td>
        </tr>							
    </table>
</asp:Content>

