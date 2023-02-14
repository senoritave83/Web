

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsPromotor
        Inherits BaseClass



#Region "Declarations"
        Protected m_intIDPromotor As Integer
        Protected m_strCodigo As String
        Protected m_strPromotor As String
        Protected m_strCPF As String
        Protected m_strLogin As String
        Protected m_strSenha As String
        Protected m_strEndereco As String
        Protected m_strNumero As String
        Protected m_strComplemento As String
        Protected m_strBairro As String
        Protected m_strCep As String
        Protected m_strCidade As String
        Protected m_strUF As String
        Protected m_strContato As String
        Protected m_strTelefone As String
        Protected m_strCelular As String
        Protected m_strFax As String
        Protected m_strEmail As String
        Protected m_strCargo As String
        Protected m_strEmpresa As String
        Protected m_indTeste As Boolean
        Protected m_intIDLider As Integer
        Protected m_intIDRegiao As Integer
        Protected m_intIDStatus As Integer
        Protected m_strFoto As String
        Protected m_intIdUsuario As Integer
        Protected m_indAcessoWeb As Boolean
        Protected m_strSegmento As String
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDPromotor() As Integer
            Get
                Return m_intIDPromotor
            End Get
        End Property

        Public Overridable Property Segmento() As String
            Get
                Return m_strSegmento
            End Get
            Set(ByVal Value As String)
                m_strSegmento = Value
            End Set
        End Property

        Public Overridable Property Codigo() As String
            Get
                Return m_strCodigo
            End Get
            Set(ByVal Value As String)
                m_strCodigo = Value
            End Set
        End Property

        Public Overridable Property Promotor() As String
            Get
                Return m_strPromotor
            End Get
            Set(ByVal Value As String)
                m_strPromotor = Value
            End Set
        End Property

        Public Overridable Property CPF() As String
            Get
                Return m_strCPF
            End Get
            Set(ByVal Value As String)
                m_strCPF = Value
            End Set
        End Property

        Public Overridable Property Login() As String
            Get
                Return m_strLogin
            End Get
            Set(ByVal Value As String)
                m_strLogin = Value
            End Set
        End Property

        Public Overridable Property Senha() As String
            Get
                Return m_strSenha
            End Get
            Set(ByVal Value As String)
                m_strSenha = Value
            End Set
        End Property

        Public Overridable Property Endereco() As String
            Get
                Return m_strEndereco
            End Get
            Set(ByVal Value As String)
                m_strEndereco = Value
            End Set
        End Property

        Public Overridable Property Numero() As String
            Get
                Return m_strNumero
            End Get
            Set(ByVal Value As String)
                m_strNumero = Value
            End Set
        End Property

        Public Overridable Property Complemento() As String
            Get
                Return m_strComplemento
            End Get
            Set(ByVal Value As String)
                m_strComplemento = Value
            End Set
        End Property

        Public Overridable Property Bairro() As String
            Get
                Return m_strBairro
            End Get
            Set(ByVal Value As String)
                m_strBairro = Value
            End Set
        End Property

        Public Overridable Property Cep() As String
            Get
                Return m_strCep
            End Get
            Set(ByVal Value As String)
                m_strCep = Value
            End Set
        End Property

        Public Overridable Property Cidade() As String
            Get
                Return m_strCidade
            End Get
            Set(ByVal Value As String)
                m_strCidade = Value
            End Set
        End Property

        Public Overridable Property UF() As String
            Get
                Return m_strUF
            End Get
            Set(ByVal Value As String)
                m_strUF = Value
            End Set
        End Property

        Public Overridable Property Contato() As String
            Get
                Return m_strContato
            End Get
            Set(ByVal Value As String)
                m_strContato = Value
            End Set
        End Property

        Public Overridable Property Telefone() As String
            Get
                Return m_strTelefone
            End Get
            Set(ByVal Value As String)
                m_strTelefone = Value
            End Set
        End Property

        Public Overridable Property Celular() As String
            Get
                Return m_strCelular
            End Get
            Set(ByVal Value As String)
                m_strCelular = Value
            End Set
        End Property

        Public Overridable Property Fax() As String
            Get
                Return m_strFax
            End Get
            Set(ByVal Value As String)
                m_strFax = Value
            End Set
        End Property

        Public Overridable Property Email() As String
            Get
                Return m_strEmail
            End Get
            Set(ByVal Value As String)
                m_strEmail = Value
            End Set
        End Property

        Public Overridable Property Cargo() As String
            Get
                Return m_strCargo
            End Get
            Set(ByVal Value As String)
                m_strCargo = Value
            End Set
        End Property

        Public Overridable Property Empresa() As String
            Get
                Return m_strEmpresa
            End Get
            Set(ByVal Value As String)
                m_strEmpresa = Value
            End Set
        End Property

        Public Overridable Property Teste() As Boolean
            Get
                Return m_indTeste
            End Get
            Set(ByVal Value As Boolean)
                m_indTeste = Value
            End Set
        End Property

        Public Overridable Property IDLider() As Integer
            Get
                Return m_intIDLider
            End Get
            Set(ByVal Value As Integer)
                m_intIDLider = Value
            End Set
        End Property

        Public Overridable Property IDRegiao() As Integer
            Get
                Return m_intIDRegiao
            End Get
            Set(ByVal Value As Integer)
                m_intIDRegiao = Value
            End Set
        End Property

        Public Overridable Property IdStatus() As Integer
            Get
                Return m_intIDStatus
            End Get
            Set(ByVal Value As Integer)
                m_intIDStatus = Value
            End Set
        End Property

        Public Property Foto() As String
            Get
                Return m_strFoto
            End Get
            Set(ByVal value As String)
                m_strFoto = value
            End Set
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDPromotor = 0
            End Get
        End Property

        Public Overridable Property IdUsuario() As Integer
            Get
                Return m_intIdUsuario
            End Get
            Set(ByVal value As Integer)
                m_intIdUsuario = value
            End Set
        End Property

        Public Overridable Property AcessoWeb() As Boolean
            Get
                Return m_indAcessoWeb
            End Get
            Set(ByVal value As Boolean)
                m_indAcessoWeb = value
            End Set
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)


            m_intIDPromotor = dr.GetInt32(dr.GetOrdinal("IDPromotor"))
            m_strPromotor = dr.GetString(dr.GetOrdinal("Promotor"))
            If dr.IsDBNull(dr.GetOrdinal("Login")) Then
                m_strLogin = ""
            Else
                m_strLogin = dr.GetString(dr.GetOrdinal("Login"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Senha")) Then
                m_strSenha = ""
            Else
                m_strSenha = dr.GetString(dr.GetOrdinal("Senha"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("UF")) Then
                m_strUF = ""
            Else
                m_strUF = dr.GetString(dr.GetOrdinal("UF"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Cidade")) Then
                m_strCidade = ""
            Else
                m_strCidade = dr.GetString(dr.GetOrdinal("Cidade"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Endereco")) Then
                m_strEndereco = ""
            Else
                m_strEndereco = dr.GetString(dr.GetOrdinal("Endereco"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("CPF")) Then
                m_strCPF = ""
            Else
                m_strCPF = dr.GetString(dr.GetOrdinal("CPF"))
            End If

            If dr.IsDBNull(dr.GetOrdinal("Codigo")) Then
                m_strCodigo = ""
            Else
                m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Numero")) Then
                m_strNumero = ""
            Else
                m_strNumero = dr.GetString(dr.GetOrdinal("Numero"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Complemento")) Then
                m_strComplemento = ""
            Else
                m_strComplemento = dr.GetString(dr.GetOrdinal("Complemento"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Bairro")) Then
                m_strBairro = ""
            Else
                m_strBairro = dr.GetString(dr.GetOrdinal("Bairro"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Cep")) Then
                m_strCep = ""
            Else
                m_strCep = dr.GetString(dr.GetOrdinal("Cep"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Contato")) Then
                m_strContato = ""
            Else
                m_strContato = dr.GetString(dr.GetOrdinal("Contato"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Telefone")) Then
                m_strTelefone = ""
            Else
                m_strTelefone = dr.GetString(dr.GetOrdinal("Telefone"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Celular")) Then
                m_strCelular = ""
            Else
                m_strCelular = dr.GetString(dr.GetOrdinal("Celular"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Fax")) Then
                m_strFax = ""
            Else
                m_strFax = dr.GetString(dr.GetOrdinal("Fax"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Email")) Then
                m_strEmail = ""
            Else
                m_strEmail = dr.GetString(dr.GetOrdinal("Email"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Cargo")) Then
                m_strCargo = ""
            Else
                m_strCargo = dr.GetString(dr.GetOrdinal("Cargo"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Empresa")) Then
                m_strEmpresa = ""
            Else
                m_strEmpresa = dr.GetString(dr.GetOrdinal("Empresa"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Teste")) Then
                m_indTeste = 0
            Else
                m_indTeste = dr.GetByte(dr.GetOrdinal("Teste"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IdLider")) Then
                m_intIDLider = 0
            Else
                m_intIDLider = dr.GetInt32(dr.GetOrdinal("IdLider"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IdRegiao")) Then
                m_intIDRegiao = 0
            Else
                m_intIDRegiao = dr.GetInt32(dr.GetOrdinal("IdRegiao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IdStatus")) Then
                m_intIDStatus = 0
            Else
                m_intIDStatus = dr(dr.GetOrdinal("IdStatus"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Segmento")) Then
                m_strSegmento = ""
            Else
                m_strSegmento = dr.GetString(dr.GetOrdinal("Segmento"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Foto")) Then
                m_strFoto = ""
            Else
                m_strFoto = dr.GetString(dr.GetOrdinal("Foto"))
            End If

            m_intIdUsuario = dr.GetInt32(dr.GetOrdinal("IdUsuario"))
            m_indAcessoWeb = IIf(dr.Item("AcessoWeb") = "0", False, True)

        End Sub

        ''' <summary>
        ''' 	Funcao que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PROMOTOR"
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = m_intIDPromotor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).Value = m_strCodigo
            cmd.Parameters.Add("@PROMOTOR", SqlDbType.VarChar, 100).Value = m_strPromotor
            cmd.Parameters.Add("@CPF", SqlDbType.VarChar, 20).Value = m_strCPF
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 20).Value = m_strLogin
            cmd.Parameters.Add("@SENHA", SqlDbType.VarChar, 20).Value = m_strSenha
            cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar, 100).Value = m_strEndereco
            cmd.Parameters.Add("@NUMERO", SqlDbType.VarChar, 50).Value = m_strNumero
            cmd.Parameters.Add("@COMPLEMENTO", SqlDbType.VarChar, 20).Value = m_strComplemento
            cmd.Parameters.Add("@BAIRRO", SqlDbType.VarChar, 50).Value = m_strBairro
            cmd.Parameters.Add("@CEP", SqlDbType.VarChar, 50).Value = m_strCep
            cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar, 50).Value = m_strCidade
            cmd.Parameters.Add("@UF", SqlDbType.VarChar, 2).Value = m_strUF
            cmd.Parameters.Add("@CONTATO", SqlDbType.VarChar, 100).Value = m_strContato
            cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar, 30).Value = m_strTelefone
            cmd.Parameters.Add("@CELULAR", SqlDbType.VarChar, 30).Value = m_strCelular
            cmd.Parameters.Add("@FAX", SqlDbType.VarChar, 30).Value = m_strFax
            cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 250).Value = m_strEmail
            cmd.Parameters.Add("@CARGO", SqlDbType.VarChar, 100).Value = m_strCargo
            cmd.Parameters.Add("@EMPRESA", SqlDbType.VarChar, 100).Value = m_strEmpresa
            cmd.Parameters.Add("@TESTE", SqlDbType.TinyInt).Value = m_indTeste
            cmd.Parameters.Add("@IDLIDER", SqlDbType.Int).Value = m_intIDLider
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = m_intIDRegiao
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = m_intIDStatus
            cmd.Parameters.Add("@IMAGEM", SqlDbType.VarChar).Value = m_strFoto
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = m_intIdUsuario
            cmd.Parameters.Add("@ACESSOWEB", SqlDbType.Int).Value = m_indAcessoWeb

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

            Me.User.Log("Cadastro de Promotores", "Gravar - IDPROMOTOR=" & m_intIDPromotor & " CODIGO=" & m_strCodigo & " PROMOTOR=" & m_strPromotor & " CPF=" & m_strCPF & _
                        " LOGIN=" & m_strLogin & " SENHA=" & m_strSenha & " ENDERECO=" & m_strEndereco & " NUMERO=" & m_strNumero & " COMPLEMENTO=" & m_strComplemento & _
                        " BAIRRO=" & m_strBairro & " CEP=" & m_strCep & " CIDADE=" & m_strCidade & " UF=" & m_strUF & " CONTATO=" & m_strContato & _
                        " TELEFONE=" & m_strTelefone & " CELULAR=" & m_strCelular & " FAX=" & m_strFax & " EMAIL=" & m_strEmail & " CARGO=" & m_strCargo & _
                        " EMPRESA=" & m_strEmpresa & " TESTE=" & m_indTeste & " IDLIDER=" & m_intIDLider & " IDREGIAO=" & m_intIDRegiao & " IDSTATUS=" & m_intIDStatus & _
                        " IMAGEM=" & m_strFoto & " ACESSOWEB=" & m_indAcessoWeb)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDPromotor">Chave primaria IDPromotor</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDPromotor As Integer) As Boolean

            If vIDPromotor = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PROMOTOR"
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
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


            Me.User.Log("Cadastro de Promotores", "Visualizar - IDPROMOTOR=" & vIDPromotor)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDPromotor = 0
            m_strCodigo = ""
            m_strPromotor = ""
            m_strCPF = ""
            m_strLogin = ""
            m_strSenha = ""
            m_strEndereco = ""
            m_strNumero = ""
            m_strComplemento = ""
            m_strBairro = ""
            m_strCep = ""
            m_strCidade = ""
            m_strUF = ""
            m_strContato = ""
            m_strTelefone = ""
            m_strCelular = ""
            m_strFax = ""
            m_strEmail = ""
            m_strCargo = ""
            m_strEmpresa = ""
            m_indTeste = 0
            m_intIDLider = 0
            m_intIDRegiao = 0
            m_intIDStatus = 0
            m_strFoto = ""
            m_intIdUsuario = 0
            m_strSegmento = ""
            m_indAcessoWeb = False
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PROMOTOR"
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = m_intIDPromotor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Promotor' the following row:  IDPromotor=" & m_intIDPromotor & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

            Me.User.Log("Cadastro de Promotores", "Apagar - IDPROMOTOR=" & m_intIDPromotor)

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(Optional ByVal vIdLider As Integer = 0, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PROMOTORES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDLIDER", SqlDbType.Int).Value = vIdLider
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal p_Lideres As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PROMOTORES_LIDER"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@LIDERES", SqlDbType.VarChar, 1000).Value = p_Lideres
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarPromotor_Recado(ByVal p_Lideres As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PROMOTORES_LIDER_RECADOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@LIDERES", SqlDbType.VarChar, 1000).Value = p_Lideres
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal p_Lideres As String, ByVal p_Coordenadores As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PROMOTORES_LIDER"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@LIDERES", SqlDbType.VarChar, 1000).Value = p_Lideres
            cmd.Parameters.Add("@COORDENADORES", SqlDbType.VarChar, 1000).Value = p_Coordenadores
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarPromotorSegmento(ByVal p_Coordenadores As String, ByVal p_Lideres As String, ByVal p_Segmento As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PROMOTORES_SEGMENTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@LIDERES", SqlDbType.VarChar, 1000).Value = p_Lideres
            cmd.Parameters.Add("@COORDENADORES", SqlDbType.VarChar, 1000).Value = p_Coordenadores
            cmd.Parameters.Add("@SEGMENTO", SqlDbType.VarChar, 1000).Value = p_Segmento
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vUF">Filtro</param>
        ''' <param name="vTeste">Filtro</param>
        ''' <param name="vIDLider">Filtro</param>
        ''' <param name="vIDRegiao">Filtro</param>
        ''' <param name="vIDCoordenador">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vUF As String, ByVal vTeste As Integer, ByVal vIDLider As Integer, _
                               ByVal vIDRegiao As Integer, ByVal vIDCoordenador As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, _
                               ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vIdStatus As Integer = 3, _
                               Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult


            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PROMOTORES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@UF", SqlDbType.VarChar, 2).Value = vUF
            cmd.Parameters.Add("@TESTE", SqlDbType.Int).Value = vTeste
            cmd.Parameters.Add("@IDLIDER", SqlDbType.Int).Value = vIDLider
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = vIDRegiao
            cmd.Parameters.Add("@IDCOORDENADOR", SqlDbType.Int).Value = vIDCoordenador
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = vIdStatus

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDLider">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDLider As Integer, ByVal vIDPromotor As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, ByVal vIdStatus As Integer, Optional ByVal vIDCoordenador As Integer = 0, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PROMOTORES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            'cmd.Parameters.Add("@UF", SqlDbType.VarChar, 2).Value = vUF
            'cmd.Parameters.Add("@TESTE", SqlDbType.Int).Value = vTeste
            cmd.Parameters.Add("@IDLIDER", SqlDbType.Int).Value = vIDLider
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            'cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = vIDRegiao
            cmd.Parameters.Add("@IDCOORDENADOR", SqlDbType.Int).Value = vIDCoordenador
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = vIdStatus

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a Função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDPromotor">Chave primaria do registro atual.</param>
        ''' <param name="vCodigo">Codigo que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDPromotor As Integer, ByVal vCodigo As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PROMOTOR_EXISTENTE"
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).Value = vCodigo

            Return ExecuteScalar(cmd)

        End Function

        Public Function LoginExiste(ByVal vIDPromotor As Integer, ByVal vLogin As String, ByVal vSenha As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PROMOTOR_LOGIN_EXISTENTE"
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = vIDPromotor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 20).Value = vLogin
            cmd.Parameters.Add("@SENHA", SqlDbType.VarChar, 20).Value = vSenha

            Return ExecuteScalar(cmd)

        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If Existe(m_intIDPromotor, m_strCodigo) Then
                blnValid = False
                AddBrokenRule("Promotor já existente!")
            ElseIf LoginExiste(m_intIDPromotor, m_strLogin, m_strSenha) Then
                blnValid = False
                AddBrokenRule("Login já existe!")
            ElseIf CPFExiste(m_strCPF) Then
                blnValid = False
                AddBrokenRule("CPF j&aacute; existe!")
            End If

            Return blnValid
        End Function

        Protected Function CPFExiste(ByVal vCPF As String) As Boolean
            Dim blnExiste As Boolean = False

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PROMOTOR_CPF_EXISTENTE"
            Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            parameter.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(parameter)
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = m_intIDPromotor
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CPF", SqlDbType.VarChar, 20).Value = vCPF

            ExecuteNonQuery(cmd)

            blnExiste = (cmd.Parameters("@RETURN_VALUE").Value = 1)
            Return blnExiste

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa de produtos do promotor
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarProdutos(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PROMOTOR_PRODUTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = m_intIDPromotor
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        Public Sub AdicionarProdutos(ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, ByVal vIDProduto As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PROMOTOR_PRODUTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = m_intIDPromotor
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Promotores", "AdicionarProdutos - IDPROMOTOR=" & m_intIDPromotor & " IDSUBCATEGORIA=" & vIDSubCategoria & " IDCATEGORIA=" & vIDCategoria & _
                        " IDPRODUTO=" & vIDProduto)

        End Sub

        Public Sub RetirarProdutos(ByVal vIDPromotorProduto As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PROMOTOR_PRODUTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROMOTOR", SqlDbType.Int).Value = m_intIDPromotor
            cmd.Parameters.Add("@IDPROMOTORPRODUTO", SqlDbType.Int).Value = vIDPromotorProduto

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Promotores", "RetirarProdutos - IDPROMOTOR=" & m_intIDPromotor & " IDPROMOTORPRODUTO=" & vIDPromotorProduto)

        End Sub


#End Region



    End Class
End Namespace

