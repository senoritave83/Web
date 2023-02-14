<%@ Page Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="MotivoFolga.aspx.vb" Inherits="Pages.Cadastros.MotivoFolga" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class='EditArea' style="width:68%; width:73%;">
		<div class='divEditArea' style="height:160px; height:120px\9;">
			<div class='trField cb' runat='server'  id='trMotivoFolga' visible='<%$Settings: visible, MotivoFolga.MotivoFolga, true %>' >
				<div class='tdFieldHeader cb fl' style="padding-left:22px; padding-right:10px; padding-top:15px;">
					<a>Motivo de Aus&ecirc;ncia:</a><br><br>

					<asp:TextBox runat='server' ID='txtMotivoFolga' MaxLength='200' CssClass="formulario" Width="641px" Height="90px" />
					<asp:RequiredFieldValidator runat='server' ID='valReqMotivoFolga' Enabled='<%$Settings: Required, MotivoFolga.MotivoFolga, true %>' Display='None' ErrorMessage='Motivo de Aus ncia &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtMotivoFolga' />
				</div>
			</div>
		</div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='MotivoFolga.aspx?idmotivofolga=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='MotivoFolgas.aspx'" />
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

