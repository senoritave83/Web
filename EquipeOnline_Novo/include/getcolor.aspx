<%@ Page Language="VB" AutoEventWireup="false" CodeFile="getcolor.aspx.vb" Inherits="include_getcolor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Selecionar cor</title>
    <style type='text/css'>
        body {
	        margin-left: 0px;
	        margin-top: 0px;
	        margin-right: 0px;
	        margin-bottom: 0px;
	        font-family: Verdana, Arial, Helvetica;
	        font-size: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border=0>
	        <tr>
		        <td colspan=15>
			        <font class='TextNol1'>Cores Básicas</font>
		        </td>
	        </tr>
	        <tr>
		        <%
		        For i As integer = 0 to 15
			        Response.Write("<td bgcolor='" & xBasic(i) & "'><a href='javascript:selColor(""" & xBasic(i) & """);'><img src='../images/pt.gif' height=10 width=10 border=0></a></td>" & vbcrlf)
		        next
		        %>
	        </tr>
	        <tr>
		        <td colspan=15>
			        <font class='TextNol1'>Cores Adicionais</font>
		        </td>
	        </tr>
	        <tr>
		        <%
		        For i As integer = 16 to uBound(xBasic)
			        Response.Write ("<td bgcolor='" & xBasic(i) & "'><a href='javascript:selColor(""" & xBasic(i) & """);'><img src='../images/pt.gif' height=10 width=10 border=0></a></td>" & vbcrlf)
			        If (i + 1) mod 16 = 0 and i > 0 Then
				        Response.Write ("</tr><tr>" & vbcrlf)
			        end if		
		        next
		        %>
	        </tr>
	        <tr>
		        <td colspan=16>
			        <table Width=100%>
				        <tr>
					        <td Width=100%>
						        <font class='TextNol1'>Cor:<span id='spCor' /></font>
					        </td>
					        <td>
						        <table bgcolor='Gray'>
							        <tr bgcolor=White>
								        <td id=tdColor><img src="../images/pt.gif" height=15 width=15></td>
							        </tr>
						        </table>
					        </td>
				        </tr>
			        </table>
		        </td>
	        </tr>
	        <tr>
		        <td colspan=16>
			        <table width=100%>
				        <tr>
					        <td Width=50% align=left> 
						        <input type=button value=' Aplicar ' Class='Botao'  onClick='fncAplicar();'>
					        </td>
					        <td Width=50% align=right>  
						        <input type=button value=' Cancelar ' Class='Botao'>
					        </td>
				        </tr>
			        </table>
		        </td>
	        </tr>
        </table>
    </div>
    </form>
<script>
	function selColor(ColorName)
	{
		tdColor.bgColor = ColorName;
		spCor.innerHTML = ColorName;
	}
		
	selColor('<%=Request("Cor")%>');
	
	function fncAplicar()
	{
		//opener.document.forms[0].<%=Request("Field")%>.value = spCor.innerHTML;
		opener.setCor(spCor.innerHTML, '<%=Request("Field")%>');
		opener.newwindow = null;
		opener.focus();
		self.close();
	}
</script>
</body>
</html>
