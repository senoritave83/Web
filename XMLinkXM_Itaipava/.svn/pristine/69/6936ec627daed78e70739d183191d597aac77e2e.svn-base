<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="historico_roteiro_det.aspx.vb" Inherits="Relatorios_historico_roteiro" title="Relatório de Histórico do Roteiro" %>

<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register src="Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>

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
	            <asp:GridView Runat="server" ID='grdRelatorio' Width="100%" AutoGenerateColumns="False" ShowFooter='true' SkinID='GridRelatorios'>
	                <HeaderStyle HorizontalAlign='Center' />
                    <RowStyle HorizontalAlign="Center" />
                    <FooterStyle HorizontalAlign="Center" />
		            <Columns>
			            <asp:BoundField HeaderText="Vendedor" DataField='Vendedor' FooterText='Total' HeaderStyle-HorizontalAlign='Left' ItemStyle-HorizontalAlign='Left' FooterStyle-HorizontalAlign="Left"/>
			            <asp:TemplateField HeaderText="Início da Visita&nbsp;">
			                <ItemTemplate>
			                    <%#Eval("MediaInicioVisita")%>
			                </ItemTemplate>
			                <FooterTemplate>
                                <%#MediaInicio%>
			                </FooterTemplate>
			            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Término da Visita&nbsp;">
			                <ItemTemplate>
			                    <%#Eval("MediaTerminoVisita")%>
			                </ItemTemplate>
			                <FooterTemplate>
                                <%#MediaTermino%>
			                </FooterTemplate>
			            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Duração do Roteiro&nbsp;">
			                <ItemTemplate>
			                    <%#Eval("DuracaoRoteiro")%>
			                </ItemTemplate>
			                <FooterTemplate>
                                <%#MediaDuracaoRoteiro%>
			                </FooterTemplate>
			            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qtd. de Visitas com Vendas">
			                <ItemTemplate>
                                <%#FormatNumber(Soma.Add(Eval("VisitasComVendas"), "VisitasComVendas"), 0)%>
			                </ItemTemplate>
			                <FooterTemplate>
                                <%#FormatNumber(Soma.Item("VisitasComVendas").Sum, 0)%>
			                </FooterTemplate>
			            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Qtd. de Visitas com Justificativas">
			                <ItemTemplate>
			                    <%#FormatNumber(Soma.Add(Eval("VisitasJustificadas"), "VisitasJustificadas"), 0)%>
			                </ItemTemplate>
			                <FooterTemplate>
                                <%#FormatNumber(Soma.Item("VisitasJustificadas").Sum, 0)%>
			                </FooterTemplate>
			            </asp:TemplateField>
                        <asp:TemplateField HeaderText="Visitas Fora de Rota">
			                <ItemTemplate>
			                    <%#FormatNumber(Soma.Add(Eval("VisitasForaRota"), "VisitasForaRota"), 0)%>
			                </ItemTemplate>
			                <FooterTemplate>
                                <%#FormatNumber(Soma.Item("VisitasForaRota").Sum, 0)%>
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