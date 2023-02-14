Imports System.Data.SqlClient
Imports System.Configuration
Imports XMSistemas.XMVirtualFile
Public Class campanhas

    Inherits XMProtectedPage

    Protected WithEvents BarraBotoes As BarraBotoes
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents valReqNome As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDataIni As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtDataFim As System.Web.UI.WebControls.TextBox
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents tdCodigo As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents dtgGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lnkPrevious As LinkButton
    Protected WithEvents txtValor As TextBox
    Protected WithEvents lnkNext As LinkButton
    Protected WithEvents Requiredfieldvalidator8 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator9 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnSalvar As System.Web.UI.WebControls.Button
    Protected WithEvents Td1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtFiltro As TextBox

    Protected intIDCampanha As Integer
    Protected WithEvents cboFiltroCategoria As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnFiltrar As System.Web.UI.WebControls.Button
    Protected WithEvents chkAtivar As System.Web.UI.WebControls.CheckBox
    Protected WithEvents rblParcelas As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtParcelas As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnLimpar As Button
    Protected WithEvents btnDesativar As Button
    Protected WithEvents imgOS As System.Web.UI.WebControls.Image
    Protected WithEvents flImgOS As System.Web.UI.WebControls.FileUpload
    Protected WithEvents btnSalvarFoto As System.Web.UI.WebControls.Button
    Protected WithEvents txtPontos As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDetalhes As System.Web.UI.WebControls.TextBox


    Protected cls As clsCampanhas

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        cls = New clsCampanhas(Me)

        intIDCampanha = CLng("0" & Request("IDCampanha"))
        ViewState("IDCampanha") = intIDCampanha

        If Not Page.IsPostBack Then
            BindGrid()
            ViewState("CurrentPage") = 0
            ViewState("Desc") = True
            ViewState("Sort") = "OS"

            If ViewState("IDCampanha") <> 0 Then
                Inflate()
            End If
            btnSalvar.Enabled = CheckPermission("Cadastro de Campanhas", "Adicionar Campanha")
            btnDesativar.Enabled = CheckPermission("Cadastro de Campanhas", "Desativar Campanha")
        End If
    End Sub

    Public Sub BindGrid()
        Dim ds As DataSet
        ds = cls.Listar(txtFiltro.Text, ViewState("Sort") & "", ViewState("Desc"), ViewState("CurrentPage"), PageSize)
        dtgGrid.DataSource = ds.Tables(0)
        dtgGrid.DataBind()
        Dim intMaxPages As Integer = ds.Tables(1).Rows(0).Item(0) \ PageSize
        If ViewState("CurrentPage") > intMaxPages Then
            ViewState("CurrentPage") = intMaxPages
        End If
        If ViewState("CurrentPage") > 0 Then
            lnkPrevious.Enabled = True
            lnkPrevious.CommandArgument = ViewState("CurrentPage") - 1
        Else
            lnkPrevious.Enabled = False
        End If
        If ViewState("CurrentPage") < intMaxPages Then
            lnkNext.Enabled = True
            lnkNext.CommandArgument = ViewState("CurrentPage") + 1
        Else
            lnkNext.Enabled = False
        End If
    End Sub

    Public Sub Inflate()
        cls.Load(ViewState("IDCampanha"))
        txtCodigo.Text = cls.Codigo
        txtNome.Text = cls.Descricao
        txtValor.Text = cls.ValorMin
        txtDataIni.Text = cls.DataIni
        txtDataFim.Text = cls.DataFim
        If cls.Parcelas <> 0 Then
            rblParcelas.Visible = False
            txtParcelas.Visible = True
            txtParcelas.Text = cls.Parcelas
        Else
            rblParcelas.Visible = False
            txtParcelas.Visible = True
            txtParcelas.Text = 1
        End If
        If cls.Foto = "" Or Not VirtualFile.FileExists(ConfigurationManager.AppSettings("DirFotos") & cls.Foto) Then
            imgOS.ImageUrl = VirtualFile.GetDirectAccessUrl(ConfigurationManager.AppSettings("DirFotos") & "noimage.png")
        Else
            imgOS.ImageUrl = "../thumbnail.ashx?width=280&filename=" & VirtualFile.GetDirectAccessUrl(ConfigurationManager.AppSettings("DirFotos") & cls.Foto)
            ViewState("NamePhoto") = cls.Foto
        End If
        txtPontos.Text = cls.Pontos
        txtDetalhes.Text = cls.Detalhes
    End Sub

    Public Sub Clear()
        Response.Redirect("campanhas.aspx?idcampanha=" & 0)
    End Sub

    Public Sub DataGrid_Command(ByVal source As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        If e.CommandName = "Order" Then
            ViewState("Desc") = Not ViewState("Desc")
            ViewState("Sort") = e.CommandArgument
        ElseIf e.CommandName = "Paginate" Then
            If e.CommandArgument = "inc" Then
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            Else
                ViewState("CurrentPage") = CInt(e.CommandArgument)
            End If
        End If
        BindGrid()
    End Sub

    Public Sub Deflate()
        cls.IDCampanha = ViewState("IDCampanha")
        cls.Codigo = txtCodigo.Text
        cls.Descricao = txtNome.Text
        cls.ValorMin = CInt(0 & txtValor.Text)
        cls.DataIni = txtDataIni.Text
        cls.DataFim = txtDataFim.Text
        If ViewState("IDCampanha") = 0 Then
            If rblParcelas.SelectedIndex = 0 Then
                txtParcelas.Text = "1"
            End If
        End If
        cls.Parcelas = txtParcelas.Text
        cls.Foto = ViewState("NamePhoto") & ""
        cls.Pontos = txtPontos.Text
        cls.Detalhes = txtDetalhes.Text
    End Sub

    Private Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        SalvarDadosCampanha()
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        BindGrid()
    End Sub

    Private Sub btnLimpar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpar.Click
        Clear()
    End Sub

    Private Sub rblParcelas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblParcelas.SelectedIndexChanged
        If rblParcelas.SelectedIndex <> 0 Then
            txtParcelas.Visible = True
            txtParcelas.Text = ""
            txtParcelas.Enabled = True
        Else
            txtParcelas.Text = "1"
            txtParcelas.Enabled = False
        End If
    End Sub

    Private Sub btnDesativar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDesativar.Click
        If VirtualFile.FileExists(ConfigurationManager.AppSettings("DirFotos") & ViewState("NamePhoto")) Then
            VirtualFile.Delete(ConfigurationManager.AppSettings("DirFotos") & ViewState("NamePhoto"))
        End If
        cls.Delete(ViewState("IDCampanha"))
        Clear()
        BindGrid()
    End Sub


    Protected Sub btnSalvarFoto_Click(sender As Object, e As System.EventArgs) Handles btnSalvarFoto.Click

        ViewState("NamePhoto") = flImgOS.FileName

        If flImgOS.HasFile Then

            If Not XMSistemas.XMVirtualFile.VirtualFile.FileExists(ConfigurationManager.AppSettings("DirFotos") & ViewState("NamePhoto")) Then

                Dim xm As New XMSistemas.XMVirtualFile.XMFileStream(ConfigurationManager.AppSettings("DirFotos") & ViewState("NamePhoto"), IO.FileMode.CreateNew)

                xm.Write(flImgOS.PostedFile.InputStream)
                xm.Close()

                imgOS.ImageUrl = "../thumbnail.ashx?width=280&height=280&filename=" & _
                    XMSistemas.XMVirtualFile.VirtualFile.GetDirectAccessUrl(ConfigurationManager.AppSettings("DirFotos") & ViewState("NamePhoto"))
            End If

            SalvarDadosCampanha()

        End If


    End Sub

    Public Sub SalvarDadosCampanha()

        If CheckPermission("Cadastro de Campanhas", "Adicionar Campanha") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If

        'If cls.Existe(txtCodigo.Text) Then
        '    ShowMsg("A campanha com este código já existe!")
        '    Exit Sub
        'End If

        Deflate()

        Try
            cls.Update()
        Catch ex As SqlException
            If ex.Number = 50000 Then
                ShowError(ex.Message)
                Exit Sub
            Else
                Throw ex
            End If
        End Try
        MostraGravado("campanhas.aspx?idcampanha=" & cls.IDCampanha)
    End Sub

End Class
