<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="Lider.aspx.vb" Inherits="Pages.Cadastros.Lider" title="XM Promotores - Yes Mobile" %>

<%@ Register src="../controls/ImageUploader.ascx" tagname="ImageUploader" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" language="javascript">
    function funcBtnNovo(){
        location.href='lider.aspx?idlider=0';
    }

    function fncBtnApagar() {
        return confirm('Deseja realmente apagar o ' + document.getElementById("tdLider").innerHTML.replace(":", "") + '?');        
    }
</script>
    <div class='EditArea'>
        <asp:ScriptManager ID="scptManager" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="UpdatePanel1">
            <ContentTemplate>
                <table id='tblEditArea' border='0'>
	                <tr class="trEditHeader">
	                    <td colspan='2'>&nbsp;</td>
	                </tr>
	                <tr class='trField'>
		                <td id="tdLider" class='tdFieldHeader'>
			                <asp:Literal ID="ltrLider" runat="server" Text='<%$Settings: caption, Promotor.FiltroLider, "Lider" %>' />:
		                </td>
		                <td class='tdField'>
			                <asp:TextBox runat='server' ID='txtLider' MaxLength='100' Width="60%" />
			                <asp:RequiredFieldValidator runat='server' ID='valReqLider' Display="None" ErrorMessage="A PROPRIEDADE ERROR MESSAGE ESTÁ SENDO SETADA NO CODEBEHIND" ControlToValidate='txtLider' />
		                </td>
	                </tr>
	                <tr class='trField'>
		                <td class='tdFieldHeader'>
			                <asp:Literal ID="ltrCoordenador" runat="server" Text='<%$Settings: caption, Promotor.FiltroCoordenador, "Coordenador" %>' />:
		                </td>
		                <td class='tdField'>
			                <asp:DropDownList runat="server" ID="cboIDCoordenador" DataTextField="Coordenador" DataValueField="IDCoordenador" />
			                <asp:CompareValidator ValueToCompare="0" Operator="GreaterThan" runat='server' ID='valReqIDCoordenador' Display="None" ErrorMessage="A PROPRIEDADE ERROR MESSAGE ESTÁ SENDO SETADA NO CODEBEHIND" ControlToValidate='cboIDCoordenador' ></asp:CompareValidator>
		                </td>
	                </tr>
                    <tr runat="server" id="trAcessoWeb" visible='<%$Settings: visualiza, Lider.UsuarioWeb, false %>'>
                        <td class='tdFieldHeader'>
	                        AcessoWeb:
                        </td>
                        <td class='tdField' align="left">
	                        <asp:CheckBox AutoPostBack='true' runat="server" ID="chkAcessoWeb" />
                        </td>
                    </tr>
                    <tr runat="server" id="trUsuarioAcessoWeb" visible='<%$Settings: visualiza, Lider.UsuarioWeb, false %>'>
                        <td class='tdFieldHeader'>
                            Usuário:
                        </td>
                        <td class='tdField'>
                            <asp:DropDownList runat="server" ID="drpIdUsuario" DataTextField="Usuario" DataValueField="IdUsuario"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr class='trField' runat="server" id="trFoto" Visible='<%$Settings: Visible, Lider.Foto, true %>'>
                        <td class='tdFieldHeader'>
	                        Foto:
                        </td>
                        <td>
	                        <uc1:ImageUploader ID="ImageUploaderLider" runat="server" VirtualPath='~/imagens/Lider/' NoImage='noimage.png'  />
	                        &nbsp;
		                </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao'  Visible='<%$Settings: Visible, Lider.BotaoGravar, true %>'/>
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' OnClientClick='return fncBtnApagar();' Visible='<%$Settings: Visible, Lider.BotaoApagar, true %>' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " OnClick='funcBtnNovo()' Visible='<%$Settings: Visible, Lider.BotaoNovo, true %>' />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='lideres.aspx'" />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary'  />
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

