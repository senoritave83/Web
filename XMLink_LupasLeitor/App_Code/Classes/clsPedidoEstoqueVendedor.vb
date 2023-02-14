Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsPedidoEstoqueVendedor
		Inherits BaseClass

        Public Enum STATUS_MOVIMENTACAO
            Novo = 0
            Finalizado = 1
            EmAberto = 3
            Cancelada = 5
        End Enum

#Region "Declarations"
        Protected m_intIDPedidoEstoqueVendedor As Integer
        Protected m_indTipoPedido As Byte
        Protected m_intIDVendedor As Integer
        Protected m_strVendedor As String
        Protected m_strData As String
        Protected m_intIDUsuario As Integer
        Protected m_strUsuario As String
        Protected m_intIdStatus As Integer
        Protected m_strStatus As String
        Protected m_blnIsNew As Boolean = True
        Protected m_clsPedidoEstoqueVendedor_Itens As clsPedidoEstoqueVendedor_Itens
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDPedidoEstoqueVendedor As Integer
            Get
                Return m_intIDPedidoEstoqueVendedor
            End Get
        End Property

        Public Overridable Property TipoPedido As Byte
            Get
                Return m_indTipoPedido
            End Get
            Set(ByVal Value As Byte)
                m_indTipoPedido = Value
            End Set
        End Property

        Public Overridable Property IDVendedor As Integer
            Get
                Return m_intIDVendedor
            End Get
            Set(ByVal Value As Integer)
                m_intIDVendedor = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Vendedor As String
            Get
                Return m_strVendedor
            End Get
        End Property

        Public Overridable Property Data As String
            Get
                Return _getDateTimePropertyValue(m_strData)
            End Get
            Set(ByVal Value As String)
                m_strData = Value
            End Set
        End Property


        Public Overridable Property IDUsuario As Integer
            Get
                Return m_intIDUsuario
            End Get
            Set(ByVal Value As Integer)
                m_intIDUsuario = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Usuario As String
            Get
                Return m_strUsuario
            End Get
        End Property

        Public Overridable Property IdStatus As STATUS_MOVIMENTACAO
            Get
                Return m_intIdStatus
            End Get
            Set(ByVal Value As STATUS_MOVIMENTACAO)
                m_intIdStatus = Value
            End Set
        End Property

        Public ReadOnly Property Status As String
            Get
                Return m_strStatus
            End Get
        End Property

        Public ReadOnly Property IsNew() As Boolean
            Get
                Return m_blnIsNew
            End Get
        End Property

        Public ReadOnly Property Itens() As clsPedidoEstoqueVendedor_Itens
            Get
                If m_clsPedidoEstoqueVendedor_Itens Is Nothing Then
                    m_clsPedidoEstoqueVendedor_Itens = New clsPedidoEstoqueVendedor_Itens
                End If
                Return m_clsPedidoEstoqueVendedor_Itens
            End Get
        End Property


#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDPedidoEstoqueVendedor = dr.GetInt32(dr.GetOrdinal("IDPedidoEstoqueVendedor"))
            m_indTipoPedido = dr.GetByte(dr.GetOrdinal("TipoPedido"))
            If dr.IsDBNull(dr.GetOrdinal("IDVendedor")) Then
                m_intIDVendedor = 0
            Else
                m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Vendedor")) Then
                m_strVendedor = ""
            Else
                m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Data")) Then
                m_strData = ""
            Else
                m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDUsuario")) Then
                m_intIDUsuario = 0
            Else
                m_intIDUsuario = dr.GetInt32(dr.GetOrdinal("IDUsuario"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Usuario")) Then
                m_strUsuario = ""
            Else
                m_strUsuario = dr.GetString(dr.GetOrdinal("Usuario"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IdStatus")) Then
                m_intIdStatus = 0
            Else
                m_intIdStatus = dr.GetByte(dr.GetOrdinal("IdStatus"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Status")) Then
                m_strStatus = ""
            Else
                m_strStatus = dr.GetString(dr.GetOrdinal("Status"))
            End If
            m_blnIsNew = False
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PEDIDOESTOQUEVENDEDOR"
            cmd.Parameters.Add("@IDPEDIDOESTOQUEVENDEDOR", SqlDbType.Int).value = m_intIDPedidoEstoqueVendedor
            cmd.Parameters.Add("@TIPOPEDIDO", SqlDbType.TinyInt).value = m_indTipoPedido
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).value = m_intIDVendedor
            If m_strData <> "" Then
                cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = m_strData
            End If
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).value = m_intIDUsuario
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
        ''' <param name="vIDPedidoEstoqueVendedor">Chave primaria IDPedidoEstoqueVendedor</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDPedidoEstoqueVendedor As Integer) As Boolean
            If vIDPedidoEstoqueVendedor = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PEDIDOESTOQUEVENDEDOR"
            cmd.Parameters.Add("@IDPEDIDOESTOQUEVENDEDOR", SqlDbType.Int).value = vIDPedidoEstoqueVendedor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
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
            m_intIDPedidoEstoqueVendedor = 0
            m_indTipoPedido = 0
            m_intIDVendedor = 0
            m_strData = ""
            m_intIDUsuario = 0
            m_intIdStatus = 0
            m_strStatus = ""
            m_blnIsNew = True
        End Sub

        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PEDIDOESTOQUEVENDEDOR"
            cmd.Parameters.Add("@IDPEDIDOESTOQUEVENDEDOR", SqlDbType.Int).value = m_intIDPedidoEstoqueVendedor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'PedidoEstoqueVendedor' the following row:  IDPedidoEstoqueVendedor=" & m_intIDPedidoEstoqueVendedor & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PEDIDOESTOQUEVENDEDORES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDPedidoEstoqueVendedor">Filtro</param>
        ''' <param name="vTipoPedido">Filtro</param>
        ''' <param name="vIDVendedor">Filtro</param>
        ''' <param name="vDataInicial">Filtro</param>
        ''' <param name="vDataFinal">Filtro</param>
        ''' <param name="vIDUsuario">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, vIDPedidoEstoqueVendedor As Integer, vTipoPedido As Byte, vIDVendedor As Integer, vDataInicial As String, vDataFinal As String, vIDUsuario As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PEDIDOESTOQUEVENDEDORES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
            cmd.Parameters.Add("@IDPEDIDOESTOQUEVENDEDOR", SqlDbType.Int).value = vIDPedidoEstoqueVendedor
            cmd.Parameters.Add("@TIPOPEDIDO", SqlDbType.TinyInt).value = vTipoPedido
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).value = vIDVendedor
            If vDataInicial <> "" Then
                cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).value = _setDateTimeDBValue(vDataInicial)
            End If
            If vDataFinal <> "" Then
                cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).value = _setDateTimeDBValue(vDataFinal)
            End If
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).value = vIDUsuario
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

#End Region

    End Class

    Public Class clsPedidoEstoqueVendedor_Itens
        Inherits BaseClass

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vIDPedidoEstoqueVendedor">Id do Pedido</param>
        ''' <returns>Object</returns>
        Public Function ListarItens(vIDPedidoEstoqueVendedor As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PEDIDOESTOQUEVENDEDOR_ITENS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDOESTOQUEVENDEDOR", SqlDbType.Int).Value = vIDPedidoEstoqueVendedor

            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vIDPedidoEstoqueVendedor">Id do Pedido</param>
        ''' <param name="vIdProduto">Id do Produto</param>
        ''' <param name="vQuant">Quantidade</param>
        ''' <returns>Object</returns>
        Public Function AdicionarItem(vIDPedidoEstoqueVendedor As Integer, vIdProduto As Integer, vQuant As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PEDIDOESTOQUEVENDEDOR_ADICIONAR_ITEM"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDOESTOQUEVENDEDOR", SqlDbType.Int).Value = vIDPedidoEstoqueVendedor
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdProduto
            cmd.Parameters.Add("@QUANTIDADE", SqlDbType.Int).Value = vQuant

            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vIDPedidoEstoqueVendedor">Id do Pedido</param>
        ''' <param name="vIdProduto">Id do Produto</param>
        Public Sub RemoverItem(vIDPedidoEstoqueVendedor As Integer, vIdProduto As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PEDIDOESTOQUEVENDEDOR_REMOVER_ITEM"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDOESTOQUEVENDEDOR", SqlDbType.Int).Value = vIDPedidoEstoqueVendedor
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdProduto

            ExecuteNonQuery(cmd)

        End Sub

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vIDPedidoEstoqueVendedor">Id do Pedido</param>
        Public Sub FinalizarMovimentacao(vIDPedidoEstoqueVendedor As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "BS_PEDIDOESTOQUEVENDEDOR_FINALIZARMOVIMENTACAO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDOESTOQUEVENDEDOR", SqlDbType.Int).Value = vIDPedidoEstoqueVendedor

            ExecuteNonQuery(cmd)

        End Sub


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vIDPedidoEstoqueVendedor">Id do Pedido</param>
        Public Sub CancelarMovimentacao(vIDPedidoEstoqueVendedor As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "BS_PEDIDOESTOQUEVENDEDOR_CANCELARMOVIMENTACAO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDOESTOQUEVENDEDOR", SqlDbType.Int).Value = vIDPedidoEstoqueVendedor

            ExecuteNonQuery(cmd)

        End Sub

    End Class

End Namespace

