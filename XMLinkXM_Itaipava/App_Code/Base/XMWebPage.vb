Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationManager
Imports System.Web
Imports System.Security.Cryptography

Public Class XMWebPage
    Inherits Page

    Protected Const ACAO_ADICIONAR As String = "Adicionar"
    Protected Const ACAO_EDITAR As String = "Editar"
    Protected Const ACAO_APAGAR As String = "Apagar"

    Public Sub New()

    End Sub

    Public Function Logout() As Boolean
        FormsAuthentication.SignOut()
        Return True
    End Function

    Public Function GetPath() As String
        Dim strPath As String = AppSettings("File_Directory")
        If strPath = "" Then
            strPath = Server.MapPath("~/files/")
        End If
        Return strPath
    End Function

    Public Sub GravaFiltro(ByVal vControl As UserControl)
        For Each ctr As Control In vControl.Controls
            GravaFiltro(ctr)
        Next
    End Sub

    Public Function RecuperaFiltro(ByVal vControl As UserControl) As Boolean
        For Each ctr As Control In vControl.Controls
            RecuperaFiltro(ctr)
        Next
        Return True
    End Function

    Public Sub GravaFiltro(ByVal ParamArray vControls() As Control)
        Dim cookie As New HttpCookie("FILTRO")
        cookie.Values.Add("URL", Request.Path)
        For Each ctr As Control In vControls
            If ctr.GetType Is GetType(TextBox) Then
                cookie.Values.Add(ctr.ID, CType(ctr, TextBox).Text)
            ElseIf ctr.GetType Is GetType(DropDownList) Then
                cookie.Values.Add(ctr.ID, CType(ctr, DropDownList).SelectedValue)
            ElseIf TypeOf ctr Is IFiltroControl Then
                cookie.Values.Add(ctr.ID, CType(ctr, IFiltroControl).Value)
            ElseIf TypeOf ctr Is ListControl Then
                Dim strValues As String = ""
                For Each it As ListItem In CType(ctr, ListControl).Items
                    If it.Selected Then strValues &= IIf(strValues = "", "", ",") & it.Value
                Next
                cookie.Values.Add(ctr.ID, strValues)
            End If
        Next

        Response.Cookies.Add(cookie)
    End Sub

    Public Function RecuperaFiltro(ByVal ParamArray vControls() As Control) As Boolean

        Dim cookie As HttpCookie = Request.Cookies.Item("FILTRO")
        If Not cookie Is Nothing Then
            If cookie.Values("URL").ToLower() = Request.Path.ToLower() Then
                For Each ctr As Control In vControls
                    If ctr.GetType Is GetType(TextBox) Then
                        CType(ctr, TextBox).Text = cookie.Values(ctr.ID)
                    ElseIf ctr.GetType Is GetType(DropDownList) Then
                        setComboValue(ctr, cookie.Values(ctr.ID))
                    ElseIf TypeOf ctr Is IFiltroControl Then
                        CType(ctr, IFiltroControl).Value = cookie.Values(ctr.ID)
                    ElseIf TypeOf ctr Is ListControl Then
                        Dim strValues As String = "," & cookie.Values(ctr.ID) & ","
                        For Each it As ListItem In CType(ctr, ListControl).Items
                            it.Selected = (InStr(strValues, "," & it.Value & ",") > 0)
                        Next
                        cookie.Values.Add(ctr.ID, strValues)
                    End If
                Next
                Return True
            End If
        End If
        Return False
    End Function


    Public Overloads ReadOnly Property User() As XMPrincipal
        Get
            Try
                Return CType(HttpContext.Current.User, XMPrincipal)
            Catch e As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public Sub MostraGravado(ByVal vVolta As String)
        Response.Redirect(vVolta, True)
    End Sub

    Protected Sub subAddConfirm(ByVal vButton As Button, ByVal vMessage As String)
        vButton.Attributes.Add("onclick", "return Confirmar(""" & vMessage & """);")
    End Sub

    Public Sub ShowMsg(ByVal vCaption As String)
        Response.Write("<script>alert('" & vCaption & "');</script>")
    End Sub

    Public Function VerificaPermissao(ByVal vSecao As String, ByVal vAcao As String) As Boolean
        If vSecao = "" Then
            Return True
        End If
        Dim permissao As New Classes.clsPermissao
        Return permissao.VerificaPermissao(vSecao, vAcao)
    End Function

    Protected Function VerificaRoles(ByVal Roles As ArrayList) As Boolean
        Dim blnOK As Boolean = False
        If Roles.Count > 0 Then
            For Each s As String In Roles
                If s = "*" Then
                    blnOK = True
                    Exit For
                ElseIf Me.Page.User.IsInRole(s) Then
                    blnOK = True
                End If
            Next
        Else
            blnOK = True
        End If
        Return blnOK
    End Function
End Class

Public Class XMCrypto

    Private Const cryptoKey As String = "ITAIPAVA_XMSISTEMAS_XMLINK"
    Private Shared IV As Byte() = New Byte(7) {240, 3, 45, 29, 0, 76, 173, 59}
    Private Shared IV_192() As Byte = {55, 103, 246, 79, 36, 99, 167, 3, 42, 5, 62, 83, 184, 7, 209, 13, 145, 23, 200, 58, 173, 10, 121, 222}

    Public Shared Function Encrypt(ByVal p_Val As String) As String

        Dim buffer As Byte() = Encoding.ASCII.GetBytes(p_Val)
        Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
        Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider

        des.Key = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey))
        des.IV = IV

        Return Convert.ToBase64String(des.CreateEncryptor.TransformFinalBlock(buffer, 0, buffer.Length))

    End Function

    Public Shared Function Decrypt(ByVal p_Val As String) As String

        Dim p_Return As String = ""

        Try
            Dim buffer As Byte() = Convert.FromBase64String(p_Val)
            Dim des As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
            Dim MD5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
            des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey))
            des.IV = IV
            p_Return = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length()))
        Catch ex As Exception
            p_Return = ""
        End Try

        Return p_Return

    End Function

End Class

Public Module globalFunctions

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



End Module

