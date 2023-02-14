<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Perguntas.aspx.vb" Inherits="Pages.Cadastros.Perguntas" title="XM Promotores - Yes Mobile" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
<%@ Register src="../controls/ExportButton.ascx" tagname="ExportButton" tagprefix="uc3" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class='Filtro'>
            <div class='FiltroItem'>Filtrar por<br>
                <asp:TextBox Runat="server" ID='txtFiltro' Width="500px" />
            </div> <br class='cb' />
            <div class='FiltroItem' style="float:none">Tipo de Pergunta<br>

                <asp:CheckBoxList runat="server" ID='chkTipoPergunta'>
                    <asp:ListItem Text="Na Loja" Value="1"></asp:ListItem>
                    <asp:ListItem Text="No segmento" Value="4"></asp:ListItem>
                    <asp:ListItem Text="Na categoria" Value="8"></asp:ListItem>
                    <asp:ListItem Text="No Produto" Value="16"></asp:ListItem>
                    <asp:ListItem Text="Por Amostra" Value="2"></asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <div class='FiltroBotao'>
                <asp:Button runat='server' ID='btnFiltrar' Text='Filtrar' />
            </div>
        </div>	
	    <div class='ListArea'>
				    <asp:GridView runat='server' id='GridView1' AutoGenerateColumns='False' AllowSorting='true' CellPadding="1" CellSpacing="1">
					    <columns>
						    <asp:HyperLinkField DataNavigateUrlFields="IDPergunta" DataNavigateUrlFormatString="Pergunta.aspx?IDPergunta={0}" DataTextField="Pergunta" HeaderText="Pergunta" SortExpression='Pergunta' ItemStyle-HorizontalAlign="left"  />
						    <asp:TemplateField HeaderText="Tipo de Campo" ItemStyle-HorizontalAlign="Center" SortExpression="TipoCampo"><ItemTemplate><%# Eval("DesTipoCampo") %></ItemTemplate></asp:TemplateField>
						    <asp:TemplateField HeaderText="Pergunta de" ItemStyle-HorizontalAlign="Center" SortExpression="PerguntaLoja"><ItemTemplate><%# TipoPergunta(Eval("PerguntaLoja"))%></ItemTemplate></asp:TemplateField>
                            <asp:TemplateField HeaderText="Prioridade" ItemStyle-HorizontalAlign="Center" SortExpression="Prioridade"><ItemTemplate><%# Eval("Prioridade")%></ItemTemplate></asp:TemplateField>
                            <asp:TemplateField HeaderText="Pergunta Condicional" ItemStyle-HorizontalAlign="Center" SortExpression="PerguntaCondicional"><ItemTemplate><%# IIf(Eval("TipoDependencia") = 1 Or Eval("RespostaDependencia") = 1, "Sim", "N&atilde;o")%></ItemTemplate></asp:TemplateField>
						    <asp:TemplateField HeaderText="Pergunta Ativa" ItemStyle-HorizontalAlign="Center" SortExpression="PerguntaAtiva"><ItemTemplate><%# IIF(Eval("Ativo"), IIF(Eval("TipoCampo") = 0, IIf(Eval("Respostas") = "0","Incompleta", "Sim"), "Sim"), "N&atilde;o")%></ItemTemplate></asp:TemplateField>
					    </columns>
				    </asp:GridView>
                    <xm:Paginate ID="Paginate1" runat="server" />
	    </div>
	</ContentTemplate>
    </asp:UpdatePanel>		
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

