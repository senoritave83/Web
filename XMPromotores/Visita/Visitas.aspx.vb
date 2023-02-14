
Imports Classes
Imports System.Data.SqlClient

Namespace Pages.Visita

    Partial Public Class Visitas
        Inherits XMWebPage
        Dim cls As clsVisita
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVisita()
            If Not Page.IsPostBack Then
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)

                Dim tjf As New clsTipoJustificativa
                cboIDTipoJustificativa.DataSource = tjf.Listar
                cboIDTipoJustificativa.DataBind()
                cboIDTipoJustificativa.Items.Insert(0, New ListItem("SEM JUSTIFICATIVA", 0))
                cboIDTipoJustificativa.Items.Insert(0, New ListItem("TODOS", -1))
                tjf = Nothing

                txtDataFinal.Text = FormatDateTime(Now, 2)
                txtDataInicial.Text = FormatDateTime(Now.AddDays(-10), 2)

                Me.RecuperaFiltro(txtFiltro, Paginate1, cboIDTipoJustificativa, txtDataFinal, txtDataInicial, cboTeste, cboStatus)

                BindCargos()
                setComboValue(drpCargoSuperior, 1)
                Me.RecuperaFiltro(drpCargoSuperior)

                BindUsuariosCargo(lstSuperior, drpCargoSuperior.SelectedItem.Value)
                Me.RecuperaFiltro(lstSuperior)

                setComboValue(drpTipoSelecao, 1)
                Me.RecuperaFiltro(drpTipoSelecao)

                BindGrid()

            End If
        End Sub


        Public Sub BindGrid()

            Dim strUsuarios As String = getComboValues(lstSuperior)
            If strUsuarios = "" Then
                For Each lst As ListItem In lstSuperior.Items
                    lst.Selected = True
                Next
                strUsuarios = getComboValues(lstSuperior)
            End If
            Dim vTipoSelecao As Integer = getComboValue(drpTipoSelecao)

            Dim ret As IPaginaResult = cls.Listar(ViewState("Filtro"), strUsuarios, vTipoSelecao, txtDataInicial.Text, txtDataFinal.Text, _
                                                  cboIDTipoJustificativa.SelectedValue, cboTeste.SelectedValue, _
                                                  SortExpression, SortDirection, Paginate1.CurrentPage, PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            gravarfiltro()

        End Sub

        Private Sub gravarfiltro()
            Me.GravaFiltro(txtFiltro, Paginate1, drpCargoSuperior, lstSuperior, drpTipoSelecao, cboIDTipoJustificativa, txtDataFinal, txtDataInicial, cboTeste, cboStatus)
        End Sub

        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub

        Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
            Paginate1.CurrentPage = 0
            ViewState("Filtro") = txtFiltro.Text
            BindGrid()
        End Sub

        Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand

            If e.CommandName = "Delete" Then

                Dim p_IdVisita As Integer = Convert.ToInt32(e.CommandArgument)
                Try

                    cls = New clsVisita()
                    cls.Delete_To_Temp(p_IdVisita)
                    BindGrid()

                Catch ex As Exception

                    Throw New Exception(ex.Message)

                Finally

                    cls = Nothing

                End Try

            End If

        End Sub

        Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        End Sub

        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
            BindGrid()
        End Sub


        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            Paginate1.CurrentPage = 0
            ViewState("Filtro") = txtFiltro.Text
            BindGrid()
        End Sub

        Protected Sub imgDeleteButton(ByVal sender As Object, ByVal e As EventArgs)

            Dim btnDelVisita As ImageButton = sender
            Dim rowIndex As Integer = Convert.ToInt32(btnDelVisita.Attributes("RowIndex"))

        End Sub


        'Private Sub carregaPromotores()
        '    Dim pro As New clsUsuario
        '    cboIDPromotor.DataSource = pro.Listar(FiltroSuperior1.IDSuperior, DataClass.enReturnType.DataReader)
        '    cboIDPromotor.DataBind()
        '    cboIDPromotor.Items.Insert(0, New ListItem("TODOS", 0))
        '    pro = Nothing
        'End Sub

        Protected Sub drpCargoSuperior_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpCargoSuperior.SelectedIndexChanged

            Dim vIdCargo As Integer = getComboValue(drpCargoSuperior)

            BindUsuariosCargo(lstSuperior, vIdCargo)

        End Sub

        Protected Sub BindCargos()
            Dim car As New clsCargo
            Dim ds As SqlDataReader = car.Listar()
            While ds.Read
                If ds("IDCargo") = 1 Or ds("IDCargo") = 2 Or ds("IDCargo") = 3 Then
                    Dim lst As New ListItem(ds("Cargo"), ds("IdCargo"))
                    If lst.Value = 3 Then lst.Selected = True
                    drpCargoSuperior.Items.Add(lst)
                End If
            End While
            drpCargoSuperior.Items.Insert(0, New ListItem("Todos", "0"))
            car = Nothing
        End Sub

        Protected Sub BindUsuarios(ByVal cbo As Object, ByVal vIDCargo As Integer, ByVal vSuperiores As String)

            cbo.items.clear()
            If vIDCargo > 0 And vSuperiores <> "0" And vSuperiores <> "" Then
                Dim usu As New clsUsuario
                cbo.DataSource = usu.ListarUsuariosProximoNivel(vIDCargo, vSuperiores)
                cbo.DataBind()
            End If
            cbo.Items.Insert(0, New ListItem("Todos", "0"))

        End Sub

        Protected Sub BindUsuariosCargo(ByVal cbo As Object, ByVal vIDCargo As Integer)
            Dim usu As New clsUsuario
            cbo.items.clear()
            If vIDCargo > 0 Then
                cbo.DataSource = usu.Listar(vIDCargo, 0, 0, cboStatus.SelectedValue, DataClass.enReturnType.DataReader)
                cbo.DataBind()
            End If
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

        Protected Sub cboStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStatus.SelectedIndexChanged
            BindUsuariosCargo(lstSuperior, getComboValue(drpCargoSuperior))
        End Sub
    End Class

End Namespace

