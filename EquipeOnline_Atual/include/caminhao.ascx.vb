
Partial Class include_caminhao
    Inherits System.Web.UI.UserControl

    Public Property Etapas() As Integer
        Get
            Return ViewState("Etapas")
        End Get
        Set(ByVal value As Integer)
            ViewState("Etapas") = value
        End Set
    End Property

    Public Property Realizadas() As Integer
        Get
            Return ViewState("Realizadas")
        End Get
        Set(ByVal value As Integer)
            ViewState("Realizadas") = value
        End Set
    End Property

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        If Realizadas = 0 Or Etapas = 0 Then
            ltrPorcentagem.Text = "0%"
        Else
            ltrPorcentagem.Text = FormatPercent(Realizadas / Etapas, 0)
        End If
    End Sub
End Class
