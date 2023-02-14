

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsParametros
		Inherits BaseClass

#Region "Declarations"
        Protected m_strNomeParametro As String
        Protected m_strValorParametro As String
        Protected m_blnIsNew As Boolean = True
#End Region


	#Region "Properties" 
		Public Overridable Property NomeParametro As String
			Get
				Return m_strNomeParametro
			End Get
			Set(ByVal Value As String)
				m_strNomeParametro = Value
			End Set
		End Property

		Public Overridable Property ValorParametro As String
			Get
				Return m_strValorParametro
			End Get
			Set(ByVal Value As String)
				m_strValorParametro = Value
			End Set
		End Property



		Public readonly property IsNew() as Boolean
			Get
				return m_blnIsNew
			End Get
		end Property
		
	#End Region  
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
		Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            If dr.IsDBNull(dr.GetOrdinal("ValorParametro")) Then
                m_strValorParametro = ""
            Else
                m_strValorParametro = dr.GetString(dr.GetOrdinal("ValorParametro"))
            End If
			m_blnIsNew = false
		End Sub

        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update(ByVal vParametro As String, ByVal vValor As String)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PARAMETROS"
            cmd.Parameters.Add("@NOMEPARAMETRO", SqlDbType.VarChar, 200).Value = vParametro
            cmd.Parameters.Add("@VALORPARAMETRO", SqlDbType.VarChar, 200).Value = vValor
            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                Else
                    Clear()
                End If
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try
        End Sub



        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Update(m_strNomeParametro, m_strValorParametro)
        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vParametro As String) As Boolean
            m_strNomeParametro = vParametro
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PARAMETROS"
            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                Else
                    Clear()
                End If
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_strValorParametro = ""
            m_blnIsNew = True
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PARAMETROS"

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Parametros' the following row: ", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PARAMETROS"
            cmd.CommandType = CommandType.StoredProcedure
            Return ExecuteCommand(cmd, vReturnType)

        End Function


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

#End Region

    End Class
End Namespace

