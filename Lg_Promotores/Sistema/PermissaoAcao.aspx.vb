Imports Classes
Imports System.Configuration.ConfigurationManager
Imports System.Drawing.Color

Partial Class sistema_PermissaoAcao
    Inherits XMWebPage
    Dim cls As clsPermissao
    Protected Const VW_IDPERMISSAO As String = "IDPermissao"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsPermissao()
        If Not Page.IsPostBack Then
            ViewState(VW_IDPERMISSAO) = CInt("0" & Request("IDPermissao"))
            cls.Load(ViewState(VW_IDPERMISSAO))
            Inflate()
            BindSections()
        Else
            cls.Load(ViewState(VW_IDPERMISSAO))
        End If
    End Sub

    Protected Sub Inflate()
        lblPermissao.Text = cls.Permissao
    End Sub

    Protected Sub BindSections()
        rptSecoes.DataSource = cls.ListarSecoes()
        rptSecoes.DataBind()
    End Sub

    Protected Function ListaAcoes(ByVal vSecao As String) As Object
        Return cls.ListarAcoes(vSecao)
    End Function

    Protected Sub chk_OnCheckedChange(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim checkbox As CheckBox = CType(sender, CheckBox)
        Dim row As GridViewRow = CType(checkbox.NamingContainer, GridViewRow)
        Dim grd As GridView = CType(row.NamingContainer, GridView)
        Dim IDAcao As Integer = grd.DataKeys(row.DataItemIndex).Item(0)
        cls.GravarAcao(IDAcao, checkbox.Checked)

        If checkbox.Checked Then
            checkbox.ForeColor = System.Drawing.Color.Red
        Else
            checkbox.ForeColor = System.Drawing.Color.FromKnownColor(Drawing.KnownColor.Black)
        End If

    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("permissao.aspx?idpermissao=" & cls.IDPermissao)
    End Sub

    Function fncPodeAlterar() As Boolean
        Dim blnPodeAlterar As Boolean = True
        If CStr(AppSettings("IdPermissaoPromotor") & "") = CStr(ViewState(VW_IDPERMISSAO)) Or _
            CStr(AppSettings("IdPermissaoLider") & "") = CStr(ViewState(VW_IDPERMISSAO)) Or _
            CStr(AppSettings("IdPermissaoCoordenador") & "") = CStr(ViewState(VW_IDPERMISSAO)) Then
            blnPodeAlterar = False
        End If
        Return blnPodeAlterar
    End Function

End Class


