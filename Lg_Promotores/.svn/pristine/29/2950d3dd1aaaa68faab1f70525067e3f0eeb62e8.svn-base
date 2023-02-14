

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsVisita
        Inherits BaseClass



#Region "Declarations"

        Protected m_intIDVisita As Integer
        Protected m_intIDLoja As Integer
        Protected m_strLoja As String
        Protected m_intIDPromotor As Integer
        Protected m_strPromotor As String
        Protected m_strDataInicio As String
        Protected m_strDataFinalizacao As String
        Protected m_strData As String
        Protected m_strDataEmissao As String
        Protected m_intNumDevice As Integer
        Protected m_intIDStatus As Integer
        Protected m_strStatus As String
        Protected m_intNumProdutosVisita As Integer
        Protected m_intIDTipoJustificativa As Integer
        Protected m_strTipoJustificativa As String
        Protected m_intProdutosColetados As Integer
        Protected m_strResponsavel As String
        Protected m_strLatitudeInicial As Double
        Protected m_strLatitudeFinal As Double
        Protected m_strLongitudeInicial As Double
        Protected m_strLongitudeFinal As Double
        Protected m_indIDStatusVisita As Short
        Protected m_indIdMotivoUsoFormulario As Integer
        Protected m_strMotivoUsoForm As String
        Protected m_indTeste As Integer
        Protected m_indMapa As Integer
        Protected m_intPrecisao As Integer
        Protected m_strLatitudeLoja As Double
        Protected m_strLongitudeLoja As Double


#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDVisita As Integer
            Get
                Return m_intIDVisita
            End Get
        End Property

        Public Overridable Property Teste() As Integer
            Get
                Return m_indTeste
            End Get
            Set(ByVal value As Integer)
                m_indTeste = value
            End Set
        End Property

        Public Overridable Property Mapa() As Integer
            Get
                Return m_indMapa
            End Get
            Set(ByVal value As Integer)
                m_indMapa = value
            End Set
        End Property



        Public Overridable Property Precisao() As Integer
            Get
                Return m_intPrecisao
            End Get
            Set(ByVal value As Integer)
                m_intPrecisao = value
            End Set
        End Property

        Public Overridable Property IDLoja As Integer
            Get
                Return m_intIDLoja
            End Get
            Set(ByVal Value As Integer)
                m_intIDLoja = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Loja As String
            Get
                Return m_strLoja
            End Get
        End Property

        Public Overridable Property IDPromotor As Integer
            Get
                Return m_intIDPromotor
            End Get
            Set(ByVal Value As Integer)
                m_intIDPromotor = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Promotor As String
            Get
                Return m_strPromotor
            End Get
        End Property

        Public Overridable ReadOnly Property DataInicio() As String
            Get
                Return _getDateTimePropertyValue(m_strDataInicio)
            End Get
        End Property

        Public Overridable ReadOnly Property DataFinalizacao() As String
            Get
                Return _getDateTimePropertyValue(m_strDataFinalizacao)
            End Get
        End Property

        Public Overridable ReadOnly Property Data() As String
            Get
                Return _getDatePropertyValue(m_strData)
            End Get
        End Property

        Public Overridable ReadOnly Property DataEmissao() As String
            Get
                Return _getDateTimePropertyValue(m_strDataEmissao)
            End Get
        End Property

        Public Overridable ReadOnly Property NumDevice() As Integer
            Get
                Return m_intNumDevice
            End Get
        End Property

        Public Overridable Property IDStatus() As Integer
            Get
                Return m_intIDStatus
            End Get
            Set(ByVal Value As Integer)
                m_intIDStatus = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Status() As String
            Get
                Return m_strStatus
            End Get
        End Property


        Public Overridable ReadOnly Property NumProdutosVisita() As Integer
            Get
                Return m_intNumProdutosVisita
            End Get
        End Property

        Public Overridable ReadOnly Property ProdutosColetados() As Integer
            Get
                Return m_intProdutosColetados
            End Get
        End Property

        Public Overridable Property IDTipoJustificativa() As Integer
            Get
                Return m_intIDTipoJustificativa
            End Get
            Set(ByVal Value As Integer)
                m_intIDTipoJustificativa = Value
            End Set
        End Property

        Public Overridable ReadOnly Property TipoJustificativa As String
            Get
                Return m_strTipoJustificativa
            End Get
        End Property

        Public Overridable ReadOnly Property Responsavel() As String
            Get
                Return m_strResponsavel
            End Get
        End Property

        Public Overridable ReadOnly Property LatitudeInicial() As Double
            Get
                Return m_strLatitudeInicial
            End Get
        End Property

        Public Overridable ReadOnly Property LongitudeInicial() As Double
            Get
                Return m_strLongitudeInicial
            End Get
        End Property

        Public Overridable ReadOnly Property LatitudeFinal() As Double
            Get
                Return m_strLatitudeFinal
            End Get
        End Property

        Public Overridable ReadOnly Property LongitudeFinal() As Double
            Get
                Return m_strLongitudeFinal
            End Get
        End Property

        Public Property StatusVisita() As Short
            Get
                Return m_indIDStatusVisita
            End Get
            Set(ByVal value As Short)
                m_indIDStatusVisita = value
            End Set
        End Property

        Public ReadOnly Property MotivoUsoForm() As String
            Get
                Return m_strMotivoUsoForm
            End Get
        End Property

        Public Property IdMotivoUsoForm() As Integer
            Get
                Return m_indIdMotivoUsoFormulario
            End Get
            Set(ByVal value As Integer)
                m_indIdMotivoUsoFormulario = value
            End Set
        End Property

        Public Overridable ReadOnly Property LatitudeLoja() As Double
            Get
                Return m_strLatitudeLoja
            End Get
        End Property

        Public Overridable ReadOnly Property LongitudeLoja() As Double
            Get
                Return m_strLongitudeLoja
            End Get
        End Property


#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDVisita = dr.GetInt32(dr.GetOrdinal("IDVisita"))
            m_intIDLoja = dr.GetInt32(dr.GetOrdinal("IDLoja"))
            m_strLoja = dr.GetString(dr.GetOrdinal("Loja"))
            m_intIDPromotor = dr.GetInt32(dr.GetOrdinal("IDPromotor"))
            m_strPromotor = dr.GetString(dr.GetOrdinal("Promotor"))
            If dr.IsDBNull(dr.GetOrdinal("DataInicio")) Then
                m_strDataInicio = ""
            Else
                m_strDataInicio = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataInicio")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DataFinalizacao")) Then
                m_strDataFinalizacao = ""
            Else
                m_strDataFinalizacao = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataFinalizacao")))
            End If
            '    If dr.IsDBNull(dr.GetOrdinal("Data")) Then
            'm_strData = ""
            '   Else
            '   m_strData = _getDatePropertyValue(dr.GetDateTime(dr.GetOrdinal("Data")))
            '  End If
            If dr.IsDBNull(dr.GetOrdinal("DataEmissao")) Then
                m_strDataEmissao = ""
            Else
                m_strDataEmissao = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataEmissao")))
            End If
            m_intNumDevice = dr.GetInt32(dr.GetOrdinal("NumDevice"))
            If dr.IsDBNull(dr.GetOrdinal("IDStatus")) Then
                m_intIDStatus = 0
            Else
                m_intIDStatus = dr.GetInt32(dr.GetOrdinal("IDStatus"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Status")) Then
                m_strStatus = ""
            Else
                m_strStatus = dr.GetString(dr.GetOrdinal("Status"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("NumProdutosVisita")) Then
                m_intNumProdutosVisita = 0
            Else
                m_intNumProdutosVisita = dr.GetInt32(dr.GetOrdinal("NumProdutosVisita"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("NumProdutosColetados")) Then
                m_intProdutosColetados = 0
            Else
                m_intProdutosColetados = dr.GetInt32(dr.GetOrdinal("NumProdutosColetados"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDTipoJustificativa")) Then
                m_intIDTipoJustificativa = 0
            Else
                m_intIDTipoJustificativa = dr.GetInt32(dr.GetOrdinal("IDTipoJustificativa"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("TipoJustificativa")) Then
                m_strTipoJustificativa = ""
            Else
                m_strTipoJustificativa = dr.GetString(dr.GetOrdinal("TipoJustificativa"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Responsavel")) Then
                m_strResponsavel = ""
            Else
                m_strResponsavel = dr.GetString(dr.GetOrdinal("Responsavel"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("LatitudeInicial")) Then
                m_strLatitudeInicial = 0
            Else
                m_strLatitudeInicial = dr.GetFloat(dr.GetOrdinal("LatitudeInicial"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("LatitudeFinal")) Then
                m_strLatitudeFinal = 0
            Else
                m_strLatitudeFinal = dr.GetFloat(dr.GetOrdinal("LatitudeFinal"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("LongitudeInicial")) Then
                m_strLongitudeInicial = 0
            Else
                m_strLongitudeInicial = dr.GetFloat(dr.GetOrdinal("LongitudeInicial"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("LongitudeFinal")) Then
                m_strLongitudeFinal = 0
            Else
                m_strLongitudeFinal = dr.GetFloat(dr.GetOrdinal("LongitudeFinal"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IdStatusVisita")) Then
                m_indIDStatusVisita = 0
            Else
                m_indIDStatusVisita = dr.GetValue(dr.GetOrdinal("IdStatusVisita"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IdMotivoUsoForm")) Then
                m_indIdMotivoUsoFormulario = 0
            Else
                m_indIdMotivoUsoFormulario = dr.GetInt32(dr.GetOrdinal("IdMotivoUsoForm"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("MotivoUsoForm")) Then
                m_strMotivoUsoForm = ""
            Else
                m_strMotivoUsoForm = dr.GetString(dr.GetOrdinal("MotivoUsoForm"))
            End If

            If dr.IsDBNull(dr.GetOrdinal("Teste")) Then
                m_indTeste = 0
            Else
                m_indTeste = dr.GetByte(dr.GetOrdinal("Teste"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("LatitudeLoja")) Then
                m_strLatitudeLoja = 0
            Else
                m_strLatitudeLoja = dr.GetDouble(dr.GetOrdinal("LatitudeLoja"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("LongitudeLoja")) Then
                m_strLongitudeLoja = 0
            Else
                m_strLongitudeLoja = dr.GetDouble(dr.GetOrdinal("LongitudeLoja"))
            End If
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_VISITA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = m_intIDLoja
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = m_intIDPromotor
            If m_strDataInicio <> "" Then
                cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strDataInicio)
            End If
            If m_strDataFinalizacao <> "" Then
                cmd.Parameters.Add("@DATAFINALIZACAO", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strDataFinalizacao)
            End If
            cmd.Parameters.Add("@IDTIPOJUSTIFICATIVA", SqlDbType.Int).Value = m_intIDTipoJustificativa
            cmd.Parameters.Add("@IDSTATUSVISITA", SqlDbType.TinyInt).Value = m_indIDStatusVisita
            cmd.Parameters.Add("@IDMOTIVOUSOFORM", SqlDbType.TinyInt).Value = m_indIdMotivoUsoFormulario
            cmd.Parameters.Add("@TESTE", SqlDbType.TinyInt).Value = m_indTeste
            cmd.Parameters.Add("@MAPA", SqlDbType.TinyInt).Value = m_indMapa

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

            Me.User.Log("Visitas", "Gravar - IDVISITA=" & m_intIDVisita & " IDLOJA=" & m_intIDLoja & " IDPROMOTOR=" & m_intIDPromotor & " DATAINICIO=" & _
                    m_strDataInicio & " DATAFINALIZACAO=" & m_strDataFinalizacao & " IDTIPOJUSTIFICATIVA=" & m_intIDTipoJustificativa & " IDSTATUSVISITA=" & m_indIDStatusVisita & _
                    " IDMOTIVOUSOFORM=" & m_indIdMotivoUsoFormulario & " TESTE=" & m_indTeste & "MAPA =" & m_indMapa)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDVisita">Chave primaria IDVisita</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDVisita As Integer) As Boolean

            If vIDVisita = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_VISITA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita

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

            Me.User.Log("Visitas", "Visualizar - IDVISITA=" & vIDVisita)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()

            m_intIDVisita = 0
            m_intIDLoja = 0
            m_intIDPromotor = 0
            m_strDataInicio = ""
            m_strDataFinalizacao = ""
            m_intNumDevice = 0
            m_intIDStatus = 0
            m_strStatus = ""
            m_intNumProdutosVisita = 0
            m_intIDTipoJustificativa = 0
            m_strResponsavel = ""
            m_strLatitudeFinal = 0
            m_strLatitudeInicial = 0
            m_strLongitudeFinal = 0
            m_strLongitudeInicial = 0
            m_indIDStatusVisita = 0
            m_indTeste = 0
            m_strLatitudeLoja = 0
            m_strLongitudeLoja = 0
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_VISITA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita

            ExecuteNonQuery(cmd)

            Me.User.Log("Visitas", "Apagar - IDVISITA=" & m_intIDVisita)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Visita' the following row:  IDEmpresa=" & User.IDEmpresa & " IDVisita=" & m_intIDVisita & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Rotina que move os dados da visita
        '''     para uma tabela de backup e apaga o 
        '''     registro da tabela principal
        ''' </summary>
        Public Sub Delete_To_Temp(ByVal vIdVisita As Integer)

            Dim cmd As New SqlCommand()
            Dim cn As SqlConnection = GetDBConnection()

            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_VISITA_TOTEMP"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIdVisita
            cn.Open()

            Try
                cmd.ExecuteNonQuery()
            Catch ex_Message As Exception
                Throw New Exception(ex_Message.Message)
            Finally
                cn.Close()
            End Try

            Me.User.Log("Visitas", "LimparTempVisita - IDVISITA=" & vIdVisita)

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_VISITAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDPromotor">Filtro</param>
        ''' <param name="vDataInicial">Filtro</param>
        ''' <param name="vDataFinal">Filtro</param>
        ''' <param name="vIDTipoJustificativa">Valor 0 - Sem justificativa, -1 - Todas</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIdCoordenador As Integer, ByVal vIDLider As Integer, ByVal vIDPromotor As Integer, ByVal vDataInicial As String, _
                               ByVal vDataFinal As String, ByVal vIDTipoJustificativa As Integer, ByVal vTeste As Short, ByVal vMapa As Short, ByVal vPrecisao As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, _
                               ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_VISITAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDCOORDENADOR", SqlDbType.Int).Value = vIdCoordenador
            cmd.Parameters.Add("@IDLIDER", SqlDbType.Int).Value = vIDLider
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            If vDataInicial <> "" Then
                cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
            End If
            If vDataFinal <> "" Then
                cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)
            End If
            cmd.Parameters.Add("@TESTE", SqlDbType.TinyInt).Value = vTeste
            cmd.Parameters.Add("@IDTIPOJUSTIFICATIVA", SqlDbType.Int).Value = vIDTipoJustificativa
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            cmd.Parameters.Add("@MAPA", SqlDbType.Int).Value = vMapa
            cmd.Parameters.Add("@PRECISAO", SqlDbType.Int).Value = vPrecisao
            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        Public Function ListarPerguntasLoja() As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_LOJA_PERGUNTAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita

            Return ExecuteReader(cmd)

        End Function

        Public Function ListarEventosLoja() As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_VISITA_EVENTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita

            Return ExecuteReader(cmd)

        End Function

        Public Function getSumario() As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_VISITAPRODUTOS_SUMARIO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita

            Return ExecuteReader(cmd)

        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean

            Dim blnValid As Boolean = True
            Return blnValid

        End Function


        Public Function ListarRespostasLoja(ByVal vIDPergunta As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PERGUNTA_RESPOSTAS_LOJA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        Protected Sub LimparRespostasLoja(ByVal vIDPergunta As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PERGUNTA_RESPOSTAS_LOJA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta

            ExecuteNonQuery(cmd)

            Me.User.Log("Visitas", "LimparRespostasLoja - IDVISITA=" & m_intIDVisita & " IDPERGUNTA=" & vIDPergunta)

        End Sub

        Public Sub AdicionarRespostasLoja(ByVal vIDPergunta As Integer, ByVal vRespostas() As String)
            LimparRespostasLoja(vIDPergunta)

            Dim cmd As New SqlCommand()
            Dim cn As SqlConnection = GetDBConnection()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PERGUNTA_RESPOSTA_LOJA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
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

            Me.User.Log("Visitas", "AdicionarRespostasLoja - IDVISITA=" & m_intIDVisita & " IDPERGUNTA=" & vIDPergunta & " RESPOSTA=" & prm.Value)

        End Sub


        'Public Function ListarPerguntasProduto(ByVal vIDProduto As Integer) As IDataReader

        '    Dim cmd As New SqlCommand()
        '    cmd.CommandText = PREFIXO & "LS_VISITA_PRODUTO_PERGUNTA"
        '    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        '    cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
        '    cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
        '    Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        'End Function

        'Public Sub LimparRespostasProduto(ByVal vIDProduto As Integer, ByVal vIDPergunta As Integer)

        '    Dim cmd As New SqlCommand()
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.CommandText = PREFIXO & "DE_PERGUNTARESPOSTAS"
        '    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        '    cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
        '    cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
        '    cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta
        '    MyBase.ExecuteNonQuery(cmd)

        'End Sub

        ''Public Sub LimparRespostas(ByVal vIDProduto As Integer)

        ''    Dim cmd As New SqlCommand()
        ''    cmd.CommandType = CommandType.StoredProcedure
        ''    cmd.CommandText = PREFIXO & "DE_PERGUNTARESPOSTAS"
        ''    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        ''    cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
        ''    cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
        ''    MyBase.ExecuteNonQuery(cmd)

        ''End Sub


        'Public Sub AdicionarRespostas(ByVal vIDProduto As Integer, ByVal vIDPergunta As Integer, ByVal vRespostas() As String)

        '    LimparRespostasProduto(vIDProduto, vIDPergunta)

        '    Dim cmd As New SqlCommand()
        '    Dim cn As SqlConnection = GetDBConnection()
        '    cmd.Connection = cn
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.CommandText = PREFIXO & "IN_PERGUNTA_RESPOSTA"
        '    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        '    cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
        '    cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
        '    cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta
        '    Dim prm As SqlParameter = cmd.Parameters.Add("@RESPOSTA", SqlDbType.VarChar)
        '    cn.Open()
        '    Try

        '        For Each strResposta As String In vRespostas
        '            prm.Value = strResposta
        '            cmd.ExecuteNonQuery()
        '        Next

        '    Finally
        '        cn.Close()
        '    End Try






        'End Sub

        'Public Function ListarRespostasProduto(ByVal vIDProduto As Integer, ByVal vIDPergunta As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

        '    Dim cmd As New SqlCommand()
        '    cmd.CommandText = PREFIXO & "LS_PERGUNTARESPOSTAS"
        '    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        '    cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
        '    cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
        '    cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta
        '    Return MyBase.ExecuteCommand(cmd, vReturnType)

        'End Function



#End Region



    End Class
End Namespace

