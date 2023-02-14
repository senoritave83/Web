function addFase(){
			var valorText, valorValue, bitInsere;
			if(document.form1.cmb_fases.value=="0"){
				if(typeof(document.form1.cmb_fases.length)=="number"){
					for(auxcli=1;auxcli<document.form1.cmb_fases.length;auxcli++){
						bitInsere=1;
						valorValue = document.form1.cmb_fases[auxcli].value;
						valorText = document.form1.cmb_fases.options[auxcli].text;
						for(aux=0;aux<document.form1.cmb_fases_sel.length;aux++){
							if(trim(valorValue)==trim(document.form1.cmb_fases_sel[aux].value)){
								bitInsere=0;
							};
						};
						if(bitInsere==1){
							document.form1.cmb_fases_sel.options[document.form1.cmb_fases_sel.options.length] = new Option(valorText, valorValue, true, false);
						};
					};
				};
			}else{
				fAdicionaItens("cmb_fases", "cmb_fases_sel", "", "");
			};
		};

	function delFase(){
			fRemoveItens("cmb_fases_sel");
		};
		
		
	function addSegmento(){
			var valorText, valorValue, bitInsere;
			if(document.form1.cmb_segmentos.value=="0"){
				if(typeof(document.form1.cmb_segmentos.length)=="number"){
					for(auxcli=1;auxcli<document.form1.cmb_segmentos.length;auxcli++){
						bitInsere=1;
						valorValue = document.form1.cmb_segmentos[auxcli].value;
						valorText = document.form1.cmb_segmentos.options[auxcli].text;
						for(aux=0;aux<document.form1.cmb_segmentos_sel.length;aux++){
							if(trim(valorValue)==trim(document.form1.cmb_segmentos_sel[aux].value)){
								bitInsere=0;
							};
						};
						if(bitInsere==1){
							document.form1.cmb_segmentos_sel.options[document.form1.cmb_segmentos_sel.options.length] = new Option(valorText, valorValue, true, false);
						};
					};
				};
			}else{
				fAdicionaItens("cmb_segmentos", "cmb_segmentos_sel", "", "");
			};
		};

	function delSegmento(){
			fRemoveItens("cmb_segmentos_sel");
		};
		
		
	function addEstado(){
			var valorText, valorValue, bitInsere;
			if(document.form1.cmb_estados.value=="0"){
				if(typeof(document.form1.cmb_estados.length)=="number"){
					for(auxcli=1;auxcli<document.form1.cmb_estados.length;auxcli++){
						bitInsere=1;
						valorValue = document.form1.cmb_estados[auxcli].value;
						valorText = document.form1.cmb_estados.options[auxcli].text;
						for(aux=0;aux<document.form1.cmb_estados_sel.length;aux++){
							if(trim(valorValue)==trim(document.form1.cmb_estados_sel[aux].value)){
								bitInsere=0;
							};
						};
						if(bitInsere==1){
							document.form1.cmb_estados_sel.options[document.form1.cmb_estados_sel.options.length] = new Option(valorText, valorValue, true, false);
						};
					};
				};
			}else{
				fAdicionaItens("cmb_estados", "cmb_estados_sel", "", "");
			};
		};

	function delEstado(){
			fRemoveItens("cmb_estados_sel");
		};