<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="PerformanceRevenda.aspx.vb" Inherits="Relatorios_Performance_Revenda" title="Untitled Page" %>

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
					        <%= clsPesquisa.Pesquisa %>
				        </div>
			        </div>
                    <div class='trField cb' runat='server'  id='trPeriodo' visible='<%$Settings: visible, Performance.Pesquisa, true %>' >
				        <div class='tdFieldHeader cb fl'>
					        Per&iacute;odo:
				        </div>
				        <div class='tdField fl'>
					        <%= clsPesquisa.DataInicio%> &nbsp;at&eacute;&nbsp; <%= clsPesquisa.DataFim%>
				        </div>
			        </div>
                    <div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, Performance.Pesquisa, true %>' >
				        <div class='tdFieldHeader cb fl'>
					        Revenda:
				        </div>
				        <div class='tdField fl'>
					        <%= clsEmpresa.Empresa %>
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
				<asp:GridView runat="server" ID="grdPerformanceRevenda" AutoGenerateColumns="false" ShowFooter="true">
                    <HeaderStyle HorizontalAlign="Left" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Vendedor
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# Eval("Vendedor")%>
                            </ItemTemplate>
                            <FooterTemplate>
                                Total
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Total
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# FormatNumber(Soma.Add(Eval("Esperados"), "Esperados"), 0) %>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%= FormatNumber(Soma.Item("Esperados").Sum, 0)%>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Sorteados
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# FormatNumber(Soma.Add(Eval("Sorteados"), "Sorteados"), 0)%>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%= FormatNumber(Soma.Item("Sorteados").Sum, 0)%>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Justificados
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# FormatNumber(Soma.Add(Eval("Justificados"), "Justificados"), 0)%>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%= FormatNumber(Soma.Item("Justificados").Sum, 0)%>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Realizados
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# FormatNumber(Soma.Add(Eval("Realizados"), "Realizados"), 0)%>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%= FormatNumber(Soma.Item("Realizados").Sum, 0)%>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
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
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='PerformancePesquisa.aspx?IDPesquisa=<%= clsPesquisa.IDPesquisa %>'" />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>