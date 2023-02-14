<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Usuario.aspx.vb" Inherits="Pages.Cadastros.Usuario" title="XM Promotores - Yes Mobile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class='EditArea'>
		<table id='tblEditArea' border="0">
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Nome do Usu&aacute;rio:
				</td>
				<td class='tdField' colspan="3">
					<asp:TextBox runat='server' ID='txtUsuario' MaxLength='100' Width="80%" />
					<asp:RequiredFieldValidator runat='server' ID='valReqUsuario' Display='None' ErrorMessage='Usu&aacute;rio &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtUsuario' />
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Login:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtlogin' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqlogin' Display='None' ErrorMessage='Login &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtlogin' />
				</td>
				<td class='tdFieldHeader'>
					Email:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtEmail' MaxLength='256' Width="250px" />
					<asp:RequiredFieldValidator runat='server' ID='valReqEmail' Display='None' ErrorMessage='Email &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEmail' />
					<asp:RegularExpressionValidator ControlToValidate="txtEmail" runat="Server" 
                        ID="regEmail" ErrorMessage='E-mail Inv&aacute;lido' 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
				</td>
			</tr>
			<tr class='trField' runat="Server" id="trSenha">
				<td class='tdFieldHeader'>
					Senha:
				</td>
				<td class='tdField'>
					<asp:TextBox TextMode="Password" runat='server' ID='txtSenha' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqSenha' Display='None' ErrorMessage='Senha &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtSenha' />
					<asp:CompareValidator Display='None' ErrorMessage="Os campos Senha e Confirmar Senha devem ser iguais. Verifique..." runat="Server" ControlToValidate="txtSenha" ControlToCompare="txtConfirmarSenha" Operator="Equal"></asp:CompareValidator>
				</td>
				<td class='tdFieldHeader'>
					Confirmar senha:
				</td>
				<td class='tdField'>
					<asp:TextBox TextMode="Password" runat='server' ID='txtConfirmarSenha' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator1' Display='None' ErrorMessage='Confirmar Senha &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtConfirmarSenha' />
				</td>
			</tr>
			<tr class='trField' ID="trAdministrador" runat="server">
				<td class='tdFieldHeader'>
					Administrador:
				</td>
				<td class='tdField'>
					<asp:RadioButtonList RepeatDirection="Horizontal" runat="Server" ID="rdAdmin">
					    <asp:ListItem Text="Sim" Value="1"></asp:ListItem>
					    <asp:ListItem Text="N&atilde;o" Value="0"></asp:ListItem>
					</asp:RadioButtonList>
				</td>
            </tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
					&Uacute;ltimo Acesso:
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblUltimoAcesso' />
				</td>
			</tr>
            <tr class='trField'>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Observa&ccedil;&otilde;es:
				</td>
				<td class='tdField' colspan="3">
					<asp:TextBox runat='server' ID='txtObservacao' MaxLength='1000' Width="80%" TextMode='MultiLine' Rows='3' />
				</td>
			</tr>
			<tr class='trField' runat="Server" id="trDadosAcesso">
				<td class='tdFieldHeader'>
					Senha Alterada em:
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblSenhaAlterada' />
				</td>
				<td class='tdFieldHeader'>
					Senha V&aacute;lida at&eacute;:
				</td>
				<td class='tdField' >
					<asp:Label runat='server' ID='lblValidSenha' />
				</td>
			</tr>
			<tr class='trField' runat="Server" id="trDadosAcesso2">
				<td class='tdFieldHeader'>
					Criado em:
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCriado' />
				</td>
				<td class='tdFieldHeader'>
					&Uacute;ltima Atividade do Usu&aacute;rio em:
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblUltimaAtividade' />
				</td>
			</tr>
		</table>
	</div>
    <div class='EditArea'>
	    <asp:Panel runat='server' ID='pnlPermissoes'>
	        <asp:label ID="Label1" Runat="server">Permiss&otilde;es:</asp:label><br>
			<asp:DataList ItemStyle-Width="25%" ItemStyle-Height="5" CssClass="f8" DataKeyField="IdPermissao" id="grdPermissao" runat="server" BorderColor="#999999" BorderStyle="Outset" BorderWidth="1" BackColor="#EFEFEF" CellSpacing="0" CellPadding="0" GridLines="none" width="100%" RepeatColumns="4" RepeatDirection='Vertical'>
				<ItemTemplate>
				    <input <%# VerificaTravarPermissao(Eval("IdPermissao")) %> type="checkbox" name='Permissoes' value='<%# Eval("Permissao")%>' <%# IIF(Eval("Permitido") = 1," checked", "") %> /><%# DataBinder.Eval(Container.DataItem, "Permissao")%>
				</ItemTemplate>
			</asp:DataList>
		    <asp:checkboxlist DataTextField="Permissao" DataValueField="IdPermissao" id="chkPermissoes" Runat="server" Width="100%" RepeatDirection="Horizontal" RepeatColumns="4">
		    </asp:checkboxlist>
	    </asp:Panel>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Usuario.aspx?idusuario=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Usuarios.aspx'" />
        <asp:Button runat='server' ID='btnAlterarSenha' Text="Definir Senha" CssClass='Botao' />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
			    <b>Gravar:</b>
				Grava as altera&ccedil;&otilde;es efetuadas no banco.
		    </li> 
		    <li>
			    <b>Apagar:</b>
				Apaga o registro atual.
		    </li> 
		    <li>
			    <b>Novo:</b>
				Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		    </li> 
		    <li>
			    <b>Voltar:</b> Volta para o menu anterior.
			</li>
	    </ul>
    </div>
</asp:Content>

