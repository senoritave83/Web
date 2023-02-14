

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsLoja
        Inherits BaseClass

        Public Enum STATUS_LOJA
            INATIVO = 0
            ATIVO = 1
            TODOS = 2
        End Enum

        Public Enum TIPO_CADASTRO_CODIGO
            CODIGO_IGUAL_CNPJ = 1
            CODIGO_AUTOMATICO = 2
            CODIGO_DEFINIDO_PELO_USUARIO = 4
        End Enum

#Region "Declarations"
        Protected m_intIDLoja As Integer
        Protected m_intIDCliente As Integer
        Protected m_strCodigo As String
        Protected m_strLoja As String
        Protected m_strCNPJ As String
        Protected m_strIE As String
        Protected m_strEndereco As String
        Protected m_strNumero As String
        Protected m_strComplemento As String
        Protected m_strBairro As String
        Protected m_strCidade As String
        Protected m_strUF As String
        Protected m_strCep As String
        Protected m_strContato As String
        Protected m_strCargo As String
        Protected m_strTelefone As String
        Protected m_strCelular As String
        Protected m_strFax As String
        Protected m_strEmail As String
        Protected m_intIDTipoLoja As Integer
        Protected m_intIdShopping As Integer
        Protected m_intIDUltimaVisita As Integer
        Protected m_intIDRegiao As Integer
        Protected m_indStatus As Byte
        Protected m_strFilial As String
        Protected m_strRazaoSocial As String
        Protected m_strGerenteLoja As String
        Protected m_strImagem As String
        Protected m_strOBS As String

        Protected m_TipoCadastroCodigo As TIPO_CADASTRO_CODIGO

#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDLoja() As Integer
            Get
                Return m_intIDLoja
            End Get
        End Property

        Public Overridable Property TipoCadastroCodigo() As TIPO_CADASTRO_CODIGO
            Get
                Return m_TipoCadastroCodigo
            End Get
            Set(ByVal Value As TIPO_CADASTRO_CODIGO)
                m_TipoCadastroCodigo = Value
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

        Public Overridable Property Codigo() As String
            Get
                Return m_strCodigo
            End Get
            Set(ByVal Value As String)
                m_strCodigo = Value
            End Set
        End Property

        Public Overridable Property Loja() As String
            Get
                Return m_strLoja
            End Get
            Set(ByVal Value As String)
                m_strLoja = Value
            End Set
        End Property

        Public Overridable Property CNPJ() As String
            Get
                Return m_strCNPJ
            End Get
            Set(ByVal Value As String)
                m_strCNPJ = Value
            End Set
        End Property

        Public Overridable Property IE() As String
            Get
                Return m_strIE
            End Get
            Set(ByVal Value As String)
                m_strIE = Value
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

        Public Overridable Property Cep() As String
            Get
                Return m_strCep
            End Get
            Set(ByVal Value As String)
                m_strCep = Value
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

        Public Overridable Property Cargo() As String
            Get
                Return m_strCargo
            End Get
            Set(ByVal Value As String)
                m_strCargo = Value
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

        Public Overridable Property IDTipoLoja() As Integer
            Get
                Return m_intIDTipoLoja
            End Get
            Set(ByVal Value As Integer)
                m_intIDTipoLoja = Value
            End Set
        End Property

        Public Overridable Property IdShopping() As Integer
            Get
                Return m_intIdShopping
            End Get
            Set(ByVal Value As Integer)
                m_intIdShopping = Value
            End Set
        End Property

        Public Overridable Property IDUltimaVisita() As Integer
            Get
                Return m_intIDUltimaVisita
            End Get
            Set(ByVal Value As Integer)
                m_intIDUltimaVisita = Value
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

        Public Overridable Property Status() As Byte
            Get
                Return m_indStatus
            End Get
            Set(ByVal Value As Byte)
                m_indStatus = Value
            End Set
        End Property


        Public Overridable Property Filial() As String
            Get
                Return m_strFilial
            End Get
            Set(ByVal Value As String)
                m_strFilial = Value
            End Set
        End Property

        Public Overridable Property RazaoSocial() As String
            Get
                Return m_strRazaoSocial
            End Get
            Set(ByVal Value As String)
                m_strRazaoSocial = Value
            End Set
        End Property

        Public Overridable Property GerenteLoja() As String
            Get
                Return m_strGerenteLoja
            End Get
            Set(ByVal Value As String)
                m_strGerenteLoja = Value
            End Set
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDLoja = 0
            End Get
        End Property

        Public Overridable Property Imagem() As String
            Get
                Return m_strImagem
            End Get
            Set(ByVal value As String)
                m_strImagem = value
            End Set
        End Property

        Public Overridable Property Observacoes() As String
            Get
                Return m_strOBS
            End Get
            Set(ByVal Value As String)
                m_strOBS = Value
            End Set
        End Property

#End Region


#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>

        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDLoja = dr.GetInt32(dr.GetOrdinal("IDLoja"))
            If dr.IsDBNull(dr.GetOrdinal("IDCliente")) Then
                m_intIDCliente = 0
            Else
                m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IDCliente"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Codigo")) Then
                m_strCodigo = ""
            Else
                m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
            End If
            m_strLoja = dr.GetString(dr.GetOrdinal("Loja"))
            If dr.IsDBNull(dr.GetOrdinal("CNPJ")) Then
                m_strCNPJ = ""
            Else
                m_strCNPJ = dr.GetString(dr.GetOrdinal("CNPJ"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IE")) Then
                m_strIE = ""
            Else
                m_strIE = dr.GetString(dr.GetOrdinal("IE"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Endereco")) Then
                m_strEndereco = ""
            Else
                m_strEndereco = dr.GetString(dr.GetOrdinal("Endereco"))
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
            If dr.IsDBNull(dr.GetOrdinal("Cidade")) Then
                m_strCidade = ""
            Else
                m_strCidade = dr.GetString(dr.GetOrdinal("Cidade"))
            End If
            m_strUF = dr.GetString(dr.GetOrdinal("UF"))
            If dr.IsDBNull(dr.GetOrdinal("Cep")) Then
                m_strCep = ""
            Else
                m_strCep = dr.GetString(dr.GetOrdinal("Cep")).Trim
            End If
            If dr.IsDBNull(dr.GetOrdinal("Contato")) Then
                m_strContato = ""
            Else
                m_strContato = dr.GetString(dr.GetOrdinal("Contato"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Cargo")) Then
                m_strCargo = ""
            Else
                m_strCargo = dr.GetString(dr.GetOrdinal("Cargo"))
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
            If dr.IsDBNull(dr.GetOrdinal("IDTipoLoja")) Then
                m_intIDTipoLoja = 0
            Else
                m_intIDTipoLoja = dr.GetInt32(dr.GetOrdinal("IDTipoLoja"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IdShopping")) Then
                m_intIdShopping = 0
            Else
                m_intIdShopping = dr.GetInt32(dr.GetOrdinal("IdShopping"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDUltimaVisita")) Then
                m_intIDUltimaVisita = 0
            Else
                m_intIDUltimaVisita = dr.GetInt32(dr.GetOrdinal("IDUltimaVisita"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDRegiao")) Then
                m_intIDRegiao = 0
            Else
                m_intIDRegiao = dr.GetInt32(dr.GetOrdinal("IDRegiao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Status")) Then
                m_indStatus = 0
            Else
                m_indStatus = dr.GetByte(dr.GetOrdinal("Status"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Filial")) Then
                m_strFilial = ""
            Else
                m_strFilial = dr.GetString(dr.GetOrdinal("Filial"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("RazaoSocial")) Then
                m_strRazaoSocial = ""
            Else
                m_strRazaoSocial = dr.GetString(dr.GetOrdinal("RazaoSocial"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("GerenteLoja")) Then
                m_strGerenteLoja = ""
            Else
                m_strGerenteLoja = dr.GetString(dr.GetOrdinal("GerenteLoja"))
            End If

            If dr.IsDBNull(dr.GetOrdinal("Imagem")) Then
                m_strImagem = ""
            Else
                m_strImagem = dr.GetString(dr.GetOrdinal("Imagem"))
            End If

            If dr.IsDBNull(dr.GetOrdinal("Observacoes")) Then
                m_strOBS = ""
            Else
                m_strOBS = dr.GetString(dr.GetOrdinal("Observacoes"))
            End If

        End Sub

        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_LOJA"
            cmd.Parameters.Add("@TIPOCADASTROLOJA", SqlDbType.TinyInt).Value = m_TipoCadastroCodigo
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = m_intIDLoja
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).Value = m_strCodigo
            cmd.Parameters.Add("@LOJA", SqlDbType.VarChar, 200).Value = m_strLoja
            cmd.Parameters.Add("@CNPJ", SqlDbType.VarChar, 20).Value = m_strCNPJ
            cmd.Parameters.Add("@IE", SqlDbType.VarChar, 20).Value = m_strIE
            cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar, 100).Value = m_strEndereco
            cmd.Parameters.Add("@NUMERO", SqlDbType.VarChar, 20).Value = m_strNumero
            cmd.Parameters.Add("@COMPLEMENTO", SqlDbType.VarChar, 30).Value = m_strComplemento
            cmd.Parameters.Add("@BAIRRO", SqlDbType.VarChar, 50).Value = m_strBairro
            cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar, 100).Value = m_strCidade
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = m_strUF
            cmd.Parameters.Add("@CEP", SqlDbType.Char, 9).Value = m_strCep
            cmd.Parameters.Add("@CONTATO", SqlDbType.VarChar, 50).Value = m_strContato
            cmd.Parameters.Add("@CARGO", SqlDbType.VarChar, 30).Value = m_strCargo
            cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar, 20).Value = m_strTelefone
            cmd.Parameters.Add("@CELULAR", SqlDbType.VarChar, 20).Value = m_strCelular
            cmd.Parameters.Add("@FAX", SqlDbType.VarChar, 20).Value = m_strFax
            cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 100).Value = m_strEmail
            cmd.Parameters.Add("@IDTIPOLOJA", SqlDbType.Int).Value = m_intIDTipoLoja
            cmd.Parameters.Add("@IDSHOPPING", SqlDbType.Int).Value = m_intIdShopping
            cmd.Parameters.Add("@IDULTIMAVISITA", SqlDbType.Int).Value = m_intIDUltimaVisita
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = m_intIDRegiao
            cmd.Parameters.Add("@STATUS", SqlDbType.TinyInt).Value = m_indStatus
            cmd.Parameters.Add("@FILIAL", SqlDbType.VarChar, 100).Value = m_strFilial
            cmd.Parameters.Add("@RAZAOSOCIAL", SqlDbType.VarChar, 200).Value = m_strRazaoSocial
            cmd.Parameters.Add("@GERENTELOJA", SqlDbType.VarChar, 100).Value = m_strGerenteLoja
            cmd.Parameters.Add("@IMAGEM", SqlDbType.VarChar).Value = m_strImagem
            cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = m_strOBS

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

            Me.User.Log("Cadastro de Lojas", "Gravar - IDLOJA=" & m_intIDLoja & " IDCLIENTE=" & m_intIDCliente & " CODIGO=" & m_strCodigo & " LOJA=" & m_strLoja & " CNPJ=" & m_strCNPJ & _
                        " IE=" & m_strIE & " ENDERECO=" & m_strEndereco & " NUMERO=" & m_strNumero & " COMPLEMENTO=" & m_strComplemento & " BAIRRO=" & m_strBairro & _
                        " CIDADE=" & m_strCidade & " UF=" & m_strUF & " CEP=" & m_strCep & " CONTATO=" & m_strContato & " CARGO=" & m_strCargo & " TELEFONE=" & m_strTelefone & _
                        " CELULAR=" & m_strCelular & " FAX=" & m_strFax & " EMAIL=" & m_strEmail & " IDTIPOLOJA=" & m_intIDTipoLoja & " IDSHOPPING=" & m_intIdShopping & _
                        " IDULTIMAVISITA=" & m_intIDUltimaVisita & " IDREGIAO=" & m_intIDRegiao & " STATUS=" & m_indStatus & " FILIAL=" & m_strFilial & _
                        " RAZAOSOCIAL=" & m_strRazaoSocial & " GERENTELOJA=" & m_strGerenteLoja & " IMAGEM=" & m_strImagem & " OBS=" & m_strOBS)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDLoja">Chave primaria IDLoja</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDLoja As Integer) As Boolean

            If vIDLoja = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_LOJA"
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
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

            Me.User.Log("Cadastro de Lojas", "Visualizar - IDLOJA=" & vIDLoja)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDLoja = 0
            m_intIDCliente = 0
            m_strCodigo = ""
            m_strLoja = ""
            m_strCNPJ = ""
            m_strIE = ""
            m_strEndereco = ""
            m_strNumero = ""
            m_strComplemento = ""
            m_strBairro = ""
            m_strCidade = ""
            m_strUF = ""
            m_strCep = ""
            m_strContato = ""
            m_strCargo = ""
            m_strTelefone = ""
            m_strCelular = ""
            m_strFax = ""
            m_strEmail = ""
            m_intIDTipoLoja = 0
            m_intIdShopping = 0
            m_intIDUltimaVisita = 0
            m_intIDRegiao = 0
            m_indStatus = 0
            m_strFilial = ""
            m_strRazaoSocial = ""
            m_strGerenteLoja = ""
            m_strImagem = ""
            m_strOBS = ""
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_LOJA"
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = m_intIDLoja
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Lojas", "Apagar - IDLOJA=" & m_intIDLoja)
            MyBase.Log("Loja", "Apagar Loja", "User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Loja' the following row:  IDLoja=" & m_intIDLoja & " IDEmpresa=" & User.IDEmpresa & "")

            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_LOJAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa por cliente
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIDCliente As Integer, ByVal vReturnType As enReturnType) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_LOJAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa por cliente
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIDCliente As Integer, ByVal vIdRegiao As Integer, ByVal vIdTipoLoja As Integer, ByVal vUF As String, ByVal vCidade As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_LOJAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = vIdRegiao
            cmd.Parameters.Add("@IDTIPOLOJA", SqlDbType.Int).Value = vIdTipoLoja
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = vUF
            cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar, 100).Value = vCidade
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa por cliente
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIDClientes As String, ByVal vReturnType As enReturnType) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_LOJAS_CLIENTES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCLIENTES", SqlDbType.VarChar, 500).Value = vIDClientes
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa por cliente e categoria
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIDCategoria As Integer, ByVal vIDClientes As String, ByVal vReturnType As enReturnType) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_LOJAS_CLIENTES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCLIENTES", SqlDbType.VarChar, 8000).Value = vIDClientes
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDCliente">Filtro</param>
        ''' <param name="vUF">Filtro</param>
        ''' <param name="vIDTipoLoja">Filtro</param>
        ''' <param name="vIDShopping">Filtro</param>
        ''' <param name="vIDRegiao">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDCliente As Integer, ByVal vUF As String, ByVal vIDTipoLoja As Integer, ByVal vIDShopping As Integer, ByVal vIDRegiao As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vIDStatus As Integer = 2, Optional ByVal vCidade As String = "", Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_LOJAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = vUF
            cmd.Parameters.Add("@IDTIPOLOJA", SqlDbType.Int).Value = vIDTipoLoja
            cmd.Parameters.Add("@IDSHOPPING", SqlDbType.Int).Value = vIDShopping
            cmd.Parameters.Add("@IDREGIAO", SqlDbType.Int).Value = vIDRegiao
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar).Value = vCidade
            cmd.Parameters.Add("@ATIVO", SqlDbType.TinyInt).Value = vIDStatus

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function




        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a Função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDLoja">Chave primaria IDLoja do registro atual.</param>
        ''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDLoja As Integer, ByVal vCodigo As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_LOJA_EXISTENTE"
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = vIDLoja
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).Value = vCodigo

            Return ExecuteScalar(cmd)

        End Function

        Public Overloads Sub AddBrokenRule(vMessage As String)
            MyBase.AddBrokenRule(vMessage)
        End Sub

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strCodigo = "" And SettingsExpression.GetProperty("codigoautomatico", "loja.codigo", False) = False Then
                AddBrokenRule("Codigo Obrigatorio!")
                blnValid = False
            ElseIf Existe(m_intIDLoja, m_strCodigo) Then
                AddBrokenRule("O CNPJ informado ja existe cadastrado!")
                blnValid = False
            ElseIf m_strCNPJ <> "" And CNPJExiste(m_strCNPJ) Then
                blnValid = False
                AddBrokenRule("O CNPJ já existe!")
            End If
            Return blnValid
        End Function


        Public Function CNPJExiste(ByVal vCNPJ As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_LOJA_CNPJ_EXISTENTE"
            Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
            parameter.Direction = ParameterDirection.ReturnValue
            cmd.Parameters.Add(parameter)
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = m_intIDLoja
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CNPJ", SqlDbType.VarChar, 20).Value = vCNPJ
            ExecuteNonQuery(cmd)

            Return (cmd.Parameters("@RETURN_VALUE").Value = 1)

        End Function

        Private Function IsOnlyNumber(ByVal vNumber As String) As Boolean
            If vNumber.Length = 0 Then Return False
            For i As Integer = 0 To vNumber.Length - 1
                If Not IsNumeric(vNumber.Substring(i, 1)) Then
                    Return False
                End If
            Next i
            Return True
        End Function

        Public Function CNPJValido(ByVal vCNPJ As String) As Boolean
            CNPJValido = False

            Dim a, j, d1, d2 As Double
            Dim i As Integer

            If Len(vCNPJ) <> 14 Then
                CNPJValido = False
                Exit Function
            End If

            If Not IsOnlyNumber(vCNPJ) Then
                CNPJValido = False
                Exit Function
            End If

            a = 0
            i = 0
            d1 = 0
            d2 = 0
            j = 5
            For i = 1 To 12 Step 1
                a = a + (Val(Mid(vCNPJ, i, 1)) * j)
                j = Convert.ToDouble(IIf(j > 2, j - 1, 9))
            Next i
            a = a Mod 11
            d1 = Convert.ToDouble(IIf(a > 1, 11 - a, 0))
            a = 0
            i = 0
            j = 6
            For i = 1 To 13 Step 1
                a = a + (Val(Mid(vCNPJ, i, 1)) * j)
                j = Convert.ToDouble(IIf(j > 2, j - 1, 9))
            Next i
            a = a Mod 11
            d2 = Convert.ToDouble(IIf(a > 1, 11 - a, 0))
            If (d1 = Val(Mid(vCNPJ, 13, 1)) And d2 = Val(Mid(vCNPJ, 14, 1))) Then
                CNPJValido = True
            Else
                CNPJValido = False
            End If


        End Function




#End Region

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function ListarSegmentacao(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_LOJASEGMENTACOES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = m_intIDLoja
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        Public Sub AdicionarProdutos(ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, ByVal vIDProduto As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_LOJA_PRODUTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = m_intIDLoja
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Lojas", "AdicionarProdutos - IDLOJA=" & m_intIDLoja & " IDSUBCATEGORIA=" & vIDSubCategoria & " IDCATEGORIA=" & vIDCategoria & " IDPRODUTO=" & vIDProduto)

        End Sub

        Public Sub RetirarProdutos(ByVal vIDSegmentacao As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_LOJA_PRODUTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDLOJA", SqlDbType.Int).Value = m_intIDLoja
            cmd.Parameters.Add("@IDSEGMENTACAO", SqlDbType.Int).Value = vIDSegmentacao

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Lojas", "RetirarProdutos - IDLOJA=" & m_intIDLoja & " IDSEGMENTACAO=" & vIDSegmentacao)

        End Sub


    End Class
End Namespace

