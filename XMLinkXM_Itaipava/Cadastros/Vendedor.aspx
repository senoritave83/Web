<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Vendedor.aspx.vb" Inherits="Pages.Cadastros.Vendedor" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat='server' />
    <div class='EditArea'>
		<div class='divEditArea'>
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trVendedor' visible='<%$Settings: visible, Vendedor.Vendedor, true %>' >
				<div class='tdFieldHeader cb fl'>
					Vendedor:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtVendedor' MaxLength='30' />
					<asp:RequiredFieldValidator runat='server' ID='valReqVendedor' Enabled='<%$Settings: Required, Vendedor.Vendedor, true %>' Display='None' ErrorMessage='Vendedor &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtVendedor' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trTelefone' visible='<%$Settings: visible, Vendedor.Telefone, true %>' >
				<div class='tdFieldHeader cb fl'>
					Telefone:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtTelefone' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqTelefone' Enabled='<%$Settings: Required, Vendedor.Telefone, false %>' Display='None' ErrorMessage='Telefone &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTelefone' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trID' visible='<%$Settings: visible, Vendedor.ID, true %>' >
				<div class='tdFieldHeader cb fl'>
					ID:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtID' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqID' Enabled='<%$Settings: Required, Vendedor.ID, false %>' Display='None' ErrorMessage='ID &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtID' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trLogin' visible='<%$Settings: visible, Vendedor.Login, true %>' >
				<div class='tdFieldHeader cb fl'>
					Login:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtLogin' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLogin' Enabled='<%$Settings: Required, Vendedor.Login, true %>' Display='None' ErrorMessage='Login &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLogin' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trSenha' visible='<%$Settings: visible, Vendedor.Senha, true %>' >
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
					<asp:RequiredFieldValidator runat='server' ID='valReqSenha' Enabled='<%$Settings: Required, Vendedor.Senha, false %>' Display='None' ErrorMessage='Senha &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtSenha' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='Div2' visible='<%$Settings: visible, Vendedor.Nivel, true %>' >
				<div class='tdFieldHeader cb fl'>
					N&iacute;vel:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList runat='server' ID='cboIDNivel' DataTextField='Nivel' DataValueField='IDNivel'></asp:DropDownList>
				</div>
			</div>
			<div class='trField cb' runat='server'  id='Div1' visible='<%$Settings: visible, Vendedor.Especial, true %>' >
				<div class='tdFieldHeader cb fl'>
					Especial:
				</div>
				<div class='tdField fl'>
					<asp:CheckBox runat='server' ID='chkEspecial' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trTeste' visible='<%$Settings: visible, Vendedor.Teste, true %>' >
				<div class='tdFieldHeader cb fl'>
					Conta de Teste:
				</div>
				<div class='tdField fl'>
					<asp:CheckBox runat='server' ID='chkTeste' />
				</div>
			</div>
            <div class='trField cb' runat='server'  id='Div3' visible='<%$Settings: visible, Vendedor.TipoVendedor, true %>' >
				<div class='tdFieldHeader cb fl'>
					Tipo Vendedor:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList runat='server' ID='cboTipoVendedor' DataTextField='TipoVendedor' DataValueField='TipoVendedor'></asp:DropDownList>
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Vendedor.Criado, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>            
		</div>
	</div>
	<asp:PlaceHolder runat='server' id='plhGrupos'>
	    <div class='gridHeader'>
	        Grupos do vendedor
	    </div> 
	    <div class='ListArea'>	
	        <asp:CheckBoxList runat='server' ID='lstGrupos' DataTextField='Grupo' DataValueField='IDGrupo' Width='100%' RepeatColumns='3' >
	        </asp:CheckBoxList>
	    </div> 
	</asp:PlaceHolder><br /><br />
	<asp:PlaceHolder runat='server' id='PlaceHolder1'>
	    <div class='gridHeader'>
	        Tabelas de preços do vendedor
	    </div> 
	    <div class='ListArea' style="overflow:scroll;Height:90px;">	
            <table width='400'>
                <tr>
                    <td bgcolor='black' style="height:15px;width:20px;">&nbsp;</td>
                    <td>Tabelas Ativas</td>
                    <td bgcolor='red' style="height:15px;width:20px;">&nbsp;</td>
                    <td>Tabelas Inativas</td>
                    <td bgcolor='blue' style="height:15px;width:20px;">&nbsp;</td>
                    <td>Tabelas Especiais</td>
                </tr>
            </table>
	        <asp:CheckBoxList runat='server' ID='lstTabelas' DataTextField='Tabela' DataValueField='IDTabela' Width='100%' RepeatColumns='6' >
	        </asp:CheckBoxList>
	    </div> 
	</asp:PlaceHolder>
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
		        <b>Especial:</b> Vendedores marcados como "especial" podem realizar pedidos com tabelas "especiais".
		    </li>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

