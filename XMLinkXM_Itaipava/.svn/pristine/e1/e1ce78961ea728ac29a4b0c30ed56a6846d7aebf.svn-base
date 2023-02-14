<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="PerformancePesquisa.aspx.vb" Inherits="PESQUISAS.Relatorios_Performance_Pesquisa" title="Untitled Page" %>

<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register Src="../Controls/Paginate.ascx" Tagname="Paginate" Tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='EditArea'>
		        <div class='divEditArea'>
		            <div class='divHeader'>&nbsp;</div>
			        <div class='trField cb' runat='server'  id='trPesquisa' visible='<%$Settings: visible, Performance.Pesquisa, true %>' >
				        <div class='tdFieldHeader cb fl'>
					        Pesquisa:
				        </div>
				        <div class='tdField fl'>
                            <asp:Label runat=server ID=lblPesquisa></asp:Label>
				        </div>
			        </div>
                    <div class='trField cb' runat='server'  id='trPeriodo' visible='<%$Settings: visible, Performance.Pesquisa, true %>' >
				        <div class='tdFieldHeader cb fl'>
					        Per&iacute;odo:
				        </div>
				        <div class='tdField fl'>
                            <asp:Label runat=server ID=lblPeriodoPesquisa></asp:Label>
				        </div>
			        </div>
		        </div>
	        </div>
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
				<asp:GridView runat="server" ID="grdPerformancePesquisa" AutoGenerateColumns="false">
                    <HeaderStyle HorizontalAlign="Left" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Revenda
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a href='PerformanceRevenda.aspx?IDpesquisa=<%= ViewState(VW_IDPESQUISA)%>&IDRevenda=<%# Eval("IDRevenda")%>'><%# Eval("Revenda") %></a>
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
                                <%# Eval("Sorteados") - Eval("Justificados") - Eval("Realizados")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Progresso
                            </HeaderTemplate>
                            <ItemTemplate>
                                <uc1:progresso ID="progresso1" runat="server" MaxValue='<%# Eval("Sorteados") %>'  Value='<%# Eval("Realizados") %>' SecondValue='<%# Eval("Justificados") %>' />
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