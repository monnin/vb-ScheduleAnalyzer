Public Class ShowPotentialSchedules
    Private mycompare As New DataGridViewCustomIComparer(SortOrder.Ascending)
    Private allMatches As List(Of List(Of Integer))

    Private Sub ShowPotentialSchedules_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        preDefinedComboBox.Items.Clear()

        preDefinedComboBox.Items.AddRange(SCHED_DATA.allSequenceNames(0))

        '
        '  Enable the checkbox if we have data to support it
        '
        If (SCHED_DATA.hasEnrollmentData()) Then
            NotFullCheckBox.Checked = My.Settings.LastFullSearchOption
            NotFullCheckBox.Enabled = True
        Else
            NotFullCheckBox.Checked = False
        End If

    End Sub

    Private Sub loadCriteria(ByRef c As ScheduleCriteria)
        '
        '  Format
        '
        If ((c Is Nothing) OrElse (c.format = ScheduleCriteria.classFormat.either)) Then
            eitherRadioButton.Checked = True
        ElseIf (c.format = ScheduleCriteria.classFormat.classroom) Then
            classroomRadioButton.Checked = True
        Else
            onlineRadioButton.Checked = True
        End If

        '
        '  Days
        '
        MonBox.Checked = (c Is Nothing) OrElse (c.hasMonday())
        TueBox.Checked = (c Is Nothing) OrElse (c.hasTuesday())
        WedBox.Checked = (c Is Nothing) OrElse (c.hasWednesday())
        ThurBox.Checked = (c Is Nothing) OrElse (c.hasThursday())
        FriBox.Checked = (c Is Nothing) OrElse (c.hasFriday())
        SatBox.Checked = (c Is Nothing) OrElse (c.hasSaturday())
        sunBox.Checked = (c Is Nothing) OrElse (c.hasSunday())

        '
        '
        '  Max # Days
        If ((c Is Nothing) OrElse (c.maxDays < 0)) Then
            maxDaysUD.Value = 7
        Else
            maxDaysUD.Value = c.maxDays()
        End If

        '
        '  Time of Days
        '

        If (c Is Nothing) Then
            fromDateTimePicker.Value = New DateTime(2015, 1, 1, 0, 0, 0)
        Else
            fromDateTimePicker.Value = c.startTime()
        End If

        If (c Is Nothing) Then
            toDateTimePicker.Value = New DateTime(2015, 1, 1, 23, 59, 59)
        Else
            toDateTimePicker.Value = c.endTime()
        End If

        '
        '  Rooms
        '
        If (c Is Nothing) Then
            roomBox.Text = ""
        Else
            roomBox.Text = c.rooms()
        End If

    End Sub

    Private Sub preDefinedComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles preDefinedComboBox.SelectedIndexChanged
        Dim s As String()

        s = SCHED_DATA.getCoursesInSequenceByNum(preDefinedComboBox.SelectedIndex)
        coursesBox.Text = String.Join(", ", s)

        loadCriteria(SCHED_DATA.getCriteriaForSequenceByNum(preDefinedComboBox.SelectedIndex))
    End Sub

    Private Sub coursesBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles coursesBox.TextChanged
        checkButton.Enabled = (coursesBox.Text.Trim <> "")
    End Sub

    Private Function create_criteria_from_form() As ScheduleCriteria
        Dim rooms As String = roomBox.Text
        Dim starttime As String = fromDateTimePicker.Value.ToShortTimeString
        Dim endtime As String = toDateTimePicker.Value.ToShortTimeString
        Dim format As String
        Dim days As String = ""

        If (onlineRadioButton.Checked) Then
            format = "online"
        ElseIf (classroomRadioButton.Checked) Then
            format = "classroom"
        Else
            format = "either"
        End If

        If (sunBox.Checked) Then days &= "Sun "
        If (MonBox.Checked) Then days &= "Mon "
        If (TueBox.Checked) Then days &= "Tue "
        If (WedBox.Checked) Then days &= "Wed "
        If (ThurBox.Checked) Then days &= "Thur "
        If (FriBox.Checked) Then days &= "Fri "
        If (SatBox.Checked) Then days &= "Sat "

        Return New ScheduleCriteria(rooms, starttime, endtime, days, maxDaysUD.Value, format, NotFullCheckBox.Checked)
    End Function

    '
    '   updateProgress(percent)
    '
    '   This acts as a "callback" from ScheduleData's load functions so that
    '   the user can see how long the event is taking (especially useful for
    '   large spreadsheets and slow computers)
    '

    Private Sub updateProgress(ByVal percent As Integer)
        If (percent > 100) Then
            percent = 100
        End If

        CheckProgressBar.Value = percent

        '
        '   Since the actual GUI event is still going on, we need to force
        '   a refresh (and complete the queue of events including the refresh)
        '
        CheckProgressBar.Refresh()
        Application.DoEvents()
    End Sub



    Private Sub checkButtonHelper()
        Dim courselist As New List(Of String)
        Dim rawList As String()

        Dim sep As Char() = {","c, ";"c}
        Dim s As String
        Dim matchList As New List(Of String)
        Dim courses As New List(Of String)
        Dim courseName As String = ""
        Dim courseDays As String = ""
        Dim courseTime As String = ""
        Dim courseRoom As String = ""
        Dim numDays As Integer
        Dim numOnline As Integer
        Dim timeOnCampus As Integer
        Dim starttime As Integer = -1
        Dim endtime As Integer = -1
        Dim toolTips As New List(Of String)
        Dim thisRow As Integer
        Dim daysWithOnline, daysWithoutOnline As Integer

        '
        '  Disable button
        '
        checkButton.Enabled = False
        checkButton.Refresh()

        CheckProgressBar.Visible = True
        CheckProgressBar.BringToFront()

        extraDataLabel.Visible = False

        Application.DoEvents()

        rawList = coursesBox.Text.Split(sep)
        For i = 0 To rawList.Count - 1
            s = rawList(i).Trim

            If (s <> "") Then
                courselist.Add(s)
            End If

        Next




        allMatches = SCHED_DATA.getAllSchedulesForOneSequence(courselist, _
                                                                create_criteria_from_form(),
                                                                AddressOf updateProgress)
        If (allMatches.Count > 0) Then
            errorLabel.Visible = False

            outputDataGridView.Rows.Clear()
            outputDataGridView.Columns.Clear()

            'outputDataGridView.Columns.Add("Seq #", "Seq #")
            'outputDataGridView.Columns(0).Width = 40


            outputDataGridView.Columns.Add("# Days", "# Days")
            outputDataGridView.Columns(0).Width = 40

            outputDataGridView.Columns.Add("# Online", "# Online")
            outputDataGridView.Columns(1).Width = 40

            outputDataGridView.Columns.Add("% In Class", "% In Class")
            outputDataGridView.Columns(2).Width = 40

            outputDataGridView.Columns.Add("Earliest Start", "Earliest Start")
            outputDataGridView.Columns(3).Width = 60

            outputDataGridView.Columns.Add("Latest End", "Latest End")
            outputDataGridView.Columns(4).Width = 60

            For i As Integer = 0 To courselist.Count - 1
                outputDataGridView.Columns.Add(courselist(i), courselist(i))
                'outputDataGridView.Columns.Add(courselist(i) & "-time", "Date/Time")
            Next

            For j As Integer = 0 To allMatches.Count - 1
                Dim earlieststart As Integer = -1
                Dim latestend As Integer = -1

                matchList.Clear()
                courses.Clear()
                toolTips.Clear()

                earlieststart = -1
                latestend = -1

                'matchList.Add((j + 1).ToString)

                If (j Mod 5 = 0) Then
                    updateProgress(50 + (40 * j / allMatches.Count))
                End If

                SCHED_DATA.computeDaysAndOnline(allMatches(j), numDays, numOnline, timeOnCampus)

                matchList.Add(numDays.ToString)
                toolTips.Add(numDays.ToString)

                matchList.Add(numOnline.ToString)
                toolTips.Add(numOnline.ToString)

                'matchList.Add(DurationIntToStr(timeOnCampus))
                matchList.Add(timeOnCampus.ToString & "%")
                toolTips.Add("(similar to a layover in a flight)")

                toolTips.Add("Earliest time on any day")
                toolTips.Add("Latest time on any day")

                For i As Integer = allMatches(j).Count - 1 To 0 Step -1
                    SCHED_DATA.getCourseData(allMatches(j)(i), _
                                               courseName, courseDays, courseRoom, _
                                               starttime, endtime)

                    courseTime = TimeIntToStr(starttime)
                    courseDays = courseDays.Replace(".", "")

                    If (courseTime.Contains(" ")) Then
                        courseTime = courseTime.Substring(0, courseTime.IndexOf(" "))
                    End If

                    If (courseDays = "") Then

                        courses.Add("Online (" & courseName & ")")
                        toolTips.Add("Online (" & courseName & ")")

                    Else

                        courses.Add(courseDays & "@" & courseTime & " (" & courseName & ")")
                        toolTips.Add(courseName & " " & courseDays & "@" & _
                                     TimeIntToStr(starttime) & "-" & TimeIntToStr(endtime))

                    End If

                    earlieststart = newMin(earlieststart, starttime)
                    latestend = newMax(latestend, endtime)
                Next

                matchList.Add(TimeIntToStr(earlieststart))
                matchList.Add(TimeIntToStr(latestend))
                matchList.AddRange(courses)

                outputDataGridView.Rows.Add(matchList.ToArray())
                thisRow = outputDataGridView.Rows.Count - 1

                For i As Integer = 0 To toolTips.Count - 1
                    outputDataGridView.Rows(thisRow).Cells(i).ToolTipText = toolTips(i)
                Next

                outputDataGridView.Rows(thisRow).Tag = j
            Next

            'outputDataGridView.Sort(outputDataGridView.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
            outputDataGridView.Sort(mycompare)

            SCHED_DATA.MaxDaysForSchedule(allMatches, daysWithOnline, daysWithoutOnline)

            extraDataLabel.Text = "Total of " & allMatches.Count.ToString & " possible schedules" & vbCrLf

            If (Not onlineRadioButton.Checked) Then
                extraDataLabel.Text &= "Min. " & daysWithOnline.ToString & " days on campus"

                If (eitherRadioButton.Checked) Then
                    extraDataLabel.Text &= " (if allowed to use online sections)"
                End If

                extraDataLabel.Text &= vbCrLf

                If (eitherRadioButton.Checked) Then
                    If (daysWithoutOnline < 0) Then
                        extraDataLabel.Text &= "Cannot schedule without using online sections"
                    Else
                        extraDataLabel.Text &= "Min. " & daysWithoutOnline.ToString & " days on campus (without using online sections)"
                    End If
                End If

            End If

        Else
            errorLabel.Text = "No schedules matched the course list"
            extraDataLabel.Text = ""
            errorLabel.Visible = True

            outputDataGridView.Rows.Clear()
            outputDataGridView.Columns.Clear()
        End If

        CheckProgressBar.Visible = False
        extraDataLabel.Visible = True

        '
        '  Re-enable button
        '
        checkButton.Enabled = True
    End Sub


    Private Sub checkButton_Click(sender As System.Object, e As System.EventArgs) Handles checkButton.Click
        '
        '  Use a try block (in-case someone exists before the check button completes)
        '
        Try
            checkButtonHelper()
        Catch ex As Exception
            MsgBox("ShowPotentialSchedules - check failed" & vbCrLf & ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub outputDataGridView_CellMouseDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles outputDataGridView.CellMouseDoubleClick
        Dim row As Integer
        Dim j As Integer
        Dim oneSchedWindow As New ShowOneSchedule

        row = e.RowIndex
        j = outputDataGridView.Rows(row).Tag

        oneSchedWindow.classList = allMatches(j)
        oneSchedWindow.Show()
    End Sub

    Private Sub NotFullCheckBox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles NotFullCheckBox.CheckedChanged
        '
        '   Save the change only if the user could change it...
        '
        If (NotFullCheckBox.Enabled) Then
            My.Settings.LastFullSearchOption = NotFullCheckBox.Checked
        End If

    End Sub


    ''
    ''  Code based on 
    ''
    ''  http://msdn.microsoft.com/en-us/library/system.windows.forms.datagridview.columnheadermouseclick%28v=vs.110%29.aspx?cs-save-lang=1&cs-lang=vb#code-snippet-2
    ''
    'Private Sub outputDataGridView_ColumnHeaderMouseClick(ByVal sender As Object, _
    'ByVal e As DataGridViewCellMouseEventArgs) _
    'Handles outputDataGridView.ColumnHeaderMouseClick

    '    Dim newColumn As DataGridViewColumn = _
    '        outputDataGridView.Columns(e.ColumnIndex)
    '    Dim oldColumn As DataGridViewColumn = outputDataGridView.SortedColumn
    '    Dim direction As System.ComponentModel.ListSortDirection

    '    ' If oldColumn is null, then the DataGridView is not currently sorted. 
    '    If oldColumn IsNot Nothing Then

    '        ' Sort the same column again, reversing the SortOrder. 
    '        If oldColumn Is newColumn AndAlso outputDataGridView.SortOrder = _
    '            SortOrder.Ascending Then
    '            direction = System.ComponentModel.ListSortDirection.Descending
    '        Else

    '            ' Sort a new column and remove the old SortGlyph.
    '            direction = System.ComponentModel.ListSortDirection.Ascending
    '            oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None
    '        End If
    '    Else
    '        direction = System.ComponentModel.ListSortDirection.Ascending
    '    End If

    '    ' Sort the selected column.
    '    outputDataGridView.Sort(newColumn, direction)

    '    If direction = System.ComponentModel.ListSortDirection.Ascending Then
    '        newColumn.HeaderCell.SortGlyphDirection = SortOrder.Ascending
    '    Else
    '        newColumn.HeaderCell.SortGlyphDirection = SortOrder.Descending
    '    End If

    'End Sub

    'Private Sub outputDataGridView_DataBindingComplete(ByVal sender As Object, _
    '    ByVal e As DataGridViewBindingCompleteEventArgs) _
    '    Handles outputDataGridView.DataBindingComplete

    '    ' Put each of the columns into programmatic sort mode. 
    '    For Each column As DataGridViewColumn In outputDataGridView.Columns
    '        column.SortMode = DataGridViewColumnSortMode.Programmatic
    '    Next
    'End Sub


    Private Sub ResultsContextMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ResultsContextMenu.Opening
        Dim numResults As Integer = outputDataGridView.Rows.Count

        copyOneRow.Enabled = (numResults >= 1)
        copyOneRow.Enabled = False          ' TODO:  Implement this one

        copyTenRows.Enabled = (numResults >= 10)
        copy100rows.Enabled = (numResults >= 100)

    End Sub


    Private Sub copyTenRows_Click(sender As Object, e As System.EventArgs) Handles copyTenRows.Click
        copyDataGridViewToClipboard(outputDataGridView, , 10)
    End Sub

    Private Sub copy100rows_Click(sender As Object, e As System.EventArgs) Handles copy100rows.Click
        copyDataGridViewToClipboard(outputDataGridView, , 100)
    End Sub

    Private Sub CopyAllRowsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyAllRowsToolStripMenuItem.Click
        copyDataGridViewToClipboard(outputDataGridView)
    End Sub

    Private Sub CopyFirst4RowsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyFirst4RowsToolStripMenuItem.Click
        copyDataGridViewToClipboard(outputDataGridView, 5, 4)
    End Sub
End Class