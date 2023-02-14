<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MaskFormater.ascx.vb" Inherits="include_DataFormater" %>

<%@ Register Assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:TextBox runat="server" ID="txtMaskFormater" MaxLength="10" Width="140px" onkeyup="setCaretPosition(this, format(this, event));" onkeydown="return validate_input(this, event);" onblur="validate_date(this);" >
</asp:TextBox>
<asp:Image ID="imgCalendar" runat="server" ImageUrl="~/images/Calendario.png" />&nbsp;
<cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="Right"  PopupButtonID="imgCalendar" TargetControlID="txtMaskFormater" Format="dd/MM/yyyy" >
</cc1:CalendarExtender>
<asp:RequiredFieldValidator Runat="server" ID="valReqMask" ControlToValidate='txtMaskFormater' ErrorMessage='Campo obrigatório' Display="Dynamic" CssClass="cinza1" Enabled="true" />

<script type="text/javascript">
    function doGetCaretPosition(ctrl) {

        var CaretPos = 0;
        // IE Support
        if (document.selection) {

            ctrl.focus();
            var Sel = document.selection.createRange();

            Sel.moveStart('character', -ctrl.value.length);

            CaretPos = Sel.text.length;
        }
        // Firefox support
        else if (ctrl.selectionStart || ctrl.selectionStart == '0')
            CaretPos = ctrl.selectionStart;

        return (CaretPos);
    }

    function setCaretPosition(ctrl, pos) {

        if (ctrl.setSelectionRange) {
            ctrl.focus();
            ctrl.setSelectionRange(pos, pos);
        }
        else if (ctrl.createTextRange) {
            var range = ctrl.createTextRange();
            range.collapse(true);
            range.moveEnd('character', pos);
            range.moveStart('character', pos);
            range.select();
        }
    }

    function validate_input(control, event) {
        var key = (event.keyCode ? event.keyCode : (event.which ? event.which : event.charCode));
        var teclas = {8:1, 9:1, 35:1, 36:1, 37:1, 39:1, 46:1}; // Teclas de controle

        if (key in teclas) {
            return true;
        }        

        // Aceita Números e Números NumLock
        if (((key >= 48) && (key <= 57)) || ((key >= 96) && (key <= 105))) {
            return true;
        }

        // Recusa qualquer outra tecla
        return false;
    }

    function format(control, event) {
        var pos = doGetCaretPosition(control);
        var key = (event.keyCode ? event.keyCode : (event.which ? event.which : event.charCode));

        if ((key == 37) || (key == 39)) {
            return pos;
        }
        
        control.value = control.value.substring(0, 2).replace('/', '') +
    						control.value.charAt(2) +
    						control.value.substring(3, 5).replace('/', '') +
    						control.value.charAt(5) +
    						control.value.substring(6, control.value.length).replace('/', '');

        if ((control.value.length > 2) && (control.value.charAt(2) != '/')) {
            control.value = control.value.substring(0, 2) + '/' + control.value.substring(2, control.value.length);
            if ((key != 8) && (key != 46) && (pos == 3)) {
                pos++;
            }
        }

        if ((control.value.length > 5) && (control.value.charAt(5) != '/')) {
            control.value = control.value.substring(0, 5) + '/' + control.value.substring(5, control.value.length);
            if ((key != 8) && (key != 46) && (pos == 6)) {
                pos++;
            }
        }

        return pos;
    }

    function validate_date(control) {
        var valid = false;
        
        if (control.value.length == 10) {
            var diasMes = new Array(0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
            var anoMax = 2050;
            var anoMin = 1900;            

            var ano = parseInt(control.value.substring(6, 10));
            var mes = parseInt(control.value.substring(3, 5));
            var dia = parseInt(control.value.substring(0, 2));

            var bisexto = ((ano.value % 400) == 0) || (((ano.value % 100) != 0) && ((ano.value % 4) == 0));

            if (bisexto) {
                diasMes[2] = 29;
            }
            else {
                diasMes[2] = 28;
            }

            if ((anoMin <= ano) && (anoMax >= ano)) {
                if ((1 <= mes) && (12 >= mes)) {
                    if ((1 <= dia) && (diasMes[mes] >= dia)) {
                        valid = true;
                    }
                }
            }
        }

        if (!valid) {
            control.value = "";
        }
    }
</script>