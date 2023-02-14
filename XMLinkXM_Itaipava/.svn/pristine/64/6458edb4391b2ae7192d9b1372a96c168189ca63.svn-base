

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsNivel
        Inherits BaseClass


#Region "Metodos"

        ''' <summary>
        ''' 	Função que retorna uma listagem completa de niveis
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_NIVEIS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Function GravarNiveisJustificativa(ByVal vIdJustificativa As Integer, ByVal vNiveis As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_JUSTIFICATIVA_NIVEIS"
            cmd.Parameters.Add("@IDJUSTIFICATIVA", SqlDbType.Int).Value = vIdJustificativa
            cmd.Parameters.Add("@IDNIVEIS", SqlDbType.VarChar).Value = vNiveis
            'cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function


#End Region


    End Class
End Namespace

