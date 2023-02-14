
Imports System
Imports System.Data
Imports System.Data.SqlClient


Public Class clsEtapa
    Inherits DataClass



#Region "Declarations"
    Protected m_intIDEtapa As Integer
    Protected m_strEtapa As String
    Protected m_strColor As String
    Protected m_intPosicao As Integer
    Protected m_blnIsNew As Boolean = True
#End Region


#Region "Properties"
    Public Overridable ReadOnly Property IDEtapa() As Integer
        Get
            Return m_intIDEtapa
        End Get
    End Property

    Public Overridable Property Etapa() As String
        Get
            Return m_strEtapa
        End Get
        Set(ByVal Value As String)
            m_strEtapa = Value
        End Set
    End Property

    Public Overridable Property Color() As String
        Get
            Return m_strColor
        End Get
        Set(ByVal Value As String)
            m_strColor = Value
        End Set
    End Property

    Public Overridable ReadOnly Property Posicao() As Integer
        Get
            Return m_intPosicao
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
        m_intIDEtapa = dr.GetInt32(dr.GetOrdinal("IDEtapa"))
        m_strEtapa = dr.GetString(dr.GetOrdinal("Etapa"))
        m_strColor = dr.GetString(dr.GetOrdinal("Color"))
        m_intPosicao = dr.GetInt32(dr.GetOrdinal("Posicao"))
        m_blnIsNew = False
    End Sub




    ''' <summary>
    ''' 	Função que grava os dados do registro atual
    ''' </summary>
    Public Sub Update()
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SV_ETAPA"
        cmd.Parameters.Add("@IDETAPA", SqlDbType.Int).Value = m_intIDEtapa
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@ETAPA", SqlDbType.VarChar, 50).Value = m_strEtapa
        cmd.Parameters.Add("@COLOR", SqlDbType.VarChar, 30).Value = m_strColor
        cmd.Parameters.Add("@POSICAO", SqlDbType.Int).Value = m_intPosicao
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
    ''' <param name="vIDEtapa">Chave primaria IDEtapa</param>
    ''' <returns>Boolean</returns>
    Public Function Load(ByVal vIDEtapa As Integer) As Boolean
        If vIDEtapa = 0 Then
            Clear()
            Return False
        End If
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_ETAPA"
        cmd.Parameters.Add("@IDETAPA", SqlDbType.Int).Value = vIDEtapa
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
    ''' 	Função interna que limpa as variaveis internas
    ''' </summary>
    Protected Sub Clear()
        m_intIDEtapa = 0
        m_strEtapa = ""
        m_strColor = ""
        m_intPosicao = 0
        m_blnIsNew = True
    End Sub



    ''' <summary>
    ''' 	Rotina que apaga o registro atual
    ''' </summary>
    Public Sub Delete()

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_ETAPA"
        cmd.Parameters.Add("@IDETAPA", SqlDbType.Int).Value = m_intIDEtapa
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa

        ExecuteNonQuery(cmd)

        Clear()

    End Sub

    ''' <summary>
    ''' 	Função que retorna uma listagem completa
    ''' </summary>
    ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
    ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
    Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

        Dim cmd As New SqlCommand()
        cmd.CommandText = SQLPREFIXO & "LS_ETAPAS"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        Return ExecuteCommand(cmd, vReturnType)

    End Function

    ''' <summary>
    ''' 	Função que retorna uma listagem apenas das etapas disponiveis
    ''' </summary>
    ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
    ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
    Public Function ListarDisponiveis(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

        Dim cmd As New SqlCommand()
        cmd.CommandText = SQLPREFIXO & "LS_ETAPAS_DISPONIVEIS"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        Return ExecuteCommand(cmd, vReturnType)

    End Function


    Public Sub Gravar(ByVal vPosicao As String, ByVal vTexto As String, ByVal vColor As String)

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SV_ETAPA"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@POSICAO", SqlDbType.Int).Value = vPosicao
        cmd.Parameters.Add("@TEXTO", SqlDbType.VarChar, 50).Value = vTexto
        cmd.Parameters.Add("@COLOR", SqlDbType.VarChar, 30).Value = vColor
        ExecuteNonQuery(cmd)

    End Sub

    Protected Overrides Function CheckIfSubClassIsValid() As Boolean
        Dim blnValid As Boolean = True

        Return blnValid

    End Function

#End Region

End Class

