<%
''-----------------------------------------------------------------------------------------------------
'COPYRIGHT XM SISTEMAS DISTRIBUIDOS LTDA
'MÓDULO DE RECEBIMENTO DOS DADOS VIA DTS PARA O ITC.NET
'OBJETIVO...........: RECEBE OS DADOS ENVIADOS ATRAVÉS DO DTS E ENVIA AO BANCO DE DADOS
'PROGRAMADOR........: MARCELO REZENDE M SOUZA, LUIS FELIPE ASSUMPÇÃO FLEURY
'DATA...............: 13/02/2006
''-----------------------------------------------------------------------------------------------------

dim rs, strSQL, strOutput
dim i, strReturn, vIDLog 
Dim cn, cmd

Dim p_TipoTarefa, p_XML, p_TotalBytes

p_TipoTarefa	= Request.QueryString("T")
p_TotalBytes	= Request.TotalBytes
p_XML			= Request.BinaryRead(p_TotalBytes)

set fs = Server.CreateObject("Scripting.FileSystemObject")
set txt = fs.OpenTextFile(Server.MapPath("/itc/updateoffline/") & "\LOG_" & p_TipoTarefa & "_XML.txt", 8, true)
txt.WriteLine "----------------------------------------------"
txt.WriteLine "XML"
txt.WriteLine p_XML
txt.writeline "----------------------------------------------" & vbcrlf
txt.close

Response.Expires = -1
Response.ExpiresAbsolute = Now -1
Response.AddHeader "Content-Type", "text/plain"

Set cn = Server.CreateObject("ADODB.Connection")
cn.Open "provider=sqloledb;Server=192.168.0.1;uid=sa;pwd=cfmf2;database=ITC;"
	
if VerificaRequest() = True then

	'*************************************************
	'************* PROCESSA REQUISICAO ***************
	'*************************************************
	Set cmd = Server.CreateObject("ADODB.Command")
	With cmd
		Set .ActiveConnection = cn
		.CommandType = 1
		.CommandText = strSQL

		Set strOutput = Server.CreateObject("ADODB.Stream")
		strOutput.Open
		.Properties("Output Stream") = strOutput

		On Error Resume Next
		err.Clear
		.Execute , , 1024
		If err.number <> 0 Then
			set txt = fs.OpenTextFile(Server.MapPath("/itc/updateoffline/") & "\LOG_" & p_TipoTarefa & "_ATUALIZACAO_ERRO.txt", 8, true)
			txt.WriteLine "----------------------------------------------"
			txt.WriteLine "ERRO NA ATUALIZAÇÃO DO XML"
			txt.WriteLine "Número do Erro" & err.number
			txt.WriteLine "Descrição do Erro" & err.Description
			txt.writeline "----------------------------------------------" & vbcrlf
			txt.close
		end if
		strReturn = strOutput.ReadText
		On Error Goto 0
		
	End With
	Set cmd = Nothing

end if

if strReturn <> "" Then

	Response.AddHeader "Content-Length", CStr(Len(strReturn))
	Response.Write strReturn 
	
end if

cn.Close
Set cn = Nothing

Function VerificaRequest()
	
	Set doc = Server.CreateObject("Microsoft.XMLDOM")
	doc.Async = False
	
	If doc.Load(p_XML) Then
		
		strSQL = "SP_OFF_IMP_IN_" & p_TipoTarefa & " '" & p_XML  & "'"
		
		set txt = fs.OpenTextFile(Server.MapPath("/itc/updateoffline/") & "\LOG_" & p_TipoTarefa & "_ATUALIZACAO.txt", 8, true)		
		txt.write "----------------------------------------------"
		txt.write "XM SISTEMAS - AUDITORIA" & vbCrLf
		txt.write "TENTATIVA DE ENVIO DE DADOS EM " & Now & vbCrLf
		On Error Resume Next
		txt.write "DADOS " & strSQL & vbCrLf
		On Error Goto 0
		txt.write "----------------------------------------------"
		txt.close
		
		VerificaRequest = true
		
	else
		
		VerificaRequest = false
		
		On Error Resume Next
		set txt = fs.OpenTextFile(Server.MapPath("/itc/updateoffline/") & "\LOG_" & p_TipoTarefa & "_ATUALIZACAO_ERRO.txt", 8, true)
		txt.writeline "----------------------------------------------"
		txt.WriteLine "XML PARSER ERROR"
		txt.WriteLine "Reason: " & doc.parseError.reason
		txt.WriteLine "Line: " & doc.parseError.line 
		txt.WriteLine "Line position: " & doc.parseError.linepos
		txt.WriteLine "Src text: " & doc.parseError.srcText
		txt.writeline "----------------------------------------------"
		txt.close
		On Error Goto 0
		Response.end
		
	End IF
	
	set txt = nothing
	set fs = nothing
		
	Dim blnOk
	blnOk = True
	
End Function

'Response.Write " "
%>