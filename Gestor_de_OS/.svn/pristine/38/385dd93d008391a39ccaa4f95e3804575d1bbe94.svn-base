Namespace Controls

    Partial Public Class Paginate
        Inherits System.Web.UI.UserControl

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
                If ViewState("PageSize") Is Nothing Then
                    Return 10
                End If
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

        Public Property Filtro() As String
            Get
                Return ViewState("Filtro")
            End Get
            Set(ByVal value As String)
                ViewState("Filtro") = value
            End Set
        End Property

        Public property ValidationGroup As String
            Get
                Return lnkFirst.ValidationGroup
            End Get
            Set(ByVal value As String)
                lnkFirst.ValidationGroup = value
                lnkNext.ValidationGroup = value
                lnkPrevious.ValidationGroup = value
                lnkUltima.ValidationGroup = value
            End Set
        End Property

        Public Property CausesValidation As Boolean
            Get
                Return lnkFirst.CausesValidation
            End Get
            Set(ByVal value As Boolean)
                lnkFirst.CausesValidation = value
                lnkNext.CausesValidation = value
                lnkPrevious.CausesValidation = value
                lnkUltima.CausesValidation = value
            End Set
        End Property


        Public Property SortExpression() As String
            Get
                If ViewState("SortExpression") Is Nothing Then
                    Return ""
                Else
                    Return ViewState("SortExpression")
                End If
            End Get
            Set(ByVal value As String)
                If ViewState("SortExpression") = value Then
                    If SortDirection = WebControls.SortDirection.Ascending Then
                        SortDirection = WebControls.SortDirection.Descending
                    Else
                        SortDirection = WebControls.SortDirection.Ascending
                    End If
                Else
                    ViewState("SortExpression") = value
                    SortDirection = WebControls.SortDirection.Ascending
                End If
            End Set
        End Property

        Public Property SortDirection() As SortDirection
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

    End Class

End Namespace
