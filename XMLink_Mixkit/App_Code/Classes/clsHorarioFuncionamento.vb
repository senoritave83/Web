

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics


Namespace Classes

	Public Class clsHorarioFuncionamento
		Inherits BaseClass

#Region "Metodos"

        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Inserir(ByVal vHorario As String, ByVal vInicio As Short, ByVal vFinal As Short)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_HORARIOFUNCIONAMENTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@HORARIO", SqlDbType.VarChar, 50).Value = vHorario
            cmd.Parameters.Add("@HORARIOINICIAL", SqlDbType.SmallInt).Value = vInicio
            cmd.Parameters.Add("@HORARIOFINAL", SqlDbType.SmallInt).Value = vFinal
            ExecuteNonQuery(cmd)
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete(ByVal vIDHorarioFuncionamento As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_HORARIOFUNCIONAMENTO"
            cmd.Parameters.Add("@IDHORARIOFUNCIONAMENTO", SqlDbType.Int).Value = vIDHorarioFuncionamento
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'HorarioFuncionamento' the following row:  IDHorarioFuncionamento=" & vIDHorarioFuncionamento & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_HORARIOFUNCIONAMENTOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            Return blnValid
        End Function

#End Region



	End Class
End Namespace

