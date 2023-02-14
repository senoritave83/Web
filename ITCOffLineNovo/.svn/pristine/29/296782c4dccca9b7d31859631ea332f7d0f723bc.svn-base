Imports ITCOffLine
Imports System.Data

Public Class ProdutosAssociados

    Inherits XMWebPage
    Protected WithEvents chkProdutos As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Private ProdAss As clsProdutosAssociado
    Protected WithEvents Barra As BarraBotoes2
    Protected WithEvents Barra1 As BarraBotoes2

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            ViewState("IdAssociado") = DeCryptography(Page.Request("IdAssociado"))
            If Not IsNumeric(ViewState("IdAssociado")) Then ViewState("IdAssociado") = 0
            ProdAss = New clsProdutosAssociado
            BindGrid()
            Barra.AtivarBotoes(BarraBotoes2.Botoes_Ativos.Atualizar + BarraBotoes2.Botoes_Ativos.Voltar)
            Barra1.AtivarBotoes(BarraBotoes2.Botoes_Ativos.Atualizar + BarraBotoes2.Botoes_Ativos.Voltar)
        End If
    End Sub

    Private Sub BindGrid()
        chkProdutos.Items.Clear()
        Dim ds As DataSet = ProdAss.ListProdutosAssociado(ViewState("IdAssociado"))
        With ds.Tables
            If .Count > 0 Then
                If .Item(0).Rows.Count > 0 Then
                    Dim i As Integer
                    Dim lst As ListItem
                    For i = 0 To .Item(0).Rows.Count - 1
                        lst = New ListItem()
                        lst.Text = .Item(0).Rows(i).Item("DESCRICAOPRODUTO")
                        lst.Value = .Item(0).Rows(i).Item("IDPRODUTO")
                        lst.Selected = (.Item(0).Rows(i).Item("IDASSOCIADO") > 0)
                        chkProdutos.Items.Add(lst)
                    Next
                End If
            End If
        End With
    End Sub

    Private Sub BarraAtualizar()

        ProdAss = New clsProdutosAssociado()
        ProdAss.IdAssociado = ViewState("IdAssociado")

        Dim strItens As String
        Dim i As Integer
        strItens = ""

        For i = 0 To chkProdutos.Items.Count - 1
            If chkProdutos.Items(i).Selected Then
                If strItens.Length > 0 Then
                    strItens &= ", "
                End If
                strItens &= chkProdutos.Items(i).Value
            End If
        Next
        ProdAss.Itens = strItens
        ProdAss.Update()
        BindGrid()
        ProdAss = Nothing

        Gravado("produtosassociados.aspx?idassociado=" & CryptographyEncoded(ViewState("IdAssociado")))

    End Sub

    Private Sub Barra_Atualizar() Handles Barra.Gravar
        BarraAtualizar()
    End Sub

    Private Sub Barra1_Atualizar() Handles Barra1.Gravar
        BarraAtualizar()
    End Sub

    Private Sub Barra_Voltar() Handles Barra.Voltar
        Response.Redirect("associadosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IdAssociado")))
    End Sub

    Private Sub Barra1_Voltar() Handles Barra1.Voltar
        Response.Redirect("associadosdet.aspx?codigo=" & CryptographyEncoded(ViewState("IdAssociado")))
    End Sub

End Class
