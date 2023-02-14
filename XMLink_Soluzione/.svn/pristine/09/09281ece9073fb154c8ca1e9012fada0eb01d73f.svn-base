Public Class clsAjuda
    Inherits clsBaseClass

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
    End Sub

    Public Function ListarTopics(ByVal vFiltro As String) As DataSet
        Return GetDataSet(PREFIXO & "LS_PROCURA_AJUDA '" & vFiltro.Replace("'", "''") & "'")
    End Function

    Public Function GetHTML(ByVal vIDTopico As Integer) As String
        Try
            Return GetDataSet(PREFIXO & "SE_AJUDA " & vIDTopico & ", " & xmpage.IDEmpresa).Tables(0).Rows.Item(0).Item(0)
        Catch
            Return ""
        End Try
    End Function

End Class
