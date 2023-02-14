<%@ Page Title="Pesquisas Diárias" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="RelatorioPesquisasDiarias.aspx.vb" Inherits="Pesquisas_RelatorioPesquisasDiarias" %>
<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register Src="../Controls/Paginate.ascx" Tagname="Paginate" Tagprefix="uc1" %>
<%@ Register src="~/Relatorios/Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
                <uc1:Filtro ID="Filtro1" runat="server" PermitirTodasEmpresas="false" ShowPesquisas="1" ShowGerenteVendas="true" ShowSupervisor="true" ShowVendedor="true"
                    ShowDataInicial="false" ShowDataFinal="false" StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
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
				<asp:GridView runat="server" ID="grdRelatorioPesquisas" AutoGenerateColumns="false" AllowSorting="true">
                    <HeaderStyle HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField HeaderText="Vendedor" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" SortExpression="Vendedor">
                            <ItemTemplate>
                                <div runat="server" id="lnkVendedor">
                                    <a href='relatoriopesquisasdiarias_vendedor.aspx?v=<%# StrReverse("ide=" & Filtro1.IdEmpresa & "_||_idp=" & Filtro1.IdPesquisa & "_||_ger=" & Filtro1.IDGerente & "_||_sup=" & Filtro1.IDSupervisor & "_||_ven=" & eval("idvendedor"))%>'><%#Eval("Vendedor")%></a>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="VisitasSorteadas" HeaderText="Sorteadas"  SortExpression="Sorteadas" />
                        <asp:BoundField DataField="QuantVisitasEfetuadas" HeaderText="Realizadas" SortExpression="Realizadas" />
                        <asp:BoundField DataField="QuantVisitasJustificadas" HeaderText="Justificadas" SortExpression="Justificadas" />
                        <asp:BoundField DataField="QuantVisitasReincidencia" HeaderText="Reincidência" SortExpression="Reincidencia" />
                        <asp:BoundField DataField="QuantVisitasPendentes" HeaderText="Pendente" Visible="false" />
                    </Columns>
                </asp:GridView>
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes' runat="server" id="divAreaBotoes">
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
    </div>
    <div class='AreaAjuda' runat="server" id="divAreaAjuda">
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>