<%@ Page Title="" Language="VB" MasterPageFile="~/XMPromotores.master" AutoEventWireup="false" CodeFile="TipoEvento.aspx.vb" Inherits="Pages.Cadastros.Cadastros_TipoEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class='EditArea'>
		<table id='tblEditArea' border='1'>
        </table>
        <table id='tblEditArea' width="600" style="width:600px;" border='0'>
			<tr class='trField'>
				<td class='tdFieldHeader' style="text-align:left; width:405px;"> 
					Tipo de Evento
					<asp:TextBox runat='server' ID='txtTipoEvento' MaxLength='50' Width="400" CssClass="formulario" />
					<asp:RequiredFieldValidator runat='server' ID='valReqTipoEvento' Display='None' ErrorMessage='Tipo de Evento &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTipoEvento' />
				</td>
				<td class='tdFieldHeader' style="text-align:left;">
					Contexto
					<asp:DropDownList runat="server" ID="drpIdContexto" CssClass="Select">
                        <asp:ListItem Text="Selecione..." Value="0"></asp:ListItem>
                        <asp:ListItem Text="Durante Visita" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Fora da Visita" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Qualquer momento" Value="3"></asp:ListItem>
                    </asp:DropDownList>
					<asp:CompareValidator runat='server' ID='compValidator1' Display='None' ErrorMessage='Contexto &eacute; um campo obrigat&oacute;rio!' ControlToValidate='drpIdContexto' ValueToCompare="0" Operator="GreaterThan"></asp:CompareValidator>
				</td>				
			</tr>
		</table>
		<ul style="padding-left:15px; margin-top:0px;">
			<li  style="float:none;  display:list-item;">
				<a style="padding-right:5px;">Evento Instantâneo</a>
				<asp:CheckBox runat='server' ID='chkInstantaneo' />
			</li>
			<li  style="float:none;  display:list-item;">
				<a style="padding-right:5px;">Requer posição GPS</a>
				<asp:CheckBox runat='server' ID='chkPosicao' />
			</li>
			<li  style="float:none;  display:list-item;">
				<a style="padding-right:3px;">Permite Observação</a>
				<asp:CheckBox runat='server' ID='chkPermiteObs' />
			</li>
		</ul>
		<ul style="width:150px;">
			<li  style="float:none;  display:list-item;">
				<a style="padding-right:3px;">É exclusivo ?</a>
				<asp:CheckBox runat='server' ID='chkExclusivo' />
			</li>		
			<li  style="float:none;  display:list-item;">
				<a style="padding-right:3px; padding-left:26px;">É único ?</a>
				<asp:CheckBox runat='server' ID='chkUnico' />
			</li>
			<li  style="display:list-item; width:110px;">
				<a style="padding-right:3px; padding-right:0px\9;  padding-left:46px;">Ativo:</a>
				<asp:CheckBox runat='server' ID='chkAtivo' />
			</li>		
		</ul>
        <ul style="width:200px;">
            <li  runat="server" id="liApagado" visible="false">
                <a style="padding-right:3px; ">Apagado:</a>
				<asp:CheckBox runat='server' ID='chkApagado' />
            </li>
			<li  style="width:100%; padding-top:30px;">
				<a>Criado:</a>
				<asp:Label runat='server' ID='lblCriado' />
			</li>	
        </ul>
		<div class="cb" style="height:1px;"></div>
	</div>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='tipoevento.aspx?idTipoEvento=0'" />
        <input type="button" class="Botao" value=" Voltar " onclick="location.href='tiposevento.aspx'" />
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

