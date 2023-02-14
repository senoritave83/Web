
Partial Class configuracoes_respostas
    Inherits XMProtectedPage

    Protected cls As clsResposta
    Protected _dsEtapas As DataSet

    Public ReadOnly Property GetEtapas() As DataSet
        Get
            If _dsEtapas Is Nothing Then
                Dim etp As New clsEtapa
                _dsEtapas = etp.ListarDisponiveis(DataClass.enReturnType.DataSet)
            End If
            Return _dsEtapas
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cls = New clsResposta()
        cls.Load(CInt("0" & Request("IDSuperior")))

        If Not IsPostBack Then

            If Not IsAdmin() Then Response.Redirect("../Default.aspx")

            ClientScript.RegisterHiddenField("__EVENTTARGET", "btnSalvar")

            BindGrid()
        End If



    End Sub

    Public Sub BindGrid()

        rptRespostas.DataSource = cls.Listar()
        rptRespostas.DataBind()

    End Sub

    Private Sub btnSalvar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSalvar.Click

        If CheckPermission("Cadastro de Respostas", "Gravar Resposta") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If

        Dim intPos As Integer = 1
        For Each item As RepeaterItem In rptRespostas.Items
            If item.ItemType = ListItemType.AlternatingItem Or item.ItemType = ListItemType.Item Then
                Dim txtResposta As TextBox = item.FindControl("txtResposta_1")
                Dim clrResposta As controls.xmcolor = item.FindControl("Xmcolor1")
                Dim chkFinaliza As HtmlInputCheckBox = item.FindControl("chkFinaliza1")
                Dim cboEtapa As DropDownList = item.FindControl("cboEtapa1")

                cls.Gravar(intPos, txtResposta.Text, clrResposta.Color, chkFinaliza.Checked, cboEtapa.SelectedValue)
                intPos += 1
            End If
        Next


        MostraGravado("respostas.aspx?idsuperior=" & cls.IDResposta)

    End Sub

    Public Sub Button_Apagar(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)

        If CheckPermission("Cadastro de Respostas", "Excluir Resposta") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If

        If e.CommandName = "Apagar" Then
            cls.DeleteSubDeck(e.CommandArgument)
        End If
        MostraGravado("respostas.aspx?idsuperior=" & cls.IDResposta)
    End Sub

    Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnApagar.Click

        If CheckPermission("Cadastro de Respostas", "Excluir Resposta") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If

        cls.Delete(Request("chkSelected") & "")
        BindGrid()
    End Sub

    Private Sub btnVoltar_ServerClick(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        If cls.IDResposta > 0 Then
            Response.Redirect("respostas.aspx?idsuperior=" & cls.IDSuperior)
        Else
            Response.Redirect("default2.aspx")
        End If
    End Sub


    Protected Sub rptRespostas_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptRespostas.ItemDataBound
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim lnk As HyperLink = e.Item.FindControl("HyperLink1")
            lnk.NavigateUrl = "respostas.aspx?idsuperior=" & e.Item.DataItem("res_Resposta_int_PK")
            lnk.ImageUrl = IIf(e.Item.DataItem("res_SubFolder_ind") = 1, "../images/subfolder.gif", "../images/subnfolder.gif")

            lnk = e.Item.FindControl("lnkObs1")
            lnk.NavigateUrl = "respostadet.aspx?idresposta=" & e.Item.DataItem("res_Resposta_int_PK")
            lnk.Text = e.Item.DataItem("Observacao")

            Dim ltr As Literal = e.Item.FindControl("Literal1")
            ltr.Text = "<input type='checkbox' value='" & CInt("0" & e.Item.DataItem("res_Resposta_int_PK")) & "' name='chkSelected' width='10'>"

            Dim btn As ImageButton = e.Item.FindControl("btnApagarDeck1")
            btn.Attributes.Add("onclick", "return fncApagarDeck();")
            btn.CommandArgument = CInt("0" & e.Item.DataItem("res_Resposta_int_PK"))

            Dim cboEtapa As DropDownList = e.Item.FindControl("cboEtapa1")
            cboEtapa.DataSource = GetEtapas
            cboEtapa.DataBind()
            cboEtapa.Items.Insert(0, New ListItem("sem etapa", "0"))
            setComboValue(cboEtapa, e.Item.DataItem("IDEtapa"))

        End If
    End Sub
End Class
