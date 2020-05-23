Public Class FindTime
    Private myListViewColumnSorter As New ReportViewColumnSorter
    ' Private fixedFont As New Font("Calibri", 9)
    '
    '   FindTime
    '
    '   Given a specific room, find the times the room is available anytime
    '   in a specific block
    '
    '


    Private Sub startTimeBox_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        ' endTimeBox.SelectedIndex = startTimeBox.SelectedIndex
    End Sub

    Sub load_capabilities()
        Dim row As Integer = 0
        Dim col As Integer = 0
        Dim count As Integer

        count = load_capabilities_table(capabilitiesTable)

        If (count = 0) Then
            capabilitiesLabel.Visible = True

            capabilitiesTable.Visible = False
            matchAllRB.Visible = False
            matchAnyRB.Visible = False
        Else
            capabilitiesLabel.Visible = False

            capabilitiesTable.Visible = True
            matchAllRB.Visible = True
            matchAnyRB.Visible = True
        End If
    End Sub

    '
    '    (Form Load)
    '
    '   Reset the items in the list of room 
    '   (clear it first because the form might be opened multiple times)
    '
    Private Sub FindTime_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        errorLabel.Visible = False

        roomBox.Items.Clear()
        roomBox.Items.Add("<any>")
        roomBox.Items.AddRange(SCHED_DATA.rooms.ListAllRooms())
        load_capabilities()

        ResultView.ListViewItemSorter = myListViewColumnSorter

    End Sub

    '
    '   checkToStr
    '
    '   Convert all of the day of week checkboxes into a single string (that
    '   can be passed into ScheduleData.vb)
    '
    '   The string will have an extra space at the end, but ScheduleData doesn't care
    '
    Private Function checkToStr() As String
        Dim s As String = ""

        If (SunCheck.Checked) Then
            s = s & "Sun "
        End If


        If (MonCheck.Checked) Then
            s = s & "Mon "
        End If

        If (TueCheck.Checked) Then
            s = s & "Tue "
        End If

        If (WedCheck.Checked) Then
            s = s & "Wed "
        End If

        If (ThurCheck.Checked) Then
            s = s & "Thur "
        End If

        If (friCheck.Checked) Then
            s = s & "Fri "
        End If

        If (SatCheck.Checked) Then
            s = s & "Sat "
        End If

        Return s
    End Function

    Private Function durationgraph(dur As Integer) As String
        Dim s As String = ""

        While (dur > 30)
            s = s & "*"
            dur = dur - 30
        End While

        Return s
    End Function

    '
    '   FindItButton
    '
    '   Call the routine in ScheduleData that does the actual search
    '
    '   (but first check to make sure that at least one day was selected)
    '
    Private Sub FindItButton_Click(sender As System.Object, e As System.EventArgs) Handles FindItButton.Click
        Dim weekStr As String = checkToStr()
        Dim capabilitiesHash As HashSet(Of String)
        Dim ok As Boolean
        Dim errorString As String = ""
        Dim allPossibilities As New List(Of roomReportEntry)
        Dim subitems(5) As String
        Dim i As Integer
        Dim item As ListViewItem
        Dim duration As Integer
        Dim seats As Integer

        If (weekStr.Trim = "") Then
            errorLabel.Text = "Please select at least one date"
            ResultView.Enabled = False
            errorLabel.Visible = True

        Else

            capabilitiesHash = tablelayouttohash(capabilitiesTable)

            If ((Integer.TryParse(minSeats.Text, seats) = False) OrElse (seats < 1)) Then
                seats = -1
            End If

            ok = SCHED_DATA.findFreeTime(roomBox.Text, durationBox.Text, classCount.Value, _
                              startTimeBox.Text, endTimeBox.Text, weekStr, _
                              capabilitiesHash, matchAllRB.Checked, _
                              seats, My.Settings.DefaultRoomSize, _
                              allPossibilities, errorString)

            errorLabel.Text = errorString
            errorLabel.Visible = Not ok
            ResultView.Enabled = ok

            If (ok) Then
                ResultView.Items.Clear()
                myListViewColumnSorter.Order = SortOrder.None


                If (allPossibilities.Count = 0) Then

                    errorLabel.Text = "Sorry, no available time found matching the criteria"
                    errorLabel.Visible = True
                    ResultView.Enabled = False

                Else
                    For i = 0 To allPossibilities.Count - 1
                        duration = allPossibilities(i).endTime - allPossibilities(i).startTime
                        subitems(0) = allPossibilities(i).room

                        subitems(1) = dayBitmaskToStr(allPossibilities(i).days, 3)
                        subitems(2) = TimeIntToStr(allPossibilities(i).startTime)
                        subitems(3) = TimeIntToStr(allPossibilities(i).endTime)
                        subitems(4) = DurationIntToStr(duration)
                        subitems(5) = durationgraph(duration)

                        item = New ListViewItem(subitems)

                        '
                        '   Add a pop-up telling me a little more about each room
                        '
                        item.ToolTipText = allPossibilities(i).room & ": " & allPossibilities(i).descr

                        ' item.UseItemStyleForSubItems = False
                        'item.font = fixedFont

                        ResultView.Items.Add(item)

                    Next
                End If
            End If

        End If
    End Sub



    '
    '   See http://support.microsoft.com/kb/319401
    '
    Private Sub resultView_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles ResultView.ColumnClick
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

        ResultView.Sort()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    '
    '  Based on http://dotnetref.blogspot.com/2007/06/copy-listview-to-clipboard.html
    '

    Private Sub CopyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        copyListViewToClipboard(ResultView)
    End Sub


    Private Sub copyMenuItem_Click(sender As Object, e As System.EventArgs) Handles copyMenuItem.Click
        findAndCopyListView(sender)
    End Sub


    Private Sub printMenuItem_Click(sender As Object, e As System.EventArgs) Handles printMenuItem.Click
        printView(ResultView, True, "Rooms matching ...", longdatetime())
    End Sub
End Class