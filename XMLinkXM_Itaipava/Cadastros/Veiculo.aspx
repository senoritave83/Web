<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Veiculo.aspx.vb" Inherits="Pages.Cadastros.Veiculo" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat='server' ></asp:ScriptManager>
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, Veiculo.Placa, true %>' >
				<div class='tdFieldHeader cb fl'>
					Placa:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtPlaca' MaxLength='50' ReadOnly='True' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trVeiculo' visible='<%$Settings: visible, Veiculo.Veiculo, true %>' >
				<div class='tdFieldHeader cb fl'>
					Veiculo:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtVeiculo' MaxLength='50' />
					<asp:RequiredFieldValidator runat='server' ID='valReqVeiculo' Enabled='<%$Settings: Required, Veiculo.Veiculo, false %>' Display='None' ErrorMessage='Veiculo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtVeiculo' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trSenha' visible='<%$Settings: visible, Veiculo.Senha, true %>' >
				<div class='tdFieldHeader cb fl'>
					Senha:
				</div>
				<div class='tdField fl'>
				    <asp:UpdatePanel runat="server" id="pnlSenha">
				        <ContentTemplate>
        					<asp:TextBox runat="server" ID="txtSenha" MaxLength="20" TextMode="Password" />
        					<asp:Button runat="server" ID="btnNovaSenha" Text="Nova Senha" style="margin-left:0px;" />
				        </ContentTemplate>
				    </asp:UpdatePanel>
					<asp:RequiredFieldValidator runat='server' ID='valReqSenha' Enabled='<%$Settings: Required, Veiculo.Senha, false %>' Display='None' ErrorMessage='Senha &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtSenha' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Veiculo.Criado, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Veiculos.aspx'" />
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
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

