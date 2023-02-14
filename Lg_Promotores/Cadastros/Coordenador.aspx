<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Coordenador.aspx.vb" Inherits="Pages.Cadastros.Coordenador" title="XM Promotores - Yes Mobile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script>
    function funcBtnNovo() {
        location.href = 'Coordenador.aspx?idcoordenador=0';
    }

    function fncBtnApagar() {
        return confirm('Deseja realmente apagar o ' + document.getElementById("tdCoordenador").innerHTML.replace(":", "") + '?');
    }
</script>
    <div class='EditArea'>
        <asp:ScriptManager ID="scptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="updCoordenador">
            <ContentTemplate>
		        <table id='tblEditArea'>
			        <tr class="trEditHeader">
			            <td colspan='2'>&nbsp;</td>
			        </tr>
			        <tr class='trField'>
				        <td id="tdCoordenador" class='tdFieldHeader'>
					        <asp:Literal ID="ltrCoordenador" runat="server" Text='<%$Settings: caption, Coordenadores.FiltroCoordenador, "Coordenador" %>' />:
				        </td>
				        <td class='tdField'>
					        <asp:TextBox runat='server' ID='txtCoordenador' Width="60%" MaxLength='100' />
					        <asp:RequiredFieldValidator runat='server' ID='valReqCoordenador' Display='None' ErrorMessage='ESTÁ SENDO SETADO NO CODEBEHIND' ControlToValidate='txtCoordenador' />
				        </td>
			        </tr>
			        <tr class='trField' runat="server" visible='<%$Settings: visualiza, Coordenadores.UsuarioWeb, false %>'>
				        <td class='tdFieldHeader'>
					        AcessoWeb:
				        </td>
				        <td class='tdField'>
					        <asp:CheckBox AutoPostBack='true' runat="server" ID="chkAcessoWeb" />
				        </td>
			        </tr>
			        <tr class='trField' runat="server" id="trUsuario" visible='<%$Settings: visualiza, Coordenadores.UsuarioWeb, false %>'>
				        <td class='tdFieldHeader'>
					        Usuário:
				        </td>
				        <td class='tdField'>
					        <asp:DropDownList runat="server" ID="drpIdUsuario" DataTextField="Usuario" DataValueField="IdUsuario"></asp:DropDownList>
					        <asp:RequiredFieldValidator runat='server' ID='RequiredFieldValidator2' Display='None' ErrorMessage='Coordenador &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCoordenador' />
				        </td>
			        </tr>
		        </table>            
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="chkAcessoWeb" EventName="CheckedChanged" />
            </Triggers>
        </asp:UpdatePanel>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' Visible='<%$Settings: Visible, Coordenadores.BotaoGravar, true %>' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' OnClientClick="return fncBtnApagar();" Visible='<%$Settings: Visible, Coordenadores.BotaoApagar, true %>' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick='<%$Settings: onclick, Coordenadores.BotaoNovo, funcBtnNovo() %>' Visible='<%$Settings: Visible, Coordenadores.BotaoNovo, true %>' />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='Coordenadores.aspx'" />
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

