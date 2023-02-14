Imports System
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class Util
    Inherits DataClass

    Public Sub SendEmailConfirmacao(ByVal Msg_IdEmpresa As Integer, ByVal Msg_Usuario As String, ByVal Msg_Subject As String, ByVal Msg_To As String, ByVal Msg_From As String, ByVal Msg_Body As String)

        Dim dt As New DataClass
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "IN_INSERE_EMAIL_CONFIRMACAO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Msg_IdEmpresa
        cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 100).Value = Msg_Usuario
        cmd.Parameters.Add("@FROM", SqlDbType.VarChar, 255).Value = Msg_From
        cmd.Parameters.Add("@TO", SqlDbType.VarChar, 255).Value = Msg_To
        cmd.Parameters.Add("@SUBJECT", SqlDbType.VarChar, 300).Value = Msg_Subject
        cmd.Parameters.Add("@BODY", SqlDbType.Text).Value = Msg_Body
        ExecuteNonQuery(cmd)

    End Sub

End Class
