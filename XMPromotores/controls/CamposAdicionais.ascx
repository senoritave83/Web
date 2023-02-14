<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CamposAdicionais.ascx.vb" Inherits="controls_CamposAdicionais" %>
<asp:Repeater runat='server' ID='rptCamposAdicionais'>
    <ItemTemplate>
        <div class='trField fl' style="border:1px white dotted" >
	        <span class='tdFieldHeader' style="width:100px;">
		        <a><%#Eval("Nome")%></a>
	        </span><br/>
	        <div class='tdField'>
	            	<asp:HiddenField runat='server' ID='hidIDCampoAdicional' Value='<%#Eval("IDCampoAdicional") %>' />
		        <asp:TextBox runat='server' ID='txtValor'  ></asp:TextBox> 
		        <asp:DropDownList runat='server' ID='cboValor' DataTextField='Opcao' DataValueField='Opcao' style='width:<%#Eval("Tamanho") %>'  CssClass="Select" >
		        </asp:DropDownList>
		        <asp:RequiredFieldValidator runat='server' ID='valValor' Enabled='<%#Eval("Requirido")%>' Display='None' ErrorMessage='O Campo <%#Eval("Nome") %> &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtValor' />
	        </div>
        </div><%# iif(Eval("QuebraDeLinha")=1, "<br class='cb'>", "") %>
    </ItemTemplate>
</asp:Repeater>

