<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="respostas.aspx.vb" Inherits="configuracoes_respostas" title="Gestor de O.S" %>

<%@ Register src="../include/xmcolor.ascx" tagname="xmcolor" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	
	<asp:Repeater runat='server' ID='rptRespostas'>
		<HeaderTemplate>
<table align="center"	>
	<tr class='Header2'>
		<td colspan='5' style="height: 20px"></td>
		<td colspan='2' align='center' style="background-color:#eceee7; height: 20px;">Subn&iacute;vel</td>
		<td colspan='2' style="height: 20px"></td>
	</tr> 
	<tr class='Header2'>
	 <td colspan="2">Pos</td>
		<td align='left' width='215'>Resposta</td>
		<td width="32" style="padding:0px">Cor</td>
		<td width="30" align='center' style="padding:0 5px 0 0;">Fim</td>
		<td width="30" align='center' style="background-color:#eceee7">ver</td>
		<td align='center' style="background-color:#eceee7;">apagar</td>
		<td width='210' style="padding-left:20px;">Etapa</td>
		<td style="text-align:center; width: 135px;">Obs.</td>
	</tr>
		</HeaderTemplate>
		<ItemTemplate>
			<tr style='background-color:white;' align="center">
				<td width='8'>
                    <%#Eval("POS_POSICAO_INT") %>
                </td>
				<td width='12'>
                    <asp:Literal Runat="server" ID="Literal1" />
                </td>
				<td>
                    <asp:textbox id="txtResposta_1" Runat="server" CssClass="formulario" Width='290px' MaxLength="30" Text='<%#Eval("res_Resposta_chr") %>'></asp:textbox>
                </td>
				<td>
                    <uc1:xmcolor id="Xmcolor1" runat="server" Color='<%#Eval("res_Color_chr")%>'></uc1:xmcolor>
                </td>
				<td align='center'>
                    <input type='checkbox' runat="Server" id="chkFinaliza1" name="chkFinaliza1" checked='<%#Eval("res_Finaliza_ind") %>' />
                </td>
				<td align='center'>
                    <asp:hyperlink id="HyperLink1" Runat="server" NavigateUrl="respostas.aspx?idsuperior=0"  Tooltip='Visualiza o sub n&iacute;vel desta resposta'></asp:hyperlink>
                </td>
				<td style="width:38px;">
                    <asp:ImageButton Runat="server" id='btnApagarDeck1' OnCommand='Button_Apagar' CommandName='Apagar' ImageUrl='../images/ico_sair.gif' />
                </td>
				<td>
                    <asp:DropDownList runat='server' CssClass="ui-select"  ID='cboEtapa1' Width='210' DataTextField='Etapa' DataValueField='IDEtapa'></asp:DropDownList>
                </td>
				<td align="center">
                    <asp:HyperLink runat='server' ID='lnkObs1'>Padr&atilde;o</asp:HyperLink>
                </td>
			</tr>
		</ItemTemplate>
		<FooterTemplate>
		    <tr class='Footer1'> 
	        <td colspan='9' style="height: 28px">
	            <img width="1" height="25" src="../images/transpa.gif" alt=""/>
	        </td>
	    </tr>	
	</table>
		</FooterTemplate>
	</asp:Repeater>

	<script type='text/javascript'>
		function changeColor(vObject)
			{
			var newwindow = null;
			if ( newwindow != null ) 
				{
				newwindow.close();
				}
				newwindow = window.open('../include/getcolor.aspx?tn=1&cor=' + vObject.value + '&field=' + vObject.id,'csel','width=230,height=250,resizable=no,statusbar=no;');
				newwindow.focus();
			}
		function setCor(vColor, vField)
			{
			    eval('document.forms[0].' + vField + '.value = "' + vColor + '";');
			    eval(vField.replace('ColorName', 'ColorCell') + '.style.backgroundColor="' + vColor + '"');
			}
		function fncApagarDeck()
			{
			return confirm('Apagar todos os sub n&iacute;veis deste item?');
			}
		function fncApagar()
			{
			return confirm('Voc&ecirc; deseja realmente apagar estas respostas?');
		}

		function fnExibe(strId) {
			eval('trDetails' + strId).style.display = '';
			eval('document.imgUp' + strId).style.display = '';
			eval('document.imgDown' + strId).style.display = 'none';
		}

		function fnNExibe(strId) {
			eval('document.imgDown' + strId).style.display = '';
			eval('trDetails' + strId).style.display = 'none';
			eval('document.imgUp' + strId).style.display = 'none';
		}
					    
	</script>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:imageButton runat="server" id="btnVoltar" ImageUrl="../images/buttons/btn_voltar.png" CssClass="botao_voltar_resposta"></asp:imageButton>    
	<asp:imageButton Runat="server" ID='btnApagar' ImageUrl="../images/buttons/btn_excluir.png" CssClass="botao_excluir_respostas"></asp:imageButton>
	<asp:imageButton Runat="server" id="btnSalvar" ImageUrl="../images/buttons/btn_salvar.png" CssClass="botao"></asp:imageButton>
</asp:Content>

<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt><span lang="pt-br"><a href="default.aspx">Configura&ccedil;&otilde;es B&aacute;sicas</a></span></dt>
    <dt class="current"><a href="default2.aspx">Configura&ccedil;&otilde;es Especiais</a></dt>
    </dl>     
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
	<b>Salvar:</b> Salve as respostas que voc<span lang="pt-br">&ecirc;</span> inseriu e/ou alterou.
    <br />
	<b>Excluir:</b> Exclua um ou mais clientes selecionados pela caixa de sele<span lang="pt-br">&ccedil;&atilde;</span>o. 
    <br />	
	<img src="../images/subfolder.gif" width="16" height="16" style="vertical-align:middle;"> Indica que a resposta possui sub n&iacute;vel<br />
	<img src="../images/iconever.gif" width="16" height="16" style="vertical-align:middle;"> Indica que a resposta n&atilde;o possui sub n&iacute;vel.<br />
</asp:Content>