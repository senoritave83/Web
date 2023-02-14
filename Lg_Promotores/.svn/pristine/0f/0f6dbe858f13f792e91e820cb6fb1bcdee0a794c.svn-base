// DATA: 24/06/2009


/*
txt += "<p>Browser Version: " + navigator.appVersion + "</p>";
txt += "<p>Cookies Enabled: " + navigator.cookieEnabled + "</p>";
txt += "<p>Platform: " + navigator.platform + "</p>";
txt += "<p>User-agent header: " + navigator.userAgent + "</p>";
document.getElementById("example").innerHTML = txt;
*/

var p_Navigator = navigator.appVersion;

/*INICIO IE9*/
function CreateValidations() {
    var bValidate = false;

    if (p_Navigator.indexOf("MSIE 9.0") > 0) {
    }

    for (var iForm = 0; iForm < document.forms.length; iForm++) {
        var form = document.forms(iForm);
        bValidate = false;
        for (var iField = 0; iField < form.length; iField++) {
            var field = form.elements(iField);
            if (field.getAttribute("validar") == 'true') {

                bValidate = true;
                if (field.getAttribute("opcoes") == undefined) {
                    field.setAttribute("opcoes", 'format_off');
                }
                if (field.getAttribute("onkeydown") == undefined || field.getAttribute("onkeydown") == null) {
                    field.onkeydown = fncCheckKeyPress;
                }

                if (field.getAttribute("onfocus") == undefined) {
                    field.onfocus = fncEnterField;
                }
                if (field.getAttribute("onblur") == undefined) {                    
                    field.onblur = fncLeaveField;
                }
                if (field.getAttribute("tipo") == 'inteiro') {
                    if (field.getAttribute("formato") != undefined && field.getAttribute("direcao") == undefined) {
                        field.setAttribute("direcao", 'right');
                    }
                }
                if (field.getAttribute("tipo") == 'data' && field.getAttribute("opcoes") != 'format_off') {
                    if (field.getAttribute("formato") == undefined) field.setAttribute("formato", '##/##/####');
                    if (field.getAttribute("direcao") == undefined) field.setAttribute("direcao", 'right');
                    if (field.getAttribute("opcoes") == undefined) field.setAttribute("opcoes", 'format_inline');
                }
                if (field.getAttribute("tipo") == 'cnpj' || field.getAttribute("tipo") == 'cpf') {
                    if (field.getAttribute("formato") == undefined) {
                        if (field.getAttribute("tipo") == 'cnpj') {
                            field.setAttribute("formato", '##.###.###/####-##');
                        } else {
                            field.setAttribute("formato", '###.###.###-##');
                        }
                    }
                    if (field.getAttribute("direcao") == undefined) field.setAttribute("direcao", 'right');
                    field.setAttribute("opcoes", 'format_inline');
                }
                if (field.getAttribute("tipo") == 'hora') {
                    //field.setAttribute("formato",  '##:##');
                    //field.setAttribute("direcao",  'right');
                    if (field.getAttribute("formato") == undefined) field.setAttribute("formato", '##:##');
                    if (field.getAttribute("direcao") == undefined) field.setAttribute("direcao", 'left');
                    //if (field.getAttribute("opcoes == undefined) field.setAttribute("opcoes",  'format_inline');
                    field.setAttribute("opcoes", 'format_inline');
                }
                if (field.getAttribute("decimais") == undefined && field.getAttribute("tipo") == 'moeda') {
                    field.setAttribute("decimais", 2);
                }
                if ((field.getAttribute("tipo") == 'numero' || field.getAttribute("tipo") == 'moeda') && field.getAttribute("opcoes") != 'format_off') {
                    dc = (field.getAttribute("decimais") == undefined) ? 2 : field.getAttribute("decimais");
                    if (field.getAttribute("opcoes") != 'format_inline') {
                        if (field.getAttribute("formato") == undefined) {
                            field.setAttribute("formato", '###.###.###.##0' + ((dc > 0) ? ',' + repeat('0', dc) : ''));
                        }
                    } else {
                        if (field.getAttribute("formato") == undefined) {
                            field.setAttribute("formato", '###.###.###.###' + ((dc > 0) ? ',' + repeat('#', dc) : ''));
                        }
                    }
                    field.setAttribute("direcao", 'left');
                }                
                if (field.getAttribute("formato") != undefined) {
                    if (field.getAttribute("opcoes") == 'format_onblur') {
                        field.setAttribute("maxLength", fncLimpaFormato(field.getAttribute("formato")).length);
                    } else if (field.getAttribute("opcoes") == 'format_inline') {
                        if (field.getAttribute("onkeyup") == undefined) {
                            field.onkeyup = fncFormataCampo;
                        }
                        field.setAttribute("maxLength", field.getAttribute("formato").length);
                    } else if (field.getAttribute("opcoes") == 'format_off') {
                        field.setAttribute("maxLength", field.getAttribute("formato").length);
                    }
                }
            }
        }
        if (bValidate) { form.onsubmit = fncOnSubmitForm; }
    } // end for
} // function

function fncCheckKeyPress() {
    var field = event.srcElement;

    if (field.getAttribute("tipo") == 'numero' || field.getAttribute("tipo") == 'moeda') {
        return fncNumero();
    }
    if (field.getAttribute("tipo") == 'inteiro' || field.getAttribute("tipo") == 'data' || field.getAttribute("tipo") == 'hora' || field.getAttribute("tipo") == 'cnpj' || field.getAttribute("tipo") == 'cpf') {
        return fncInteiro();
    }
}

function fncLeaveField() {
    var field = event.srcElement;
    if (field.getAttribute("opcoes") != 'format_off') {
        fncFormataCampo();
    }
    fncVerificaDecimais();
    fncCheckField();
}

function fncVerificaDecimais() {
    var field = event.srcElement;
    if (field.getAttribute("decimais") != undefined) {
        var iPoint = inStr(field.value, ',');
        if (iPoint != -1) {
            iPoint += parseInt(field.getAttribute("decimais")) + 1;
            var vResto = field.value.substring(0, iPoint);
            field.setAttribute("value", vResto);
        }
    }
}

function fncEnterField() {
    var field = event.srcElement;
    if (field.getAttribute("opcoes") == 'format_onblur' && field.getAttribute("formato") != undefined) {
        field.setAttribute("value", fncRemoveChars(field.value, replace(field.getAttribute("formato"), '0', '')));
    }
}

function fncLimpaFormato(value) {
    var vRet = '';
    value = String(value);
    for (var i = 0; i < value.length; i++) {
        ch = value.substring(i, i + 1);
        if (ch == '0' || ch == '#') {
            vRet = vRet + ch;
        }
    }
    return vRet;
}

function fncCheckField() {
    var field = event.srcElement;
    if (field.value == '') return true;
    if ((field.getAttribute("tipo") == 'inteiro' && field.getAttribute("formato") == undefined) || field.getAttribute("tipo") == 'moeda' || field.getAttribute("tipo") == 'numero') {
        var vl = replace(replace(field.value, '.', ''), ',', '.')
        if (CFloat(field.value) != vl) {
            alert('Valor inválido!');
            field.setAttribute("value", '');
            field.focus();
        }
    }
    if (field.getAttribute("tipo") == 'data') {
        if (isDate(field.value) == false) {
            alert('Data inválida');
            field.setAttribute("value", '');
            field.focus();
        }
    }
    if (field.getAttribute("tipo") == 'hora') {
        if (isHora(field.value) == false) {
            alert('Hora inválida');
            field.setAttribute("value", '');
            field.focus();
        }
    }
}

function fncOnSubmitForm() {
    var form = event.srcElement;
    return verificaFormulario(form);
}

function submitForm(form) {
    if (verificaFormulario(form) == true)
        form.submit();
}

function verificaCampo(field) {
    var vMessage = '';
    if (field.getAttribute("obrigatorio") == 'true' && field.getAttribute("selectedIndex") != undefined && field.getAttribute("selectedIndex") < parseInt(field.getAttribute("minIndex"))) {
        vMessage = vMessage + 'O campo "' + fncGetNomeCampo(field) + '" é obrigatório! \n';
    } else if (field.getAttribute("obrigatorio") == 'true' && field.value == '') {
        vMessage = vMessage + 'O campo "' + fncGetNomeCampo(field) + '" é obrigatório! \n';
    } else {
        if (field.getAttribute("tipo") == 'data') {
            if (isDate(field.value) == false && field.value != '') {
                vMessage = vMessage + 'Data inválida no campo "' + fncGetNomeCampo(field) + '"! \n';
            }
        }
        if (field.getAttribute("tipo") == 'hora') {
            if (isHora(field.value) == false && field.value != '') {
                vMessage = vMessage + 'Hora inválida no campo "' + fncGetNomeCampo(field) + '"! \n';
            }
        }
        if (field.getAttribute("min") != undefined) {
            if (CFloat(field.value) < CFloat(field.getAttribute("min")) && field.value != '') {
                vMessage = vMessage + 'O campo "' + fncGetNomeCampo(field) + '" deve ser maior que "' + field.getAttribute("min") + '"! \n';
            }
        }
        if (field.getAttribute("max") != undefined) {
            if (CFloat(field.value) > CFloat(field.getAttribute("max")) && field.value != '') {
                vMessage = vMessage + 'O campo "' + fncGetNomeCampo(field) + '" deve ser menor que "' + field.getAttribute("max") + '"! \n';
            }
        }
    }
    return vMessage;
}

function verificaFormulario(form) {
    if (form == undefined) {
        alert('Não há formulário definido!');
        return false;
    }
    var vMessage = '';
    for (var iField = 0; iField < form.length; iField++) {
        var field = form.elements(iField);
        if (field.getAttribute("validar") == 'true') {
            vMessage = vMessage + verificaCampo(field);
            //alert('minIndex:' + field.getAttribute("minIndex + ' index:' + field.getAttribute("selectedIndex"));
        }
    }
    if (vMessage == '') {
        return true;
    } else {
        alert(vMessage);
        return false;
    }
}

function fncGetNomeCampo(field) {
    if (field.getAttribute("campo") == undefined)
        return field.getAttribute("name")
    else
        return field.getAttribute("campo");
}

function fncFormataCampo() {
    var field = event.srcElement;
    if (field.getAttribute("formato") != undefined && field.getAttribute("value") != '') {
        field.value = fncFormatar(field.value, field.getAttribute("formato"), field.getAttribute("direcao"));
    }
}

function fncFormatar(valor, formato, direcao) {
    if (formato == undefined) return valor;
    var vTmp = '';
    var vRet = '';
    vTmp = fncRemoveChars(valor, replace(formato, '0', ''));
    if (direcao == 'right') {
        for (var i = 0; i < formato.length; i++) {
            var ch = formato.substring(i, i + 1);
            if (vTmp != '') {
                if (ch == '#') {
                    vRet = vRet + vTmp.substring(0, 1);
                    vTmp = vTmp.substring(1);
                } else {
                    vRet = vRet + ch;
                }
            } else if (inStr(formato.substring(i), '0') > 0) {
                vRet = ch + vRet;
            }
        }
    } else {
        for (var i = formato.length; i > 0; i--) {
            var ch = formato.substring(i - 1, i);
            if (vTmp != '') {
                if (ch == '#' || ch == '0') {
                    vRet = vTmp.substring(vTmp.length - 1, vTmp.length) + vRet;
                    vTmp = vTmp.substring(0, vTmp.length - 1);
                } else {
                    vRet = ch + vRet;
                }
            } else if (inStr(formato.substring(0, i), '0') > 0) {
                vRet = ch + vRet;
            }

        }
    }
    return vRet;
}

function fncRemoveChars(value, caracs) {
    var vRet = '';
    for (var i = 0; i < value.length; i++) {
        var ch = value.substring(i, i + 1)
        if (inStr(caracs, ch) < 0) {
            vRet = vRet + ch;
        }
    }
    return vRet;
}

window.onload = CreateValidations;