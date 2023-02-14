function getAjax(){
	window.document.body.style.cursor = "wait";

	// DEFINE AS VARIÁVEIS QUE SERÃO UTILIZADAS NO OBJETO

	var req;
	var arrRegistros = "";
	var txtObj = "";
	var txtFunction = "";
	var bitCombo = 0;
	var bitJavaScript = 0;
	var txtValSelected = "";
	var txtHost = "";
	var txtMetod = "GET";
	var arrItensPost = new Array();
	var bitAddInner = 0;
	var txtExibeMSG = "<BR><BR>Consultando Banco de Dados.<BR>Aguarde...<BR><BR>"; //texto que o usuário pode enviar que aparecerá no lugar de "Consultando banco de dados"

	// INÍCIO DO PROCESSAMENTO

	// Seta o nome do objeto que irá receber o conteúdo da informação
	this.setObject = function(txtNome){
		txtObj = txtNome;
	};
	// Seta um valor binário 1=indica que o retorno deve entrar em um objeto do tipo combo; 0=indica que o retorno será em um objeto normal
	this.setCombo = function(txtNome){
		bitCombo = txtNome;
	};
	// Seta um valor binário 1=indica que o retorno deve ser executado como javascript; 0=indica que o retorno será em um objeto normal
	this.setJavaScript = function(txtNome){
		bitJavaScript = txtNome;
	};
	// Seta um nome de função que o objeto chamará após ser carregado as informações
	this.setFunction = function(txtNome){
		txtFunction = txtNome;
	};
	// Seta o valor default para caso for uma combo, este valor virá selecionado
	this.setValSelected = function(txtNome){
		txtValSelected = txtNome;
	};
	// Seta o host
	this.setHost = function(txtNome){
		txtHost = txtNome;
	};
	// Seta o método de envio das informações
	this.setMetod = function(txtNome){
		txtMetod = txtNome;
	};
	// Adiciona informação de variáveis para POST
	this.addVariavel = function(txtCampo, txtValor){
		var numIndice;
		var txtValorTemp = txtValor;
		txtValorTemp = escape(txtValorTemp).replace('+', '%2B').replace('%20', '+').replace('*', '%2A').replace('/', '%2F').replace('@', '%40');

		numIndice = arrItensPost.length;
		arrItensPost[numIndice] = Array(txtCampo, txtValorTemp);
	};
	// Seta um valor binário 1=indica que deve adicionar o valor junto ao conteúdo do innerHTML; 0=indica que o innerHTML será zerado e colocado o novo conteúdo.
	this.setAddInner = function(txtNome){
		bitAddInner = txtNome;
	};
	//texto que o usuário pode enviar que aparecerá no lugar de "Consultando banco de dados"
	this.setExibeMSG = function(txtNome){
		txtExibeMSG = txtNome;
	};

	if(window.XMLHttpRequest) {
    	try {
			req = new XMLHttpRequest();
        } catch(e) {
			req = false;
        };
    } else if(window.ActiveXObject) {
       	try {
        	req = new ActiveXObject("Msxml2.XMLHTTP");
      	} catch(e) {
        	try {
          		req = new ActiveXObject("Microsoft.XMLHTTP");
        	} catch(e) {
          		req = false;
        	};
		};
    };

	this.sendAjax = function(){
		var objRetorno = "";
		if(bitJavaScript!="1"){
			if(txtObj==""){
				alert("Insira o nome do objeto.");
				return;
			};
			objRetorno = document.getElementById(txtObj);
			if(typeof(objRetorno)!="object") return false;
		};
		if(txtHost==""){
			alert("Insira o parâmetro de Host.");
			return;
		};

		//if(txtExibeMSG==""){
		//	txtExibeMSG="<br /><br /><table align='center' width='200' cellspacing='0' cellpadding='0'><tr><td width='35' align='center'><IMG src='imgs/loading.gif' width='32' height='32' border='0' /></td><td width='215' align='left'>Consultando Banco de Dados.<br /><br />Aguarde...</td></tr></table>";
		//};
		if(bitCombo!="1" && bitAddInner!="1" && bitJavaScript!="1" && txtExibeMSG!=""){
			objRetorno.innerHTML = txtExibeMSG;
		};

		window.document.body.style.cursor = "wait";
		if(req) {
			req.onreadystatechange = function(){
				var resultado = "";
				var objRetorno = "";
				var contadorAjax = 0;
				var qtditens;
				var contArr;
				var controleGrupo;
				if (req.readyState == 4) {
					if (req.status == 200) {
						resultado = req.responseText;
					};
					if (req.status == 500) {
						resultado = "erro";
						alert("Erro 500. Erro na página, favor contatar o suporte. \n" + req.statusText);
					};
					if (req.status == 401) {
						resultado = "erro";
						alert("Erro 401. Acesso a leitura da pasta e/ou documento, negado. \n" + req.statusText);
					};
					if(resultado!="erro"){
						if(bitJavaScript!="1"){
							var objRetorno = document.getElementById(txtObj);
							if(typeof(objRetorno)!="object") return false;
						};

						if(parseInt(bitCombo)==1){	// Se for combo
							eval(resultado);
							// Zera tudo as opções
							for(contadorAjax=objRetorno.length-1;contadorAjax>=0;contadorAjax--) {
								objRetorno.options[contadorAjax]=null;
							};
							// Zera tudo os grupos
							var optgroups = objRetorno.childNodes;
							for(contadorAjax=optgroups.length-1; contadorAjax>=0; contadorAjax--){
								objRetorno.removeChild(optgroups[contadorAjax]);
							};
							// Carrega os dados
							qtditens = arrRegistros.length;
							contArr = 0;
							controleGrupo = '0';
							for(contadorAjax=0;contadorAjax<(qtditens);contadorAjax++){
								if(controleGrupo!=arrRegistros[contadorAjax][2] && trim(arrRegistros[contadorAjax][3])!=""){
									var optgroup = document.createElement('optgroup');
									optgroup.label = trim(arrRegistros[contadorAjax][3]);
									objRetorno.appendChild(optgroup);
									controleGrupo = arrRegistros[contadorAjax][2];
								};
								objRetorno.options[contArr] = new Option(arrRegistros[contadorAjax][1],arrRegistros[contadorAjax][0],false);
								if(txtValSelected==arrRegistros[contadorAjax][0]){
									objRetorno.options[contArr].selected = true;
								};
								contArr++;
							};
						}else{ // if(parseInt(this.setCombo)==1){	// Se NÃO for combo
							if(parseInt(bitJavaScript)==1){	// Se for javascript
								eval(resultado);
							}else{ // if(parseInt(bitJavaScript)==1){	// Se NÃO for javascript
								var txtresultado = resultado;
								var numPosIni = 0;
								var numPosFim = 0;
								var txtJavaScript = "";

								while(txtresultado.indexOf("<script>") >= 0){
									numPosIni = txtresultado.indexOf("<script>");
									numPosFim = (txtresultado.indexOf("</script>"))+9;
									if(numPosFim<numPosIni) break;
									txtJavaScript += " " +txtresultado.substring(numPosIni + 8, numPosFim - 9);
									txtresultado = txtresultado.substring(0,numPosIni) + txtresultado.substring(numPosFim, txtresultado.length);
								};

								if(bitAddInner==0){
									objRetorno.innerHTML = txtresultado;
								}else{
									objRetorno.innerHTML += txtresultado;
								};
								eval(txtJavaScript);
							};
						};
	
						if(txtFunction!=""){ // Caso seja para executar alguma função no final do processamento
							eval(txtFunction);
						};
					};
				};
				window.document.body.style.cursor = "default";
			};
	
			req.open(txtMetod, txtHost, true);
			req.setRequestHeader("Content-Type", "text/html; charset=iso-8859-1"); //"application/x-www-form-urlencoded");
//			req.setRequestHeader('Charset','windows-1252');
//			req.setRequestHeader("charset","ISO-8859-1");
			req.setRequestHeader("CharSet","iso-8859-1");
			req.setRequestHeader("Encoding","iso-8859-1");
			req.setRequestHeader("Cache-Control", "no-cache");
			req.setRequestHeader("Pragma", "no-cache");
			if(txtMetod!="GET"){
				var txtItensPost = "";
				for(var numCount=0; numCount<arrItensPost.length; numCount++){
					if(txtItensPost!="") txtItensPost += "&";
					txtItensPost += arrItensPost[numCount][0] + "=" + arrItensPost[numCount][1];
				};
				req.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
				req.send(txtItensPost);
				//req.send(null);
			}else{
				req.send(null);
			};
			
		};
	};
	window.document.body.style.cursor = "default";
};