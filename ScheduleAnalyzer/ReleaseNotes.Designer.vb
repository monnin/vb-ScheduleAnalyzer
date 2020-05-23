<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReleaseNotes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.closeButton = New System.Windows.Forms.Button()
        Me.NotesBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'closeButton
        '
        Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeButton.Location = New System.Drawing.Point(535, 293)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 0
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'NotesBox
        '
        Me.NotesBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NotesBox.BackColor = System.Drawing.Color.White
        Me.NotesBox.Location = New System.Drawing.Point(12, 12)
        Me.NotesBox.Multiline = True
        Me.NotesBox.Name = "NotesBox"
        Me.NotesBox.ReadOnly = True
        Me.NotesBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.NotesBox.Size = New System.Drawing.Size(598, 275)
        Me.NotesBox.TabIndex = 1
        Me.NotesBox.WordWrap = False
        '
        'ReleaseNotes
        '
        Me.AcceptButton = Me.closeButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 328)
        Me.Controls.Add(Me.NotesBox)
        Me.Controls.Add(Me.closeButton)
        Me.Name = "ReleaseNotes"
        Me.Text = "Release Notes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents NotesBox As System.Windows.Forms.TextBox
End Class
