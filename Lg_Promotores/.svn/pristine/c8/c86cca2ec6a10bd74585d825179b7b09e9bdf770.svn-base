function removeCar(p_Field,Caracter)
{

    var p_Valor = p_Field.value;
    var i = 0;           
    while(i < p_Valor.length) 
    {
        p_Valor = p_Valor.replace(Caracter,'');
        i = i + 1;
    }
    p_Field.value = p_Valor;
    return;
    
}

function remove(Value,Caracter)
{

    var p_Valor = Value;
    var i = 0;           
    while(i < p_Valor.length) 
    {
        p_Valor = p_Valor.replace(Caracter,'');
        i = i + 1;
    }
    return p_Valor;
}

function verMapa(IdEmpresa, IdVisita, TipoMapa) {
    var wh = window.open("Rota_Popup.aspx?IDEmpresa=" + IdEmpresa + "&IdVisita=" + IdVisita + "&TipoMapa=" + TipoMapa, "mapa", "width=700, height=600, toolbars=no");
    wh.focus();

}

function fncInteiro() {
	if ((event.keyCode < 48 || event.keyCode > 57) && event.keyCode !=8 && event.keyCode !=96 && event.keyCode !=39  && event.keyCode !=37  && event.keyCode !=46 && event.keyCode !=45 && event.keyCode !=36 && event.keyCode !=35 && event.keyCode !=9 && (event.keyCode > 105 || event.keyCode < 97))
		return false;
	else
		return true;
	}

function fncNumero() {
	if (fncInteiro() == true || event.keyCode == 188 || event.keyCode == 110 || event.keyCode == 189 || event.keyCode == 109) {
		return true;
	} else {
		return false;
	}
}
	
function fncInteiroNegativo() {
	if (event.keyCode != 189) {
		return fncInteiro();	
	} else {
		return true;
	}
}

function toInt(x)
    {
        return ( x>0 ? Math.floor(x) : Math.ceil(x) )
    }
function formatValue(p_Field)
{
    removeCar(p_Field, ',');
    var p_Value = p_Field.value;
    var p_formatValue = '00000000';
    var p_newValue = toInt(Right(p_formatValue.toString() + p_Value, 8))
    if(p_newValue.length == 0 || p_newValue == 0)
        p_newValue = '0,00';
    else
        {
            /*if(p_newValue.toString().length == 4)
                p_newValue = '0' + p_newValue;
            else if(p_newValue.toString().length == 3)
                p_newValue = '00' + p_newValue;
            else */if(p_newValue.toString().length == 2)
                p_newValue = '0' + p_newValue;
            else if(p_newValue.toString().length == 1)
                p_newValue = '00' + p_newValue;

            p_newValue = p_newValue.toString().substring(0, p_newValue.toString().length - 2) + ',' +  Right(p_newValue.toString(),2)
            
        }
    p_Field.value = p_newValue;
    return;
}
function unformatValue(p_Field)
{
    removeCar(p_Field, ',');
    p_Field.select();
    return;
}
function Left(str, n){
    if (n <= 0)
        return "";
    else if (n > String(str).length)
        return str;
    else
        return String(str).substring(0,n);
}
function Right(str, n){
    if (n <= 0)
       return "";
    else if (n > String(str).length)
       return str;
    else {
       var iLen = String(str).length;
       return String(str).substring(iLen, iLen - n);
    }
}
function getDataAtual() {
   var p_Today = new Date();
   var p_TheDate = Right('00' + p_Today.getDate(),2) +'/'+ Right('00' + (p_Today.getMonth() + 1),2) + '/' + p_Today.getYear() 
   return p_TheDate;
}
function FormataData(Campo, teclapres)
{
    var Letras = "abcdefghijlmnopqrstuvxzkyw";
    var tecla = teclapres.keyCode;
    var vr = new String(Campo.value);
    vr = vr.replace("/", "");
    tam = vr.length + 1 ;

    if(	teclapres.keyCode >= 96 && teclapres.keyCode <= 105 || 
        teclapres.keyCode >= 48 && teclapres.keyCode <= 57
        )
    {
        if (tam == 3)
	        Campo.value = vr.substr(0,2) + '/';
        else if (tam == 4)
	        Campo.value = vr.substr(0,2) + '/' + vr.substr(2,2);
        else if (tam >= 5 && tam <= 8)
	        Campo.value = vr.substr(0,2) + '/' + vr.substr(2,2) + '/' + vr.substr(5,4);
		
        return true;
    }
    else if(teclapres.keyCode == 8 ||
	        teclapres.keyCode == 9 ||
	        teclapres.keyCode >= 33 && 
	        teclapres.keyCode <= 40 || 
	        teclapres.keyCode == 18 ||
	        teclapres.keyCode == 46)
    {
        return true;
    }
    else
    {
        return false;
    }
}



function inStr(value, find) {
	for (var i = 0; i < value.length; i++)
		if (value.substring(i, i+find.length) == find) {
			return i;
		}
	return -1;
}

function inStrRev(value, find) {
	return inStr(reverse(value), find);
}

function replace(value, find, subs) {
	var vRet = '';
	value = String(value);
	for (var i = 0; i < value.length; i++)
		if (value.substring(i, i + find.length) == find) {
			vRet = vRet + subs;
			i = i + find.length - 1;
		} else {
			vRet = vRet + value.substring(i, i+1);
		}
	return vRet;
}

function reverse(value) {
	var vRet = '';
	for (var i = 0; i < value.length; i++)
		vRet = value.substring(i, i+1) + vRet;
	return vRet;
}

function repeat(Char, qtd) {
	var vRet = '';
	for (var i = 1; i <= qtd; i++)
		vRet = vRet + Char;
	return vRet;
}

function CFloat(value) {
	return parseFloat(replace(replace(value, '.', ''), ',', '.'));
}

function isDate(value){
	if (value.length != 10) return false;
	if (value.substring(2,3) != '/') return false;
	if (value.substring(5,6) != '/') return false;
	value = replace(value, '/', '');
	if (value.length != 8) return false;
	var ano, mes, dia;
	dia = value.substring(0, 2);
	mes = value.substring(2, 4) - 1;
	ano = value.substring(4, 8);
	var date = new Date(ano, mes, dia);
	if (typeof(date) == "object") {
		if (ano == date.getFullYear() && mes == date.getMonth() && dia == date.getDate()) {
			return true;
		}
	}
	return false;
}

function isHora(value)
{
    return true;
}

function VerificaData(Campo)
{
    var checkstr = "0123456789";
    var DateValue = Campo.value;
    var DateTemp = "";
    var seperator = ".";
    var day;
    var month;
    var year;
    var leap = 0;
    var err = 0;
    var i;
    err = 0;
	
    for (i = 0; i < DateValue.length; i++) 
    {
        if (checkstr.indexOf(DateValue.substr(i,1)) >= 0) 
        {
        DateTemp = DateTemp + DateValue.substr(i,1);
        }
    }
    DateValue = DateTemp;
    /* Always change date to 8 digits - string*/
    /* if year is entered as 2-digit / always assume 20xx */
    if (DateValue.length == 6) 
    {
        if(DateValue.substr(4,2)<=30)
        {
	        Campo.value = DateValue.substr(0,2) + '/' + DateValue.substr(2,2) + '/' + '20' + DateValue.substr(4,2); 
        }
        else
        {
	        Campo.value = DateValue.substr(0,2) + '/' + DateValue.substr(2,2) + '/' + '19' + DateValue.substr(4,2); 
        }
        DateValue = DateValue.substr(0,4) + '20' + DateValue.substr(4,2); 
    }
    if (DateValue.length != 8) 
    {
        err = 19;
    }
    /* year is wrong if year = 0000 */
    year = DateValue.substr(4,4);
    if (year == 0) 
    {
        err = 20;
    }
    /* Validation of month*/
    month = DateValue.substr(2,2);
    if ((month < 1) || (month > 12)) 
    {
        err = 21;
    }
    /* Validation of day*/
    day = DateValue.substr(0,2);
    if (day < 1) 
    {
        err = 22;
    }
    /* Validation leap-year / february / day */
    if ((year % 4 == 0) || (year % 100 == 0) || (year % 400 == 0)) 
    {
        leap = 1;
    }
    if ((month == 2) && (leap == 1) && (day > 29)) 
    {
        err = 23;
    }
    if ((month == 2) && (leap != 1) && (day > 28)) 
    {
        err = 24;
    }
    /* Validation of other months */
    if ((day > 31) && ((month == "01") || (month == "03") || (month == "05") || (month == "07") || (month == "08") || (month == "10") || (month == "12"))) 
    {
        err = 25;
    }
    if ((day > 30) && ((month == "04") || (month == "06") || (month == "09") || (month == "11"))) 
    {
        err = 26;
    }
    /* if 00 ist entered, no error, deleting the entry */
    if ((day == 0) && (month == 0) && (year == 00)) 
    {
        err = 0; day = ""; month = ""; year = ""; seperator = "";
    }
    /* if no error, write the completed date to Input-Field (e.g. 13.12.2001) */
    if (err == 0) 
    {
        return true;
    }
    /* Error-message if err != 0 */
    else 
    {
        Campo.value = "";
        return false;
    }
}
function upperCase(p_Obj)
{
    var x=p_Obj.value;
    p_Obj.value=x.toUpperCase();
}

function valida_CPFCNPJ(oSrc,args){
    var vValue = remove(remove(remove(args.Value, "."), "/"), "-")
    if (vValue.length == 11){
        valida_CPF(oSrc,args);
    }else if(vValue.length == 14){
        valida_CNPJ(oSrc, args);
    }else{
        return args.IsValid = false;
    }
}

//Validação de CPF

function valida_CPF(oSrc,args){

    s = remove(remove(remove(args.Value, "."), "/"), "-");

    if (isNaN(s)) {
        return args.IsValid = false;
    }

    var i;
    var c = s.substr(0,9);
    var dv = s.substr(9,2);
    var d1 = 0;

    for (i = 0; i < 9; i++) {
        d1 += c.charAt(i)*(10-i);
    }

    if (d1 == 0){
        return args.IsValid = false;
    } 

    d1 = 11 - (d1 % 11);
    if (d1 > 9) d1 = 0; 
    if (dv.charAt(0) != d1) {
        return args.IsValid = false; 
    }

    d1 *= 2;
    for (i = 0; i < 9; i++) {
        d1 += c.charAt(i)*(11-i);
    }

    d1 = 11 - (d1 % 11);
    if (d1 > 9) d1 = 0;
    if (dv.charAt(1) != d1) {
        return args.IsValid = false;
    }

    return args.IsValid = true;
} 

//Validação de CNPJ

function valida_CNPJ(oSrc, args){

    s = remove(remove(remove(args.Value, "."), "/"), "-");
    
    if (isNaN(s)) {
        return args.IsValid = false;
    }

    var i;
    var c = s.substr(0,12);
    var dv = s.substr(12,2);
    var d1 = 0;

    for (i = 0; i <12; i++){
        d1 += c.charAt(11-i)*(2+(i % 8));
    }

    if (d1 == 0) 
        return args.IsValid = false;

    d1 = 11 - (d1 % 11);
    if (d1 > 9) d1 = 0;
    if (dv.charAt(0) != d1){
        return args.IsValid = false;
    }

    d1 *= 2;
    for (i = 0; i < 12; i++){
        d1 += c.charAt(11-i)*(2+((i+1) % 8));
    }

    d1 = 11 - (d1 % 11);
    if (d1 > 9) 
        d1 = 0;

    if (dv.charAt(1) != d1){
        return args.IsValid = false;
    }

    return args.IsValid = true;
}

function sDiv(o) {
    o.style.display = 'inline';
}
function hDiv(o) {
    o.style.display = 'none';
}