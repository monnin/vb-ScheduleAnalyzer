Public Class ShowOneSchedule
    Public classList As List(Of Integer)
    Private shortdays() As String = {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"}
    Private longdays() As String = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"}

    Class reportData
        Implements IComparable(Of reportData)

        Public starttime As Integer
        Public days As String
        Public line As String

        Public Function CompareTo(xrd As reportData) As Integer Implements IComparable(Of reportData).CompareTo
            Dim result As Integer = 0

            If (xrd.starttime > starttime) Then
                result = -1
            ElseIf (xrd.starttime < starttime) Then
                result = 1
            End If

            Return result
        End Function
    End Class



    'Private Function compareReport()

    Private Sub ShowOneSchedule_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim i, j As Integer
        Dim s As String = ""
        Dim name As String = ""
        Dim days As String = ""
        Dim room As String = ""
        Dim starttime As Integer
        Dim title As String
        Dim endtime As Integer
        Dim l As New List(Of reportData)
        Dim reportedData As reportData

        If (classList IsNot Nothing) Then
            For i = 0 To classList.Count - 1
                SCHED_DATA.getCourseData(classList(i), name, days, room, starttime, endtime, 0)

                If (days = "") Then
                    s = name & vbCrLf
                Else
                    s = name & vbTab & room & vbTab & TimeIntToStr(starttime) & " - " & TimeIntToStr(endtime)
                End If
 
                reportedData = New reportData

                reportedData.days = days
                reportedData.line = s
                reportedData.starttime = starttime
                l.Add(reportedData)
            Next
        End If

        l.Sort()

        s = ""

        For j = 0 To shortdays.Count - 1
            title = vbTab & vbTab & longdays(j) & vbCrLf & vbCrLf

            For i = 0 To l.Count - 1
                If (l(i).days.Contains(shortdays(j))) Then
                    If (title <> "") Then
                        If (s <> "") Then
                            s &= vbCrLf
                        End If

                        s &= title
                        title = ""
                    End If

                    s &= l(i).line & vbCrLf
                End If

            Next i
        Next j

        title = vbTab & vbTab & "Online Courses" & vbCrLf & vbCrLf
        For i = 0 To l.Count - 1
            If (l(i).days = "") Then
                If (title <> "") Then
                    If (s <> "") Then
                        s &= vbCrLf
                    End If

                    s &= title
                    title = ""
                End If

                s &= l(i).line & vbCrLf
            End If
        Next i

        TextBox1.Text = s
        TextBox1.Select(0, 0)
    End Sub

    Private Sub closeButton_Click(sender As System.Object, e As System.EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub
End Class