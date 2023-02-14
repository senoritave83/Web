Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager


Namespace Classes


    Public Class clsReports

        Inherits BaseClass

#Region "Classes dos Relatorios"

        Public Class RelatorioData

            Private m_Data As Object
            Private m_Header As Object
            Private m_Side As Object
            Private m_Sucess As Boolean

            Public Sub New()
                m_Header = Nothing
                m_Data = Nothing
                m_Sucess = False
            End Sub

            Public Sub New(ByVal vData As IDataReader, ByVal vSucess As Boolean)
                m_Header = Nothing
                m_Data = vData
                m_Sucess = vSucess
            End Sub

            Public Sub New(ByVal vHeader As DataSet, ByVal vSucess As Boolean)
                m_Header = vHeader
                m_Data = Nothing
                m_Sucess = vSucess
            End Sub

            Public Sub New(ByVal vHeader As DataSet, ByVal vSide As DataSet, ByVal vData As IDataReader, ByVal vSucess As Boolean)
                m_Header = vHeader
                m_Data = vData
                m_Side = vSide
                m_Sucess = vSucess
            End Sub


            Public Sub New(ByVal vHeader As DataSet, ByVal vData As IDataReader, ByVal vSucess As Boolean)
                m_Header = vHeader
                m_Data = vData
                m_Sucess = vSucess
            End Sub

            Public Sub New(ByVal vHeader As IDataReader, ByVal vData As IDataReader, ByVal vSucess As Boolean)
                m_Header = vHeader
                m_Data = vData
                m_Sucess = vSucess
            End Sub

            Public Sub New(ByVal vHeader As DataSet, ByVal vData As DataSet, ByVal vSucess As Boolean)
                m_Header = vHeader
                m_Data = vData
                m_Sucess = vSucess
            End Sub

            Public Sub New(ByVal vHeader As IDataReader, ByVal vData As DataSet, ByVal vSucess As Boolean)
                m_Header = vHeader
                m_Data = vData
                m_Sucess = vSucess
            End Sub

            Public ReadOnly Property Header() As Object
                Get
                    Return m_Header
                End Get
            End Property

            Public ReadOnly Property Data() As Object
                Get
                    Return m_Data
                End Get
            End Property

            Public ReadOnly Property Side() As Object
                Get
                    Return m_Side
                End Get
            End Property



            Public ReadOnly Property Sucess() As Boolean
                Get
                    Return m_Sucess
                End Get
            End Property

        End Class

#End Region

        Public Function verificaFila(ByVal p_Guid As String) As DataSet

            Dim cmd As New SqlCommand()

            cmd.CommandText = PREFIXO & "RPT_VERIFICAFILA"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDREPORT", SqlDbType.UniqueIdentifier).Value = New System.Guid(p_Guid)

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function

        Public Function cancelarFila(ByVal p_Guid As String) As Boolean

            Dim cmd As New SqlCommand()

            cmd.CommandText = PREFIXO & "RPT_CANCELARFILA"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDREPORT", SqlDbType.UniqueIdentifier).Value = New System.Guid(p_Guid)

            MyBase.ExecuteNonQuery(cmd)

            Return True

        End Function

        Public Function saveURLReport(ByVal p_NomeRelatorio As String, ByVal p_Parameters As String, _
                                      ByVal p_IdUsuario As Integer, ByVal p_Caminho As String, _
                                      ByVal p_Arquivo As String, ByVal p_Chave As String) As String

            Dim p_SQL As String = ""
            Dim cmd As New SqlCommand()
            Dim p_returnGuid As String = ""

            cmd.CommandText = PREFIXO & "RPT_SAVEREPORT"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@NOMERELATORIO", SqlDbType.VarChar).Value = p_NomeRelatorio
            cmd.Parameters.Add("@PARAMETROS", SqlDbType.Text).Value = p_Parameters
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = p_IdUsuario
            cmd.Parameters.Add("@CAMINHO", SqlDbType.VarChar).Value = p_Caminho
            cmd.Parameters.Add("@ARQUIVO", SqlDbType.VarChar).Value = p_Arquivo
            cmd.Parameters.Add("@CHAVE", SqlDbType.VarChar).Value = p_Chave

            Dim dr As SqlDataReader = MyBase.ExecuteCommand(cmd, enReturnType.DataReader)
            If dr.Read Then
                p_returnGuid = dr("Guid").ToString()
            End If

            Return p_returnGuid

            Me.User.Log("Reports", "saveURLReport - NOMERELATORIO=" & p_NomeRelatorio & " PARAMETROS=" & p_Parameters & " CAMINHO=" & p_Caminho & " ARQUIVO=" & _
                        p_Arquivo & " CHAVE=" & p_Chave)

        End Function

        Public Function loadURLReport(ByVal p_Guid As String) As String

            Dim p_SQL As String = ""
            Dim cmd As New SqlCommand()
            Dim p_returnURL As String = ""

            cmd.CommandText = PREFIXO & "RPT_LOADREPORT"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@GUID", SqlDbType.VarChar).Value = p_Guid

            Dim dr As SqlDataReader = MyBase.ExecuteCommand(cmd, enReturnType.DataReader)
            If dr.Read Then
                p_returnURL = dr("PARAMETERS").ToString()
            End If

            Return p_returnURL

            Me.User.Log("Reports", "loadURLReport - GUID=" & p_Guid)

        End Function

        Public Function getRelatorioMostruarioResumo(ByVal p_IdRegiao As String, ByVal p_IdEstados As String, ByVal p_IdTipoLoja As String, ByVal p_Shopping As String, ByVal p_Lojas As String, _
                                          ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String) As IDataReader


            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_MOSTRUARIO_FASTSHOP_RESUMO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.VarChar).Value = p_IdRegiao
            cmd.Parameters.Add("@UF", SqlDbType.VarChar).Value = p_IdEstados
            cmd.Parameters.Add("@TIPOLOJA", SqlDbType.VarChar).Value = p_IdTipoLoja
            cmd.Parameters.Add("@SHOPPINGS", SqlDbType.VarChar).Value = p_Shopping
            cmd.Parameters.Add("@LOJAS", SqlDbType.VarChar).Value = p_Lojas

            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = p_PeriodoInicial
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = p_PeriodoFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function getRelatorioMostruarioTotal(ByVal p_IdRegiao As String, ByVal p_IdEstados As String, ByVal p_IdTipoLoja As String, _
                                                    ByVal p_Shopping As String, ByVal p_Lojas As String, ByVal p_Categoria As String, _
                                                    ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String) As IDataReader


            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_MOSTRUARIO_FASTSHOP_TOTAL"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.VarChar).Value = p_IdRegiao
            cmd.Parameters.Add("@UF", SqlDbType.VarChar).Value = p_IdEstados
            cmd.Parameters.Add("@TIPOLOJA", SqlDbType.VarChar).Value = p_IdTipoLoja
            cmd.Parameters.Add("@SHOPPINGS", SqlDbType.VarChar).Value = p_Shopping
            cmd.Parameters.Add("@LOJAS", SqlDbType.VarChar).Value = p_Lojas
            cmd.Parameters.Add("@SUBCATEGORIA", SqlDbType.VarChar).Value = p_Categoria

            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = p_PeriodoInicial
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = p_PeriodoFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function getRelatorioMostruarioTotalLinhas(ByVal p_IdRegiao As String, ByVal p_IdEstados As String, ByVal p_IdTipoLoja As String, _
                                                ByVal p_Shopping As String, ByVal p_Lojas As String, ByVal p_Categoria As String, _
                                                ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String) As IDataReader


            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_MOSTRUARIO_FASTSHOP_TOTAL_LINHAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.VarChar).Value = p_IdRegiao
            cmd.Parameters.Add("@UF", SqlDbType.VarChar).Value = p_IdEstados
            cmd.Parameters.Add("@TIPOLOJA", SqlDbType.VarChar).Value = p_IdTipoLoja
            cmd.Parameters.Add("@SHOPPINGS", SqlDbType.VarChar).Value = p_Shopping
            cmd.Parameters.Add("@LOJAS", SqlDbType.VarChar).Value = p_Lojas
            cmd.Parameters.Add("@SUBCATEGORIA", SqlDbType.VarChar).Value = p_Categoria

            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = p_PeriodoInicial
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = p_PeriodoFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function getRelatorioMostruario(ByVal p_IdRegiao As String, ByVal p_IdEstados As String, ByVal p_IdTipoLoja As String, ByVal p_Shopping As String, ByVal p_Lojas As String, _
                                              ByVal p_Periodo As String) As RelatorioData


            Dim dtsHeader As DataSet
            Dim dtsProdutos As DataSet
            Dim drData As IDataReader


            Dim cmdHeader As New SqlCommand()
            With cmdHeader
                .CommandText = PREFIXO & "RPT_MOSTRUARIO_FASTSHOP_HEADER"
                .Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                .Parameters.Add("@IDREGIAO", SqlDbType.VarChar).Value = p_IdRegiao
                .Parameters.Add("@UF", SqlDbType.VarChar).Value = p_IdEstados
                .Parameters.Add("@TIPOLOJA", SqlDbType.VarChar).Value = p_IdTipoLoja
                .Parameters.Add("@SHOPPINGS", SqlDbType.VarChar).Value = p_Shopping
                .Parameters.Add("@LOJAS", SqlDbType.VarChar).Value = p_Lojas
            End With
            dtsHeader = ExecuteCommand(cmdHeader, enReturnType.DataSet)
            cmdHeader.Dispose()

            Dim cmdSide As New SqlCommand()
            With cmdSide
                .CommandText = PREFIXO & "RPT_MOSTRUARIO_FASTSHOP_PRODUTOS"
                .Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            End With
            dtsProdutos = ExecuteCommand(cmdSide, enReturnType.DataSet)
            cmdSide.Dispose()

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_MOSTRUARIO_FASTSHOP"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.VarChar).Value = p_IdRegiao
            cmd.Parameters.Add("@UF", SqlDbType.VarChar).Value = p_IdEstados
            cmd.Parameters.Add("@TIPOLOJA", SqlDbType.VarChar).Value = p_IdTipoLoja
            cmd.Parameters.Add("@SHOPPINGS", SqlDbType.VarChar).Value = p_Shopping
            cmd.Parameters.Add("@LOJAS", SqlDbType.VarChar).Value = p_Lojas
            cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = p_Periodo
            drData = ExecuteCommand(cmd, enReturnType.DataReader)


            Return New RelatorioData(dtsHeader, dtsProdutos, drData, True)

        End Function

        Public Function ListarLojasMostruario() As IDataReader
            Return ListarLojasMostruario("", "", "", "")
        End Function

        Public Function ListarLojasMostruario(ByVal p_IdRegiao As String, ByVal p_IdEstados As String, ByVal p_IdTipoLoja As String, ByVal p_Shopping As String) As IDataReader


            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_MOSTRUARIO_FASTSHOP_LOJAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.VarChar).Value = p_IdRegiao
            cmd.Parameters.Add("@UF", SqlDbType.VarChar).Value = p_IdEstados
            cmd.Parameters.Add("@TIPOLOJA", SqlDbType.VarChar).Value = p_IdTipoLoja
            cmd.Parameters.Add("@SHOPPINGS", SqlDbType.VarChar).Value = p_Shopping

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function getRelatorioPrecos(ByVal p_IdEmpresa As Integer, ByVal p_IdClientes As String, ByVal p_IdLojas As String, _
                                          ByVal p_IdEstados As String, ByVal p_IdCategorias As String, ByVal p_IdSubCategorias As String, _
                                          ByVal p_IdProdutos As String, ByVal p_IdTipoLoja As String, ByVal p_IdRegiao As String, ByVal p_IdStatus As String, _
                                          ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String, ByVal p_Shopping As String) As RelatorioData


            Dim ret As RelatorioData = Nothing
            Dim blnInTransaction As Boolean = False
            Dim m_strConnection As String = ConnectionStrings.Item("cnStr").ConnectionString
            Dim p_SQL As String = ""

            Try

                Dim cn As New SqlConnection(m_strConnection)
                Dim cmd As SqlCommand

                Try

                    cn.Open()

                    'If Not blnInTransaction Then
                    '    cmd = New SqlCommand("BEGIN TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = True
                    'End If

                    '*****************************************
                    'INICIANDO CRIAÇÃO DAS TABELAS TEMPORÁRIAS
                    '*****************************************
                    cmd = New SqlCommand("CREATE TABLE #TBL_PRODUTOS(IdProduto int)", cn)
                    cmd.ExecuteNonQuery()

                    If p_IdProdutos <> "" Then

                        p_SQL = "INSERT INTO #TBL_PRODUTOS "
                        p_SQL &= "SELECT PRD_PRODUTO_INT_PK FROM TB_REP_PRODUTO_PRD (NOLOCK) "
                        p_SQL &= "WHERE PRD_PRODUTO_INT_PK IN (" & IIf(p_IdProdutos.Trim().EndsWith(","), Left(p_IdProdutos.Trim(), Len(p_IdProdutos.Trim()) - 1), p_IdProdutos.Trim()) & ")"
                        'If p_Marca <> "" Then
                        '    p_SQL &= "AND FOR_FORNECEDOR_INT_FK IN (" & IIf(p_Marca.Trim().EndsWith(","), Left(p_Marca.Trim(), Len(p_Marca.Trim()) - 1), p_Marca.Trim()) & ")"
                        'End If
                        p_SQL &= "AND EMP_EMPRESA_INT_FK = " & Me.User.IDEmpresa
                        cmd = New SqlCommand(p_SQL, cn)
                        cmd.ExecuteNonQuery()

                    ElseIf p_IdSubCategorias <> "" Then

                        p_SQL = "INSERT INTO #TBL_PRODUTOS "
                        p_SQL &= "SELECT PRD_PRODUTO_INT_PK FROM TB_REP_PRODUTO_PRD PRD (NOLOCK) "
                        p_SQL &= "WHERE SCT_SUBCATEGORIA_INT_FK IN (" & IIf(p_IdSubCategorias.Trim().EndsWith(","), Left(p_IdSubCategorias.Trim(), Len(p_IdSubCategorias.Trim()) - 1), p_IdSubCategorias.Trim()) & ")"
                        'If p_Marca <> "" Then
                        '    p_SQL &= "AND FOR_FORNECEDOR_INT_FK IN (" & IIf(p_Marca.Trim().EndsWith(","), Left(p_Marca.Trim(), Len(p_Marca.Trim()) - 1), p_Marca.Trim()) & ")"
                        'End If
                        p_SQL &= "AND EMP_EMPRESA_INT_FK = " & Me.User.IDEmpresa

                        cmd = New SqlCommand(p_SQL, cn)
                        cmd.ExecuteNonQuery()

                    ElseIf p_IdCategorias <> "" Then

                        p_SQL = "INSERT INTO #TBL_PRODUTOS "
                        p_SQL &= "SELECT PRD_PRODUTO_INT_PK FROM TB_REP_PRODUTO_PRD PRD (NOLOCK) "
                        p_SQL &= "INNER JOIN TB_REP_SUBCATEGORIA_SCT SCT (NOLOCK) ON SCT_SUBCATEGORIA_INT_FK = SCT_SUBCATEGORIA_INT_PK AND PRD.EMP_EMPRESA_INT_FK = SCT.EMP_EMPRESA_INT_FK WHERE CAT_CATEGORIA_INT_FK IN (" & IIf(p_IdCategorias.Trim().EndsWith(","), Left(p_IdCategorias.Trim(), Len(p_IdCategorias.Trim()) - 1), p_IdCategorias.Trim()) & ")"
                        'If p_Marca <> "" Then
                        '    p_SQL &= "AND FOR_FORNECEDOR_INT_FK IN (" & IIf(p_Marca.Trim().EndsWith(","), Left(p_Marca.Trim(), Len(p_Marca.Trim()) - 1), p_Marca.Trim()) & ")"
                        'End If
                        p_SQL &= "AND PRD.EMP_EMPRESA_INT_FK = " & Me.User.IDEmpresa
                        cmd = New SqlCommand(p_SQL, cn)
                        cmd.ExecuteNonQuery()

                    End If

                    cmd = New SqlCommand("CREATE TABLE #TBL_LOJAS(IdLoja int)", cn)
                    cmd.ExecuteNonQuery()
                    If p_IdLojas <> "" Then
                        cmd = New SqlCommand("INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE LOJ_LOJA_INT_PK IN (" & IIf(p_IdLojas.Trim().EndsWith(","), Left(p_IdLojas.Trim(), Len(p_IdLojas.Trim()) - 1), p_IdLojas.Trim()) & ") AND EMP_EMPRESA_INT_FK = " & Me.User.IDEmpresa, cn)
                        cmd.ExecuteNonQuery()
                    ElseIf p_IdClientes <> "" Then
                        cmd = New SqlCommand("INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE CLI_CLIENTE_INT_FK IN (" & IIf(p_IdClientes.Trim().EndsWith(","), Left(p_IdClientes.Trim(), Len(p_IdClientes.Trim()) - 1), p_IdClientes.Trim()) & ") AND EMP_EMPRESA_INT_FK = " & Me.User.IDEmpresa, cn)
                        cmd.ExecuteNonQuery()
                    Else
                        cmd = New SqlCommand("INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE EMP_EMPRESA_INT_FK = " & Me.User.IDEmpresa, cn)
                        cmd.ExecuteNonQuery()
                    End If

                    p_SQL = "SP_REP_WEB_RPT_CLIENTES_LOJAS_NEW " & p_IdEmpresa & ",'" & _
                          p_IdEstados & "','" & p_IdTipoLoja & "','" & p_IdRegiao & "','" & p_IdStatus & "'," & _
                          checkDate(p_PeriodoInicial, True, True) & "," & _
                          checkDate(p_PeriodoFinal, True, True) & ",'" & p_Shopping & "'"

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    da.Fill(ds, "Header")

                    p_SQL = "SP_REP_WEB_RPT_ANALISEPRECO_PRECOS_NEW " & Me.User.IDEmpresa & "," & _
                                                                        checkDate(p_PeriodoInicial, True, True) & "," & _
                                                                        checkDate(p_PeriodoFinal, True, True)

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

                    ret = New RelatorioData(ds, dr, True)

                    'If blnInTransaction Then
                    '    cmd = New SqlCommand("COMMIT TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = False
                    'End If

                Catch ex As Exception

                    'If blnInTransaction Then
                    '    cmd = New SqlCommand("ROLLBACK TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = False
                    'End If

                    Throw ex

                Finally
                    'If (Not cn Is Nothing) Then
                    '    cn.Close()
                    '    cn = Nothing
                    'End If
                End Try
            Catch ex As Exception
                ret = New RelatorioData()
                Throw ex

            End Try

            Return ret

        End Function

        Public Function getRelatorioEstoque(ByVal p_IdEmpresa As Integer, ByVal p_IdClientes As String, ByVal p_IdLojas As String, _
                                          ByVal p_IdEstados As String, ByVal p_IdCategorias As String, ByVal p_IdSubCategorias As String, _
                                          ByVal p_IdProdutos As String, ByVal p_IdTipoLoja As String, ByVal p_IdRegiao As String, ByVal p_IdStatus As String, _
                                          ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String, ByVal p_Shopping As String) As RelatorioData


            Dim ret As RelatorioData = Nothing
            Dim blnInTransaction As Boolean = False
            Dim m_strConnection As String = ConnectionStrings.Item("cnStr").ConnectionString
            Dim p_SQL As String = ""

            Try

                Dim cn As New SqlConnection(m_strConnection)
                Dim cmd As SqlCommand

                Try

                    cn.Open()

                    'If Not blnInTransaction Then
                    '    cmd = New SqlCommand("BEGIN TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = True
                    'End If

                    '*****************************************
                    'INICIANDO CRIAÇÃO DAS TABELAS TEMPORÁRIAS
                    '*****************************************
                    cmd = New SqlCommand("CREATE TABLE #TBL_PRODUTOS(IdProduto int)", cn)
                    cmd.ExecuteNonQuery()

                    If p_IdProdutos <> "" Then

                        p_SQL = "INSERT INTO #TBL_PRODUTOS "
                        p_SQL &= "SELECT PRD_PRODUTO_INT_PK FROM TB_REP_PRODUTO_PRD (NOLOCK) "
                        p_SQL &= "WHERE PRD_PRODUTO_INT_PK IN (" & IIf(p_IdProdutos.Trim().EndsWith(","), Left(p_IdProdutos.Trim(), Len(p_IdProdutos.Trim()) - 1), p_IdProdutos.Trim()) & ")"

                        cmd = New SqlCommand(p_SQL, cn)
                        cmd.ExecuteNonQuery()

                    ElseIf p_IdSubCategorias <> "" Then

                        p_SQL = "INSERT INTO #TBL_PRODUTOS "
                        p_SQL &= "SELECT PRD_PRODUTO_INT_PK FROM TB_REP_PRODUTO_PRD (NOLOCK) "
                        p_SQL &= "WHERE SCT_SUBCATEGORIA_INT_FK IN (" & IIf(p_IdSubCategorias.Trim().EndsWith(","), Left(p_IdSubCategorias.Trim(), Len(p_IdSubCategorias.Trim()) - 1), p_IdSubCategorias.Trim()) & ")"

                        cmd = New SqlCommand(p_SQL, cn)
                        cmd.ExecuteNonQuery()

                    ElseIf p_IdCategorias <> "" Then

                        p_SQL = "INSERT INTO #TBL_PRODUTOS "
                        p_SQL &= "SELECT PRD_PRODUTO_INT_PK FROM TB_REP_PRODUTO_PRD (NOLOCK) "
                        p_SQL &= "INNER JOIN TB_REP_SUBCATEGORIA_SCT (NOLOCK) ON SCT_SUBCATEGORIA_INT_FK = SCT_SUBCATEGORIA_INT_PK WHERE CAT_CATEGORIA_INT_FK IN (" & IIf(p_IdCategorias.Trim().EndsWith(","), Left(p_IdCategorias.Trim(), Len(p_IdCategorias.Trim()) - 1), p_IdCategorias.Trim()) & ")"

                        cmd = New SqlCommand(p_SQL, cn)
                        cmd.ExecuteNonQuery()

                    End If

                    cmd = New SqlCommand("CREATE TABLE #TBL_LOJAS(IdLoja int)", cn)
                    cmd.ExecuteNonQuery()
                    If p_IdLojas <> "" Then
                        cmd = New SqlCommand("INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE LOJ_LOJA_INT_PK IN (" & IIf(p_IdLojas.Trim().EndsWith(","), Left(p_IdLojas.Trim(), Len(p_IdLojas.Trim()) - 1), p_IdLojas.Trim()) & ")", cn)
                        cmd.ExecuteNonQuery()
                    ElseIf p_IdClientes <> "" Then
                        cmd = New SqlCommand("INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE CLI_CLIENTE_INT_FK IN (" & IIf(p_IdClientes.Trim().EndsWith(","), Left(p_IdClientes.Trim(), Len(p_IdClientes.Trim()) - 1), p_IdClientes.Trim()) & ")", cn)
                        cmd.ExecuteNonQuery()
                    Else
                        cmd = New SqlCommand("INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) ", cn)
                        cmd.ExecuteNonQuery()
                    End If

                    p_SQL = "SP_REP_WEB_RPT_ANALISE_ESTOQUE_LOJAS " & p_IdEmpresa & ",'" & _
                          p_IdEstados & "','" & p_IdTipoLoja & "','" & p_IdRegiao & "','" & p_IdStatus & "'," & _
                          checkDate(p_PeriodoInicial, True, True) & "," & _
                          checkDate(p_PeriodoFinal, True, True) & "," & IIf(p_Shopping.Trim() = "", 0, 1)

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    da.Fill(ds, "Header")

                    p_SQL = "SP_REP_WEB_RPT_ANALISE_ESTOQUE " & Me.User.IDEmpresa & "," & _
                                                                        checkDate(p_PeriodoInicial, True, True) & "," & _
                                                                        checkDate(p_PeriodoFinal, True, True)

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

                    ret = New RelatorioData(ds, dr, True)

                    'If blnInTransaction Then
                    '    cmd = New SqlCommand("COMMIT TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = False
                    'End If

                Catch ex As Exception

                    'If blnInTransaction Then
                    '    cmd = New SqlCommand("ROLLBACK TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = False
                    'End If

                    Throw ex

                Finally
                    'If (Not cn Is Nothing) Then
                    '    cn.Close()
                    '    cn = Nothing
                    'End If
                End Try
            Catch ex As Exception
                ret = New RelatorioData()
                Throw ex

            End Try

            Return ret

        End Function

        Public Function getRelatorioVendas(ByVal p_IdEmpresa As Integer, ByVal p_IdClientes As String, ByVal p_IdLojas As String, _
                                          ByVal p_IdEstados As String, ByVal p_IdCategorias As String, ByVal p_IdSubCategorias As String, _
                                          ByVal p_IdProdutos As String, ByVal p_IdTipoLoja As String, ByVal p_IdRegiao As String, ByVal p_IdStatus As String, _
                                          ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String, ByVal p_Shopping As String, ByVal p_Marca As String, ByVal p_TipoVisualizacao As String) As RelatorioData


            Dim ret As RelatorioData = Nothing
            Dim blnInTransaction As Boolean = False
            Dim m_strConnection As String = ConnectionStrings.Item("cnStr").ConnectionString
            Dim p_SQL As String = ""

            Try

                Dim cn As New SqlConnection(m_strConnection)
                Dim cmd As SqlCommand

                Try

                    cn.Open()

                    'If Not blnInTransaction Then
                    '    cmd = New SqlCommand("BEGIN TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = True
                    'End If

                    '*****************************************
                    'INICIANDO CRIAÇÃO DAS TABELAS TEMPORÁRIAS
                    '*****************************************
                    cmd = New SqlCommand("CREATE TABLE #TBL_PRODUTOS(IdProduto int)", cn)
                    cmd.ExecuteNonQuery()

                    If p_IdProdutos <> "" Then

                        p_SQL = "INSERT INTO #TBL_PRODUTOS "
                        p_SQL &= "SELECT PRD_PRODUTO_INT_PK FROM TB_REP_PRODUTO_PRD (NOLOCK) "
                        p_SQL &= "WHERE PRD_PRODUTO_INT_PK IN (" & IIf(p_IdProdutos.Trim().EndsWith(","), Left(p_IdProdutos.Trim(), Len(p_IdProdutos.Trim()) - 1), p_IdProdutos.Trim()) & ")"
                        If p_Marca <> "" Then
                            p_SQL &= "AND FOR_FORNECEDOR_INT_FK IN (" & IIf(p_Marca.Trim().EndsWith(","), Left(p_Marca.Trim(), Len(p_Marca.Trim()) - 1), p_Marca.Trim()) & ")"
                        End If

                        cmd = New SqlCommand(p_SQL, cn)
                        cmd.ExecuteNonQuery()

                    ElseIf p_IdSubCategorias <> "" Then

                        p_SQL = "INSERT INTO #TBL_PRODUTOS "
                        p_SQL &= "SELECT PRD_PRODUTO_INT_PK FROM TB_REP_PRODUTO_PRD (NOLOCK) "
                        p_SQL &= "WHERE SCT_SUBCATEGORIA_INT_FK IN (" & IIf(p_IdSubCategorias.Trim().EndsWith(","), Left(p_IdSubCategorias.Trim(), Len(p_IdSubCategorias.Trim()) - 1), p_IdSubCategorias.Trim()) & ")"
                        If p_Marca <> "" Then
                            p_SQL &= "AND FOR_FORNECEDOR_INT_FK IN (" & IIf(p_Marca.Trim().EndsWith(","), Left(p_Marca.Trim(), Len(p_Marca.Trim()) - 1), p_Marca.Trim()) & ")"
                        End If

                        cmd = New SqlCommand(p_SQL, cn)
                        cmd.ExecuteNonQuery()

                    ElseIf p_IdCategorias <> "" Then

                        p_SQL = "INSERT INTO #TBL_PRODUTOS "
                        p_SQL &= "SELECT PRD_PRODUTO_INT_PK FROM TB_REP_PRODUTO_PRD (NOLOCK) "
                        p_SQL &= "INNER JOIN TB_REP_SUBCATEGORIA_SCT (NOLOCK) ON SCT_SUBCATEGORIA_INT_FK = SCT_SUBCATEGORIA_INT_PK WHERE CAT_CATEGORIA_INT_FK IN (" & IIf(p_IdCategorias.Trim().EndsWith(","), Left(p_IdCategorias.Trim(), Len(p_IdCategorias.Trim()) - 1), p_IdCategorias.Trim()) & ")"
                        If p_Marca <> "" Then
                            p_SQL &= "AND FOR_FORNECEDOR_INT_FK IN (" & IIf(p_Marca.Trim().EndsWith(","), Left(p_Marca.Trim(), Len(p_Marca.Trim()) - 1), p_Marca.Trim()) & ")"
                        End If

                        cmd = New SqlCommand(p_SQL, cn)
                        cmd.ExecuteNonQuery()

                    End If

                    cmd = New SqlCommand("CREATE TABLE #TBL_LOJAS(IdLoja int)", cn)
                    cmd.ExecuteNonQuery()
                    If p_IdLojas <> "" Then
                        cmd = New SqlCommand("INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE LOJ_LOJA_INT_PK IN (" & IIf(p_IdLojas.Trim().EndsWith(","), Left(p_IdLojas.Trim(), Len(p_IdLojas.Trim()) - 1), p_IdLojas.Trim()) & ")", cn)
                        cmd.ExecuteNonQuery()
                    ElseIf p_IdClientes <> "" Then
                        cmd = New SqlCommand("INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE CLI_CLIENTE_INT_FK IN (" & IIf(p_IdClientes.Trim().EndsWith(","), Left(p_IdClientes.Trim(), Len(p_IdClientes.Trim()) - 1), p_IdClientes.Trim()) & ")", cn)
                        cmd.ExecuteNonQuery()
                    Else
                        cmd = New SqlCommand("INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) ", cn)
                        cmd.ExecuteNonQuery()
                    End If

                    p_SQL = "SP_REP_WEB_RPT_ANALISE_VENDAS_LOJAS " & p_IdEmpresa & ",'" & _
                          p_IdEstados & "','" & p_IdTipoLoja & "','" & p_IdRegiao & "','" & p_IdStatus & "'," & _
                          checkDate(p_PeriodoInicial, True, True) & "," & _
                          checkDate(p_PeriodoFinal, True, True) & "," & IIf(p_Shopping.Trim() = "", 0, 1) & "," & p_TipoVisualizacao

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    da.Fill(ds, "Header")

                    p_SQL = "SP_REP_WEB_RPT_ANALISE_VENDAS " & Me.User.IDEmpresa & "," & _
                                                                        checkDate(p_PeriodoInicial, True, True) & "," & _
                                                                        checkDate(p_PeriodoFinal, True, True) & "," & p_TipoVisualizacao

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

                    ret = New RelatorioData(ds, dr, True)

                    'If blnInTransaction Then
                    '    cmd = New SqlCommand("COMMIT TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = False
                    'End If

                Catch ex As Exception

                    'If blnInTransaction Then
                    '    cmd = New SqlCommand("ROLLBACK TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = False
                    'End If

                    Throw ex

                Finally
                    'If (Not cn Is Nothing) Then
                    '    cn.Close()
                    '    cn = Nothing
                    'End If
                End Try
            Catch ex As Exception
                ret = New RelatorioData()
                Throw ex

            End Try

            Return ret

        End Function

        'Public Function getRelatorioRoteiros(ByVal p_IdEmpresa As Integer, ByVal p_IdCategoria As String, ByVal p_IdPromotores As String) As RelatorioData


        '    Dim ret As DataSet = Nothing
        '    Dim blnInTransaction As Boolean = False
        '    Dim m_strConnection As String = ConnectionStrings.Item("cnStr").ConnectionString
        '    Dim p_SQL As String = ""

        '    Try

        '        Dim cn As New SqlConnection(m_strConnection)
        '        Dim cmd As SqlCommand

        '        Try

        '            cn.Open()

        '            Dim ds As DataSet = Nothing

        '            p_SQL = "SP_REP_WEB_RPT_LS_ROTEIROS " & Me.User.IDEmpresa & ",'" & p_IdCategoria & "','" & p_IdPromotores & "'"

        '            cmd = New SqlCommand(p_SQL, cn)
        '            ret = GetDataSet(cmd)


        '        Catch ex As Exception

        '            Throw ex

        '        Finally

        '        End Try
        '    Catch ex As Exception
        '        ret = Nothing
        '        Throw ex

        '    End Try

        '    Return ret

        'End Function

        Public Function getRelatorioRuptura(ByVal p_IdEmpresa As Integer, ByVal p_IdClientes As String, ByVal p_IdLojas As String, _
                                          ByVal p_IdEstados As String, ByVal p_IdCategorias As String, ByVal p_IdSubCategorias As String, _
                                          ByVal p_IdProdutos As String, ByVal p_IdTipoLoja As String, ByVal p_IdRegiao As String, ByVal p_IdStatus As String, _
                                          ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String, ByVal p_Shopping As String, _
                                          ByVal p_Marca As String) As RelatorioData


            Dim ret As RelatorioData = Nothing
            Dim blnInTransaction As Boolean = False
            Dim m_strConnection As String = ConnectionStrings.Item("cnStr").ConnectionString
            Dim p_SQL As String = ""

            Try

                Dim cn As New SqlConnection(m_strConnection)
                Dim cmd As SqlCommand

                Try

                    cn.Open()

                    'If Not blnInTransaction Then
                    '    cmd = New SqlCommand("BEGIN TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = True
                    'End If

                    '*****************************************
                    'INICIANDO CRIAÇÃO DAS TABELAS TEMPORÁRIAS
                    '*****************************************
                    cmd = New SqlCommand("CREATE TABLE #TBL_PRODUTOS(IdProduto int)", cn)
                    cmd.ExecuteNonQuery()
                    If p_IdProdutos <> "" Then

                        p_SQL = "INSERT INTO #TBL_PRODUTOS "
                        p_SQL &= "SELECT PRD_PRODUTO_INT_PK FROM TB_REP_PRODUTO_PRD (NOLOCK) "
                        p_SQL &= "WHERE PRD_PRODUTO_INT_PK IN (" & IIf(p_IdProdutos.Trim().EndsWith(","), Left(p_IdProdutos.Trim(), Len(p_IdProdutos.Trim()) - 1), p_IdProdutos.Trim()) & ")"
                        If p_Marca <> "" Then
                            p_SQL &= "AND FOR_FORNECEDOR_INT_FK IN (" & IIf(p_Marca.Trim().EndsWith(","), Left(p_Marca.Trim(), Len(p_Marca.Trim()) - 1), p_Marca.Trim()) & ")"
                        End If

                        cmd = New SqlCommand(p_SQL, cn)
                        cmd.ExecuteNonQuery()

                    ElseIf p_IdSubCategorias <> "" Then

                        p_SQL = "INSERT INTO #TBL_PRODUTOS "
                        p_SQL &= "SELECT PRD_PRODUTO_INT_PK FROM TB_REP_PRODUTO_PRD (NOLOCK) "
                        p_SQL &= "WHERE SCT_SUBCATEGORIA_INT_FK IN (" & IIf(p_IdSubCategorias.Trim().EndsWith(","), Left(p_IdSubCategorias.Trim(), Len(p_IdSubCategorias.Trim()) - 1), p_IdSubCategorias.Trim()) & ")"
                        If p_Marca <> "" Then
                            p_SQL &= "AND FOR_FORNECEDOR_INT_FK IN (" & IIf(p_Marca.Trim().EndsWith(","), Left(p_Marca.Trim(), Len(p_Marca.Trim()) - 1), p_Marca.Trim()) & ")"
                        End If

                        cmd = New SqlCommand(p_SQL, cn)
                        cmd.ExecuteNonQuery()

                    ElseIf p_IdCategorias <> "" Then

                        p_SQL = "INSERT INTO #TBL_PRODUTOS "
                        p_SQL &= "SELECT PRD_PRODUTO_INT_PK FROM TB_REP_PRODUTO_PRD (NOLOCK) "
                        p_SQL &= "INNER JOIN TB_REP_SUBCATEGORIA_SCT (NOLOCK) ON SCT_SUBCATEGORIA_INT_FK = SCT_SUBCATEGORIA_INT_PK WHERE CAT_CATEGORIA_INT_FK IN (" & IIf(p_IdCategorias.Trim().EndsWith(","), Left(p_IdCategorias.Trim(), Len(p_IdCategorias.Trim()) - 1), p_IdCategorias.Trim()) & ")"
                        If p_Marca <> "" Then
                            p_SQL &= "AND FOR_FORNECEDOR_INT_FK IN (" & IIf(p_Marca.Trim().EndsWith(","), Left(p_Marca.Trim(), Len(p_Marca.Trim()) - 1), p_Marca.Trim()) & ")"
                        End If

                        cmd = New SqlCommand(p_SQL, cn)
                        cmd.ExecuteNonQuery()

                    End If

                    cmd = New SqlCommand("CREATE TABLE #TBL_LOJAS(IdLoja int)", cn)
                    cmd.ExecuteNonQuery()
                    If p_IdLojas <> "" Then
                        cmd = New SqlCommand("INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE LOJ_LOJA_INT_PK IN (" & IIf(p_IdLojas.Trim().EndsWith(","), Left(p_IdLojas.Trim(), Len(p_IdLojas.Trim()) - 1), p_IdLojas.Trim()) & ")", cn)
                        cmd.ExecuteNonQuery()
                    ElseIf p_IdClientes <> "" Then
                        cmd = New SqlCommand("INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE CLI_CLIENTE_INT_FK IN (" & IIf(p_IdClientes.Trim().EndsWith(","), Left(p_IdClientes.Trim(), Len(p_IdClientes.Trim()) - 1), p_IdClientes.Trim()) & ")", cn)
                        cmd.ExecuteNonQuery()
                    Else
                        cmd = New SqlCommand("INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) ", cn)
                        cmd.ExecuteNonQuery()
                    End If

                    p_SQL = "SP_REP_WEB_RPT_CLIENTES_LOJAS_RUPTURA " & p_IdEmpresa & ",'" & _
                          p_IdEstados & "','" & p_IdTipoLoja & "','" & p_IdRegiao & "','" & p_IdStatus & "'," & _
                          checkDate(p_PeriodoInicial, True, True) & "," & _
                          checkDate(p_PeriodoFinal, True, True) & "," & IIf(p_Shopping.Trim() = "", 0, 1)

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    da.Fill(ds, "Header")

                    p_SQL = "SP_REP_WEB_RPT_ANALISE_RUPTURA " & Me.User.IDEmpresa & "," & _
                                                                        checkDate(p_PeriodoInicial, True, True) & "," & _
                                                                        checkDate(p_PeriodoFinal, True, True)

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

                    ret = New RelatorioData(ds, dr, True)

                    'If blnInTransaction Then
                    '    cmd = New SqlCommand("COMMIT TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = False
                    'End If

                Catch ex As Exception

                    'If blnInTransaction Then
                    '    cmd = New SqlCommand("ROLLBACK TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = False
                    'End If

                    Throw ex

                Finally
                    'If (Not cn Is Nothing) Then
                    '    cn.Close()
                    '    cn = Nothing
                    'End If
                End Try
            Catch ex As Exception
                ret = New RelatorioData()
                Throw ex

            End Try

            Return ret

        End Function

        Public Function getRelatorioRoteiros(ByVal p_IdEmpresa As Integer, ByVal p_IdCliente As String, ByVal p_IdLoja As String, _
                                             ByVal p_IdShopping As String, ByVal p_IdCoordenadores As String, ByVal p_IdLideres As String, _
                                             ByVal p_IdPromotores As String, ByVal p_TipoLoja As String, ByVal p_Regiao As String, _
                                             ByVal p_StatusLoja As String, ByVal p_StatusPromotor As String, ByVal p_Estados As String, _
                                             ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String, ByVal p_Segmento As String) As DataSet


            Dim ret As DataSet = Nothing
            Dim blnInTransaction As Boolean = False
            Dim m_strConnection As String = ConnectionStrings.Item("cnStr").ConnectionString
            Dim p_SQL As String = ""

            Try

                Dim cn As New SqlConnection(m_strConnection)
                Dim cmd As SqlCommand

                Try

                    cn.Open()

                    'If Not blnInTransaction Then
                    '    cmd = New SqlCommand("BEGIN TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = True
                    'End If

                    '*****************************************
                    'INICIANDO CRIAÇÃO DAS TABELAS TEMPORÁRIAS
                    '*****************************************
                    cmd = New SqlCommand("CREATE TABLE #TBL_PROMOTORES(IdPromotor int)", cn)
                    cmd.ExecuteNonQuery()
                    Dim blnWhere As Boolean = False

                    p_SQL = "INSERT INTO #TBL_PROMOTORES SELECT PRO_PROMOTOR_INT_PK FROM TB_REP_PROMOTOR_PRO (NOLOCK) "

                    If p_IdPromotores <> "" And p_IdPromotores <> "0" Then
                        p_SQL = p_SQL & "WHERE PRO_PROMOTOR_INT_PK IN (" & IIf(p_IdPromotores.Trim().EndsWith(","), Left(p_IdPromotores.Trim(), Len(p_IdPromotores.Trim()) - 1), p_IdPromotores.Trim()) & ")"
                        blnWhere = True
                    ElseIf p_IdLideres <> "" And p_IdLideres <> "0" Then
                        p_SQL = p_SQL & "WHERE LID_LIDER_INT_FK IN (" & IIf(p_IdLideres.Trim().EndsWith(","), Left(p_IdLideres.Trim(), Len(p_IdLideres.Trim()) - 1), p_IdLideres.Trim()) & ")"
                        blnWhere = True
                    ElseIf p_IdCoordenadores <> "" And p_IdCoordenadores <> "0" Then
                        p_SQL = p_SQL & "INNER JOIN TB_REP_LIDER_LID LID (NOLOCK) ON LID_LIDER_INT_FK = LID_LIDER_INT_PK "
                        p_SQL = p_SQL & "WHERE CRD_COORDENADOR_INT_FK IN (" & IIf(p_IdCoordenadores.Trim().EndsWith(","), Left(p_IdCoordenadores.Trim(), Len(p_IdCoordenadores.Trim()) - 1), p_IdCoordenadores.Trim()) & ")"
                        blnWhere = True
                    End If

                    If p_Segmento <> "" And p_Segmento <> "0" Then
                        p_SQL = p_SQL & IIf(blnWhere, " and ", " where ") & "PRO_SEGMENTO_CHR = '" & p_Segmento & "'"
                        blnWhere = True
                    End If

                    p_SQL = p_SQL & IIf(blnWhere, " and ", " where ") & " " & IIf(p_StatusPromotor = "2", "1=1", "pro_ativo_ind=" & p_StatusPromotor)

                    cmd = New SqlCommand(p_SQL, cn)
                    cmd.ExecuteNonQuery()

                    cmd = New SqlCommand("CREATE TABLE #TBL_LOJAS(IdLoja int)", cn)
                    cmd.ExecuteNonQuery()

                    p_SQL = "INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE 1 = 1 "
                    If p_IdLoja <> "" And p_IdLoja <> "0" Then p_SQL &= " AND LOJ_LOJA_INT_PK IN (" & IIf(p_IdLoja.Trim().EndsWith(","), Left(p_IdLoja.Trim(), Len(p_IdLoja.Trim()) - 1), p_IdLoja.Trim()) & ")"
                    If p_IdCliente <> "" And p_IdCliente <> "0" Then p_SQL &= " AND CLI_CLIENTE_INT_FK IN (" & IIf(p_IdCliente.Trim().EndsWith(","), Left(p_IdCliente.Trim(), Len(p_IdCliente.Trim()) - 1), p_IdCliente.Trim()) & ")"
                    If p_TipoLoja <> "" Then p_SQL &= " AND tlj_TipoLoja_int_FK IN (" & IIf(p_TipoLoja.Trim().EndsWith(","), Left(p_TipoLoja.Trim(), Len(p_TipoLoja.Trim()) - 1), p_TipoLoja.Trim()) & ")"
                    If p_IdShopping <> "" And p_IdShopping <> "0" Then p_SQL &= " AND loj_Shopping_int_FK IN (" & IIf(p_IdShopping.Trim().EndsWith(","), Left(p_IdShopping.Trim(), Len(p_IdShopping.Trim()) - 1), p_IdShopping.Trim()) & ")"
                    If p_Regiao <> "" Then p_SQL &= " AND reg_Regiao_int_FK IN (" & IIf(p_Regiao.Trim().EndsWith(","), Left(p_Regiao.Trim(), Len(p_Regiao.Trim()) - 1), p_Regiao.Trim()) & ")"
                    If p_StatusLoja <> "2" Then p_SQL &= " AND loj_Status_ind=" & p_StatusLoja
                    If p_Estados <> "" Then p_SQL &= " AND loj_UF_chr IN ('" & IIf(p_Estados.Trim().EndsWith(","), Left(p_Estados.Trim(), Len(p_Estados.Trim()) - 1), p_Estados.Trim()).ToString().Replace(",", "','") & "')"

                    cmd = New SqlCommand(p_SQL, cn)
                    cmd.ExecuteNonQuery()

                    p_SQL = "SP_REP_WEB_RPT_RELATORIOROTEIROS " & p_IdEmpresa & "," & _
                          checkDate(p_PeriodoInicial, True, True) & "," & _
                          checkDate(p_PeriodoFinal, True, True)

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim da As SqlDataAdapter
                    Dim ds As New DataSet

                    da = New SqlDataAdapter(cmd)
                    da.SelectCommand.Connection = cn
                    da.Fill(ds, "data")

                    da = Nothing
                    cn.Close()
                    cn = Nothing

                    ret = ds

                Catch ex As Exception

                    Throw ex

                Finally

                End Try
            Catch ex As Exception

                ret = Nothing
                Throw ex

            End Try

            Return ret

        End Function

        Public Function getRelatorioRoteirosVertical(ByVal p_IdEmpresa As Integer, ByVal p_IdCliente As String, ByVal p_IdLoja As String, ByVal p_IdShopping As String, _
                                          ByVal p_IdCoordenadores As String, ByVal p_IdLideres As String, ByVal p_IdPromotores As String, _
                                          ByVal p_TipoLoja As String, ByVal p_Regiao As String, ByVal p_StatusLoja As String, ByVal p_StatusPromotor As String, _
                                          ByVal p_Estados As String, ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String) As DataSet


            Dim ret As DataSet = Nothing
            Dim blnInTransaction As Boolean = False
            Dim m_strConnection As String = ConnectionStrings.Item("cnStr").ConnectionString
            Dim p_SQL As String = ""

            Try

                Dim cn As New SqlConnection(m_strConnection)
                Dim cmd As SqlCommand

                Try

                    cn.Open()

                    'If Not blnInTransaction Then
                    '    cmd = New SqlCommand("BEGIN TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = True
                    'End If

                    '*****************************************
                    'INICIANDO CRIAÇÃO DAS TABELAS TEMPORÁRIAS
                    '*****************************************
                    cmd = New SqlCommand("CREATE TABLE #TBL_PROMOTORES(IdPromotor int)", cn)
                    cmd.ExecuteNonQuery()

                    Dim blnWhere As Boolean = False
                    If p_IdPromotores <> "" And p_IdPromotores <> "0" Then
                        p_SQL = "INSERT INTO #TBL_PROMOTORES SELECT PRO_PROMOTOR_INT_PK FROM TB_REP_PROMOTOR_PRO (NOLOCK) "
                        p_SQL = p_SQL & "WHERE PRO_PROMOTOR_INT_PK IN (" & IIf(p_IdPromotores.Trim().EndsWith(","), Left(p_IdPromotores.Trim(), Len(p_IdPromotores.Trim()) - 1), p_IdPromotores.Trim()) & ")"
                        blnWhere = True
                    ElseIf p_IdLideres <> "" And p_IdLideres <> "0" Then
                        p_SQL = "INSERT INTO #TBL_PROMOTORES SELECT PRO_PROMOTOR_INT_PK FROM TB_REP_PROMOTOR_PRO (NOLOCK) "
                        p_SQL = p_SQL & "WHERE LID_LIDER_INT_FK IN (" & IIf(p_IdLideres.Trim().EndsWith(","), Left(p_IdLideres.Trim(), Len(p_IdLideres.Trim()) - 1), p_IdLideres.Trim()) & ")"
                        blnWhere = True
                    ElseIf p_IdCoordenadores <> "" And p_IdCoordenadores <> "0" Then
                        p_SQL = "INSERT INTO #TBL_PROMOTORES SELECT PRO_PROMOTOR_INT_PK FROM TB_REP_PROMOTOR_PRO (NOLOCK) "
                        p_SQL = p_SQL & "INNER JOIN TB_REP_LIDER_LID LID (NOLOCK) ON LID_LIDER_INT_FK = LID_LIDER_INT_PK "
                        p_SQL = p_SQL & "WHERE CRD_COORDENADOR_INT_FK IN (" & IIf(p_IdCoordenadores.Trim().EndsWith(","), Left(p_IdCoordenadores.Trim(), Len(p_IdCoordenadores.Trim()) - 1), p_IdCoordenadores.Trim()) & ")"
                        blnWhere = True
                    Else
                        p_SQL = "INSERT INTO #TBL_PROMOTORES SELECT PRO_PROMOTOR_INT_PK FROM TB_REP_PROMOTOR_PRO (NOLOCK) "
                    End If
                    p_SQL = p_SQL & IIf(blnWhere, " and ", " where ") & " " & IIf(p_StatusPromotor = "2", "1=1", "pro_ativo_ind=" & p_StatusPromotor)

                    cmd = New SqlCommand(p_SQL, cn)
                    cmd.ExecuteNonQuery()

                    cmd = New SqlCommand("CREATE TABLE #TBL_LOJAS(IdLoja int)", cn)
                    cmd.ExecuteNonQuery()

                    p_SQL = "INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE 1 = 1 "
                    If p_IdLoja <> "" And p_IdLoja <> "0" Then p_SQL &= "AND LOJ_LOJA_INT_PK IN (" & IIf(p_IdLoja.Trim().EndsWith(","), Left(p_IdLoja.Trim(), Len(p_IdLoja.Trim()) - 1), p_IdLoja.Trim()) & ")"
                    If p_IdCliente <> "" And p_IdCliente <> "0" Then p_SQL &= "AND CLI_CLIENTE_INT_FK IN (" & IIf(p_IdCliente.Trim().EndsWith(","), Left(p_IdCliente.Trim(), Len(p_IdCliente.Trim()) - 1), p_IdCliente.Trim()) & ")"
                    If p_TipoLoja <> "" Then p_SQL &= "AND tlj_TipoLoja_int_FK IN (" & IIf(p_TipoLoja.Trim().EndsWith(","), Left(p_TipoLoja.Trim(), Len(p_TipoLoja.Trim()) - 1), p_TipoLoja.Trim()) & ")"
                    If p_IdShopping <> "" And p_IdShopping <> "0" Then p_SQL &= "AND loj_Shopping_int_FK IN (" & IIf(p_IdShopping.Trim().EndsWith(","), Left(p_IdShopping.Trim(), Len(p_IdShopping.Trim()) - 1), p_IdShopping.Trim()) & ")"
                    If p_Regiao <> "" Then p_SQL &= "AND reg_Regiao_int_FK IN (" & IIf(p_Regiao.Trim().EndsWith(","), Left(p_Regiao.Trim(), Len(p_Regiao.Trim()) - 1), p_Regiao.Trim()) & ")"
                    If p_StatusLoja <> "2" Then p_SQL &= " AND loj_Status_ind=" & p_StatusLoja
                    If p_Estados <> "" Then p_SQL &= "AND loj_UF_chr IN ('" & IIf(p_Estados.Trim().EndsWith(","), Left(p_Estados.Trim(), Len(p_Estados.Trim()) - 1), p_Estados.Trim()).ToString().Replace(",", "','") & "')"

                    cmd = New SqlCommand(p_SQL, cn)
                    cmd.ExecuteNonQuery()

                    p_SQL = "SP_REP_WEB_RPT_RELATORIOROTEIROSVERTICAL " & p_IdEmpresa & "," & _
                          checkDate(p_PeriodoInicial, True, True) & "," & _
                          checkDate(p_PeriodoFinal, True, True)

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim da As SqlDataAdapter
                    Dim ds As New DataSet

                    da = New SqlDataAdapter(cmd)
                    da.SelectCommand.Connection = cn
                    da.Fill(ds, "data")

                    da = Nothing
                    cn.Close()
                    cn = Nothing

                    ret = ds

                Catch ex As Exception

                    Throw ex

                Finally

                End Try
            Catch ex As Exception

                ret = Nothing
                Throw ex

            End Try

            Return ret

        End Function

        Public Function getRelatorioPerformance(ByVal p_IdEmpresa As Integer, ByVal p_IdCliente As String, ByVal p_IdLoja As String, ByVal p_IdShopping As String, _
                                            ByVal p_IdCoordenadores As String, ByVal p_IdLideres As String, ByVal p_IdPromotores As String, _
                                            ByVal p_TipoLoja As String, ByVal p_Regiao As String, ByVal p_StatusLoja As String, _
                                            ByVal p_TipoPesquisa As String, ByVal p_Estados As String, ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String) As RelatorioData


            Dim ret As RelatorioData = Nothing
            Dim blnInTransaction As Boolean = False
            Dim m_strConnection As String = ConnectionStrings.Item("cnStr").ConnectionString
            Dim p_SQL As String = ""

            Try

                Dim cn As New SqlConnection(m_strConnection)
                Dim cmd As SqlCommand

                Try

                    cn.Open()

                    'If Not blnInTransaction Then
                    '    cmd = New SqlCommand("BEGIN TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = True
                    'End If

                    '*****************************************
                    'INICIANDO CRIAÇÃO DAS TABELAS TEMPORÁRIAS
                    '*****************************************
                    cmd = New SqlCommand("CREATE TABLE #TBL_PROMOTORES(IdPromotor int)", cn)
                    cmd.ExecuteNonQuery()

                    If p_IdPromotores <> "" Then
                        p_SQL = "INSERT INTO #TBL_PROMOTORES SELECT PRO_PROMOTOR_INT_PK FROM TB_REP_PROMOTOR_PRO (NOLOCK) "
                        p_SQL = p_SQL & "WHERE PRO_PROMOTOR_INT_PK IN (" & IIf(p_IdPromotores.Trim().EndsWith(","), Left(p_IdPromotores.Trim(), Len(p_IdPromotores.Trim()) - 1), p_IdPromotores.Trim()) & ")"
                    ElseIf p_IdLideres <> "" Then
                        p_SQL = "INSERT INTO #TBL_PROMOTORES SELECT PRO_PROMOTOR_INT_PK FROM TB_REP_PROMOTOR_PRO (NOLOCK) "
                        p_SQL = p_SQL & "WHERE LID_LIDER_INT_FK IN (" & IIf(p_IdLideres.Trim().EndsWith(","), Left(p_IdLideres.Trim(), Len(p_IdLideres.Trim()) - 1), p_IdLideres.Trim()) & ")"
                    ElseIf p_IdCoordenadores <> "" Then
                        p_SQL = "INSERT INTO #TBL_PROMOTORES SELECT PRO_PROMOTOR_INT_PK FROM TB_REP_PROMOTOR_PRO (NOLOCK) "
                        p_SQL = p_SQL & "INNER JOIN TB_REP_LIDER_LID LID (NOLOCK) ON LID_LIDER_INT_FK = LID_LIDER_INT_PK "
                        p_SQL = p_SQL & "WHERE CRD_COORDENADOR_INT_FK IN (" & IIf(p_IdCoordenadores.Trim().EndsWith(","), Left(p_IdCoordenadores.Trim(), Len(p_IdCoordenadores.Trim()) - 1), p_IdCoordenadores.Trim()) & ")"
                    Else
                        p_SQL = "INSERT INTO #TBL_PROMOTORES SELECT PRO_PROMOTOR_INT_PK FROM TB_REP_PROMOTOR_PRO (NOLOCK) "
                    End If

                    cmd = New SqlCommand(p_SQL, cn)
                    cmd.ExecuteNonQuery()

                    cmd = New SqlCommand("CREATE TABLE #TBL_LOJAS(IdLoja int)", cn)
                    cmd.ExecuteNonQuery()

                    p_SQL = "INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE 1=1 "
                    If p_IdLoja <> "" Then p_SQL &= "AND LOJ_LOJA_INT_PK IN (" & IIf(p_IdLoja.Trim().EndsWith(","), Left(p_IdLoja.Trim(), Len(p_IdLoja.Trim()) - 1), p_IdLoja.Trim()) & ")"
                    If p_IdCliente <> "" Then p_SQL &= "AND CLI_CLIENTE_INT_FK IN (" & IIf(p_IdCliente.Trim().EndsWith(","), Left(p_IdCliente.Trim(), Len(p_IdCliente.Trim()) - 1), p_IdCliente.Trim()) & ")"
                    If p_TipoLoja <> "" Then p_SQL &= "AND tlj_TipoLoja_int_FK IN (" & IIf(p_TipoLoja.Trim().EndsWith(","), Left(p_TipoLoja.Trim(), Len(p_TipoLoja.Trim()) - 1), p_TipoLoja.Trim()) & ")"
                    If p_IdShopping <> "" Then p_SQL &= "AND loj_Shopping_int_FK IN (" & IIf(p_IdShopping.Trim().EndsWith(","), Left(p_IdShopping.Trim(), Len(p_IdShopping.Trim()) - 1), p_IdShopping.Trim()) & ")"
                    If p_Regiao <> "" Then p_SQL &= "AND reg_Regiao_int_FK IN (" & IIf(p_Regiao.Trim().EndsWith(","), Left(p_Regiao.Trim(), Len(p_Regiao.Trim()) - 1), p_Regiao.Trim()) & ")"
                    If p_StatusLoja <> "2" Then p_SQL &= "AND loj_Status_ind IN (" & IIf(p_StatusLoja.Trim().EndsWith(","), Left(p_StatusLoja.Trim(), Len(p_StatusLoja.Trim()) - 1), p_StatusLoja.Trim()) & ")"
                    If p_Estados <> "" Then p_SQL &= "AND loj_UF_chr IN ('" & IIf(p_Estados.Trim().EndsWith(","), Left(p_Estados.Trim(), Len(p_Estados.Trim()) - 1), p_Estados.Trim()).ToString().Replace(",", "','") & "')"

                    cmd = New SqlCommand(p_SQL, cn)
                    cmd.ExecuteNonQuery()

                    p_SQL = "SP_REP_WEB_RPT_PERFORMANCE_DADOS " & p_IdEmpresa & "," & _
                          checkDate(p_PeriodoInicial, True, True) & "," & _
                          checkDate(p_PeriodoFinal, True, True) & "," & p_TipoPesquisa

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

                    ret = New RelatorioData(dr, True)

                Catch ex As Exception

                    Throw ex

                Finally

                End Try
            Catch ex As Exception

                ret = New RelatorioData()
                Throw ex

            End Try

            Return ret

        End Function

        Public Function getRelatorioPerformanceDet(ByVal p_TipoDetalhe As Integer, ByVal p_IdEmpresa As Integer, ByVal p_IdCliente As String, ByVal p_IdLoja As String, ByVal p_IdShopping As String, _
                                                ByVal p_IdCoordenadores As String, ByVal p_IdLideres As String, ByVal p_IdPromotor As String, _
                                                ByVal p_TipoLoja As String, ByVal p_Regiao As String, ByVal p_StatusLoja As String, _
                                                ByVal p_TipoPesquisa As String, ByVal p_Estados As String, ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String) As RelatorioData


            Dim ret As RelatorioData = Nothing
            Dim blnInTransaction As Boolean = False
            Dim m_strConnection As String = ConnectionStrings.Item("cnStr").ConnectionString
            Dim p_SQL As String = ""

            Try

                Dim cn As New SqlConnection(m_strConnection)
                Dim cmd As SqlCommand

                Try

                    cn.Open()

                    'If Not blnInTransaction Then
                    '    cmd = New SqlCommand("BEGIN TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = True
                    'End If

                    '*****************************************
                    'INICIANDO CRIAÇÃO DAS TABELAS TEMPORÁRIAS
                    '*****************************************
                    cmd = New SqlCommand("CREATE TABLE #TBL_PROMOTORES(IdPromotor int)", cn)
                    cmd.ExecuteNonQuery()

                    p_SQL = "INSERT INTO #TBL_PROMOTORES SELECT PRO_PROMOTOR_INT_PK FROM TB_REP_PROMOTOR_PRO (NOLOCK) "
                    p_SQL = p_SQL & "WHERE PRO_PROMOTOR_INT_PK = " & p_IdPromotor

                    cmd = New SqlCommand(p_SQL, cn)
                    cmd.ExecuteNonQuery()

                    cmd = New SqlCommand("CREATE TABLE #TBL_LOJAS(IdLoja int)", cn)
                    cmd.ExecuteNonQuery()

                    p_SQL = "INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK FROM TB_REP_LOJA_LOJ (NOLOCK) WHERE 1=1 "
                    If p_IdLoja <> "" Then p_SQL &= "AND LOJ_LOJA_INT_PK IN (" & IIf(p_IdLoja.Trim().EndsWith(","), Left(p_IdLoja.Trim(), Len(p_IdLoja.Trim()) - 1), p_IdLoja.Trim()) & ")"
                    If p_IdCliente <> "" Then p_SQL &= "AND CLI_CLIENTE_INT_FK IN (" & IIf(p_IdCliente.Trim().EndsWith(","), Left(p_IdCliente.Trim(), Len(p_IdCliente.Trim()) - 1), p_IdCliente.Trim()) & ")"
                    If p_TipoLoja <> "" Then p_SQL &= "AND tlj_TipoLoja_int_FK IN (" & IIf(p_TipoLoja.Trim().EndsWith(","), Left(p_TipoLoja.Trim(), Len(p_TipoLoja.Trim()) - 1), p_TipoLoja.Trim()) & ")"
                    If p_IdShopping <> "" Then p_SQL &= "AND loj_Shopping_int_FK IN (" & IIf(p_IdShopping.Trim().EndsWith(","), Left(p_IdShopping.Trim(), Len(p_IdShopping.Trim()) - 1), p_IdShopping.Trim()) & ")"
                    If p_Regiao <> "" Then p_SQL &= "AND reg_Regiao_int_FK IN (" & IIf(p_Regiao.Trim().EndsWith(","), Left(p_Regiao.Trim(), Len(p_Regiao.Trim()) - 1), p_Regiao.Trim()) & ")"
                    If p_StatusLoja <> "2" Then p_SQL &= "AND loj_Status_ind IN (" & IIf(p_StatusLoja.Trim().EndsWith(","), Left(p_StatusLoja.Trim(), Len(p_StatusLoja.Trim()) - 1), p_StatusLoja.Trim()) & ")"
                    If p_Estados <> "" Then p_SQL &= "AND loj_UF_chr IN ('" & IIf(p_Estados.Trim().EndsWith(","), Left(p_Estados.Trim(), Len(p_Estados.Trim()) - 1), p_Estados.Trim()).ToString().Replace(",", "','") & "')"

                    cmd = New SqlCommand(p_SQL, cn)
                    cmd.ExecuteNonQuery()

                    p_SQL = "SP_REP_WEB_RPT_PERFORMANCE_DADOS_DETALHES " & p_IdEmpresa & "," & _
                          checkDate(p_PeriodoInicial, True, True) & "," & _
                          checkDate(p_PeriodoFinal, True, True) & ",'" & p_TipoPesquisa & "'," & p_TipoDetalhe

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim dr As SqlDataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)

                    ret = New RelatorioData(dr, True)

                Catch ex As Exception

                    Throw ex

                Finally

                End Try
            Catch ex As Exception

                ret = New RelatorioData()
                Throw ex

            End Try

            Return ret

        End Function

        Public Function getRelatorioResumoPOP(ByVal p_IdEmpresa As Integer, ByVal p_IdCliente As String, ByVal p_IdLoja As String, ByVal p_IdShopping As String, _
                                                ByVal p_TipoLoja As String, ByVal p_Regiao As String, ByVal p_StatusLoja As String, _
                                                ByVal p_Estados As String, ByVal p_PeriodoInicial As String, ByVal p_PeriodoFinal As String) As RelatorioData


            Dim ret As RelatorioData = Nothing
            Dim blnInTransaction As Boolean = False
            Dim m_strConnection As String = ConnectionStrings.Item("cnStr").ConnectionString
            Dim p_SQL As String = ""

            Try

                Dim cn As New SqlConnection(m_strConnection)
                Dim cmd As SqlCommand

                Try

                    cn.Open()

                    'If Not blnInTransaction Then
                    '    cmd = New SqlCommand("BEGIN TRANSACTION", cn)
                    '    cmd.ExecuteNonQuery()
                    '    blnInTransaction = True
                    'End If

                    '*****************************************
                    'INICIANDO CRIAÇÃO DAS TABELAS TEMPORÁRIAS
                    '*****************************************

                    cmd = New SqlCommand("CREATE TABLE #TBL_LOJAS(loj_loja_int_pk int, loj_loja_chr varchar(300),cli_cliente_int_fk int,cli_fantasia_chr varchar(300))", cn)
                    cmd.ExecuteNonQuery()

                    p_SQL = "INSERT INTO #TBL_LOJAS SELECT LOJ_LOJA_INT_PK,LOJ_LOJA_CHR,CLI_CLIENTE_INT_FK,CLI_FANTASIA_CHR "
                    p_SQL &= "FROM TB_REP_LOJA_LOJ (NOLOCK) INNER JOIN TB_REP_CLIENTE_CLI (NOLOCK) ON CLI_CLIENTE_INT_FK = CLI_CLIENTE_INT_PK WHERE 1=1 "
                    If p_IdLoja <> "" Then p_SQL &= "AND LOJ_LOJA_INT_PK IN (" & IIf(p_IdLoja.Trim().EndsWith(","), Left(p_IdLoja.Trim(), Len(p_IdLoja.Trim()) - 1), p_IdLoja.Trim()) & ")"
                    If p_IdCliente <> "" Then p_SQL &= "AND CLI_CLIENTE_INT_FK IN (" & IIf(p_IdCliente.Trim().EndsWith(","), Left(p_IdCliente.Trim(), Len(p_IdCliente.Trim()) - 1), p_IdCliente.Trim()) & ")"
                    If p_TipoLoja <> "" Then p_SQL &= "AND tlj_TipoLoja_int_FK IN (" & IIf(p_TipoLoja.Trim().EndsWith(","), Left(p_TipoLoja.Trim(), Len(p_TipoLoja.Trim()) - 1), p_TipoLoja.Trim()) & ")"
                    If p_IdShopping <> "" Then p_SQL &= "AND loj_Shopping_int_FK IN (" & IIf(p_IdShopping.Trim().EndsWith(","), Left(p_IdShopping.Trim(), Len(p_IdShopping.Trim()) - 1), p_IdShopping.Trim()) & ")"
                    If p_Regiao <> "" Then p_SQL &= "AND reg_Regiao_int_FK IN (" & IIf(p_Regiao.Trim().EndsWith(","), Left(p_Regiao.Trim(), Len(p_Regiao.Trim()) - 1), p_Regiao.Trim()) & ")"
                    If p_StatusLoja <> "2" Then p_SQL &= "AND loj_Status_ind IN (" & IIf(p_StatusLoja.Trim().EndsWith(","), Left(p_StatusLoja.Trim(), Len(p_StatusLoja.Trim()) - 1), p_StatusLoja.Trim()) & ")"
                    If p_Estados <> "" Then p_SQL &= "AND loj_UF_chr IN ('" & IIf(p_Estados.Trim().EndsWith(","), Left(p_Estados.Trim(), Len(p_Estados.Trim()) - 1), p_Estados.Trim()).ToString().Replace(",", "','") & "')"

                    cmd = New SqlCommand(p_SQL, cn)
                    cmd.ExecuteNonQuery()

                    p_SQL = "SP_REP_WEB_RPT_RESUMOPOP " & p_IdEmpresa & "," & _
                          checkDate(p_PeriodoInicial, True, True) & "," & _
                          checkDate(p_PeriodoFinal, True, True)

                    cmd = New SqlCommand(p_SQL, cn)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    da.Fill(ds, "Header")

                    ret = New RelatorioData(ds, True)

                Catch ex As Exception

                    Throw ex

                Finally

                End Try
            Catch ex As Exception
                ret = New RelatorioData()
                Throw ex

            End Try

            Return ret

        End Function


    End Class

End Namespace
