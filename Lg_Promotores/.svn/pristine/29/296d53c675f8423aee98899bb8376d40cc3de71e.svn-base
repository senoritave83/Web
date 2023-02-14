<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Perguntas.aspx.vb" Inherits="Pages.Cadastros.Perguntas" title="XM Promotores - Yes Mobile" %>
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
				<asp:GridView runat='server' id='GridView1' AutoGenerateColumns='False' AllowSorting='true'>
					<columns>
						<asp:HyperLinkField DataNavigateUrlFields="IDPergunta" DataNavigateUrlFormatString="Pergunta.aspx?IDPergunta={0}" DataTextField="Pergunta" HeaderText="Pergunta" SortExpression='Pergunta'  />
						<asp:TemplateField HeaderText="Tipo de Campo" ItemStyle-HorizontalAlign="Center" SortExpression="TipoCampo"><ItemTemplate><%# IIF(Eval("TipoCampo") = 0,  IIF(Eval("MultiResposta"), "Sele&ccedil;&atilde;o m&uacute;tipla", "Sele&ccedil;&atilde;o"), IIF(Eval("TipoCampo") = 1, "Num&eacute;rico", IIF(Eval("TipoCampo") = 2, "Foto", IIF(Eval("TipoCampo") = 3, "Data", "Decimal"))))%></ItemTemplate></asp:TemplateField>
						<asp:TemplateField HeaderText="Pergunta de" ItemStyle-HorizontalAlign="Center" SortExpression="PerguntaLoja"><ItemTemplate><%# IIF(Eval("PerguntaLoja"), "Loja", "Produto")%></ItemTemplate></asp:TemplateField>
						<asp:TemplateField HeaderText="Pergunta Ativa" ItemStyle-HorizontalAlign="Center" SortExpression="TipoCampo"><ItemTemplate><%# IIF(Eval("Ativo"), IIF(Eval("TipoCampo") = 0, IIf(Eval("Respostas") = "0","Incompleta", "Sim"), "Sim"), "N&atilde;o")%></ItemTemplate></asp:TemplateField>
                        <asp:TemplateField HeaderText="Prioridade" ItemStyle-HorizontalAlign="Center" SortExpression="Prioridade"><ItemTemplate><%# Eval("Prioridade")%></ItemTemplate></asp:TemplateField>
					</columns>
				</asp:GridView>
                <uc1:Paginate ID="Paginate1" runat="server" />
			</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID='btnFiltrar' EventName='Click'  />
            </Triggers> 
        </asp:UpdatePanel>		
	</div>
    <div class='AreaBotoes'>
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Pergunta.aspx?idpergunta=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='default.aspx'" />
        <uc3:ExportButton ID="ExportButton1" runat="server" visible='<%$Settings: visible, Pergunta.Exportar, false %>' />
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

