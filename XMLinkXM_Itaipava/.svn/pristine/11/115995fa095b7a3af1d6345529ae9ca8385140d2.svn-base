<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="RelatorioPesquisasDiarias_Vendedor.aspx.vb" Inherits="Pesquisas_RelatorioPesquisasDiarias_Vendedor" %>
<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register Src="../Controls/Paginate.ascx" Tagname="Paginate" Tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class='EditArea'>
        <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='1000' DynamicLayout='false'>
            <ProgressTemplate>
                <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
            </ProgressTemplate>
        </asp:UpdateProgress> 
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
		        <div class='divEditArea'>
		            <div class='divHeader'>&nbsp;</div>
                    <div class='trField cb' runat='server'  id='trPesquisa' visible='<%$Settings: visible, Pesquisa.Pesquisa, true %>' >
				        <div class='tdFieldHeader cb fl'>
					        Vendedor:
				        </div>
				        <div class='tdField fl'>
					        <asp:Label runat='server' ID='lblVendedor'></asp:Label>
				        </div>
			        </div>
			        <div class='trField cb' runat='server'  id='Div1'>
				        <div class='tdFieldHeader cb fl'>
					        Cliente:
				        </div>
				        <div class='tdField fl'>
					        <asp:TextBox runat='server' ID='txtCliente' style="width:200px;"></asp:TextBox>
				        </div>
                    </div>
			        <div class='trField cb' runat='server'  id='Div2'>
                        <div class='tdFieldHeader fl'>
					        Status:
				        </div>
				        <div class='tdField fl'>
					        <asp:DropDownList DataTextField="Justificativa" DataValueField="IdJustificativa" runat="server" ID="drpStatusPesquisa"></asp:DropDownList>
				        </div>
			        </div>
                    <br class='cb' />
                    <div class='AreaBotoes' runat="server" id="divAreaBotoes">
                        <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" />
                    </div>
		        </div>
		        <div class='ListArea'>
			        <asp:GridView runat="server" ID="grdRelatorioPesquisasVendedor" AutoGenerateColumns="false" AllowSorting="true">
                        <HeaderStyle HorizontalAlign="Center" />
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:TemplateField HeaderText="Cliente" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" SortExpression="Cliente">
                                <ItemTemplate>
                                    <a href='relatoriopesquisasdiarias_visita.aspx?v=<%# strReverse("ide=" & ViewState("IdEmpresa") & "_||_idp=" & ViewState("IdPesquisa") & "_||_ger=" & ViewState("IdGerente") & "_||_sup=" & ViewState("IdSupervisor") & "_||_ven=" & eval("idvendedor") & "_||_pes=" & eval("idpesquisa") & "_||_vis=" & eval("idvisita") & "_||_di=" & ViewState("DataInicial") & "_||_df=" & ViewState("DataFinal"))%>'><%#Eval("Cliente")%></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdPesquisa" HeaderText="Id da Pesquisa" />
                            <asp:BoundField DataField="Data" HeaderText="Data" SortExpression="Data" />
                            <asp:BoundField DataField="Situacao" HeaderText="Situação" SortExpression="Situacao" />
                        </Columns>
                    </asp:GridView>
                    <uc1:Paginate ID="Paginate1" runat="server" />
	            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class='AreaBotoes'>
        <asp:Button runat="server" id="btnVoltar" CssClass="Botao" Text=" Voltar " />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

