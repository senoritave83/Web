<%@ Page Title="Previsão de Pesquisas" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="PrevisaoPesquisas.aspx.vb" Inherits="Pesquisas_PrevisaoPesquisas" %>

<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register Src="../Controls/Paginate.ascx" Tagname="Paginate" Tagprefix="uc1" %>
<%@ Register src="~/Relatorios/Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
                <uc1:Filtro ID="Filtro1" runat="server" ShowGerenteVendas="false" ShowSupervisor="false" ShowVendedor="false" ShowPesquisas="2" 
                    TextoTodasPesquisas="TODAS AS PESQUISAS DISPONÍVEIS" ShowDataInicial="false" ShowDataFinal="false" StatusClass='FiltroItem' 
                    VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
	    </ContentTemplate>
	</asp:UpdatePanel> 
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='1000' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat="server" ID="grdRelatorioPesquisas" AutoGenerateColumns="false">
                    <HeaderStyle HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Pesquisa" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                            <div runat="server" id="lnkPesquisa">
                                <a href='previsaopesquisasdetalhe.aspx?idpesquisa=<%#eval("IdPesquisa")%>&di=<%=Filtro1.DataInicial%>&df=<%=Filtro1.DataFinal%>'><%#Eval("Pesquisa")%></a>
                            </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DataInicio" HeaderText="Data Inicial" />
                        <asp:BoundField DataField="DataFim" HeaderText="Data Final" />
                    </Columns>
                </asp:GridView>
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
        </asp:UpdatePanel>		
	</div>
    <div runat="server" id="divAreaBotoes" class='AreaBotoes'>
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
    </div>
    <div runat="server" id="divAreaAjuda" class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>