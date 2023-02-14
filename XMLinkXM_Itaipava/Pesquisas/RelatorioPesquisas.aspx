<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="RelatorioPesquisas.aspx.vb" Inherits="Relatorios_Performance_Pesquisas" title="Untitled Page" %>

<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register Src="../Controls/Paginate.ascx" Tagname="Paginate" Tagprefix="uc1" %>
<%@ Register src="~/Relatorios/Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
            <uc1:Filtro ID="Filtro1" runat="server" ShowGerenteVendas="false" ShowSupervisor="false" ShowVendedor="false"
                    ShowFiltro="true" FiltroSize="300" ShowDataInicial="true" ShowDataFinal="true" StatusClass='FiltroItem'  DataInicialClass='FiltroItem' />
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
                        <asp:HyperLinkField DataNavigateUrlFields="IDPesquisa" DataNavigateUrlFormatString="PerformancePesquisa.aspx?IDPesquisa={0}" DataTextField="Pesquisa" HeaderText="Pesquisa" SortExpression="Pesquisa" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"/>            
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Per&iacute;odo
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# String.Format("{0: MM/yyyy}", Eval("DataInicio"))%> &nbsp;até&nbsp; <%# String.Format("{0: MM/yyyy}", Eval("DataFim")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Esperados" HeaderText="Total" />
                        <asp:BoundField DataField="Sorteados" HeaderText="Sorteados" />
                        <asp:BoundField DataField="Justificados" HeaderText="Justificados" />
                        <asp:BoundField DataField="Realizados" HeaderText="Realizados" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Pendentes
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Esperados") - Eval("Justificados") - Eval("Realizados")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                Progresso
                            </HeaderTemplate>
                            <ItemTemplate>
                                <uc1:progresso ID="progresso1" runat="server" MaxValue='<%# Eval("Esperados") %>'  Value='<%# Eval("Realizados") %>' SecondValue='<%# Eval("Justificados") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>