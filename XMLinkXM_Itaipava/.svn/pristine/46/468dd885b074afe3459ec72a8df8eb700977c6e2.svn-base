<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="VolumeVendasEmbalagem.aspx.vb" Inherits="Relatorios_VolumeVendasEmbalagem" %>

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
	        <uc1:Filtro ID="Filtro1" runat="server" ShowDias='false' ShowEmbalagem='True' ShowGerenteVendas='false' ShowSupervisor='false' ShowVendedor='false' ShowMapa='false' ShowStatus='false'
                    StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
            <br />
            <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
            <div class="scrollTableContainer2">
            
            <div id='divVoltar' style="background-color:Gray;height:15px;padding-left:5px;" runat='server' visible='false' > 
                <asp:LinkButton ID="lnkVoltar" Font-Bold="true" ForeColor="White" Runat="server" >Voltar p/ Nível Anterior</asp:LinkButton>
            </div>
            <table class="dataTable" cellspacing="0" cellpadding="4" style="border-style:None;width:100%;border-collapse:collapse;text-align:center;">
                <xm:XMCrossRepeater ID="XMCrossRepeater1" runat="server" EnableViewState="true" >
                        <TopTemplates>
                            <xm:XMCrossRepeaterTopTemplate>
                                <TopLeftTemplate>
                                    <thead>
                                    <tr class='GridHeader'>
                                        <th width='200px' align="left">Regional</th>
                                </TopLeftTemplate>
                                <ColHeaderTemplate>
                                        <th><%#Container.DataItem.Item("Linha")%><br />Volume de Vendas</th>
                                        <th><%#Container.DataItem.Item("Linha")%><br />Preço Médio</th>
                                </ColHeaderTemplate>
                                <TopRightTemplate>
                                    </tr>
                                    </thead>
                                    <tbody>
                                </TopRightTemplate>
                            </xm:XMCrossRepeaterTopTemplate>
                        </TopTemplates>
                                    
                        <RowTemplate>
                           <RowHeaderTemplate>
                                <tr style="background-color:#EFF3FB;">
                                    <td align="left">
                                        <asp:Literal runat="server" ID="ltrLink"></asp:Literal>
                                    </td>
                           </RowHeaderTemplate>
                           <ItemTemplate>
                                    <td><%# FormatNumber(Soma.Add(Container.DataItem.Item("Volume"), Container.DataItem.Item("IdLinha") & "2"), 0)%></td>
                                    <td><%# Container.DataItem.Item("PrecoMedio")%>
                                        <%# Soma.AddNonQuery(Container.DataItem.Item("PrecoMedio"), Container.DataItem.Item("IdLinha"))%>
                                    </td>
                           </ItemTemplate>
                           <EmptyItemTemplate>
                                    <td>-</td>
                                    <td>-</td>
                           </EmptyItemTemplate>
                           <RowFooterTemplate>
                                </tr>
                           </RowFooterTemplate>
                        </RowTemplate>

                        <AlternatingRowTemplate>
                           <RowHeaderTemplate>
                                <tr style="background-color:White;">
                                    <td align="left">
                                        <asp:Literal runat="server" ID="ltrLink"></asp:Literal>
                                    </td>
                           </RowHeaderTemplate>
                           <ItemTemplate>
                                    <td><%# FormatNumber(Soma.Add(Container.DataItem.Item("Volume"), Container.DataItem.Item("IdLinha") & "2"), 0)%></td>
                                    <td><%# Container.DataItem.Item("PrecoMedio")%>
                                        <%# Soma.AddNonQuery(Container.DataItem.Item("PrecoMedio"), Container.DataItem.Item("IdLinha"))%>
                                    </td>
                           </ItemTemplate>
                           <EmptyItemTemplate>
                                    <td>-</td>
                                    <td>-</td>
                           </EmptyItemTemplate>
                           <RowFooterTemplate>
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
                                        <td><%# FormatNumber((Soma.Item(Container.DataItem.Item("IdLinha") & "2").Sum) / (2), 0)%></td>
                                        <td><%# IIf(Soma.Item(Container.DataItem.Item("IdLinha")).Sum > 0, FormatNumber((Soma.Item(Container.DataItem.Item("IdLinha")).Sum / 2), 4), 0)%>
                                        </td>
                               </ColFooterTemplate>
                               <BottomRightTemplate>
                                    </tr>
                                    </tfoot>
                               </BottomRightTemplate>
                            </xm:XMCrossRepeaterBottomTemplate>
                       </BottomTemplates> 
                </xm:XMCrossRepeater>
            </table>
            </div> 
            <div id='divEmpty' class='divEmptyRow' runat='server' visible='false' >
	            N&atilde;o h&aacute; registros com o filtro selecionado!
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

