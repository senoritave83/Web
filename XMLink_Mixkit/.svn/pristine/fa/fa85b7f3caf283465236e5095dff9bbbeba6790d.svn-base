Namespace Controls

    Partial Public Class Paginate
        Inherits System.Web.UI.UserControl
        Implements IFiltroControl


        Public Event OnPageChanged()

        Public Property CurrentPage() As Integer
            Get
                Return ViewState("CurrentPage")
            End Get
            Set(ByVal value As Integer)
                ViewState("CurrentPage") = value
            End Set
        End Property

        Public Property PageCount() As Integer
            Get
                Return ViewState("PageCount")
            End Get
            Set(ByVal value As Integer)
                ViewState("PageCount") = value
            End Set
        End Property

        Public Property PageSize() As Integer
            Get
                Return ViewState("PageSize")
            End Get
            Set(ByVal value As Integer)
                ViewState("PageSize") = value
            End Set
        End Property

        Public Property RecordCount() As Integer
            Get
                Return ViewState("RecordCount")
            End Get
            Set(ByVal value As Integer)
                ViewState("RecordCount") = value
            End Set
        End Property

        Public WriteOnly Property DataSource() As IPaginaResult
            Set(ByVal value As IPaginaResult)
                CurrentPage = value.CurrentPage
                PageCount = value.PageCount
                PageSize = value.PageSize
                RecordCount = value.RecordCount
            End Set
        End Property


        Private Sub lnkNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNext.Click
            Me.CurrentPage += 1
            RaiseEvent OnPageChanged()
        End Sub

        Private Sub lnkPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPrevious.Click
            Me.CurrentPage -= 1
            RaiseEvent OnPageChanged()
        End Sub


        Private Sub lnkFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkFirst.Click
            Me.CurrentPage = 0
            RaiseEvent OnPageChanged()
        End Sub

        Private Sub lnkUltima_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkUltima.Click
            Me.CurrentPage = Me.PageCount
            RaiseEvent OnPageChanged()
        End Sub

        Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
            lnkFirst.Enabled = (Me.CurrentPage > 0)
            lnkPrevious.Enabled = lnkFirst.Enabled
            lnkNext.Enabled = (Me.CurrentPage < Me.PageCount)
            lnkUltima.Enabled = lnkNext.Enabled
        End Sub

        Public Property Value() As Object Implements IFiltroControl.Value
            Get
                Return CurrentPage
            End Get
            Set(ByVal value As Object)
                CurrentPage = value
            End Set
        End Property
    End Class

End Namespace
