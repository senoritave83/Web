Imports System.Data.SqlClient

Public Class clsRecados
    Inherits DataClass


    Public Function Listar(ByVal vOrder As String, ByVal vPage As Integer, ByVal vPageSize As Integer) As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_RECADOS_DIGITAIS"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 50).Value = vOrder
        cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
        cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

        Return ExecuteReader(cmd)

    End Function

    Public Function Enviar(ByVal vGrupo As Boolean, ByVal vID As Integer, ByVal vMensagem As String) As Boolean
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "IN_RECADO_DIGITAL"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@GRUPO", SqlDbType.Int).Value = IIf(vGrupo, 1, 0)
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = vID
        cmd.Parameters.Add("@MENSAGEM", SqlDbType.VarChar, 120).Value = vMensagem
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = Identity.IDUsuario
        ExecuteNonQuery(cmd)
        Return True
    End Function

    Public Function Destinatarios() As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_DESTINATARIOS_RECADO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = Identity.IDEmpresa
        Return ExecuteReader(cmd)
    End Function

    Public Function DestinatariosRecado() As IDataReader
        Return Destinatarios()
    End Function

End Class
