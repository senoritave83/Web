

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsVisitaProduto
		Inherits BaseClass

#Region "Declarations"
        Protected m_intIDVisita As Integer
        Protected m_intIDProduto As Integer
        Protected m_intIDJustificativaRuptura As Integer
        Protected m_strProduto As String
        Protected m_strJustificativaRuptura As String
        Protected m_blnEncontrado As Boolean
        Protected m_varPreco As Decimal
        Protected m_intVisualizouEstoque As enVizualizou
        Protected m_intEstoque As Integer
        Protected m_strData As String
        Protected m_blnPesquisado As Boolean 'StatusPesquisa
        Protected m_blnPerguntasRespondidas As Boolean 'StatusPergunta


        Public Enum enVizualizou As Byte
            Nao = 0
            Sim = 1
            NaoPermitido = 2
        End Enum

        Public Enum enFiltroPesquisada As Byte
            ProdutosPesquisados = 1
            ProdutosNaoPesquisados = 0
            TodosProdutos = 2
        End Enum


#End Region



	#Region "Properties" 
        Public Overridable ReadOnly Property IDVisita As Integer
            Get
                Return m_intIDVisita
            End Get
        End Property

		Public Overridable ReadOnly Property IDProduto As Integer
			Get
				Return m_intIDProduto
			End Get
        End Property

        Public Overridable ReadOnly Property IDJustificativaRuptura As Integer
            Get
                Return m_intIDJustificativaRuptura
            End Get
        End Property

        Public Overridable ReadOnly Property Produto() As String
            Get
                Return m_strProduto
            End Get
        End Property

        Public Overridable ReadOnly Property JustificativaRuptura() As String
            Get
                Return m_strJustificativaRuptura
            End Get
        End Property

        Public Overridable Property Encontrado() As Boolean
            Get
                Return m_blnEncontrado
            End Get
            Set(ByVal Value As Boolean)
                m_blnEncontrado = Value
            End Set
        End Property

		Public Overridable Property Preco As Decimal
			Get
				Return m_varPreco
			End Get
			Set(ByVal Value As Decimal)
				m_varPreco = Value
			End Set
		End Property

        Public Overridable Property VisualizouEstoque() As enVizualizou
            Get
                Return m_intVisualizouEstoque
            End Get
            Set(ByVal Value As enVizualizou)
                m_intVisualizouEstoque = Value
            End Set
        End Property

		Public Overridable Property Estoque As Integer
			Get
				Return m_intEstoque
			End Get
			Set(ByVal Value As Integer)
				m_intEstoque = Value
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

        Public Property Pesquisado() As Boolean
            Get
                Return m_blnPesquisado
            End Get
            Set(ByVal value As Boolean)
                m_blnPesquisado = value
            End Set
        End Property

      
	#End Region  
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDVisita = dr.GetInt32(dr.GetOrdinal("IDVisita"))
            m_intIDProduto = dr.GetInt32(dr.GetOrdinal("IDProduto"))
            m_intIDJustificativaRuptura = dr.GetInt32(dr.GetOrdinal("IDJustificativaRuptura"))
            If dr.IsDBNull(dr.GetOrdinal("Produto")) Then
                m_strProduto = ""
            Else
                m_strProduto = dr.GetString(dr.GetOrdinal("Produto"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("JustificativaRuptura")) Then
                m_strJustificativaRuptura = ""
            Else
                m_strJustificativaRuptura = dr.GetString(dr.GetOrdinal("JustificativaRuptura"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Encontrado")) Then
                m_blnEncontrado = False
            Else
                m_blnEncontrado = dr.GetBoolean(dr.GetOrdinal("Encontrado"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Preco")) Then
                m_varPreco = Nothing
            Else
                m_varPreco = dr.GetDecimal(dr.GetOrdinal("Preco"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("VisualizouEstoque")) Then
                m_intVisualizouEstoque = enVizualizou.Nao
            Else
                m_intVisualizouEstoque = dr.GetByte(dr.GetOrdinal("VisualizouEstoque"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Estoque")) Then
                m_intEstoque = 0
            Else
                m_intEstoque = dr.GetInt32(dr.GetOrdinal("Estoque"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Pesquisado")) Then
                m_blnPesquisado = False
            Else
                m_blnPesquisado = dr.GetBoolean(dr.GetOrdinal("Pesquisado"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("PerguntasRespondidas")) Then
                m_blnPerguntasRespondidas = False
            Else
                m_blnPerguntasRespondidas = dr.GetBoolean(dr.GetOrdinal("PerguntasRespondidas"))
            End If
            m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_VISITAPRODUTO"
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            cmd.Parameters.Add("@ENCONTRADO", SqlDbType.Bit).Value = m_blnEncontrado
            cmd.Parameters.Add("@PRECO", SqlDbType.Money).Value = m_varPreco
            cmd.Parameters.Add("@VISUALIZOUESTOQUE", SqlDbType.TinyInt).Value = m_intVisualizouEstoque
            cmd.Parameters.Add("@ESTOQUE", SqlDbType.Int).Value = m_intEstoque
            cmd.Parameters.Add("@PESQUISADO", SqlDbType.Bit).Value = m_blnPesquisado

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

            Me.User.Log("Produtos da Visita", "Gravar - IDVISITA=" & m_intIDVisita & " IDPRODUTO=" & m_intIDProduto & " ENCONTRADO=" & m_blnEncontrado & " PRECO=" & _
                        m_varPreco & " VISUALIZOUESTOQUE=" & m_intVisualizouEstoque & " ESTOQUE=" & m_intEstoque & " PESQUISADO=" & m_blnPesquisado)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDVisita">Chave primaria IDVisita</param>
        ''' <param name="vIDProduto">Chave primaria IDProduto</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDVisita As Integer, ByVal vIDProduto As Integer) As Boolean

            If vIDVisita = 0 And vIDProduto = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_VISITAPRODUTO"
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto

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

            Me.User.Log("Produtos da Visita", "Visualizar - IDVISITA=" & vIDVisita & " IDPRODUTO=" & vIDProduto)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDVisita = 0
            m_intIDProduto = 0
            m_intIDJustificativaRuptura = 0
            m_blnEncontrado = False
            m_varPreco = Nothing
            m_intVisualizouEstoque = enVizualizou.Nao
            m_intEstoque = 0
            m_strData = ""
            m_strProduto = ""
            m_strJustificativaRuptura = ""
            m_blnPesquisado = False
            m_blnPerguntasRespondidas = False

        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_VISITAPRODUTO"
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto

            ExecuteNonQuery(cmd)

            Me.User.Log("Produtos da Visita", "Apagar - IDVISITA=" & m_intIDVisita & " IDPRODUTO=" & m_intIDProduto)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'VisitaProduto' the following row:  IDVisita=" & m_intIDVisita & " IDEmpresa=" & User.IDEmpresa & " IDProduto=" & m_intIDProduto & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDVisita As Integer, ByVal vFiltroPesquisa As enFiltroPesquisada, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_VISITAPRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita
            cmd.Parameters.Add("@FILTRARPOR", SqlDbType.TinyInt).Value = vFiltroPesquisa

            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDVisita">Filtro</param>
        ''' <param name="vFiltroPesquisa">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vIDVisita As Integer, ByVal vFiltroPesquisa As enFiltroPesquisada, ByVal vFilter As String, ByVal p_Segmento As Integer, ByVal p_Categoria As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_VISITAPRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita
            cmd.Parameters.Add("@FILTRARPOR", SqlDbType.TinyInt).Value = vFiltroPesquisa
            cmd.Parameters.Add("@SEGMENTO", SqlDbType.Int).Value = p_Segmento
            cmd.Parameters.Add("@CATEGORIA", SqlDbType.Int).Value = p_Categoria
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


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function ListarPerguntasProduto(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_VISITAPRODUTORESPOSTAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        Public Function ListarPerguntas() As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_VISITA_PRODUTO_PERGUNTA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Sub LimparRespostas(ByVal vIDPergunta As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PERGUNTARESPOSTAS_PRODUTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta
            MyBase.ExecuteNonQuery(cmd)

            Me.User.Log("Produtos da Visita", "LimparRespostas - IDVISITA=" & m_intIDVisita & " IDPRODUTO=" & m_intIDProduto & " IDPERGUNTA=" & vIDPergunta)

        End Sub


        Public Sub AdicionarRespostas(ByVal vIDPergunta As Integer, ByVal vRespostas() As String)

            LimparRespostas(vIDPergunta)

            Dim cmd As New SqlCommand()
            Dim cn As SqlConnection = GetDBConnection()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PERGUNTA_RESPOSTA_PRODUTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta
            Dim prm As SqlParameter = cmd.Parameters.Add("@RESPOSTA", SqlDbType.VarChar)
            cn.Open()
            Try

                For Each strResposta As String In vRespostas
                    prm.Value = strResposta
                    cmd.ExecuteNonQuery()
                Next

            Finally
                cn.Close()
            End Try

            Me.User.Log("Produtos da Visita", "AdicionarRespostas - IDVISITA=" & m_intIDVisita & " IDPRODUTO=" & m_intIDProduto & " IDPERGUNTA=" & vIDPergunta)

        End Sub

        Public Function ListarRespostas(ByVal vIDPergunta As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PERGUNTA_PRODUTO_RESPOSTAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

#End Region



    End Class
End Namespace

