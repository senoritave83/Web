//fazendo os filtros///////////////////////////////////////////////////////////////////////
	
	
	function Dados(valor) {
	  try {
         ajax = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            ajax = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               ajax = new XMLHttpRequest();
            }
	        catch(exc) {
               alert("Esse browser não tem recursos para uso do Ajax");
               ajax = null;
            }
         }
      }
	  if(ajax) {
		 document.forms[0].cmb_fases.options.length = 1;
	     
		 idOpcao  = document.getElementById("opcoes"); 
	     ajax.open("POST", "../scripts/carrega_combo_fase.asp", true);
		 ajax.setRequestHeader("Content-Type", "application/x-www-form-urlencoded"); 
		 ajax.onreadystatechange = function() {
			if(ajax.readyState == 1) {
			   idOpcao.innerHTML = "Carregando...";   
	        }
            if(ajax.readyState == 4 ) {
			   if(ajax.responseXML) {
			      processXML(ajax.responseXML);
			   }
			   else {
				   idOpcao.innerHTML = "Selecione";
			   }
			   
            }
         }
	     var params = "fase="+valor;
         ajax.send(params);
      }
   }
   
   function processXML(obj){
      var dataArray   = obj.getElementsByTagName("fase");
	  
	  if(dataArray.length > 0) {
         for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			var codigo    =  item.getElementsByTagName("codigo")[0].firstChild.nodeValue;
			var descricao =  item.getElementsByTagName("descricao")[0].firstChild.nodeValue;
			
	        idOpcao.innerHTML = "Selecione";
			
			var novo = document.createElement("option");
			    novo.setAttribute("id", "opcoes");
			    novo.value = codigo;
			    novo.text  = descricao;
				document.forms[0].cmb_fases.options.add(novo);
		 }
	  }
	  else {
		idOpcao.innerHTML = "Selecione";
	  }	  
   }
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   function Dados_seg(valor) {
	  try {
         ajax = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            ajax = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               ajax = new XMLHttpRequest();
            }
	        catch(exc) {
               alert("Esse browser não tem recursos para uso do Ajax");
               ajax = null;
            }
         }
      }
	  if(ajax) {
		 document.forms[0].cmb_segmentos.options.length = 1;
	     
		 idOpcao  = document.getElementById("opcoes_seg"); 
	     ajax.open("POST", "../scripts/carrega_combo_segmentos.asp", true);
		 ajax.setRequestHeader("Content-Type", "application/x-www-form-urlencoded"); 
		 ajax.onreadystatechange = function() {
			if(ajax.readyState == 1) {
			   idOpcao.innerHTML = "Carregando...";   
	        }
            if(ajax.readyState == 4 ) {
			   if(ajax.responseXML) {
			      processXML_seg(ajax.responseXML);
			   }
			   else {
				   idOpcao.innerHTML = "Selecione";
			   }
			   
            }
         }
	     var params = "fase="+valor;
         ajax.send(params);
      }
   }
   
   function processXML_seg(obj){
      var dataArray   = obj.getElementsByTagName("segmento");
	  
	  if(dataArray.length > 0) {
         for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			var codigo    =  item.getElementsByTagName("codigo")[0].firstChild.nodeValue;
			var descricao =  item.getElementsByTagName("descricao")[0].firstChild.nodeValue;
			
	        idOpcao.innerHTML = "Selecione";
			
			var novo = document.createElement("option");
			    novo.setAttribute("id", "opcoes");
			    novo.value = codigo;
			    novo.text  = descricao;
				document.forms[0].cmb_segmentos.options.add(novo);
		 }
	  }
	  else {
		idOpcao.innerHTML = "Selecione";
	  }	  
   }
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   function Dados_estado(valor) {
	  try {
         ajax = new ActiveXObject("Microsoft.XMLHTTP");
      } 
      catch(e) {
         try {
            ajax = new ActiveXObject("Msxml2.XMLHTTP");
         }
	     catch(ex) {
            try {
               ajax = new XMLHttpRequest();
            }
	        catch(exc) {
               alert("Esse browser não tem recursos para uso do Ajax");
               ajax = null;
            }
         }
      }
	  if(ajax) {
		 document.forms[0].cmb_estados.options.length = 1;
	     
		 idOpcao  = document.getElementById("opcoes_estado"); 
	     ajax.open("POST", "../scripts/carrega_combo_estado.asp", true);
		 ajax.setRequestHeader("Content-Type", "application/x-www-form-urlencoded"); 
		 ajax.onreadystatechange = function() {
			if(ajax.readyState == 1) {
			   idOpcao.innerHTML = "Carregando...";   
	        }
            if(ajax.readyState == 4 ) {
			   if(ajax.responseXML) {
			      processXML_estado(ajax.responseXML);
			   }
			   else {
				   idOpcao.innerHTML = "Selecione";
			   }
			   
            }
         }
	     var params = "fase="+valor;
         ajax.send(params);
      }
   }
   
   function processXML_estado(obj){
      var dataArray   = obj.getElementsByTagName("estado");
	  
	  if(dataArray.length > 0) {
         for(var i = 0 ; i < dataArray.length ; i++) {
            var item = dataArray[i];
			var codigo    =  item.getElementsByTagName("codigo")[0].firstChild.nodeValue;
			var descricao =  item.getElementsByTagName("descricao")[0].firstChild.nodeValue;
			
	        idOpcao.innerHTML = "Selecione";
			
			var novo = document.createElement("option");
			    novo.setAttribute("id", "opcoes");
			    novo.value = codigo;
			    novo.text  = descricao;
				document.forms[0].cmb_estados.options.add(novo);
		 }
	  }
	  else {
		idOpcao.innerHTML = "Selecione";
	  }	  
   }