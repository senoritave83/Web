

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsConfig
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_varPerformance As Decimal
        Protected m_varExibirPreco As Integer
        Protected m_varCodigoBarras As Integer
	#End Region  


	#Region "Properties" 
		Public Overridable Property Performance As Decimal
			Get
				Return m_varPerformance
			End Get
			Set(ByVal Value As Decimal)
				m_varPerformance = Value
			End Set
        End Property

        Public Overridable Property ExibirPreco As Integer
            Get
                Return m_varExibirPreco
            End Get
            Set(ByVal Value As Integer)
                m_varExibirPreco = Value
            End Set
        End Property



        Public Overridable Property ExibirCodigoBarras As Integer
            Get
                Return m_varCodigoBarras
            End Get
            Set(ByVal Value As Integer)
                m_varCodigoBarras = Value
            End Set
        End Property


        Public ReadOnly Property isNew() As Boolean
            Get
                Return False
            End Get
        End Property

#End Region

    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_varPerformance = dr.GetDecimal(dr.GetOrdinal("Performance"))
            m_varExibirPreco = dr.GetInt32(dr.GetOrdinal("ExibirPreco"))
            m_varCodigoBarras = dr.GetInt32(dr.GetOrdinal("ExibirCodigoBarras"))

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_CONFIG"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@PERFORMANCE", SqlDbType.Decimal).Value = m_varPerformance
            cmd.Parameters.Add("@EXIBIR_PRECO", SqlDbType.Int).Value = m_varExibirPreco
            cmd.Parameters.Add("@EXIBIR_CODIGOBARRAS", SqlDbType.Int).Value = m_varCodigoBarras
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

            Me.User.Log("Config", "Update - PERFORMANCE=" & m_varPerformance)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        Public Sub New()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CONFIG"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

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
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_varPerformance = Nothing
        End Sub



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_varPerformance > 100 Then
                AddBrokenRule("A meta de performance não pode ser superior a 100%")
                blnValid = False
            End If
            If m_varPerformance < 0 Then
                AddBrokenRule("A meta de performance não pode ser inferior a 0%")
                blnValid = False
            End If
            Return blnValid
        End Function

#End Region



    End Class
End Namespace

