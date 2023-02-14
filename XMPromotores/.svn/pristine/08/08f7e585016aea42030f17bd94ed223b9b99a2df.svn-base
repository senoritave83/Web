<%@ Page Language="VB" MasterPageFile="~/Cadastros\/export/export.master" AutoEventWireup="false" CodeFile="Perguntas.aspx.vb" Inherits="Pages.Cadastros.export.Perguntas" title="XM Promotores - Yes Mobile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView runat='server' ID='grdExportar' SkinID='GridExportar' EnableViewState='false' AutoGenerateColumns='false'>
        <HeaderStyle cssclass='xl24'/>
        <RowStyle cssclass='xl25' />
        <Columns>
            <asp:BoundField HeaderText="IDPergunta" DataField="IDPergunta" ItemStyle-CssClass="xl28" />
        	<asp:BoundField HeaderText="Pergunta" DataField="Pergunta" ItemStyle-CssClass="xl28" />
			<asp:TemplateField HeaderText="Tipo de Campo" ItemStyle-HorizontalAlign="Center"><ItemTemplate><%# IIF(Eval("TipoCampo") = 0,  IIF(Eval("MultiResposta"), "Sele&ccedil;&atilde;o m&uacute;tipla", "Sele&ccedil;&atilde;o"), "Num&eacute;rico")%></ItemTemplate></asp:TemplateField>
			<asp:TemplateField HeaderText="Perguntar na Loja" ItemStyle-HorizontalAlign="Center"><ItemTemplate><%# IIF(Eval("PerguntaLoja"), "Sim", "N&atilde;o")%></ItemTemplate></asp:TemplateField>
			<asp:TemplateField HeaderText="Pergunta Ativa" ItemStyle-HorizontalAlign="Center"><ItemTemplate><%# IIF(Eval("Ativo"), IIF(Eval("TipoCampo") = 0, IIf(Eval("Respostas") = "0","Incompleta", "Sim"), "Sim"), "N&atilde;o")%></ItemTemplate></asp:TemplateField>
        </Columns>
    </asp:GridView>    
</asp:Content>

