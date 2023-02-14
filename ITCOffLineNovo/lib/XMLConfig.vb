Imports System.Xml

Public Class XMLConfig

    Private strFileName As String
    Sub New(ByVal vFileName As String)
        strFileName = vFileName
    End Sub

    Sub New()
        strFileName = ""
    End Sub

    Private Function AddNodes(ByRef domConfig As XmlDocument, ByVal vXPath As String) As XmlNode
        Dim nd1, nd2 As XmlNode
        Dim el, el1 As XmlElement
        Dim vNodes() As String
        Dim strPath As String
        Try
            vNodes = Split(vXPath, "/")
            Dim i As Integer
            el = domConfig.DocumentElement
            nd2 = el
            For i = LBound(vNodes) + 1 To UBound(vNodes)
                strPath += "/" & vNodes(i)
                nd1 = el.SelectSingleNode(strPath)
                If nd1 Is Nothing Then
                    el1 = domConfig.CreateElement(vNodes(i))
                    nd1 = nd2.AppendChild(el1)
                End If
                nd2 = nd1
            Next
        Catch e As XmlException
            System.Diagnostics.EventLog.WriteEntry("XMLConfig", e.Message)
        Catch e As Exception
            System.Diagnostics.EventLog.WriteEntry("XMLConfig", e.Message)
        End Try
        Return nd2
    End Function

    Public Sub SaveValue(ByVal vKey As String, ByVal vValue As String, Optional ByVal Criptograph As Boolean = False)

        If strFileName = "" Then
            Throw New ApplicationException("O XMLConfig foi aberto como somente leitura!")
            Exit Sub
        End If

        Dim domConfig As XmlDocument
        domConfig = New XmlDocument()
        domConfig.Load(strFileName)
        Dim nd As XmlNode
        Try
            nd = domConfig.SelectSingleNode("/configuration/appSettings")
        Catch e As Exception
            nd = Nothing
        End Try
        If nd Is Nothing Then
            nd = AddNodes(domConfig, "/configuration/appSettings")
        End If
        Dim ndAdd As XmlNode
        Dim blnFound As Boolean = False
        Dim ndAtt As XmlAttribute
        For Each ndAdd In nd.ChildNodes
            If ndAdd.Attributes("key").Value = vKey Then
                blnFound = True
                If Criptograph Then
                    ndAdd.Attributes("value").Value = WriteData(vValue)
                Else
                    ndAdd.Attributes("value").Value = vValue
                End If
                Exit For
            End If
        Next
        If blnFound = False Then
            Dim el As XmlElement
            el = domConfig.CreateElement("add")
            ndAdd = el
            ndAtt = domConfig.CreateAttribute("key")
            ndAtt.Value = vKey
            ndAdd.Attributes.Append(ndAtt)
            ndAtt = domConfig.CreateAttribute("value")
            If Criptograph Then
                ndAtt.Value = WriteData(vValue)
            Else
                ndAtt.Value = vValue
            End If
            ndAdd.Attributes.Append(ndAtt)
        End If
        nd.AppendChild(ndAdd)
        domConfig.Save(strFileName)
    End Sub

    Public Function GetValue(ByVal vKey As String, ByVal vDefault As String, Optional ByVal Criptograph As Boolean = False) As String
        Dim cfg As New System.Configuration.AppSettingsReader()
        Try
            If Criptograph Then
                Return ReadData(cfg.GetValue(vKey, GetType(System.String)))
            Else
                Return cfg.GetValue(vKey, GetType(System.String))
            End If
        Catch e As Exception
            Return vDefault
        End Try
        cfg = Nothing
    End Function


    Private Function ReadData(ByVal vData As String) As String
        ReadData = Criptografar(HexToString(vData))

    End Function

    Private Function WriteData(ByVal vData As String) As String

        WriteData = StringToHex(Criptografar(vData))

    End Function


    Private Function Criptografar(ByVal inp As String) As String
        Dim key As String
        key = System.Environment.MachineName().ToString
        key += "_" + System.Environment.OSVersion.Platform().ToString
        key += "_" + System.Environment.OSVersion.Version().ToString

        Dim S(255) As Byte, K(255) As Byte, i As Long
        Dim j As Long, Temp As Byte, Y As Byte, t As Long, x As Long
        Dim Outp As String

        For i = 0 To 255
            S(i) = i
        Next

        j = 1
        For i = 0 To 255
            If j > Len(key) Then j = 1
            K(i) = Asc(Mid(key, j, 1))
            j = j + 1
        Next i

        j = 0
        For i = 0 To 255
            j = (j + S(i) + K(i)) Mod 256
            Temp = S(i)
            S(i) = S(j)
            S(j) = Temp
        Next i

        i = 0
        j = 0
        For x = 1 To Len(inp)
            i = (i + 1) Mod 256
            j = (j + S(i)) Mod 256
            Temp = S(i)
            S(i) = S(j)
            S(j) = Temp
            t = (S(i) + (S(j) Mod 256)) Mod 256
            Y = S(t)

            Outp = Outp & Chr(Asc(Mid(inp, x, 1)) Xor Y)
        Next
        Criptografar = Outp
    End Function


    Private Function StringToHex(ByVal sourcestring As String) As String
        Dim x As Long
        Dim S As String
        Dim h As String
        For x = 1 To Len(sourcestring)
            h = Hex$(Asc(Mid$(sourcestring, x, 1)))
            If Len(h) = 1 Then h = "0" & h
            S = S & h
        Next x
        StringToHex = S
    End Function


    Private Function HexToString(ByVal HexString As String) As String
        Dim x As Long
        Dim S As String
        Dim h As Integer
        For x = 1 To Len(HexString) Step 2
            h = Val("&h" & (Mid$(HexString, x, 2)))
            If Len(h) = 1 Then h = "0" & h
            S = S & Chr(h)
        Next x
        HexToString = S
    End Function




End Class
