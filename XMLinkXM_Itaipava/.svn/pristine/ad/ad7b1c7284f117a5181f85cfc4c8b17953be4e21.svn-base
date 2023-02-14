

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsRoteiro
		Inherits BaseClass



	#Region "Declarations" 
        Protected m_strData As String
		Protected m_indDia As Byte
		Protected m_strCriado As String
		Protected m_intIDResponsavel As Integer
        Protected m_strResponsavel As String
        Protected m_intIDVendedor As Integer
        Protected m_strVendedor As String
        Protected m_blnIsNew As Boolean = True
	#End Region  


	#Region "Properties" 

        Public ReadOnly Property Data() As String
            Get
                Return _getDatePropertyValue(m_strData)
            End Get
        End Property

        Public Overridable Property Dia() As Byte
            Get
                Return m_indDia
            End Get
            Set(ByVal Value As Byte)
                m_indDia = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Criado() As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
        End Property

        Public ReadOnly Property IDResponsavel() As Integer
            Get
                Return m_intIDResponsavel
            End Get
        End Property

        Public ReadOnly Property Responsavel() As String
            Get
                Return m_strResponsavel
            End Get
        End Property

        Public Property IDVendedor() As Integer
            Get
                Return m_intIDVendedor
            End Get
            Set(value As Integer)
                m_intIDVendedor = value
            End Set
        End Property

        Public ReadOnly Property Vendedor() As String
            Get
                Return m_strVendedor
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
            m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))
            m_indDia = dr.GetByte(dr.GetOrdinal("Dia"))
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            m_intIDResponsavel = dr.GetInt32(dr.GetOrdinal("IDResponsavel"))
            m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
            m_blnIsNew = False
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_ROTEIRO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strData)
            cmd.Parameters.Add("@DIA", SqlDbType.TinyInt).Value = m_indDia
            cmd.Parameters.Add("@IDRESPONSAVEL", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = m_intIDVendedor
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
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vData As String, ByVal vIdVendedor As Integer) As Boolean
            Dim blnReturn As Boolean = False
            m_strData = _setDateTimePropertyValue(vData)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_ROTEIRO"
            cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strData)
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                    blnReturn = True
                Else
                    Clear()
                End If
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try
            Return blnReturn
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_indDia = 0
            m_strCriado = ""
            m_intIDResponsavel = 0
            m_intIDVendedor = 0
            m_blnIsNew = True
        End Sub

        ''' <summary>
        ''' 	Função que inativa o roteiro
        ''' </summary>
        ''' <param name="vIdRoteiro">Id do Roteiro que deve ser excluir (inativado) (Integer)</param>		
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        Public Sub Delete(ByVal vIdRoteiro As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader)

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "DE_ROTEIRO"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IdRoteiro", SqlDbType.Int).Value = vIdRoteiro
            ExecuteNonQuery(cmd)

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ROTEIROS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vDataInicial">Filtro</param>
        ''' <param name="vDataFinal">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_ROTEIROS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            If vDataInicial <> "" Then
                cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
            End If
            If vDataFinal <> "" Then
                cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)
            End If
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

