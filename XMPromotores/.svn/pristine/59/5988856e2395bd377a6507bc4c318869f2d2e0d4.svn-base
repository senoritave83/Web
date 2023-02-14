Imports XMSistemas.XMVirtualFile
Imports System.Drawing
Imports System.IO
Imports System.IO.Compression
Imports System.Data
Imports System.Configuration.ConfigurationManager
Imports System.Web.Services
Imports Ionic.Utils.Zip
Imports Classes
Imports System.Reflection

Namespace Pages.Sistema
    Partial Class Fotos
        Inherits XMWebPage

        Dim vis As clsVisita

        Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
            vis = New clsVisita

            If Not Page.IsPostBack Then

                ViewState("PhotoPath") = AppSettings("PhotoPath")
                txtDataFinal.Text = FormatDateTime(Now, 2)
                txtDataInicial.Text = FormatDateTime(Now.AddDays(-3), 2)

                BindCargos()
                BindUsuarios()

                RecuperaFiltro(txtFiltro, cboIDRevenda, txtDataInicial, txtDataFinal, cboIDCargos, lstUsuarios, lstTipoEntidade, cboFiltroDetalhado)
                cboFiltroDetalhado_Selected(sender, e)

                BindRepeaterVisita()

            End If

        End Sub

        <WebMethod()> _
        Public Shared Sub GirarFoto(ByVal name As String)
            Dim img As Image
            Dim path As String
            path = System.Configuration.ConfigurationManager.AppSettings("PhotoPath") & name
            Dim vf As New XMSistemas.XMVirtualFile.XMFileStream(path, FileMode.Open)

            Try
                img = Image.FromStream(vf)
                Dim img2 As System.Drawing.Imaging.ImageFormat = New System.Drawing.Imaging.ImageFormat(img.RawFormat.Guid)

                img.RotateFlip(RotateFlipType.Rotate270FlipXY)
                vf.Position = 0
                img.Save(vf, img2)
                vf.Close()
                img.Dispose()

                VirtualFile.CheckFile(path)
            Catch e As Exception

                Throw New Exception(e.Message)
            End Try

        End Sub

        Public Sub BindRevendas()
            Dim cli As New clsCliente

            cboIDRevenda.DataSource = cli.Listar
            cboIDRevenda.DataBind()
            cboIDRevenda.Items.Insert(0, New ListItem("TODAS", 0))
            cli = Nothing
        End Sub

        Public Sub BindCargos()
            Dim car As New clsCargo

            cboIDCargos.DataSource = car.Listar()
            cboIDCargos.DataBind()
            cboIDCargos.Items.Insert(0, New ListItem("TODOS", "0"))
            car = Nothing
        End Sub

        Public Sub BindUsuarios()
            Dim usu As New clsUsuario

            lstUsuarios.DataSource = usu.Listar(CInt(cboIDCargos.SelectedValue))
            lstUsuarios.DataBind()
            usu = Nothing

            Dim strUsuarios As String = getComboValues(lstUsuarios)
            If strUsuarios = "" Then
                For Each lst As ListItem In lstUsuarios.Items
                    lst.Selected = True
                Next
            End If

        End Sub

        Public Sub BindEntidades()

            Dim ent As New clsEntidade

            lstTipoEntidade.DataSource = ent.ListarEmFotos()
            lstTipoEntidade.DataBind()

        End Sub

        Public Sub BindRepeaterVisita()

            Dim vIdRevenda As Integer = 0, vIdCargo As Integer = 0, vIdUsuario As String = "", vTipoEntidade As String = ""
            Select Case cboFiltroDetalhado.SelectedValue

                Case "0"

                    vIdRevenda = getComboValue(cboIDRevenda)
                    vIdCargo = getComboValue(cboIDCargos)
                    vIdUsuario = getComboValues(lstUsuarios)
                    vTipoEntidade = getComboValues(lstTipoEntidade)

                Case "1"

                    vIdCargo = getComboValue(cboIDCargos)
                    vIdUsuario = getComboValues(lstUsuarios)

                Case "3"

                    vIdRevenda = getComboValue(cboIDRevenda)

                Case "4"

                    vTipoEntidade = getComboValues(lstTipoEntidade)

            End Select

            Dim ret As IPaginaResult = vis.ListarVisitasFotos(txtFiltro.Text, vIdRevenda, txtDataInicial.Text, _
                                              txtDataFinal.Text, vIdCargo, vIdUsuario, _
                                              vTipoEntidade, SortExpression, SortDirection, Paginate1.CurrentPage, PAGESIZE)
            rptVisita.DataSource = ret.Data
            rptVisita.DataBind()

            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            lblEmpytResult.Visible = Not rptVisita.Items.Count > 0
            trDownload.Visible = rptVisita.Items.Count > 0

            GravaFiltro(txtFiltro, cboIDRevenda, txtDataInicial, txtDataFinal, cboIDCargos, lstUsuarios, lstTipoEntidade, cboFiltroDetalhado)

        End Sub

        Public Function BindRepeaterTipoEntidade(ByVal IdVisita As Integer) As IDataReader

            Dim dr As IDataReader = vis.ListarTipoEntidades(IdVisita, getComboValues(lstTipoEntidade))
            Return dr

        End Function

        Public Function BindRepeaterFotos(ByVal IdVisita As String, ByVal TipoEntidade As Integer) As IDataReader

            Dim dr As IDataReader = vis.ListarFotos(IdVisita, TipoEntidade)
            Return dr

        End Function

        Protected Sub cboIDCargos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboIDCargos.SelectedIndexChanged

            BindUsuarios()

        End Sub

        Protected Sub cboFiltroDetalhado_Selected(sender As Object, e As System.EventArgs)

            If cboFiltroDetalhado.SelectedValue = 0 Then

                trCargo.Visible = True
                trBuscaRevenda.Visible = True
                trTipoFoto.Visible = True

                setComboValue(lstTipoEntidade, 0)
                setComboValue(cboIDRevenda, 0)
                setComboValue(cboIDCargos, 0)
                setComboValue(lstUsuarios, 0)

                RecuperaFiltro(txtDataFinal, txtDataInicial)

                If txtDataFinal.Text = "" Or txtDataInicial.Text = "" Then
                    txtDataFinal.Text = FormatDateTime(Now.AddDays(-10), 2)
                    txtDataInicial.Text = FormatDateTime(Now, 2)
                End If

            Else

                BindRevendas()
                BindCargos()
                BindUsuarios()
                BindEntidades()

                RecuperaFiltro(txtDataFinal, txtDataInicial)

                If cboFiltroDetalhado.SelectedValue = 1 Then

                    trCargo.Visible = True
                    RecuperaFiltro(cboIDCargos, lstUsuarios)

                Else

                    trCargo.Visible = False

                End If

                If cboFiltroDetalhado.SelectedValue = 3 Then

                    trBuscaRevenda.Visible = True
                    RecuperaFiltro(cboIDRevenda)

                Else

                    trBuscaRevenda.Visible = False

                End If

                If cboFiltroDetalhado.SelectedValue = 4 Then

                    trTipoFoto.Visible = True
                    RecuperaFiltro(lstTipoEntidade)

                Else

                    trTipoFoto.Visible = False

                End If
            End If
        End Sub

        Protected Sub cboFiltroDetalhado_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboFiltroDetalhado.SelectedIndexChanged

            cboFiltroDetalhado_Selected(sender, e)

        End Sub

        Protected Sub btnFiltrar_Click(sender As Object, e As System.EventArgs) Handles btnFiltrar.Click

            Paginate1.CurrentPage = 0
            ViewState("Filtro") = txtFiltro.Text
            BindRepeaterVisita()

        End Sub

        Sub verificaDatas(ByVal source As Object, ByVal args As ServerValidateEventArgs)

            Try

                args.IsValid = True

                If IsDate(txtDataInicial.Text) And IsDate(txtDataFinal.Text) Then
                    If DateDiff(DateInterval.Day, CDate(txtDataInicial.Text), CDate(txtDataFinal.Text)) > 3 Then
                        args.IsValid = False
                    End If
                Else
                    If IsDate(txtDataInicial.Text) Then
                        txtDataFinal.Text = CDate(txtDataInicial.Text).AddDays(3)
                    Else
                        If IsDate(txtDataFinal.Text) Then
                            txtDataInicial.Text = CDate(txtDataFinal.Text).AddDays(-33)
                        Else
                            txtDataFinal.Text = FormatDateTime(Now, 2)
                            txtDataInicial.Text = FormatDateTime(Now.AddDays(-3), 2)
                        End If
                    End If
                End If


            Catch ex As Exception

                args.IsValid = False

            End Try

        End Sub

        Protected Sub btnDownload_Click(sender As Object, e As System.EventArgs) Handles btnDownload.Click
            Dim p_Path As String
            Dim dr As IDataReader
            Dim zip As ZipFile

            If Not Request("chkEntidade") Is Nothing Then
                Dim Dados = Request("chkEntidade").Split(",")

                p_Path = Server.MapPath(ViewState("PhotoPath"))

                'Cria arquivo ZIP no stream de resposta.
                zip = New ZipFile(Response.OutputStream)

                'Para cada visita, adiciona as fotos de acordo com a entidade selecionada.
                For Each item In Dados
                    Dim VisitaEntidade = item.Split("|")

                    dr = vis.ListarFotos(VisitaEntidade(0), VisitaEntidade(1))
                    While dr.Read

                        If File.Exists(p_Path & dr.GetString(dr.GetOrdinal("NomeFoto"))) Then

                            zip.AddFile(p_Path & dr.GetString(dr.GetOrdinal("NomeFoto")), "")
                        End If
                    End While

                    dr = Nothing
                Next
                'Grava resposta
                Response.Clear()
                Response.ClearHeaders()
                Response.AddHeader("Content-Disposition", "attachment; filename=fotos_xmpromotores_" & Now.ToString.Replace("/", "").Replace(":", "").Replace(" ", "") & ".zip")
                zip.Save()
                zip.Dispose()
                zip = Nothing

                Response.End()
            Else
                ltrAlert.Text = "<script type='text/javascript'>alert('Nenhuma visita foi selecionada!');</script>"
            End If

        End Sub

        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindRepeaterVisita()
        End Sub

        Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
            Paginate1.CurrentPage = 0
            ViewState("Filtro") = txtFiltro.Text
            BindRepeaterVisita()
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

    End Class
End Namespace