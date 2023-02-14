function criaXML(){
	var objXML, txtUrl, txtUrlParam;

	txtUrl = "../Login.aspx";

	txtUrlParam = "txtChave="+document.frmLogin.txtChave.value;
	txtUrlParam += "&txtVersion=2";
	txtUrlParam += "&txtLogin="+document.frmLogin.txtLogin.value;
	txtUrlParam += "&txtSenha="+document.frmLogin.txtSenha.value;

	objXML = false;
	if(window.XMLHttpRequest){
		try {
			objXML = new XMLHttpRequest();
				
		} catch(e) {
			objXML = false;
		};
	}else if(window.ActiveXObject){
       	try {
	    	objXML = new ActiveXObject("Msxml2.XMLHTTP");
  		} catch(e) {
        	try {
	      		objXML = new ActiveXObject("Microsoft.XMLHTTP");
			} catch(e) {
      			objXML = false;
    		};
		};
	};

	if(typeof(objXML)=="object"){
		objXML.open("POST", txtUrl, false);
		objXML.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
		objXML.setRequestHeader("Content-length", txtUrlParam.length);
		objXML.setRequestHeader("Connection", "close");
		objXML.send(txtUrlParam);

		return objXML.responseXML;
		//return objXML.responseText;
	};
};

function validaUsuario(){
	var objXML, objXMLRet, numValidacao;

	objXML=criaXML();
	//alert(objXML); return false;

	numValidacao = "-1";
	if(objXML.childNodes.length>0){
		objXMLRet = objXML.getElementsByTagName("retorno");
		if(objXMLRet.length>0){
			numValidacao = objXMLRet[0].childNodes[0].nodeValue;
		};
	};

	if(numValidacao=="0"){
		alert("Usuário ou senha incorretos.");
		document.frmLogin.txtLogin.focus();
		return;
	}else if(numValidacao=="1"){
		document.frmLogin.submit();
		return;
	}else if(numValidacao=="3"){
		document.frmLogin.submit();
		return;
	};
	alert(numValidacao);
	return false;
};