/*
************************************************************
copyright...................: XM Sistemas 2005
última atualização..........: 29/09/2005 19:45
autor........................: Marcelo R
************************************************************
*/
function fncOnlyNumeric(p_KeyCode)
	{
	if (p_KeyCode >= 96 && p_KeyCode <=105)
		{
		return true;
		}
		else
		{
		return false;
		}
	}

function fncOnlyInteger(teclapres)
	{
	if ((teclapres.keyCode < 48 || teclapres.keyCode > 57) && teclapres.keyCode !=8 && teclapres.keyCode !=96 && teclapres.keyCode !=39  && teclapres.keyCode !=37  && teclapres.keyCode !=46 && teclapres.keyCode !=45 && teclapres.keyCode !=36 && teclapres.keyCode !=35 && teclapres.keyCode != 9 && (teclapres.keyCode < 97 || teclapres.keyCode > 105)) {
		return false;
		}
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
function textCounter( field, countfield, maxlimit ) 
{
	if ( field.value.length > maxlimit )
	{
		field.value = field.value.substring( 0, maxlimit );
		return false;
	}
}


function FormataCEP(Campo, teclapres){

	var tecla = teclapres.keyCode;
	var vr = new String(Campo.value);
	vr = vr.replace("-", "");
	tam = vr.length + 1 ;

	if (tam > 5 && tam < 8)
		Campo.value = vr.substr(0,5) + '-' + vr.substr(5,3);
			
}


function FormataCNPJ(Campo, teclapres){

	var tecla = teclapres.keyCode;

	var vr = new String(Campo.value);
	vr = vr.replace(".", "");
	vr = vr.replace(".", "");
	vr = vr.replace("/", "");
	vr = vr.replace("-", "");

	tam = vr.length + 1 ;

	if (tecla != 9 && tecla != 8){
		if (tam > 2 && tam < 6)
			Campo.value = vr.substr(0, 2) + '.' + vr.substr(2, tam);
		if (tam >= 6 && tam < 9)
			Campo.value = vr.substr(0,2) + '.' + vr.substr(2,3) + '.' + vr.substr(5,tam-5);
		if (tam >= 9 && tam < 13)
			Campo.value = vr.substr(0,2) + '.' + vr.substr(2,3) + '.' + vr.substr(5,3) + '/' + vr.substr(8,tam-8);
		if (tam >= 13 && tam < 15)
			Campo.value = vr.substr(0,2) + '.' + vr.substr(2,3) + '.' + vr.substr(5,3) + '/' + vr.substr(8,4)+ '-' + vr.substr(12,tam-12);
		}
}

