<%@ Control Language="VB" AutoEventWireup="false" CodeFile="txtCorrecao.ascx.vb" Inherits="controls_txtCorrecao" %>
<asp:TextBox ID="txtCorrecao" runat="server" onKeyUp='fncShowCorrecao(this)' Width='50px'></asp:TextBox>
<asp:CompareValidator ID='valCompCorrecao' ControlToValidate='txtCorrecao' runat='server' Operator='DataTypeCheck' Type='Double' ErrorMessage='Valor da correção inválido!' Text='Valor da correção inválido!' Display='None' />
<asp:RequiredFieldValidator runat='server' ID='valReqCorrecao' Display='None' ErrorMessage='Corre&ccedil&atilde;o &eacute; um campo obrigat&oacute;rio!' ControlToValidate='txtCorrecao' />
<span id='spCorrecao' class='spHelp'></span>
<script type='text/javascript'>
    function fncShowCorrecao(txt) {
        var c = CFloat(txt.value);
        if (!isNaN(c)) {
            if (c > 1) {
                spCorrecao.innerHTML = '(' + Math.round(((c - 1) * 100), 2) + '% de acrescimo no preço base)';
            }else if (c < 1){
                spCorrecao.innerHTML = '(' + Math.round(((1 - c) * 100)) + '% de desconto no preço base)';
            } else {
                spCorrecao.innerHTML = '(sem alteração no preço base)';
            }
        } else {
            spCorrecao.innerHTML = '';
        }
    }
    fncShowCorrecao(document.getElementById('<%=txtCorrecao.ClientID%>'));
</script>
