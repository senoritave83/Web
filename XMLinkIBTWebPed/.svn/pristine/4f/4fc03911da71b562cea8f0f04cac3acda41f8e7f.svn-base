

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsProduto
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDProduto As Integer
		Protected m_strCodigo As String
        Protected m_strDescricao As String
        Protected m_strPreco As String
		Protected m_intIDCategoria As Integer
		Protected m_intEstoque As Integer
		Protected m_decPrecoUnitario As Decimal
        Protected m_strCriado As String
        Protected m_sngDescontoMax As Single

		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDProduto As Integer
			Get
				Return m_intIDProduto
			End Get
		End Property

		Public Overridable Property Codigo As String
			Get
				Return m_strCodigo
			End Get
			Set(ByVal Value As String)
				m_strCodigo = Value
			End Set
		End Property

		
		Public Overridable Property Descricao As String
			Get
				Return m_strDescricao
			End Get
			Set(ByVal Value As String)
				m_strDescricao = Value
			End Set
        End Property
        Public Overridable Property Preco As String
            Get
                Return m_strPreco
            End Get
            Set(ByVal Value As String)
                m_strPreco = Value
            End Set
        End Property

		Public Overridable Property IDCategoria As Integer
			Get
				Return m_intIDCategoria
			End Get
			Set(ByVal Value As Integer)
				m_intIDCategoria = Value
			End Set
		End Property

		Public Overridable Property Estoque As Integer
			Get
				Return m_intEstoque
			End Get
			Set(ByVal Value As Integer)
				m_intEstoque = Value
			End Set
		End Property

		Public Overridable Property PrecoUnitario As Decimal
			Get
				Return m_decPrecoUnitario
			End Get
			Set(ByVal Value As Decimal)
				m_decPrecoUnitario = Value
			End Set
		End Property

        Public ReadOnly Property DescontoMax() As Single
            Get
                Return m_sngDescontoMax
            End Get
        End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
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
			m_intIDProduto = dr.GetInt32(dr.GetOrdinal("IDProduto"))
			m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
            m_strDescricao = dr.GetString(dr.GetOrdinal("Descricao"))
            m_strPreco = dr.GetString(dr.GetOrdinal("Preco"))
			if dr.IsDBNull(dr.GetOrdinal("IDCategoria")) Then 
				m_intIDCategoria = 0
			else
				m_intIDCategoria = dr.GetInt32(dr.GetOrdinal("IDCategoria"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Estoque")) Then 
				m_intEstoque = 0
			else
				m_intEstoque = dr.GetInt32(dr.GetOrdinal("Estoque"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("PrecoUnitario")) Then 
				m_decPrecoUnitario = Nothing
			else
				m_decPrecoUnitario = dr.GetDecimal(dr.GetOrdinal("PrecoUnitario"))
			end if
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            If dr.IsDBNull(dr.GetOrdinal("DescontoMax")) Then
                m_sngDescontoMax = 0
            Else
                m_sngDescontoMax = dr.Item(dr.GetOrdinal("DescontoMax"))
            End If

            m_blnIsNew = False
        End Sub



	
        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vCodigo As String, ByVal vIDCliente As Integer) As Boolean
            If vCodigo = "" Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PRODUTO"
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = vCodigo
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                    Load = True
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
			m_intIDProduto = 0
			m_strCodigo = ""
			m_strDescricao = ""
			m_intIDCategoria = 0
			m_intEstoque = 0
			m_decPrecoUnitario = Nothing
			m_strCriado = ""
            m_sngDescontoMax = 0
			m_blnIsNew = true 
		End Sub



	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_PRODUTOS"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa de produtos por categoria
        ''' </summary>		
        ''' <param name="vIDCategoria">Chave primária da categoria do produto</param>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListaProdutoCategoria(ByVal vIDCategoria As String, ByVal vIDPedido As String, Optional ByVal vCodigoProd As String = "", Optional ByVal vReturnType As enReturnType = enReturnType.DataSet) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CATEGORIA_PRODUTOS_PEDIDO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.VarChar, 255).Value = vIDCategoria
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar, 255).Value = vIDPedido
            cmd.Parameters.Add("@CODIGOPROD", SqlDbType.VarChar, 255).Value = vCodigoProd
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function
	

		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

