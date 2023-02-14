<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Pesquisas.aspx.vb" Inherits="Pages.Cadastros.Pesquisas" title="XM Promotores - Yes Mobile" %>
<%@ Register Src="../Controls/Paginate.ascx" TagName="Paginate" TagPrefix="uc1" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro' Width="500px" />
        </div> 
        <div class='FiltroBotao'>
            <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
        </div>
    </div>	
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true'>
				    
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDPesquisa" DataNavigateUrlFormatString="Pesquisa.aspx?IDPesquisa={0}" DataTextField="Pesquisa" HeaderText="Pesquisa" HeaderStyle-HorizontalAlign='Left' ItemStyle-HorizontalAlign='Left' SortExpression="Pesquisa" />
						<asp:TemplateField HeaderText="Concorrente" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Concorrente" ><ItemTemplate><%#IIf(Eval("Concorrente") = 1, "Sim", IIf(Eval("Concorrente") = 2, "Todos", "N&atilde;o"))%></ItemTemplate></asp:TemplateField>
						<asp:TemplateField HeaderText="Ativa" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" SortExpression="Ativo" ><ItemTemplate><%#IIf(Eval("Ativo") = 1, "Sim", "N&atilde;o")%></ItemTemplate></asp:TemplateField>
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
					        N&atilde;o h&aacute; Pesquisas cadastradas!
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
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Pesquisa.aspx?idpesquisa=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Pesquisas.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, Pesquisa.Exportar, false %>' />
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

