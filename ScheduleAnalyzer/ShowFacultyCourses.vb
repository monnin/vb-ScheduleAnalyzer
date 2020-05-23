Public Class ShowFacultyCourses
    Private myListViewColumnSorter As New ReportViewColumnSorter
    Public initialFacName As String = ""
    Public lastSpreadsheet As String = ""

    Private Sub getCourses()
        Dim l As List(Of oneSection)
        Dim subitems(4) As String
        Dim newItem As ListViewItem

        courseView.Items.Clear()

        Me.Text = "Course load for " & initialFacName

        l = SCHED_DATA.getAllSectionsForInstructor(facNameBox.Text)

        For Each one As oneSection In (l)
            subitems(0) = one.coursenum
            subitems(1) = dayBitmaskToStr(one.days, 3 + 4)
            subitems(2) = TimeIntToStr(one.starttime)
            subitems(3) = TimeIntToStr(one.endtime)
            subitems(4) = one.loc

            newItem = New ListViewItem(subitems)
            courseView.Items.Add(newItem)
        Next
    End Sub

    Private Sub showButton_Click(sender As System.Object, e As System.EventArgs) Handles showButton.Click
        getCourses()
    End Sub

    '
    '   See http://support.microsoft.com/kb/319401
    '
    Private Sub courseView_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles courseView.ColumnClick
        If (e.Column = myListViewColumnSorter.SortColumn) Then
            '
            '  Reverse the order if the column is clicked a second (or third...) time
            '
            If (myListViewColumnSorter.Order = SortOrder.Ascending) Then
                myListViewColumnSorter.Order = SortOrder.Descending
            Else
                myListViewColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            myListViewColumnSorter.Order = SortOrder.Ascending
            myListViewColumnSorter.SortColumn = e.Column
        End If

        courseView.Sort()

    End Sub

    Private Sub ShowFacultyCourses_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        facNameBox.Text = initialFacName

        getCourses()

        courseView.ListViewItemSorter = myListViewColumnSorter
    End Sub


    Private Sub courseView_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles courseView.MouseDoubleClick
        Dim jf As JumpForm

        For Each i As ListViewItem In courseView.SelectedItems
            If (lastSpreadsheet <> "") Then
                jf = New JumpForm

                jf.ShowChoices(lastSpreadsheet, facNameBox.Text & "'s section of " & i.SubItems(0).Text,
                               i.SubItems(4).Text, "", i.SubItems(0).Text, "")
            End If

        Next
    End Sub



    Private Sub copyMenuItem_Click(sender As Object, e As System.EventArgs) Handles copyMenuItem.Click
        copyListViewToClipboard(courseView, 4)
    End Sub

    Private Sub printMenuItem_Click(sender As Object, e As System.EventArgs) Handles printMenuItem.Click
        printView(courseView, True, "Courses for " & facNameBox.Text, longdatetime(), 4)
    End Sub


End Class