
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class clsCategoria
    Inherits BaseClass


#Region "Declarations"
    Protected m_intIDCategoria As Integer
    Protected m_strCodigo As String
    Protected m_strCategoria As String
    Protected m_strCriado As String
    Protected m_blnIsNew As Boolean = True
#End Region


#Region "Properties"

    Public Overridable ReadOnly Property IDCategoria As Integer
        Get
            Return m_intIDCategoria
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

    Public Overridable Property Categoria As String
        Get
            Return m_strCategoria
        End Get
        Set(ByVal Value As String)
            m_strCategoria = Value
        End Set
    End Property

    Public Overridable Property Criado As String
        Get
            Return _getDateTimePropertyValue(m_strCriado)

        End Get

        Set(ByVal value As String)
            m_strCriado = value

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
        If dr.IsDBNull(dr.GetOrdinal("IDCategoria")) Then
            m_intIDCategoria = 0
        Else
            m_intIDCategoria = dr.GetInt32(dr.GetOrdinal("IDCategoria"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Codigo")) Then
            m_strCodigo = ""
        Else
            m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
        End If
        If dr.IsDBNull(dr.GetOrdinal("Categoria")) Then
            m_strCategoria = ""
        Else
            m_strCategoria = dr.GetString(dr.GetOrdinal("Categoria"))
        End If
        m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))


        m_blnIsNew = False
    End Sub



    ''' <summary>
    ''' 	Função que obtem os dados do registro solicitado 
    ''' </summary>
    ''' <param name="vIDCategoria">Chave primaria IDCategoria</param>
    ''' <returns>Boolean</returns>
    Public Function Load(ByVal vIDCategoria As Integer) As Boolean
            If vIDCategoria = 0 Then
                Clear()
                Return False
            End If
            Dim cn As SQLConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CATEGORIA"
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).value = vIDCategoria
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            cn.Open()
            Try
                Dim dr As IDataReader = cmd.ExecuteReader()
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
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try
    End Function



    ''' <summary>
    ''' 	Função interna que limpa as variaveis internas
    ''' </summary>
    Protected Sub Clear()

        m_intIDCategoria = 0
        m_strCodigo = ""
        m_strCategoria = ""
        m_strCriado = ""
        m_blnIsNew = True

    End Sub



    ''' <summary>
    ''' 	Função que retorna uma listagem completa
    ''' </summary>
    ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
    ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
    Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "LS_CATEGORIAS"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
        Return ExecuteCommand(cmd, vReturnType)

    End Function


    Protected Overrides Function CheckIfSubClassIsValid() As Boolean
        Dim blnValid As Boolean = True
        Return blnValid

    End Function

#End Region



End Class
