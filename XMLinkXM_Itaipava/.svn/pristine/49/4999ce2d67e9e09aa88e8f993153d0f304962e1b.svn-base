<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="FarolDesVendedorDet.aspx.vb" Inherits="Enquetes_FarolDesVendedorDet" %>
<%@ Register assembly="XMCrossRepeater" namespace="XMSistemas.Web.UI.WebControls" tagprefix="xm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>Farol de Desempenho - Resultado dos Vendedores</div>
            <table width=100%>
                <tr>
                    <td style="width:50%">
                        <div class='trField cb' style="width:40%">
				            <div class='tdFieldHeader fl'>
					            Revenda:
				            </div>
				            <div class='tdField fl'>
					            <asp:Label runat="server" ID="lblRevenda" />
				            </div>
			            </div>
                        <div class='trField cb' style="width:40%">
				            <div class='tdFieldHeader fl'>
					            Gerente de Vendas:
				            </div>
				            <div class='tdField fl'>
					            <asp:Label runat="server" ID="lblGerenteVendas" />
				            </div>
			            </div>
                        <div class='trField cb' style="width:40%">
				            <div class='tdFieldHeader fl'>
					            Supervisor:
				            </div>
				            <div class='tdField fl'>
					            <asp:Label runat="server" ID="lblSupervisor" />
				            </div>
			            </div>
			            <div class='trField cb' style="width:40%">
				            <div class='tdFieldHeader fl'>
					            Vendedor:
				            </div>
				            <div class='tdField fl'>
					            <asp:Label runat="server" ID="lblVendedor" />
				            </div>
			            </div>
                        <div class='trField cb' style="width:40%">
				            <div class='tdFieldHeader fl'>
					            Data do Roteiro:
				            </div>
				            <div class='tdField fl'>
					            <asp:Label runat="server" ID="lblData" />
				            </div>
			            </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
	<div class='ListArea'>
        <div class="scrollTableContainer2" runat="server" id="divResumo">
            <asp:GridView runat="server" ID="grdFarolDesempenhoVendedorGeral" AutoGenerateColumns="false" AllowSorting="true" SkinID="GridRelatorios" >
                <HeaderStyle HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Center" Height="30" BackColor="#EFF3FB" BorderStyle=Outset BorderColor=Black BorderWidth=1 />
                <AlternatingRowStyle HorizontalAlign="Center" Height="30" />
                <Columns>
                    <asp:BoundField DataField="Pergunta" HeaderText="Pergunta"  SortExpression="Pergunta" ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="left" />
                    <asp:BoundField DataField="Resposta" HeaderText="Resposta"  SortExpression="Resposta" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="scrollTableContainer2">
            <table class="DataTable2" cellspacing="0" cellpadding="4" style="width:100%;border-collapse:collapse;text-align:center;">
                <xm:XMCrossRepeater ID="XMCrossRepeater_FarolDesempenhoVendedorGeral" runat="server">
                        <TopTemplates>
                            <xm:XMCrossRepeaterTopTemplate>
                                <TopLeftTemplate>
                                    <thead>
                                    <tr class='GridHeader'>
                                        <th width='200px' align="left">Cliente</th>
                                </TopLeftTemplate>
                                <ColHeaderTemplate>
                                        <th><%#Container.DataItem.Item("Pergunta") & " - " & Container.DataItem.Item("IdPergunta")%></th>
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
                                    <td align="left"><%#Container.DataItem.Item("Cliente")%></td>
                            </RowHeaderTemplate>
                            <ItemTemplate>
                                    <td bgcolor='<%#IIF(Container.DataItem.Item("Resposta").toString().toUpper()="SIM", "#86BD60", "#E8574B") %>'>
                                        <%#Container.DataItem.Item("Resposta")%>
                                        <%#IIf(fncSomarItem(Container.DataItem.Item("IdCliente") & "_" & Container.DataItem.Item("IdVisita"),Container.DataItem.Item("Resposta").ToString().ToUpper()),"","")%>
                                        <%#IIf(fncSomarItem(Container.DataItem.Item("IdPergunta"),Container.DataItem.Item("Resposta").ToString().ToUpper()),"","")%>
                                    </td>
                            </ItemTemplate>
                            <EmptyItemTemplate>
                                    <td>-</td>
                            </EmptyItemTemplate>
                            <RowFooterTemplate>
                                    <td bgcolor='<%#iif(IsDBNull(Container.DataItem.Item("IdVisita")) = true,"#EFF3FB",IIF(fncVerificaPorcentagem(Container.DataItem.Item("IdCliente") & "_" & Container.DataItem.Item("IdVisita")) >= 0.75, "#86BD60", IIF(fncVerificaPorcentagem(Container.DataItem.Item("IdCliente") & "_" & Container.DataItem.Item("IdVisita")) >= 0.50, "#FDEE6F", "#E8574B"))) %>'><h2><%#IIf(IsDBNull(Container.DataItem.Item("IdVisita")) = True, "", IIf(fncVerificaPorcentagem(Container.DataItem.Item("IdCliente") & "_" & Container.DataItem.Item("IdVisita")) >= 0.75, "S", IIf(fncVerificaPorcentagem(Container.DataItem.Item("IdCliente") & "_" & Container.DataItem.Item("IdVisita")) >= 0.5, "EP", "N")))%></h2></td>
                                </tr>
                            </RowFooterTemplate>
                        </RowTemplate>

                        <AlternatingRowTemplate>
                            <RowHeaderTemplate>
                                <tr style="background-color:White;">
                                    <td align="left"><%#Container.DataItem.Item("Cliente")%></td>
                            </RowHeaderTemplate>
                            <ItemTemplate>
                                    <td bgcolor='<%#IIF(Container.DataItem.Item("Resposta").toString().toUpper()="SIM", "#86BD60", "#E8574B") %>'>
                                        <%#Container.DataItem.Item("Resposta")%>
                                        <%#IIf(fncSomarItem(Container.DataItem.Item("IdCliente") & "_" & Container.DataItem.Item("IdVisita"),Container.DataItem.Item("Resposta").ToString().ToUpper()),"","")%>
                                        <%#IIf(fncSomarItem(Container.DataItem.Item("IdPergunta"),Container.DataItem.Item("Resposta").ToString().ToUpper()),"","")%>
                                    </td>
                            </ItemTemplate>
                            <EmptyItemTemplate>
                                    <td>-</td>
                            </EmptyItemTemplate>
                            <RowFooterTemplate>
                                    <td bgcolor='<%#iif(IsDBNull(Container.DataItem.Item("IdVisita")) = true,"#EFF3FB",IIF(fncVerificaPorcentagem(Container.DataItem.Item("IdCliente") & "_" & Container.DataItem.Item("IdVisita")) >= 0.75, "#86BD60", IIF(fncVerificaPorcentagem(Container.DataItem.Item("IdCliente") & "_" & Container.DataItem.Item("IdVisita")) >= 0.50, "#FDEE6F", "#E8574B"))) %>'><h2><%#IIf(IsDBNull(Container.DataItem.Item("IdVisita")) = True, "", IIf(fncVerificaPorcentagem(Container.DataItem.Item("IdCliente") & "_" & Container.DataItem.Item("IdVisita")) >= 0.75, "S", IIf(fncVerificaPorcentagem(Container.DataItem.Item("IdCliente") & "_" & Container.DataItem.Item("IdVisita")) >= 0.5, "EP", "N")))%></h2></td>
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
                                        <td style="color:Black;" bgcolor='<%#IIF(fncVerificaPorcentagemFooter(Container.DataItem.Item("IdPergunta")) = -1, "", IIF(fncVerificaPorcentagemFooter(Container.DataItem.Item("IdPergunta")) >= 0.75, "#86BD60", IIF(fncVerificaPorcentagemFooter(Container.DataItem.Item("IdPergunta")) >= 0.50, "#FDEE6F", "#E8574B"))) %>'><%#IIF(fncVerificaPorcentagemFooter(Container.DataItem.Item("IdPergunta")) = -1, "", IIf(fncVerificaPorcentagemFooter(Container.DataItem.Item("IdPergunta")) >= 0.75, "S", IIf(fncVerificaPorcentagemFooter(Container.DataItem.Item("IdPergunta")) >= 0.5, "EP", "N"))) & "<BR>" & FormatPercent(fncVerificaPorcentagemFooter(Container.DataItem.Item("IdPergunta")),2)%></td>
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
    <div class='AreaBotoes' runat="server" id="divAreaBotoes">
        <asp:Button runat="server" ID="btnVoltar" Text="Voltar" />
    </div>
    <div class='AreaAjuda' runat="server" id="divAreaAjuda">
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

