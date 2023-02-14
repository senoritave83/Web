

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsRecado
        Inherits BaseClass



#Region "Declarations"
        Protected m_intIDEnvio As Integer
        Protected m_strNextel As String
        Protected m_strTexto As String
        Protected m_strDataEnviado As String
        Protected m_indEnviado As Byte
        Protected m_intIDusuario As Integer
        Protected m_strUsuario As String
        Protected m_intGrupo As Integer
        Protected m_blnIsNew As Boolean = True
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDEnvio As Integer
            Get
                Return m_intIDEnvio
            End Get
        End Property

        Public Overridable Property Nextel As String
            Get
                Return m_strNextel
            End Get
            Set(ByVal Value As String)
                m_strNextel = Value
            End Set
        End Property

        Public Overridable Property Texto As String
            Get
                Return m_strTexto
            End Get
            Set(ByVal Value As String)
                m_strTexto = Value
            End Set
        End Property

        Public Overridable Property DataEnviado As String
            Get
                Return _getDateTimePropertyValue(m_strDataEnviado)
            End Get
            Set(ByVal Value As String)
                m_strDataEnviado = _setDateTimePropertyValue(Value)
            End Set
        End Property

        Public Overridable Property Enviado As Byte
            Get
                Return m_indEnviado
            End Get
            Set(ByVal Value As Byte)
                m_indEnviado = Value
            End Set
        End Property

        Public Overridable Property IDusuario As Integer
            Get
                Return m_intIDusuario
            End Get
            Set(ByVal Value As Integer)
                m_intIDusuario = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Usuario As String
            Get
                Return m_strUsuario
            End Get
        End Property

        Public Overridable Property Grupo As Integer
            Get
                Return m_intGrupo
            End Get
            Set(ByVal Value As Integer)
                m_intGrupo = Value
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
            m_intIDEnvio = dr.GetInt32(dr.GetOrdinal("IDEnvio"))
            m_strNextel = dr.GetString(dr.GetOrdinal("Nextel"))
            m_strTexto = dr.GetString(dr.GetOrdinal("Texto"))
            If dr.IsDBNull(dr.GetOrdinal("Enviado")) Then
                m_strDataEnviado = ""
            Else
                m_strDataEnviado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Enviado")))
            End If
            m_indEnviado = dr.GetByte(dr.GetOrdinal("Enviado"))
            If dr.IsDBNull(dr.GetOrdinal("IDusuario")) Then
                m_intIDusuario = 0
            Else
                m_intIDusuario = dr.GetInt32(dr.GetOrdinal("IDusuario"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Usuario")) Then
                m_strUsuario = ""
            Else
                m_strUsuario = dr.GetString(dr.GetOrdinal("Usuario"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Grupo")) Then
                m_intGrupo = 0
            Else
                m_intGrupo = dr.GetInt32(dr.GetOrdinal("Grupo"))
            End If
            m_blnIsNew = False
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_ENVIO"
            cmd.Parameters.Add("@IDENVIO", SqlDbType.Int).Value = m_intIDEnvio
            cmd.Parameters.Add("@NEXTEL", SqlDbType.VarChar, 10).Value = m_strNextel
            cmd.Parameters.Add("@TEXTO", SqlDbType.VarChar, 140).Value = m_strTexto
            If m_strDataEnviado <> "" Then
                cmd.Parameters.Add("@ENVIADO", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strDataEnviado)
            End If
            cmd.Parameters.Add("@ENVIADO", SqlDbType.TinyInt).Value = m_indEnviado
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = m_intIDusuario
            cmd.Parameters.Add("@GRUPO", SqlDbType.Int).Value = m_intGrupo
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
        ''' <param name="vIDEnvio">Chave primaria IDEnvio</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDEnvio As Integer) As Boolean
            If vIDEnvio = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_ENVIO"
            cmd.Parameters.Add("@IDENVIO", SqlDbType.Int).Value = vIDEnvio
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
            m_intIDEnvio = 0
            m_strNextel = ""
            m_strTexto = ""
            m_strDataEnviado = ""
            m_indEnviado = 0
            m_intIDusuario = 0
            m_intGrupo = 0
            m_blnIsNew = True
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_ENVIO"
            cmd.Parameters.Add("@IDENVIO", SqlDbType.Int).Value = m_intIDEnvio

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Envio' the following row:  IDEnvio=" & m_intIDEnvio & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ENVIOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDusuario">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDusuario As Integer, ByVal vDataEnvio As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_RECADOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDusuario
            cmd.Parameters.Add("@DATAENVIO", SqlDbType.VarChar).Value = vDataEnvio
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        ''' <summary>
        ''' 	Função que grava as mensagens de envio SMS
        ''' </summary>
        ''' <param name="vNumero">Número celular para o qual será enviado a mensagem</param>
        ''' <param name="vMensagem">Mensagem que será enviada via SMS</param>	
        ''' <returns>Booleano</returns>
        Public Function Enviar(ByVal vNumero As String, ByVal vMensagem As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_RECADO_DIGITAL"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@NUMERO", SqlDbType.VarChar, 8000).Value = vNumero
            cmd.Parameters.Add("@MENSAGEM", SqlDbType.VarChar, 140).Value = vMensagem
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            Try
                ExecuteNonQuery(cmd)
                Enviar = True
                Me.User.Log("Envio de Recado", "Enviado para - NUMERO=" & vNumero & " MENSAGEM=" & vMensagem & " IDUSUARIO=" & User.IDUser)
            Catch
                Enviar = False
            End Try

        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True

            Return blnValid

        End Function

#End Region

    End Class
End Namespace

