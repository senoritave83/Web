    Public Class clsSomarizador

        Private col As New Collections.Specialized.NameValueCollection

        Public Sub Add(ByVal value As Integer, ByVal key As String)
            Dim intTemp As Integer = value
            intTemp += CInt(col.Item(key))
            col.Item(key) = intTemp
        End Sub

        Public Function Total(ByVal key As String) As String
            If col.Item(key) Is Nothing Then
                Return ""
            End If
            Return col.Item(key)
        End Function

    End Class

