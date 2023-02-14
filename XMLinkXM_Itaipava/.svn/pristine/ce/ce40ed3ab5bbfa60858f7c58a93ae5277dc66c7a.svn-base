
Partial Class Relatorios_Imprimir
    Inherits System.Web.UI.MasterPage

    Public Property Titulo() As String
        Get
            Return lblTitulo.Text
        End Get
        Set(ByVal value As String)
            lblTitulo.Text = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return lblDescricao.Text
        End Get
        Set(ByVal value As String)
            lblDescricao.Text = value
        End Set
    End Property

    'Public Property Periodo() As String
    '    Get
    '        Return ltrPeriodo.Text
    '    End Get
    '    Set(ByVal value As String)
    '        ltrPeriodo.Text = value
    '    End Set
    'End Property

    Public ReadOnly Property User() As XMPrincipal
        Get
            Return CType(Me.Page, XMWebPage).User
        End Get
    End Property

    Public ReadOnly Property VerificaPermissao(vSecao As String, vAcao As String) As Boolean
        Get
            Return CType(Me.Page, XMWebPage).VerificaPermissao(vSecao, vAcao)
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Titulo = Request("tx")
        'Descricao = Request("desc")

        Descricao = "Periodo: " & Request("di") & " at&eacute; " & Request("df")
        'ltrScroll.Visible = (Request("pr") <> 1)


    End Sub


End Class

