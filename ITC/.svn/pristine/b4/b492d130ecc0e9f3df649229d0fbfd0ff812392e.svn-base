<%
Function UpLoad(arquivo, imgpath, num, Id)
	'if trim(UploadRequest("arquivo").Item("Value")) <> "" then
	if trim(arquivo.Item("Value")) <> "" and trim(imgpath) <> "" then
		'ContentType = UploadRequest.Item("arquivo").Item("ContentType")
		'filepathname = UploadRequest.Item("arquivo").Item("FileName")
		'extension = mid(filepathname,instr(filepathname,"."),len(filepathname))
		'filename = Right(filepathname,Len(filepathname)-InstrRev(filepathname,"/"))
		'value = UploadRequest("arquivo").Item("Value")
		
		'ContentType = arquivo.Item("ContentType")
		imgpath = Server.MapPath(imgpath) & "\"
		'filepathname = arquivo.Item("FileName")
		'extension = mid(filepathname,instrrev(filepathname,"."),len(filepathname))
		'filename = Right(filepathname,Len(filepathname)-InstrRev(filepathname,"\"))
		filename = Id
		value = arquivo.Item("Value")
		
'num=filename
		'response.write imgpath & ID & num '& extension
		'response.end
		
		'filename = ID & num & "_" & filename ' & extension
		'filename = Replace(filename," ","_")

		Set Arq = Server.CreateObject("Scripting.FileSystemObject")
		Set MyFile = Arq.CreateTextFile(imgpath & filename)

		For i = 1 to LenB(value)
			MyFile.Write chr(AscB(MidB(value,i,1)))
		Next
		MyFile.Close
		Set MyFile = Nothing
		Set Arq = Nothing
		UpLoad = filename
	End If
End Function
'-------------------------------------------------------------------------------------------
Sub BuildUploadRequest(RequestBin)
        Dim PosBeg
        Dim PosEnd
        Dim Pos
        Dim PosFile
        Dim PosBound
        Dim Value
        Dim FileName
        Dim ContentType
        Dim Boundary
        Dim BoundaryPos
        Dim i
        Dim name
	'Get the boundary
	PosBeg = 1
	PosEnd = InstrB(PosBeg,RequestBin,getByteString(chr(13)))
	boundary = MidB(RequestBin,PosBeg,PosEnd-PosBeg)
	boundaryPos = InstrB(1,RequestBin,boundary)
	'Get all data inside the boundaries
	Do until (boundaryPos=InstrB(RequestBin,boundary & getByteString("--")))
		'Members variable of objects are put in a dictionary object
		Dim UploadControl
		Set UploadControl = CreateObject("Scripting.Dictionary")
		'Get an object name
		Pos = InstrB(BoundaryPos,RequestBin,getByteString("Content-Disposition"))
		Pos = InstrB(Pos,RequestBin,getByteString("name="))
		PosBeg = Pos+6
		PosEnd = InstrB(PosBeg,RequestBin,getByteString(chr(34)))
		Name = getString(MidB(RequestBin,PosBeg,PosEnd-PosBeg))
		PosFile = InstrB(BoundaryPos,RequestBin,getByteString("filename="))
		PosBound = InstrB(PosEnd,RequestBin,boundary)
		'Test if object is of file type
		If  PosFile<>0 AND (PosFile<PosBound) Then
			'Get Filename, content-type and content of file
			PosBeg = PosFile + 10
			PosEnd =  InstrB(PosBeg,RequestBin,getByteString(chr(34)))
			FileName = getString(MidB(RequestBin,PosBeg,PosEnd-PosBeg))
			'Add filename to dictionary object
			UploadControl.Add "FileName", FileName
			Pos = InstrB(PosEnd,RequestBin,getByteString("Content-Type:"))
			PosBeg = Pos+14
			PosEnd = InstrB(PosBeg,RequestBin,getByteString(chr(13)))
			'Add content-type to dictionary object
			ContentType = getString(MidB(RequestBin,PosBeg,PosEnd-PosBeg))
			UploadControl.Add "ContentType",ContentType
			'Get content of object
			PosBeg = PosEnd+4
			PosEnd = InstrB(PosBeg,RequestBin,boundary)-2
			Value = MidB(RequestBin,PosBeg,PosEnd-PosBeg)
			Else
			'Get content of object
			Pos = InstrB(Pos,RequestBin,getByteString(chr(13)))
			PosBeg = Pos+4
			PosEnd = InstrB(PosBeg,RequestBin,boundary)-2
			Value = getString(MidB(RequestBin,PosBeg,PosEnd-PosBeg))
		End If
		'Add content to dictionary object
	UploadControl.Add "Value" , Value	
		'Add dictionary object to main dictionary
	UploadRequest.Add name, UploadControl	
		'Loop to next object
		BoundaryPos=InstrB(BoundaryPos+LenB(boundary),RequestBin,boundary)
	Loop

End Sub

'String to byte string conversion
Function getByteString(StringStr)
 Dim i
 Dim char
 For i = 1 to Len(StringStr)
 	char = Mid(StringStr,i,1)
	getByteString = getByteString & chrB(AscB(char))
 Next
End Function

'Byte string to string conversion
Function getString(StringBin)
 Dim intcount

 getString =""
 For intCount = 1 to LenB(StringBin)
	getString = getString & chr(AscB(MidB(StringBin,intCount,1))) 
 Next
End Function

'-------------------------------------------------------------------------------------------
 server.ScriptTimeout = 99999
 byteCount = Request.TotalBytes
 RequestBin = Request.BinaryRead(byteCount)

 Set UploadRequest = CreateObject("Scripting.Dictionary")
 
 BuildUploadRequest RequestBin
%>