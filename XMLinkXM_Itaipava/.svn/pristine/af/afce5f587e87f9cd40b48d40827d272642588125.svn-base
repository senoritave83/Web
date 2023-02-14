<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="RelatorioAcompanhamentoPesquisas.aspx.vb" Inherits="Pesquisas_RelatorioAcompanhamentoPesquisas" %>

<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register Src="../Controls/Paginate.ascx" Tagname="Paginate" Tagprefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register src="~/Relatorios/Filtro.ascx" tagname="Filtro" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgress1" runat="Server" AssociatedUpdatePanelID="updAcompanhamento" DisplayAfter='0' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image10" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
    <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='1000' DynamicLayout='false'>
        <ProgressTemplate>
            <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
        </ProgressTemplate>
    </asp:UpdateProgress> 
	<asp:UpdatePanel ID="updAcompanhamento" runat="server">
	    <ContentTemplate>
        	<uc1:Filtro ID="Filtro1" runat="server" 
                                    ShowPesquisas="2" 
                                    TextoTodasPesquisas="TODAS AS PESQUISAS DISPONÍVEIS" 
                                    ShowDataInicial="false" ShowDataFinal="false" 
                                    ShowDias='false' 
                                    ShowGerenteVendas='false' 
                                    ShowSupervisor='false' 
                                    ShowVendedor='false' 
                                    ShowMapa='false' 
                                    ShowStatus='false'
                                    StatusClass='FiltroItem' VendedorClass='FiltroItem' DataInicialClass='FiltroItem' />
            <asp:Label ID="lblPeriodoData" runat="server" Font-Bold="true" Height="16px"></asp:Label>
	    </ContentTemplate>
	</asp:UpdatePanel> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat="server" ID="grdPerformancePesquisa" AutoGenerateColumns="false" EnableViewState="false">
                    <HeaderStyle HorizontalAlign="Left" />
                    <Columns>
                        <asp:BoundField ItemStyle-BorderColor="Gainsboro" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="CodigoEmpresa" HeaderText="CÓD." />
                        <asp:BoundField ItemStyle-BorderColor="Gainsboro" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" DataField="Revenda" HeaderText="REVENDA" />
                        <asp:BoundField ItemStyle-BorderColor="Gainsboro" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataField="Total" HeaderText="TOTAL" />
                        <asp:TemplateField ItemStyle-BorderColor="Gainsboro" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                DIGITADOS
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Realizados") + Eval("JustificadosSemReincidencia")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-BorderColor="Gainsboro" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                %
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# FormataPorcentagem(Eval("Realizados"), Eval("JustificadosSemReincidencia") , Eval("Total")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-BorderColor="Gainsboro" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                RESTANTES
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Total") - (Eval("Realizados") + Eval("JustificadosSemReincidencia"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ItemStyle-BorderColor="Gainsboro" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                PREVISÃO<br />
                                DE TÉRMINO
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# fncTempoRestanteDias(Eval("Realizados") + Eval("JustificadosSemReincidencia"), Eval("DiasPassados"), Eval("Total"))%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='RelatorioPesquisas.aspx'" />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>