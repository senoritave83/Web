﻿
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsPedido
        Inherits BaseClass



#Region "Declarations"
        Protected m_strIDPedido As String
        Protected m_intIDVendedor As Integer
        Protected m_intIDCliente As Integer
        Protected m_strCodigo As String
        Protected m_strDataEmissao As String
        Protected m_strDataCriacao As String
        Protected m_intIdOpcao As Integer 'Opção 1 ou Opção 2
        Protected m_intIDCondicao As Integer
        Protected m_strCondicao As String
        Protected m_strDataEntrega As String
        Protected m_indStatusPedido As Byte
        Protected m_decPrecoUnitario As Decimal
        Protected m_sngDesconto As Single
        Protected m_intIDSituacaoPedido As Integer
        Protected m_intNumeroPedido As Integer
        Protected m_intIDFormaPagamento As Integer
        Protected m_strFormaPagamento As String
        Protected m_strObservacao As String
        Protected m_intNumDevice As Integer
        Protected m_intIDVisita As Integer
        Protected m_decTotal As Decimal
        Protected m_intIDTipoPedido As Integer
        Protected m_decSubTotal As Decimal
        Protected m_strCliente As String
        Protected m_blnIsNew As Boolean = True
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDPedido() As String
            Get
                Return m_strIDPedido
            End Get
        End Property

        Public Overridable Property IDVendedor() As Integer
            Get
                Return m_intIDVendedor
            End Get
            Set(ByVal Value As Integer)
                m_intIDVendedor = Value
            End Set
        End Property

        Public Overridable Property IDCliente() As Integer
            Get
                Return m_intIDCliente
            End Get
            Set(ByVal Value As Integer)
                m_intIDCliente = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Cliente() As String
            Get
                Return m_strCliente
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

        Public Overridable Property DataEmissao() As String
            Get
                Return _getDatePropertyValue(m_strDataEmissao)
            End Get
            Set(ByVal Value As String)
                m_strDataEmissao = _setDateTimePropertyValue(Value)
            End Set
        End Property

        Public ReadOnly Property DataCriacao() As String
            Get
                Return _getDateTimePropertyValue(m_strDataCriacao)
            End Get
        End Property

        Public Overridable Property IDOpcao() As Integer
            Get
                Return m_intIdOpcao
            End Get
            Set(ByVal Value As Integer)
                m_intIdOpcao = Value
            End Set
        End Property


        Public Overridable Property IDTipoPedido() As Integer
            Get
                Return m_intIDTipoPedido
            End Get
            Set(ByVal Value As Integer)
                m_intIDTipoPedido = Value
            End Set
        End Property

        Public Overridable Property IDCondicao() As Integer
            Get
                Return m_intIDCondicao
            End Get
            Set(ByVal Value As Integer)
                m_intIDCondicao = Value
            End Set
        End Property

        Public Overridable Property DataEntrega() As String
            Get
                Return _getDatePropertyValue(m_strDataEntrega)
            End Get
            Set(ByVal Value As String)
                m_strDataEntrega = _setDateTimePropertyValue(Value)
            End Set
        End Property


        Public Overridable Property StatusPedido() As Byte
            Get
                Return m_indStatusPedido
            End Get
            Set(ByVal Value As Byte)
                m_indStatusPedido = Value
            End Set
        End Property

        Public Overridable Property Desconto() As Single
            Get
                Return m_sngDesconto
            End Get
            Set(ByVal Value As Single)
                m_sngDesconto = Value
            End Set
        End Property

        Public Overridable Property IDSituacaoPedido() As Integer
            Get
                Return m_intIDSituacaoPedido
            End Get
            Set(ByVal Value As Integer)
                m_intIDSituacaoPedido = Value
            End Set
        End Property

        Public Overridable ReadOnly Property NumeroPedido() As Integer
            Get
                Return m_intNumeroPedido
            End Get
        End Property

        Public Overridable Property IDFormaPagamento() As Integer
            Get
                Return m_intIDFormaPagamento
            End Get
            Set(ByVal Value As Integer)
                m_intIDFormaPagamento = Value
            End Set
        End Property

        Public Overridable Property Observacao() As String
            Get
                Return m_strObservacao
            End Get
            Set(ByVal Value As String)
                m_strObservacao = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Condicao() As String
            Get
                Return m_strCondicao
            End Get
        End Property

        Public Overridable ReadOnly Property FormaPagamento() As String
            Get
                Return m_strFormaPagamento
            End Get
        End Property

        Public Overridable Property IDVisita() As Integer
            Get
                Return m_intIDVisita
            End Get
            Set(ByVal Value As Integer)
                m_intIDVisita = Value
            End Set
        End Property

        Public Overridable Property Total() As Decimal
            Get
                Return m_decTotal
            End Get
            Set(ByVal Value As Decimal)
                m_decTotal = Value
            End Set
        End Property


        Public Overridable Property PrecoUnitario As Decimal
            Get
                Return m_decPrecoUnitario
            End Get
            Set(ByVal Value As Decimal)
                m_decPrecoUnitario = Value
            End Set
        End Property

        Public Overridable Property SubTotal() As Decimal
            Get
                Return m_decSubTotal
            End Get
            Set(ByVal Value As Decimal)
                m_decSubTotal = Value
            End Set
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

            m_strIDPedido = dr.GetGuid(dr.GetOrdinal("IDPedido")).ToString
            m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))

            If dr.IsDBNull(dr.GetOrdinal("IDCliente")) Then
                m_intIDCliente = 0
            Else
                m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IDCliente"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Cliente")) Then
                m_strCliente = ""
            Else
                m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Codigo")) Then
                m_strCodigo = ""
            Else
                m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DataEmissao")) Then
                m_strDataEmissao = ""
            Else
                m_strDataEmissao = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataEmissao")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DataCriacao")) Then
                m_strDataCriacao = ""
            Else
                m_strDataCriacao = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataCriacao")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Opcao")) Then
                m_intIdOpcao = 0
            Else
                m_intIdOpcao = dr.Item(dr.GetOrdinal("Opcao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("TipoPedido")) Then
                m_intIDTipoPedido = 0
            Else
                m_intIDTipoPedido = dr.Item(dr.GetOrdinal("TipoPedido"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDCondicao")) Then
                m_intIDCondicao = 0
            Else
                m_intIDCondicao = dr.GetInt32(dr.GetOrdinal("IDCondicao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DataEntrega")) Then
                m_strDataEntrega = ""
            Else
                m_strDataEntrega = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataEntrega")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("StatusPedido")) Then
                m_indStatusPedido = 0
            Else
                m_indStatusPedido = dr.GetByte(dr.GetOrdinal("StatusPedido"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Desconto")) Then
                m_sngDesconto = 0
            Else
                m_sngDesconto = dr.GetFloat(dr.GetOrdinal("Desconto"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDSituacaoPedido")) Then
                m_intIDSituacaoPedido = 0
            Else
                m_intIDSituacaoPedido = dr.GetInt32(dr.GetOrdinal("IDSituacaoPedido"))
            End If

            If dr.IsDBNull(dr.GetOrdinal("PrecoUnitario")) Then
                m_decPrecoUnitario = 0
            Else
                m_decPrecoUnitario = dr.GetDecimal(dr.GetOrdinal("PrecoUnitario"))
            End If

            m_intNumeroPedido = dr.GetInt32(dr.GetOrdinal("NumeroPedido"))
            If dr.IsDBNull(dr.GetOrdinal("IDFormaPagamento")) Then
                m_intIDFormaPagamento = 0
            Else
                m_intIDFormaPagamento = dr.GetInt32(dr.GetOrdinal("IDFormaPagamento"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("FormaPagamento")) Then
                m_strFormaPagamento = 0
            Else
                m_strFormaPagamento = dr.GetString(dr.GetOrdinal("FormaPagamento"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Observacao")) Then
                m_strObservacao = ""
            Else
                m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("NumDevice")) Then
                m_intNumDevice = 0
            Else
                m_intNumDevice = dr.GetInt32(dr.GetOrdinal("NumDevice"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDVisita")) Then
                m_intIDVisita = 0
            Else
                m_intIDVisita = dr.GetInt32(dr.GetOrdinal("IDVisita"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Condicao")) Then
                m_strCondicao = ""
            Else
                m_strCondicao = dr.GetString(dr.GetOrdinal("Condicao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Total")) Then
                m_decTotal = Nothing
            Else
                m_decTotal = dr.Item(dr.GetOrdinal("Total"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("SubTotal")) Then
                m_decSubTotal = Nothing
            Else
                m_decSubTotal = dr.Item(dr.GetOrdinal("SubTotal"))
            End If

            m_blnIsNew = False

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PEDIDO"
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = m_strIDPedido
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = m_intIDVendedor
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@CODIGO", SqlDbType.NVarChar, 40).Value = m_strCodigo
            cmd.Parameters.Add("@OPCAO", SqlDbType.Int).Value = m_intIdOpcao
            cmd.Parameters.Add("@TIPOPEDIDO", SqlDbType.Int).Value = m_intIDTipoPedido
            If m_strDataEmissao <> "" Then
                cmd.Parameters.Add("@DATAEMISSAO", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strDataEmissao)
            End If
            cmd.Parameters.Add("@IDCONDICAO", SqlDbType.Int).Value = m_intIDCondicao
            cmd.Parameters.Add("@IDFORMAPAGTO", SqlDbType.Int).Value = m_intIDFormaPagamento
            If m_strDataEntrega <> "" Then
                cmd.Parameters.Add("@DATAENTREGA", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strDataEntrega)
            End If
            cmd.Parameters.Add("@IDSITUACAOPEDIDO", SqlDbType.Int).Value = m_intIDSituacaoPedido
            cmd.Parameters.Add("@OBSERVACAO", SqlDbType.VarChar, 50).Value = m_strObservacao
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
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


        Public Sub NovoPedido(ByVal vIDVisita As Integer, ByVal vIDCliente As Integer, ByVal vIDTipoPedido As Integer, Optional ByVal vIDPedidoCopiar As Integer = -1, Optional ByVal vTipoCopia As Integer = 1)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PEDIDO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita
            cmd.Parameters.Add("@IDTIPOPEDIDO", SqlDbType.Int).Value = vIDTipoPedido
            cmd.Parameters.Add("@IDPEDIDOCOPIA", SqlDbType.Int).Value = vIDPedidoCopiar
            cmd.Parameters.Add("@TIPOCOPIA", SqlDbType.Int).Value = vTipoCopia
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
        ''' <param name="vIDPedido">Chave primaria IDPedido</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDPedido As String) As Boolean
            If vIDPedido = Nothing Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PEDIDO"
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = vIDPedido
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

            Return True

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()

            m_strIDPedido = Nothing
            m_intIDVendedor = 0
            m_intIDCliente = 0
            m_strCodigo = ""
            m_strDataEmissao = ""
            m_strDataCriacao = ""
            m_intIDCondicao = 0
            m_strDataEntrega = ""
            m_indStatusPedido = 0
            m_sngDesconto = 0
            m_intIDSituacaoPedido = 0
            m_intNumeroPedido = 0
            m_intIDFormaPagamento = 0
            m_strObservacao = ""
            m_intNumDevice = 0
            m_intIDVisita = 0
            m_decTotal = Nothing
            m_decSubTotal = Nothing
            m_strCondicao = ""
            m_strFormaPagamento = ""
            m_intIDTipoPedido = 0
            m_intIdOpcao = 0

            m_blnIsNew = True

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarUltimosPedidos(ByVal vIDCliente As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ULTIMOS_PEDIDOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        Public Function ListarItens(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PEDIDOS_ITENS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = m_strIDPedido
            Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDVendedor">Filtro</param>
        ''' <param name="vIDCliente">Filtro</param>
        ''' <param name="vIDCondicao">Filtro</param>
        ''' <param name="vIDSituacaoPedido">Filtro</param>
        ''' <param name="vIDEndereco">Filtro</param>
        ''' <param name="vIDFormaPagamento">Filtro</param>
        ''' <param name="vIDVisita">Filtro</param>
        ''' <param name="vIDMotivo">Filtro</param>
        ''' <param name="vIDEmpresaFaturamento">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDVendedor As Integer, ByVal vIDCliente As Integer, ByVal vIDCondicao As Integer, ByVal vIDSituacaoPedido As Integer, ByVal vIDEndereco As Integer, ByVal vIDFormaPagamento As Integer, ByVal vIDVisita As Integer, ByVal vIDMotivo As Integer, ByVal vIDEmpresaFaturamento As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PEDIDOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@IDCONDICAO", SqlDbType.Int).Value = vIDCondicao
            cmd.Parameters.Add("@IDSITUACAOPEDIDO", SqlDbType.Int).Value = vIDSituacaoPedido
            cmd.Parameters.Add("@IDENDERECO", SqlDbType.Int).Value = vIDEndereco
            cmd.Parameters.Add("@IDFORMAPAGAMENTO", SqlDbType.Int).Value = vIDFormaPagamento
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita
            cmd.Parameters.Add("@IDMOTIVO", SqlDbType.Int).Value = vIDMotivo
            cmd.Parameters.Add("@IDEMPRESAFATURAMENTO", SqlDbType.Int).Value = vIDEmpresaFaturamento
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        Public Sub AdicionarProduto(ByVal vIDProduto As Integer, ByVal vQuantidade As Integer, ByVal vPrecoUnitario As Decimal, ByVal vDesconto As Single)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PEDIDO_PRODUTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = m_strIDPedido
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@QUANTIDADE", SqlDbType.Int).Value = vQuantidade
            cmd.Parameters.Add("@PRECOUNITARIO", SqlDbType.Decimal).Value = vPrecoUnitario
            cmd.Parameters.Add("@DESCONTO", SqlDbType.Real).Value = vDesconto
            ExecuteNonQuery(cmd)

        End Sub


        Public Sub RetirarProduto(ByVal vIDItemPedido As String)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PEDIDO_PRODUTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = m_strIDPedido
            cmd.Parameters.Add("@IDITEMPEDIDO", SqlDbType.VarChar).Value = vIDItemPedido
            ExecuteNonQuery(cmd)

        End Sub


        Public Sub FinalizarPedido()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "BS_PEDIDO_FINALIZAR"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = m_strIDPedido
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

        Public Sub CancelarPedido()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "BS_PEDIDO_CANCELAR"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = m_strIDPedido
            ExecuteNonQuery(cmd)

        End Sub



        Public Function ExistePedido(ByVal vNumPedido As Integer) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PEDIDO_EXISTE"
            cmd.Parameters.Add("@NUMPEDIDO", SqlDbType.Int).Value = vNumPedido
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return ExecuteScalar(cmd)

        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

#End Region

    End Class
End Namespace
