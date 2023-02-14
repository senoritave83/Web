

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace Classes

    Public Class clsPesquisa
        Inherits BaseClass

#Region "Declarations"
        Protected m_intIDPesquisa As Integer
        Protected m_strDataInicio As String
        Protected m_strDataFim As String
        Protected m_indVisitasMes As Byte
        Protected m_strCriado As String
        Protected m_blnPricing As Boolean = False
        Protected m_blnIsNew As Boolean = True
        Protected m_lstEmpresas As List(Of Integer)
        Protected m_lstMarcas As List(Of Integer)
        Protected m_lstProdutos As List(Of Integer)
        Protected m_strPesquisa As String
#End Region

#Region "Properties"        

        Public Overridable ReadOnly Property IDPesquisa As Integer
            Get
                Return m_intIDPesquisa
            End Get
        End Property

        Public Overridable ReadOnly Property Empresas As List(Of Integer)
            Get
                If m_lstEmpresas Is Nothing Then
                    m_lstEmpresas = New List(Of Integer)
                    InflateList(m_lstEmpresas, ListarPesquisaEmpresa, "IDEmpresa")
                End If

                Return m_lstEmpresas
            End Get
        End Property

        Public Overridable ReadOnly Property Marcas As List(Of Integer)
            Get
                If m_lstMarcas Is Nothing Then
                    m_lstMarcas = New List(Of Integer)
                    InflateList(m_lstMarcas, ListarPesquisaMarca, "IDMarca")
                End If

                Return m_lstMarcas
            End Get
        End Property

        'Public Overridable ReadOnly Property Embalagens As List(Of Integer)
        '    Get
        '        If m_lstEmbalagens Is Nothing Then
        '            m_lstEmbalagens = New List(Of Integer)
        '            InflateList(m_lstEmbalagens, ListarPesquisaEmbalagem, "IDEmbalagem")
        '        End If

        '        Return m_lstEmbalagens
        '    End Get
        'End Property

        Public Overridable ReadOnly Property Produtos As List(Of Integer)
            Get
                If m_lstProdutos Is Nothing Then
                    m_lstProdutos = New List(Of Integer)
                    InflateList(m_lstProdutos, ListarPesquisaProduto, "IdProdutoPesquisa")
                End If

                Return m_lstProdutos
            End Get
        End Property

        Public Overridable Property Pesquisa As String
            Get
                Return m_strPesquisa
            End Get
            Set(ByVal Value As String)
                m_strPesquisa = Value
            End Set
        End Property

        Public Overridable Property DataInicio As String
            Get
                If IsDate(m_strDataInicio) Then
                    Return FormatDateTime(m_strDataInicio, DateFormat.ShortDate)
                Else
                    Return ""
                End If
            End Get
            Set(ByVal Value As String)
                m_strDataInicio = _getDateTimeDBValue(Value)
            End Set
        End Property

        Public Overridable Property DataFim As String
            Get
                If IsDate(m_strDataInicio) Then
                    Return FormatDateTime(m_strDataFim, DateFormat.ShortDate)
                Else
                    Return ""
                End If
            End Get
            Set(ByVal Value As String)
                m_strDataFim = _getDateTimeDBValue(Value)
            End Set
        End Property

        Public Overridable Property VisitasMes As Byte
            Get
                Return m_indVisitasMes
            End Get
            Set(ByVal Value As Byte)
                m_indVisitasMes = Value
            End Set
        End Property

        Public Overridable Property Pricing As Boolean
            Get
                Return m_blnPricing
            End Get
            Set(ByVal Value As Boolean)
                m_blnPricing = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Criado As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
        End Property

        Public ReadOnly Property IsValidToEdit() As Boolean
            Get
                If m_strDataInicio = "" Then
                    Return True
                End If
                Return Date.Today < CDate(m_strDataInicio)
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

            m_intIDPesquisa = dr.GetInt32(dr.GetOrdinal("IDPesquisa"))
            m_strPesquisa = dr.GetString(dr.GetOrdinal("Pesquisa"))
            m_strDataInicio = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataInicio")))
            m_strDataFim = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataFim")))
            m_indVisitasMes = dr.GetByte(dr.GetOrdinal("VisitasMes"))
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))

            m_blnPricing = IIf(dr.Item(dr.GetOrdinal("Pricing")) = 1, True, False)

            m_blnIsNew = False

        End Sub

        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PESQUISA"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@PESQUISA", SqlDbType.VarChar).Value = m_strPesquisa
            cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strDataInicio)
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strDataFim)
            cmd.Parameters.Add("@VISITASMES", SqlDbType.TinyInt).Value = m_indVisitasMes
            cmd.Parameters.Add("@PRICING", SqlDbType.TinyInt).Value = IIf(m_blnPricing = True, 1, 0)

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

            UpdateProdutos()
            UpdateMarcas()
            UpdateEmpresas()

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDPesquisa">Chave primaria IDPesquisa</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDPesquisa As Integer) As Boolean
            Dim blnReturn As Boolean = False
            If vIDPesquisa = 0 Then
                Clear()
                Return blnReturn
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PESQUISA"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIDPesquisa
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
            ClearLists()
            Return blnReturn
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDPesquisa = 0
            m_strPesquisa = ""
            m_strDataInicio = ""
            m_strDataFim = ""
            m_indVisitasMes = 0
            m_strCriado = ""
            m_blnIsNew = True
            m_blnPricing = False
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PESQUISA"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Pesquisa' the following row:  IDPesquisa=" & m_intIDPesquisa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PESQUISAS"
            cmd.CommandType = CommandType.StoredProcedure
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vDataInicio">Filtro</param>
        ''' <param name="vDataFim">Filtro</param>        
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vDataInicio As String, ByVal vDataFim As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PESQUISAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Me.User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            If IsDate(vDataInicio) Then
                cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicio)
            End If
            If IsDate(vDataFim) Then
                cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFim)
            End If
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        ' ''' <summary>
        ' ''' 	Função que grava os dados das embalagens da pesquisa
        ' ''' </summary>
        'Public Sub UpdatePesquisaEmbalagem(ByVal vIDEmbalagem As Integer)
        '    Dim cmd As New SqlCommand()
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.CommandText = PREFIXO & "SV_PESQUISA_EMBALAGEM"
        '    cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
        '    cmd.Parameters.Add("@IDEMBALAGEM", SqlDbType.Int).Value = vIDEmbalagem
        '    Dim dr As IDataReader = ExecuteReader(cmd)

        '    If (Not dr Is Nothing) Then
        '        dr.Close()
        '        dr = Nothing
        '    End If
        'End Sub

        ''' <summary>
        ''' 	Função que grava os dados das embalagens da pesquisa
        ''' </summary>
        Public Sub UpdatePesquisaProduto(ByVal vIdProduto As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PESQUISA_PRODUTO"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdProduto
            Dim dr As IDataReader = ExecuteReader(cmd)

            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Sub

        ' ''' <summary>
        ' ''' 	Função que apaga os dados das embalagens da pesquisa
        ' ''' </summary>
        'Public Sub DeletePesquisaEmbalagem()
        '    Dim cmd As New SqlCommand()
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.CommandText = PREFIXO & "DE_PESQUISA_EMBALAGEM"
        '    cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
        '    Dim dr As IDataReader = ExecuteReader(cmd)

        '    If (Not dr Is Nothing) Then
        '        dr.Close()
        '        dr = Nothing
        '    End If
        'End Sub

        ''' <summary>
        ''' 	Função que apaga os dados das embalagens da pesquisa
        ''' </summary>
        Public Sub DeletePesquisaProduto()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PESQUISA_PRODUTO"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            Dim dr As IDataReader = ExecuteReader(cmd)

            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Sub

        ' ''' <summary>
        ' ''' 	Função que apaga os dados das embalagens da pesquisa
        ' ''' </summary>        
        'Public Function ListarPesquisaEmbalagem(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
        '    Dim cmd As New SqlCommand()
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.CommandText = PREFIXO & "LS_PESQUISA_EMBALAGENS"
        '    cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa

        '    Return ExecuteCommand(cmd, vReturnType)
        'End Function


        ''' <summary>
        ''' 	Função que apaga os dados das embalagens da pesquisa
        ''' </summary>        
        Public Function ListarPesquisaProduto(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PESQUISA_PRODUTOS"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa

            Return ExecuteCommand(cmd, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que apaga os dados das embalagens da pesquisa
        ''' </summary>        
        Public Function ListarPesquisasEmpresa(ByVal vIdEmpresa As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PESQUISAS_EMPRESA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa

            Return ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que grava os dados das embalagens da pesquisa
        ''' </summary>
        Public Sub UpdatePesquisaMarca(ByVal vIDMarca As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PESQUISA_MARCA"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@IDMARCA", SqlDbType.Int).Value = vIDMarca
            Dim dr As IDataReader = ExecuteReader(cmd)

            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Sub

        ''' <summary>
        ''' 	Função que apaga os dados das embalagens da pesquisa
        ''' </summary>
        Public Sub DeletePesquisaMarca()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PESQUISA_MARCA"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            Dim dr As IDataReader = ExecuteReader(cmd)

            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Sub

        ''' <summary>
        ''' 	Função que apaga os dados das embalagens da pesquisa
        ''' </summary>        
        Public Function ListarPesquisaMarca(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PESQUISA_MARCAS"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa

            Return ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que grava os dados das empresas da pesquisa
        ''' </summary>
        Public Sub UpdatePesquisaEmpresa(ByVal vIDEmpresa As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PESQUISA_EMPRESA"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            Dim dr As IDataReader = ExecuteReader(cmd)

            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Sub

        ''' <summary>
        ''' 	Função que apaga os dados das empresas da pesquisa
        ''' </summary>
        Public Sub DeletePesquisaEmpresa()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PESQUISA_EMPRESA"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa
            Dim dr As IDataReader = ExecuteReader(cmd)

            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Sub

        ''' <summary>
        ''' 	Função que apaga os dados das empresas da pesquisa
        ''' </summary>        
        Public Function ListarPesquisaEmpresa(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PESQUISA_EMPRESAS"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = m_intIDPesquisa

            Return ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo login informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a Função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDPesquisa">Chave primaria IDPesquisa do registro atual.</param>
        ''' <param name="vDataInicial">Data que se deseja verificar a existência no banco de dados</param>
        ''' <param name="vDataFinal">Data que se deseja verificar a existência no banco de dados</param>
        Public Function Conflito(ByVal vIDPesquisa As Integer, ByVal vDataInicial As Date, ByVal vDataFinal As Date) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PESQUISA_CONFLITO"
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIDPesquisa
            cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@EMPRESAS", SqlDbType.VarChar).Value = String.Join(",", Array.ConvertAll(m_lstEmpresas.ToArray, New Converter(Of Integer, String)(AddressOf ConvertIntToString)))
            Return ExecuteScalar(cmd)
        End Function

        Private Function ConvertIntToString(ByVal int As Integer) As String
            Return CStr(int)
        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            If Conflito(m_intIDPesquisa, m_strDataInicio, m_strDataFim) Then
                AddBrokenRule("A data da pesquisa conflita com uma pesquisa já cadastrada!")
                blnValid = False
            End If

            Return blnValid
        End Function

        Private Function getData(ByVal value As String) As String
            If IsDate(value) Then
                Return CDate(value).ToString("MM/yyyy")
            Else
                Return ""
            End If
        End Function

        Private Function setDataInicio(ByVal Value As String) As String
            If IsDate(Value) Then
                Return CDate(Value).ToString("yyyy-MM-dd HH:mm:ss")
            Else
                Return ""
            End If
        End Function

        Private Function setDataFim(ByVal Value As String) As String
            Dim data As DateTime

            If IsDate(Value) Then
                data = (CDate(Value).ToString("yyyy-MM-dd HH:mm:ss"))

                Return data.AddMonths(1).AddSeconds(-1)
            Else
                Return ""
            End If
        End Function

        'Private Sub UpdateEmbalagens()
        '    If m_lstEmbalagens Is Nothing Then
        '        Exit Sub
        '    End If

        '    DeletePesquisaEmbalagem()

        '    For Each embalagem As Integer In m_lstEmbalagens
        '        UpdatePesquisaEmbalagem(embalagem)
        '    Next
        'End Sub

        Private Sub UpdateProdutos()

            If m_lstProdutos Is Nothing Then
                Exit Sub
            End If

            DeletePesquisaProduto()

            For Each produto As Integer In m_lstProdutos
                UpdatePesquisaProduto(produto)
            Next

        End Sub

        Private Sub UpdateMarcas()
            If m_lstMarcas Is Nothing Then
                Exit Sub
            End If

            DeletePesquisaMarca()

            For Each marca As Integer In m_lstMarcas
                UpdatePesquisaMarca(marca)
            Next
        End Sub

        Private Sub UpdateEmpresas()
            If m_lstEmpresas Is Nothing Then
                Exit Sub
            End If

            DeletePesquisaEmpresa()

            For Each empresa As Integer In m_lstEmpresas
                UpdatePesquisaEmpresa(empresa)
            Next
        End Sub

        Protected Overridable Sub InflateList(ByVal pList As List(Of Integer), ByVal dr As IDataReader, ByVal pFieldName As String)
            Try
                pList.Clear()

                While (dr.Read)
                    pList.Add(dr.GetInt32(dr.GetOrdinal(pFieldName)))
                End While
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try

        End Sub

        Protected Overridable Sub ClearLists()
            m_lstProdutos = Nothing
            m_lstEmpresas = Nothing
            m_lstMarcas = Nothing
        End Sub

#End Region

    End Class

End Namespace

