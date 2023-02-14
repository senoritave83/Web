<%@ Page ValidateRequest="false" Language="VB" AutoEventWireup="false" CodeFile="TesteRelatorio.aspx.vb" Inherits="reports_TesteRelatorio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" ACTION="http://www.xmpromotores.com.br/jj/site/reports/relmob.aspx" METHOD="POST">
    <div>
        <INPUT name="reportpath" VALUE="/xmpromotores/johnson_xmprom/_mob_Ultimas_Visitas2" style="width:400px;" /><br>
        <INPUT name="parameters" VALUE='<?xml version="1.0" encoding="iso-8859-1"?><ParameterValues><ParameterValue><Name>IDEMPRESA</Name><Value>20</Value></ParameterValue><ParameterValue><Name>IDUSUARIO</Name><Value>3</Value></ParameterValue></ParameterValues>'  style="width:600px;height:600px;"  /><br>
        <input type="button" value="Abrir relatório" onclick="submitform();" />    
    </div>
    </form>
    <script type="text/javascript">
        function submitform() {

            openWindowWithPost('http://www.xmpromotores.com.br/jj/site/reports/relmob.aspx');
            //document.forms(0).submit();
            /*
            var DataToSend = "reportpath=" + document.getElementById('reportpath') + "parameters=" + document.getElementById('parameters');
            var xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            xmlhttp.Open("POST","http://localhost:55253/XMPromotores/reports/relmob.aspx",false);
            xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            xmlhttp.send(DataToSend);
            alert(xmlhttp.responseText);
            */
        }
        function openWindowWithPost(url) {
            var newWindow = window.open(url, 'NOVAJANELA', 'height=400, width=600');
            if (!newWindow) return false;
            var html = "";

            html += "<html><head></head><body><form id='formid' method='post' action='" + url + "'>";
            html += "<INPUT NAME='reportpath' VALUE='/xmpromotores/johnson_xmprom/_mob_Ultimas_Visitas2' style='width:400px;' />"
            html += "<INPUT NAME='parameters' VALUE='" + "<?xml version='1.0' encoding='iso-8859-1'?><ParameterValues><ParameterValue><Name>IDEMPRESA</Name><Value>20</Value></ParameterValue><ParameterValue><Name>IDUSUARIO</Name><Value>3</Value></ParameterValue></ParameterValues>'>"
            html += "</form><script type='text/javascript'>document.getElementById(\"formid\").submit()<" + "/" + "script></body></html>";

            newWindow.document.write(html);

            return newWindow;
        }
</script>
</body>
</html>
