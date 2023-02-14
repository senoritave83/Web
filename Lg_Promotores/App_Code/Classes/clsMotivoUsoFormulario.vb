

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsMotivoUsoFormulario
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDMotivoUsoForm As Integer
		Protected m_strMotivoUsoForm As String
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
        Public Overridable ReadOnly Property IDMotivoUsoForm As Integer
            Get
                Return m_intIDMotivoUsoForm
            End Get
        End Property

        Public Overridable Property MotivoUsoForm As String
            Get
                Return m_strMotivoUsoForm
            End Get
            Set(ByVal Value As String)
                m_strMotivoUsoForm = Value
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
            m_intIDMotivoUsoForm = dr.GetInt32(dr.GetOrdinal("IDMotivoUsoForm"))
            m_strMotivoUsoForm = dr.GetString(dr.GetOrdinal("MotivoUsoForm"))
            m_blnIsNew = False
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_MOTIVOUSOFORMULARIO"
            cmd.Parameters.Add("@IDMOTIVOUSOFORM", SqlDbType.Int).value = m_intIDMotivoUsoForm
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            cmd.Parameters.Add("@MOTIVOUSOFORM", SqlDbType.VarChar, 200).value = m_strMotivoUsoForm
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

            Me.User.Log("Cadastro de Motivos de Uso do Formulario On-line", "Gravar - IDMOTIVOUSOFORM=" & m_intIDMotivoUsoForm & " MOTIVOUSOFORM=" & m_strMotivoUsoForm)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDMotivoUsoForm">Chave primaria IDMotivoUsoForm</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDMotivoUsoForm As Integer) As Boolean
            If vIDMotivoUsoForm = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_MOTIVOUSOFORMULARIO"
            cmd.Parameters.Add("@IDMOTIVOUSOFORM", SqlDbType.Int).value = vIDMotivoUsoForm
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

            Me.User.Log("Cadastro de Motivos de Uso do Formulario On-line", "Visualizar - IDMOTIVOUSOFORM=" & vIDMotivoUsoForm)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDMotivoUsoForm = 0
            m_strMotivoUsoForm = ""
            m_blnIsNew = True
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_MOTIVOUSOFORMULARIO"
            cmd.Parameters.Add("@IDMOTIVOUSOFORM", SqlDbType.Int).value = m_intIDMotivoUsoForm

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Motivos de Uso do Formulario On-line", "Apagar - IDMOTIVOUSOFORM=" & m_intIDMotivoUsoForm)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'MotivoUsoFormulario' the following row:  IDMotivoUsoForm=" & m_intIDMotivoUsoForm & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_MOTIVOUSOFORMULARIOS"
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
            cmd.CommandText = PREFIXO & "NV_MOTIVOUSOFORMULARIOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
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

