Public Class copiaroteirodet

    Inherits XMProtectedPage
    Protected cls As clsCopiarRoteiros
    Protected cli As clsClientes

    Protected WithEvents lblVendedor As Label
    Protected WithEvents lblCliente As Label
    Protected WithEvents lblRoteiro As Label
    Protected WithEvents txtNomeRoteiro As TextBox
    Protected WithEvents chlDiaSemana As RadioButtonList
    Protected WithEvents chlSemana As RadioButtonList
    Protected WithEvents btnCancelar As Button
    Protected WithEvents btnSalvar As Button
    Protected WithEvents VendedorSel As DropDownList
    Protected IDPrimeiroVendedor As Integer
    Protected WithEvents Td1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected intIDRoteiro As Integer
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dtgGridClientes As DataGrid
    Protected WithEvents lnkPrevious As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkNext As System.Web.UI.WebControls.LinkButton


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents valNome As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtReferencia As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBairro As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCidade As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCep As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUF As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtContato As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelefone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTabelaPreco As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDescontoMax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLimite As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtObservacao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLatitude As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLongitude As System.Web.UI.WebControls.TextBox
    Protected WithEvents imgLocalizacao As System.Web.UI.WebControls.ImageButton
    Protected WithEvents pnlMensagem As System.Web.UI.WebControls.Panel
    Protected WithEvents dtgVendedores As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cboVendedor As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAdicionar As System.Web.UI.WebControls.ImageButton
    Protected WithEvents pnlVendedores As System.Web.UI.WebControls.Panel
    Protected WithEvents tdCodigo As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdLocalizacao As System.Web.UI.HtmlControls.HtmlTableCell

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

        Dim IdVendedor As Integer

        cli = New clsClientes(Me)
        cls = New clsCopiarRoteiros(Me)
        If Not Page.IsPostBack Then

            IdVendedor = Page.Request("IDVendedor")
            intIDRoteiro = CInt("0" & Page.Request("IDRoteiro"))
            ViewState("IDRoteiro") = intIDRoteiro

            'intIDRoteiro = CLng("0" & Request("IDRoteiro"))
            'ViewState("intIDRoteiro") = intIDRoteiro

            BindVendedores()

            cls.Load(intIDRoteiro)
            'CreateItens()
            Inflate()

            If Request("edit") = "1" Then
                Dim strNewClientes As String = ""
                Dim vClientesAntigo() As String = Split(cls.Clientes, ",")
                Dim vClientesNovo() As String = Split(Page.Request("IDClientes"), ",")

                For intAntigo As Integer = 0 To UBound(vClientesAntigo)
                    Dim blnFoundOnNewArray As Boolean = False
                    For intNovo As Integer = 0 To UBound(vClientesNovo)
                        If vClientesAntigo(intAntigo) = vClientesNovo(intNovo) Then
                            blnFoundOnNewArray = True
                            Exit For
                        End If
                    Next
                    If blnFoundOnNewArray Then
                        strNewClientes &= vClientesAntigo(intAntigo) & ","
                    End If
                Next

                For intNovo As Integer = 0 To UBound(vClientesNovo)
                    Dim blnFoundOnOldArray As Boolean = False
                    For intAntigo As Integer = 0 To UBound(vClientesAntigo)
                        If vClientesNovo(intNovo) = vClientesAntigo(intAntigo) Then
                            blnFoundOnOldArray = True
                            Exit For
                        End If
                    Next
                    If Not blnFoundOnOldArray Then
                        strNewClientes &= vClientesNovo(intNovo) & ","
                    End If
                Next

                If strNewClientes.Length > 1 Then
                    strNewClientes = Left(strNewClientes, Len(strNewClientes) - 1)
                End If

                ViewState("IDClientes") = strNewClientes
            Else
                ViewState("IDClientes") = cls.Clientes
            End If


            BindClientes()

        Else
            IdVendedor = ViewState("IDVendedor")
            intIDRoteiro = ViewState("IDRoteiro")
            cls.Load(intIDRoteiro)

        End If

    End Sub

    Public Sub BindClientes()

        Dim ds As DataSet
        ds = cli.ListarInclusosRoteiro(ViewState("IDClientes"))
        dtgGridClientes.DataSource = ds.Tables(0)
        dtgGridClientes.DataBind()

    End Sub

    Public Sub BindVendedores()

        Dim ven As New clsVendedor(Me)
        cboVendedor.DataSource = ven.ListAll
        cboVendedor.DataBind()
        ven = Nothing

    End Sub

    Public Overridable Property Semana() As Integer
        Get
            Dim m_intSemana As Integer = 0
            For Each lst As ListItem In chlSemana.Items
                If lst.Selected Then m_intSemana = CInt(lst.Value)
            Next
            Return m_intSemana
        End Get
        Set(ByVal Value As Integer)
            Dim m_intSemana As Integer = Value
            For Each lst As ListItem In chlSemana.Items
                If lst.Value = CInt(m_intSemana) Then lst.Selected = True
            Next
        End Set
    End Property

    Public Overridable Property DiaSemana() As Integer
        Get
            Dim m_intDiaSemana As Integer = 0
            For Each lst As ListItem In chlDiaSemana.Items
                If lst.Selected Then m_intDiaSemana = CInt(lst.Value)
            Next
            Return m_intDiaSemana
        End Get
        Set(ByVal Value As Integer)
            Dim m_intDiaSemana As Integer = Value
            For Each lst As ListItem In chlDiaSemana.Items
                If lst.Value = CInt(m_intDiaSemana) Then lst.Selected = True
            Next
        End Set
    End Property

    'Protected Sub CreateItens()

    '    Dim iTemp As Integer, iValue As Integer

    '    chlDiaSemana.Items.Clear()
    '    chlSemana.Items.Clear()

    '    For iTemp = 0 To 6
    '        Dim lst As New ListItem
    '        iValue = 2 ^ iTemp
    '        lst.Selected = (iValue And CInt(m_intDiaSemana))
    '        lst.Text = WeekdayName(iTemp + 1)
    '        lst.Value = iValue
    '        chlSemana.Items.Add(lst)
    '    Next

    '    For iTemp = 0 To 4
    '        Dim lst As New ListItem
    '        iValue = 2 ^ iTemp
    '        lst.Selected = (iValue And CInt(m_intDia))
    '        lst.Text = iTemp + 1 & "ª Semana"
    '        lst.Value = iValue
    '        chlDiaSemana.Items.Add(lst)
    '    Next

    'End Sub

    Protected Sub Inflate()
        With cls
            lblRoteiro.Text = .IDRoteiro
            DiaSemana = .DiaSemana
            Semana = .Semana
            txtNomeRoteiro.Text = .NomeRoteiro
        End With
        
    End Sub

    Protected Sub Deflate()
        With cls
            .IDPrimeiroVendedor = Page.Request("IDVendedor")
            .IDVendedor = cboVendedor.SelectedValue
            .Semana = Semana
            .DiaSemana = DiaSemana
            .Ativo = True
            .Clientes = ViewState("IDClientes")
            .NomeRoteiro = txtNomeRoteiro.Text
        End With
    End Sub

   

    Private Sub dtgGridClientes_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgGridClientes.ItemCommand

        Dim vClientes() As String = Split(ViewState("IDClientes"), ",")
        Dim intIDSelected As Integer = dtgGridClientes.DataKeys(e.Item.ItemIndex)
        Dim strIDTemp As String

        If e.CommandName = "UP" Then
            If e.Item.ItemIndex = 0 Then
                Exit Sub
            End If
            strIDTemp = vClientes(e.Item.ItemIndex)
            vClientes(e.Item.ItemIndex) = vClientes(e.Item.ItemIndex - 1)
            vClientes(e.Item.ItemIndex - 1) = strIDTemp

        ElseIf e.CommandName = "DOWN" Then
            If e.Item.ItemIndex = UBound(vClientes) Then
                Exit Sub
            End If

            strIDTemp = vClientes(e.Item.ItemIndex)
            vClientes(e.Item.ItemIndex) = vClientes(e.Item.ItemIndex + 1)
            vClientes(e.Item.ItemIndex + 1) = strIDTemp
        End If
        Dim vRet As String
        vRet = Join(vClientes, ",")
        'hidClientes.Text = vRet
        ViewState("IDClientes") = vRet
        BindClientes()

    End Sub

    Private Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        If CheckPermission("Cadastro de Roteiros", "Adicionar Roteiro") = False Then
            ShowMsg("Permissão Negada")
            Exit Sub
        End If
        Deflate()
        cls.IDRoteiro = 0
        cls.CopiaRoteiro = 1
        cls.Update()
        Response.Redirect("roteiro.aspx?" & "idroteiro=" & cls.IDRoteiro & "&idvendedor=" & cls.IDVendedor)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Deflate()
        Response.Redirect("vendedordet.aspx?idvendedor=" & cls.IDPrimeiroVendedor)
    End Sub
End Class