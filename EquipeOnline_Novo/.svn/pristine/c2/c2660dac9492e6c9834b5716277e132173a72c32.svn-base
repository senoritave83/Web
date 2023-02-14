'***********************************************************************
'  Visual Basic ActiveX Script
'************************************************************************

	Dim strErro
	Set rs = CreateObject("ADODB.Recordset")
	Set cn = CreateObject("ADODB.Connection")
	'cn.Open "Provider=SQLOLEDB;Server=sqlserver;uid=sa;pwd=sql@#xm#@tat;database=EquipeOnLine;"
    cn.Open "Provider=SQLOLEDB;Server=BRZw2ap04;uid=eol_teste;pwd=xmteste1234;database=EquipeOnLine;"
	rs.CursorLocation = 3
	rs.Open "SP_EOL_WEB_LS_ENVIAR_EMAIL", cn, 3,3
	Do while Not rs.EOF
		strErro = envia_email(rs("evm_Subject_chr"), rs("evm_To_chr"), rs("evm_Body_txt"), rs("evm_From_chr") & "")
		if strErro = "" then 
			cn.Execute "SP_EOL_WEB_UP_ENVIO_EMAIL " & rs("evm_EnvioEmail_int_PK") & ", " & rs("emp_Empresa_int_FK")
		else
			cn.Execute "SP_EOL_WEB_UP_ENVIO_EMAIL " & rs("evm_EnvioEmail_int_PK") & ", " & rs("emp_Empresa_int_FK") & ", '" & Replace(strErro, "'", "''") & "'"
		end if
		rs.MoveNext
	Loop
	rs.Close
	cn.Execute "SP_EOL_WEB_UP_ENVIO_EMAIL_TENTATIVA"
	cn.Close
	Set rs = Nothing
	Set cn = Nothing


Function envia_email(xAssunto, xDestinatario, xMensagem, xRemetente)

	On Error Resume Next

	Set objCDOSYSMail = CreateObject("CDO.Message")
	Set objCDOSYSCon = CreateObject ("CDO.Configuration")
	objCDOSYSCon.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserver") = "127.0.0.1"
	objCDOSYSCon.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport")= 25
	objCDOSYSCon.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
	objCDOSYSCon.Fields.Item("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1 'cdoBasic
	objCDOSYSCon.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendusername") = ""
	objCDOSYSCon.Fields.Item("http://schemas.microsoft.com/cdo/configuration/sendpassword") = ""
	objCDOSYSCon.Fields("http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout") = 120
	objCDOSYSCon.Fields.update

	Set objCDOSYSMail.Configuration = objCDOSYSCon
	objCDOSYSMail.From = xRemetente & ""
	objCDOSYSMail.To = xDestinatario & ""
	objCDOSYSMail.Subject = xAssunto & ""  
	objCDOSYSMail.HtmlBody = xMensagem
	objCDOSYSMail.Send

ENVIO_OK:
	On Error Goto 0
    'MsgBox "Mail Sent!"
	Exit Function

ENVIO_NAOOK:
	On Error Goto 0
    'MsgBox "Mail Not Sent!"
	envia_email = err.description
	Exit Function

        
End Function