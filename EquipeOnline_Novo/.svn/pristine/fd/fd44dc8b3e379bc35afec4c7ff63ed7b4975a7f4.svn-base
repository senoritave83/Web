// DATA: 24/06/2009

				function CreateValidations() {
				    var bValidate = false;
				    for (var iForm = 0; iForm < document.forms.length; iForm++) {
						var form  = document.forms(iForm);
						bValidate = false;

						for (var iField = 0; iField < form.length; iField++) {
							var field = form.elements(iField);
							if (field.validar == 'true') {
							    bValidate = true;
								if (field.opcoes == undefined) field.opcoes = 'format_off';
								if (field.onkeydown == undefined) field.onkeydown = fncCheckKeyPress;
								if (field.onfocus == undefined) field.onfocus = fncEnterField; 
								if (field.onblur == undefined) field.onblur = fncLeaveField;
								if (field.tipo == 'inteiro') {
									if (field.formato != undefined && field.direcao == undefined) field.direcao = 'right';
								}
								alert(field.name);
								if (field.tipo == 'data' && field.opcoes != 'format_off') {
									if (field.formato == undefined) field.formato = '##/##/####';
									if (field.direcao == undefined) field.direcao = 'right';
									if (field.opcoes == undefined) field.opcoes = 'format_inline';
								}
								if (field.tipo == 'cnpj' || field.tipo == 'cpf')
								{
								    if (field.formato == undefined) 
								    {
								        if (field.tipo == 'cnpj')   {
								            field.formato = '##.###.###/####-##';
								        } else {
								            field.formato = '###.###.###-##';
								        }
								    }
									if (field.direcao == undefined) field.direcao = 'right';
									field.opcoes = 'format_inline';
								}
								if (field.tipo == 'hora') {
								    //field.formato = '##:##';
								    //field.direcao = 'right';
								    if (field.formato == undefined) field.formato = '##:##';
									if (field.direcao == undefined) field.direcao = 'left';
									//if (field.opcoes == undefined) field.opcoes = 'format_inline';
									field.opcoes = 'format_inline';
								}
								if (field.decimais == undefined && field.tipo == 'moeda') field.decimais = 2;
								if ((field.tipo == 'numero' || field.tipo == 'moeda') && field.opcoes != 'format_off') {
									dc = (field.decimais == undefined) ? 2: field.decimais;
									if (field.opcoes != 'format_inline') {
										if (field.formato == undefined) field.formato = '###.###.###.##0' + ((dc > 0) ? ',' + repeat('0', dc): '');
									} else {
										if (field.formato == undefined) field.formato = '###.###.###.###' + ((dc > 0) ? ',' + repeat('#', dc): '');
									}
									field.direcao = 'left';
								}
								if (field.formato != undefined) {
									if (field.opcoes == 'format_onblur') {
										field.maxLength = fncLimpaFormato(field.formato).length;
									} else if (field.opcoes == 'format_inline') {
										if (field.onkeyup == undefined) field.onkeyup = fncFormataCampo;
										field.maxLength = field.formato.length;
									} else if (field.opcoes == 'format_off') {
										field.maxLength = field.formato.length;
									}
								}
							}
						}
						if (bValidate) {form.onsubmit = fncOnSubmitForm;}
					} // end for
				} // function
				
				function fncCheckKeyPress() {
					var field = event.srcElement;
					if (field.tipo == 'numero' || field.tipo == 'moeda') return fncNumero();
					if (field.tipo == 'inteiro' || field.tipo == 'data' || field.tipo == 'hora' || field.tipo == 'cnpj' || field.tipo == 'cpf') return fncInteiro();
				}
				
				function fncLeaveField(){
					var field = event.srcElement;
					if (field.opcoes != 'format_off') fncFormataCampo();
					fncVerificaDecimais();
					fncCheckField();
				}
				
				function fncVerificaDecimais(){
					var field = event.srcElement;
					if (field.decimais != undefined){
						var iPoint = inStr(field.value, ',');
						if (iPoint != -1) {
							iPoint += parseInt(field.decimais) + 1;
							var vResto = field.value.substring(0, iPoint);
							field.value = vResto;
						}
					}
				}
				
				function fncEnterField(){
					var field = event.srcElement;
					if (field.opcoes == 'format_onblur' && field.formato != undefined) field.value = fncRemoveChars(field.value, replace(field.formato, '0', ''));
				}
				
				function fncLimpaFormato(value){
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

				function fncCheckField(){
					var field = event.srcElement;
					if (field.value == '') return true;
					if ((field.tipo == 'inteiro' && field.formato == undefined) || field.tipo == 'moeda' || field.tipo == 'numero') {
						var vl = replace(replace(field.value, '.', ''), ',', '.')
						if (CFloat(field.value) != vl) {
							alert('Valor inválido!');
							field.value = '';
							field.focus();
						}
					}
					if (field.tipo == 'data') {
						if (isDate(field.value) == false) {
							alert('Data inválida');
							field.value = '';
							field.focus();
						}
					}
					if (field.tipo == 'hora') {
						if (isHora(field.value) == false) {
							alert('Hora inválida');
							field.value = '';
							field.focus();
						}
					}
				}
				
				function fncOnSubmitForm() {
					var form  = event.srcElement;
					return verificaFormulario(form);
				}
				
				function submitForm(form){
					if(verificaFormulario(form) == true) 
						form.submit();
				}

				function verificaCampo(field) {
				    var vMessage = '';
				    if (field.obrigatorio == 'true' && field.selectedIndex != undefined && field.selectedIndex < parseInt(field.minIndex)) {
				        vMessage = vMessage + 'O campo "' + fncGetNomeCampo(field) + '" é obrigatório! \n';
				    } else if (field.obrigatorio == 'true' && field.value == '') {
				        vMessage = vMessage + 'O campo "' + fncGetNomeCampo(field) + '" é obrigatório! \n';
				    } else {
				        if (field.tipo == 'data') {
				            if (isDate(field.value) == false && field.value != '') {
				                vMessage = vMessage + 'Data inválida no campo "' + fncGetNomeCampo(field) + '"! \n';
				            }
				        };
				        if (field.tipo == 'hora') {
				            if (isHora(field.value) == false && field.value != '') {
				                vMessage = vMessage + 'Hora inválida no campo "' + fncGetNomeCampo(field) + '"! \n';
				            }
				        };
				        if (field.min != undefined) {
				            if (CFloat(field.value) < CFloat(field.min) && field.value != '') {
				                vMessage = vMessage + 'O campo "' + fncGetNomeCampo(field) + '" deve ser maior que "' + field.min + '"! \n';
				            }
				        };
				        if (field.max != undefined) {
				            if (CFloat(field.value) > CFloat(field.max) && field.value != '') {
				                vMessage = vMessage + 'O campo "' + fncGetNomeCampo(field) + '" deve ser menor que "' + field.max + '"! \n';
				            }
				        };
				    }
				    return vMessage;
				
				}
				
				function verificaFormulario(form) {
					if (form == undefined) {
						alert('Não há formulário definido!');
						return false;
					};
					var vMessage = '';
					for (var iField = 0; iField < form.length; iField++) {
						var field = form.elements(iField);
						if (field.validar == 'true') {
						    vMessage = vMessage + verificaCampo(field);
							//alert('minIndex:' + field.minIndex + ' index:' + field.selectedIndex);
						}
					}
					if (vMessage == '') {
						return true;
					} else {
						alert(vMessage);
						return false;
					}
				}
				
				function fncGetNomeCampo(field){
					if(field.campo == undefined)
						return field.name
					else
						return field.campo;
				}

				function fncFormataCampo() {
					var field = event.srcElement;
					if (field.formato != undefined && field.value != '') field.value = fncFormatar(field.value, field.formato, field.direcao);
				}

				function fncFormatar(valor, formato, direcao) {
					if (formato == undefined) return valor;
					var vTmp = '';
					var vRet = '';
					vTmp = fncRemoveChars(valor, replace(formato, '0', ''));
					if (direcao=='right') {
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
				
				window.onload = CreateValidations;
