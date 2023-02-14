<%
ArrTiposTamanho = Array("Bytes", "Kb", "Mb", "Gb", "Tb")

Function TrocaChr(Texto)
	Dim FTexto
	FTexto = trim(Texto)
	FTexto = Replace(FTexto, "'", "''")
	TrocaChr = FTexto
End Function

'--------------------------------------------------------------------------

Function ExcluiArquivo(CaminhoArquivo)
	On Error Resume Next
	'// Deve se aplicar o MapPath
	'// Caminho = Caminho onde o arquivo se encontra
	'// NomeArquivo = Nome do arquivo
	If CaminhoArquivo <> "" Then
		Set Arq = CreateObject("Scripting.FileSystemObject")
		If Arq.FileExists(CaminhoArquivo) = true Then
			Set ArqSai = Arq.GetFile(CaminhoArquivo)
			ArqSai.Delete
			If Err.number <> 0 Then
				Response.Write Err.number & "<BR>" & Err.Description
				Response.end
			End If
			Set ArqSai =nothing
		End If
		Set Arq = nothing
	End If
End Function

'----------------------------------------------------------------------

'// Paginação de registros: inicio
Sub Paginacao(objRS, strLink, intMaximoRegistrosPorPagina, intMaximoBlocoDePaginas, intPaginaAtual)

	'// Hélio, revisar este If que vc colocou, no script q vc sentiu necessidade. Do jeito que vc fez,
	'// na última página da paginação, ele simplesmente não exibe a paginação, pois o RS.EOF retorna true (última página)
	'If objRS.EOF = true Then Exit Sub

	'// OBS: Ao dar executar a instrução select, não esquecer de passar o tipo de cursor como sendo 3
	'// Exemplo: TBOra.Open SQL, Conexao, 3

	'// Setup: configurações da paginação
	If intMaximoRegistrosPorPagina = "" Then intMaximoRegistrosPorPagina = 10  '// máximo de registros por página
	If intMaximoBlocoDePaginas = "" Then intMaximoBlocoDePaginas = 5 '// máximo de blocos de página
	If intPaginaAtual = "" Then intPaginaAtual = 1 '// página inicial

	'// Varifica se o strLink já vem com algum tipo de paramentros
	if instr(strLink,"?")>0 Then
		If Right(strLink,1) <> "?" and Right(strLink,1) <> "&" Then
			strLink = strLink & "&"
		End If
	Else
		strLink = strLink & "?"
	End If

	'// Setup: configurações do recordset
	If objRS.EOF = False Or objRS.BOF = False Then
		If objRS.BOF = false then objRS.MoveFirst
		objRS.CacheSize = intMaximoRegistrosPorPagina
		objRS.PageSize = intMaximoRegistrosPorPagina
		objRS.AbsolutePage = intPaginaAtual
		intTotalPaginas = objRS.PageCount

		'// De acordo com o número da página atual, define primeira e última páginas a serem exibidas
		intIntervalo = Int(intMaximoBlocoDePaginas / 2)
		intPrimeiraPagina = CInt(intPaginaAtual - intIntervalo)
		intUltimaPagina = CInt(intPaginaAtual + intIntervalo)

		If intPrimeiraPagina < 1 Then
			intPrimeiraPagina = 1
			intUltimaPagina = intMaximoBlocoDePaginas
		End If

		If intUltimaPagina > intTotalPaginas Then
			intUltimaPagina = intTotalPaginas
			If (intTotalPaginas - intMaximoBlocoDePaginas) > 0 Then
				intPrimeiraPagina = ((intTotalPaginas - intMaximoBlocoDePaginas)+1)
			End If
		End If
		%><table width="400" border="0" cellpadding="0" cellspacing="0" class="contentTit1">
          <tr>
            <td width="20" align="left"><%'// link "anterior"
			If CInt(intPaginaAtual) > 1 Then
				%><a href="<%=strLink%>intPaginaAtual=<%=(intPaginaAtual-1)%>" title="Anterior"><img src="img/ico/icone_setaesq.gif" width="14" height="14" border="0"></a><%
			Else
				%>&nbsp;<%
			End If %></td>
            <td width="10">&nbsp;</td>
            <td width="360" align="Center"><table border="0" cellpadding="0" cellspacing="0" class="contentTit1"><tr><%
            '// blocos de páginas
			For i = intPrimeiraPagina To intUltimaPagina
				If CStr(i) = Cstr(intPaginaAtual) then
					%><td align="center" class="contentTit1" style="cursor:pointer;">&nbsp;<b><%=i%></b>&nbsp;</td><%
				Else
					%><td align="center" class="contentTit1" style="cursor:pointer;">&nbsp;<b><A href="<%=strLink%>intPaginaAtual=<%=i%>" class="contentTit1"><%=i%></A></b>&nbsp;</td><%
				End If
			Next %></tr></table></td>
            <td width="10">&nbsp;</td>
            <td width="20" align="right"><%'// link "próximo"
			If CInt(intPaginaAtual) < intUltimaPagina Then
				%><a href="<%=strLink%>intPaginaAtual=<%=(intPaginaAtual+1)%>" title="Próxima"><img src="img/ico/icone_setadir.gif" width="14" height="14" border="0"></a><%
			Else
				%>&nbsp;<%
			End If %></td>
          </tr>
        </table><%
	End If
End Sub
'// Paginação de registros: fim

'--------------------------------------------------------------------------------------------------------

'//Função de envio de e-mail
Function EnviaMail(DeNome, DeMail, ParaNome, ParaMail, Assunto, Mensagem, Prioridade, CC, conf_email_envio, conf_email_pass, conf_smtp, conf_smtp_port)
'	on error resume next
	EnviaMail = False

'	Set oArq = CreateObject("Scripting.FileSystemObject")
'	If NomeArquivo = "" Then NomeArquivo = "Emails.htm"
'	CaminhoArquivo = Server.MapPath("logErros") & "\" & NomeArquivo

'	If oArq.FileExists(CaminhoArquivo) = false Then
'		oArq.CreateTextFile(CaminhoArquivo)
'	End If
'	Set Arquivo = oArq.OpenTextFile(CaminhoArquivo,2)

'	Arquivo.WriteLine "<!--" & VbNewLine
'	Arquivo.WriteLine VBNewLine & "--------------------------------------- " & Right("00" & Day(Date()), 2) & "/" & Right("00" & Month(Date()), 2) & "/" & Year(Date()) & " " & Time() & " ---------------------------------------" & VbNewLine
'	Arquivo.WriteLine "De: " & DeNome & " <" & DeMail & ">" & VbNewLine
'	Arquivo.WriteLine "Para: " & ParaNome & " <" & ParaMail & ">" & VbNewLine
'	Arquivo.WriteLine "Assunto: " & Assunto & VbNewLine
'	Arquivo.WriteLine VbNewLine & "-->" & VbNewLine
'	Arquivo.WriteLine Mensagem

'	Arquivo.Close
'	Set Arquivo = Nothing
'	Set oArq = Nothing

'	exit function

If ParaMail <> "" and Instr(ParaMail, "@") > 1 Then
	'// CDONTS
	Set Correio = Server.CreateObject("CDONTS.NewMail")
	Correio.To = ParaMail
	Correio.From = DeNome&" <"&DeMail&">"
	Correio.Subject = Assunto
	Correio.Body = Mensagem
	Correio.BodyFormat = 0
	Correio.MailFormat = 0
	Correio.importance=CInt(Prioridade)
	Correio.Send
	EnviaMail = true

	'// SMTP MAILER
	'Set Correio = Server.CreateObject("SMTPsvg.Mailer")
	'Correio.RemoteHost = "smtp.b2pdv.com"
	'Correio.ContentType = "text/html"
	'Correio.FromName = DeNome
	'Correio.FromAddress = "mailer@b2pdv.com"
	'Correio.AddRecipient ParaNome, ParaMail
	'Correio.Subject = Assunto
	'Correio.BodyText = Mensagem
	'Correio.SendMail
	'if Correio.SendMail then EnviaMail = true
	
	'// ASP EMAIL
	'Set Correio = Server.CreateObject("Persits.MailSender")
	'Correio.Host = conf_smtp
	'Correio.Port = conf_smtp_port
	'Correio.Username = conf_email_envio
	'Correio.Password = conf_email_pass
	
	'Correio.From = DeMail
	'Correio.FromName = DeNome
	
	'Correio.AddAddress ParaMail, ParaNome
	
	'For each CCs in split(CC, ",")
	'	AuxCC = CCs
	'	if(instr(arrCCs, "|")<1) Then
	'		AuxCC = AuxCC & "|" & AuxCC
	'	End If
	'	arrCCs = split(AuxCC, "|")
	'	Correio.AddCC arrCCs(0), arrCCs(1)
	'Next
	
	'Correio.IsHTML = True 
	'Correio.Subject = Assunto
	'Correio.Body = Mensagem

	'Correio.Send
	'EnviaMail = true

	'Set Correio = nothing
End If

'If Err.number <> 0 Then 
'	Response.Write Err.Description & "<BR>"
'	Response.End
'	Err.Clear
'End If

'Response.Write "Passou <BR>" & EnviaMail

End Function

%>