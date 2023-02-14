<SCRIPT LANGUAGE="javascript" SRC="/inc/coolmenus.js"></SCRIPT>
<SCRIPT LANGUAGE="javascript" SRC="/inc/home.js"></SCRIPT>
<script>
<%
iF Session("sID") = "1" or Session("sID") = "4" or Session("sID") = "5" or Session("sID") = "15" Then 
	%>
	oM.makeMenu('m9','m8','cadastro de usuários','usuarios.asp');
	oM.makeMenu('m10','m8','Relatório','relatorio.asp');
	oM.makeMenu('m11','m8','Instituições','instituicoes.asp');
	<%
end if
%>

var avail="5+((cmpage.x2-105)/7)";
oM.menuPlacement=new Array(10,avail+"-5",avail+"*2-0",avail+"*3+3",avail+"*4-7",avail+"*5",avail+"*6+10")
oM.construct()

</script>
<SCRIPT LANGUAGE="javascript" SRC="/inc/generico.js"></SCRIPT>
<table border="0" cellpadding="3" cellspacing="0" width="100%" bgcolor="#666666">
    <tr>
        <td>&nbsp;</td>
    </tr>
</table>
