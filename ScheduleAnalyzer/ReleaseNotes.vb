Public Class ReleaseNotes

    Private Sub closeButton_Click(sender As System.Object, e As System.EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

    Private Sub ReleaseNotes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        NotesBox.Text = My.Resources.ReleaseNotes
    End Sub
End Class