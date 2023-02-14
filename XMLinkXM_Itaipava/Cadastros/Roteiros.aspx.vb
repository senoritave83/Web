
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Roteiros
        Inherits XMWebPage

		Protected Const SECAO as String = "Cadastro de Roteiro"
		Dim cls As clsRoteiro
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsRoteiro()
            If Not Page.IsPostBack Then
    
                txtDataInicial.Text = Now.ToString("dd/MM/yyyy")
                txtDataFinal.Text = Now.ToString("dd/MM/yyyy")

                Dim clsVen As New clsVendedor()
                drpIdVendedor.DataSource = clsVen.Listar()
                drpIdVendedor.DataBind()
                clsVen = Nothing

                drpIdVendedor.Items.Insert(0, New ListItem("Todos", "0"))

                Me.RecuperaFiltro(Paginate1, txtDataInicial, txtDataFinal)
                BindGrid()

                Dim clsConfig As New clsConfiguracoes()
                clsConfig.Load(Me.User.IDEmpresa)

                chkDias.Visible = clsConfig.RevendaPermiteAcumuloRoteiros
                rdpDias.Visible = Not clsConfig.RevendaPermiteAcumuloRoteiros

                clsConfig = Nothing

            End If
        End Sub

        Public Sub BindGrid()

            Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, txtDataInicial.Text, txtDataFinal.Text, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()

            GridView1.Columns(3).Visible = VerificaPermissao(SECAO, "Excluir")

            Paginate1.DataSource = ret
            Paginate1.DataBind()

            ret = Nothing

            Me.GravaFiltro(Paginate1, txtDataInicial, txtDataFinal)
        End Sub
		
        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub

        Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
            If e.CommandName = "Editar" Then
                Dim vSelectItem As Object = GridView1.DataKeys(e.CommandArgument).Values
                Dim vData As String = vSelectItem(0)
                Dim vIdVendedor As String = vSelectItem(1)
                cls.Load(GridView1.DataKeys(e.CommandArgument).Value, vIdVendedor)
                If chkDias.Visible = True Then
                    _setCheckValue(chkDias, cls.Dia)
                Else
                    _setCheckValue(rdpDias, cls.Dia)
                End If

                txtData.Text = cls.Data
                setComboValue(drpIdVendedor, cls.IDVendedor)
            ElseIf e.CommandName = "Excluir" Then
                cls.Delete(e.CommandArgument)
                BindGrid()
            End If
        End Sub

        Public Sub _setCheckValue(ByVal vCombo As Object, ByVal p_Value As String)
            vCombo.ClearSelection()
            For Each it As ListItem In vCombo.items
                If p_Value And it.Value Then
                    it.Selected = True
                End If
            Next
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

        Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If IsDate(txtData.Text) Then
                cls.Load(txtData.Text, drpIdVendedor.SelectedItem.Value)
                Dim intDias As Byte = 0
                If chkDias.Visible = True Then
                    For Each lstItem As ListItem In chkDias.Items
                        If lstItem.Selected Then
                            intDias = intDias + lstItem.Value
                        End If
                    Next
                Else
                    For Each lstItem As ListItem In rdpDias.Items
                        If lstItem.Selected Then
                            intDias = intDias + lstItem.Value
                        End If
                    Next
                End If
                cls.Dia = intDias
                cls.IDVendedor = getComboValues(drpIdVendedor)
                cls.Update()

                txtData.Text = ""
                chkDias.SelectedIndex = -1
                drpIdVendedor.ClearSelection()

                BindGrid()

            End If
        End Sub
    End Class

End Namespace

