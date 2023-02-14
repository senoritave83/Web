
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsCampoAdicional
        Inherits BaseClass

#Region "Declarations"
        Protected m_intIDCampoAdicional As Integer
        Protected m_strEntidade As String
        Protected m_strNome As String
        Protected m_strFormato As String
        Protected m_varRequirido As Boolean
        Protected m_indTipo As Byte
        Protected m_indTamanho As Byte
        Protected m_indTamanhoMaximo As Byte
        Protected m_varQuebraLinha As Boolean
        Protected m_blnIsNew As Boolean = True
#End Region


#Region "Properties"

        Public Overridable ReadOnly Property IDCampoAdicional() As Integer
            Get
                Return m_intIDCampoAdicional
            End Get
        End Property

        Public Overridable ReadOnly Property Entidade() As String
            Get
                Return m_strEntidade
            End Get
        End Property

        Public Overridable Property Nome() As String
            Get
                Return m_strNome
            End Get
            Set(ByVal Value As String)
                m_strNome = Value
            End Set
        End Property

        Public Overridable Property Formato() As String
            Get
                Return m_strFormato
            End Get
            Set(ByVal Value As String)
                m_strFormato = Value
            End Set
        End Property

        Public Overridable Property Requirido() As Boolean
            Get
                Return m_varRequirido
            End Get
            Set(ByVal Value As Boolean)
                m_varRequirido = Value
            End Set
        End Property

        Public Overridable Property Tipo() As Byte
            Get
                Return m_indTipo
            End Get
            Set(ByVal Value As Byte)
                m_indTipo = Value
            End Set
        End Property

        Public Overridable Property QuebraDeLinha() As Boolean
            Get
                Return m_varQuebraLinha
            End Get
            Set(ByVal Value As Boolean)
                m_varQuebraLinha = Value
            End Set
        End Property

        Public Overridable Property Tamanho() As Byte
            Get
                Return m_indTamanho
            End Get
            Set(ByVal Value As Byte)
                m_indTamanho = Value
            End Set
        End Property

        Public Overridable Property TamanhoMaximo() As Byte
            Get
                Return m_indTamanhoMaximo
            End Get
            Set(ByVal Value As Byte)
                m_indTamanhoMaximo = Value
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
            m_intIDCampoAdicional = dr.GetInt32(dr.GetOrdinal("IDCampoAdicional"))
            m_strEntidade = dr.GetString(dr.GetOrdinal("Entidade"))
            m_strNome = dr.GetString(dr.GetOrdinal("Nome"))
            m_strFormato = dr.GetString(dr.GetOrdinal("Formato"))
            m_varRequirido = dr.GetBoolean(dr.GetOrdinal("Requirido"))
            m_indTipo = dr.GetByte(dr.GetOrdinal("Tipo"))
            m_varQuebraLinha = dr.GetBoolean(dr.GetOrdinal("QuebraDeLinha"))
            m_indTamanho = dr.GetInt32(dr.GetOrdinal("Tamanho"))
            m_indTamanhoMaximo = dr.GetInt32(dr.GetOrdinal("TamanhoMaximo"))
            m_blnIsNew = False
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_CAMPOADICIONAL"
            cmd.Parameters.Add("@IDCAMPOADICIONAL", SqlDbType.Int).Value = m_intIDCampoAdicional
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@ENTIDADE", SqlDbType.VarChar, 20).Value = m_strEntidade
            cmd.Parameters.Add("@NOME", SqlDbType.VarChar, 100).Value = m_strNome
            cmd.Parameters.Add("@FORMATO", SqlDbType.VarChar, 30).Value = m_strFormato
            cmd.Parameters.Add("@REQUIRIDO", SqlDbType.Bit).Value = m_varRequirido
            cmd.Parameters.Add("@TIPO", SqlDbType.TinyInt).Value = m_indTipo
            cmd.Parameters.Add("@TAMANHO", SqlDbType.TinyInt).Value = m_indTamanho
            cmd.Parameters.Add("@TAMANHOMAXIMO", SqlDbType.TinyInt).Value = m_indTamanhoMaximo
            cmd.Parameters.Add("@QUEBRADELINHA", SqlDbType.Bit).Value = m_varQuebraLinha
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
            Me.User.Log("Cadastro de Campos Adicionais", "Gravar - IDCAMPOADICIONAL=" & m_intIDCampoAdicional & " ENTIDADE=" & m_strEntidade & " NOME=" & m_strNome & _
                        " FORMATO=" & m_strFormato & " REQUIRIDO=" & m_varRequirido & " TIPO=" & m_indTipo & " TAMANHO=" & m_indTamanho & " TAMANHOMAXIMO=" & m_indTamanhoMaximo & _
                        " QUEBRADELINHA=" & m_varQuebraLinha)
        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDCampoAdicional">Chave primaria IDCampoAdicional</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDCampoAdicional As Integer, ByVal vEntidade As String) As Boolean
            m_strEntidade = vEntidade
            If vIDCampoAdicional = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CAMPOADICIONAL"
            cmd.Parameters.Add("@IDCAMPOADICIONAL", SqlDbType.Int).Value = vIDCampoAdicional
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@ENTIDADE", SqlDbType.VarChar, 20).Value = vEntidade
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

            Me.User.Log("Cadastro de Campos Adicionais", "Visualizar - IDCAMPOADICIONAL=" & vIDCampoAdicional & " ENTIDADE=" & vEntidade)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDCampoAdicional = 0
            m_strNome = ""
            m_strFormato = ""
            m_varRequirido = Nothing
            m_indTipo = 0
            m_varQuebraLinha = Nothing
            m_indTamanho = 0
            m_indTamanhoMaximo = 0
            m_blnIsNew = True
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_CAMPOADICIONAL"
            cmd.Parameters.Add("@IDCAMPOADICIONAL", SqlDbType.Int).Value = m_intIDCampoAdicional
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Campos Adicionais", "Apagar - IDCAMPOADICIONAL=" & m_intIDCampoAdicional)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'CamposAdicional' the following row:  IDCampoAdicional=" & m_intIDCampoAdicional & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vEntidade As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CAMPOADICIONAIS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@ENTIDADE", SqlDbType.VarChar, 20).Value = vEntidade
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarOpcoes(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Return ListarOpcoes(Me.Entidade, Me.IDCampoAdicional, vReturnType)
        End Function



        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarOpcoes(ByVal vEntidade As String, ByVal vIDCampoAdicional As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CAMPOADICIONAL_OPCOES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@ENTIDADE", SqlDbType.VarChar, 20).Value = vEntidade
            cmd.Parameters.Add("@IDCAMPOADICIONAL", SqlDbType.Int).Value = vIDCampoAdicional
            Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que adiciona o texto na lista de opções do campo adicional
        ''' </summary>
        ''' <param name="vTexto">Texto da opção do campo adicional</param>		
        Public Sub AdicionarOpcao(ByVal vTexto As String)
            AdicionarOpcao(m_intIDCampoAdicional, m_strEntidade, vTexto)
        End Sub


        ''' <summary>
        ''' 	Função que adiciona o texto na lista de opções do campo adicional
        ''' </summary>
        ''' <param name="vEntidade">Entidade do campo adicional</param>		
        ''' <param name="vIDCampoAdicional">ID do campo adicional</param>		
        ''' <param name="vTexto">Texto da opção do campo adicional</param>		
        Public Sub AdicionarOpcao(ByVal vEntidade As String, ByVal vIDCampoAdicional As Integer, ByVal vTexto As String)

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "IN_CAMPOADICIONAL_OPCAO"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@ENTIDADE", SqlDbType.VarChar, 20).Value = vEntidade
            cmd.Parameters.Add("@IDCAMPOADICIONAL", SqlDbType.Int).Value = vIDCampoAdicional
            cmd.Parameters.Add("@OPCAO", SqlDbType.VarChar, 255).Value = vTexto
            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Campos Adicionais", "AdicionarOpcao - ENTIDADE=" & vEntidade & " IDCAMPOADICIONAL=" & vIDCampoAdicional & " OPCAO=" & vTexto)

        End Sub


        ''' <summary>
        ''' 	Função que exclui o texto da lista de opções do campo adicional
        ''' </summary>
        ''' <param name="vTexto">Texto da opção do campo adicional</param>		
        Public Sub ExcluirOpcao(ByVal vTexto As String)

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "DE_CAMPOADICIONAL_OPCAO"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@ENTIDADE", SqlDbType.VarChar, 20).Value = m_strEntidade
            cmd.Parameters.Add("@IDCAMPOADICIONAL", SqlDbType.Int).Value = m_intIDCampoAdicional
            cmd.Parameters.Add("@OPCAO", SqlDbType.VarChar, 255).Value = vTexto
            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Campos Adicionais", "ExcluirOpcao - ENTIDADE=" & m_strEntidade & " IDCAMPOADICIONAL=" & m_intIDCampoAdicional & " OPCAO=" & vTexto)

        End Sub



        Public Sub GravarValor(ByVal vIDReferencia As Integer, ByVal vEntidade As String, ByVal vIDCampoAdicional As Integer, ByVal vValor As String)
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "SV_CAMPOADICIONAL_VALOR"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@ENTIDADE", SqlDbType.VarChar, 20).Value = vEntidade
            cmd.Parameters.Add("@IDCAMPOADICIONAL", SqlDbType.Int).Value = vIDCampoAdicional
            cmd.Parameters.Add("@IDREFERENCIA", SqlDbType.Int).Value = vIDReferencia
            cmd.Parameters.Add("@VALOR", SqlDbType.VarChar, 255).Value = vValor
            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Campos Adicionais", "GravarValor - ENTIDADE=" & vEntidade & " IDCAMPOADICIONAL=" & vIDCampoAdicional & " IDREFERENCIA=" & vIDReferencia & " VALOR=" & vValor)

        End Sub






        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vAtivo">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vEntidade As String, ByVal vFilter As String, ByVal vAtivo As Byte, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_CAMPOADICIONAIS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@ENTIDADE", SqlDbType.VarChar, 20).Value = vEntidade
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@ATIVO", SqlDbType.TinyInt).Value = vAtivo
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa com os valores prenchidos para a entidade informada
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarValores(ByVal vEntidade As String, ByVal vIDReferencia As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CAMPOADICIONAIS_VALORES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@ENTIDADE", SqlDbType.VarChar, 20).Value = vEntidade
            cmd.Parameters.Add("@REFERENCIA", SqlDbType.Int).Value = vIDReferencia
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim ret As Boolean = True
            If m_strEntidade = "" Then
                AddBrokenRule("Entidade é obrigatorio")
                ret = False
            End If
            If m_strNome = "" Then
                AddBrokenRule("Nome é obrigatorio")
                ret = False
            End If
            Return ret
        End Function

#End Region

    End Class
End Namespace