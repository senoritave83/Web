<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SelectCliente.ascx.vb" Inherits="include_SelectCliente" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:DropDownList cssclass='formulario' id="cboCliente" runat="server" DataTextField='cli_Cliente_chr' DataValueField='cli_Cliente_chr' />
<asp:TextBox ID="txtCliente" runat="server" />						    
<cc1:AutoCompleteExtender ID="AutoCompleteExtender1" TargetControlID="txtCliente"
    runat="server" ServiceMethod="GetClienteCompletionList" 
    ServicePath="~/home/AutoComplete.asmx" MinimumPrefixLength="1" /> 

<script type='text/javascript'>
    function getSelectedCliente() {
        var cboCliente = document.getElementById('<%=cboCliente.ClientID()%>');
        var txtCliente = document.getElementById('<%=txtCliente.ClientID()%>');

        var vCliente = '';
        if (cboCliente == null) {
            vCliente = txtCliente.value
        }
        else {
            vCliente = cboCliente.options[cboCliente.selectedIndex].value;
        };

        return vCliente;
    }
</script>