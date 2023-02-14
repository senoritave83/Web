
Imports Classes
Imports System.Data.SqlClient
Imports XMSistemas.Web.XMGMapControl

Namespace Pages.Visita

    Partial Public Class Visitas
        Inherits XMWebPage
        Dim cls As clsVisita
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVisita()
            If Not Page.IsPostBack Then
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)

                'Bind Combos

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
                cboIdLider.DataSource = IIf(Me.User.IdCoordenador > 0, lid.Listar(Me.User.IdCoordenador), lid.Listar)
                cboIdLider.DataBind()
                cboIdLider.Items.Insert(0, New ListItem("TODOS", 0))
                If Me.User.IdLider > 0 Then
                    setComboValue(cboIDCoordenador, lid.IDCoordenador)
                    cboIDCoordenador.Enabled = False
                    setComboValue(cboIdLider, Me.User.IdLider)
                    cboIdLider.Enabled = False
                End If
                lid = Nothing

                carregaPromotores()

                Dim tjf As New clsTipoJustificativa
                cboIDTipoJustificativa.DataSource = tjf.Listar
                cboIDTipoJustificativa.DataBind()
                cboIDTipoJustificativa.Items.Insert(0, New ListItem("SEM JUSTIFICATIVA", 0))
                cboIDTipoJustificativa.Items.Insert(0, New ListItem("TODOS", -1))
                tjf = Nothing

                txtDataFinal.Text = FormatDateTime(Now, 2)
                txtDataInicial.Text = FormatDateTime(Now.AddDays(-10), 2)

                RecuperaFiltro(txtFiltro, Paginate1, cboIDCoordenador, cboIdLider, cboIDPromotor, cboIDTipoJustificativa, txtDataFinal, txtDataInicial, cboTeste, cboMapa, drpPrecisao)

                BindGrid()

            End If			
        End Sub


        Public Sub BindGrid()


            Dim ret As IPaginaResult = cls.Listar(ViewState("Filtro"), cboIDCoordenador.SelectedValue, cboIdLider.SelectedValue, cboIDPromotor.SelectedValue, txtDataInicial.Text, txtDataFinal.Text, _
                                                  cboIDTipoJustificativa.SelectedValue, cboTeste.SelectedValue, cboMapa.SelectedValue, drpPrecisao.SelectedItem.Value, _
                                                  SortExpression, SortDirection, Paginate1.CurrentPage, PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            gravarfiltro()

        End Sub

        Private Sub gravarfiltro()
            If Me.User.IdLider > 0 Then
                Me.GravaFiltro(txtFiltro, Paginate1, cboIDPromotor, cboIDTipoJustificativa, txtDataFinal, txtDataInicial, cboTeste, cboMapa, drpPrecisao)
            ElseIf Me.User.IdCoordenador > 0 Then
                Me.RecuperaFiltro(txtFiltro, Paginate1, cboIdLider, cboIDPromotor, cboIDTipoJustificativa, txtDataFinal, txtDataInicial, cboTeste, cboMapa, drpPrecisao)
            Else
                Me.GravaFiltro(txtFiltro, Paginate1, cboIDCoordenador, cboIdLider, cboIDPromotor, cboIDTipoJustificativa, txtDataFinal, txtDataInicial, cboTeste, cboMapa, drpPrecisao)
            End If
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


        Private Sub carregaPromotores()

            cboIDPromotor.Items.Clear()

            Dim p_Coordenadores As String = getComboValues(cboIDCoordenador)
            Dim p_Lideres As String = getComboValues(cboIdLider)

            Dim pro As New clsPromotor
            cboIDPromotor.DataSource = pro.Listar(p_Lideres, p_Coordenadores, DataClass.enReturnType.DataReader)
            cboIDPromotor.DataBind()
            cboIDPromotor.Items.Insert(0, New ListItem("TODOS", 0))
            pro = Nothing

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

        Protected Sub cboIDCoordenador_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDCoordenador.SelectedIndexChanged

            cboIdLider.Items.Clear()

            Dim p_Coordenadores As String = getComboValues(cboIDCoordenador)

            Dim clsLid As clsLider
            clsLid = New clsLider
            cboIdLider.Items.Insert(0, New ListItem("TODOS", 0))
            Dim dr As SqlDataReader = clsLid.Listar(p_Coordenadores, DataClass.enReturnType.DataReader)
            Do While dr.Read
                cboIdLider.Items.Add(New ListItem(dr("Lider") & "", dr("IdLider")))
            Loop
            clsLid = Nothing

            carregaPromotores()

        End Sub

        Protected Sub cboIdLider_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdLider.SelectedIndexChanged

            carregaPromotores()

        End Sub

    End Class

End Namespace

