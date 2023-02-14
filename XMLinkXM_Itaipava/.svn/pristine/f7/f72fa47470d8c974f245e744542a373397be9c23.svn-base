
Imports Classes

Namespace Pages.Sistema

    Partial Public Class Integracao
        Inherits XMWebPage

        Dim cls As clsIntegracao

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsIntegracao()
            If Not Page.IsPostBack Then

                'Bind Combos
                Dim vIDEmpresa As Integer = Me.User.IDEmpresa
                If Me.User.IDEmpresa = 0 Then
                    If VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
                        Dim cls As New Classes.clsEmpresa
                        cboEmpresa.DataSource = cls.ListarAutorizadas()
                        cboEmpresa.DataBind()
                        cboEmpresa.Items.Insert(0, New ListItem("TODAS", 0))
                        setComboValue(cboEmpresa, Me.User.IDEmpresa)
                    Else
                        cboEmpresa.Items.Clear()
                        cboEmpresa.Items.Add(New ListItem(Me.User.Chave.Replace(".", "") & " - " & Me.User.Empresa, Me.User.IDEmpresa))
                    End If
                Else
                    cboEmpresa.Items.Clear()
                    cboEmpresa.Items.Add(New ListItem(Me.User.Chave.Replace(".", "") & " - " & Me.User.Empresa, Me.User.IDEmpresa))
                End If
                'cboEmpresa.DataSource = cls.ListarEmpresas()
                'cboEmpresa.DataBind()
                'cboEmpresa.Items.Insert(0, New ListItem("TODAS", 0))
                'setComboValue(cboEmpresa, User.IDEmpresa)

                txtDataInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
                txtDataFinal.Text = Now.ToString("dd/MM/yyyy")

                Me.RecuperaFiltro(cboEmpresa, chkComErro, txtDataInicial, txtDataFinal, Paginate1)
                BindGrid()
            End If
        End Sub

        Public Sub BindGrid()
            Dim ret As IPaginaResult = cls.Listar(cboEmpresa.SelectedItem.Value, chkComErro.Checked, txtDataInicial.Text, txtDataFinal.Text, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(cboEmpresa, chkComErro, txtDataInicial, txtDataFinal, Paginate1)
        End Sub

        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub


        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
            BindGrid()
        End Sub



        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            Paginate1.CurrentPage = 0
            BindGrid()
        End Sub

        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
            Paginate1.SortExpression = e.SortExpression
        End Sub

    End Class

End Namespace

