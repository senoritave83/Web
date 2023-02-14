<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="relatorio_roteiro_det.aspx.vb" Inherits="Relatorios_relatorio_roteiro_det" title="Relatório Roteiro do Vendedor" %>
<%@ Register Assembly="XMGMapControl" Namespace="XMSistemas.Web.XMGMapControl" TagPrefix="cc1" %>
<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register src="Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat='server' />
        <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="updRep" DisplayAfter='0' DynamicLayout='false'>
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
            </ProgressTemplate>
        </asp:UpdateProgress> 
    <asp:UpdatePanel runat="server" ID="updRep">
     <ContentTemplate>
	    <uc1:Filtro ID="Filtro1" runat="server" ShowDataInicial="true" ShowDataFinal="false" ShowVendedor="true" ShowMapa="true"
                StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
        <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
            <asp:Repeater runat='server' ID='grdRelatorio' EnableViewState='false'>
                <HeaderTemplate>
                    <div class="scrollTableContainer">
            	        <table class="dataTable" cellspacing="0" cellpadding="4" border="0" id="ctl00_cphRelatorio_grdRelatorio" style="border-style:None;width:100%;border-collapse:collapse;">
            	            <thead>
		                        <tr class="GridHeader" align="left" valign='top'>
			                        <th scope="col">Vendedor</th>
                                    <th align="center" scope="col">Cliente</th>
                                    <th align="center" scope="col">Status</th>
                                    <th align="center" scope="col">Data Início da Visita</th>
                                    <th align="center" scope="col">Data Fim da Visita</th>
                                    <th align="center" scope="col">Duração da Visita</th>
		                        </tr>
            	            </thead>
            	            <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr style="background-color:#EFF3FB;">
			                <td><%# Eval("Vendedor") %></td>
			                <td align="center"><%#Eval("IDCLiente")%></td>
			                <td><%#Eval("Status")%></td>
			                <td align="center"><%#Eval("DataInicio")%></td>
                            <td align="center"><%#Eval("DataFim")%></td>
			                <td align="center"><%#Eval("DuracaoVisita")%></td>
		                </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                        <tr style="background-color:White;">
			                <td><%# Eval("Vendedor") %></td>
			                <td align="center"><%#Eval("IDCLiente")%></td>
			                <td><%#Eval("Status")%></td>
			                <td align="center"><%#Eval("DataInicio")%></td>
                            <td align="center"><%#Eval("DataFim")%></td>
			                <td align="center"><%#Eval("DuracaoVisita")%></td>
		                </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
        	            </tbody>
                        <tfoot>
                            <tr class="GridHeader">
                                <td colspan="6">&nbsp;</td>
		                    </tr>
		                </tfoot>
                    </table>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        <cc1:XMMapViewer ID="XMMapViewer1" visible="false"
                Width='100%' 
                FrameBorder='false'
                Height='600' 
                runat="server" 
                DataLatitudeField="Latitude" 
                DataLongitudeField="Longitude" 
                DataDetailsField="Descricao" 
                DataSequenceField="Sequencia" 
                DataTextField='Descricao'
                Title="Rota de Pedidos"
                ShowLegend="false">
        <Sequences> 
            <cc1:XMMapViewerSequence SequenceID='0' ShowMarker='true' ShowLine='false' LineColor='Green'  />
            <cc1:XMMapViewerSequence SequenceID='1' ShowMarker='true' ShowLine='true' LineColor='Blue' />
            <cc1:XMMapViewerSequence SequenceID='2' ShowMarker='true' ShowLine='false' LineColor='gainsboro' />
        </Sequences>
        </cc1:XMMapViewer>
	    <div id='divEmpty' class='divEmptyRow' runat='server' visible='false' >
		    N&atilde;o h&aacute; registros com o filtro selecionado!
	    </div>
        <div id='divErroPosicaoMapa' class='divEmptyRow' runat='server' visible='false' >
            N&atilde;o foi poss&iacute;vel gerar o mapa! Verifique os dados de Posicionamento nas visitas do vendedor.
        </div>
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

