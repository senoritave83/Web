Public Class clsTipo
    Inherits clsBaseClass

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
    End Sub

    Public Function Listar() As DataSet
        Return GetDataSet(PREFIXO & "LS_TIPO " & XMPage.IDEmpresa)
    End Function
End Class
