Public Class FindFreeRoom

    '
    '   FindFreeRoom
    '
    '   This is the user interface to find rooms that are available at a specific
    '   time.  It is mostly a front end to the "FindRoom" routine in ScheduleData.vb
    '
    '

    '
    '   findButton
    '
    '   Go do the work, and display the results
    '
    Private Sub findButton_Click(sender As System.Object, e As System.EventArgs) Handles findButton.Click
        Dim minRoom As Integer = 0
        Dim ok As Boolean = True
        Dim hash As New HashSet(Of String)

        hash = tablelayouttohash(capabilitiesTable)

        '
        '  Min size specified?  If so, then set it 
        '
        If (minSizeBox.Text.Trim <> "") Then
            ok = Integer.TryParse(minSizeBox.Text, minRoom)

            If (Not ok) Then
                MsgBox("Invalid minimum room size - please enter a number (or 0 or blank for all rooms)", _
                         MsgBoxStyle.Exclamation, "Invalid number")
            End If
        End If

        If (ok) Then
            ResultBox.Text = FindRoom(daysBox.Text, startTimeBox.Text, endTimeBox.Text, _
                                      minRoom, My.Settings.DefaultRoomSize, _
                                      hash, matchAllRB.Checked)
        End If

    End Sub

    '
    '   startTimeBox (SelectedIndexChanged event)
    '
    '   If the person uses the pulldown for the start time, automatically match
    '   the end time too.  (Note: if the user types in a value, then this routine
    '   is not called)
    '
    Private Sub startTimeBox_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles startTimeBox.SelectedIndexChanged
        Dim si As Integer
        si = startTimeBox.SelectedIndex

        '
        '  Protect against the endTimeBox having an incorrect # of items
        '   ("just in case", but it did happen to me...)
        '
        If (si <= endTimeBox.Items.Count - 1) Then
            endTimeBox.SelectedIndex = startTimeBox.SelectedIndex
        End If

    End Sub


    Sub load_capabilities()
        Dim row As Integer = 0
        Dim col As Integer = 0
        Dim count As Integer

        count = load_capabilities_table(capabilitiesTable, Me)

        If (count = 0) Then
            capabilitiesLabel.Visible = True

            capabilitiesTable.Visible = False
            minSizeBox.Visible = False
            initialLabel.Visible = False
            endInitialLabel.Visible = False
            matchAllRB.Visible = False
            matchAnyRB.Visible = False
        Else
            capabilitiesLabel.Visible = False

            capabilitiesTable.Visible = True
            minSizeBox.Visible = True
            initialLabel.Visible = True
            endInitialLabel.Visible = True
            matchAllRB.Visible = True
            matchAnyRB.Visible = True
        End If
    End Sub

    Private Sub FindFreeRoom_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        load_capabilities()
    End Sub

 
End Class