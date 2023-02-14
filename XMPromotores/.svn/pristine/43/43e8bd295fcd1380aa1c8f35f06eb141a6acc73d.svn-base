
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class LOGs
        Inherits XMWebPage
        Dim cls As clsLOG
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsLOG()
            If Not Page.IsPostBack Then
                'btnNovo.Disabled = Not Me.User.IsInRole("Cadastrador")

                'Bind Combos
                Dim modulo As New clsLOG
                Dim dr As System.Data.SqlClient.SqlDataReader
                dr = modulo.Listar
                Do While dr.Read
                    If VerificaPermissao(Secao, dr("modulo")) = True Then
                        cboModulo.Items.Add(New ListItem(dr("modulo")))
                    End If
                Loop
                cboModulo.Items.Insert(0, New ListItem("Selecione um módulo", "0"))

                modulo = Nothing


                'Dim modulo As New clsLOG
                'cboModulo.DataSource = modulo.Listar
                'cboModulo.DataBind()
                'cboModulo.Items.Insert(0, New ListItem("Selecione um módulo", "0"))
                'modulo = Nothing


                Me.RecuperaFiltro(cboModulo, txtUsuario, txtDataInicial, txtDataFinal, Paginate1)

            End If
        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult = cls.Listar(cboModulo.SelectedItem.Value, txtUsuario.Text, txtDataInicial.Text, txtDataFinal.Text, SortExpression, SortDirection, Paginate1.CurrentPage, PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(cboModulo, txtUsuario, txtDataInicial, txtDataFinal, Paginate1)
			
		End Sub
		
        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub

        'Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtModulo.TextChanged
        '    Paginate1.CurrentPage = 0
        '    Letras1.Letra = ""
        '    ViewState("Filtro") = txtModulo.Text
        '    BindGrid()
        'End Sub

        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
            BindGrid()
        End Sub
		

        'Protected Sub Letras1_Item_Selected(ByVal vLetra As String) Handles Letras1.Item_Selected
        '    Paginate1.CurrentPage = 0
        '    ViewState("Filtro") = vLetra
        '    txtModulo.Text = ""
        '    BindGrid()
        'End Sub

        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            Paginate1.CurrentPage = 0
            BindGrid()
        End Sub		

#Region "Sorting"


        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
            If SortExpression = e.SortExpression Then
                If SortDirection = WebControls.SortDirection.Ascending Then
                    SortDirection = WebControls.SortDirection.Descending
                Else
                    SortDirection = WebControls.SortDirection.Ascending
                End If
            Else
                SortExpression = e.SortExpression
                SortDirection = WebControls.SortDirection.Ascending
            End If
        End Sub

        Protected Property SortExpression() As String
            Get
                If ViewState("SortExpression") Is Nothing Then
                    Return ""
                Else
                    Return ViewState("SortExpression")
                End If
            End Get
            Set(ByVal value As String)
                ViewState("SortExpression") = value
            End Set
        End Property

        Protected Property SortDirection() As SortDirection
            Get
                If ViewState("SortDirection") Is Nothing Then
                    Return WebControls.SortDirection.Ascending
                Else
                    Return ViewState("SortDirection")
                End If
            End Get
            Set(ByVal value As SortDirection)
                ViewState("SortDirection") = value
            End Set
        End Property

#End Region

    End Class

End Namespace

