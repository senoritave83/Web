<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Usuario.aspx.vb" Inherits="Pages.Cadastros.Usuario" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trUsuario' visible='<%$Settings: visible, Usuario.Usuario, true %>' >
				<div class='tdFieldHeader fl'>
					Usuario:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtUsuario' MaxLength='100' />
					<asp:RequiredFieldValidator runat='server' ID='valReqUsuario' Enabled='<%$Settings: Required, Usuario.Usuario, true %>' Display='None' ErrorMessage='Usuario &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtUsuario' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trlogin' visible='<%$Settings: visible, Usuario.login, true %>' >
				<div class='tdFieldHeader fl'>
					login:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtlogin' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqlogin' Enabled='<%$Settings: Required, Usuario.login, true %>' Display='None' ErrorMessage='login &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtlogin' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trSenha' visible='<%$Settings: visible, Usuario.Senha, true %>' >
				<div class='tdFieldHeader fl'>
					Senha:
				</div>
				<div class='tdField fl'>
				    <asp:UpdatePanel runat="server" id="pnlSenha">
				        <ContentTemplate>
        					<asp:TextBox runat="server" ID="txtSenha" MaxLength="20" TextMode="Password" />
        					<asp:Button runat="server" ID="btnNovaSenha" Text="Nova Senha" style="margin-left:0px;" />
				        </ContentTemplate>
				    </asp:UpdatePanel>
					<asp:RequiredFieldValidator runat='server' ID='valReqSenha' Enabled='<%$Settings: Required, Usuario.Senha, false %>' Display='None' ErrorMessage='Senha &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtSenha' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trEmail' visible='<%$Settings: visible, Usuario.Email, true %>' >
				<div class='tdFieldHeader fl'>
					Email:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtEmail' MaxLength='256' />
					<asp:RequiredFieldValidator runat='server' ID='valReqEmail' Enabled='<%$Settings: Required, Usuario.Email, false %>' Display='None' ErrorMessage='Email &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEmail' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Usuario.Criado, true %>' >
				<div class='tdFieldHeader fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<div class='trField fr' runat='server' style="width:40%"  id='trAdministrador' visible='<%$Settings: visible, Usuario.Administrador, false %>' >
				<div class='tdFieldHeader fl'>
					Administrador:
				</div>
				<div class='tdField fl'>
					<asp:CheckBox runat='server' ID='chkAdministrador' Enabled='false' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trObservacao' visible='<%$Settings: visible, Usuario.Observacao, true %>' >
				<div class='tdFieldHeader fl'>
					observa&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtObservacao' TextMode="Multiline" Rows="3" Width='100%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqObservacao' Enabled='<%$Settings: Required, Usuario.Observacao, false %>' Display='None' ErrorMessage='observa&ccedil;&atilde;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtObservacao' />
				</div>
			</div>

		</div>
	</div>
    <div class='ListArea'>
	<asp:UpdatePanel runat='server' id='updRoles'>
	    <ContentTemplate>
		    <asp:GridView runat='server' id='grdRoles' AutoGenerateColumns='false' AllowSorting='true' DataKeyNames='Permissao'>
		        <HeaderStyle HorizontalAlign='Left' />
		        <Columns>
		            <asp:TemplateField HeaderText='Permiss&atilde;o'>
		                <ItemTemplate>
			                <%#Eval("Permissao")%>
		                </ItemTemplate>
		            </asp:TemplateField>
		            <asp:TemplateField HeaderText='Possui a permiss&atilde;o' >
		                <ItemTemplate>
		                    <asp:CheckBox runat='server' ID='chk' AutoPostBack='true' OnCheckedChanged='chk_OnCheckedChange'  />
		                </ItemTemplate>
		            </asp:TemplateField>
		        </Columns>
			    <EmptyDataTemplate>
			        <div class='divEmptyRow'>
			            <div class='GridHeader'>&nbsp;</div>
			            <asp:Label runat='server' ID='lblNaoEncontrados'>
				            N&atilde;o h&aacute; permiss&otilde;es!
			            </asp:Label>
			        </div>
			    </EmptyDataTemplate>
		    </asp:GridView>
	    </ContentTemplate>
	</asp:UpdatePanel>
	</div>	
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Usuario.aspx?idusuario=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Usuarios.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaGravar'>
			        <b>Gravar:</b>
				    Grava as altera&ccedil;&otilde;es efetuadas no banco.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaApagar'>
			        <b>Apagar:</b>
				    Apaga o registro atual.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaNovo'>
			        <b>Novo:</b>
				    Abre para edi&ccedil;&atilde;o um novo registro, fechando o atual sem gravar as altera&ccedil;&otilde;es.
		        </asp:Localize>
		    </li> 
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

