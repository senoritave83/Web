<%@ Page Title="" Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="PrevisaoPesquisasDetalhe.aspx.vb" Inherits="Pesquisas_PrevisaoPesquisasDetalhe" %>

<%@ Register src="../controls/progresso.ascx" tagname="progresso" tagprefix="uc1" %>
<%@ Register Src="../Controls/Paginate.ascx" Tagname="Paginate" Tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class='EditArea'>
		        <div class='divEditArea'>
		            <div class='divHeader'>&nbsp;</div>
                    <div class='trField cb' runat='server'  id='trPesquisa'  >
				        <div class='tdFieldHeader cb fl'>
					        Nome da Pesquisa:
				        </div>
				        <div class='tdField fl'>
					        <asp:Label runat='server' ID='lblPesquisa'></asp:Label>
				        </div>
			        </div>
			        <div class='trField cb' runat='server'  id='trDataInicio'  >
				        <div class='tdFieldHeader cb fl'>
					        Data Inicial:
				        </div>
				        <div class='tdField fl'>
					        <asp:Label runat='server' ID='lblDataInicial'></asp:Label>
				        </div>
			        </div>
			        <div class='trField cb' runat='server'  id='Div1'  >
				        <div class='tdFieldHeader cb fl'>
					        Data Final:
				        </div>
				        <div class='tdField fl'>
					        <asp:Label runat='server' ID='lblDataFinal'></asp:Label>
				        </div>
			        </div>
                    <div class='trField cb' runat='server'  id='Div2' >
				        <div class='tdFieldHeader cb fl'>
					        Visitas mês:
				        </div>
				        <div class='tdField fl'>
					        <asp:Label runat='server' ID='lblVisitasMes'></asp:Label>
				        </div>
			        </div>
                    <div class='trField cb' runat='server'  id='divVendedor' >
				        <div class='tdFieldHeader cb fl'>
					        Vendedor:
				        </div>
				        <div class='tdField fl'>
					        <asp:Label runat='server' ID='lblVendedor'></asp:Label>
				        </div>
			        </div>
                    <div class='trField cb' runat='server'  id='divVisualizar' >
				        <div class='tdFieldHeader cb fl'>
					        Visualizar:
				        </div>
				        <div class='tdField fl'>
					        <asp:RadioButtonList ID="rdpVisualizar" runat="server" AutoPostBack="true">
                                <asp:ListItem Text="Todos os resultados" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Com pesquisas previstas" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Com pesquisas realizadas" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Com pesquisas justificadas" Value="3"></asp:ListItem>
                                <asp:ListItem Text="Com pesquisas justificadas reincidentes" Value="4"></asp:ListItem>
                            </asp:RadioButtonList>
				        </div>
			        </div>
                    <div class='trField cb' runat='server'  id='divVisualizarDetalhes'>
				        <div class='tdFieldHeader cb fl'>
					        Visualizar:
				        </div>
				        <div class='tdField fl'>
					        <asp:RadioButtonList ID="rdpVisualizarDetalhes" runat="server" AutoPostBack="true">
                                <asp:ListItem Text="Todos os resultados" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Somente realizadas" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Somente não realizadas" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
				        </div>
			        </div>
		        </div>
                 <div class='trField cb' runat='server'  id='div3'>
				    <div class='tdFieldHeader cb fl'>
					    * Obs - Previsão contempla apenas clientes já sorteados até o momento.
				    </div>
                </div>
                <asp:UpdateProgress ID="updProgress" runat="Server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter='1000' DynamicLayout='false'>
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="Server" ImageUrl="~/imagens/pleasewait.gif" alt='Aguarde por favor...' /> Por favor aguarde...
                    </ProgressTemplate>
                </asp:UpdateProgress> 
		        <div class='ListArea'>
				    <asp:GridView runat="server" DataKeyNames="IdPesquisa,IdVendedor" ID="grdRelatorioPesquisasVendedor" AutoGenerateColumns="false">
                        <HeaderStyle HorizontalAlign="Center" />
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                             <asp:buttonfield buttontype="Link"
                            commandname="Detalhes"
                            headertext="Vendedor" 
                            DataTextField="Vendedor" 
                            ItemStyle-HorizontalAlign=Left HeaderStyle-HorizontalAlign=Left />
                            <asp:BoundField DataField="QuantidadePrevista" HeaderText="Qtde Prevista" />
                            <asp:BoundField DataField="QuantidadeRealizada" HeaderText="Qtde Realizada" />
                            <asp:BoundField DataField="QuantidadeJustificada" HeaderText="Qtde Justificada" />
                            <asp:BoundField DataField="QuantidadeReincidencia" HeaderText="Qtde Reincidencia" />
                        </Columns>
                    </asp:GridView>
                    <uc1:Paginate ID="Paginate1" runat="server" />
                    <asp:GridView runat="server" DataKeyNames="IdPesquisa,IdVendedor" ID="grdRelatorioPesquisasVendedor_Detalhes" AutoGenerateColumns="false" Visible="false">
                        <HeaderStyle HorizontalAlign="Center" />
                        <RowStyle HorizontalAlign="Center" />
                        <Columns>
                            <asp:BoundField DataField="Cliente" HeaderText="Cliente" ItemStyle-HorizontalAlign=Left HeaderStyle-HorizontalAlign=Left />
                            <asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-HorizontalAlign=Left HeaderStyle-HorizontalAlign=Left />
                            <asp:BoundField DataField="Data" HeaderText="Realizada em" />
                            <asp:BoundField DataField="DataVisInicio" HeaderText="Início da Visita" />
                            <asp:BoundField DataField="DataVisFim" HeaderText="Fim da Visita" />
                        </Columns>
                    </asp:GridView>
                    <uc1:Paginate ID="Paginate2" runat="server" Visible="false" />
	            </div>
            </div>
            <div class='AreaBotoes'>
                <asp:Button runat="server" id="btnVoltar" CssClass="Botao" Text=" Voltar " />
            </div>
		</ContentTemplate>
    </asp:UpdatePanel>		
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

