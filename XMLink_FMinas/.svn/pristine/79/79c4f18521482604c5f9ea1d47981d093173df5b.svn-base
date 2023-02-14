

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsRegra
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDResponsavel As Integer
        Protected m_strData As String
        Protected m_strResponsavel As String
		Protected m_sngDescontoMax As Single
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
        Public ReadOnly Property IDResponsavel() As Integer
            Get
                Return m_intIDResponsavel
            End Get
        End Property

        Public ReadOnly Property Data() As String
            Get
                Return _getDateTimePropertyValue(m_strData)
            End Get
        End Property

		Public Overridable Property DescontoMax As Single
			Get
				Return m_sngDescontoMax
			End Get
			Set(ByVal Value As Single)
				m_sngDescontoMax = Value
			End Set
		End Property


        Public ReadOnly Property Responsavel() As String
            Get
                Return m_strResponsavel
            End Get
        End Property

        Public ReadOnly Property IsNew() As Boolean
            Get
                Return m_blnIsNew
            End Get
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDResponsavel = dr.GetInt32(dr.GetOrdinal("IDResponsavel"))
            m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))
            m_sngDescontoMax = dr.GetFloat(dr.GetOrdinal("DescontoMax"))
            m_strResponsavel = dr.GetString(dr.GetOrdinal("Responsavel"))
            m_blnIsNew = False
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_REGRA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDRESPONSAVEL", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@DESCONTOMAX", SqlDbType.Real).Value = m_sngDescontoMax
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
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        Public Sub New()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_REGRA"
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
            m_intIDResponsavel = 0
            m_strData = ""
            m_sngDescontoMax = 10
            m_blnIsNew = True
        End Sub



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

#End Region

    End Class
End Namespace

