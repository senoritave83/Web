<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="responsaveis.aspx.vb" Inherits="configuracoes_responsaveis" title="Gestor de O.S" %>
<%@ Register assembly="XMWeb" namespace="XMSistemas.Web.Controls" tagprefix="xm" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<script type='text/javascript'>

    function fncOrdenacao(p_Sort) {
        var vUrl = 'responsaveis.aspx?Sort=' + p_Sort + '&Desc=<%=ViewState("Desc")%>';

        window.location.href = vUrl;
    }
        
</script>
    <table width="101%" align="center" class="resumo">        
        <tr style="height:30px;background-color:#DDDDDD;">
            <td style="width:95px;color:White;background-color:#BBBBBB;font-weight:bold">
                RESUMO
            </td>
            <td style="width:150px;">
                Respons&aacute;veis Pendentes:&nbsp;<asp:label id="lblPendente" runat="server" Font-Bold="true"></asp:label>
            </td>
            <td style="width:150px;">
                Respons&aacute;veis Bloqueados:&nbsp;<asp:label id="lblBloqueado" runat="server" Font-Bold="true"></asp:label>
            </td>            
            <td style="width:150px;">
                Respons&aacute;veis Ativos:&nbsp;<asp:label id="lblAtivo" runat="server" Font-Bold="true"></asp:label>
            </td>
            <td style="width:150px;">
                Respons&aacute;veis sem Servi&ccedil;o:&nbsp;<asp:label id="lblSemServico" runat="server" Font-Bold="true"></asp:label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr> 
            <td class='Linha1' colspan='6'>
                <img src="../../images/transpa.gif" height="1" alt=""/>
            </td>
        </tr> 
    </table>
	<table width="101%" align="center">
		<tr>
			<td>
				<asp:Repeater Runat="server" EnableViewState="False" id="rptResponsaveis">                    
					<HeaderTemplate>						
                        <tr class='Header1'> 
                            <td colspan='6'>
                                <input type='checkbox' name='chkSel' onclick="selectAll(this.form.chkResponsavel, this.form.chkSel.checked);" title="Selecionar Todos">Selecionar Todos
                            </td>
						</tr>
                        <tr> 
                            <td class='Linha1' colspan='6'>
                                <img src="../../images/transpa.gif" height="1" alt=""/>
                            </td>
                        </tr>                
	                    <tr class="Header2">
	                        <td>&nbsp;</td>
		                    <td><a href='javascript:void();' onclick="fncOrdenacao('Responsavel')">Respons&aacute;vel</a></td>
		                    <td><a href='javascript:void();' onclick="fncOrdenacao('Telefone')">Telefone</a></td>
		                    <td><a href='javascript:void();' onclick="fncOrdenacao('Grupo')">Grupo</a></td>
		                    <td><a href='javascript:void();' onclick="fncOrdenacao('Status')">Status</a></td>
		                    <td><a href='javascript:void();' onclick="fncOrdenacao('Criado')">Criado</a></td>
	                    </tr>                        
					</HeaderTemplate>
					<ItemTemplate>                        
						<tr class="griditem">
							<td width="10">
                                <input type="checkbox" name="chkResponsavel" value="<%#DataBinder.Eval(Container.DataItem, "IDResponsavel")%>">
                            </td>
							<td width="300" align="left">
                                <a href="responsavel_det.aspx?id=<%#DataBinder.Eval(Container.DataItem, "IDResponsavel")%>"><%#DataBinder.Eval(Container.DataItem, "Responsavel")%></asp:HyperLink>
                            </td>
							<td align="left">
                                <%#DataBinder.Eval(Container.DataItem, "Telefone")%>
                            </td>	
							<td align="left">
                                <%#DataBinder.Eval(Container.DataItem, "Grupo")%>
                            </td>	
							<td align="left">
                                <%#DataBinder.Eval(Container.DataItem, "Status")%>
                            </td>	
							<td align="left">
                                <%#FormatDateTime(DataBinder.Eval(Container.DataItem, "Criado"), 2)%>
                            </td>	
						</tr>                         
					</ItemTemplate>                                                        
                    <FooterTemplate>                                                							            
				    </FooterTemplate>
                </asp:Repeater>
			</td>
		</tr>
        <tr>
            <td colspan='6'>
                <xm:Paginate ID="Paginate1" runat="server" />
            </td>                            
        </tr>  
        <tr class='Footer1'> 
            <td colspan='6'>
                <img width="1" height="25" src="../../images/transpa.gif" alt=""/>
            </td>
        </tr>	
	</table>
</asp:Content>

<asp:Content runat="server" ID='Content2' ContentPlaceHolderID="Botoes">     
	<asp:ImageButton ImageUrl="../images/buttons/btn_voltar.png" id="btnVoltar" runat="server" CssClass="botao_voltar"></asp:ImageButton>    
    <asp:ImageButton ImageUrl="../images/buttons/btn_excluir.png" id="btnExcluir" runat="server" CssClass="botao_exclui_grupos"></asp:ImageButton>
    <asp:ImageButton ImageUrl="../images/buttons/btn_adicionar.png" id="btnAdicionar" runat="server" CssClass="botao_adicionar"></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt class="current"><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>


<asp:Content runat="server" ID='Content3' ContentPlaceHolderID="Ajuda">    
	<b>Novo:</b> Adicione um novo respons&aacute;vel a lista de respons&aacute;veis de Campo.<br />
    <b>Excluir:</b> Exclua um ou mais respons&aacute;veis selecionados pelas caixas de sele&ccedil;&atilde;o.
</asp:Content>

