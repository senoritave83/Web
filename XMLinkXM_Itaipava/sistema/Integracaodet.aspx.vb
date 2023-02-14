
Imports Classes

Namespace Pages.Sistema

    Partial Public Class IntegracaoDet
        Inherits XMWebPage

        Private Const VW_IDCONTEXTO As String = "IDContexto"

        Dim cls As clsIntegracao


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsIntegracao()
            If Not Page.IsPostBack Then
                ViewState(VW_IDCONTEXTO) = CInt("0" & Request("idcontexto"))
                BindGrid()
            End If
        End Sub

        Protected Sub BindGrid()
            grdDetalhes.DataSource = cls.Listar(ViewState(VW_IDCONTEXTO))
            grdDetalhes.DataBind()
        End Sub


    End Class

End Namespace

