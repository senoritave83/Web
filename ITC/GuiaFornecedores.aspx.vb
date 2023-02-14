Public Class GuiaFornecedores

    Inherits System.Web.UI.Page
    Protected WithEvents dtlLetras As System.Web.UI.WebControls.DataList
    Protected WithEvents dtlProdutos As System.Web.UI.WebControls.DataList
    Protected xmWeb As XMWebPage

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

        xmWeb = New XMWebPage

        If Not Page.IsPostBack Then

            Dim letters(26) As String
            letters(0) = "A"
            letters(1) = "B"
            letters(2) = "C"
            letters(3) = "D"
            letters(4) = "E"
            letters(5) = "F"
            letters(6) = "G"
            letters(7) = "H"
            letters(8) = "I"
            letters(9) = "J"
            letters(10) = "K"
            letters(11) = "L"
            letters(12) = "M"
            letters(13) = "N"
            letters(14) = "O"
            letters(15) = "P"
            letters(16) = "Q"
            letters(17) = "R"
            letters(18) = "S"
            letters(19) = "T"
            letters(20) = "U"
            letters(21) = "V"
            letters(22) = "W"
            letters(23) = "X"
            letters(24) = "Y"
            letters(25) = "Z"

            Dim i As Integer = 0
            Dim dt As New DataTable
            Dim dr As DataRow

            dt.Columns.Add(New DataColumn("Letter"))
            For i = 0 To 25
                dr = dt.NewRow()
                dr(0) = letters(i)
                dt.Rows.Add(dr)
            Next

            dtlLetras.DataSource = dt
            dtlLetras.DataBind()

        End If

        Dim Letra As String = Page.Request("letra") & ""
        If Letra.Trim <> "" Then
            Dim pro As clsProdutos
            pro = New clsProdutos
            dtlProdutos.DataSource = pro.ListProdutosGuia(Letra)
            dtlProdutos.DataBind()
            pro = Nothing
        End If

    End Sub


End Class
