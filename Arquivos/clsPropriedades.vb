Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsPropriedades
        Inherits BaseClass

#Region "Declarations"
        Protected m_intIDPropriedade As Integer
        Protected m_strPropriedade As String
        Protected m_intStatus As Integer
        Protected m_intOrdem As Integer
#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDPropriedade As Integer
            Get
                Return m_intIDPropriedade
            End Get
        End Property

        Public Overridable Property Propriedade As String
            Get
                Return m_strPropriedade
            End Get
            Set(ByVal Value As String)
                m_strPropriedade = Value
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

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDPropriedade = 0
            End Get
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDPropriedade = dr.GetInt32(dr.GetOrdinal("IDPropriedade"))
            m_strPropriedade = dr.GetString(dr.GetOrdinal("Propriedade"))
            m_intStatus = dr.GetByte(dr.GetOrdinal("IdStatus"))

            If dr.IsDBNull(dr.GetOrdinal("Propriedade")) Then
                m_strPropriedade = ""
            Else
                m_strPropriedade = dr.GetString(dr.GetOrdinal("Propriedade"))
            End If

            If dr.IsDBNull(dr.GetOrdinal("IdStatus")) Then
                m_intStatus = 1
            Else
                m_intStatus = dr.GetByte(dr.GetOrdinal("IdStatus"))
            End If

            If dr.IsDBNull(dr.GetOrdinal("Ordem")) Then
                m_intOrdem = 0
            Else
                m_intOrdem = dr.GetInt32(dr.GetOrdinal("Ordem"))
            End If

        End Sub

        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_PROPRIEDADE"
            cmd.Parameters.Add("@IDPROPRIEDADE", SqlDbType.Int).Value = m_intIDPropriedade
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@PROPRIEDADE", SqlDbType.VarChar, 50).Value = m_strPropriedade
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = m_intStatus

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

            cmd.Parameters.Add("@ORDEM", SqlDbType.Int).Value = m_intOrdem
            Me.User.Log("Cadastro de Propriedade", "Gravar - IDPROPRIEDADE=" & m_intIDPropriedade & " PROPRIEDADE=" & m_strPropriedade & " ORDEM=" & m_intOrdem)

        End Sub

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
     

        Public Function Load(ByVal m_intIDPropriedade As Integer) As Boolean

            If m_intIDPropriedade = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PROPRIEDADE"
            cmd.Parameters.Add("@IDPROPRIEDADE", SqlDbType.Int).Value = m_intIDPropriedade
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

            Me.User.Log("Cadastro de Propriedades", "Visualizar - IDPROPRIEDADE=" & m_intIDPropriedade)

        End Function

        Protected Sub Clear()
            m_intIDPropriedade = 0
            m_strPropriedade = ""
            m_intStatus = 1
        End Sub


        ''' <summary>
        ''' 	Rotina que Inativa o registro atual
        ''' </summary>
        Public Function Delete() As Integer

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PROPRIEDADE"
            cmd.Parameters.Add("@IDPROPRIEDADE", SqlDbType.Int).Value = m_intIDPropriedade
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Dim drDelete As IDataReader = ExecuteReader(cmd)

            Try
                If drDelete.Read Then

                    If drDelete.GetInt32(drDelete.GetOrdinal("Retorno")) = 1 Then
                        Me.User.Log("Cadastro de Property", "Apagar - IDPROPRIEDADE=" & m_intIDPropriedade)
                        MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Property' the following row:  IDPropriedade=" & m_intIDPropriedade & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
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
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PROPRIEDADES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenção utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>

        Public Function Listar(ByVal vFilter As String, ByVal vStatus As Integer, ByVal vOrder As String, _
                              ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, _
                              Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PROPRIEDADES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = vStatus
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function


        ''   Public Function Existe(ByVal m_intIDPropriedade As Integer, ByVal m_strPropriedade As String) As Boolean

        'Dim cmd As New SqlCommand()
        '    cmd.CommandType = CommandType.StoredProcedure
        '    cmd.CommandText = PREFIXO & "SE_PROPRIEDADE_EXISTENTE"
        '    cmd.Parameters.Add("@IDPROPRIEDADE", SqlDbType.Int).Value = m_intIDPropriedade
        '    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
        '    cmd.Parameters.Add("@PROPRIEDADE", SqlDbType.VarChar, 50).Value = m_strPropriedade

        '    Return ExecuteScalar(cmd)

        'End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vIdCategoria">Id da Property</param>		
        ''' <param name="vMovimento">Up ou Down</param>		
        Public Sub TrocarOrdem(ByVal vIdPropriedade As Integer, ByVal vMovimento As Integer)
            'Movimentos
            '1 - UP
            '2 - DOWNN
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "BS_TROCAORDEM_PROPRIEDADE"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPROPRIEDADE", SqlDbType.Int).Value = vIdPropriedade
            cmd.Parameters.Add("@MOVIMENTO", SqlDbType.Int).Value = vMovimento
            MyBase.ExecuteNonQuery(cmd)

        End Sub


       
       
        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strPropriedade = "" Then
                AddBrokenRule("Por favor informe o Property!")
                blnValid = False
                '    ElseIf Existe(m_intIDPropriedade, m_strPropriedade) Then
                '      AddBrokenRule("Property informado existente!")
                '     blnValid = False
            End If
            Return blnValid
        End Function

#End Region



    End Class
End Namespace

