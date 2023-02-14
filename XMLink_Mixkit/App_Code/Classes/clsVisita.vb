

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports XMSistemas.Web.Base

Namespace Classes

	Public Class clsVisita
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDVisita As Integer
        Protected m_intIDCliente As Integer
        Protected m_strCliente As String
        Protected m_intIDVendedor As Integer
        Protected m_strVendedor As String
		Protected m_strData As String
        Protected m_intIDJustificativa As Integer
        Protected m_strJustificativa As String
        Protected m_sngLatitudeInicio As Single
        Protected m_sngLongitudeInicio As Single
        Protected m_sngLatitudeFinal As Single
        Protected m_sngLongitudeFinal As Single
        Protected m_strInicio As String
        Protected m_strTermino As String
        Protected m_blnIsNew As Boolean = True
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDVisita As Integer
			Get
				Return m_intIDVisita
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

        Public ReadOnly Property Justificativa() As String
            Get
                Return m_strJustificativa
            End Get
        End Property

        Public Overridable ReadOnly Property LatitudeInicio() As Single
            Get
                Return m_sngLatitudeInicio
            End Get
        End Property

        Public Overridable ReadOnly Property LongitudeInicio() As Single
            Get
                Return m_sngLongitudeInicio
            End Get
        End Property

        Public Overridable ReadOnly Property LatitudeFinal() As Single
            Get
                Return m_sngLatitudeFinal
            End Get
        End Property

        Public Overridable ReadOnly Property LongitudeFinal() As Single
            Get
                Return m_sngLongitudeFinal
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
			m_intIDVisita = dr.GetInt32(dr.GetOrdinal("IDVisita"))
			m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IDCliente"))
            m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))
            m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
            m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
			if dr.IsDBNull(dr.GetOrdinal("Data")) Then 
				m_strData = ""
			else
				m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))
			end if
			if dr.IsDBNull(dr.GetOrdinal("IDJustificativa")) Then 
				m_intIDJustificativa = 0
			else
				m_intIDJustificativa = dr.GetInt32(dr.GetOrdinal("IDJustificativa"))
			end if
            If dr.IsDBNull(dr.GetOrdinal("LatitudeInicio")) Then
                m_sngLatitudeInicio = 0
            Else
                m_sngLatitudeInicio = dr.GetFloat(dr.GetOrdinal("LatitudeInicio"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("LongitudeInicio")) Then
                m_sngLongitudeInicio = 0
            Else
                m_sngLongitudeInicio = dr.GetFloat(dr.GetOrdinal("LongitudeInicio"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("LatitudeFinal")) Then
                m_sngLatitudeFinal = 0
            Else
                m_sngLatitudeFinal = dr.GetFloat(dr.GetOrdinal("LatitudeFinal"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("LongitudeFinal")) Then
                m_sngLongitudeFinal = 0
            Else
                m_sngLongitudeFinal = dr.GetFloat(dr.GetOrdinal("LongitudeFinal"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Justificativa")) Then
                m_strJustificativa = ""
            Else
                m_strJustificativa = dr.GetString(dr.GetOrdinal("Justificativa"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Inicio")) Then
                m_strInicio = ""
            Else
                m_strInicio = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Inicio")))
            End If
			if dr.IsDBNull(dr.GetOrdinal("Termino")) Then 
				m_strTermino = ""
			else
				m_strTermino = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Termino")))
            End If
            m_blnIsNew = False
		End Sub




        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDVisita">Chave primaria IDVisita</param>
        ''' <returns>Boolean</returns>
		Public Function Load(ByVal vIDVisita As Integer) As Boolean
			If vIDVisita = 0 Then 
				Clear()
				return false
			End if
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_VISITA"
			cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).value = vIDVisita
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			Dim dr As IDataReader = ExecuteReader(cmd)
			try
				If dr.Read Then
					Inflate(dr)
				Else
					Clear()
				End If
			finally
				If (Not dr Is Nothing) Then
					dr.Close()
					dr = Nothing
				End If
			end try
		End Function			

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
		Protected Sub Clear()
			m_intIDVisita = 0
			m_intIDCliente = 0
			m_intIDVendedor = 0
			m_strData = ""
			m_intIDJustificativa = 0
            m_sngLatitudeInicio = 0
            m_sngLongitudeInicio = 0
            m_sngLatitudeFinal = 0
            m_sngLongitudeFinal = 0
            m_strInicio = ""
            m_strTermino = ""
            m_strJustificativa = ""
			m_blnIsNew = true 
		End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_VISITAS"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vCliente">Filtro</param>
        ''' <param name="vVendedor">Filtro</param>
		''' <param name="vDataInicial">Filtro</param>
		''' <param name="vDataFinal">Filtro</param>
		''' <param name="vIDJustificativa">Filtro</param>
		''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
		''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
		''' <param name="vPage">Número da página a exibir</param>	
		''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vCliente As String, ByVal vVendedor As String, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vIDJustificativa As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_VISITAS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = vCliente
            cmd.Parameters.Add("@VENDEDOR", SqlDbType.VarChar).Value = vVendedor
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
	  


		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
	
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

