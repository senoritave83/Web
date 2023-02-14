<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="JustificativaRuptura.aspx.vb" Inherits="Pages.Cadastros.JustificativaRuptura" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class='EditArea'>
		<table id='tblEditArea'>
            <tr class="trEditHeader">
			    <td colspan='2'>&nbsp;</td>
			</tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
					Descri&ccedil;&atilde;o:
				</td>
				<td class='tdField'>
					<asp:TextBox runat='server' ID='txtJustificativaRuptura' MaxLength='50' Width='400px' />
					<asp:RequiredFieldValidator runat='server' ID='valReqJustificativaRuptura' Display='None' ErrorMessage='JustificativaRuptura &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtJustificativaRuptura' />
				</td>
			</tr>
            <tr class='trField'>
				<td class='tdFieldHeader'>
					Mostrar:
				</td>
				<td class='tdField'>
					<asp:DropDownList runat='server' ID='cboConcorrenteMostrar' >
                        <asp:ListItem Text='N&Atilde;O' Value='0' Selected='True' />
                        <asp:ListItem Text='Produto Pr&oacute;prio' Value='1' />
                        <asp:ListItem Text='Produto Concorrente' Value='2' />
                        <asp:ListItem Text='Todos' Value='3' />
                    </asp:DropDownList>
				</td>
			</tr>
			<tr class='trField'>
				<td class='tdFieldHeader'>
					Criado:
				</td>
				<td class='tdField'>
					<asp:Label runat='server' ID='lblCriado' />
				</td>
			</tr>
	    </table>		    
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='JustificativaRuptura.aspx'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='JustificativaRupturas.aspx'" />
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

