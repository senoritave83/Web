Public Class visita

    Inherits XMProtectedPage

    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm

    Protected WithEvents lblDataVisita As System.Web.UI.WebControls.Label
    Protected WithEvents lblDataInicio As System.Web.UI.WebControls.Label
    Protected WithEvents lblDataFinal As System.Web.UI.WebControls.Label
    Protected WithEvents lblCliente As System.Web.UI.WebControls.Label
    Protected WithEvents lblVendedor As System.Web.UI.WebControls.Label
    Protected WithEvents lblNumero As System.Web.UI.WebControls.Label

    Protected WithEvents lblLatitudeInicio As System.Web.UI.WebControls.Label
    Protected WithEvents lblLongitudeInicio As System.Web.UI.WebControls.Label
    Protected WithEvents lblLatitudeFinal As System.Web.UI.WebControls.Label
    Protected WithEvents lblLongitudeFinal As System.Web.UI.WebControls.Label

    Protected WithEvents rowPosicaoInicial As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents rowPosicaoFinal As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents globe As System.Web.UI.WebControls.Image
    Protected WithEvents rowMostraMapa As System.Web.UI.HtmlControls.HtmlTableRow

    Protected WithEvents rptImages As System.Web.UI.WebControls.DataList

    Protected sIDVisita As String

    Protected WithEvents latCli As HtmlInputHidden
    Protected WithEvents lonCli As HtmlInputHidden
    Protected WithEvents latCliFinal As HtmlInputHidden
    Protected WithEvents lonCliFinal As HtmlInputHidden

    Protected cls As clsVisita

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        cls = New clsVisita(Me)

        If Not Page.IsPostBack Then
            If CheckPermission("Acesso do Sistema", "Visualizar Visitas") = False Then
                Response.Redirect("principal.aspx")
            End If

            rowPosicaoInicial.Visible = False
            rowPosicaoFinal.Visible = False
            rowMostraMapa.Visible = False
            sIDVisita = Request("IDVisita")
            ViewState("IDVisita") = sIDVisita
            cls.IDVisitaCliente = sIDVisita

            Dim clsCliente As clsClientes = New clsClientes(Me)
            clsCliente.Load(cls.IDCliente)
            latCli.Value = clsCliente.Latitude
            lonCli.Value = clsCliente.Longitude

            Inflate()
            BindFotos()

        Else

            sIDVisita = ViewState("IDVisita")
            cls.IDVisitaCliente = sIDVisita

        End If

    End Sub

    Protected Sub BindFotos()
        With rptImages
            .DataSource = cls.ListFotos(cls.IDVisitaCliente)
            .DataBind()
        End With
    End Sub

    Protected Sub Inflate()

        lblCliente.Text = cls.IDCliente & " - " & cls.Cliente
        lblDataVisita.Text = cls.DataVisita
        lblNumero.Text = cls.IDVisitaCliente

        If IsDate(cls.DataVisita) Then
            lblDataVisita.Text = CDate(cls.DataVisita).ToString("dd/MM/yyyy hh:mm:ss")
        Else
            lblDataVisita.Text = ""
        End If

        If IsDate(cls.DataInicio) Then
            lblDataInicio.Text = CDate(cls.DataInicio).ToString("dd/MM/yyyy hh:mm:ss")
        Else
            lblDataInicio.Text = ""
        End If

        If IsDate(cls.DataTermino) Then
            lblDataFinal.Text = CDate(cls.DataTermino).ToString("dd/MM/yyyy hh:mm:ss")
        Else
            lblDataFinal.Text = ""
        End If

        lblVendedor.Text = cls.IDVendedor & " - " & cls.Vendedor
        rowPosicaoInicial.Visible = (cls.LatitudeInicio <> 0 Or cls.LongitudeInicio <> 0)
        rowPosicaoFinal.Visible = (cls.LatitudeFinal <> 0 Or cls.LongitudeFinal <> 0)
        rowMostraMapa.Visible = (cls.LatitudeInicio <> 0 Or cls.LongitudeInicio <> 0)

        lblLatitudeInicio.Text = cls.LatitudeInicio
        lblLongitudeInicio.Text = cls.LongitudeInicio
        lblLatitudeFinal.Text = cls.LatitudeFinal
        lblLongitudeFinal.Text = cls.LongitudeFinal

    End Sub

End Class
