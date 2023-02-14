

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsTipoJustificativa
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDTipoJustificativa As Integer
		Protected m_strTipoJustificativa As String
		Protected m_strCriado As String
        Protected m_blnAbono As Boolean
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDTipoJustificativa As Integer
			Get
				Return m_intIDTipoJustificativa
			End Get
		End Property

		Public Overridable Property TipoJustificativa As String
			Get
				Return m_strTipoJustificativa
			End Get
			Set(ByVal Value As String)
				m_strTipoJustificativa = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

        Public Overridable Property Abono() As Boolean
            Get
                Return m_blnAbono
            End Get
            Set(ByVal value As Boolean)
                m_blnAbono = value
            End Set
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDTipoJustificativa = 0
            End Get
        End Property

#End Region
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDTipoJustificativa = dr.GetInt32(dr.GetOrdinal("IDTipoJustificativa"))
            If dr.IsDBNull(dr.GetOrdinal("TipoJustificativa")) Then
                m_strTipoJustificativa = ""
            Else
                m_strTipoJustificativa = dr.GetString(dr.GetOrdinal("TipoJustificativa"))
            End If
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            If dr.IsDBNull(dr.GetOrdinal("Abono")) Then
                m_blnAbono = False
            Else
                m_blnAbono = IIf(dr.GetByte(dr.GetOrdinal("Abono")) = 1, True, False)
            End If

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_TIPOJUSTIFICATIVA"
            cmd.Parameters.Add("@IDTIPOJUSTIFICATIVA", SqlDbType.Int).Value = m_intIDTipoJustificativa
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@TIPOJUSTIFICATIVA", SqlDbType.VarChar, 50).Value = m_strTipoJustificativa
            cmd.Parameters.Add("@ABONO", SqlDbType.TinyInt).Value = IIf(m_blnAbono = True, 1, 0)
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

            Me.User.Log("Cadastro de Tipos de Justificativa", "Gravar - IDTIPOJUSTIFICATIVA=" & m_intIDTipoJustificativa & " TIPOJUSTIFICATIVA=" & m_strTipoJustificativa & " ABONO=" & m_blnAbono)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDTipoJustificativa">Chave primaria IDTipoJustificativa</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDTipoJustificativa As Integer) As Boolean

                If vIDTipoJustificativa = 0 Then
                    Clear()
                    Return False
                End If

                Dim cmd As New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_TIPOJUSTIFICATIVA"
                cmd.Parameters.Add("@IDTIPOJUSTIFICATIVA", SqlDbType.Int).Value = vIDTipoJustificativa
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

            Me.User.Log("Cadastro de Tipos de Justificativa", "Visualizar - IDTIPOJUSTIFICATIVA=" & vIDTipoJustificativa)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDTipoJustificativa = 0
            m_strTipoJustificativa = ""
            m_strCriado = ""
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_TIPOJUSTIFICATIVA"
            cmd.Parameters.Add("@IDTIPOJUSTIFICATIVA", SqlDbType.Int).Value = m_intIDTipoJustificativa
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Tipos de Justificativa", "Apagar - IDTIPOJUSTIFICATIVA=" & m_intIDTipoJustificativa)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'TipoJustificativa' the following row:  IDTipoJustificativa=" & m_intIDTipoJustificativa & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)

            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_TIPOJUSTIFICATIVAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>

        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_TIPOJUSTIFICATIVAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            Return blnValid
        End Function

#End Region

    End Class
End Namespace

