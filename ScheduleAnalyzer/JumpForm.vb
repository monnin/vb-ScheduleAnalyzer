Public Class JumpForm

    Private loc1, loc2 As String
    Private text1, text2 As String
    Dim filename As String


    Public Sub ShowChoices(ByVal filename As String, ByVal mesg As String, _
                           ByVal loc1 As String, ByVal loc2 As String, _
                           ByVal text1 As String, ByVal text2 As String)
        Me.loc1 = loc1
        Me.loc2 = loc2

        Me.filename = filename

        MesgBox.Text = mesg

        If (text1 <> "") Then
            DescrBox1.Text = text1
            DescrBox1.Visible = True

            If (loc1 <> "") Then
                DescrBox1.Text &= " (@ location " & loc1 & ")"
                ExamineButton1.Visible = True
            End If
        End If


        If (text2 <> "") Then
            DescrBox2.Text = text2
            DescrBox2.Visible = True

            If (loc2 <> "") Then
                DescrBox2.Text &= " (@ location " & loc2 & ")"
                ExamineButton2.Visible = True
            End If
        End If

        Me.Show()

        Me.Left = Cursor.Position.X - (Me.Width \ 2)
        Me.Top = Cursor.Position.Y - (Me.Height \ 2)

    End Sub


    Private Sub okButton_Click(sender As System.Object, e As System.EventArgs) Handles okButton.Click
        Me.Close()
    End Sub

    Private Sub ExamineButton1_Click(sender As System.Object, e As System.EventArgs) Handles ExamineButton1.Click
        GoToSheetAndCell(filename, loc1)
    End Sub

    Private Sub ExamineButton2_Click(sender As System.Object, e As System.EventArgs) Handles ExamineButton2.Click
        GoToSheetAndCell(filename, loc2)
    End Sub
End Class