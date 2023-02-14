<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="clientesdet.aspx.vb" Inherits="configuracoes_clientesdet" title="Gestor de O.S" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width="101%" align="center" style="text-align:left;">
    <tr class="Header2">
        <td colspan="3">
            Dados do cliente
        </td>
    </tr>		
   	<tr>		
		<td class='Cinza3' width="45%" style="padding:10px 10px 10px 10px;">
            Nome do Cliente
			<asp:RequiredFieldValidator Runat="server" ID='valNome' ErrorMessage='*' ControlToValidate='txtNome' />
			<br />
			<asp:TextBox Runat="server" ID='txtNome' CssClass="formulario" Width="100%" />
		</td>
		<td class='Cinza3'>Razão Social
			<br />
			<asp:TextBox Runat="server" ID="txtRazao" CssClass="formulario" Width="100%" />
		</td>
		<td class='Cinza3' width="30%" style="padding:0px 10px 0px 10px;">
            CNPJ <font class='Cinza2'>(11.111.111/0001-11)</font>
			<br />
			<asp:TextBox Runat="server" ID="txtCNPJ" CssClass="formulario" Width="100%" onFocus='fncCleanFormat(this);' onBlur='fncFormatText(this);' onKeyDown='return fncOnlyInteger();' />
		</td>
	</tr>
	<tr>
		<td class='Cinza3' colspan="2" style="padding:0px 0px 0px 10px;">
            Endereço
			<br />
			<asp:TextBox Runat="server" ID="txtEndereco" CssClass="formulario" Width="100%" />
		</td>
		<td class='Cinza3' style="padding:0px 10px 0px 10px;">Local de referência
			<br />
			<asp:TextBox Runat="server" ID="txtReferencia" CssClass="formulario" Width="100%" />
		</td>
	</tr>
	<tr>
		<td class='Cinza3' width="45%" style="padding:10px 10px 10px 10px;">
            Bairro
			<br />
			<asp:TextBox Runat="server" ID="txtBairro" CssClass="formulario" Width="100%" />
		</td>
		<td class='Cinza3'>
            Cidade
            <br />
			<asp:TextBox Runat="server" ID="txtCidade" CssClass="formulario" Width="100%" />
		</td>
		<td class='Cinza3' width="30%" style="padding:0px 10px 0px 10px;">
            CEP<font class='Cinza2'>(11111-111)</font>
			<br />
			<asp:TextBox Runat="server" ID="txtCep" CssClass="formulario" Width="100%" />
		</td>
	</tr>
	<tr>
		<td class='Cinza3' width="45%" style="padding:10px 10px 10px 10px;">
            UF
            <br />
			<asp:TextBox Runat="server" ID="txtUF" CssClass="formulario" Width="100%" />
		</td>
		<td class='Cinza3'>
            Contato
            <br />
			<asp:TextBox Runat="server" ID="txtContato" CssClass="formulario" Width="100%" />
		</td>
		<td class='Cinza3' width="30%" style="padding:0px 10px 0px 10px;">
            Telefone
            <br />
			<asp:TextBox Runat="server" ID="txtTelefone" CssClass="formulario" Width="100%" />
		</td>
	</tr>
	<tr>
		<td class='Cinza3' colspan="3" style="padding:0px 10px 10px 10px;">
            Observação
            <br />
			<asp:TextBox Runat="server" ID="txtObservacao" TextMode="MultiLine" Width="100%" Rows="3" CssClass="formulario" />            
		</td>
	</tr>				
    <tr class='Footer1'> 
        <td colspan="3">
            <img width="1" height="25" src="../images/transpa.gif" alt=""/>
        </td>
    </tr>							
</table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:ImageButton Runat="server" ID="btnVoltar" ImageUrl="../images/buttons/btn_voltar.png" CausesValidation="false" CssClass="botao_voltar"></asp:ImageButton>
    <asp:ImageButton Runat="server" ID='btnNovo' ImageUrl="../images/buttons/btn_novo.png" CssClass="botao"></asp:ImageButton>	
	<asp:ImageButton Runat="server" ID="btnExcluir" ImageUrl="../images/buttons/btn_excluir.png" CssClass="botao"></asp:ImageButton>
	<asp:ImageButton Runat="server" ID="btnSalvar" ImageUrl="../images/buttons/btn_salvar.png" CssClass="botao"></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt class="current"><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
	<b>Novo:</b> Adicione um novo cliente à Lista de Clientes.<br />
    <b>Excluir:</b> Exclua o cliente representado pelos dados acima.<br />
    <b>Salvar:</b> Grava os dados do cliente e o coloca disponível na Lista de Clientes.
</asp:Content>

