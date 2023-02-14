<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="justificado_det.aspx.vb" Inherits="Relatorios_justificado_det" title="Untitled Page" %>
<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register src="Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>
<%@ Register assembly="XMCrossRepeater" namespace="XMSistemas.Web.UI.WebControls" tagprefix="xm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat='server' />
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="updRep" DisplayAfter='0' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
    <asp:UpdatePanel runat="server" ID="updRep">
     <ContentTemplate>
	        <uc1:Filtro ID="Filtro1" runat="server" ShowGerenteVendas="true" ShowSupervisor="true" ShowVendedor="true"
                    ShowDataInicial="true" ShowDataFinal="true" StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
            <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
            <br />
            <div class="scrollTableContainer2">
            <table class="dataTable" cellspacing="0" cellpadding="4" style="border-style:None;width:100%;border-collapse:collapse;text-align:center;">
                <xm:XMCrossRepeater ID="XMCrossRepeater1" runat="server">
                        <TopTemplates>
                            <xm:XMCrossRepeaterTopTemplate>
                                <TopLeftTemplate>
                                    <thead>
                                    <tr class='GridHeader'>
                                        <th width='200px' align="left">Vendedor</td>
                                </TopLeftTemplate>
                                <ColHeaderTemplate>
                                        <th><%#Container.DataItem.Item("Justificativa")%></td>
                                </ColHeaderTemplate>
                                <TopRightTemplate>
                                        <th>Soma</td>
                                    </tr>
                                    </thead>
                                    <tbody>
                                </TopRightTemplate>
                            </xm:XMCrossRepeaterTopTemplate>
                        </TopTemplates>
                                    
                        <RowTemplate>
                           <RowHeaderTemplate>
                                <tr style="background-color:#EFF3FB;">
                                    <td align="left"><%#Container.DataItem.Item("Vendedor")%></td>
                           </RowHeaderTemplate>
                           <ItemTemplate>
                                    <td><%#FormatNumber(Soma.Add(Container.DataItem.Item("Qtd"), Container.DataItem.Item("Vendedor")), 0)%>
                                        <%#Soma.AddNonQuery(Container.DataItem.Item("Qtd"), Container.DataItem.Item("Justificativa"))%></td>
                           </ItemTemplate>
                           <EmptyItemTemplate>
                                    <td>-</td>
                           </EmptyItemTemplate>
                           <RowFooterTemplate>
                                    <td><%#FormatNumber(Soma.Item(Container.DataItem.Item("Vendedor")).Sum / 2, 0)%></td>
                                </tr>
                           </RowFooterTemplate>
                        </RowTemplate>

                        <AlternatingRowTemplate>
                           <RowHeaderTemplate>
                                <tr style="background-color:White;">
                                    <td align="left"><%#Container.DataItem.Item("Vendedor")%></td>
                           </RowHeaderTemplate>
                           <ItemTemplate>
                                    <td><%#FormatNumber(Soma.Add(Container.DataItem.Item("Qtd"), Container.DataItem.Item("Vendedor")), 0)%>
                                        <%#Soma.AddNonQuery(Container.DataItem.Item("Qtd"), Container.DataItem.Item("Justificativa"))%></td>
                           </ItemTemplate>
                           <EmptyItemTemplate>
                                    <td>-</td>
                           </EmptyItemTemplate>
                           <RowFooterTemplate>
                                    <td><%#FormatNumber(Soma.Item(Container.DataItem.Item("Vendedor")).Sum / 2, 0)%></td>
                                </tr>
                           </RowFooterTemplate>
                        </AlternatingRowTemplate>
                
                       <BottomTemplates>
                            <xm:XMCrossRepeaterBottomTemplate>
                               <BottomLeftTemplate>
                                    </tbody>
                                    <tfoot>
                                    <tr class='GridHeader'><td align="left">Total</td>
                               </BottomLeftTemplate>           
                               <ColFooterTemplate>
                                        <td><%#FormatNumber(Soma.Item(Container.DataItem.Item("Justificativa")).Sum / 2, 0)%><br /></td>
                               </ColFooterTemplate>
                               <BottomRightTemplate>
                                    <td>&nbsp;</td></tr>
                                    </tfoot>
                               </BottomRightTemplate>
                            </xm:XMCrossRepeaterBottomTemplate>
                       </BottomTemplates> 
                </xm:XMCrossRepeater>
            </table> 
            </div> 
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

