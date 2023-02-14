Public Class clsRecados
    Inherits clsBaseClass

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
    End Sub

    Public Function Listar(ByVal vOrder As String, ByVal vPage As Integer, ByVal vPageSize As Integer) As DataSet
        Return GetDataSet(PREFIXO & "LS_RECADOS_DIGITAIS " & XMPage.IDEmpresa & ", '" & vOrder.Replace("'", "''") & "', " & vPage & ", " & vPageSize)
    End Function

    Public Function ListarEmails(ByVal vGrupo As Boolean, ByVal vID As Integer) As DataSet
        Return GetDataSet(PREFIXO & "LS_CLIENTES_EMAILS " & XMPage.IDEmpresa & ", " & IIf(vGrupo, 1, 0) & ", " & vID & "")
    End Function

    Public Function Enviar(ByVal vGrupo As Boolean, ByVal vID As Integer, ByVal vMensagem As String) As Boolean
        ExecuteNonQuery(PREFIXO & "IN_RECADO_DIGITAL " & XMPage.IDEmpresa & ", " & IIf(vGrupo, 1, 0) & ", " & vID & ", '" & vMensagem.Replace("'", "''") & "', " & XMPage.Usuario.IDUsuario)
        Enviar = True
    End Function

    Public Function Destinatarios() As DataSet
        Return GetDataSet(PREFIXO & "LS_DESTINATARIOS_RECADO " & XMPage.IDEmpresa)
    End Function

End Class
