Option Compare Text

Imports System.Windows.Forms

Public Class ExcelSettings

    Public Function isSheetName(ByVal s As String) As Boolean
        Dim result As Boolean

        Select Case s.Trim
            Case My.Settings.ScheduleTab
                result = True

            Case My.Settings.SequenceTab
                result = True

            Case My.Settings.capabilitiesTab
                result = True

            Case Else
                result = False
        End Select

        Return result
    End Function


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click


        My.Settings.SequenceTab = sequenceBox.Text

        '
        '   Room
        '

        My.Settings.capabilitiesTab = capabilitiesBox.Text
        My.Settings.DefaultRoomSize = roomSizeBox.Value
        My.Settings.MaxCapacityColumn = maxCapacityBox.Text
        My.Settings.RoomCapabilityColumn = firstCapBox.Text
        My.Settings.roomDescription = roomDescription.Text
        My.Settings.notesCol = notesBox.Text
        My.Settings.contactHoursCol = contactHoursBox.Text



        '
        '  Sections settings
        '
        My.Settings.ScheduleTab = scheduleBox.Text

        My.Settings.CourseNumColumn = courseNumBox.Text
        My.Settings.InstructorCol = instructorBox.Text
        My.Settings.DaysCol = daysBox.Text
        My.Settings.TimeCol = timeBox.Text
        My.Settings.RoomCol = roomBox.Text


        My.Settings.CurEnroll = curEnrollBox.Text
        My.Settings.MaxEnroll = maxEnrollBox.Text

        My.Settings.EnrollTypeIsCurEnroll = (enrollTypeBox.SelectedIndex = 0)

        SCHED_DATA.set_worksheet_names(My.Settings.ScheduleTab, My.Settings.SequenceTab, My.Settings.capabilitiesTab)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ExcelSettings_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        loadVals()
    End Sub


    Public Sub loadVals()

        sequenceBox.Text = My.Settings.SequenceTab

        '
        '   Room
        '
        capabilitiesBox.Text = My.Settings.capabilitiesTab
        roomSizeBox.Value = My.Settings.DefaultRoomSize
        maxCapacityBox.Text = My.Settings.MaxCapacityColumn
        firstCapBox.Text = My.Settings.RoomCapabilityColumn
        roomDescription.Text = My.Settings.roomDescription
        notesBox.Text = My.Settings.notesCol
        contactHoursBox.Text = My.Settings.contactHoursCol

        '
        '  Sections settings
        '
        scheduleBox.Text = My.Settings.ScheduleTab

        courseNumBox.Text = My.Settings.CourseNumColumn
        instructorBox.Text = My.Settings.InstructorCol
        daysBox.Text = My.Settings.DaysCol
        timeBox.Text = My.Settings.TimeCol
        roomBox.Text = My.Settings.RoomCol

        maxEnrollBox.Text = My.Settings.MaxEnroll
        curEnrollBox.Text = My.Settings.CurEnroll

        If (My.Settings.EnrollTypeIsCurEnroll) Then
            enrollTypeBox.SelectedIndex = 0
        Else
            enrollTypeBox.SelectedIndex = 1
        End If

    End Sub

    '
    '   resetButton
    '
    '   Change the settings to the default
    '
    Private Sub resetButton_Click(sender As System.Object, e As System.EventArgs) Handles resetButton.Click
        If (MsgBox("Reset all settings to their default values?", MsgBoxStyle.OkCancel, "Are you sure?") = MsgBoxResult.Ok) Then

            My.Settings.Reset()

            loadVals()
        End If

    End Sub

End Class
