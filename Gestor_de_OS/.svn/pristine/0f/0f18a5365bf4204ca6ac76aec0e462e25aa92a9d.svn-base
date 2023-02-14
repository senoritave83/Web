Partial Class hotsite_hotsite
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        liBeneficios.Attributes("class") = IIf(Me.Page.Request.Path.ToLower.EndsWith("beneficios.aspx"), "on", "")
        liEOL.Attributes("class") = IIf(Me.Page.Request.Path.ToLower.EndsWith("equipe.aspx"), "on", "")
        liComoAdquirir.Attributes("class") = IIf(Me.Page.Request.Path.ToLower.EndsWith("adquirir.aspx"), "on", "")
        liRequisitos.Attributes("class") = IIf(Me.Page.Request.Path.ToLower.EndsWith("requisitos.aspx"), "on", "")

    End Sub

End Class

