<%@ Page Title="" Language="VB" MasterPageFile="~/Imprimir.master" AutoEventWireup="false" CodeFile="reletapas_prn.aspx.vb" Inherits="relatorios_reletapas_prn" %>
<%@ Register src="../include/caminhao.ascx" tagname="caminhao" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHelp" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" Runat="Server">
    <table width="94%" border="0" align="left" cellpadding="0" cellspacing="0">
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
		        <asp:Repeater runat='server' ID='rptRelatorio'>
		            <HeaderTemplate>
                        <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdRelatorio" style="width:100%;border-collapse:collapse;">
                            <tr class="Header2" align="left">
                                <th scope="col">#OS</th><th scope="col">R&#225;dio</th><th scope="col">Início</th><th scope="col">Executando</th><th scope="col">FInalizado</th><th scope="col">Final</th><th scope="col">Completado</th>
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
            <td>
                <img width="1" height="25" src="../images/transpa.gif" />
            </td>
        </tr>							
    </table>
</asp:Content>

