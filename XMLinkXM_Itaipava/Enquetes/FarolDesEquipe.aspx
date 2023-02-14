<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="FarolDesEquipe.aspx.vb" Inherits="Enquetes_FarolDesEquipe" %>

<%@ Register src="~/Relatorios/Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>
<%@ Register assembly="XMCrossRepeater" namespace="XMSistemas.Web.UI.WebControls" tagprefix="xm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:Filtro ID="Filtro1" runat="server" PermitirTodasEmpresas="false" ShowPesquisas="1" ShowGerenteVendas="true" ShowSupervisor="true" ShowVendedor="true"
                ShowDataInicial="true" ShowDataFinal="true" StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
	        <div class='ListArea'>
                <div class="scrollTableContainer2">
                        <table class="DataTable2" cellspacing="0" cellpadding="4" style="width:100%;border-collapse:collapse;text-align:center;">
                            <xm:XMCrossRepeater ID="XMCrossRepeater_FarolDesempenhoVendedorGeral" runat="server">
                                    <TopTemplates>
                                        <xm:XMCrossRepeaterTopTemplate>
                                            <TopLeftTemplate>
                                                <thead>
                                                <tr class='GridHeader'>
                                                    <th width='200px' align="left">Supervisor</th>
                                                    <th width='200px' align="left">Vendedor</th>
                                            </TopLeftTemplate>
                                            <ColHeaderTemplate>
                                                    <th><%#Container.DataItem.Item("Pergunta") %></th>
                                            </ColHeaderTemplate>
                                            <TopRightTemplate>
                                                    <th>Diagnóstico</th>
                                                </tr>
                                                </thead>
                                                <tbody>
                                            </TopRightTemplate>
                                        </xm:XMCrossRepeaterTopTemplate>
                                    </TopTemplates>
                                    
                                    <RowTemplate>
                                        <RowHeaderTemplate>
                                            <tr style="background-color:#EFF3FB;">
                                                <td align="left"><%#Container.DataItem.Item("Supervisor")%></td>
                                                <td align="left"><%#Container.DataItem.Item("Vendedor")%></td>
                                        </RowHeaderTemplate>
                                        <ItemTemplate>
                                                <td bgcolor='<%#IIf(fncVerificaPorcentagemQuant(Container.DataItem.Item("Resposta"), Container.DataItem.Item("QuantResposta")) >= 0.75, "#86BD60", IIf(fncVerificaPorcentagemQuant(Container.DataItem.Item("Resposta"), Container.DataItem.Item("QuantResposta")) >= 0.50, "#FDEE6F", "#E8574B")) %>'>
                                                    <%#IIf(fncVerificaPorcentagemQuant(Container.DataItem.Item("Resposta"), Container.DataItem.Item("QuantResposta")) >= 0.75, "S", IIf(fncVerificaPorcentagemQuant(Container.DataItem.Item("Resposta"), Container.DataItem.Item("QuantResposta")) >= 0.5, "EP", "S"))%>
                                                    <%#Soma.AddNonQuery(Container.DataItem.Item("Resposta"), "R" & Container.DataItem.Item("IdSupervisor_Vendedor"))%>
                                                    <%#Soma.AddNonQuery(Container.DataItem.Item("QuantResposta"), "QR" & Container.DataItem.Item("IdSupervisor_Vendedor"))%>
                                                    <%#Soma.AddNonQuery(Container.DataItem.Item("Resposta"), "R" & Container.DataItem.Item("IdPergunta"))%>
                                                    <%#Soma.AddNonQuery(Container.DataItem.Item("QuantResposta"), "QR" & Container.DataItem.Item("IdPergunta"))%>
                                                </td>
                                        </ItemTemplate>
                                        <EmptyItemTemplate>
                                                <td>-</td>
                                        </EmptyItemTemplate>
                                        <RowFooterTemplate>
                                                <td bgcolor='<%#IIF(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum()) >= 0.75, "#86BD60", IIF(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum()) >= 0.50, "#FDEE6F", "#E8574B")) %>'>
                                                    <h2><%#IIf(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum()) >= 0.75, "S", IIf(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum()) >= 0.5, "EP", "N"))%></h2>
                                                </td>
                                            </tr>
                                        </RowFooterTemplate>
                                    </RowTemplate>

                                    <AlternatingRowTemplate>
                                        <RowHeaderTemplate>
                                            <tr style="background-color:White;">
                                                <td align="left"><%#Container.DataItem.Item("Supervisor")%></td>
                                                <td align="left"><%#Container.DataItem.Item("Vendedor")%></td>
                                        </RowHeaderTemplate>
                                        <ItemTemplate>
                                                <td bgcolor='<%#IIf(fncVerificaPorcentagemQuant(Container.DataItem.Item("Resposta"), Container.DataItem.Item("QuantResposta")) >= 0.75, "#86BD60", IIf(fncVerificaPorcentagemQuant(Container.DataItem.Item("Resposta"), Container.DataItem.Item("QuantResposta")) >= 0.50, "#FDEE6F", "#E8574B")) %>'>
                                                    <%#IIf(fncVerificaPorcentagemQuant(Container.DataItem.Item("Resposta"), Container.DataItem.Item("QuantResposta")) >= 0.75, "S", IIf(fncVerificaPorcentagemQuant(Container.DataItem.Item("Resposta"), Container.DataItem.Item("QuantResposta")) >= 0.5, "EP", "S")) %>
                                                    <%#Soma.AddNonQuery(Container.DataItem.Item("Resposta"), "R" & Container.DataItem.Item("IdSupervisor_Vendedor"))%>
                                                    <%#Soma.AddNonQuery(Container.DataItem.Item("QuantResposta"), "QR" & Container.DataItem.Item("IdSupervisor_Vendedor"))%>
                                                    <%#Soma.AddNonQuery(Container.DataItem.Item("Resposta"), "R" & Container.DataItem.Item("IdPergunta"))%>
                                                    <%#Soma.AddNonQuery(Container.DataItem.Item("QuantResposta"), "QR" & Container.DataItem.Item("IdPergunta"))%>
                                                </td>
                                        </ItemTemplate>
                                        <EmptyItemTemplate>
                                                <td>-</td>
                                        </EmptyItemTemplate>
                                        <RowFooterTemplate>
                                                <td bgcolor='<%#IIF(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum()) >= 0.75, "#86BD60", IIF(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum()) >= 0.50, "#FDEE6F", "#E8574B")) %>'>
                                                    <h2><%#IIf(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum()) >= 0.75, "S", IIf(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdSupervisor_Vendedor")).Sum()) >= 0.5, "EP", "N"))%></h2>
                                                </td>
                                            </tr>
                                        </RowFooterTemplate>
                                    </AlternatingRowTemplate>
                
                                    <BottomTemplates>
                                        <xm:XMCrossRepeaterBottomTemplate>
                                            <BottomLeftTemplate>
                                                </tbody>
                                                <tfoot>
                                                <tr class='GridHeader'><td align="left" colspan='2'>Total</td>
                                            </BottomLeftTemplate>           
                                            <ColFooterTemplate>
                                                    <td style="color:Black;" bgcolor='<%#IIF(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdPergunta")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdPergunta")).Sum()) = -1, "", IIF(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdPergunta")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdPergunta")).Sum()) >= 0.75, "#86BD60", IIF(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdPergunta")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdPergunta")).Sum()) >= 0.50, "#FDEE6F", "#E8574B"))) %>'>
                                                        <%#IIf(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdPergunta")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdPergunta")).Sum()) = -1, "", IIf(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdPergunta")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdPergunta")).Sum()) >= 0.75, "S", IIf(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdPergunta")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdPergunta")).Sum()) >= 0.5, "EP", "N"))) & "<BR>" & FormatPercent(fncVerificaPorcentagemQuant(Soma.Item("R" & Container.DataItem.Item("IdPergunta")).Sum(), Soma.Item("QR" & Container.DataItem.Item("IdPergunta")).Sum()), 2)%>
                                                     </td>
                                            </ColFooterTemplate>
                                            <BottomRightTemplate>
                                                    <td style="background-color:White;">&nbsp;</td></tr>
                                                </tfoot>
                                            </BottomRightTemplate>
                                        </xm:XMCrossRepeaterBottomTemplate>
                                    </BottomTemplates> 
                            </xm:XMCrossRepeater>
                        </table> 
                    </div> 
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>		
</asp:Content>

