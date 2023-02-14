
Imports Classes

Namespace Pages.Sistema

    Partial Public Class Recados
        Inherits XMWebPage

        Dim cls As clsRecado

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            cls = New clsRecado()

            If Not Page.IsPostBack Then

                'Bind Combos
                Dim usu As New clsUsuario
                With cboIDusuario
                    .DataSource = usu.Listar
                    .DataBind()
                    .Items.Insert(0, New ListItem("TODOS", 0))
                    usu = Nothing
                End With

                Dim crd As New clsCoordenador
                With lstCoordenador
                    .DataSource = crd.Listar
                    .DataBind()
                End With
                crd = Nothing

                lstLider.Items.Add(New ListItem("Todos", "0"))
                lstPromotor.Items.Add(New ListItem("Todos", "0"))

                Me.RecuperaFiltro(txtFiltro, Paginate1, Letras1, cboIDusuario)
                BindGrid()

            End If

        End Sub

        Public Sub BindGrid()

            Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, cboIDusuario.SelectedValue, txtDataEnvio.Text, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(txtFiltro, Letras1, Paginate1, cboIDusuario)

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

        Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnviar.Click

            Dim strErrosEnvio As String = ""
            Dim intEnvio As Integer = 0
            Dim intNaoEnvio As Integer = 0
            lblErro.Visible = False
            lblSucesso.Visible = False
            lblSucesso.Text = ""
            lblErro.Text = ""

            Try

                If txtMensagem.Text <> "" Then

                    For Each lst As ListItem In LstPromotor.Items
                        If lst.Selected Or LstPromotor.GetSelectedIndices.Length = 0 Then
                            Dim strTel As String = lst.Value
                            Dim intSeparador As Integer = strTel.IndexOf("_") + 1
                            If intSeparador < strTel.Length Then
                                strTel = strTel.Substring(intSeparador, Len(strTel) - intSeparador)
                                strTel = ValidaCelular(strTel)
                                If strTel <> "" And txtMensagem.Text <> "" Then
                                    If cls.Enviar(strTel, txtMensagem.Text) Then
                                        intEnvio += 1
                                        lblSucesso.Text &= lst.Text & "<br>"
                                    Else
                                        lblErro.Text &= lst.Text & "<br>"
                                        intNaoEnvio += 1
                                    End If
                                Else
                                    lblErro.Text &= lst.Text & "<br>"
                                    intNaoEnvio += 1
                                End If
                            Else
                                lblErro.Text &= lst.Text & "<br>"
                                intNaoEnvio += 1
                            End If
                        End If
                    Next

                    If intNaoEnvio > 0 Then
                        lblErro.Text = "Mensagens não enviadas:<BR>" & lblErro.Text
                        lblErro.ForeColor = Drawing.Color.Red
                        lblErro.Visible = True
                    End If
                    If intEnvio > 0 Then
                        lblSucesso.Text = "Mensagens enviadas:<BR>" & lblSucesso.Text
                        lblSucesso.ForeColor = Drawing.Color.Green
                        lblSucesso.Visible = True
                    End If

                    pnlMensagem.Visible = False
                    pnlResult.Visible = True
                    btnOk.Visible = True
                    btnEnviar.Visible = False
                    btnLimpar.Visible = False
                    GridView1.Visible = False
                    Paginate1.Visible = False

                End If

            Catch ex As Exception

                lblErro.Text = "ERRO AO TENTAR ENVIAR AS MENSAGENS SELECIONADAS:<BR>" & ex.Message
                lblErro.ForeColor = Drawing.Color.Red
                lblErro.Visible = True

                pnlMensagem.Visible = False
                pnlResult.Visible = True
                btnOk.Visible = True
                btnEnviar.Visible = False
                btnLimpar.Visible = False
                GridView1.Visible = False
                Paginate1.Visible = False

            End Try

        End Sub

        Protected Sub btnLimpar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
            txtMensagem.Text = ""
            lblErro.Visible = False
            lblSucesso.Visible = False
        End Sub

        Protected Sub btlVerLideres_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btlVerLideres.Click
            Dim lid As New clsLider
            With lstLider
                .Items.Clear()
                .DataSource = lid.Listar(getComboValues(lstCoordenador))
                .DataBind()
            End With
            lid = Nothing
        End Sub


        Protected Sub btnVerPromotor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerPromotor.Click
            Dim pro As New clsPromotor
            With lstPromotor
                .Items.Clear()
                .DataSource = pro.ListarPromotor_Recado(getComboValues(lstLider))
                .DataBind()
            End With
            pro = Nothing
        End Sub

        Private Function ValidaCelular(ByVal vTel As String) As String

            Dim p_Carac As String = "0123456789"
            Dim p_Phones As String = "", p_PhonesNew As String = ""
            Dim i As Integer = 0
            p_Phones = vTel

            For i = 0 To p_Phones.Length - 1
                If (p_Carac.IndexOf(p_Phones.Substring(i, 1)) >= 0) Then
                    p_PhonesNew &= p_Phones.Substring(i, 1)
                End If
            Next
            If p_PhonesNew.Length <> 10 Then
                p_PhonesNew = ""
            End If

            Return p_PhonesNew

        End Function

        Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

            lstCoordenador.SelectedIndex = 0
            lstLider.Items.Clear()
            lstLider.Items.Add(New ListItem("Todos", "0"))
            LstPromotor.Items.Clear()
            LstPromotor.Items.Add(New ListItem("Todos", "0"))
            txtMensagem.Text = ""

            pnlMensagem.Visible = True
            pnlResult.Visible = False
            btnOk.Visible = False
            btnEnviar.Visible = True
            btnLimpar.Visible = True

            GridView1.Visible = True
            Paginate1.Visible = True

            BindGrid()

        End Sub
    End Class

End Namespace

