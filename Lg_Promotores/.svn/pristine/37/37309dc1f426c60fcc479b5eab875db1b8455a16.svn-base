Imports Classes

Namespace Pages.Cadastros.roteiros

    Partial Public Class ListaRoteiros
        Inherits XMWebPage
        Dim cls As clsPromotor

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPromotor()
            If Not Page.IsPostBack Then

                'Bind Combos
                Dim uf As New clsEstado
                cboUF.DataSource = uf.Listar
                cboUF.DataBind()
                cboUF.Items.Insert(0, New ListItem("TODOS", ""))
                uf = Nothing

                Dim crd As New clsCoordenador
                cboIDCoordenador.DataSource = crd.Listar
                cboIDCoordenador.DataBind()
                cboIDCoordenador.Items.Insert(0, New ListItem("TODOS", 0))
                crd = Nothing

                If Me.User.IdCoordenador > 0 Then
                    setComboValue(cboIDCoordenador, Me.User.IdCoordenador)
                    cboIDCoordenador.Enabled = False
                End If

                Dim lid As New clsLider
                cboIDLider.DataSource = IIf(Me.User.IdCoordenador > 0, lid.Listar(Me.User.IdCoordenador), lid.Listar)
                cboIDLider.DataBind()
                cboIDLider.Items.Insert(0, New ListItem("TODOS", 0))
                If Me.User.IdLider > 0 Then
                    lid.Load(Me.User.IdLider)
                    setComboValue(cboIDCoordenador, lid.IDCoordenador)
                    cboIDCoordenador.Enabled = False
                    setComboValue(cboIDLider, Me.User.IdLider)
                    cboIDLider.Enabled = False
                End If
                lid = Nothing

                Dim reg As New clsRegiao
                cboIDRegiao.DataSource = reg.Listar
                cboIDRegiao.DataBind()
                cboIDRegiao.Items.Insert(0, New ListItem("TODOS", 0))
                reg = Nothing

                If Me.User.IdLider > 0 Then
                    Me.RecuperaFiltro(txtFiltro, Paginate1, Letras1, cboUF, cboTeste, cboIDRegiao, cboIdStatus)
                ElseIf Me.User.IdCoordenador > 0 Then
                    Me.RecuperaFiltro(txtFiltro, Paginate1, Letras1, cboUF, cboTeste, cboIDLider, cboIDRegiao, cboIdStatus)
                Else
                    Me.RecuperaFiltro(txtFiltro, Paginate1, Letras1, cboUF, cboTeste, cboIDLider, cboIDRegiao, cboIDCoordenador, cboIdStatus)
                End If

                BindGrid()

            End If
        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, cboUF.SelectedValue, cboTeste.SelectedValue, cboIDLider.SelectedValue, cboIDRegiao.SelectedValue, cboIDCoordenador.SelectedValue, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, PAGESIZE, cboIdStatus.SelectedValue, DataClass.enReturnType.DataReader)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(txtFiltro, Paginate1, Letras1, cboUF, cboTeste, cboIDLider, cboIDRegiao, cboIDCoordenador, cboIdStatus)
        End Sub


        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub

        Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
            Paginate1.CurrentPage = 0
            Letras1.Letra = ""
            Paginate1.Filtro = txtFiltro.Text
            BindGrid()
        End Sub

        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
            BindGrid()
        End Sub


        Protected Sub Letras1_Item_Selected(ByVal vLetra As String) Handles Letras1.Item_Selected
            Paginate1.CurrentPage = 0
            Paginate1.Filtro = vLetra
            txtFiltro.Text = ""
            BindGrid()
        End Sub

        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            Paginate1.CurrentPage = 0
            BindGrid()
        End Sub

        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
            Paginate1.SortExpression = e.SortExpression
        End Sub

        Protected Sub cboIDCoordenador_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDCoordenador.SelectedIndexChanged
            Dim lid As New clsLider
            cboIDLider.DataSource = lid.Listar(CInt(cboIDCoordenador.SelectedValue))
            cboIDLider.DataBind()
            cboIDLider.Items.Insert(0, New ListItem("TODOS", 0))
            lid = Nothing
        End Sub

    End Class

End Namespace