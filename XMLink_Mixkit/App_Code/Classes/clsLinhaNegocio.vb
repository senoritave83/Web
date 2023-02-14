Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsLinhaNegocio
        Inherits BaseClass

#Region "Declarations"
        Protected m_intIdLinhaNegocio As Integer
        Protected m_strLinhaNegocio As String
        Protected m_strCriado As String
        Protected m_blnIsNew As Boolean = True
#End Region

#Region "Properties"
        Public Property IDLinhaNegocio() As Integer
            Get
                Return m_intIdLinhaNegocio
            End Get
            Set(ByVal value As Integer)
                m_intIdLinhaNegocio = value
            End Set
        End Property

        Public Property LinhaNegocio() As String
            Get
                Return m_strLinhaNegocio
            End Get
            Set(ByVal value As String)
                m_strLinhaNegocio = value
            End Set
        End Property

        Public ReadOnly Property Criado() As String
            Get
                Return m_strCriado
            End Get
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
            m_intIdLinhaNegocio = dr.GetInt32(dr.GetOrdinal("IDLinhaNegocio"))
            If dr.IsDBNull(dr.GetOrdinal("LinhaNegocio")) Then
                m_strLinhaNegocio = ""
            Else
                m_strLinhaNegocio = dr.GetString(dr.GetOrdinal("LinhaNegocio"))
            End If
            m_strCriado = dr.GetString(dr.GetOrdinal("Criado"))
            m_blnIsNew = False
        End Sub

        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_LINHANEGOCIO"
            cmd.Parameters.Add("@IDLINHANEGOCIO", SqlDbType.Int).Value = m_intIdLinhaNegocio
            cmd.Parameters.Add("@LINHANEGOCIO", SqlDbType.NVarChar, 50).Value = m_strLinhaNegocio
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
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
        ''' <param name="vIDLinhaNegocio">Chave primaria IDCategoria</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDLinhaNegocio As Integer) As Boolean
            If vIDLinhaNegocio = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_LINHANEGOCIO"
            cmd.Parameters.Add("@IDLINHANEGOCIO", SqlDbType.Int).Value = vIDLinhaNegocio
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
            m_intIdLinhaNegocio = 0
            m_strLinhaNegocio = ""
            m_strCriado = ""
            m_blnIsNew = True
        End Sub

        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_LINHANEGOCIO"
            cmd.Parameters.Add("@IDLINHANEGOCIO", SqlDbType.Int).Value = m_intIdLinhaNegocio
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Linha de Negócio' the following row:  IDCategoria=" & m_intIdLinhaNegocio & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_LINHANEGOCIO"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
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
            cmd.CommandText = PREFIXO & "NV_LINHASNEGOCIO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function
#End Region

    End Class
End Namespace