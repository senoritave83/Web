Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling

Public Class clsConsignacao
    Inherits BaseClass
    Protected m_intIDCliente As Integer

    Friend Sub New(ByVal vIDCliente As Integer)
        m_intIDCliente = vIDCliente
    End Sub


    Public Function ListaHistorico(ByVal vIDProduto As Integer, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
        Dim ret As New PaginateResult
        Try
            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_CONSIGNACAO_PRODUTO_HISTORICO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            cn.Open()
            If vReturnType = enReturnType.DataReader Then
                Dim dr As IDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If dr.Read Then
                    ret.PageSize = vPageSize
                    ret.CurrentPage = vPage
                    ret.RecordCount = dr.GetInt32(0)
                    If dr.NextResult Then
                        ret.Data = dr
                    End If
                End If
            Else
                Try
                    Dim ad As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    ad.Fill(ds)
                    ret.PageSize = vPageSize
                    ret.CurrentPage = vPage
                    ret.RecordCount = ds.Tables(0).Rows(0).Item(0)
                    ret.Data = ds.Tables(1)
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            End If

        Catch ex As Exception

            If (1 = 2) Then
                Throw
            End If
        End Try
        Return ret
    End Function

    ''' <summary>
    ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
    ''' </summary>
    ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
    ''' <param name="vIDCategoria">Filtro</param>
    ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
    ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
    ''' <param name="vPage">Número da página a exibir</param>	
    ''' <param name="vPageSize">Tamanho da página em registros</param>		
    ''' <returns>PaginateResult</returns>
    Public Function ProdutosNaoConsignados(ByVal vFilter As String, ByVal vIDCategoria As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
        Dim ret As New PaginateResult
        Try
            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            cn.Open()

            If vReturnType = enReturnType.DataReader Then
                Dim dr As IDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If dr.Read Then
                    ret.PageSize = vPageSize
                    ret.CurrentPage = vPage
                    ret.RecordCount = dr.GetInt32(0)
                    If dr.NextResult Then
                        ret.Data = dr
                    End If
                End If
            Else
                Try
                    Dim ad As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    ad.Fill(ds)
                    ret.PageSize = vPageSize
                    ret.CurrentPage = vPage
                    ret.RecordCount = ds.Tables(0).Rows(0).Item(0)
                    ret.Data = ds.Tables(1)
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            End If

        Catch ex As Exception

            If (1 = 2) Then
                Throw
            End If
        End Try
        Return ret
    End Function



    Public Function ListarProdutosConsignados(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "LS_CLIENTE_PRODUTOS_CONSIGNADOS"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
        Return MyBase.ExecuteCommand(cmd, vReturnType)
    End Function


    Public Sub AtualizaQuantidades(ByVal vProdutos As clsProdutosConsignados)
        Try
            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "UP_CLIENTE_PRODUTOS_CONSIGNADOS"
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@PRODUTOS", SqlDbType.Xml).Value = GetXML(vProdutos)
            cn.Open()
            Try
                cmd.ExecuteNonQuery()
                MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " esta alterando a quantidade de produtos consignados", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try
        Catch ex As Exception

            If (1 = 2) Then
                Throw
            End If
        End Try
    End Sub

    Public Sub AdicionaProduto(ByVal vIDProduto As Integer, ByVal vQuantidade As Integer)
        Try
            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_CLIENTE_PRODUTO_CONSIGNADO"
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@QUANTIDADE", SqlDbType.Int).Value = vQuantidade
            cn.Open()
            Try
                cmd.ExecuteNonQuery()
                MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " esta incluindo o produto ID(" & vIDProduto & ") como consignado com a quantidade de " & vQuantidade, "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try
        Catch ex As Exception

            If (1 = 2) Then
                Throw
            End If
        End Try
    End Sub




    Public Class clsProdutosConsignados
        Inherits Generic.List(Of clsProdutoConsignado)

        Public Overloads Sub Add(ByVal vIDProduto As Integer, ByVal vEstoque As Integer)
            Dim c As New clsProdutoConsignado
            c.IDProduto = vIDProduto
            c.Estoque = vEstoque
            Me.Add(c)
        End Sub

    End Class

    Public Class clsProdutoConsignado

        Protected _IDProduto As Integer
        Protected _Estoque As Integer

        Public Property IDProduto() As Integer
            Get
                Return _IDProduto
            End Get
            Set(ByVal value As Integer)
                _IDProduto = value
            End Set
        End Property

        Public Property Estoque() As Integer
            Get
                Return _Estoque
            End Get
            Set(ByVal value As Integer)
                _Estoque = value
            End Set
        End Property
    End Class




End Class
