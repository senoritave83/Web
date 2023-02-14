<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CamposAdicionais.ascx.vb" Inherits="controls_CamposAdicionais" %>
<br class='cb'>
<div class='trField fl' style="border:1px white dotted" style="width:800px">
	<div class='tdFieldHeader' style="width:150px;">
		Informações adicionais:
	</div>
</div>
<br class='cb'>
<asp:Repeater runat='server' ID='rptCamposAdicionais'>
    <ItemTemplate>
        <div class='trField fl' style="border:1px white dotted" >
	        <div class='tdFieldHeader' style="width:150px;">
		        <%#Eval("Nome")%>
	        </div>
	        <div class='tdField fl'>
	            	<asp:HiddenField runat='server' ID='hidIDCampoAdicional' Value='<%#Eval("IDCampoAdicional") %>' />
		        <asp:TextBox runat='server' ID='txtValor'  ></asp:TextBox> 
		        <asp:DropDownList runat='server' ID='cboValor' DataTextField='Opcao' DataValueField='Opcao' style='width:<%#Eval("Tamanho") %>'  >
		        </asp:DropDownList>
		        <asp:RequiredFieldValidator runat='server' ID='valValor' Enabled='<%#Eval("Requirido")%>' Display='None' ErrorMessage='O Campo <%#Eval("Nome") %> &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtValor' />
	        </div>
        </div><%# iif(Eval("QuebraDeLinha")=1, "<br class='cb'>", "") %>
    </ItemTemplate>
</asp:Repeater>

