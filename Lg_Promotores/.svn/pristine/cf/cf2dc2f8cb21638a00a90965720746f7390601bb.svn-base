

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsPesquisa
        Inherits BaseClass

#Region "Declarations"
        Protected m_intIDPesquisa As Integer
        Protected m_strPesquisa As String
        Protected m_indConcorrente As Byte
        Protected m_strCriado As String
        Protected m_intDia As Integer
        Protected m_intMes As Integer
        Protected m_intDiaSemana As Integer
        Protected m_intSemanaMes As Integer
        Protected m_indAcao As Byte
        Protected m_blnAtivo As Boolean

        Public Enum enTipoPesquisa As Byte
            Marca_Propria = 0
            Concorrente = 1
            Todos = 2
        End Enum
#End Region



#Region "Properties"
        Public Overridable ReadOnly Property IDPesquisa() As Integer
            Get
                Return m_intIDPesquisa
            End Get
        End Property

        Public Overridable Property Pesquisa() As String
            Get
                Return m_strPesquisa
            End Get
            Set(ByVal Value As String)
                m_strPesquisa = Value
            End Set
        End Property

        Public Overridable Property Concorrente() As enTipoPesquisa
            Get
                Return m_indConcorrente
            End Get
            Set(ByVal Value As enTipoPesquisa)
                m_indConcorrente = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Criado() As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
        End Property

        Public Overridable Property Dia() As Integer
            Get
                Return m_intDia
            End Get
            Set(ByVal Value As Integer)
                m_intDia = Value
            End Set
        End Property

        Public Overridable Property Mes() As Integer
            Get
                Return m_intMes
            End Get
            Set(ByVal Value As Integer)
                m_intMes = Value
            End Set
        End Property

        Public Overridable Property DiaSemana() As Integer
            Get
                Return m_intDiaSemana
            End Get
            Set(ByVal Value As Integer)
                m_intDiaSemana = Value
            End Set
        End Property

        Public Overridable Property SemanaMes() As Integer
            Get
                Return m_intSemanaMes
            End Get
            Set(ByVal Value As Integer)
                m_intSemanaMes = Value
            End Set
        End Property

        Public Property Ativo() As Boolean
            Get
                Return m_blnAtivo
            End Get
            Set(ByVal value As Boolean)
                m_blnAtivo = value
            End Set
        End Property


        Public Overridable Property Acao() As Byte
            Get
                Return m_indAcao
            End Get
            Set(ByVal Value As Byte)
                m_indAcao = Value
            End Set
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDPesquisa = 0
            End Get
        End Property
#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDPesquisa = dr.GetInt32(dr.GetOrdinal("IDPesquisa"))
            m_strPesquisa = dr.GetString(dr.GetOrdinal("Pesquisa"))
            m_indConcorrente = dr.GetByte(dr.GetOrdinal("Concorrente"))
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            If dr.IsDBNull(dr.GetOrdinal("Dia")) Then
                m_intDia = 0
            Else
                m_intDia = dr.GetInt32(dr.GetOrdinal("Dia"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Mes")) Then
                m_intMes = 0
            Else
                m_intMes = dr.GetInt32(dr.GetOrdinal("Mes"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DiaSemana")) Then
                m_intDiaSemana = 0
            Else
                m_intDiaSemana = dr.GetInt32(dr.GetOrdinal("DiaSemana"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("SemanaMes")) Then
                m_intSemanaMes = 0
            Else
                m_intSemanaMes = dr.GetInt32(dr.GetOrdinal("SemanaMes"))
            End If
            m_blnAtivo = (dr.GetByte(dr.GetOrdinal("Ativo")) = 1)
            If dr.IsDBNull(dr.GetOrdinal("Acao")) Then
                m_indAcao = 7
            Else
                m_indAcao = dr.GetByte(dr.GetOrdinal("Acao"))
            End If
        End Sub

        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PESQUISA"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@PESQUISA", SqlDbType.VarChar, 50).Value = m_strPesquisa
            cmd.Parameters.Add("@CONCORRENTE", SqlDbType.TinyInt).Value = m_indConcorrente
            cmd.Parameters.Add("@DIA", SqlDbType.Int).Value = m_intDia
            cmd.Parameters.Add("@MES", SqlDbType.Int).Value = m_intMes
            cmd.Parameters.Add("@DIASEMANA", SqlDbType.Int).Value = m_intDiaSemana
            cmd.Parameters.Add("@SEMANAMES", SqlDbType.Int).Value = m_intSemanaMes
            cmd.Parameters.Add("@ACAO", SqlDbType.TinyInt).Value = m_indAcao
            cmd.Parameters.Add("@ATIVO", SqlDbType.TinyInt).Value = IIf(m_blnAtivo, 1, 0)

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

            Me.User.Log("Cadastro de Pesquisas", "Gravar - IDPESQUISA=" & m_intIDPesquisa & " PESQUISA=" & m_strPesquisa & " CONCORRENTE=" & m_indConcorrente & " DIA=" & m_intDia & _
                        " MES=" & m_intMes & " DIASEMANA=" & m_intDiaSemana & " SEMANAMES=" & m_intSemanaMes & " ACAO=" & m_indAcao & " ATIVO=" & m_blnAtivo)

        End Sub

        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDPesquisa">Chave primaria IDPesquisa</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDPesquisa As Integer) As Boolean
            If vIDPesquisa = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PESQUISA"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIDPesquisa
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

            Me.User.Log("Cadastro de Pesquisas", "Visualizar - IDPESQUISA=" & vIDPesquisa)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDPesquisa = 0
            m_strPesquisa = ""
            m_indConcorrente = 0
            m_strCriado = ""
            m_intDia = 0
            m_intMes = 0
            m_intDiaSemana = 0
            m_intSemanaMes = 0
            m_blnAtivo = True
            m_indAcao = 7
        End Sub

        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PESQUISA"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Pesquisas", "Apagar - IDPESQUISA=" & m_intIDPesquisa)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Pesquisa' the following row:  IDPesquisa=" & m_intIDPesquisa & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)

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
            cmd.CommandText = PREFIXO & "LS_PESQUISAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa de produtos da pesquisa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarProdutos(Optional ByVal p_TipoFiltro As String = "", Optional ByVal p_Filtro As String = "", Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PESQUISA_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@TIPOBUSCA", SqlDbType.VarChar, 20).Value = p_TipoFiltro
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 200).Value = p_Filtro
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa de perguntas da pesquisa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarPerguntas(Optional ByVal p_Filtro As String = "", Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PESQUISA_PERGUNTAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 200).Value = p_Filtro
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa de segmentos (lojas) da pesquisa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarSegmentos(Optional ByVal p_TipoFiltro As String = "", Optional ByVal p_Filtro As String = "", Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PESQUISA_SEGMENTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@TIPOBUSCA", SqlDbType.VarChar, 20).Value = p_TipoFiltro
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 200).Value = p_Filtro
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

        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PESQUISAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        Public Sub AdicionarProdutos(ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, ByVal vIDProduto As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PESQUISA_PRODUTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Pesquisas", "AdicionarProdutos - IDPESQUISA=" & m_intIDPesquisa & " IDSUBCATEGORIA=" & vIDSubCategoria & " IDCATEGORIA=" & vIDCategoria & _
                        " IDPRODUTO=" & vIDProduto)
            
        End Sub

        Public Sub AdicionarPergunta(ByVal vIDPergunta As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PESQUISA_PERGUNTA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Pesquisas", "AdicionarPergunta - IDPESQUISA=" & m_intIDPesquisa & " IDPERGUNTA=" & vIDPergunta)

        End Sub

        Public Sub RetirarProdutos(ByVal vIDPesquisaProduto As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PESQUISA_PRODUTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@IDPESQUISAPRODUTO", SqlDbType.Int).Value = vIDPesquisaProduto

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Pesquisas", "RetirarProdutos - IDPESQUISA=" & m_intIDPesquisa & " IDPESQUISAPRODUTO=" & vIDPesquisaProduto)

        End Sub


        Public Sub RetirarSegmento(ByVal vIDPesquisaSegmento As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PESQUISA_SEGMENTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@IDPESQUISASEGMENTO", SqlDbType.Int).Value = vIDPesquisaSegmento

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Pesquisas", "RetirarSegmento - IDPESQUISA=" & m_intIDPesquisa & " IDPESQUISASEGMENTO=" & vIDPesquisaSegmento)

        End Sub

        Public Sub RetirarPerguntas(ByVal vIDPergunta As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PESQUISA_PERGUNTA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Pesquisas", "RetirarPerguntas - IDPESQUISA=" & m_intIDPesquisa & " IDPERGUNTA=" & vIDPergunta)

        End Sub

        Public Sub AdicionarSegmento(ByVal vUF As String, ByVal vCidade As String, ByVal vIDCliente As Integer, ByVal vIDLoja As Integer, ByVal vIDRegiao As Integer, ByVal vIDTipoLoja As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PESQUISA_SEGMENTO"
            Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            parameter.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(parameter)
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = vUF
            cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar, 100).Value = vCidade
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = vIDRegiao
            cmd.Parameters.Add("@IDTIPOLOJA", SqlDbType.Int).Value = vIDTipoLoja

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Pesquisas", "AdicionarSegmento - IDPESQUISA=" & m_intIDPesquisa & " UF=" & vUF & " CIDADE=" & vCidade & " IDCLIENTE=" & vIDCliente & " IDLOJA=" & vIDLoja & _
                        " IDREGIAO=" & vIDRegiao & " IDTIPOLOJA=" & vIDTipoLoja)

        End Sub

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            Return blnValid
        End Function

#End Region



    End Class
End Namespace



