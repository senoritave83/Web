

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsPergunta
        Inherits BaseClass

#Region "Declarations"
        Protected m_intIDPergunta As Integer
        Protected m_strCodigo As String
        Protected m_strPergunta As String
        Protected m_strDescricaoPergunta As String
        Protected m_intPrioridade As Integer
        Protected m_varMultiResposta As Boolean
        Protected m_indTipoCampo As Byte
        Protected m_intPerguntaLoja As Byte
        Protected m_blnAtivo As Boolean
        Protected m_dcmMinimo As Decimal
        Protected m_dcmMaximo As Decimal
        Protected m_indTipoDependencia As Byte
        Protected m_intIDDependente As Integer
        Protected m_strDependenteValor As String
        Protected m_colRespostas As clsPerguntaRespostaCollection

        Public Enum enTipoDependencia As Byte
            Nenhum = 0
            Igual = 1
            Diferente = 2
        End Enum

        Public Enum enTipoPergunta As Byte
            Loja = 1
            Amostra = 2
            Categoria = 4
            SubCategoria = 8
            Produto = 16
        End Enum

#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDPergunta() As Integer
            Get
                Return m_intIDPergunta
            End Get
        End Property

        Public Overridable Property Codigo() As String
            Get
                Return m_strCodigo
            End Get
            Set(ByVal Value As String)
                m_strCodigo = Value
            End Set
        End Property

        Public Overridable Property Pergunta() As String
            Get
                Return m_strPergunta
            End Get
            Set(ByVal Value As String)
                m_strPergunta = Value
            End Set
        End Property

        Public Overridable Property DescricaoRelatorio() As String
            Get
                Return m_strDescricaoPergunta
            End Get
            Set(ByVal Value As String)
                m_strDescricaoPergunta = Value
            End Set
        End Property

        Public Overridable Property MultiResposta() As Boolean
            Get
                Return m_varMultiResposta
            End Get
            Set(ByVal Value As Boolean)
                m_varMultiResposta = Value
            End Set
        End Property

        Public Overridable Property TipoCampo() As Byte
            Get
                Return m_indTipoCampo
            End Get
            Set(ByVal Value As Byte)
                m_indTipoCampo = Value
            End Set
        End Property

        Public Overridable Property PerguntaLoja() As enTipoPergunta
            Get
                Return m_intPerguntaLoja
            End Get
            Set(ByVal value As enTipoPergunta)
                m_intPerguntaLoja = value
            End Set
        End Property

        Public Overridable Property Ativo() As Boolean
            Get
                Return m_blnAtivo
            End Get
            Set(ByVal value As Boolean)
                m_blnAtivo = value
            End Set
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDPergunta = 0
            End Get
        End Property

        Public Property Prioridade() As Integer
            Get
                Return m_intPrioridade
            End Get
            Set(ByVal value As Integer)
                m_intPrioridade = value
            End Set
        End Property


        Public ReadOnly Property Condicional() As Boolean
            Get
                If m_indTipoDependencia = 0 Then
                    For Each r As clsPerguntaResposta In Me.Respostas
                        If r.Acao <> clsPerguntaResposta.enRespostaAcao.Nenhuma Then
                            Return True
                        End If
                    Next
                End If
                Return m_indTipoDependencia > 0
            End Get
        End Property

        Public Property Minimo() As Decimal
            Get
                Return m_dcmMinimo
            End Get
            Set(ByVal value As Decimal)
                m_dcmMinimo = value
            End Set
        End Property

        Public Property Maximo() As Decimal
            Get
                Return m_dcmMaximo
            End Get
            Set(ByVal value As Decimal)
                m_dcmMaximo = value
            End Set
        End Property

        Public Overridable Property TipoDependencia() As enTipoDependencia
            Get
                Return m_indTipoDependencia
            End Get
            Set(ByVal Value As enTipoDependencia)
                m_indTipoDependencia = Value
            End Set
        End Property

        Public Overridable Property IDDependente() As Integer
            Get
                Return m_intIDDependente
            End Get
            Set(ByVal Value As Integer)
                m_intIDDependente = Value
            End Set
        End Property

        Public Overridable Property DependenteValor() As String
            Get
                Return m_strDependenteValor
            End Get
            Set(ByVal Value As String)
                m_strDependenteValor = Value
            End Set
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDPergunta = dr.GetInt32(dr.GetOrdinal("IDPergunta"))
            If dr.IsDBNull(dr.GetOrdinal("Codigo")) Then
                m_strCodigo = ""
            Else
                m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
            End If
            m_strPergunta = dr.GetString(dr.GetOrdinal("Pergunta"))
            m_strDescricaoPergunta = dr.GetString(dr.GetOrdinal("DescricaoRelatorio"))
            m_intPrioridade = dr.GetInt32(dr.GetOrdinal("Prioridade"))
            m_varMultiResposta = dr.GetBoolean(dr.GetOrdinal("MultiResposta"))
            m_indTipoCampo = dr.GetByte(dr.GetOrdinal("TipoCampo"))
            m_intPerguntaLoja = dr.GetByte(dr.GetOrdinal("PerguntaLoja"))
            m_blnAtivo = (dr.GetByte(dr.GetOrdinal("Ativo")) = 1)
            If dr.IsDBNull(dr.GetOrdinal("Minimo")) Then
                m_dcmMinimo = 0
            Else
                m_dcmMinimo = dr.GetFloat(dr.GetOrdinal("Minimo"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Maximo")) Then
                m_dcmMaximo = 0
            Else
                m_dcmMaximo = dr.GetFloat(dr.GetOrdinal("Maximo"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("TipoDependencia")) Then
                m_indTipoDependencia = 0
            Else
                m_indTipoDependencia = dr.GetByte(dr.GetOrdinal("TipoDependencia"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDDependente")) Then
                m_intIDDependente = 0
            Else
                m_intIDDependente = dr.GetInt32(dr.GetOrdinal("IDDependente"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DependenteValor")) Then
                m_strDependenteValor = ""
            Else
                m_strDependenteValor = dr.GetString(dr.GetOrdinal("DependenteValor"))
            End If
        End Sub

        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PERGUNTA"
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@PERGUNTA", SqlDbType.VarChar, 255).Value = m_strPergunta
            cmd.Parameters.Add("@DESCRICAORELATORIO", SqlDbType.VarChar, 255).Value = m_strDescricaoPergunta
            cmd.Parameters.Add("@PRIORIDADE", SqlDbType.Int).Value = m_intPrioridade
            cmd.Parameters.Add("@MULTIRESPOSTA", SqlDbType.Bit).Value = m_varMultiResposta
            cmd.Parameters.Add("@TIPOCAMPO", SqlDbType.TinyInt).Value = m_indTipoCampo
            cmd.Parameters.Add("@PERGUNTALOJA", SqlDbType.TinyInt).Value = m_intPerguntaLoja
            cmd.Parameters.Add("@ATIVO", SqlDbType.TinyInt).Value = IIf(m_blnAtivo, 1, 0)
            cmd.Parameters.Add("@MINIMO", SqlDbType.Decimal).Value = m_dcmMinimo
            cmd.Parameters.Add("@MAXIMO", SqlDbType.Decimal).Value = m_dcmMaximo
            cmd.Parameters.Add("@TIPODEPENDENCIA", SqlDbType.TinyInt).Value = m_indTipoDependencia
            cmd.Parameters.Add("@IDDEPENDENTE", SqlDbType.Int).Value = m_intIDDependente
            cmd.Parameters.Add("@DEPENDENTEVALOR", SqlDbType.NVarChar, 255).Value = m_strDependenteValor
            cn.Open()
            Try
                Dim dr As IDataReader = ExecuteReader(cmd)
                If dr.Read Then
                    Inflate(dr)
                    If (Not dr Is Nothing) Then
                        dr.Close()
                        dr = Nothing
                    End If

                    Dim cmdClear As New SqlCommand(PREFIXO & "DE_PERGUNTARESPOSTA")
                    cmdClear.Connection = cn
                    cmdClear.CommandType = CommandType.StoredProcedure
                    cmdClear.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
                    cmdClear.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                    cmdClear.ExecuteNonQuery()
                    cmdClear.Dispose()
                    cmdClear = Nothing

                    Me.User.Log("Cadastro de Perguntas", "Apagar - IDPERGUNTA=" & m_intIDPergunta)

                    Dim cmdRespostas As New SqlCommand(PREFIXO & "IN_PERGUNTARESPOSTA")
                    cmdRespostas.Connection = cn
                    cmdRespostas.CommandType = CommandType.StoredProcedure
                    cmdRespostas.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
                    cmdRespostas.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                    cmdRespostas.Parameters.Add("@RESPOSTA", SqlDbType.VarChar, 255)
                    cmdRespostas.Parameters.Add("@UNICA", SqlDbType.Bit)
                    cmdRespostas.Parameters.Add("@ACAO", SqlDbType.TinyInt)
                    cmdRespostas.Parameters.Add("@ACAOVALOR", SqlDbType.Int)
                    Dim resp As clsPerguntaResposta
                    For Each resp In m_colRespostas
                        If resp.Resposta <> "" Then
                            cmdRespostas.Parameters("@RESPOSTA").Value = resp.Resposta
                            cmdRespostas.Parameters("@UNICA").Value = resp.Unica
                            cmdRespostas.Parameters("@ACAO").Value = resp.Acao
                            cmdRespostas.Parameters("@ACAOVALOR").Value = resp.AcaoValor
                            cmdRespostas.ExecuteNonQuery()
                        End If

                        Me.User.Log("Cadastro de Perguntas", "GravarPerguntaResposta - IDPERGUNTA=" & m_intIDPergunta & " RESPOSTA=" & resp.Resposta & " UNICA=" & resp.Unica)
                    Next
                    cmdRespostas.Dispose()
                    cmdRespostas = Nothing


                Else
                    Clear()
                End If
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try

            Me.User.Log("Cadastro de Perguntas", "Gravar - IDPERGUNTA=" & m_intIDPergunta & " PERGUNTA=" & m_strPergunta & " DESCRICAORELATORIO=" & m_strPergunta & _
                        " PRIORIDADE=" & m_intPrioridade & " MULTIRESPOSTA=" & m_varMultiResposta & " TIPOCAMPO=" & m_indTipoCampo & " PERGUNTALOJA=" & m_intPerguntaLoja & _
                        " ATIVO=" & m_blnAtivo & " MINIMO=" & m_dcmMinimo & " MAXIMO=" & m_dcmMaximo)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDPergunta">Chave primaria IDPergunta</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDPergunta As Integer) As Boolean


            If vIDPergunta = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PERGUNTA"
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                    dr.NextResult()
                    m_colRespostas = New clsPerguntaRespostaCollection
                    Do While dr.Read
                        If Not dr.IsDBNull(dr.GetOrdinal("Resposta")) Then
                            m_colRespostas.Add(dr.GetString(dr.GetOrdinal("Resposta")), dr.GetBoolean(dr.GetOrdinal("Unica")), dr.GetByte(dr.GetOrdinal("Acao")), dr.GetInt32(dr.GetOrdinal("AcaoValor")))
                        End If
                    Loop
                Else
                    Clear()
                End If
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try

            Me.User.Log("Cadastro de Perguntas", "Visualizar - IDPERGUNTA=" & vIDPergunta)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDPergunta = 0
            m_strCodigo = ""
            m_strPergunta = ""
            m_strDescricaoPergunta = ""
            m_intPrioridade = 0
            m_varMultiResposta = Nothing
            m_indTipoCampo = 0
            m_intPerguntaLoja = False
            m_blnAtivo = True
            m_dcmMinimo = 0
            m_dcmMaximo = 0
            m_indTipoDependencia = 0
            m_intIDDependente = 0
            m_strDependenteValor = ""
            m_colRespostas = New clsPerguntaRespostaCollection
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PERGUNTA"
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Perguntas", "Apagar - IDPERGUNTA=" & m_intIDPergunta)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Pergunta' the following row:  IDPergunta=" & m_intIDPergunta & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PERGUNTAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <param name="vIdPesquisa">Código da pesquisa para filtrar somente perguntas ativas</param>
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIdPesquisa As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PERGUNTAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIdPesquisa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenção utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>

        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, ByVal vTipoCampo As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PERGUNTAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@TIPOPERG", SqlDbType.VarChar, 50).Value = vTipoCampo
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        Public Function ListarPerguntasRelatorio(ByVal vIdCategoria As Integer, ByVal vTipoRelatorio As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As SqlDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PERGUNTAS_RELATORIO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIdCategoria
            cmd.Parameters.Add("@TIPORELATORIO", SqlDbType.Int).Value = vTipoRelatorio

            Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa de Segmentações da Pergunta
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarSegmentacao(Optional ByVal p_TipoFiltro As String = "", Optional ByVal p_Filtro As String = "", Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PERGUNTA_SEGMENTACOES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
            cmd.Parameters.Add("@TIPOBUSCA", SqlDbType.VarChar, 20).Value = p_TipoFiltro
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 200).Value = p_Filtro
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa de Segmentações por loja da Pergunta
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listarlojas(Optional ByVal p_TipoFiltro As String = "", Optional ByVal p_Filtro As String = "", Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PERGUNTA_LOJAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
            cmd.Parameters.Add("@TIPOBUSCA", SqlDbType.VarChar, 20).Value = p_TipoFiltro
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 200).Value = p_Filtro
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        Public Function ListarDependentes(ByVal vIDPerguntaLoja As enTipoPergunta, ByVal vPrioridade As Integer, Optional ByVal vMaior As Boolean = False) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PERGUNTA_DEPENDENCIA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
            cmd.Parameters.Add("@PERGUNTALOJA", SqlDbType.TinyInt).Value = vIDPerguntaLoja
            cmd.Parameters.Add("@PRIORIDADE", SqlDbType.Int).Value = vPrioridade
            cmd.Parameters.Add("@MAIOR", SqlDbType.Bit).Value = vMaior
            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)
        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa das respostas
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarRespostas(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PERGUNTARESPOSTAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        Public Sub AdicionarProdutos(ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, ByVal vIDProduto As Integer, ByVal vConcorrente As Byte)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PERGUNTA_SEGMENTACAO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@CONCORRENTE", SqlDbType.Int).Value = vConcorrente

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Perguntas", "AdicionarProdutos - IDPERGUNTA=" & m_intIDPergunta & " IDSUBCATEGORIA=" & vIDSubCategoria & " IDCATEGORIA=" & vIDCategoria & _
                        " IDPRODUTO=" & vIDProduto & " CONCORRENTE=" & vConcorrente)

        End Sub

        Public Sub RetirarProdutos(ByVal vIDSegmentacao As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PERGUNTA_SEGMENTACAO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
            cmd.Parameters.Add("@IDSEGMENTACAO", SqlDbType.Int).Value = vIDSegmentacao

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Perguntas", "RetirarProdutos - IDPERGUNTA=" & m_intIDPergunta & " IDSEGMENTACAO=" & vIDSegmentacao)

        End Sub



        Public Sub RetirarLoja(ByVal vIDPerguntaLoja As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PERGUNTA_LOJA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
            cmd.Parameters.Add("@IDPERGUNTALOJA", SqlDbType.Int).Value = vIDPerguntaLoja

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Perguntas", "RetirarLoja - IDPERGUNTA=" & m_intIDPergunta & " IDPERGUNTALOJA=" & vIDPerguntaLoja)

        End Sub



        Public Sub AdicionarLoja(ByVal vUF As String, ByVal vCidade As String, ByVal vIDCliente As Integer, ByVal vIDLoja As Integer, ByVal vIDRegiao As Integer, ByVal vIDTipoLoja As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PERGUNTA_LOJA"
            Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            parameter.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(parameter)
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = m_intIDPergunta
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = vUF
            cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar, 100).Value = vCidade
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = vIDRegiao
            cmd.Parameters.Add("@IDTIPOLOJA", SqlDbType.Int).Value = vIDTipoLoja

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Perguntas", "AdicionarLoja - IDPERGUNTA=" & m_intIDPergunta & " UF=" & vUF & " CIDADE=" & vCidade & " IDCLIENTE=" & vIDCliente & _
                        " IDLOJA=" & vIDLoja & " IDREGIAO=" & vIDRegiao & " IDTIPOLOJA=" & vIDTipoLoja)

        End Sub


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            Return blnValid
        End Function

        Public ReadOnly Property Respostas() As clsPerguntaRespostaCollection
            Get
                Return m_colRespostas
            End Get
        End Property

#End Region



    End Class
End Namespace
