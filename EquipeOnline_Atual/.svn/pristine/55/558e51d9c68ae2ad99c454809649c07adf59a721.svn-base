<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SelectResponsaveis.ascx.vb" Inherits="include_SelectResponsaveis" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:DropDownList cssclass='formulario' id="cboResponsavel" runat="server" DataTextField='Responsavel' DataValueField='Responsavel' />
<asp:TextBox ID="txtResponsavel" runat="server" />						    
<cc1:AutoCompleteExtender ID="AutoCompleteExtender1" TargetControlID="txtResponsavel"
    runat="server" ServiceMethod="GetResponsaveisCompletionList" 
    ServicePath="~/home/AutoComplete.asmx" MinimumPrefixLength="1" /> 

<script type='text/javascript'>
    function getSelectedResponsavel() {
        var cboResponsavel = document.getElementById('<%=cboResponsavel.ClientID()%>');
        var txtResponsavel = document.getElementById('<%=txtResponsavel.ClientID()%>');

        var vResponsavel = '';
        if (cboResponsavel == null) {
            vResponsavel = txtResponsavel.value
        }
        else {
            vResponsavel = cboResponsavel.options[cboResponsavel.selectedIndex].value;
        };
        return vResponsavel;
    }
</script>