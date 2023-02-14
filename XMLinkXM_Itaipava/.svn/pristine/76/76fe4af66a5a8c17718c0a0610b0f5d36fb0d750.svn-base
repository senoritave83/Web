Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsVisitaPesquisa
        Inherits BaseClass

#Region "Declarations"
        Protected m_intIDVisita As Integer
        Protected m_intIDPesquisa As Integer
        Protected m_intIDCliente As Integer
        Protected m_strCliente As String
        Protected m_intIDVendedor As Integer
        Protected m_strVendedor As String
        Protected m_strData As String
        Protected m_intIDJustificativa As Integer
        Protected m_indJustificativaReincidencia As Byte
        Protected m_strInicio As String
        Protected m_strTermino As String
        Protected m_strStatus As String
        Protected m_indMarcadaReincidencia As Byte
        Protected m_blnIsNew As Boolean = True
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDVisita As Integer
            Get
                Return m_intIDVisita
            End Get
        End Property

        Public Overridable ReadOnly Property IDPesquisa As Integer
            Get
                Return m_intIDPesquisa
            End Get
        End Property

        Public Overridable ReadOnly Property IDCliente() As Integer
            Get
                Return m_intIDCliente
            End Get
        End Property

        Public Overridable ReadOnly Property Cliente() As String
            Get
                Return m_strCliente
            End Get
        End Property

        Public Overridable ReadOnly Property IDVendedor() As Integer
            Get
                Return m_intIDVendedor
            End Get
        End Property

        Public Overridable ReadOnly Property Vendedor() As String
            Get
                Return m_strVendedor
            End Get
        End Property

        Public Overridable ReadOnly Property Data() As String
            Get
                Return _getDatePropertyValue(m_strData)
            End Get
        End Property

        Public Overridable ReadOnly Property IDJustificativa() As Integer
            Get
                Return m_intIDJustificativa
            End Get
        End Property

        Public Overridable ReadOnly Property Inicio() As String
            Get
                Return _getDateTimePropertyValue(m_strInicio)
            End Get
        End Property

        Public Overridable ReadOnly Property Termino() As String
            Get
                Return _getDateTimePropertyValue(m_strTermino)
            End Get
        End Property

        Public ReadOnly Property Status() As String
            Get
                Return m_strStatus
            End Get
        End Property

        Public ReadOnly Property IsNew() As Boolean
            Get
                Return m_blnIsNew
            End Get
        End Property

        Public ReadOnly Property MarcadaReincidencia As Boolean
            Get
                Return IIf(m_indMarcadaReincidencia = 1, True, False)
            End Get
        End Property

        Public ReadOnly Property JustificaticaReincidencia As Boolean
            Get
                Return m_indJustificativaReincidencia
            End Get
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDVisita = dr.GetInt32(dr.GetOrdinal("IDVisita"))
            m_intIDPesquisa = dr.GetInt32(dr.GetOrdinal("IDPesquisa"))
            m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IDCliente"))
            m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))
            m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
            m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
            If dr.IsDBNull(dr.GetOrdinal("Data")) Then
                m_strData = ""
            Else
                m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDJustificativa")) Then
                m_intIDJustificativa = 0
            Else
                m_intIDJustificativa = dr.GetInt32(dr.GetOrdinal("IDJustificativa"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Inicio")) Then
                m_strInicio = ""
            Else
                m_strInicio = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Inicio")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Termino")) Then
                m_strTermino = ""
            Else
                m_strTermino = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Termino")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Status")) Then
                m_strStatus = ""
            Else
                m_strStatus = dr.GetString(dr.GetOrdinal("Status"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("MarcadaReincidencia")) Then
                m_indMarcadaReincidencia = 0
            Else
                m_indMarcadaReincidencia = dr.GetByte(dr.GetOrdinal("MarcadaReincidencia"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("JustificativaReincidente")) Then
                m_indJustificativaReincidencia = 0
            Else
                m_indJustificativaReincidencia = dr.GetByte(dr.GetOrdinal("JustificativaReincidente"))
            End If

            m_blnIsNew = False
        End Sub

        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDVisita">Chave primaria IDVisita</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDVisita As Integer) As Boolean
            Return Load(vIDVisita, User.IDEmpresa)
        End Function

        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDVisita">Chave primaria IDVisita</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDVisita As Integer, ByVal vIdEmpresa As Integer) As Boolean
            Dim blnReturn As Boolean = False
            If vIDVisita = 0 Then
                Clear()
                Return blnReturn
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_VISITAPESQUISA"
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
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
            m_intIDVisita = 0
            m_intIDPesquisa = 0
            m_intIDCliente = 0
            m_intIDVendedor = 0
            m_strData = ""
            m_intIDJustificativa = 0
            m_strInicio = ""
            m_strTermino = ""
            m_indMarcadaReincidencia = 0
            m_blnIsNew = True
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa dos itens da pesquisa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarItens(ByVal vIdVisita As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_VISITAPESQUISA_ITENS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIdVisita
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa dos itens da pesquisa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarItens(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Return ListarItens(m_intIDVisita, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_VISITAPESQUISAS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ForcarReincidencia(ByVal vIdVisita As Integer, ByVal vIdPesquisa As Integer, ByVal vReincidencia As Boolean, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "BS_VISITAPESQUISA_FORCARREINCIDENCIA"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIdVisita
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIdPesquisa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@MARCAR", SqlDbType.TinyInt).Value = IIf(vReincidencia = True, 1, 0)
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFiltro">Filtro</param>
        ''' <param name="vIDVendedor">Filtro</param>
        ''' <param name="vDataInicial">Filtro</param>
        ''' <param name="vDataFinal">Filtro</param>
        ''' <param name="vIDGerenteVendas">Filtro</param>
        ''' <param name="vIDSupervisor">Filtro</param>
        ''' <param name="vIDJustificativa">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFiltro As String, ByVal vDataInicial As String, ByVal vDataFinal As String, _
                               ByVal vIDJustificativa As Integer, ByVal vIDGerenteVendas As Integer, ByVal vIDSupervisor As Integer, ByVal vIDVendedor As Integer, _
                               ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, _
                               ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_VISITAPESQUISAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar).Value = vFiltro

            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIDGerenteVendas
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            If vDataInicial <> "" Then
                cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
            End If
            If vDataFinal <> "" Then
                cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)
            End If
            cmd.Parameters.Add("@IDJUSTIFICATIVA", SqlDbType.Int).Value = vIDJustificativa
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarStatusVisita(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_STATUS_VISITAPESQUISA"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)

        End Function


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

#End Region

    End Class
End Namespace
