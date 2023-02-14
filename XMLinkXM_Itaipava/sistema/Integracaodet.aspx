<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Integracaodet.aspx.vb" Inherits="Pages.Sistema.IntegracaoDet" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='ListArea'>
		<asp:GridView runat='server' id='grdDetalhes' AutoGenerateColumns='false'>
		    <HeaderStyle HorizontalAlign='Left' />
			<columns>
			    <asp:BoundField DataField='Data' HeaderText='Data' />
			    <asp:BoundField DataField='Message' HeaderText='Mensagem' />
			    <asp:TemplateField HeaderText='Status'>
			        <ItemTemplate>
			            <%# IIF(Eval("Erro"), "Com erro", "OK") %>
			        </ItemTemplate>
			    </asp:TemplateField>
			</columns>
			<EmptyDataTemplate>
		        <div class='GridHeader'>&nbsp;</div>					    
			    <div class='divEmptyRow'>
					<asp:Label runat='server' ID='lblNaoEncontrados'>
						N&atilde;o h&aacute; dados com o filtro selecionado!
					</asp:Label>
			    </div>
			</EmptyDataTemplate>
		</asp:GridView>
	</div>
	<div class='AreaBotoes'>
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='integracao.aspx'" />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

