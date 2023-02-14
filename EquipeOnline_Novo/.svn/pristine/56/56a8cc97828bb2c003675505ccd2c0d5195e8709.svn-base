
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v3.0
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}

}

function fncAbrirAjuda(vAjuda) {
    var wh = window.open("../ajuda/" + vAjuda, 'Online_help', "height=500, width=600, scrollbars=yes");
    wh.focus();
}


function direitos()

{
window.open('http://www.nextel.com.br/w_direitos_br.htm','_blank','width=513,height=500,status=no,scrollbars=yes,toolbar=no,top=20,left=20');
}
	function fncCleanFormat(vData)
		{
//		vData.value = vData.value.replace(".","");
		var vout = "";
		var vtemp = "";
		var vNumbers = "0123456789";
		for (var i=0; i <= vData.value.length; i++)
			{
			vtemp = vData.value.substring(i,i + 1);
			if (vNumbers.indexOf(vtemp)>-1)
				{vout = vout + vtemp;};
			}
			if (vData.value != vout) vData.value = vout;

    }
    function Left(str, n) {
        if (n <= 0)
            return "";
        else if (n > String(str).length)
            return str;
        else
            return String(str).substring(0, n);
    }
    function Right(str, n) {
        if (n <= 0)
            return "";
        else if (n > String(str).length)
            return str;
        else {
            var iLen = String(str).length;
            return String(str).substring(iLen, iLen - n);
        }
    }

    function inStr(value, find) {
        for (var i = 0; i < value.length; i++)
            if (value.substring(i, i + find.length) == find) {
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
            vRet = vRet + value.substring(i, i + 1);
        }
        return vRet;
    }

    function reverse(value) {
        var vRet = '';
        for (var i = 0; i < value.length; i++)
            vRet = value.substring(i, i + 1) + vRet;
        return vRet;
    }

    function repeat(Char, qtd) {
        var vRet = '';
        for (var i = 1; i <= qtd; i++)
            vRet = vRet + Char;
        return vRet;
    }

    function isDate(value) {
        if (value.length != 10) return false;
        if (value.substring(2, 3) != '/') return false;
        if (value.substring(5, 6) != '/') return false;
        value = replace(value, '/', '');
        if (value.length != 8) return false;
        var ano, mes, dia;
        dia = value.substring(0, 2);
        mes = value.substring(2, 4) - 1;
        ano = value.substring(4, 8);
        var date = new Date(ano, mes, dia);
        if (typeof (date) == "object") {
            if (ano == date.getFullYear() && mes == date.getMonth() && dia == date.getDate()) {
                return true;
            }
        }
        return false;
    }

    function isHora(value) {
        if (value.length < 4) return false;
        if (value.length > 5) return false;
        var i = inStr(value, ":");
        if (i == -1) return false;
        var hora = value.substring(0, i);
        var minuto = value.substring(i + 1, value.length);
        if (!isInteger(hora)) return false;
        if (!isInteger(minuto)) return false;
        if (hora > 23) return false;
        if (minuto > 59) return false;
        return true;
    }

    function fncFormatar(valor, formato, direcao) {
		if (formato == undefined) return valor;
		var vTmp = '';
		var vRet = '';
		vTmp = fncRemoveChars(valor, replace(formato, '0', ''));
		if (direcao == 'right') {
			for (var i = 0; i < formato.length; i++) {
				var ch = formato.substring(i, i+1);
				if (vTmp != '') {
					if (ch == '#') {
						vRet = vRet + vTmp.substring(0,1);
						vTmp = vTmp.substring(1);
					} else {
						vRet = vRet + ch;
					}
				} else if (inStr(formato.substring(i), '0') > 0) {
					vRet = ch + vRet;
            	}
			}
		} else {
			for (var i = formato.length;i > 0; i--) {
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
			if (inStr(caracs,  ch) < 0) {
				vRet = vRet + ch;
			}
		}
		return vRet;
	}


	function fncFormatText(vData)
		{
		var vout = "";
		if(vData.value.length==11)
			{
			vout = vData.value.substring(0, 3) + '.' + vData.value.substring(3, 6) + '.' + vData.value.substring(6, 9) + '-' + vData.value.substring(9, 11);
			vData.value = vout;
			}
		else if(vData.value.length==14)
			{
			vout = vData.value.substring(0, 2) + '.' + vData.value.substring(2, 5) + '.' + vData.value.substring(5, 8) + '/' + vData.value.substring(8, 12) + '-' + vData.value.substring(12, 14);
			vData.value = vout;
			};
		ValidatorOnLoad();
		}

	function fncOnlyInteger() {
		if ((event.keyCode < 48 || event.keyCode > 57) && event.keyCode !=8 && event.keyCode !=96 && event.keyCode !=39  && event.keyCode !=37  && event.keyCode !=46 && event.keyCode !=45 && event.keyCode !=36 && event.keyCode !=35 && (event.keyCode < 96 || event.keyCode > 105))
		return false;
		}
	function fncSelCliente(vFiltro)
		{
		var newwindow = null;
		if ( newwindow != null ) 
			{
			newwindow.close();
			}
			newwindow = window.open('inc/selcliente.aspx?filtro=' + vFiltro,'nsel','width=350,height=300,resizable,statusbar;');
			newwindow.focus();
		}
	

	function fncAjuda()
		{
		var newwindow = null;
		if ( newwindow != null ) 
			{
			newwindow.close();
			}
			newwindow = window.open('pop/passo_intro.htm','ajuda','width=450,height=350,resizable;');
			newwindow.focus();
		}
	
	function selectAll(vObject, vChecked)
		{
		if (isNaN(vChecked))
			{
			vChecked = true;
			}
		if (vObject != undefined)
			{
			if (isNaN(vObject.length))
				{
				vObject.checked = vChecked;
				}
			else
				{
				for(var i=0; i < vObject.length; i++)
					{
					vObject[i].checked = vChecked;
					}
				};
			}
		/*else
			{
			}*/
		}


	function isEmpty(s)
	{   if ((s == null) || (s.length == 0))
		{
			return true;
		}
		else
		{
			for (var i = 0 ; i < s.length ; i++) 
			{
				if (s.charAt(i) != ' ') 
				{
					return false;
				}
			}
		}
		return true;
	}
	
	function isInteger(s)
	{   var i;

		if (isEmpty(s)) 
		if (isInteger.arguments.length == 1) return false;
		else return (isInteger.arguments[1] == true);

		// Search through string's characters one by one
		// until we find a non-numeric character.
		// When we do, return false; if we don't, return true.

		for (i = 0; i < s.length; i++)
		{   
			// Check that current character is number.
			var c = s.charAt(i);

			if (!isDigit(c)) return false;
		}

		// All characters are numbers.
		return true;
	}

	function isDigit(c)
	{   
		return ((c >= "0") && (c <= "9"))
	}

	
	function fncPermitirUS(){
		
		var ret = false;
	
		if(event.keyCode>=48 && event.keyCode<=57)
		{
			ret = true;
		}

		if (event.keyCode>=65 && event.keyCode<=90)
		{
			ret = true;
		}

		if (event.keyCode>=97 && event.keyCode<=122) 
		{
			ret = true;
		}
		
		event.returnValue = ret;

	}
	
	/*
	A - 65
	Z - 90
	
	
	*/
	
	function fncPermitirNumeros(){
		if((event.keyCode<48)||(event.keyCode>57))
			event.returnValue = false;
	}
 
 
	function Mascara(pControl, pMask)
	{

		var valorAtual = pControl.value;
		var valorNumerico = '';
		var nIndexMask = 0;
		var nIndexString = 0;
		var valorFinal = '';
		var adicionarValor = true;


		// limpa a string valor atual para verificar
		// se todos os caracteres são números
		for (i=0;i<pMask.length;i++)
		{
			if (pMask.substr(i,1) != '#')
			{
				valorAtual = valorAtual.replace(pMask.substr(i,1),'');
			}
		}

		// verifica se todos os caracteres são números
		for (i=0;i<valorAtual.length;i++)
		{
			if (!isNaN(parseFloat(valorAtual.substr(i,1))))
			{
				valorNumerico = valorNumerico + valorAtual.substr(i,1);
			}
		}

		// aplica a máscara ao campo informado usando
		// o pMask de máscara informado no script
		for (i=0;i<pMask.length;i++)
		{

			if (pMask.substr(i,1) == '#')
			{
				if (valorNumerico.substr(nIndexMask,1) != '')
				{
					valorFinal = valorFinal + valorNumerico.substr(nIndexMask,1);
					nIndexMask++;nIndexString++;
				}
				else 
				{
					adicionarValor = false;
				}
			}
			else 
			{
				if (adicionarValor && valorNumerico.substr(nIndexMask,1) != '')
				{
					valorFinal = valorFinal + pMask.substr(nIndexString,1);
					nIndexString++;
				}
			}
		}
		
		pControl.value = valorFinal
	}


	function VerifyValidCep(poText){
		var rExp;
		rExp = /^\d{5}\-\d{3}$/;
		
		if(!rExp.test(poText)) {
			return false;
		}
		else {
			return true;
		}
	}

	function validaCNPJ(svalue) {
		CNPJ = svalue
		
		if (CNPJ.length < 18) {
			return false;
		}
		if ((CNPJ.charAt(2) != ".") || (CNPJ.charAt(6) != ".") || (CNPJ.charAt(10) != "/") || (CNPJ.charAt(15) != "-")){
			return false;
		}
		//substituir os caracteres que nao sao numeros
		if(document.layers && parseInt(navigator.appVersion) == 4){
			x = CNPJ.substring(0,2);
			x += CNPJ.substring(3,6);
			x += CNPJ.substring(7,10);
			x += CNPJ.substring(11,15);
			x += CNPJ.substring(16,18);
			CNPJ = x;	
		} else {
			CNPJ = CNPJ.replace(".","");
			CNPJ = CNPJ.replace(".","");
			CNPJ = CNPJ.replace("-","");
			CNPJ = CNPJ.replace("/","");
		}
		var nonNumbers = /\D/;
		if (nonNumbers.test(CNPJ)) { 
			return false;
		}
		var a = [];
		var b = new Number;
		var c = [6,5,4,3,2,9,8,7,6,5,4,3,2];
		for (i=0; i<12; i++){
			a[i] = CNPJ.charAt(i);
			b += a[i] * c[i+1];
		}
		if ((x = b % 11) < 2) { a[12] = 0 } else { a[12] = 11-x }
		b = 0;
		for (y=0; y<13; y++) {
			b += (a[y] * c[y]); 
		}
		if ((x = b % 11) < 2) { a[13] = 0; } else { a[13] = 11-x; }
		if ((CNPJ.charAt(12) != a[12]) || (CNPJ.charAt(13) != a[13])){
			return false;
		}

		return true;
}


function fncCarregaCombo(listField, vArray) {
    listField.length = 0;
    for (var i = 0; i < vArray.length; i++) {
        var len = listField.length++;
        listField.options[len].value = vArray[i][0];
        listField.options[len].text = vArray[i][1];
    }
    listField.selectedIndex = -1;
}

function validaDatas(data1, data2) {
    /*
    VERIFICA SE DATA1 É MAIOR QUE A DATA2
    */
    if (
                            parseInt(data2.split("/")[2].toString() + data2.split("/")[1].toString() + data2.split("/")[0].toString()) >=
                            parseInt(data1.split("/")[2].toString() + data1.split("/")[1].toString() + data1.split("/")[0].toString())) {
        return true;
    }
    else
        return false;
}
