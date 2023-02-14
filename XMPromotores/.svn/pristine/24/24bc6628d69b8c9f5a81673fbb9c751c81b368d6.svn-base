

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsLOG
		Inherits BaseClass



	#Region "Declarations" 
        Protected m_strUsuario As String
		Protected m_strModulo As String
		Protected m_strSecao As String
		Protected m_strAcao As String
		Protected m_strData As String

	#End Region  


	#Region "Properties" 

        Public Overridable Property Modulo As String
            Get
                Return m_strModulo
            End Get
            Set(ByVal Value As String)
                m_strModulo = Value
            End Set
        End Property

        Public Overridable Property Secao As String
            Get
                Return m_strSecao
            End Get
            Set(ByVal Value As String)
                m_strSecao = Value
            End Set
        End Property

        Public Overridable Property Acao As String
            Get
                Return m_strAcao
            End Get
            Set(ByVal Value As String)
                m_strAcao = Value
            End Set
        End Property

        Public Overridable Property Data As String
            Get
                Return _getDateTimePropertyValue(m_strData)
            End Get
            Set(ByVal Value As String)
                m_strData = _setDateTimePropertyValue(Value)
            End Set
        End Property

        Public Overridable Property Usuario() As String
            Get
                Return m_strUsuario
            End Get
            Set(ByVal value As String)
                m_strUsuario = value
            End Set
        End Property




#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_strUsuario = dr.GetString(dr.GetOrdinal("Usuario"))
            m_strModulo = dr.GetString(dr.GetOrdinal("Modulo"))
            m_strSecao = dr.GetString(dr.GetOrdinal("Secao"))
            m_strAcao = dr.GetString(dr.GetOrdinal("Acao"))
            m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))

        End Sub




        '      ''' <summary>
        '      ''' 	Função que grava os dados do registro atual
        '      ''' </summary>
        'Public Sub Update()
        '		Dim cmd As New SqlCommand()
        '		cmd.CommandType = CommandType.StoredProcedure
        '		cmd.CommandText = PREFIXO & "SV_LOG"
        '		cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
        '		cmd.Parameters.Add("@USER", SqlDbType.VarChar, 100).value = m_strUser
        '		cmd.Parameters.Add("@MODULO", SqlDbType.VarChar, 20).value = m_strModulo
        '		cmd.Parameters.Add("@SECAO", SqlDbType.VarChar, 255).value = m_strSecao
        '		cmd.Parameters.Add("@ACAO", SqlDbType.VarChar, 2000).value = m_strAcao
        '		cmd.Parameters.Add("@DATA", SqlDbType.DateTime).value = _setDateTimeDBValue(m_strData)

        '	Dim dr As IDataReader = ExecuteReader(cmd)
        '	try
        '		If dr.Read Then
        '			Inflate(dr)
        '		Else
        '			Clear()
        '		End If
        '	finally
        '		If (Not dr Is Nothing) Then
        '			dr.Close()
        '			dr = Nothing
        '		End If
        '	end try
        'End Sub


        '      ''' <summary>
        '      ''' 	Função que obtem os dados do registro solicitado 
        '      ''' </summary>
        'Public Sub New()


        '		Dim cmd As New SqlCommand()
        '		cmd.CommandType = CommandType.StoredProcedure
        '		cmd.CommandText = PREFIXO & "SE_LOG"
        '          cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

        '          Dim dr As IDataReader = ExecuteReader(cmd)
        '	try
        '		If dr.Read Then
        '			Inflate(dr)
        '		Else
        '			Clear()
        '		End If
        '	finally
        '		If (Not dr Is Nothing) Then
        '			dr.Close()
        '			dr = Nothing
        '		End If
        '	end try
        '      End Sub



        Public Sub Load()
            'If vIDEmpresa = 0 Then
            '    Clear()
            '    Return False
            'End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_LOG"
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
            m_strUsuario = ""
            m_strModulo = ""
            m_strSecao = ""
            m_strAcao = ""
            m_strData = ""
        End Sub
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_LOGS"
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vModulo">Modulo a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenção utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>

        Public Function Listar(ByVal vModulo As String, ByVal vUsuario As String, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_LOGS"
            cmd.Parameters.Add("@MODULO", SqlDbType.VarChar, 100).Value = vModulo
            cmd.Parameters.Add("@USUARIO", SqlDbType.VarChar, 100).Value = vUsuario
            If vDataInicial <> "" Then
                cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
            Else
                vDataInicial = vbNullString
                cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = vDataInicial
            End If
            If vDataFinal <> "" Then
                cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)
            Else
                vDataFinal = vbNullString
                cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = vDataFinal
            End If
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        'Protected Overrides Function CheckIfSubClassIsValid() as Boolean
        '	Dim blnValid as Boolean = true

        '	return blnValid
        'end Function

#End Region



    End Class
End Namespace

