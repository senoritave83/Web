Imports System.Web.Services

Partial Class formulario_respostas
    Inherits XMWebPage

    <WebMethod()> _
    Public Shared Sub GravarXMLEntidadeItem(ByVal vIdentifier As String, ByVal vTipoEntidade As Byte, ByVal vIDReferencia As Integer, ByVal vXML As String)
        controls_respostas.GravarXMLEntidadeItem(vIdentifier, vTipoEntidade, vIDReferencia, vXML)
    End Sub


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            respostas1.IDVisita = CInt("0" & Request("IDVisita"))
            respostas1.TipoEntidade = CByte("0" & Request("TipoEntidade"))
            respostas1.IDReferencia = CInt("0" & Request("IDReferencia"))
        End If
    End Sub
End Class
