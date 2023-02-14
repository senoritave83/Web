

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics


Namespace Classes

	Public Class clsSubCategoria
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDSubCategoria As Integer
		Protected m_intIDCategoria As Integer
		Protected m_strSubCategoria As String
		Protected m_strCriado As String
        Protected m_intStatus As Integer
        Protected m_intOrdem As Integer

	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDSubCategoria As Integer
			Get
				Return m_intIDSubCategoria
			End Get
		End Property

		Public Overridable Property IDCategoria As Integer
			Get
				Return m_intIDCategoria
			End Get
			Set(ByVal Value As Integer)
				m_intIDCategoria = Value
			End Set
		End Property

		Public Overridable Property SubCategoria As String
			Get
				Return m_strSubCategoria
			End Get
			Set(ByVal Value As String)
				m_strSubCategoria = Value
			End Set
        End Property

        Public Overridable Property IdStatus As Integer
            Get
                Return m_intStatus
            End Get
            Set(ByVal Value As Integer)
                m_intStatus = Value
            End Set
        End Property

        Public Overridable Property Ordem As Integer
            Get
                Return m_intOrdem
            End Get
            Set(ByVal Value As Integer)
                m_intOrdem = Value
            End Set
        End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDSubCategoria = 0
            End Get
        End Property

#End Region

    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDSubCategoria = dr.GetInt32(dr.GetOrdinal("IdSubcategoria"))
            m_intIDCategoria = dr.GetInt32(dr.GetOrdinal("Idcategoria"))
            If dr.IsDBNull(dr.GetOrdinal("SubCategoria")) Then
                m_strSubCategoria = ""
            Else
                m_strSubCategoria = dr.GetString(dr.GetOrdinal("SubCategoria"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Ordem")) Then
                m_intOrdem = 0
            Else
                m_intOrdem = dr.GetInt32(dr.GetOrdinal("Ordem"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IdStatus")) Then
                m_intStatus = 0
            Else
                m_intStatus = dr.GetByte(dr.GetOrdinal("IdStatus"))
            End If
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_SUBCATEGORIA"
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = m_intIDSubCategoria
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = m_intIDCategoria
            cmd.Parameters.Add("@SUBCATEGORIA", SqlDbType.VarChar, 50).Value = m_strSubCategoria
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = m_intStatus

            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                Else
                    Clear()
                End If
            Finally
                dr.Close()
                dr = Nothing
            End Try

            Me.User.Log("Cadastro de Categorias", "Gravar - IDCATEGORIA=" & m_intIDSubCategoria & " IDSEGMENTO=" & m_intIDCategoria & " CATEGORIA=" & m_strSubCategoria)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDSubCategoria">Chave primaria IDSubCategoria</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDSubCategoria As Integer) As Boolean

            If vIDSubCategoria = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_SUBCATEGORIA"
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                Else
                    Clear()
                End If
            Finally
                dr.Close()
                dr = Nothing
            End Try

            Me.User.Log("Cadastro de Categorias", "Visualizar - IDCATEGORIA=" & vIDSubCategoria)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDSubCategoria = 0
            m_intIDCategoria = 0
            m_strSubCategoria = ""
            m_strCriado = ""
            m_intOrdem = 0
            m_intStatus = 0
        End Sub



        ''' <summary>
        ''' 	Rotina que Inativa o registro atual
        ''' </summary>
        Public Function Delete() As Integer

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_SUBCATEGORIA"
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = m_intIDSubCategoria
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Dim drDelete As IDataReader = ExecuteReader(cmd)

            Try
                If drDelete.Read Then

                    If drDelete.GetInt32(drDelete.GetOrdinal("Retorno")) = 1 Then
                        Me.User.Log("Cadastro de Categorias", "Apagar - IDCATEGORIA=" & m_intIDSubCategoria)
                        MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'SubCategoria' the following row:  IDSubCategoria=" & m_intIDSubCategoria & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
                    End If

                    Clear()
                    Return drDelete.GetInt32(drDelete.GetOrdinal("Retorno"))
                End If
            Finally
                If (Not drDelete Is Nothing) Then
                    drDelete.Close()
                    drDelete = Nothing
                End If
            End Try

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_SUBCATEGORIAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIDCategoria As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_SUBCATEGORIAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIdCategorias As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Return Listar(vIdCategorias, "0", vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIdCategorias As String, ByVal vIDMarca As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_SUBCATEGORIAS_CATEGORIAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCATEGORIAS", SqlDbType.VarChar, 500).Value = vIdCategorias
            cmd.Parameters.Add("@IDMARCA", SqlDbType.VarChar, 500).Value = vIDMarca

            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDCategoria">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDCategoria As Integer, ByVal vIdStatus As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_SUBCATEGORIAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = vIdStatus
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a Função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDSubCategoria">Chave primaria IDSubCategoria do registro atual.</param>
        ''' <param name="vIDCategoria">Chave externa IDCategoria do registro atual.</param>
        ''' <param name="vSubCategoria">SubCategoria que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDSubCategoria As Integer, ByVal vIDCategoria As Integer, ByVal vSubCategoria As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_SUBCATEGORIA_EXISTENTE"
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@SUBCATEGORIA", SqlDbType.VarChar, 50).Value = vSubCategoria

            Return ExecuteScalar(cmd)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vIdCategoria">Id da Categoria</param>		
        ''' <param name="vMovimento">Up ou Down</param>		
        Public Sub TrocarOrdem(ByVal vIdCategoria As Integer, ByVal vMovimento As Integer)
            'Movimentos
            '1 - UP
            '2 - DOWNN
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "BS_TROCAORDEM_SUBCATEGORIA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIdCategoria
            cmd.Parameters.Add("@MOVIMENTO", SqlDbType.Int).Value = vMovimento
            MyBase.ExecuteNonQuery(cmd)

        End Sub


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strSubCategoria = "" Then
                AddBrokenRule("Por favor informe a categoria!")
                blnValid = False
            ElseIf Existe(m_intIDSubCategoria, m_intIDCategoria, m_strSubCategoria) Then
                AddBrokenRule("Categoria informada existente!")
                blnValid = False
            End If
            Return blnValid
        End Function

#End Region



    End Class
End Namespace

