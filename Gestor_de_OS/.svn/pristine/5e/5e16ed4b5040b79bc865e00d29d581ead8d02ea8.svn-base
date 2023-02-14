Imports System.Data.SqlClient
Imports System.Xml


Partial Class home_OrdemServico
    Inherits XMProtectedPage

    Protected cls As clsOrdemServico
    Protected intIDOS As Integer

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cls = New clsOrdemServico()
        If Not IsPostBack Then
            ViewState("CALLER") = CInt("0" & Request("Caller"))
            intIDOS = CLng("0" & Request("IDOS"))
            ViewState("IDOS") = intIDOS
            cls.Load(intIDOS)
            Inflate()
            BindRespostas()
            BindEtapas()
        End If
    End Sub

    Protected Sub Inflate()
        With cls
            lblOS.Text = .NumeroOS
            lblCliente.Text = .Cliente
            lblResponsavel.Text = .Responsavel
            txtDescricao.Text = .Descricao
            lblAgendada.Text = .Agendada
            lblInicio.Text = .Inicio
            lblTermino.Text = .Termino
            lblStatus.Text = .Status & " em " & .DataStatus
            lblPrioridade.Text = .Prioridade
            If .Foto = "" Or Not XMSistemas.XMVirtualFile.VirtualFile.FileExists(ConfigurationManager.AppSettings("DirFotosOS") & .Foto) Then
                imgOS.ImageUrl = XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(ConfigurationManager.AppSettings("DirFotosOS") & "noimage.png")
            Else
                imgOS.ImageUrl = XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(ConfigurationManager.AppSettings("DirFotosOS") & .Foto)
            End If
        End With
    End Sub

    Private Sub BindRespostas()

        Dim dom As New XmlDocument
        dom.LoadXml(cls.GetRespostaXML)
        trvRespostas.Nodes.Clear()
        trvRespostas.Nodes.Add(New TreeNode("Respostas"))

        Dim tNode As TreeNode = New TreeNode()

        tNode = trvRespostas.Nodes(0)
        tNode.SelectAction = TreeNodeSelectAction.None

        AddNode(dom.DocumentElement, tNode)
        trvRespostas.ExpandAll()

        plhHistorico.Visible = trvRespostas.Nodes.Count > 0


    End Sub

    Private Sub BindEtapas()
        Dim ds As DataSet = cls.ListarEtapa(DataClass.enReturnType.DataSet)
        rptEtapasTitulos.DataSource = ds
        rptEtapasTitulos.DataBind()
        rptEtapasDados.DataSource = ds
        rptEtapasDados.DataBind()
        plhEtapas.Visible = rptEtapasDados.Items.Count > 0
    End Sub


    Private Sub AddNode(ByVal inXmlNode As XmlNode, ByVal inTreeNode As TreeNode)
        Dim xNode As XmlNode
        Dim tNode As TreeNode
        Dim nodeList As XmlNodeList
        Dim i As Integer
        ' Loop through the XML nodes until the leaf is reached.
        ' Add the nodes to the TreeView during the looping process.
        If (inXmlNode.HasChildNodes) Then
            nodeList = inXmlNode.ChildNodes
            For i = 0 To nodeList.Count - 1
                xNode = inXmlNode.ChildNodes(i)
                inTreeNode.ChildNodes.Add(New TreeNode())
                tNode = inTreeNode.ChildNodes(i)
                tNode.SelectAction = TreeNodeSelectAction.None
                tNode.Text = GetText(xNode)
                tNode.Value = ""
                tNode.ImageToolTip = ""
                AddNode(xNode, tNode)
            Next
        Else
            inTreeNode.Text = GetText(inXmlNode)
            inTreeNode.SelectAction = TreeNodeSelectAction.None
        End If
    End Sub

    Private Function GetText(ByVal vNode As XmlNode) As String
        Dim strHTML As New StringBuilder
        If vNode.Name = "obs" Then
            strHTML.Append(Server.HtmlEncode(vNode.Attributes("text").Value) & ":")
            If vNode.Attributes("value") Is Nothing Then
                strHTML.Append("(n&atilde;o preenchido)")
            Else
                strHTML.Append(Server.HtmlEncode(vNode.Attributes("value").Value))
            End If
        ElseIf vNode.Name = "res" Or vNode.Name = "sta" Then
            strHTML.AppendLine("<table><tr>")
            If vNode.Attributes("color") Is Nothing Then
                strHTML.AppendFormat("<td style='width:16px;height:16px'><img src='../images/bullet.gif' height='16' width='16' border='0' /></td>{0}", Environment.NewLine)
            Else
                strHTML.AppendFormat("<td style='width:16px;height:16px;'><img src='../images/bullet.gif' style='width:16px;height:16px;background-color:{0};' /></td>{1}", vNode.Attributes("color").Value, Environment.NewLine)
            End If
            strHTML.AppendFormat("<td style='vertical-align:middle;'>{0}</td>{1}", vNode.Attributes("texto").Value, Environment.NewLine)
            If Not vNode.Attributes("data") Is Nothing Then
                strHTML.AppendFormat("<td style='vertical-align:middle;padding-left:5px;'>{0}</td>{1}", CDate(vNode.Attributes("data").Value), Environment.NewLine)
            End If
            strHTML.AppendLine("</tr></table>")
        End If
        Return strHTML.ToString
    End Function



    Private Sub btnApagar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnApagar.Click
        cls.Cancelar(ViewState("IDOS"))
        Response.Redirect("default.aspx?" & "")
    End Sub

    Private Sub btnReenviar_ServerClick(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnReenviar.Click
        Response.Redirect("reenviar.aspx?idos=" & ViewState("IDOS") & "&")
    End Sub

    Private Sub btnVoltar_ServerClick(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("default.aspx?" & "")
    End Sub

    Protected Sub btnAlterar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlterar.Click
        lblPrioridade.Visible = False
        btnAlterar.Visible = False
        cboPrioridade.Visible = True
        btnOk.Visible = True
        btnCancelar.Visible = True
    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnOk.Click
        Try
            cls.AlterarOS(ViewState("IDOS"), cboPrioridade.SelectedValue)
            cls.Load(CInt(ViewState("IDOS")))
            Inflate()
        Catch
            Response.Redirect("default.aspx?" & "")
        End Try
        lblPrioridade.Visible = True
        btnAlterar.Visible = True
        cboPrioridade.Visible = False
        btnOk.Visible = False
        btnCancelar.Visible = False
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancelar.Click
        lblPrioridade.Visible = True
        btnAlterar.Visible = True
        cboPrioridade.Visible = False
        btnOk.Visible = False
        btnCancelar.Visible = False
    End Sub
End Class
