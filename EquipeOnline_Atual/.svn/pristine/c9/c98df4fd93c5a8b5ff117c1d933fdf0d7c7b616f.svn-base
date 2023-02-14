<%@ Page Language="VB" MasterPageFile="~/Principal2.master" AutoEventWireup="false" CodeFile="reenviar.aspx.vb" Inherits="home_reenviar" title="Equipe Online" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table width="101%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr class='Header1'> 
            <td>
                Reenviar O.S.
            </td>
        </tr>
        <tr> 
            <td class='Linha1'><img src="../images/transpa.gif" height="1" alt="" /></td>
        </tr>
        <tr class='Header2'> 
            <td align="left" style="height: 20px">
                Ordem de Servi&ccedil;o:&nbsp;<asp:label id="lblOS" Runat="server"></asp:label>
            </td>
        </tr>
        <tr>
	        <td align="left">	
		        <table border='0' width="100%">
			        <tr>
				        <td style="padding-left:10px; width: 101px;">Enviar para o r&aacute;dio:</td>
				        <td align="left">				       
					        <asp:DropDownList cssClass="formulario" id="cboResponsavel" runat="server" DataValueField="IDDestinatario" DataTextField="Destinatario" />
				        </td>
			        </tr>
		        </table>
	        </td>
        </tr>
        <tr class='Footer1'> 
            <td><img width="1" height="25" src="../images/transpa.gif" alt="" /></td>
        </tr>							
    </table>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Botoes" Runat="Server">
	<asp:ImageButton id="btnVoltar" runat="server" ImageUrl="../images/buttons/btn_voltar.png"></asp:ImageButton>
    <asp:ImageButton id="btnEnviar" runat="server" ImageUrl="../images/buttons/btn_enviar.png"></asp:ImageButton>
</asp:Content>
<asp:Content runat='server' ID='Content4' ContentPlaceHolderID='menuEsquerdo'>
	<dl>
    <dt class="current"><a href="default.aspx">Lista de O.S.</a></dt>
    <dt><a href="novaordem.aspx">Nova O.S.</a></dt>
    <dt><a href="pasta.aspx">Pastas</a></dt>
    </dl>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Ajuda" Runat="Server">
	&bull; <b>Enviar:</b> Selecione o r&aacute;dio para qual deseja enviar a O.S.<br />
</asp:Content>