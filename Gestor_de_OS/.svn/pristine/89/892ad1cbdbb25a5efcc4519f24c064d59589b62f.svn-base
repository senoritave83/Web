'***********************************************************************
'  Visual Basic ActiveX Script
'************************************************************************

	Dim strErro
	Set rs = CreateObject("ADODB.Recordset")
	Set cn = CreateObject("ADODB.Connection")
	'cn.Open "Provider=SQLOLEDB;Server=sqlserver;uid=sa;pwd=sql@#xm#@tat;database=EquipeOnLine;"
    cn.Open "Provider=SQLOLEDB;Server=BRZw2ap04;uid=eol_teste;pwd=xmteste1234;database=EquipeOnLine;"
	rs.CursorLocation = 3
	rs.Open "SP_EOL_WEB_LS_ENVIAR_SMS", cn, 3,3
	Do while Not rs.EOF
		strErro = envia_sms(rs("ddd"), rs("phone"), rs("Body"), rs("url") & "")
		if strErro = "" then 
			cn.Execute "SP_EOL_WEB_UP_ENVIO_SMS " & rs("evm_EnvioEmail_int_PK") & ", " & rs("emp_Empresa_int_FK")
		else
			cn.Execute "SP_EOL_WEB_UP_ENVIO_SMS " & rs("evm_EnvioEmail_int_PK") & ", " & rs("emp_Empresa_int_FK") & ", '" & Replace(strErro, "'", "''") & "'"
		end if
		rs.MoveNext
	Loop
	rs.Close
	cn.Execute "SP_EOL_WEB_UP_ENVIO_SMS_TENTATIVA"
	cn.Close
	Set rs = Nothing
	Set cn = Nothing


Function envia_sms(xDDD, xDestinatario, xMensagem, xRemetente)

	On Error Resume Next

    dim objIE

    Set objIE = CreateObject("InternetExplorer.Application") 
    objIE.Visible = 0 
    objIE.Navigate xRemetente & "_apusr=Felipe&amp;_appwd=felipe&amp;_bdmsg=" & xMensagem & "&amp;_clddd=" & xDDD & "&amp;_clphone=" & xDestinatario
    
    Set objIE = Nothing 

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