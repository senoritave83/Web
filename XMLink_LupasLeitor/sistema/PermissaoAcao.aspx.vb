Imports Classes

Partial Class sistema_PermissaoAcao
    Inherits XMWebPage
    Dim cls As clsPermissao
    Protected Const VW_IDPERMISSAO As String = "IDPermissao"
    Protected Const VW_PERMITEEDICAO As String = "PERMITEEDICAO"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsPermissao()
        If Not Page.IsPostBack Then
            ViewState(VW_PERMITEEDICAO) = 1
            ViewState(VW_IDPERMISSAO) = CInt("0" & Request("IDPermissao"))
            cls.Load(ViewState(VW_IDPERMISSAO))
            Inflate()
            BindSections()
        Else
            cls.Load(ViewState(VW_IDPERMISSAO))
        End If
    End Sub

    Protected Function VerificaPermissaoEdicao() As Boolean
        If ViewState(VW_PERMITEEDICAO) = 0 Then
            Return False
        End If
        Return True
    End Function

    Protected Sub Inflate()
        lblPermissao.Text = cls.Permissao
        ViewState(VW_PERMITEEDICAO) = cls.PermiteEdicao
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
    End Sub


    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("permissao.aspx?idpermissao=" & cls.IDPermissao)
    End Sub

End Class
