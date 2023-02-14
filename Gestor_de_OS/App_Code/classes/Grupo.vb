
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports XMSistemas.Web.Base


Public Class clsGrupo
    Inherits DataClass



#Region "Declarations"
    Protected m_intIDGrupo As Integer
    Protected m_strGrupo As String
    Protected m_strCriado As String
    Protected m_colResponsaveis As clsLista

#End Region


#Region "Properties"
    Public Overridable ReadOnly Property IDGrupo() As Integer
        Get
            Return m_intIDGrupo
        End Get
    End Property

    Public Overridable Property Grupo() As String
        Get
            Return m_strGrupo
        End Get
        Set(ByVal Value As String)
            m_strGrupo = Value
        End Set
    End Property

    Public Overridable ReadOnly Property Criado() As String
        Get
            Return _getDateTimePropertyValue(m_strCriado)
        End Get
    End Property

    Public ReadOnly Property Responsaveis() As clsLista
        Get
            Return m_colResponsaveis
        End Get
    End Property

#End Region

#Region "Metodos"

    ''' <summary>
    ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
    ''' </summary>
    ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
    Protected Overridable Sub Inflate(ByVal dr As IDataReader)
        m_intIDGrupo = dr.GetInt32(dr.GetOrdinal("grp_Grupo_int_PK"))
        m_strGrupo = dr.GetString(dr.GetOrdinal("grp_Grupo_chr"))
        If dr.IsDBNull(dr.GetOrdinal("grp_Criado_dtm")) Then
            m_strCriado = ""
        Else
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("grp_Criado_dtm")))
        End If
        m_colResponsaveis = New clsLista
    End Sub




    ''' <summary>
    ''' 	Função que grava os dados do registro atual
    ''' </summary>
    Public Sub Update()
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SV_GRUPO"
        cmd.Parameters.Add("@grp_Grupo_int_PK", SqlDbType.Int).Value = m_intIDGrupo
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@grp_Grupo_chr", SqlDbType.VarChar, 50).Value = m_strGrupo
        cmd.Parameters.Add("@RESPONSAVEIS", SqlDbType.VarChar, 5000).Value = Responsaveis.GetLista()
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
    ''' <param name="vIDGrupo">Chave primaria IDGrupo</param>
    ''' <returns>Boolean</returns>
    Public Function Load(ByVal vIDGrupo As Integer) As Boolean
        If vIDGrupo = 0 Then
            Clear()
            Return False
        End If
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_GRUPO"
        cmd.Parameters.Add("@grp_Grupo_int_PK", SqlDbType.Int).Value = vIDGrupo
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
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
        m_intIDGrupo = 0
        m_strGrupo = ""
        m_strCriado = ""
        m_colResponsaveis = New clsLista
    End Sub



    ''' <summary>
    ''' 	Rotina que apaga o registro atual
    ''' </summary>
    Public Sub Delete()
        Delete(m_intIDGrupo)
    End Sub


    Public Sub Delete(ByVal vID As Integer)

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_GRUPO"
        cmd.Parameters.Add("@grp_Grupo_int_PK", SqlDbType.Int).Value = vID
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa

        ExecuteNonQuery(cmd)

        Clear()

    End Sub


    ''' <summary>
    ''' 	Função que retorna uma listagem completa
    ''' </summary>
    ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
    Public Function Listar() As IDataReader

        Dim cmd As New SqlCommand()
        cmd.CommandText = SQLPREFIXO & "LS_GRUPOS"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        Return ExecuteReader(cmd)

    End Function

    Public Function Listar(ByVal vOrder As String, ByVal vPage As Integer, ByVal vPageSize As Integer, ByVal vDesc As Boolean) As IPaginaResult

        Dim ret As New PaginateResult
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "NV_GRUPOS"

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

    ' ''' <summary>
    ' ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
    ' ''' </summary>
    ' ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
    ' ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
    ' ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
    ' ''' <param name="vPage">Número da página a exibir</param>	
    ' ''' <param name="vPageSize">Tamanho da página em registros</param>		
    ' ''' <returns>PaginateResult</returns>
    'Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

    '    Dim cmd As New SqlCommand()
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.CommandText = SQLPREFIXO & "NV_GRUPOS"
    '    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
    '    cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
    '    cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
    '    cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
    '    cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
    '    cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

    '    Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

    'End Function

    Public Function ListarResponsaveis(ByVal vIDGrupo As Integer, ByVal vTodos As Boolean) As IDataReader

        Dim cmd As New SqlCommand()
        cmd.CommandText = SQLPREFIXO & "LS_RESPONSAVEL_GRUPO"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@emp_Empresa_int_FK", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@grp_Grupo_int_FK", SqlDbType.Int).Value = vIDGrupo
        cmd.Parameters.Add("@Todos", SqlDbType.Bit).Value = vTodos
        Return ExecuteReader(cmd)

    End Function


    Protected Overrides Function CheckIfSubClassIsValid() As Boolean
        Dim blnValid As Boolean = True

        Return blnValid

    End Function

#End Region

End Class
