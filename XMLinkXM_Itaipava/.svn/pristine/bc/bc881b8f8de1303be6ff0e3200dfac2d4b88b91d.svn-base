<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="Cliente.aspx.vb" Inherits="Pages.Cadastros.Cliente" title="Untitled Page" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class='EditArea'>
		<div class='divEditArea' style="min-width:500px;">
		    <div class='divHeader'>&nbsp;</div>
			<div class='trField cb' runat='server'  id='trCliente' visible='<%$Settings: visible, Cliente.Cliente, true %>' >
				<div class='tdFieldHeader cb fl'>
					Cliente:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCliente' MaxLength='60' width='100%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCliente' Enabled='<%$Settings: Required, Cliente.Cliente, true %>' Display='None' ErrorMessage='Cliente &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCliente' />
				</div>
			</div>
			<div class='trField fl cl' runat='server' id='trCNPJ' visible='<%$Settings: visible, Cliente.CNPJ, true %>' >
				<div class='tdFieldHeader fl'>
					CNPJ:
				</div>
				<div class='tdField'>
					<asp:TextBox runat='server' ID='txtCNPJ' Width='110px' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqCNPJ' Enabled='<%$Settings: Required, Cliente.CNPJ, false %>' Display='None' ErrorMessage='CNPJ &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCNPJ' />
				</div>
			</div>
                       
                       
             <div class='trField fr' runat='server'  id='trIDCanal'  >
				<div class='tdFieldHeader fl' style="width:50px">
					Canal:
				</div>
				<div class='tdField'>
					<asp:DropDownList runat="server" ID="cboIDCanal" DataTextField="Canal" DataValueField="IDCanal"  />
					<asp:CompareValidator runat="server"  ID="valCompIDCanal" Display="None" ErrorMessage="Canal inv&aacute;lido" ControlToValidate="cboIDCanal" Operator="GreaterThan" ValueToCompare="0" />
					<asp:RequiredFieldValidator runat='server' ID='valreqIDCanal' Display='None' ErrorMessage='Canal &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDCanal' />
				</div>
			</div>
                        
             <div class='trField fr' runat='server'  id='trIDGrupo' >
				<div class='tdFieldHeader fl' style="width:50px">
					Grupo:
				</div>
				<div class='tdField'>
					<asp:DropDownList runat="server" ID="cboIDGrupoCanal" DataTextField="GrupoCanal" DataValueField="IDGrupoCanal" autoPostBack="true" />
					<asp:CompareValidator runat="server"  ID="valcompIDGrupo" Display="None" ErrorMessage="Grupo inv&aacute;lido" ControlToValidate="cboIDGrupoCanal" Operator="GreaterThan" ValueToCompare="0" />
					<asp:RequiredFieldValidator runat='server' ID='valreqIDGrupo' Display='None' ErrorMessage='Grupo &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDGrupoCanal' />
				</div>
			</div>
            


			<div class='trField fr' runat='server'  id='trIDPasta' visible='<%$Settings: visible, Cliente.IDPasta, true %>' >
				<div class='tdFieldHeader fl' style="width:50px">
					Pasta:
				</div>
				<div class='tdField'>
					<asp:DropDownList runat="server" ID="cboIDPasta" DataTextField="Descricao" DataValueField="IDPasta" />
					<asp:CompareValidator runat="server"  ID="valCompIDPasta" Display="None" ErrorMessage="Pasta inv&aacute;lido" ControlToValidate="cboIDPasta" Operator="GreaterThan" ValueToCompare="0" />
					<asp:RequiredFieldValidator runat='server' ID='valReqIDPasta' Display='None' ErrorMessage='Pasta &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDPasta' />
				</div>
			</div>


			<br class='cb' />
			<div class='trField cb fl' runat='server'  id='trEndereco' visible='<%$Settings: visible, Cliente.Endereco, true %>' >
				<div class='tdFieldHeader fl'>
					Endere&ccedil;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtEndereco' MaxLength='80' Width='200px' />
					<asp:RequiredFieldValidator runat='server' ID='valReqEndereco' Enabled='<%$Settings: Required, Cliente.Endereco, false %>' Display='None' ErrorMessage='Endere&ccedil;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtEndereco' />
				</div>
			</div>
			<div class='trField fr' runat='server'  id='trBairro' visible='<%$Settings: visible, Cliente.Bairro, true %>' >
				<div class='tdFieldHeader fl' style="width:50px">
					Bairro:
				</div>
				<div class='tdField'>
					<asp:TextBox runat='server' ID='txtBairro' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqBairro' Enabled='<%$Settings: Required, Cliente.Bairro, false %>' Display='None' ErrorMessage='Bairro &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtBairro' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb fl' runat='server'  id='trCidade' visible='<%$Settings: visible, Cliente.Cidade, true %>' >
				<div class='tdFieldHeader fl'>
					Cidade:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCidade' MaxLength='40' width='170px'/>
					<asp:RequiredFieldValidator runat='server' ID='valReqCidade' Enabled='<%$Settings: Required, Cliente.Cidade, false %>' Display='None' ErrorMessage='Cidade &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCidade' />
				</div>
			</div>
			<div class='trField' runat='server'  id='trCEP' visible='<%$Settings: visible, Cliente.CEP, true %>' >
				<div class='tdFieldHeader fl' style="width:40px">
					CEP:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtCEP' MaxLength='10' Width="65px" />
					<asp:RequiredFieldValidator runat='server' ID='valReqCEP' Enabled='<%$Settings: Required, Cliente.CEP, false %>' Display='None' ErrorMessage='CEP &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCEP' />
				</div>
			</div>
			<div class='trField fr' runat='server'  id='trUF' visible='<%$Settings: visible, Cliente.UF, true %>' >
				<div class='tdFieldHeader fl' style="width:40px">
					UF:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList DataTextField="UF" DataValueField="UF" runat="server" ID="cboUF" />
					<asp:CompareValidator runat="server"  ID="valCompUF" Display="None" ErrorMessage="UF inv&aacute;lida" ControlToValidate="cboUF" Operator="NotEqual" ValueToCompare="" />
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb fl' runat='server'  id='trTelefone' visible='<%$Settings: visible, Cliente.Telefone, true %>' >
				<div class='tdFieldHeader fl'>
					Telefone:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtTelefone' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqTelefone' Enabled='<%$Settings: Required, Cliente.Telefone, false %>' Display='None' ErrorMessage='Telefone &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtTelefone' />
				</div>
			</div>
			<div class='trField fr' runat='server'  id='trContato' visible='<%$Settings: visible, Cliente.Contato, true %>' >
				<div class='tdFieldHeader fl' style="width:90px">
					Contato:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtContato' MaxLength='20' />
					<asp:RequiredFieldValidator runat='server' ID='valReqContato' Enabled='<%$Settings: Required, Cliente.Contato, false %>' Display='None' ErrorMessage='Contato &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtContato' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb fl' runat='server'  id='trLatitude' visible='<%$Settings: visible, Cliente.Latitude, true %>' >
				<div class='tdFieldHeader fl' id='tdLatitude'>
					Latitude:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtLatitude' Width='80px' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLatitude' Enabled='<%$Settings: Required, Cliente.Latitude, false %>' Display='None' ErrorMessage='Latitude &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLatitude' />
				</div>
			</div>
			<div class='trField fl' runat='server' id='trLongitude' visible='<%$Settings: visible, Cliente.Longitude, true %>' >
				<div class='tdFieldHeader fl' style="width:80px">
					Longitude:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtLongitude' Width='80px' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLongitude' Enabled='<%$Settings: Required, Cliente.Longitude, false %>' Display='None' ErrorMessage='Longitude &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLongitude' />
				</div>
			</div>
			<div class='trField fl' runat='server' id='divVerMapa'>
				<div class='tdFieldHeader fl' style="width:100px;vertical-align:top;">
					Ver Mapa:<a href='javascript:AbrirMapa();' runat='server' id='lnkImagem'><img src="../imagens/view-map.gif" border='0' style="vertical-align:bottom;" /></a>
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb fl' runat='server'  id='trIDBloqueio' visible='<%$Settings: visible, Cliente.IDBloqueio, true %>' >
				<div class='tdFieldHeader fl'>
					Bloqueio:
				</div>
				<div class='tdField fl'>
					<asp:DropDownList runat="server" ID="cboIDBloqueio" DataTextField="Bloqueio" DataValueField="IDBloqueio" />
					<asp:RequiredFieldValidator runat='server' ID='valReqIDBloqueio' Display='None' ErrorMessage='Bloqueio &eacute; um campo obrigat&oacute;rio!' ControlToValidate='cboIDBloqueio' />
				</div>
			</div>
			<div class='trField fr' runat='server'  id='trLimite' visible='<%$Settings: visible, Cliente.Limite, true %>' >
				<div class='tdFieldHeader fl'>
					Limite de cr&eacute;dito:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtLimite' />
					<asp:RequiredFieldValidator runat='server' ID='valReqLimite' Enabled='<%$Settings: Required, Cliente.Limite, false %>' Display='None' ErrorMessage='Limite &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtLimite' />
					<asp:CompareValidator runat='server'  ID='valCompLimite' Display='None' ErrorMessage='Limite inv&aacute;lida' ControlToValidate='txtLimite' Operator='DataTypeCheck' Type='Currency' />
				</div>
			</div>
			<div class='trField cb' runat='server'  id='trCriado' visible='<%$Settings: visible, Cliente.Criado, true %>' >
				<div class='tdFieldHeader cb fl'>
					Data de cria&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCriado' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField cb' style="margin-top:25px" runat='server'  id='trObservacao' visible='<%$Settings: visible, Cliente.Observacao, true %>' >
				<div class='tdFieldHeader cb fl'>
					observa&ccedil;&atilde;o:
				</div>
				<div class='tdField fl'>
					<asp:TextBox runat='server' ID='txtObservacao' MaxLength='1000' Rows='5' TextMode='MultiLine' Width='100%' />
					<asp:RequiredFieldValidator runat='server' ID='valReqObservacao' Enabled='<%$Settings: Required, Cliente.Observacao, false %>' Display='None' ErrorMessage='observa&ccedil;&atilde;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtObservacao' />
				</div>
			</div>
		</div>
	</div>
	<script type='text/javascript'>
	    function AbrirMapa()
	        {
	        var Lat = document.getElementById('<%=txtLatitude.ClientID %>').value;
	        var Lon = document.getElementById('<%=txtLongitude.ClientID %>').value;
    	    verMapa(Lat, Lon, ".:XM Sistemas:.", "Endereço do Cliente");
	        }
	</script>
    <div class='AreaBotoes'>
        <asp:Button runat='server' ID='btnGravar' Text="Gravar" CssClass='Botao' />
        <asp:Button runat='server' ID='btnApagar' Text="Apagar" CssClass='Botao'  CausesValidation='false' />
        <input type="button" runat='server' id='btnNovo' class="Botao" value=" Novo " onclick="location.href='Cliente.aspx?idcliente=0'" />
        <input type="button" runat="server" id="btnVoltar" class="Botao" value=" Voltar " onclick="location.href='Clientes.aspx'" />
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

