
Dim fso, MyFile, i, j
Set fso = CreateObject("Scripting.FileSystemObject")

for i = 1 to 10
	Set MyFile = fso.GetFile("D:\Desenvolvimento\XMLinkXM_Itaipava\imagens\fotos\" & i & ".jpg")
	for j = (i + 10) to 1000 step 10
		MyFile.Copy ("D:\Desenvolvimento\XMLinkXM_Itaipava\imagens\fotos\" & j & ".jpg")
	next
	Set MyFile = Nothing
next
Set fso = Nothing