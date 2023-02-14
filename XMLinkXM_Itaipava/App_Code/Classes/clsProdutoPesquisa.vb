Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsProdutoPesquisa
        Inherits BaseClass



#Region "Declarations"

        Protected m_intIdProdutoPesquisa As Integer
        Protected m_intIdCategoriaPesquisa As Integer
        Protected m_strCodigo As String
        Protected m_strProdutoPesquisa As String
        Protected m_strCriado As String
        Protected m_intTipoPergunta As Integer
        Protected m_decPrecoPontaMinimo As String
        Protected m_decPrecoPontaMaximo As String
        Protected m_decPrecoVarejoMinimo As String
        Protected m_decPrecoVarejoMaximo As String
        Protected m_blnAtivo As Boolean
        Protected m_blnIsNew As Boolean = True

#End Region


#Region "Properties"

        Public Overridable ReadOnly Property IDProdutoPesquisa As Integer
            Get
                Return m_intIdProdutoPesquisa
            End Get
        End Property

        Public Overridable Property IDCategoriaPesquisa As Integer
            Get
                Return m_intIdCategoriaPesquisa
            End Get
            Set(value As Integer)
                m_intIdCategoriaPesquisa = value
            End Set
        End Property

        Public Overridable Property Codigo As String
            Get
                Return m_strCodigo
            End Get
            Set(ByVal Value As String)
                m_strCodigo = Value
            End Set
        End Property

        Public Overridable Property ProdutoPesquisa As String
            Get
                Return m_strProdutoPesquisa
            End Get
            Set(ByVal Value As String)
                m_strProdutoPesquisa = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Criado As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
        End Property

        Public Overridable Property TipoPergunta As Integer
            Get
                Return m_intTipoPergunta
            End Get
            Set(ByVal Value As Integer)
                m_intTipoPergunta = Value
            End Set
        End Property

        Public Overridable Property PrecoPontaMinimo As String
            Get
                Return m_decPrecoPontaMinimo
            End Get
            Set(ByVal Value As String)
                m_decPrecoPontaMinimo = Value
            End Set
        End Property

        Public Overridable Property PrecoPontaMaximo As String
            Get
                Return m_decPrecoPontaMaximo
            End Get
            Set(ByVal Value As String)
                m_decPrecoPontaMaximo = Value
            End Set
        End Property

        Public Overridable Property PrecoVarejoMinimo As String
            Get
                Return m_decPrecoVarejoMinimo
            End Get
            Set(ByVal Value As String)
                m_decPrecoVarejoMinimo = Value
            End Set
        End Property

        Public Overridable Property PrecoVarejoMaximo As String
            Get
                Return m_decPrecoVarejoMaximo
            End Get
            Set(ByVal Value As String)
                m_decPrecoVarejoMaximo = Value
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

            m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
            m_intIdProdutoPesquisa = dr.GetInt32(dr.GetOrdinal("IDProdutoPesquisa"))
            m_intIdCategoriaPesquisa = dr.GetInt32(dr.GetOrdinal("IDCategoriaPesquisa"))
            m_strProdutoPesquisa = dr.GetString(dr.GetOrdinal("ProdutoPesquisa"))
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            m_intTipoPergunta = dr.GetInt32(dr.GetOrdinal("TipoPergunta"))

            If IsDBNull(dr.Item(dr.GetOrdinal("PrecoPontaMinimo"))) = True Then
                m_decPrecoPontaMinimo = ""
            Else
                m_decPrecoPontaMinimo = dr.Item(dr.GetOrdinal("PrecoPontaMinimo"))
            End If

            If IsDBNull(dr.Item(dr.GetOrdinal("PrecoPontaMaximo"))) = True Then
                m_decPrecoPontaMaximo = ""
            Else
                m_decPrecoPontaMaximo = dr.Item(dr.GetOrdinal("PrecoPontaMaximo"))
            End If

            If IsDBNull(dr.Item(dr.GetOrdinal("PrecoVarejoMinimo"))) = True Then
                m_decPrecoVarejoMinimo = ""
            Else
                m_decPrecoVarejoMinimo = dr.Item(dr.GetOrdinal("PrecoVarejoMinimo"))
            End If

            If IsDBNull(dr.Item(dr.GetOrdinal("PrecoVarejoMaximo"))) = True Then
                m_decPrecoVarejoMaximo = ""
            Else
                m_decPrecoVarejoMaximo = dr.Item(dr.GetOrdinal("PrecoVarejoMaximo"))
            End If

            m_blnIsNew = False

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PRODUTOPESQUISA"
            cmd.Parameters.Add("@IDPRODUTOPESQUISA", SqlDbType.Int).Value = m_intIdProdutoPesquisa
            cmd.Parameters.Add("@IDCATEGORIAPESQUISA", SqlDbType.Int).Value = m_intIdCategoriaPesquisa
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = m_strCodigo
            cmd.Parameters.Add("@PRODUTOPESQUISA", SqlDbType.VarChar, 50).Value = m_strProdutoPesquisa
            cmd.Parameters.Add("@TIPOPERGUNTA", SqlDbType.Int).Value = m_intTipoPergunta
            If m_decPrecoPontaMinimo <> "" Then
                cmd.Parameters.Add("@PRECOPONTAMINIMO", SqlDbType.Money).Value = m_decPrecoPontaMinimo
            End If
            If m_decPrecoPontaMaximo <> "" Then
                cmd.Parameters.Add("@PRECOPONTAMAXIMO", SqlDbType.Money).Value = m_decPrecoPontaMaximo
            End If
            If m_decPrecoVarejoMinimo <> "" Then
                cmd.Parameters.Add("@PRECOVAREJOMINIMO", SqlDbType.Money).Value = m_decPrecoVarejoMinimo
            End If
            If m_decPrecoVarejoMaximo <> "" Then
                cmd.Parameters.Add("@PRECOVAREJOMAXIMO", SqlDbType.Money).Value = m_decPrecoVarejoMaximo
            End If

            cmd.Parameters.Add("@ATIVO", SqlDbType.TinyInt).Value = m_blnAtivo

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
        ''' <param name="vIDProdutoPesquisa">Chave primaria IDProdutoPesquisa</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDProdutoPesquisa As Integer) As Boolean

            Dim blnReturn As Boolean = False
            If vIDProdutoPesquisa = 0 Then
                Clear()
                Return blnReturn
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PRODUTOPESQUISA"
            cmd.Parameters.Add("@IDPRODUTOPESQUISA", SqlDbType.Int).Value = vIDProdutoPesquisa

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

            Return blnReturn

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()

            m_intIdProdutoPesquisa = 0
            m_intIdCategoriaPesquisa = 0
            m_strCodigo = ""
            m_strProdutoPesquisa = ""
            m_strCriado = ""
            m_blnIsNew = True
            m_intTipoPergunta = 0
            m_decPrecoPontaMinimo = 0
            m_decPrecoPontaMaximo = 0
            m_decPrecoVarejoMinimo = 0
            m_decPrecoVarejoMaximo = 0

            m_blnAtivo = False

        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PRODUTOPESQUISA"
            cmd.Parameters.Add("@IDPRODUTOPESQUISA", SqlDbType.Int).Value = m_intIdProdutoPesquisa

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'ProdutoPesquisa' the following row:  IDProdutoPesquisa=" & m_intIdProdutoPesquisa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vIDCategoriaPesquisa As Integer = 0, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PRODUTOSPESQUISA"
            cmd.Parameters.Add("@IDCATPESQUISA", SqlDbType.Int).Value = vIDCategoriaPesquisa
            cmd.CommandType = CommandType.StoredProcedure
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PRODUTOSPESQUISA"
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

#End Region

    End Class
End Namespace

