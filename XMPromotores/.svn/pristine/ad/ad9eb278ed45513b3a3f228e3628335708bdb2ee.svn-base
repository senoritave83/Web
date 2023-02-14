<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="TipoTarefas.aspx.vb" Inherits="Pages.Cadastros.TipoTarefas" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='Filtro'>
        <div class='FiltroItem'>Filtrar por<br>
            <asp:TextBox Runat="server" ID='txtFiltro' />
        </div> 
        <div class='FiltroLetras'>
			<xm:Letras ID="Letras1" runat="server" />
		</div>
		<div class='FiltroBotao'>
            <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
        </div>
    </div>	
	<div class='ListArea'>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='false' AllowSorting='true' CellPadding="1" CellSpacing="1">
				    <HeaderStyle HorizontalAlign='Left' />
					<columns>
						<asp:HyperLinkField HeaderStyle-HorizontalAlign="Left" DataNavigateUrlFields="IDTipoTarefa" DataNavigateUrlFormatString="TipoTarefa.aspx?IDTipoTarefa={0}" DataTextField="TipoTarefa" HeaderText='<%$ Settings: caption, Loja.TipoTarefa, "Tipo de Tarefa" %>' SortExpression='TipoTarefa'  />
						<asp:BoundField HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center"  HeaderText="Criado" DataField="Criado" SortExpression='Criado' />
                        <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="center" ItemStyle-HorizontalAlign="center" >
                            <ItemTemplate>
                            <%#iif(Eval("Ativo")=1,"Ativo", "Inativo") %>
                            </ItemTemplate>
                        </asp:TemplateField>
					</columns>
					<EmptyDataTemplate>
					    <div class='divEmptyRow'>
					        N&atilde;o h&aacute; tipos de tarefas com o filtro selecionado!
					    </div>
					</EmptyDataTemplate>
				</asp:GridView>
                <xm:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='TipoTarefa.aspx?idTipoTarefa=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='TipoTarefas.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, TipoTarefa.Exportar, false %>' />
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

