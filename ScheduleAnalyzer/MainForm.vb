Option Strict On

Public Class MainForm

    Dim lastSpreadsheet As String = ""      ' This is the filename of the spreadsheet we
                                            ' just opened.  We can use it to re-open/re-test
                                            ' it if desired

    Dim myListViewColumnSorter As New ListViewColumnSorter
    Dim facCountListViewColumnSorter As New ListViewColumnSorter

    Private Function severityCompare(ByVal a As String, ByVal b As String) As Integer
        Dim result As Integer = 0

        If (a <> b) Then

            If (a = "Error") Then
                result = -1
            ElseIf (b = "Error") Then
                result = 1
            ElseIf (a = "Alert") Then
                result = -1
            ElseIf (b = "Alert") Then
                result = 1
            ElseIf (a = "Warning") Then
                result = -1
            ElseIf (b = "Warning") Then
                result = 1
            ElseIf (a = "Information") Then
                result = -1
            ElseIf (b = "Information") Then
                result = 1
            Else
                result = String.Compare(a, b)
            End If
        End If

        Return result
    End Function
    '
    '   (Form Load Event)
    '
    '  Load the settings into the form
    '
    Private Sub MainForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        showHideBoxes(False)

        facultyLabel.Text = "Faculty With Course Load > " & My.Settings.FacultyLimit.ToString

        '
        '   Configure the Settings menu
        '
        ShowCourseLengthWarningsToolStripMenuItem.Checked = My.Settings.ShowTimes
        ShowSequenceWarningsToolStripMenuItem.Checked = My.Settings.ShowSequenceWarnings
        AllowGhostSectionsForSequencesToolStripMenuItem.Checked = My.Settings.allowGhosts
        '-----
        UseOpenSpreadsheetifPossibleToolStripMenuItem.Checked = My.Settings.UseOpenFile
        '-----
        IncludeInformationalResultsToolStripMenuItem.Checked = My.Settings.includeInfoResults
        CheckCourseMeetsContactHoursMinimumToolStripMenuItem.Checked = My.Settings.checkContactHours
        '-----

        '
        '
        SCHED_DATA.set_worksheet_names(My.Settings.ScheduleTab, My.Settings.SequenceTab, My.Settings.capabilitiesTab)

        '
        '  Handle the main listview
        '
        myListViewColumnSorter.addColumnCompare(1, AddressOf severityCompare)
        myListViewColumnSorter.SortColumn = 1
        myListViewColumnSorter.Order = SortOrder.Ascending

        outputView.ListViewItemSorter = myListViewColumnSorter

        myListViewColumnSorter = New ListViewColumnSorter

        '
        '  Handle the faculty listview
        '
        facCountListViewColumnSorter.SortColumn = 1
        facCountListViewColumnSorter.Order = SortOrder.Descending

        facCountView.ListViewItemSorter = facCountListViewColumnSorter

    End Sub

    '
    '   updateProgress(percent)
    '
    '   This acts as a "callback" from ScheduleData's load functions so that
    '   the user can see how long the event is taking (especially useful for
    '   large spreadsheets and slow computers)
    '

    Private Delegate Sub updateProgressDelegate(ByVal percent As Integer, ByVal substatus As String, ByVal noinvoke As Boolean)

    Private Sub updateProgress(ByVal percent As Integer, ByVal substatus As String, Optional ByVal noinvoke As Boolean = False)
        If (percent > 100) Then
            percent = 100
        End If

        If (Me.InvokeRequired) Then
            If (Not noinvoke) Then
                ' Me.Invoke(New updateProgressDelegate(AddressOf updateProgress), percent, substatus, True)
            End If
        Else
            LargeProgressBar.Value = percent

            '
            '   Since the actual GUI event is still going on, we need to force
            '   a refresh (and complete the queue of events including the refresh)
            '
            LargeProgressBar.Refresh()

            SubStatusLabel.Text = substatus
            SubStatusLabel.Refresh()

            ' Application.DoEvents()
        End If

    End Sub


    Private Sub addMessages(ByVal listOfMessages As List(Of scheduleMessage))
        Dim item As ListViewItem
        Dim subitems(6) As String

        For i As Integer = 0 To listOfMessages.Count - 1
            subitems(0) = listOfMessages(i).type
            subitems(1) = listOfMessages(i).severity
            subitems(2) = listOfMessages(i).description
            subitems(3) = listOfMessages(i).text1
            subitems(4) = listOfMessages(i).loc1
            subitems(5) = listOfMessages(i).text2
            subitems(6) = listOfMessages(i).loc2

            If (subitems(2) <> "") Then
                '
                '  Ignore the informational items if desired
                '
                If ((IncludeInformationalResultsToolStripMenuItem.Checked) Or (listOfMessages(i).severity.Substring(0, 1) <> "I")) Then
                    item = New ListViewItem(subitems)
                    outputView.Items.Add(item)
                End If

            End If
        Next
    End Sub


    Private Sub showHideBoxes(ByVal vis As Boolean)
        outputView.Visible = vis
        outputLabel.Visible = vis
        facultyLabel.Visible = vis
        facCountView.Visible = vis

        logoPictureBox.Visible = Not vis
        Me.Refresh()
    End Sub



    '
    '   LoadListBox
    '
    Private Sub LoadListBox(ByVal linesOfText As String)
        Dim lines As String()
        Dim i As Integer

        linesOfText = linesOfText.Replace(vbLf, "")
        lines = linesOfText.Split(Chr(10))

        For i = 0 To lines.Count - 1
            If (lines(i) <> "") Then
                outputView.Items.Add(lines(i))
            End If

        Next

    End Sub

    Sub showFacCount(ByVal hideAtOrBelow As Integer)
        Dim l As List(Of oneFacCount)
        Dim one As oneFacCount
        Dim item As ListViewItem
        Dim subitems(1) As String

        l = SCHED_DATA.countFaculty(My.Settings.FacultyLimit)

        facCountView.Items.Clear()

        For Each one In l
            If (one.name.Trim = "") Then
                subitems(0) = "<blank>"
            Else
                subitems(0) = one.name
            End If

            subitems(1) = one.count.ToString.PadLeft(3)

            item = New ListViewItem(subitems)

            facCountView.Items.Add(item)

        Next
    End Sub




    '
    '   TestAll(filename)
    '
    '   Routine to run (or re-run) the test on a single Excel spreadsheet
    '
    Private Sub TestAll(filename As String)
        Dim mySemesters As String = ""

        My.Settings.Save()          ' Force a saving of the settings (mostly for me during debugging)

        '
        '  Update the status box for now (and force a refresh)
        '
        StatusBox.Text = "Loading the Data...  Please wait..."
        StatusBox.Refresh()


        '
        '   Show the progress bar and it's related title
        '
        workingLabel.Text = "Loading Data..."
        workingLabel.Visible = True


        LargeProgressBar.Visible = True
        SubStatusLabel.Visible = True

        '
        '  Step 1 - Try to load the file, if it fails provide feedback to the user
        '
        If (SCHED_DATA.loadData(filename, My.Settings.UseOpenFile, AddressOf updateProgress) = False) Then

            StatusBox.Text = SCHED_DATA.errStr

        Else
            '
            '  Step 2 - Analyze the data
            '

            '
            '   Reset the progress bar and give it a new title
            '
            workingLabel.Text = "Examining Data..."
            updateProgress(0, "Starting")

            outputView.Items.Clear()

            '
            '   Update the status box with any warnings, 
            '       and the count of sections found
            '
            StatusBox.Text = SCHED_DATA.errStr & vbCrLf _
                            & "# of Sections: " & SCHED_DATA.numSections().ToString

            StatusBox.Text &= vbCrLf & "# of Rooms: " & SCHED_DATA.rooms.roomCapCount().ToString

            If (SCHED_DATA.rooms.roomCapCount() > 0) Then
                StatusBox.Text &= " (" & SCHED_DATA.rooms.roomCapCount() & " rooms had a total of " & SCHED_DATA.rooms.capCount() & " capabilities)"
            End If

            If (ShowSequenceWarningsToolStripMenuItem.Checked) Then
                StatusBox.Text = StatusBox.Text & vbCrLf & _
                    "# of Sequences: " & SCHED_DATA.numSequences

                '
                '  Ask which semesters if more than one is possible
                '
                If (SCHED_DATA.get_num_semesters() > 1) Then
                    If (SelectSemestersDialog.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                        mySemesters = SelectSemestersDialog.selectedSemesters
                    End If
                End If

            End If


            '
            '   Step 2.1 - Find Faculty with high loads
            '
            showFacCount(My.Settings.FacultyLimit)

            updateProgress(25, "Finding Overlaps")
            '
            '   Step 2.2 - Find room/instructor clashes
            '
            addMessages(SCHED_DATA.findOverlaps())



            If (ShowCourseLengthWarningsToolStripMenuItem.Checked) Then
                '
                '   Step 2.3 - Optionally find sections with "weird" times
                '
                updateProgress(50, "Finding Odd Sections")

                addMessages(SCHED_DATA.findOddSections())
            End If


            '
            '  Step 2.4 - Find time, no date (or date, no time) sections
            '
            updateProgress(60, "Finding Invalid Date/Time Info")
            addMessages(SCHED_DATA.findOddTimes())

            If (ShowSequenceWarningsToolStripMenuItem.Checked) Then
                updateProgress(75, "Finding Missing Sequences")
                addMessages(SCHED_DATA.findMissingSequences(mySemesters))
            End If

            updateProgress(100, "")
        End If

        outputView.Sort()

        '
        '   Done - So hide the progress bar and it's related title
        '
        workingLabel.Visible = False
        LargeProgressBar.Visible = False
        SubStatusLabel.Visible = False
    End Sub

    '
    '   openFile
    '
    '   Bring up an Open File Dialog, and then read the file, and then enable some more buttons
    '
    Private Sub openFile()
        Dim od As New OpenFileDialog




        '
        '   Bring up the Open File dialog box
        '
        od.Filter = "Excel Spreadsheet Files (*.xls)|*.xls;*.xlsx|All Files (*.*)|*.*"

        '
        '  If they didn't cancel, then open the file...
        '
        If (od.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            startHerePictureBox.Visible = False

            showHideBoxes(False)

            '
            '  Read and run the tests
            '
            lastSpreadsheet = od.FileName
            TestAll(od.FileName)


            '
            '   Enable the extra testing buttons
            '
            retestButton.Enabled = True

            ' freeRoom.Enabled = True
            findTimeButton.Enabled = True


            '
            '   Enable the extra testing menu items
            '
            ReLoadTestToolStripMenuItem.Enabled = True
            ' FreeRoomToolStripMenuItem.Enabled = True
            FreeTimeToolStripMenuItem.Enabled = True

            FindAllSchedulesThatMatchToolStripMenuItem.Enabled = True
            findSchedulesButton.Enabled = True

            showHideBoxes(True)
        End If

    End Sub

    '
    '       UpdateFacLimit()
    '
    '       Bring up an InputBox to ask the user for a new limit, and
    '       update the internal value if a good number is given
    '
    Private Sub UpdateFacLimit()
        Dim newLimit As Integer
        Dim response As String

        '
        '   Ask the user for a new limit (but default to the current limit)
        '
        response = InputBox("Enter limit for faculty sections", _
                            "Display Faculty With High Course Loads", _
                            My.Settings.FacultyLimit.ToString)

        '
        '  Make sure the user entered a number
        '
        If (Integer.TryParse(response, newLimit)) Then
            '
            '  Numbers less than 0 also make no sense
            '
            If (newLimit >= 0) Then
                My.Settings.FacultyLimit = newLimit

                facultyLabel.Text = "Faculty With Course Load > " & _
                                    My.Settings.FacultyLimit.ToString

                showFacCount(My.Settings.FacultyLimit)
            End If
        End If
    End Sub

    
    '
    '------------------------hidden click events------------
    '

    '
    '    Clicking on the Faculty limit label is the same as using the menu
    '
    Private Sub facultyLabel_Click(sender As System.Object, e As System.EventArgs) Handles facultyLabel.Click
        UpdateFacLimit()
    End Sub



   
    '
    '   See http://support.microsoft.com/kb/319401
    '
    Private Sub outputView_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles outputView.ColumnClick
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

        outputView.Sort()

    End Sub

    Private Sub outputView_DrawColumnHeader(sender As Object, e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles outputView.DrawColumnHeader
        Dim flags As TextFormatFlags = TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
        Dim s As String = e.Header.Text

        e.DrawBackground()

        If ((e.ColumnIndex = 1) And (e.Bounds.Width < 30)) Then
            e.Graphics.DrawString(" " & s.Substring(0, 1), e.Font, Brushes.Black, e.Bounds)
        Else
            e.DrawText(flags)
        End If
    End Sub

    Private Sub outputView_DrawSubItem(sender As Object, e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles outputView.DrawSubItem
        Dim flags As TextFormatFlags = TextFormatFlags.Left Or TextFormatFlags.EndEllipsis
        Dim s As String = e.SubItem.Text
        Dim fnt As Font

        If (e.Item.Selected) Then
            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds)
        ElseIf (e.ColumnIndex = 1) Then

            Select Case s.Substring(0, 1).ToUpper
                Case "A"
                    e.Graphics.FillRectangle(Brushes.Orange, e.Bounds)
                Case "W"
                    e.Graphics.FillRectangle(Brushes.Yellow, e.Bounds)
                Case "I"
                    e.Graphics.FillRectangle(Brushes.LightGreen, e.Bounds)
                Case "E"
                    e.Graphics.FillRectangle(Brushes.Red, e.Bounds)
                Case Else
                    e.DrawBackground()
            End Select

        Else

            e.DrawBackground()
        End If


        If (e.ColumnIndex = 1) Then
            fnt = e.SubItem.Font

            '
            '  Bold the alerts
            '
            If ((s.Substring(0, 1).ToUpper = "A") Or (s.Substring(0, 1).ToUpper = "E")) Then
                fnt = New Font(fnt, FontStyle.Bold)
            End If

            If (e.Bounds.Width < 30) Then
                e.Graphics.DrawString(" " & s.Substring(0, 1), fnt, Brushes.Black, e.Bounds)
            Else
                'e.DrawText(flags)
                e.Graphics.DrawString(" " & s, fnt, Brushes.Black, e.Bounds, New StringFormat(StringFormatFlags.NoWrap))
            End If

        Else
            e.DrawText(flags)
        End If

    End Sub


    Private Sub outputView_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles outputView.MouseDoubleClick
        Dim jf As JumpForm
        Dim i As ListViewItem

        For Each i In outputView.SelectedItems
            jf = New JumpForm

            jf.ShowChoices(lastSpreadsheet, i.SubItems(2).Text,
                           i.SubItems(4).Text, i.SubItems(6).Text, _
                            i.SubItems(3).Text, i.SubItems(5).Text)
        Next

    End Sub




    '
    '   See http://support.microsoft.com/kb/319401
    '
    Private Sub facCountView_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles facCountView.ColumnClick

        If (e.Column = facCountListViewColumnSorter.SortColumn) Then
            '
            '  Reverse the order if the column is clicked a second (or third...) time
            '
            If (facCountListViewColumnSorter.Order = SortOrder.Ascending) Then
                facCountListViewColumnSorter.Order = SortOrder.Descending
            Else
                facCountListViewColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            facCountListViewColumnSorter.Order = SortOrder.Ascending
            facCountListViewColumnSorter.SortColumn = e.Column
        End If

        facCountView.Sort()

    End Sub

    Private Sub facCountView_mouseDoubleClick(sender As Object, e As System.EventArgs) Handles facCountView.MouseDoubleClick
        Dim fac As String
        Dim f As ShowFacultyCourses

        For Each i As ListViewItem In facCountView.SelectedItems
            fac = i.SubItems(0).Text

            f = New ShowFacultyCourses
            f.initialFacName = fac
            f.lastSpreadsheet = lastSpreadsheet

            f.Show()
        Next


    End Sub

    '
    '  From http://social.msdn.microsoft.com/Forums/en-US/ed70b8d7-a179-42a3-adbd-7eb75ae42635/listview-resize-multi-columns
    '
    Private Sub facCountView_Resize(sender As Object, e As System.EventArgs) Handles facCountView.Resize
        Dim column As Integer
        Dim w As Integer = 0
        Dim resizeColumn As Integer = 0

        For column = 0 To facCountView.Columns.Count - 1
            If (column <> resizeColumn) Then
                w += facCountView.Columns(column).Width
            End If
        Next

        w = facCountView.ClientSize.Width - w - 1 - SystemInformation.VerticalScrollBarWidth

        If (w > 0) Then
            facCountView.Columns(resizeColumn).Width = w
        End If
    End Sub

    Private Function senderToListView(ByRef sender As Object) As ListView
        Dim ts As ToolStripMenuItem = Nothing
        Dim cs As ContextMenuStrip = Nothing
        Dim ctrl As Control = Nothing
        Dim lv As ListView = Nothing

        ts = TryCast(sender, ToolStripMenuItem)

        If (ts IsNot Nothing) Then
            cs = TryCast(ts.Owner, ContextMenuStrip)
        End If

        If (cs IsNot Nothing) Then
            ctrl = cs.SourceControl
        End If

        If (ctrl IsNot Nothing) Then
            lv = TryCast(ctrl, ListView)
        End If

        Return lv
    End Function

    Private Sub copyMenuItem_Click(sender As Object, e As System.EventArgs) Handles copyMenuItem.Click
        Dim lv As ListView = senderToListView(sender)

        If (Object.ReferenceEquals(lv, outputView)) Then
            copyListViewToClipboard(lv, 3)
        Else
            copyListViewToClipboard(lv)
        End If

    End Sub



    Private Sub printMenuItem_Click(sender As Object, e As System.EventArgs) Handles printMenuItem.Click
        Dim lv As ListView = senderToListView(sender)

        If (Object.ReferenceEquals(lv, outputView)) Then
            printView(lv, True, "Warnings and Errors", longdatetime(), 3)
        Else
            printView(lv, True, "", longdatetime())
        End If
    End Sub

#Region "Buttons"

    '
    '--------------------------buttons------------------------------------
    '

    '
    '   Open Button
    '
    Private Sub openButton_Click(sender As System.Object, e As System.EventArgs) Handles openButton.Click
        openFile()
    End Sub

    '
    '   Retest Button
    '
    Private Sub retestButton_Click(sender As System.Object, e As System.EventArgs) Handles retestButton.Click
        showHideBoxes(False)
        TestAll(lastSpreadsheet)
        showHideBoxes(True)
    End Sub

    '
    '   Find Empty Room...
    '
    'Private Sub freeRoom_Click(sender As System.Object, e As System.EventArgs)
    '   FindFreeRoom.Show()
    'End Sub

    '
    '   Find Empty Time...
    '
    Private Sub findTimeButton_Click(sender As System.Object, e As System.EventArgs) Handles findTimeButton.Click
        FindTime.Show()
        FindTime.BringToFront()
    End Sub

    Private Sub findSchedulesButton_Click(sender As System.Object, e As System.EventArgs) Handles findSchedulesButton.Click
        ShowPotentialSchedules.Show()
        ShowPotentialSchedules.BringToFront()
    End Sub

#End Region

#Region "Menu Items"

    '
    '------------------menu items--------------------------------------------
    '
#Region "Menu Items - File"
    '
    '   File...
    '

    '
    '           File->Open...
    '
    Private Sub OpenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        openFile()
    End Sub

    '
    '           File->Re-Load and Test
    '
    Private Sub ReLoadTestToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReLoadTestToolStripMenuItem.Click
        TestAll(lastSpreadsheet)
    End Sub

    '
    '           File->Exit
    '
    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

#End Region

#Region "Menu Items - Edit"

    '
    '   Edit
    '

    '
    '       Edit->Copy Conflicts and Warnings to Clipboard
    '
    Private Sub CopyConflictsAndWarningsToClipboardToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyConflictsAndWarningsToClipboardToolStripMenuItem.Click
        copyListViewToClipboard(outputView, 3)
    End Sub

    '
    '   Edit->Copy Course Load List to Clipboard
    '
    Private Sub CopyCourseLoadListToClipboardToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyCourseLoadListToClipboardToolStripMenuItem.Click
        copyListViewToClipboard(facCountView)
    End Sub

#End Region

#Region "Menu Items - Find"
    '
    '   Find...
    '

    '
    '           Find->Find Time for a Class...
    '
    Private Sub FreeTimeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FreeTimeToolStripMenuItem.Click
        FindTime.Show()
        FindTime.BringToFront()
    End Sub

    '
    '           Find->Find All Schedules that Match...
    '
    Private Sub FindAllSchedulesThatMatchToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FindAllSchedulesThatMatchToolStripMenuItem.Click
        ShowPotentialSchedules.Show()
        ShowPotentialSchedules.BringToFront()
    End Sub

#End Region

#Region "Menu Items - Settings"
    '
    '  Settings...
    '

    '
    '       Settings->Show Sequence Warnings
    '
    Private Sub ShowSequenceWarningsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShowSequenceWarningsToolStripMenuItem.Click
        ShowSequenceWarningsToolStripMenuItem.Checked = Not ShowSequenceWarningsToolStripMenuItem.Checked

        My.Settings.ShowSequenceWarnings = ShowSequenceWarningsToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub


    '
    '       Settings->Show Course Length Warnings
    '
    Private Sub ShowCourseLengthWarningsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ShowCourseLengthWarningsToolStripMenuItem.Click
        ShowCourseLengthWarningsToolStripMenuItem.Checked = Not ShowCourseLengthWarningsToolStripMenuItem.Checked

        My.Settings.ShowTimes = ShowCourseLengthWarningsToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub


    '
    '       Settings->Allow Ghost Sections for Sequences
    '
    Private Sub AllowGhostSectionsForSequencesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AllowGhostSectionsForSequencesToolStripMenuItem.Click
        AllowGhostSectionsForSequencesToolStripMenuItem.Checked = Not AllowGhostSectionsForSequencesToolStripMenuItem.Checked

        My.Settings.allowGhosts = AllowGhostSectionsForSequencesToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub

    '
    '       Settings->Use Open Spreadsheet (when possible)
    '
    Private Sub UseOpenSpreadsheetifPossibleToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UseOpenSpreadsheetifPossibleToolStripMenuItem.Click
        UseOpenSpreadsheetifPossibleToolStripMenuItem.Checked = Not UseOpenSpreadsheetifPossibleToolStripMenuItem.Checked

        My.Settings.ShowTimes = UseOpenSpreadsheetifPossibleToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub

    '
    '       Settings->Include Informational Results
    '
    Private Sub IncludeInformationalResultsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles IncludeInformationalResultsToolStripMenuItem.Click
        IncludeInformationalResultsToolStripMenuItem.Checked = Not IncludeInformationalResultsToolStripMenuItem.Checked

        My.Settings.includeInfoResults = IncludeInformationalResultsToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub

    '
    '       Settings->Check Course Meets Contact Hours Minimum
    '
    Private Sub CheckCourseMeetsContactHoursMinimumToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CheckCourseMeetsContactHoursMinimumToolStripMenuItem.Click
        CheckCourseMeetsContactHoursMinimumToolStripMenuItem.Checked = Not CheckCourseMeetsContactHoursMinimumToolStripMenuItem.Checked

        My.Settings.checkContactHours = CheckCourseMeetsContactHoursMinimumToolStripMenuItem.Checked
        My.Settings.Save()
    End Sub

    '
    '       Settings->Faculty Limit...
    '
    Private Sub FacultyLimitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FacultyLimitToolStripMenuItem.Click
        UpdateFacLimit()
    End Sub

    '
    '       Settings->Excel Settings...
    '
    Private Sub ExcelSettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExcelSettingsToolStripMenuItem.Click
        ExcelSettings.ShowDialog()
    End Sub

#End Region

#Region "Menu Items - Help"
    '
    '   Help...
    '

    '
    '           Help->About...
    '
    Private Sub AboutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        TheAboutBox.ShowDialog()
    End Sub


    '
    '           Help->Release Notes...
    '
    Private Sub ReleaseNotesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReleaseNotesToolStripMenuItem.Click
        ReleaseNotes.Show()
        ReleaseNotes.BringToFront()
    End Sub

    '
    '           Help->YCCC Website
    '
    Private Sub YCCCWebsiteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles YCCCWebsiteToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.yccc.edu")
    End Sub

#End Region

#End Region

End Class
