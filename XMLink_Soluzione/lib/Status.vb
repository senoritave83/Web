Public Class clsStatus
    Inherits clsBaseClass

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
    End Sub

    Public Function Listar() As DataSet
        Return GetDataSet(PREFIXO & "LS_STATUS " & XMPage.IDEmpresa)
    End Function

End Class
