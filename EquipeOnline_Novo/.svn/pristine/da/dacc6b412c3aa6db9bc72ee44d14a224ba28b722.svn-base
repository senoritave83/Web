Imports System.Collections.Generic

Public Class clsLista
    Inherits List(Of Integer)

    Public Function GetLista() As String
        Dim strLista As String = ""
        For Each i As Integer In Me
            If strLista <> "" Then
                strLista &= ","
            End If
            strLista &= i.ToString
        Next
        Return strLista
    End Function

End Class