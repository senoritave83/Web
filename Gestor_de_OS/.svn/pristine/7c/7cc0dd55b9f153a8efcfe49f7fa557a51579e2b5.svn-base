<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="mensagemdet.aspx.vb" Inherits="configuracoes_mensagemdet" title="Gestor de O.S" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="95%" border="0" align="center" cellpadding="2" cellspacing="0">
        <tr class='Header1'> 
            <td>
                <strong>&nbsp;</strong>
            </td>
        </tr>
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" /></td>
        </tr>                
        <tr class="Header2">
            <td>Dados da mensagem.</td>
        </tr>
        <tr>
		<td class="cinza1">	
			<!-- INICIO CONTEÚDO -->
			<table width="100%">				
				<tr>
					<td style="text-align:left;padding:10px 0 5px 0;">
                        Nome da Mensagem
						<asp:RequiredFieldValidator Runat="server" ID='valNome' ControlToValidate="txtNome" ErrorMessage='Campo obrigatório!' />
						<br />
						<asp:TextBox Runat="server" ID='txtNome' CssClass="formulario" Width="98%" MaxLength="50" />
					</td>
				</tr>
				<tr>
					<td style="text-align:left;">
                        Texto
						<asp:RequiredFieldValidator Runat="server" ID="valMensagem" ControlToValidate="txtMensagem" ErrorMessage='Campo obrigatório!' />
						<br />
						<asp:TextBox Runat="server" ID="txtMensagem" CssClass="formulario" Width="98%" TextMode="MultiLine" Rows="3" MaxLength="300" onKeyDown='return checkSize();' onBlur='Trim();' />												
					</td>
				</tr>
			</table>                        					
			<script type="text/javascript">
			    function checkSize()
				    {
				    var txtMensagem = document.getElementById('<%=txtMensagem.clientID%>')
				    var i = txtMensagem.value.length;
				    if (i < 300)
					    {
					    spSize.innerHTML = 300 - i;
					    return true;
					    }
				    else
					    {
					    spSize.innerHTML = 0;
					    if (event.keyCode != 46 && event.keyCode != 8 && event.keyCode != 39  && event.keyCode != 38  && event.keyCode != 37  && event.keyCode != 40)
						    return false;
					    }
				    }
			    function Trim()
				    {
                    var txtMensagem = document.getElementById('<%=txtMensagem.clientID%>')
				    if(txtMensagem.value.length > 300){
					    txtMensagem.value = txtMensagem.value.substring(0, 300);}}
			</script>
            <br />
		</td>
	</tr>
    <tr class='Footer1'> 
        <td><font class="cinza1">Caracteres disponíveis: <i><span id='spSize'>300</span></i></font></td>
    </tr>	
</table>
			<script type="text/javascript">
			checkSize();
			</script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:ImageButton Runat="server" ID="btnVoltar" ImageUrl="../images/buttons/btn_voltar.png" CausesValidation="false" onmouseover="MM_swapImage('btnVoltar','','../images/bt_voltar_over.gif',1)" onmouseout="MM_swapImgRestore()" ></asp:ImageButton>	
	<asp:ImageButton Runat="server" ID="btnExcluir" ImageUrl="../images/buttons/btn_excluir.png" onmouseover="MM_swapImage('btnExcluir','','../images/bt_excluir_over.gif',1)" onmouseout="MM_swapImgRestore()" ></asp:ImageButton>
    <asp:ImageButton Runat="server" ID='btnNovo' ImageUrl="../images/buttons/btn_novo.png" onmouseover="MM_swapImage('btnNovo','','../images/bt_novo_over.gif',1)" onmouseout="MM_swapImgRestore()" ></asp:ImageButton>	
    <asp:ImageButton Runat="server" ID="btnSalvar" ImageUrl="../images/buttons/btn_salvar.png" onmouseover="MM_swapImage('btnSalvar','','../images/bt_salvar_over.gif',1)" onmouseout="MM_swapImgRestore()" ></asp:ImageButton>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
	&bull; <b>Novo:</b> Adicione uma nova mensagem à lista de Mensagens Padrão.<br />
	&bull; <b>Excluir:</b> Exclua uma ou mais mensagens selecionadas pelas caixas de sele&ccedil;&atilde;o.<br />
	&bull; <b>Salvar:</b> Salva as alterações efetuadas na Mensagem Padrão.
</asp:Content>