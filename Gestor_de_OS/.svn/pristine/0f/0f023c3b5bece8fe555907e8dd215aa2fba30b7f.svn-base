<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="usuariodet.aspx.vb" Inherits="configuracoes_usuariodet" title="Gestor de O.S" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width="101%" align="center">
        <tr class='Header2'>
            <td>
                <strong>Dados do Operador / Administrador</strong>
            </td>
        </tr>
		<tr>
		    <td style="text-align:left;padding-top:10px;">
			    <b>Nome do Operador</b>
			    <asp:RequiredFieldValidator Runat="server" ID='valNome' ErrorMessage='*' ControlToValidate='txtNome' />
			    <br />
			    <asp:textbox class="formulario" id="txtNome" runat="server" MaxLength="100" Width="300px"></asp:textbox>
		    </td>
	    </tr>
	    <tr>
		    <td style="text-align:left;padding-top:10px;">
			    <b>Administrador</b>&nbsp;
			    <br />
			    <asp:CheckBox runat='server' ID='chkAdmin' />
		    </td>
	    </tr>
	    <tr runat='server' id='trEditarSenha'>
		    <td  width="35%">
                <input id="btnEditar" causesvalidation='false' type="button" value="Editar dados de acesso" runat="server" Width="192px" NAME="btnEditar" class="formulario" />
                <img alt="Edita os dados de acesso do Operador/Administrador" src="../images/helpnol.gif" align="bottom" />
            </td>
	    </tr>
	    <tr>
		    <td>
			    <table id="tbDados" visible='false'  width="100%" border="0" runat="server">
				    <tr>
					    <td style="text-align:left;padding-top:10px;">
                            <b>Login</b>
			                <asp:RequiredFieldValidator Runat="server" ID='RequiredFieldValidator1' ErrorMessage='*' ControlToValidate='txtLogin' />
			                <br />
			                <asp:textbox id="txtLogin" runat="server" MaxLength="20" Width="150px" CssClass="formulario"></asp:textbox>
						</td>
					</tr>
					<tr>
					    <td style="text-align:left;padding-top:10px;">
                            <b>Senha</b>
			                <asp:RequiredFieldValidator Runat="server" ID='RequiredFieldValidator2' ErrorMessage='*' ControlToValidate='txtSenha' />
			                <br />
			                <asp:textbox id="txtSenha" runat="server" MaxLength="20" Width="150px" CssClass="formulario" TextMode="Password"></asp:textbox>
						</td>
				    </tr>
			    </table>
                <br />
		    </td>
	    </tr>             
        <tr class='Footer1'> 
            <td><img width="1" height="25" src="../images/transpa.gif" alt=""/></td>
        </tr>							
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:ImageButton id="btnVoltar" runat="server" ImageUrl="../images/buttons/btn_voltar.png" CssClass="botao_voltar" CausesValidation='false'></asp:ImageButton>    
	<asp:ImageButton id="btnExcluir" runat="server" ImageUrl="../images/buttons/btn_excluir.png" CssClass="botao"></asp:ImageButton>
	<asp:ImageButton id="btnNovo" runat="server" ImageUrl="../images/buttons/btn_novo.png" CssClass="botao"></asp:ImageButton>
    <asp:ImageButton id="btnSalvar" runat="server" ImageUrl="../images/buttons/btn_salvar.png" CssClass="botao"></asp:ImageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt class="current"><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
	<b>Editar dados de acesso:</b> Editar os dados de acesso do usuário: login e senha.<br />
	<b>Salvar:</b> Salva o novo Operador/Administrador na lista de Operadores/Administradores.<br />
	<b>Novo:</b> Adicione um novo Operador/Administrador à lista de Operadores e Administradores.<br />
	<b>Excluir:</b> Exclua o Operador/Administrador do sistema.
</asp:Content>

