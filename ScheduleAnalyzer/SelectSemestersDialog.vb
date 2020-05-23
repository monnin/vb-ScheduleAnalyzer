Imports System.Windows.Forms

Public Class SelectSemestersDialog
    Public selectedSemesters As String = ""
    Private semesters As String() = SCHED_DATA.get_semesters()

    Private Sub load_semester_table()
        Dim cb As CheckBox
        Dim row As Integer = 0
        Dim col As Integer = 0
        Dim starting As String = My.Settings.lastSemestersChecked
        '
        '  Stop making updates while we create the table
        '
        semesterTable.SuspendLayout()

        '
        '  Remove the horizontal scrollbar
        '
        '   http://stackoverflow.com/questions/2197452/how-to-disable-horizontal-scrollbar-for-table-panel-in-winforms
        '
        semesterTable.Padding = New Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0)

        semesterTable.Controls.Clear()
        semesterTable.RowStyles.Clear()


        For i As Integer = 0 To semesters.Count - 1
            cb = New CheckBox
            cb.Text = semesters(i)
            cb.Checked = starting.Contains("/" & cb.Text & "/")

            ' cb.Dock = DockStyle.Top + DockStyle.Left

            semesterTable.Controls.Add(cb, col, row)

            col = col + 1

            If (col > 2) Then
                col = 0
                row = row + 1
            End If
        Next


        For i As Integer = 0 To row
            semesterTable.RowStyles.Add(New RowStyle(SizeType.Absolute, Me.Font.Height() + 10))
        Next

        semesterTable.ResumeLayout()

    End Sub


    '
    '  Converts the various checkboxes into a single string
    '    of the format /<semster>/<semester/.../
    '
    Function tablelayouttostring() As String
        Dim s As String = ""
        Dim cb As CheckBox

        '
        '  Load the HASHSET
        '
        For Each c As Control In semesterTable.Controls
            cb = TryCast(c, CheckBox)

            If (cb IsNot Nothing) Then
                If (cb.Checked) Then
                    s = s & "/" & cb.Text
                End If
            End If
        Next

        If (s <> "") Then
            s &= "/"
        End If

        Return s
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        selectedSemesters = tablelayouttostring()

        My.Settings.lastSemestersChecked = selectedSemesters

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SelectSemestersDialog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        load_semester_table()
    End Sub
End Class
