<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="RelatorioPrecoShare.aspx.vb" Inherits="Relatorio_Preco_Share" Title="Relatório Preço e Share" %>
<%@ Register Src="../Relatorios/Filtro.ascx" TagName="Filtro" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat='server' />
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="updRep"
        DisplayAfter='0' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' />
            Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel runat="server" ID="updRep">
        <ContentTemplate>
            <uc1:Filtro ID="Filtro1" runat="server" ShowGerenteVendas='true' ShowVendedor='true'
                ShowCategoriaPesquisa="true" ShowProdutoPesquisa="true" ShowMarca="true" ShowDataInicial="true"
                ShowDataFinal="true" VisualizarUnicaEmpresa="true" />
            <table runat="server" id="tblLegenda" visible="false" style="border:1px;border-color:black;border-style:solid;margin-top:-12px;float:right;margin-bottom:10px;">
                <tr>
                    <td>
                        <table>
                            <tr><td colspan="2" align="center"><b>Legenda</b></td></tr>
                            <tr><td align="right" style="color:#666666;"><b>PP</b> = <td>Preço Ponta</td></td></tr>
                            <tr><td align="right" style="color:#666666;"><b>PV</b> = <td>Preço Varejo</td></td></tr>
                            <tr><td align="right" style="color:#666666;"><b>Pmoda</b> = <td>Preço Moda</td></td></tr>
                            <tr><td align="right" style="color:#666666;"><b>Total PDV Pesq</b> = <td>Total de PDV´s pesquisados no período selecionado</td></td></tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblInfoFiltros" runat="server" Font-Bold="true"></asp:Label>
            <asp:GridView runat="server" ID='grdRelatorio' Width="100%" AutoGenerateColumns="False" ShowFooter="true" SkinID="GridRelatorios">
                <HeaderStyle HorizontalAlign="Center" />
                <RowStyle HorizontalAlign="Center" />
                <FooterStyle HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField HeaderText="Marca&nbsp;" DataField="Marca" FooterText='Total' ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left" ItemStyle-Width="180px" />
                    <asp:TemplateField HeaderText="Volume">
			            <ItemTemplate>
			                <%#FormatNumber(Soma.Add(Eval("Volume"), "Volume"), 3)%>
			            </ItemTemplate>
			            <FooterTemplate>
			                <%#FormatNumber(Soma.Item("Volume").Sum, 3)%>
			            </FooterTemplate>
			        </asp:TemplateField>
                    <asp:TemplateField HeaderText="% Share">
			            <ItemTemplate>
			                <%#FormatPercent(Soma.Add(Eval("Share"), "Share"), 1)%>
			            </ItemTemplate>
			            <FooterTemplate>
			                <%#FormatPercent(Soma.Item("Share").Sum, 0)%>
			            </FooterTemplate>
			        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total PDV Pesq" ItemStyle-Width="120px">
			            <ItemTemplate>
			                <%#Soma.Add(Eval("TotalPDV"), "TotalPDV")%>
			            </ItemTemplate>
			            <FooterTemplate>
			                <%#Soma.Item("TotalPDV").Max%>
			            </FooterTemplate>
			        </asp:TemplateField>
                    <asp:BoundField HeaderText="Presença Prod" DataField="PresProd" ItemStyle-Width="120px" />
                    <asp:BoundField HeaderText="Ruptura" DataField="Ruptura" ItemStyle-Width="120px" />
                    <asp:TemplateField HeaderText="PP Medio" ItemStyle-Width="130px">
			            <ItemTemplate>
			                <%#FormatCurrency(Soma.Add(Eval("PPMedio"), "PPMedio"), 2)%>
			            </ItemTemplate>
			            <FooterTemplate>
			                <%#FormatCurrency(Soma.Item("PPMedio").Avg, 2)%>
			            </FooterTemplate>
			        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pmoda(PP)" ItemStyle-Width="130px">
			            <ItemTemplate>
			                <%#FormatCurrency(Soma.Add(Eval("PPModa"), "PPModa"), 2)%>
			            </ItemTemplate>
			            <FooterTemplate>
			                <%#FormatCurrency(Soma.Item("PPModa").Avg, 2)%>
			            </FooterTemplate>
			        </asp:TemplateField>
                    <asp:TemplateField HeaderText="PV Medio" ItemStyle-Width="130px">
			            <ItemTemplate>
			                <%#FormatCurrency(Soma.Add(Eval("PVMedio"), "PVMedio"), 2)%>
			            </ItemTemplate>
			            <FooterTemplate>
			                <%#FormatCurrency(Soma.Item("PVMedio").Avg, 2)%>
			            </FooterTemplate>
			        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pmoda(PV)" ItemStyle-Width="130px">
			            <ItemTemplate>
			                <%#FormatCurrency(Soma.Add(Eval("PVModa"), "PVModa"), 2)%>
			            </ItemTemplate>
			            <FooterTemplate>
			                <%#FormatCurrency(Soma.Item("PVModa").Avg, 2)%>
			            </FooterTemplate>
			        </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Não há registros com o filtro selecionado!
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
