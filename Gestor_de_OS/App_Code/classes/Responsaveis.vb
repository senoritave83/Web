Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Imports XMSistemas.Web.Base

Public Class clsResponsaveis

    Inherits DataClass



#Region "Declarations"
    Protected m_intIDResponsavel As Integer
    Protected m_strResponsavel As String
    Protected m_strTelefone As String
    Protected m_strID As String
    Protected m_strObservacao As String
    Protected m_strSubscriberID As String
    Protected m_strRefreshed As String
    Protected m_strCriado As String
    Protected m_indAtivo As Byte
    Protected m_strStatus As String
    Protected m_colGrupos As clsLista
    Protected m_strLogin As String
    Protected m_strSenha As String


#End Region


#Region "Properties"
    Public Overridable ReadOnly Property IDResponsavel() As Integer
        Get
            Return m_intIDResponsavel
        End Get
    End Property

    Public Overridable Property Responsavel() As String
        Get
            Return m_strResponsavel
        End Get
        Set(ByVal Value As String)
            m_strResponsavel = Value
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

    Public Overridable Property ID() As String
        Get
            Return m_strID
        End Get
        Set(ByVal Value As String)
            m_strID = Value
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

    Public Overridable Property SubscriberID() As String
        Get
            Return m_strSubscriberID
        End Get
        Set(ByVal Value As String)
            m_strSubscriberID = Value
        End Set
    End Property

    Public Overridable Property Refreshed() As String
        Get
            Return _getDateTimePropertyValue(m_strRefreshed)
        End Get
        Set(ByVal Value As String)
            m_strRefreshed = _setDateTimePropertyValue(Value)
        End Set
    End Property

    Public Overridable ReadOnly Property Criado() As String
        Get
            Return _getDateTimePropertyValue(m_strCriado)
        End Get
    End Property

    Public ReadOnly Property Ativo() As Boolean
        Get
            Return (m_indAtivo > 0)
        End Get
    End Property

    Public ReadOnly Property Grupos() As clsLista
        Get
            Return m_colGrupos
        End Get
    End Property


    Public ReadOnly Property Status() As String
        Get
            If m_indAtivo = 0 Then
                Return "Apagado"
            ElseIf m_indAtivo = 1 Then
                Return "Ativo"
            ElseIf m_indAtivo = 2 Then
                Return "Pendente"
            ElseIf m_indAtivo = 3 Then
                Return "Bloqueado"
            ElseIf m_indAtivo = 4 Then
                Return "Sem servi&ccedil;o"
            Else
                Return "Desconhecido"
            End If
        End Get
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


#End Region

#Region "Metodos"

    ''' <summary>
    ''' 	Funcao protegida que carrega nas variaveis internas os valores presentes no Data Reader
    ''' </summary>
    ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
    Protected Overridable Sub Inflate(ByVal dr As IDataReader)
        m_intIDResponsavel = dr.GetInt32(dr.GetOrdinal("IDResponsavel"))
        m_strResponsavel = dr.GetString(dr.GetOrdinal("Responsavel"))
        If dr.IsDBNull(dr.GetOrdinal("Telefone")) Then
            m_strTelefone = ""
        Else
            m_strTelefone = dr.GetString(dr.GetOrdinal("Telefone"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("ID")) Then
            m_strID = ""
        Else
            m_strID = dr.GetString(dr.GetOrdinal("ID"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Observacao")) Then
            m_strObservacao = ""
        Else
            m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("SubscriberID")) Then
            m_strSubscriberID = ""
        Else
            m_strSubscriberID = dr.GetString(dr.GetOrdinal("SubscriberID"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Refreshed")) Then
            m_strRefreshed = ""
        Else
            m_strRefreshed = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Refreshed")))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Criado")) Then
            m_strCriado = ""
        Else
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
        End If

        If dr.IsDBNull(dr.GetOrdinal("Ativo")) Then
            m_indAtivo = 0
        Else
            m_indAtivo = dr.GetValue(dr.GetOrdinal("Ativo"))
        End If
        m_colGrupos = New clsLista()
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
    End Sub



    ''' <summary>
    ''' 	Funcao que grava os dados do registro atual
    ''' </summary>
    Public Sub Update()
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SV_RESPONSAVEL"
        cmd.Parameters.Add("@IDRESPONSAVEL", SqlDbType.Int).Value = m_intIDResponsavel
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@RESPONSAVEL", SqlDbType.VarChar, 100).Value = m_strResponsavel
        cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar, 20).Value = m_strTelefone
        cmd.Parameters.Add("@ID", SqlDbType.VarChar, 20).Value = m_strID
        cmd.Parameters.Add("@OBSERVACAO", SqlDbType.VarChar, 2000).Value = m_strObservacao
        cmd.Parameters.Add("@ATIVO", SqlDbType.TinyInt).Value = m_indAtivo
        cmd.Parameters.Add("@GRUPOS", SqlDbType.VarChar, 200).Value = Grupos.GetLista
        cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar, 50).Value = m_strLogin
        cmd.Parameters.Add("@SENHA", SqlDbType.VarChar, 50).Value = m_strSenha

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
    ''' 	Funcao que obtem os dados do registro solicitado 
    ''' </summary>
    ''' <param name="vIDResponsavel">Chave primaria IDResponsavel</param>
    ''' <returns>Boolean</returns>
    Public Function Load(ByVal vIDResponsavel As Integer) As Boolean
        If vIDResponsavel = 0 Then
            Clear()
            Return False
        End If
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_RESPONSAVEL"
        cmd.Parameters.Add("@IDRESPONSAVEL", SqlDbType.Int).Value = vIDResponsavel
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
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
    ''' 	Funcao interna que limpa as variaveis internas
    ''' </summary>
    Protected Sub Clear()
        m_intIDResponsavel = 0
        m_strResponsavel = ""
        m_strTelefone = ""
        m_strID = ""
        m_strObservacao = ""
        m_strSubscriberID = ""
        m_strRefreshed = ""
        m_strCriado = ""
        m_indAtivo = 2
        m_colGrupos = New clsLista()
        m_strLogin = ""
        m_strSenha = ""
    End Sub



    ''' <summary>
    ''' 	Rotina que apaga o registro atual
    ''' </summary>
    Public Sub Delete()
        Delete(m_intIDResponsavel)
        Clear()
    End Sub


    Public Function Listar() As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_RESPONSAVEIS"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        Return ExecuteReader(cmd)
    End Function

    Public Function ListarResponsaveis(ByVal vOrder As String, ByVal vPage As Integer, ByVal vPageSize As Integer, ByVal vDesc As Boolean) As IPaginaResult

        Dim ret As New PaginateResult
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "NV_RESPONSAVEIS"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 50).Value = vOrder
        cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
        cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
        cmd.Parameters.Add("@DESC", SqlDbType.TinyInt).Value = vDesc
        'Dim ds As DataSet = ExecuteDataSet(cmd)
        ret = ExecutePaginate(cmd, enReturnType.DataSet, vPageSize, vPage)
        ret.CurrentPage = vPage
        ret.PageSize = vPageSize
        ret.RecordCount = ret.Tables(1).Rows(0).Item(0)
        Return ret
    End Function

    Public Function Listar(ByVal vFiltro As String, ByVal vIDEmpresa As Integer) As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_RESPONSAVEIS"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
        cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar).Value = vFiltro
        Return ExecuteReader(cmd)
    End Function

    Public Function ListarAtivos() As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_RESPONSAVEIS_ATIVOS"
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        Return ExecuteReader(cmd)
    End Function

    Public Function ListarDestinatarios(ByVal vFiltro As String, ByVal vIDEmpresa As Integer) As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_DESTINATARIOS"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
        cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar).Value = vFiltro
        Return ExecuteReader(cmd)
    End Function

    Public Function ListarDestinatarios(ByVal vFiltro As String) As IDataReader
        Return ListarDestinatarios(vFiltro, Identity.IDEmpresa)
    End Function

    Public Function ListarDestinatarios() As IDataReader
        Return ListarDestinatarios("", Identity.IDEmpresa)
    End Function

    Public Function ListarDestinatariosAtivos() As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_DESTINATARIOS"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@ATIVOS", SqlDbType.Bit).Value = 1
        Return ExecuteReader(cmd)
    End Function

    Public Function ContarResponsaveis() As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "LS_RESPONSAVEIS_CONTAR"
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        Return ExecuteReader(cmd)
    End Function


    Public Sub Delete(ByVal vID As Integer)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_RESPONSAVEL"

        cmd.Parameters.Add("@rsp_Responsavel_int_PK", SqlDbType.Int).Value = vID
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        ExecuteNonQuery(cmd)
    End Sub

    Protected Overrides Function CheckIfSubClassIsValid() As Boolean
        Dim blnValid As Boolean = True

        Dim emp As New clsEmpresa
        emp.Load(Identity.IDEmpresa)

        If m_strObservacao.Length > 2000 Then
            blnValid = False
            AddBrokenRule("O campo Observação não pode conter mais de 2000 caracteres!")
        End If
        If ValidaExpressao(m_strID, "55\*\d{1,6}\*\d{1,7}") = False Then
            blnValid = False
            AddBrokenRule("Informe o ID corretamente!")
        End If
        If m_strTelefone.Length < 10 Then
            blnValid = False
            AddBrokenRule("Informe o Telefone corretamente!")
        End If
        If ValidaExpressao(m_strTelefone, "\d{1,10}") = False Then
            blnValid = False
            AddBrokenRule("Informe o Telefone corretamente!")
        End If

        Dim strServices As String = getServices(m_strTelefone)
        If strServices.Contains("EQLOC") = False And strServices.Contains("EQON") = False And emp.Verifica = True And strServices <> "" Then
            blnValid = False
            AddBrokenRule("O Serviço do Gestor de OS não está habilitado para o responsável informado!")
        ElseIf strServices <> "" Then
            m_indAtivo = 1
        End If
        If Existe(m_strTelefone) Then
            blnValid = False
            AddBrokenRule("O responsável informado já está cadastrado em outra conta do Gestor de OS!")
        End If
        If m_strSenha <> "" And m_strLogin = "" Then
            blnValid = False
            AddBrokenRule("Informe o Login e digite novamente a Senha!")
        ElseIf m_strSenha = "" And m_strLogin <> "" Then
            blnValid = False
            AddBrokenRule("Informe a Senha!")
        End If
        If ExisteLogin(m_intIDResponsavel, m_strLogin) = True Then
            blnValid = False
            AddBrokenRule("O Login informado já existe!")
        End If
        'If m_strTelefone.StartsWith("11771202") Then
        '    blnValid = False
        '    AddBrokenRule("Fleet/ID n&atilde;o pertence ao Cliente Nextel informado ou est&aacute; in&aacute;tivo ou desabilitado!")
        'End If
        'If m_strTelefone.StartsWith("11771288") Then
        '    blnValid = False
        '    AddBrokenRule("Os Servi&ccedil;os NOL necess&aacute;rios n&atilde;o est&atilde;o habilitados para o Fleet/ID informado!")
        'End If
        Return blnValid
    End Function

    Private Function GetPage(ByVal vURL As String, ByVal vTimeOut As Integer) As String
        Dim req As Net.HttpWebRequest
        Dim rsp As Net.HttpWebResponse
        Try
            req = Net.WebRequest.Create(vURL)
            If vTimeOut > 0 Then req.Timeout = vTimeOut
            rsp = req.GetResponse
            Dim str As New IO.StreamReader(rsp.GetResponseStream())
            GetPage = str.ReadToEnd
            rsp.Close()
        Catch e As Exception
            GetPage = ""
        End Try
        rsp = Nothing
        req = Nothing
    End Function

    Private Function getServices(ByVal vTelefone As String) As String
        Dim vTimeOut As Integer = CInt("0" & AppSettings("ws_timeout"))
        Return GetPage("https://argsuwdm.nextelinternational.com/NASApp/api_2/Api?appid=nextel&apppw=nextel01&class=device&function=getDeviceInfo&ptn=" & vTelefone & "&country=55", vTimeOut)
    End Function

    ''' <summary>
    ''' 	Funcao que retorna uma listagem completa
    ''' </summary>
    ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitacao</returns>
    Public Function ListarGrupos() As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandText = SQLPREFIXO & "LS_GRUPOS_RESPONSAVEL"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@rsp_Responsavel_int_PK", SqlDbType.Int).Value = m_intIDResponsavel
        Return ExecuteReader(cmd)

    End Function

    Public Function Existe(ByVal vTelefone As String) As Boolean
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_RESPONSAVEL_EXISTE"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@IDRESPONSAVEL", SqlDbType.Int).Value = m_intIDResponsavel
        cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar, 20).Value = vTelefone
        Return ExecuteScalar(cmd)
    End Function


    Public Function Count() As Integer
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_RESPONSAVEL_COUNT"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        Return ExecuteScalar(cmd)
    End Function


    Public Function ExisteLogin(ByVal vIDResponsavel As Integer, ByVal vLogin As String) As Boolean
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "EXISTE_LOGIN"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@IDRESPONSAVEL", SqlDbType.Int).Value = vIDResponsavel
        cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = vLogin
        Return ExecuteScalar(cmd)
    End Function

#End Region

End Class
