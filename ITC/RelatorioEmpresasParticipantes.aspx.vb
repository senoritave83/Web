Imports System.Data.SqlClient

Public Class RelatorioEmpresasParticipantes

    Inherits XMWebPage

    Protected WithEvents lblNomeFantasia As System.Web.UI.WebControls.Label
    Protected WithEvents lblRazaoSocial As System.Web.UI.WebControls.Label
    Protected WithEvents lblAtividade As System.Web.UI.WebControls.Label
    Protected WithEvents lblModalidade As System.Web.UI.WebControls.Label
    Protected WithEvents lblEndereco As System.Web.UI.WebControls.Label
    Protected WithEvents lblCidade As System.Web.UI.WebControls.Label
    Protected WithEvents lblEstado As System.Web.UI.WebControls.Label
    Protected WithEvents lblCep As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
    Protected WithEvents lblSite As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmail2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblSkype As System.Web.UI.WebControls.Label

    Protected WithEvents lblContato1Cargo As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato1Nome As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato1Tel1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato1Tel2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato2Cargo As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato2Nome As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato2Tel1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato2Tel2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato3Cargo As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato3Nome As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato3Tel1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblContato3Tel2 As System.Web.UI.WebControls.Label

    Protected WithEvents trContato1 As HtmlTableRow
    Protected WithEvents trContato2 As HtmlTableRow
    Protected WithEvents trContato3 As HtmlTableRow

    Dim Emp As clsEmpresasObras


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

        If Not Page.IsPostBack = True Then


            Dim objIdObra As Object = Request("IdObra")
            Dim objIdEmpresa As Object = Request("IdEmpresa")
            Dim objIdModalidade As Object = Request("IdModalidade")

            trContato1.Visible = False
            trContato2.Visible = False
            trContato3.Visible = False

            Emp = New clsEmpresasObras(objIdObra, objIdEmpresa, objIdModalidade)
            Inflate()

        End If
    End Sub

    Private Sub Inflate()

        With Emp

            Dim m_Mod As New clsModalidades
            m_Mod.load(.IdModalidade)
            lblModalidade.Text = m_Mod.Modalidade
            m_Mod = Nothing

            Dim m_Ati As New clsAtividades(.DadosEmpresa.IdAtividade)
            lblAtividade.Text = m_Ati.DescricaoAtividade
            m_Ati = Nothing

            lblRazaoSocial.Text = .DadosEmpresa.RazaoSocial
            lblNomeFantasia.Text = .DadosEmpresa.Fantasia
            lblEndereco.Text = .DadosEmpresa.Endereco
            lblCidade.Text = .DadosEmpresa.Cidade
            lblEstado.Text = .DadosEmpresa.Estado
            lblCep.Text = .DadosEmpresa.CEP
            lblEmail.Text = .DadosEmpresa.EMail
            lblSite.Text = .DadosEmpresa.WebSite
            lblEmail2.Text = .DadosEmpresa.EMail2
            lblSkype.Text = .DadosEmpresa.Skype

            Dim ds4 As DataSet = .DadosEmpresa.Contatos()
            Dim m As Integer
            If ds4.Tables.Count > 0 Then

                If ds4.Tables(0).Rows.Count > 0 Then
                    For m = 0 To ds4.Tables(0).Rows.Count - 1

                        If m = 0 Then
                            trContato1.Visible = True
                            lblContato1Cargo.Text = ds4.Tables(0).Rows(m).Item("DESCRICAOCARGO")
                            lblContato1Nome.Text = ds4.Tables(0).Rows(m).Item("NOMECONTATO")
                            lblContato1Tel1.Text = "(" & ds4.Tables(0).Rows(m).Item("DDD").Trim() & ") " & ds4.Tables(0).Rows(m).Item("TELEFONE").Trim()
                            lblContato1Tel2.Text = "(" & ds4.Tables(0).Rows(m).Item("DDDFAX").Trim() & ") " & ds4.Tables(0).Rows(m).Item("FAX").Trim()
                        ElseIf m = 1 Then
                            trContato2.Visible = True
                            lblContato2Cargo.Text = ds4.Tables(0).Rows(m).Item("DESCRICAOCARGO")
                            lblContato2Nome.Text = ds4.Tables(0).Rows(m).Item("NOMECONTATO")
                            lblContato2Tel1.Text = "(" & ds4.Tables(0).Rows(m).Item("DDD").Trim() & ") " & ds4.Tables(0).Rows(m).Item("TELEFONE").Trim()
                            lblContato2Tel2.Text = "(" & ds4.Tables(0).Rows(m).Item("DDDFAX").Trim() & ") " & ds4.Tables(0).Rows(m).Item("FAX").Trim()
                        ElseIf m = 2 Then
                            trContato3.Visible = True
                            lblContato3Cargo.Text = ds4.Tables(0).Rows(m).Item("DESCRICAOCARGO")
                            lblContato3Nome.Text = ds4.Tables(0).Rows(m).Item("NOMECONTATO")
                            lblContato3Tel1.Text = "(" & ds4.Tables(0).Rows(m).Item("DDD").Trim() & ") " & ds4.Tables(0).Rows(m).Item("TELEFONE").Trim()
                            lblContato3Tel2.Text = "(" & ds4.Tables(0).Rows(m).Item("DDDFAX").Trim() & ") " & ds4.Tables(0).Rows(m).Item("FAX").Trim()
                        End If

                        If m = 2 Then Exit For 'apenas 3 contatos por empresa participante

                    Next
                End If

            End If

        End With

    End Sub

End Class
