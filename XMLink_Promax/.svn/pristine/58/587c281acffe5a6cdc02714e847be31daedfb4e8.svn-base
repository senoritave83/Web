<%@ Page Language="VB" MasterPageFile="~/Principal.master" AutoEventWireup="false" CodeFile="sar.aspx.vb" Inherits="Pages.Pedidos.Sar" title="Untitled Page" %>

<%@ Register src="../controls/Localizacao.ascx" tagname="Localizacao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class='EditArea'>
		<div class='divEditArea' style="width:100%">
		    <div class='divHeader'>&nbsp;</div>
		    <div class='trField fl' style="width:100%" runat='server'  id='trIDCliente' visible='<%$Settings: visible, Sar.IDCliente, true %>' >
				<div class='tdFieldHeader cb fl'>
					Cliente:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblIDCliente' />
				</div>
			</div>
			<div class='trField fl' style="width:100%" runat='server'  id='trCliente' visible='<%$Settings: visible, Sar.Cliente, true %>' >
				<div class='tdFieldHeader cb fl'>
					Nome do Cliente:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblCliente' />
				</div>
			</div>
			<div class='trField fl' style="width:100%" runat='server'  id='trEndereco' visible='<%$Settings: visible, Sar.Endereco, true %>' >
				<div class='tdFieldHeader fl'>
					Endere&ccedil;o:
				</div>
				<div class='tdField fl'>
					 <asp:Label runat='server' ID='lblEndereco' />
				</div>
			</div>
			<div class='trField fl' style="width:40%" runat='server'  id='trContato' visible='<%$Settings: visible, Sar.Contato, true %>' >
				<div class='tdFieldHeader cb fl'>
					Contato:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblContato' Font-Bold='true' />
				</div>
			</div>
			<br class='cb' />
			<div class='trField fl' style="width:49%" runat='server' id='trSAR' visible='<%$Settings: visible, Sar.SAR, true %>' >
				<div class='tdFieldHeader fl'>
					SAR:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblSAR' />
				</div>
			</div>
			<br class='cb' />
            <div class='trField fl' style="width:49%"  runat='server' id='trVendedor' visible='<%$Settings: visible, Sar.Vendedor, true %>' >
				<div class='tdFieldHeader fl'>
					Vendedor:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblVendedor' />
				</div>
			</div>
			<br class='cb' />
            <div class='trField fl' style="width:49%"  runat='server' id='trVisita' visible='<%$Settings: visible, Sar.Visita, true %>' >
				<div class='tdFieldHeader fl'>
					Visita:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblVisita' />
				</div>
			</div>
			<br class='cb' />
            <div class='trField fl' style="width:49%"  runat='server' id='trEnviado' visible='<%$Settings: visible, Sar.Enviado, true %>' >
				<div class='tdFieldHeader fl'>
					Enviado:
				</div>
				<div class='tdField fl'>
					<asp:Label runat='server' ID='lblEnviado' />
				</div>
			</div>
		</div>
	</div>
	<div class='AreaBotoes'>
        <asp:Button runat="server" ID="btnVoltar" CssClass="Botao" Text=" Voltar " />
    </div>
    <div id='divErros'>
        <asp:BulletedList runat='server' ID='lstErros' SkinID='lstErros' />
        <asp:ValidationSummary runat='server' ID='valSummary' />
    </div>
    <div class='AreaAjuda'>
	    <ul class='TextDefault'>
		    <li>
		        <asp:Localize runat='server' ID='lclAjudaVoltar'>
			        <b>Voltar:</b> Volta para o menu anterior.
		        </asp:Localize>
			</li>
	    </ul>
    </div>
</asp:Content>

