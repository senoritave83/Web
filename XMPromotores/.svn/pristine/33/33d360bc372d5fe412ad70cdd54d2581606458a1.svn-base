Imports Classes
Imports System.Web.Services

Partial Class formulario_addpesquisa
    Inherits XMWebPage
    Protected cls As clsFormVisita

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsFormVisita
        If Not Page.IsPostBack Then
            ViewState("IDVISITA") = CInt("0" & Request("IDVisita"))
            ViewState("IDPRODUTO") = CInt("0" & Request("idproduto"))
            ViewState("IDCATEGORIA") = CInt("0" & Request("cat"))
            ViewState("IDFORNECEDOR") = CInt("0" & Request("for"))
            ViewState("IDPESQUISA") = CInt("0" & Request("idpesquisa"))

            Dim pes As New clsPesquisa
            pes.Load(ViewState("IDPESQUISA"))
            ltrTitulo.Text = pes.Pesquisa
        End If
        cls.Load(ViewState("IDVISITA"))

        If Not Page.IsPostBack Then
            respostas1.IDVisita = cls.IDVisita
            respostas1.TipoEntidade = 11
            respostas1.IDReferencia = 0
            respostas1.IDPesquisa = ViewState("IDPESQUISA")
        End If
    End Sub

    <WebMethod()> _
    Public Shared Sub ApagarXMLEntidadeItem(ByVal vIdentifier As String, ByVal vTipoEntidade As Byte, ByVal vIDReferencia As Integer)
        controls_respostas.ApagarXMLEntidadeItem(vIdentifier, vTipoEntidade, vIDReferencia)
    End Sub



    <WebMethod()> _
    Public Shared Sub GravarXMLEntidadeItem(ByVal vIdentifier As String, ByVal vTipoEntidade As Byte, ByVal vIDReferencia As Integer, ByVal vXML As String)
        controls_respostas.GravarXMLEntidadeItem(vIdentifier, vTipoEntidade, vIDReferencia, vXML)
    End Sub

End Class
