<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Classificacoes.aspx.vb" Inherits="Pages.Cadastros.Classificacoes" title="XM Promotores - Yes Mobile" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/Letras.ascx" tagname="Letras" tagprefix="uc2" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
	<asp:UpdatePanel ID="updFiltro" runat="server">
	    <ContentTemplate>
			<div class='Filtro'>
				<div class='FiltroItem'>
					<asp:Label runat="server" id="lblFiltrarPor">Filtrar por</asp:Label>
					<br>
					<asp:TextBox Runat="server" ID='txtFiltro' />
				</div> 
				<div class='FiltroLetras'>
					<uc2:Letras ID="Letras1" runat="server" />
				</div>
				<div class='FiltroBotao'>
					<asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
				</div>
			</div>	
	    </ContentTemplate>
	</asp:UpdatePanel> 
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDClassificacao, Tipo" DataNavigateUrlFormatString="Classificacao.aspx?idtipo={1}&IDClassificacao={0}" DataTextField="Classificacao" HeaderText="Classificacao" SortExpression="Classificacao"  />
					</columns>
					<EmptyDataTemplate>
				        <div class='GridHeader'>&nbsp;</div>					    
					    <div class='divEmptyRow'>
							<asp:Label runat='server' ID='lblNaoEncontrados'>
								N&atilde;o h&aacute; classifica&ccedil;&otilde;es com o filtro selecionado!
							</asp:Label>
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' id='btnNovo' cssclass="Botao" Text=" Novo " />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, Classificacao.Exportar, false %>' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Novo:</b>
				Abre para edi&ccedil;&atilde;o um novo registro.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

