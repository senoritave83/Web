<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Vendedor.aspx.vb" Inherits="Pages.Cadastros.Vendedor" title="Untitled Page" %>
<%@ Register src="../controls/txtDescontoMaximo.ascx" tagname="txtDescontoMaximo" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat='server' />

    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trCodigo' >
				<div class='tdFieldHeader fl'>
					C&oacute;digo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCodigo' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCodigo' Display='None' ErrorMessage='C&oacute;digo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCodigo' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trVendedor' >
				<div class='tdFieldHeader fl'>
					Vendedor:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtVendedor' MaxLength='60' />
					<asp:RequiredFieldValidator runat='server' ID='valReqVendedor' Display='None' ErrorMessage='Vendedor &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtVendedor' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trTelefone' >
				<div class='tdFieldHeader fl'>
					Telefone:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtTelefone' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqTelefone' Display='None' ErrorMessage='Telefone &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTelefone' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trLogin' >
				<div class='tdFieldHeader fl'>
					Login:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtLogin' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLogin' Display='None' ErrorMessage='Login &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLogin' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trSenha' >
				<div class='tdFieldHeader fl'>
					Senha:
				</div>
				<div class='tdField fl'>
				    <asp:UpdatePanel runat="server" id="pnlSenha">
				        <ContentTemplate>
        					<asp:TextBox runat="server" ID="txtSenha" MaxLength="20" />
        					<asp:Button runat="server" ID="btnNovaSenha" Text="Nova Senha" style="margin-left:0px;width:100px;" />
				        </ContentTemplate>
				    </asp:UpdatePanel>
					<asp:RequiredFieldValidator runat='server' ID='valReqSenha' Display='None' ErrorMessage='Senha &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtSenha' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trID' >
				<div class='tdFieldHeader fl'>
					ID:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtID' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqID' Display='None' ErrorMessage='ID &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtID' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trSubscriberID' >
				<div class='tdFieldHeader fl'>
					SubscriberID:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtSubscriberID' MaxLength='300' />
					<asp:RequiredFieldValidator runat='server' ID='valReqSubscriberID' Display='None' ErrorMessage='SubscriberID &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtSubscriberID' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trDescontoMax'>
				<div class='tdFieldHeader fl'>
					Desconto M&aacute;x.:
				</div>
				<div class='tdField fl'>
					<uc3:txtDescontoMaximo ID='txtDescontoMax' runat="server" />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trTodosClientes' >
				<div class='tdFieldHeader fl'>
					&nbsp;
				</div>
				<div class='tdField fl'>
					<asp:CheckBox runat='server' ID='chkTodosClientes' style='width:30px;' />Visualiza Todos os Clientes:
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trObservacao' >
				<div class='tdFieldHeader fl'>
					observa&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtObservacao' MaxLength='2000' TextMode='MultiLine' Rows='5' Width='100%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqObservacao' Display='None' ErrorMessage='observa&ccedil;&atilde;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtObservacao' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado'>
				<div class='tdFieldHeader fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<br class='cb' />
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Vendedor.aspx?idvendedor=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Vendedores.aspx'" />
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

