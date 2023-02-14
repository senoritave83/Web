/*
variaveis globais
*/
var charLimit = 1000;

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


function trim(inputString) {
	 if(typeof inputString!="string"){return inputString;}
	 var retValue = inputString;
	 var ch=retValue.substring(0,1);
	 while(ch==" "){
			retValue=retValue.substring(1,retValue.length);
			ch=retValue.substring(0,1);
	 }
	 ch=retValue.substring(retValue.length-1,retValue.length);
	 while(ch==" "){
			retValue=retValue.substring(0,retValue.length-1);
			ch=retValue.substring(retValue.length-1,retValue.length);
	 }
	 while(retValue.indexOf("  ") != -1){
			retValue=retValue.substring(0,retValue.indexOf("  "))+retValue.substring(retValue.indexOf("  ")+1,retValue.length);
	 }
	 return retValue;
};

// -------------------------------------------------

function contacaractere(objtexto, cxdestino, limite){
  var qtdletras = objtexto.value.length;
  var objdestino = eval("window."+cxdestino);
  if(qtdletras>limite){
   objtexto.value=objtexto.value.substr(0, limite);
   qtdletras--;
  };
  objdestino.innerHTML = qtdletras;
};

// -------------------------------------------------

function replacejs(valororiginal,stringtroca,novovalor){
	if(stringtroca=="."){
		var constante = /\./i;
	}else{
		var constante = eval("/"+stringtroca+"/i");
	};
	var valortrocado = valororiginal;
	while(valortrocado.indexOf(stringtroca)>=0){
		valortrocado = valortrocado.replace(constante, novovalor);
	};
	return valortrocado;
};

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


function onlyInteger()
{
     if ((event.keyCode < 48 || event.keyCode > 57) && 
        (event.keyCode < 96 || event.keyCode > 105) && 
        event.keyCode !=8   && 
        event.keyCode !=9   && 
        event.keyCode !=96  && 
        event.keyCode !=39  && 
        event.keyCode !=37  && 
        event.keyCode !=46  && 
        event.keyCode !=45  && 
        event.keyCode !=36  && 
        event.keyCode !=35
        )
    return false;
}

	
function FormataAno(Campo)
	{
		var p_Value = Campo.value;
		if (p_Value.length == 4) 
			return
		if (p_Value.length == 3) 
			Campo.value = '2' + Campo.value;
		if (p_Value.length == 2) 
			Campo.value = '20' + Campo.value;
		if (p_Value.length == 1) 
			Campo.value = '200' + Campo.value;
	}
	
	
	
function checkMessageLength (messageField, checkLength, splitcheck) {

	if( checkMessageLength.arguments.length == 1) { checkLength = true; splitcheck = false; }
	if( checkMessageLength.arguments.length == 2) splitcheck = false;
	if( checkLength == false ) return true;
	var count = messageField.value.length;
	var rc = true;
		    
	if( count > charLimit ) {
		messageField.value = messageField.value.substring(0, charLimit)
		messageField.focus();
		rc = false;
	} 
	return rc;
}

function emailCheck(objEmail, apontaFocus){
	if(apontaFocus!="0") apontaFocus = 1;
 
      var emailStr = objEmail.value
 
        //remove espaços antes da verificação
        var emailStr = trim(emailStr)
        /* Critica de e-mail */
        var emailPat=/^(.+)@(.+)$/
        var specialChars="\\(\\)<>@,;:\\\\\\\"\\.\\[\\]"
        var validChars="\[^\\s" + specialChars + "\]"
        var quotedUser="(\"[^\"]*\")"
        var ipDomainPat=/^\[(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})\]$/
        var atom=validChars + '+'
        var word="(" + atom + "|" + quotedUser + ")"
        var userPat=new RegExp("^" + word + "(\\." + word + ")*$")
        var domainPat=new RegExp("^" + atom + "(\\." + atom +")*$")
 

        var matchArray=emailStr.match(emailPat)
        if (matchArray==null) {
			if(apontaFocus==1){
	            objEmail.select();
    	        objEmail.focus();
			};
             return(0);
        }
        var user=matchArray[1]
        var domain=matchArray[2]
 
        if (user.match(userPat)==null) {
	        if(apontaFocus==1){
	            objEmail.select();
    	        objEmail.focus();
			};
             return(0);
        }
 
        var IPArray=domain.match(ipDomainPat)
        if (IPArray!=null) {
                  for (var i=1;i<=4;i++) {
                    if (IPArray[i]>255) {
						  if(apontaFocus==1){
							objEmail.select();
							objEmail.focus();
						  };
                         return(0);
                    }
            }
             return(1);
        }
 
        var domainArray=domain.match(domainPat)
        if (domainArray==null) {
        	 if(apontaFocus==1){
	            objEmail.select();
    	        objEmail.focus();
			};
            return(0);
        }
 
        var atomPat=new RegExp(atom,"g")
        var domArr=domain.match(atomPat)
        var len=domArr.length
        if (domArr[domArr.length-1].length<2 ||
            domArr[domArr.length-1].length>3) {
         	if(apontaFocus==1){
	            objEmail.select();
    	        objEmail.focus();
			};
             return(0);
        }
 
        if (len<2) {
        	if(apontaFocus==1){
	            objEmail.select();
    	        objEmail.focus();
			};
            return(0);
        }
 
         return(1);
}