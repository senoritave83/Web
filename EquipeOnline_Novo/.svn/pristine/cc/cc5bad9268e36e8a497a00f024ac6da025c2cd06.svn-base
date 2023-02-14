
Partial Class hotsite_popup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim pp As New Popup
            chk_Mostrar.Visible = True
            pp.PopUpExibido()
        End If
    End Sub

    Protected Sub chk_Mostrar_CheckedChanged(sender As Object, e As System.EventArgs) Handles chk_Mostrar.CheckedChanged
        Dim pp As New Popup
        pp.ShowPopUp = chk_Mostrar.Checked
    End Sub

End Class
