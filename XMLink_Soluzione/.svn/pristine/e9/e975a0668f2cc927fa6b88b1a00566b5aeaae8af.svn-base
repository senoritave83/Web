Imports System.Data.SqlClient
Imports System.Web.Mail

Public Class XMWebPage
    Inherits System.Web.UI.Page
    Protected m_Usuario As UsuarioLogged
    Protected Inc_menu1 As inc_menu
    Public PageSize As Integer = 20
    Public EditCodigos As Boolean = True

    Public ReadOnly Property IDEmpresa() As Integer
        Get
            On Error Resume Next
            Return CLng("0" & Session("IDEmpresa"))
        End Get
    End Property

    Public ReadOnly Property ConnectionString() As String
        Get
            On Error Resume Next
            Return Application("cnStr")
        End Get
    End Property

    Public Sub LogError(ByVal e As Exception, ByVal vModule As String)
        If GetSetting("Debug", "False") = "False" Then
            '        m_DataClass.ExecuteNonQuery(PREFIXO & "IN_ERROS 0, '" & e.Message.Replace("'", "''") & "', '" & e.Source.Replace("'", "''") & "', '" & vModule.Replace("'", "''") & "', 'LeadCom', '" & System.Environment.Version.ToString.Replace("'", "''") & "', '" & e.TargetSite.Name.Replace("'", "''") & e.StackTrace.Replace("'", "''") & "'")
        Else
            Throw e
        End If
    End Sub

    Public Function GetSetting(ByVal vKey As String, ByVal vDefault As String) As String
        Dim cfg As New System.Configuration.AppSettingsReader
        Try
            Return cfg.GetValue(vKey, GetType(System.String))
        Catch e As Exception
            Return vDefault
        End Try
        cfg = Nothing
    End Function

    Public Sub ShowError(ByVal vError As String)
        Response.Redirect("mostraerro.aspx?Volta=" & Server.UrlEncode(Request.Url.ToString) & "&Erro=" & Server.UrlEncode(vError), True)
    End Sub

    Public Sub ShowMsg(ByVal vCaption As String)
        Response.Write("<script>alert('" & vCaption & "');</script>")
    End Sub

    Public Overridable Function CheckPermission(ByVal vSecao As String, ByVal vAcao As String) As Boolean
        Return True
    End Function

    Public ReadOnly Property Usuario() As UsuarioLogged
        Get
            Return m_Usuario
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'm_DataClass = New DataClass(Me)
        EnsureChildControls()
        If m_Usuario Is Nothing Then m_Usuario = New UsuarioLogged(Me)
        If Not Inc_menu1 Is Nothing Then
            Inc_menu1.SetUser(m_Usuario)
        End If
    End Sub

    Public Sub SendMessage(ByVal vMessage As Mail.MailMessage)
        Dim smtp As Mail.SmtpMail
        smtp.SmtpServer = "192.168.0.1"
        smtp.Send(vMessage)
    End Sub

    Public Sub MostraGravado(ByVal vVolta As String)
        Response.Redirect(vVolta, True)
        'Response.Redirect("gravado.aspx?Volta=" & Server.UrlEncode(vVolta), True)
    End Sub
End Class


Public Enum enAuthorize
    NotAuthorized = 0
    Authorized = 1
    PasswordNotSet = 2
    Denied = 3
End Enum


Public Class clsBaseClass
    Private m_XMWebPage As XMWebPage
    Protected m_DataClass As DataClass

    Public Sub New(ByVal vXMPage As XMWebPage)
        m_XMWebPage = vXMPage
        m_DataClass = New DataClass(m_XMWebPage.ConnectionString)
    End Sub

    Protected Function GetDataSet(ByVal SQL As String) As DataSet
        Return m_DataClass.GetDataSet(SQL)
    End Function

    Protected Function ExecuteNonQuery(ByVal SQL As String)
        Return m_DataClass.ExecuteNonQuery(SQL)
    End Function

    Protected Function GetXML(ByVal SQL As String) As String
        Return m_DataClass.GetXML(SQL)
    End Function

    Protected ReadOnly Property XMPage() As XMWebPage
        Get
            Return m_XMWebPage
        End Get
    End Property

    Public ReadOnly Property DefaultPage() As String
        Get

        End Get
    End Property
End Class



Public Class XMProtectedPage
    Inherits XMWebPage

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_Usuario.IDUsuario = -1 Or m_Usuario.IDUsuario = 0 Then
            Dim StrPath, StrQS As String
            StrPath = Request.Path
            StrQS = Request.ServerVariables("QUERY_STRING")
            StrPath = StrPath & "?" & StrQS
            Response.Redirect(GetDefaultPage() & IIf(StrPath = "", "", "?RedirectTo=" & Server.UrlEncode(StrPath)), True)
        End If
    End Sub

    Protected Function GetDefaultPage() As String
        Dim strURL As String
        strURL = Request.ServerVariables("PATH_INFO")
        If Left(strURL, 1) = "/" Then strURL = Mid(Request.ServerVariables("PATH_INFO"), 2)
        Return "/" & Left(strURL, InStr(strURL, "/")) & "default.aspx"
    End Function

    Public Overrides Function CheckPermission(ByVal vSecao As String, ByVal vAcao As String) As Boolean
        Dim cmd As New SqlCommand
        Dim cn As New SqlConnection(ConnectionString)
        Dim prm As SqlParameter
        cn.Open()
        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "BS_VERIFICAR_PERMISSAO"

        prm = New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        prm.Direction = ParameterDirection.ReturnValue
        cmd.Parameters.Add(prm)

        prm = New SqlParameter("@IDEMPRESA", SqlDbType.Int)
        prm.Value = Me.IDEmpresa
        cmd.Parameters.Add(prm)

        prm = New SqlParameter("@IDUSUARIO", SqlDbType.Int)
        prm.Value = Me.Usuario.IDUsuario
        cmd.Parameters.Add(prm)

        prm = New SqlParameter("@SECAO", SqlDbType.VarChar, 50)
        prm.Value = vSecao
        cmd.Parameters.Add(prm)

        prm = New SqlParameter("@ACAO", SqlDbType.VarChar, 50)
        prm.Value = vAcao
        cmd.Parameters.Add(prm)

        cmd.ExecuteNonQuery()
        If cmd.Parameters("@RETURN_VALUE").Value = 0 Then
            CheckPermission = False
        Else
            CheckPermission = True
        End If
        'clean up
        cn.Close()
        cmd = Nothing
        cn = Nothing
    End Function

End Class

Public Module globalFunctions

    Public Function xmSetSQLString(ByVal vData As String) As String
        Return "'" & vData & "'"
    End Function

    Public Function xmSetSQLValue(ByVal vData As Decimal) As String
        Return vData.ToString().Replace(".", ",").Replace(",", ".")
    End Function

    Public Sub setComboValue(ByVal vCombo As DropDownList, ByVal Value As String)
        Dim it As ListItem
        it = vCombo.Items.FindByValue(Value)
        vCombo.ClearSelection()
        If Not it Is Nothing Then
            it.Selected = True
        End If
    End Sub

    Public Function getComboText(ByVal vCombo As Object) As String

        Dim it As ListItem, strReturn As String = ""

        For Each it In vCombo.Items
            If it.Selected Then
                strReturn = it.Text
                Exit For
            End If
        Next
        Return strReturn

    End Function

    Public Function getComboValue(ByVal vCombo As Object) As Integer

        Dim it As ListItem, intReturn As Integer = 0

        For Each it In vCombo.Items
            If it.Selected Then
                intReturn = it.Value
                Exit For
            End If
        Next
        Return intReturn

    End Function

    Public Function getComboValues(ByVal vCombo As Object, Optional ByVal vReturnAll As Boolean = False) As String

        Dim it As ListItem, strReturn As String = ""

        For Each it In vCombo.Items
            If it.Selected Then
                If strReturn <> "" Then strReturn &= ","
                strReturn &= it.Value
            End If
        Next
        If strReturn = "" And vReturnAll = True Then
            For Each it In vCombo.Items
                If strReturn <> "" Then strReturn &= ","
                strReturn &= it.Value
            Next
        End If
        Return strReturn

    End Function

    Public Function checkDate(ByVal p_Date As String, Optional ByVal p_SQLFormat As Boolean = False, Optional ByVal p_ReturnNull As Boolean = False) As String
        If Not IsDate(p_Date) Then
            Return IIf(p_ReturnNull, "NULL", "")
        End If
        If p_SQLFormat Then
            Return "'" & Right("0000" & Year(p_Date), 4) & "-" & Right("00" & Month(p_Date), 2) & "-" & Right("00" & Day(p_Date), 2) & "'"
        Else
            Return Right("00" & Day(p_Date), 2) & "/" & Right("00" & Month(p_Date), 2) & "/" & Right("0000" & Year(p_Date), 4)
        End If
    End Function
    Public Sub setCheckValue(ByVal vCombo As Object, ByVal p_Value As String)
        Dim it As ListItem
        it = vCombo.Items.FindByValue(p_Value)
        vCombo.ClearSelection()
        If Not it Is Nothing Then
            it.Selected = True
        End If
    End Sub
    Public Function retornaCelula(ByVal p_Num As Integer) As String

        Const P_BASE As Integer = 26
        p_Num = p_Num - 1
        Dim p_Ret As String, objCel As Object = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(",")

        Dim p_tmpResultado As Integer = p_Num \ P_BASE, p_NumResto As Integer = p_Num Mod P_BASE
        p_Ret = objCel(p_NumResto)
        While p_tmpResultado > 0
            p_tmpResultado = p_tmpResultado - 1
            p_NumResto = (p_tmpResultado) Mod P_BASE
            p_tmpResultado = p_tmpResultado \ P_BASE
            p_Ret = objCel(p_NumResto) & p_Ret
        End While
        Return p_Ret

    End Function

    Public Function excelExportFormatCells(ByVal p_Value As String) As String

        Dim p_NewValue As String = ""
        If IsNumeric(p_Value) Then
            p_Value = FormatNumber(p_Value, 2).ToString
            p_NewValue = p_Value.Replace(".", "").Replace(",", ".")
        End If
        Return p_NewValue

    End Function

    Public Function GetNomeMes(ByVal p_Mes As Integer) As String
        Dim p_NomeMes As String = ""
        Select Case p_Mes
            Case 1
                p_NomeMes = "Janeiro"
            Case 2
                p_NomeMes = "Fevereiro"
            Case 3
                p_NomeMes = "Março"
            Case 4
                p_NomeMes = "Abril"
            Case 5
                p_NomeMes = "Maio"
            Case 6
                p_NomeMes = "Junho"
            Case 7
                p_NomeMes = "Julho"
            Case 8
                p_NomeMes = "Agosto"
            Case 9
                p_NomeMes = "Setembro"
            Case 10
                p_NomeMes = "Outubro"
            Case 11
                p_NomeMes = "Novembro"
            Case 12
                p_NomeMes = "Dezembro"
        End Select

        Return p_NomeMes

    End Function

    Public Function fncDiferencaEntreDatas(ByVal vData1 As String, ByVal vData2 As String) As String

        Dim strReturn As String = ""
        Dim intSegundos As Integer = 0
        Dim vHoras As String = 0
        Dim vMinutos As Integer = 0
        Dim vSegundos As Integer = 0

        If IsDate(vData1) And IsDate(vData2) Then

            Dim m_dtmInicio As New DateTime(Year(vData1), Month(vData1), Day(vData1), Hour(vData1), Minute(vData1), Second(vData1))
            Dim m_dtmFim As New DateTime(Year(vData2), Month(vData2), Day(vData2), Hour(vData2), Minute(vData2), Second(vData2))

            Dim dif As TimeSpan = m_dtmFim.Subtract(m_dtmInicio)
            Dim dias As Integer = dif.Days
            Dim horas As Integer = dif.Hours
            Dim minutos As Integer = dif.Minutes
            Dim segundos As Integer = dif.Seconds

            strReturn = IIf(horas > 0, horas & " Hora" & IIf(horas > 1, "s", ""), "") & " " & _
                        IIf(minutos > 0, minutos & " Minuto" & IIf(minutos > 1, "s", ""), "") & " " & _
                        IIf(segundos > 0, segundos & " Segundo" & IIf(segundos > 1, "s", ""), "")

        End If

        Return strReturn

    End Function

    Public Function fncTempoRestanteDias(ByVal vQuantidade As Integer, _
                                         ByVal vDiasPassados As Integer, _
                                         ByVal vTotalPesquisas As Integer) As String
        Dim strReturn As String = ""
        Dim vDiasTotal As Integer = 0

        If vQuantidade > 0 And vDiasPassados > 0 And vTotalPesquisas > 0 Then

            vDiasTotal = (vTotalPesquisas * vDiasPassados) / vQuantidade
            strReturn = Now().AddDays(vDiasTotal - vDiasPassados).ToShortDateString()

        End If

        Return strReturn

    End Function

End Module
