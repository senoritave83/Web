<%@ Control Language="VB" AutoEventWireup="false" CodeFile="txtDescontoMaximo.ascx.vb" Inherits="controls_txtDescontoMaximo" %>
<table border='0'>
    <tr runat='server' id='trSemDesconto'>
        <td width='20px'><asp:RadioButton ID='chkSemDescontoMax' runat='server' GroupName='DescontoMax' Width='20px' onclick='fncMostraDesconto(this.checked, 0)' /></td>
        <td>Sem limite de desconto</td>
    </tr>
    <tr>
        <td runat='server' id='tdOpcaoDesconto'>
            <asp:RadioButton ID='chkComDescontoMax' runat='server' GroupName='DescontoMax' onclick='fncMostraDesconto(this.checked, 1)' />
        </td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width='50px'></asp:TextBox>%
        </td>
    </tr>
</table>
<asp:CompareValidator ID='valCompDescontoMaxType' ControlToValidate='TextBox1' runat='server' Operator='DataTypeCheck' Type='Double' ErrorMessage='Valor do desconto máximo inválido!' Display='None'  />
<asp:CompareValidator ID='valCompDescontoMaxTop' ControlToValidate='TextBox1' runat='server' Operator="LessThanEqual" Type='Double' ValueToCompare='100' ErrorMessage='Desconto máximo não pode ser superior a 100%!' Text='*' Display='None' />
<asp:CompareValidator ID='valCompDescontoMaxMin' ControlToValidate='TextBox1' runat='server' Operator="GreaterThanEqual" Type='Double' ValueToCompare='0' ErrorMessage='Desconto máximo não pode ser inferior a 0%!' Text='*' Display='None' />
<asp:RequiredFieldValidator runat='server' ID='valReqDescontoMax' Enabled='False' Display='None' ErrorMessage='Desconto M&aacute;x. &eacute; um campo obrigat&oacute;rio!' ControlToValidate='TextBox1' />
<script type='text/javascript'>
    function fncMostraDesconto(valor, tipo) {
        var txt = document.getElementById('<%=TextBox1.ClientID %>')
        if (tipo == 0 && valor == true) {
            txt.disabled = true;
        } else {
            txt.disabled = false;
        }
    }
</script>