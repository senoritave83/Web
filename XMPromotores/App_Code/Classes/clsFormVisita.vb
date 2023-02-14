Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes


    Public Class clsFormVisita

        Inherits clsVisita
        Protected m_intIDResponsavel As Integer
        Protected m_intLojaPerguntas As Integer
        Protected m_intLojaPerguntasRespondidas As Integer
        Protected m_intIDVisitaAberta As Integer

        Public ReadOnly Property LojaPerguntas() As Integer
            Get
                Return m_intLojaPerguntas
            End Get
        End Property

        Public ReadOnly Property LojaPerguntasRespondidas() As Integer
            Get
                Return m_intLojaPerguntasRespondidas
            End Get
        End Property


        Public ReadOnly Property Justificada() As Boolean
            Get
                Return m_intIDTipoJustificativa > 0
            End Get
        End Property

        Public ReadOnly Property VisitaAberta() As Integer
            Get
                Return m_intIDVisitaAberta
            End Get
        End Property



        Public Sub New()
            PREFIXO = "SP_REP_WEB_FRM_"
        End Sub

        Protected Overrides Sub Inflate(ByVal dr As System.Data.IDataReader)
            MyBase.Inflate(dr)
            m_intIDResponsavel = dr.GetInt32(dr.GetOrdinal("IDResponsavel"))
            m_intLojaPerguntas = dr.GetInt32(dr.GetOrdinal("LojaPerguntas"))
            m_intLojaPerguntasRespondidas = dr.GetInt32(dr.GetOrdinal("LojaPerguntasRespondidas"))
            m_intIDVisitaAberta = dr.GetInt32(dr.GetOrdinal("IDVisitaAberta"))
        End Sub


        Public Function GetIDVisitaAtiva(ByVal vIDPromotor As Integer) As Integer

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_VISITA_ATIVA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDRESPONSAVEL", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor

            Return ExecuteScalar(cmd)
            
        End Function

        Protected Function GetMobileVersao() As String

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LAST_VERSION"

            Return ExecuteScalar(cmd)

        End Function

        Public Function ListarLojasRoteiro(ByVal vIDPromotor As Integer) As IDataReader

            Dim strXML As String = GetRoteiro(vIDPromotor)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_ROTEIRO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@XML", SqlDbType.Text).Value = strXML

            Return ExecuteReader(cmd)

        End Function

        Public Function ListarLojasRoteiroPendente(ByVal vIDPromotor As Integer, ByVal vData As String) As IDataReader


            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_VISITAS_PENDENTES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@DATA", SqlDbType.Date).Value = vData


            Return ExecuteReader(cmd)

        End Function


        Protected Function GetRoteiro(ByVal vIDPromotor As Integer) As String

            Dim strVersao As String = GetMobileVersao()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_REP_MOB_SE_DADOS_" & strVersao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor

            Return ExecuteXML(cmd)

        End Function

        Protected Function GetRoteiroAntigo(ByVal vIDPromotor As Integer, ByVal vData As Date) As String

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "MOB_SE_DADOS_ANTERIOR"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@DATA", SqlDbType.Date).Value = vData

            Return ExecuteXML(cmd)

        End Function



        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDPromotor">Chave primaria vIDPromotor</param>
        ''' <param name="vIDLoja">Chave primaria vIDLoja</param>
        ''' <returns>Boolean</returns>
        Public Overloads Function IniciarVisitaAntiga(ByVal vIDPromotor As Integer, ByVal vIDLoja As Integer, ByVal vData As String) As Boolean

            Dim strXML As String = GetRoteiroAntigo(vIDPromotor, CDate(vData))
            Return _IniciarVisita(vIDPromotor, vIDLoja, strXML, vData)

        End Function

        Protected Function _IniciarVisita(ByVal vIDPromotor As Integer, ByVal vIDLoja As Integer, ByVal vXML As String, Optional ByVal vData As String = Nothing) As Boolean


            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_ROTEIRO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@IDRESPONSAVEL", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
            cmd.Parameters.Add("@XML", SqlDbType.Text).Value = vXML
            If Not String.IsNullOrEmpty(vData) Then
                cmd.Parameters.Add("@DATAVISITA", SqlDbType.Date).Value = vData
            End If
            
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

            Me.User.Log("Formulario de Visitas do Promotor", "IniciarVisita - IDPROMOTOR=" & vIDPromotor & " IDRESPONSAVEL=" & User.IDUser & " IDLOJA=" & vIDLoja & " XML=" & vXML)

        End Function


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDPromotor">Chave primaria vIDPromotor</param>
        ''' <param name="vIDLoja">Chave primaria vIDLoja</param>
        ''' <returns>Boolean</returns>
        Public Overloads Function IniciarVisita(ByVal vIDPromotor As Integer, ByVal vIDLoja As Integer) As Boolean

            Dim strXML As String = GetRoteiro(vIDPromotor)
            Return _IniciarVisita(vIDPromotor, vIDLoja, strXML, Nothing)

        End Function


        Public Function ListarCategorias() As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_VISITA_CATEGORIAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            Return ExecuteReader(cmd)

        End Function

        Public Function ListarMarcas(ByVal vIDCategoria As Integer) As IDataReader


            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_VISITA_MARCAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria

            Return ExecuteReader(cmd)

        End Function

        Public Function ListarProdutos(ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, ByVal vIDFornecedor As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_VISITA_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDFORNECEDOR", SqlDbType.Int).Value = vIDFornecedor

            Return ExecuteCommand(cmd, vReturnType)

        End Function

        Public Function ListarMotivosUsoForm(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_MOTIVOUSOFORM"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            Return ExecuteCommand(cmd, vReturnType)
        End Function


        Public Function GravarEntidadePesquisa(ByVal vIDVisita As Integer, ByVal vIDUsuario As Integer, ByVal vIDEmpresa As Integer, ByVal vTipoEntidade As enTipoEntidade, ByVal vIDReferencia As Integer, ByVal vIDPesquisa As Integer, ByVal vXML As String) As Boolean
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "BS_GRAVAR_ENTIDADE_PESQUISA"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita
            cmd.Parameters.Add("@TIPOENTIDADE", SqlDbType.Int).Value = vTipoEntidade
            cmd.Parameters.Add("@IDREFERENCIA", SqlDbType.Int).Value = vIDReferencia
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIDPesquisa
            cmd.Parameters.Add("@XML", SqlDbType.Text).Value = vXML
            Return MyBase.ExecuteScalar(cmd)
        End Function

        Public Function ApagarEntidadePesquisa(ByVal vIDVisita As Integer, ByVal vIDUsuario As Integer, ByVal vIDEmpresa As Integer, ByVal vTipoEntidade As enTipoEntidade, ByVal vIDReferencia As Integer, ByVal vIDPesquisa As Integer) As Boolean
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "BS_APAGAR_ENTIDADE_PESQUISA"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita
            cmd.Parameters.Add("@TIPOENTIDADE", SqlDbType.Int).Value = vTipoEntidade
            cmd.Parameters.Add("@IDREFERENCIA", SqlDbType.Int).Value = vIDReferencia
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIDPesquisa
            Return MyBase.ExecuteScalar(cmd)
        End Function


        Public Function ListarPerguntas(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_VISITA_PERGUNTAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita

            Return ExecuteCommand(cmd, vReturnType)
        End Function

        Public Function ListarProdutosPerguntas(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_VISITA_PRODUTOS_PERGUNTAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita

            Return ExecuteCommand(cmd, vReturnType)
        End Function

        Public Function ListarProdutosFormulario(ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, ByVal vIDFornecedor As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As IPaginaResult
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_VISITA_PRODUTOS_FORMULARIO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDFORNECEDOR", SqlDbType.Int).Value = vIDFornecedor
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            Return ExecutePaginate(cmd, enReturnType.DataSet, vPageSize, vPage)
        End Function

        Public Function BuscarLojasAdicionar(ByVal vIDPromotor As Integer, ByVal vFiltro As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As IPaginaResult
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_LOJAS_ADICIONAR"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar).Value = vFiltro
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)
        End Function


        Public Function ListarPerguntasFormulario(ByVal vTipoEntidade As enTipoEntidade, ByVal vIDReferencia As Integer, ByVal vIDPesquisa As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As IPaginaResult
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_VISITA_PERGUNTAS_FORMULARIO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@TIPOENTIDADE", SqlDbType.TinyInt).Value = vTipoEntidade
            cmd.Parameters.Add("@IDREFERENCIA", SqlDbType.Int).Value = vIDReferencia
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIDPesquisa
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            Return ExecutePaginate(cmd, enReturnType.DataSet, vPageSize, vPage)
        End Function

        Public Function AdicionarLojaRoteiro(ByVal vIDPromotor As Integer, ByVal vIDLoja As Integer) As String
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_LOJAS_ADICIONAR"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
            Return ExecuteScalar(cmd)
        End Function


        Public Function PromotorPermiteAdicionarLoja(ByVal vIDUsuario As Integer) As Byte
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_USUARIO_PERMITEADICIONARLOJA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
            Return ExecuteScalar(cmd)
        End Function



        Public Function VisitaCompleta() As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_VISITA_COMPLETA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDRESPONSAVEL", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita

            Return ExecuteScalar(cmd)

        End Function

        Public Sub FinalizarVisita()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "BS_VISITA_FINALIZAR"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDRESPONSAVEL", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita

            ExecuteNonQuery(cmd)

            Me.User.Log("Formulario de Visitas do Promotor", "FinalizarVisita - IDRESPONSAVEL=" & User.IDUser & " IDVISITA=" & m_intIDVisita)

        End Sub


        Public Class clsFormProduto
            Inherits BaseClass

            Protected m_intIDVisita As Integer
            Protected m_intIDProduto As Integer
            Protected m_strCodigo As String
            Protected m_varEncontrado As Boolean
            Protected m_decPreco As Decimal
            Protected m_indVisualizouEstoque As Byte
            Protected m_intEstoque As Integer
            Protected m_intAcao As Byte

            Public Enum enAcao As Byte
                Nada = 0
                Estoque = 1
                Preco = 2
                Perguntas = 4
            End Enum

            Public Enum Visualizou As Byte
                Sim = 1
                Nao = 0
                NaoPermitido = 2
            End Enum

            Public Sub New()
                PREFIXO = "SP_REP_WEB_FRM_"
            End Sub

#Region "Properties"
            Public Overridable ReadOnly Property IDVisita() As Integer
                Get
                    Return m_intIDVisita
                End Get
            End Property

            Public Overridable ReadOnly Property IDProduto() As Integer
                Get
                    Return m_intIDProduto
                End Get
            End Property

            Public Overridable ReadOnly Property Codigo() As String
                Get
                    Return m_strCodigo
                End Get
            End Property

            Public Overridable Property Encontrado() As Boolean
                Get
                    Return m_varEncontrado
                End Get
                Set(ByVal Value As Boolean)
                    m_varEncontrado = Value
                End Set
            End Property

            Public Overridable Property Preco() As Decimal
                Get
                    Return m_decPreco
                End Get
                Set(ByVal Value As Decimal)
                    m_decPreco = Value
                End Set
            End Property

            Public Overridable Property VisualizouEstoque() As Visualizou
                Get
                    Return m_indVisualizouEstoque
                End Get
                Set(ByVal Value As Visualizou)
                    m_indVisualizouEstoque = Value
                End Set
            End Property

            Public Overridable Property Estoque() As Integer
                Get
                    Return m_intEstoque
                End Get
                Set(ByVal Value As Integer)
                    m_intEstoque = Value
                End Set
            End Property

            Public ReadOnly Property Acao() As enAcao
                Get
                    Return m_intAcao
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
                m_intIDProduto = dr.GetInt32(dr.GetOrdinal("IDProduto"))
                If dr.IsDBNull(dr.GetOrdinal("Codigo")) Then
                    m_strCodigo = ""
                Else
                    m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("Encontrado")) Then
                    m_varEncontrado = Nothing
                Else
                    m_varEncontrado = dr.GetBoolean(dr.GetOrdinal("Encontrado"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("Preco")) Then
                    m_decPreco = Nothing
                Else
                    m_decPreco = dr.GetDecimal(dr.GetOrdinal("Preco"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("VisualizouEstoque")) Then
                    m_indVisualizouEstoque = 0
                Else
                    m_indVisualizouEstoque = dr.GetByte(dr.GetOrdinal("VisualizouEstoque"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("Estoque")) Then
                    m_intEstoque = 0
                Else
                    m_intEstoque = dr.GetInt32(dr.GetOrdinal("Estoque"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("Acao")) Then
                    m_intAcao = 0
                Else
                    m_intAcao = dr.GetByte(dr.GetOrdinal("Acao"))
                End If

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
                cmd.Parameters.Add("@ENCONTRADO", SqlDbType.Bit).Value = m_varEncontrado
                cmd.Parameters.Add("@PRECO", SqlDbType.Money).Value = m_decPreco
                cmd.Parameters.Add("@VISUALIZOUESTOQUE", SqlDbType.TinyInt).Value = m_indVisualizouEstoque
                cmd.Parameters.Add("@ESTOQUE", SqlDbType.Int).Value = m_intEstoque

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

            End Function

            ''' <summary>
            ''' 	Função interna que limpa as variaveis internas
            ''' </summary>
            Protected Sub Clear()
                m_intIDVisita = 0
                m_intIDProduto = 0
                m_varEncontrado = Nothing
                m_decPreco = Nothing
                m_indVisualizouEstoque = 0
                m_intEstoque = 0
                m_intAcao = 0
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

                Me.User.Log("Formulario de Visitas do Promotor", "Apagar - IDVISITA=" & m_intIDVisita & " IDPRODUTO=" & m_intIDProduto)

                MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'VisitaProduto' the following row:  IDVisita=" & m_intIDVisita & " IDEmpresa=" & User.IDEmpresa & " IDProduto=" & m_intIDProduto & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
                Clear()

            End Sub

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
                cmd.CommandText = PREFIXO & "DE_PERGUNTARESPOSTAS"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
                cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
                cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta
                MyBase.ExecuteNonQuery(cmd)

            End Sub

            Public Sub LimparRespostas()

                Dim cmd As New SqlCommand()
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "DE_PERGUNTARESPOSTAS"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
                cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = m_intIDProduto
                MyBase.ExecuteNonQuery(cmd)

            End Sub


            Public Sub AdicionarRespostas(ByVal vIDPergunta As Integer, ByVal vRespostas() As String)

                LimparRespostas(vIDPergunta)

                Dim cmd As New SqlCommand()
                Dim cn As SqlConnection = GetDBConnection()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "IN_PERGUNTA_RESPOSTA"
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






            End Sub

            Public Function ListarRespostas(ByVal vIDPergunta As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

                Return ListarRespostas(m_intIDProduto, m_intIDVisita, vIDPergunta, vReturnType)

            End Function

            Public Function ListarRespostas(ByVal vIDProduto As Integer, ByVal vIDVisita As Integer, ByVal vIDPergunta As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

                Dim cmd As New SqlCommand()
                cmd.CommandText = PREFIXO & "LS_PERGUNTARESPOSTAS"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita
                cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
                cmd.Parameters.Add("@IDPERGUNTA", SqlDbType.Int).Value = vIDPergunta
                Return MyBase.ExecuteCommand(cmd, vReturnType)

            End Function

            Public Function GravarPesquisa(ByVal vIDVisita As Integer, ByVal vIDUsuario As Integer, ByVal vIDEmpresa As Integer, ByVal vIDProduto As Integer, ByVal vXML As String) As Boolean
                Dim cmd As New SqlCommand()
                cmd.CommandText = PREFIXO & "BS_GRAVAR_PRODUTO_PESQUISA"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
                cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita
                cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
                cmd.Parameters.Add("@XML", SqlDbType.Text).Value = vXML
                Return MyBase.ExecuteScalar(cmd)
            End Function



#End Region

        End Class



    End Class


End Namespace
