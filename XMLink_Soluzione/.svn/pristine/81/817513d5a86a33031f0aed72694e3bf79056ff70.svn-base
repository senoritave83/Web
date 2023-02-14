</td></tr>
<tr>
	<td colspan="2">
		<!-- INICIO RODAPE -->
		<!--Tabela final de copyright inicio-->
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td class="Backgr03">
					<table width="750" border="0" cellspacing="0" cellpadding="6">
						<tr>
							<td height="45" align="center">
								<font color=white face=verdana size=1><b>©2009 - ©2010 XM Sistemas Distribuídos Ltda. Todos os direitos reservados.</b></font>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
		<script language="JavaScript">
<!--
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
		if(vData.value != vout) vData.value = vout;
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

	function fncOnlyInteger()
		{
		if ((event.keyCode < 48 || event.keyCode > 57) && event.keyCode !=8 && event.keyCode !=96 && event.keyCode !=39  && event.keyCode !=37  && event.keyCode !=46 && event.keyCode !=45 && event.keyCode !=36 && event.keyCode !=35)
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
		else
			{alert('Undefined');}
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

//-->
		</script>
		<script language="vbscript">

Sub ValidateCPF(source, arguments)
	Numero = arguments.value
	Numero = REPLACE(replace(replace(Numero, ".", ""), "-", ""), "/", "")
	CNPJ = (Len(Numero) = 14)
	Temp = Mid(Numero, 1, len(Numero) - 2)
	for j = 1 to 2 
		k = 2
		Soma = 0
		for i = Len(Temp) to 1 step -1
			Y = Cint(Mid(Temp, i, 1))
			Soma = Soma + (Y * k)
			k = k + 1
			if k > 9 and CNPJ then k = 2
		next
		Digito = 11 - (Soma mod 11)
		if Digito >= 10 then Digito = 0
		Temp = Temp & Digito
	next
	arguments.IsValid = (temp = Numero)
	end sub
	
		</script>
		<!-- FIM RODAPE -->
	</td>
</tr>
</table>
