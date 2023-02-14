

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsMapa
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_dblIDMapa As Double
		Protected m_intTipoPedido As Integer
		Protected m_strPlaca As String
		Protected m_intIDPasta As Integer
		Protected m_intIDVendedor As Integer
		Protected m_strVendedor As String
		Protected m_intIDMotorista As Integer
		Protected m_strMotorista As String
		Protected m_intQtdPedidos As Integer
		Protected m_strData As String
		Protected m_strInicio As String
		Protected m_strFim As String
		Protected m_sngLatitudeInicio As Single
		Protected m_sngLongitudeInicio As Single
		Protected m_sngLatitudeFinal As Single
        Protected m_sngLongitudeFinal As Single
        Protected m_strStatus As String
        Protected m_intIDStatus As Integer
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDMapa As Double
			Get
				Return m_dblIDMapa
			End Get
		End Property

		Public Overridable ReadOnly Property TipoPedido As Integer
			Get
				Return m_intTipoPedido
			End Get
		End Property

		Public Overridable Property Placa As String
			Get
				Return m_strPlaca
			End Get
			Set(ByVal Value As String)
				m_strPlaca = Value
			End Set
		End Property

		Public Overridable Property IDPasta As Integer
			Get
				Return m_intIDPasta
			End Get
			Set(ByVal Value As Integer)
				m_intIDPasta = Value
			End Set
		End Property

		Public Overridable Property IDVendedor As Integer
			Get
				Return m_intIDVendedor
			End Get
			Set(ByVal Value As Integer)
				m_intIDVendedor = Value
			End Set
		End Property

		Public Overridable readonly Property Vendedor As String
			Get
				Return m_strVendedor
			End Get
		End Property

		Public Overridable Property IDMotorista As Integer
			Get
				Return m_intIDMotorista
			End Get
			Set(ByVal Value As Integer)
				m_intIDMotorista = Value
			End Set
		End Property

		Public Overridable readonly Property Motorista As String
			Get
				Return m_strMotorista
			End Get
		End Property

		Public Overridable Property QtdPedidos As Integer
			Get
				Return m_intQtdPedidos
			End Get
			Set(ByVal Value As Integer)
				m_intQtdPedidos = Value
			End Set
		End Property

        Public Overridable ReadOnly Property Data() As String
            Get
                Return _getDatePropertyValue(m_strData)
            End Get
        End Property

		Public Overridable Property Inicio As String
			Get
				Return _getDateTimePropertyValue(m_strInicio)
			End Get
			Set(ByVal Value As String)
				m_strInicio = _setDateTimePropertyValue(Value)
			End Set
		End Property

		Public Overridable Property Fim As String
			Get
				Return _getDateTimePropertyValue(m_strFim)
			End Get
			Set(ByVal Value As String)
				m_strFim = _setDateTimePropertyValue(Value)
			End Set
		End Property

		Public Overridable Property LatitudeInicio As Single
			Get
				Return m_sngLatitudeInicio
			End Get
			Set(ByVal Value As Single)
				m_sngLatitudeInicio = Value
			End Set
		End Property

		Public Overridable Property LongitudeInicio As Single
			Get
				Return m_sngLongitudeInicio
			End Get
			Set(ByVal Value As Single)
				m_sngLongitudeInicio = Value
			End Set
		End Property

		Public Overridable Property LatitudeFinal As Single
			Get
				Return m_sngLatitudeFinal
			End Get
			Set(ByVal Value As Single)
				m_sngLatitudeFinal = Value
			End Set
		End Property

		Public Overridable Property LongitudeFinal As Single
			Get
				Return m_sngLongitudeFinal
			End Get
			Set(ByVal Value As Single)
				m_sngLongitudeFinal = Value
			End Set
		End Property

        Public ReadOnly Property Status() As String
            Get
                Return m_strStatus
            End Get
        End Property

        Public ReadOnly Property IDStatus() As Integer
            Get
                Return m_intIDStatus
            End Get
        End Property

		Public readonly property IsNew() as Boolean
			Get
				return m_blnIsNew
			End Get
		end Property
		
	#End Region  
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
		Protected Overridable Sub Inflate(ByVal dr As IDataReader)
			m_dblIDMapa = dr.GetDouble(dr.GetOrdinal("IDMapa"))
			m_intTipoPedido = dr.GetInt32(dr.GetOrdinal("TipoPedido"))
			m_strPlaca = dr.GetString(dr.GetOrdinal("Placa"))
			if dr.IsDBNull(dr.GetOrdinal("IDPasta")) Then 
				m_intIDPasta = 0
			else
				m_intIDPasta = dr.GetInt32(dr.GetOrdinal("IDPasta"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("IDVendedor")) Then 
				m_intIDVendedor = 0
			else
				m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Vendedor")) Then 
				m_strVendedor = ""
			else
				m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("IDMotorista")) Then 
				m_intIDMotorista = 0
			else
				m_intIDMotorista = dr.GetInt32(dr.GetOrdinal("IDMotorista"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Motorista")) Then 
				m_strMotorista = ""
			else
				m_strMotorista = dr.GetString(dr.GetOrdinal("Motorista"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("QtdPedidos")) Then 
				m_intQtdPedidos = 0
			else
				m_intQtdPedidos = dr.GetInt32(dr.GetOrdinal("QtdPedidos"))
			end if
			m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))
			if dr.IsDBNull(dr.GetOrdinal("Inicio")) Then 
				m_strInicio = ""
			else
				m_strInicio = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Inicio")))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Fim")) Then 
				m_strFim = ""
			else
				m_strFim = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Fim")))
			end if
			if dr.IsDBNull(dr.GetOrdinal("LatitudeInicio")) Then 
				m_sngLatitudeInicio = 0
			else
				m_sngLatitudeInicio = dr.GetFloat(dr.GetOrdinal("LatitudeInicio"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("LongitudeInicio")) Then 
				m_sngLongitudeInicio = 0
			else
				m_sngLongitudeInicio = dr.GetFloat(dr.GetOrdinal("LongitudeInicio"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("LatitudeFinal")) Then 
				m_sngLatitudeFinal = 0
			else
				m_sngLatitudeFinal = dr.GetFloat(dr.GetOrdinal("LatitudeFinal"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("LongitudeFinal")) Then 
				m_sngLongitudeFinal = 0
			else
				m_sngLongitudeFinal = dr.GetFloat(dr.GetOrdinal("LongitudeFinal"))
            End If
            m_intIDStatus = dr.GetInt32(dr.GetOrdinal("IDStatus"))
            m_strStatus = dr.GetString(dr.GetOrdinal("Status"))
            m_blnIsNew = False
        End Sub

        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Function Update() As Boolean
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_MAPA"
            cmd.Parameters.Add("@IDMAPA", SqlDbType.Float).Value = m_dblIDMapa
            cmd.Parameters.Add("@TIPOPEDIDO", SqlDbType.Int).Value = m_intTipoPedido
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDMOTORISTA", SqlDbType.Int).Value = m_intIDMotorista
            cmd.Parameters.Add("@PLACA", SqlDbType.Char, 8).Value = m_strPlaca
            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                    Update = True
                Else
                    Clear()
                    Update = False
                End If
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try
        End Function

        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDMapa">Chave primaria IDMapa</param>
        ''' <param name="vTipoPedido">Chave primaria TipoPedido</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDMapa As Double, ByVal vTipoPedido As Integer) As Boolean
            Dim blnReturn As Boolean = False
            If vIDMapa = 0 Then
                Clear()
                Return blnReturn
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_MAPA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDMAPA", SqlDbType.Float).Value = vIDMapa
            cmd.Parameters.Add("@TIPOPEDIDO", SqlDbType.Int).Value = vTipoPedido
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
			m_dblIDMapa = 0
			m_intTipoPedido = 0
			m_strPlaca = ""
			m_intIDPasta = 0
			m_intIDVendedor = 0
			m_intIDMotorista = 0
			m_intQtdPedidos = 0
			m_strData = ""
			m_strInicio = ""
			m_strFim = ""
			m_sngLatitudeInicio = 0
			m_sngLongitudeInicio = 0
			m_sngLatitudeFinal = 0
            m_sngLongitudeFinal = 0
            m_intIDStatus = 0
            m_strStatus = ""
			m_blnIsNew = true 
		End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_MAPAS"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
		''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vVendedor">Filtro</param>
        ''' <param name="vMotorista">Filtro</param>
		''' <param name="vDataInicial">Filtro</param>
		''' <param name="vDataFinal">Filtro</param>
		''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
		''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
		''' <param name="vPage">Número da página a exibir</param>	
		''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vCliente As String, ByVal vVendedor As String, ByVal vMotorista As String, ByVal vIDSupervisor As Integer, ByVal vIDGrupo As Integer, ByVal vIDStatus As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_MAPAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = vCliente
            cmd.Parameters.Add("@VENDEDOR", SqlDbType.VarChar).Value = vVendedor
            cmd.Parameters.Add("@MOTORISTA", SqlDbType.VarChar).Value = vMotorista
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            cmd.Parameters.Add("@IDGRUPO", SqlDbType.Int).Value = vIDGrupo
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = vIDStatus
            If vDataInicial <> "" Then
                cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
            End If
            If vDataFinal <> "" Then
                cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)
            End If
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function
	  
        Public Function ListarPedidos(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_MAPA_PEDIDOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDMAPA", SqlDbType.Float).Value = IDMapa
            cmd.Parameters.Add("@TIPOPEDIDO", SqlDbType.Int).Value = TipoPedido
            Return ExecuteCommand(cmd, vReturnType)
        End Function


		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
	
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

