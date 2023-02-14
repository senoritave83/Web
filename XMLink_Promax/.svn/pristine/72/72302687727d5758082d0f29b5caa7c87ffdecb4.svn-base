

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsSar
        Inherits BaseClass



#Region "Declarations"
        Protected m_strIDCliente As String
        Protected m_strCliente As String
        Protected m_strEndereco As String
        Protected m_strContato As String
        Protected m_strSAR As String
        Protected m_strVendedor As String
        Protected m_dtmVisita As String
        Protected m_dtmEnviado As String
#End Region


#Region "Properties"

        Public Overridable ReadOnly Property IDCliente() As String
            Get
                Return m_strIDCliente
            End Get
        End Property

        Public Overridable ReadOnly Property Cliente() As String
            Get
                Return m_strCliente
            End Get
        End Property

        Public ReadOnly Property Endereco() As String
            Get
                Return m_strEndereco
            End Get
        End Property

        Public ReadOnly Property Contato() As String
            Get
                Return m_strContato
            End Get
        End Property

        Public ReadOnly Property Sar() As String
            Get
                Return m_strSAR
            End Get
        End Property

        Public Overridable ReadOnly Property Vendedor() As String
            Get
                Return m_strVendedor
            End Get
        End Property

        Public Overridable ReadOnly Property Visita() As String
            Get
                Return m_dtmVisita
            End Get
        End Property

        Public Overridable ReadOnly Property Enviado() As String
            Get
                Return m_dtmEnviado
            End Get
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            If dr.IsDBNull(dr.GetOrdinal("IDCliente")) Then
                m_strIDCliente = ""
            Else
                m_strIDCliente = dr.GetString(dr.GetOrdinal("IDCliente"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Cliente")) Then
                m_strCliente = ""
            Else
                m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Endereco")) Then
                m_strEndereco = ""
            Else
                m_strEndereco = dr.GetString(dr.GetOrdinal("Endereco"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Contato")) Then
                m_strContato = ""
            Else
                m_strContato = dr.GetString(dr.GetOrdinal("Contato"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("SAR")) Then
                m_strSAR = ""
            Else
                m_strSAR = dr.GetString(dr.GetOrdinal("SAR"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Vendedor")) Then
                m_strVendedor = ""
            Else
                m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Visita")) Then
                m_dtmVisita = ""
            Else
                m_dtmVisita = dr.GetDateTime(dr.GetOrdinal("Visita"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Enviado")) Then
                m_dtmEnviado = ""
            Else
                m_dtmEnviado = dr.GetDateTime(dr.GetOrdinal("Enviado"))
            End If
        End Sub



        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDVisita">Chave primaria IDVisita</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDVisita As String) As Boolean
            If vIDVisita = Nothing Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_SAR"
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Char).Value = vIDVisita
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
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_strIDCliente = ""
            m_strCliente = ""
            m_strEndereco = ""
            m_strContato = ""
            m_strSAR = ""
            m_strVendedor = ""
            m_dtmVisita = ""
            m_dtmEnviado = ""
        End Sub


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vVendedor">Filtro</param>
        ''' <param name="vCliente">Filtro</param>
        ''' <param name="vDataEmissaoInicial">vDataEmissaoInicial</param>
        ''' <param name="vDataEmissaoFinal">vDataEmissaoFinal</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vVendedor As String, ByVal vCliente As String, ByVal vDataEmissaoInicial As String, ByVal vDataEmissaoFinal As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_SARS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@VENDEDOR", SqlDbType.VarChar).Value = vVendedor
            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = vCliente
            If vDataEmissaoInicial <> "" Then
                cmd.Parameters.Add("@DATAEMISSAOINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataEmissaoInicial)
            End If
            If vDataEmissaoFinal <> "" Then
                cmd.Parameters.Add("@DATAEMISSAOFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataEmissaoFinal)
            End If

            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

#End Region

    End Class
End Namespace

