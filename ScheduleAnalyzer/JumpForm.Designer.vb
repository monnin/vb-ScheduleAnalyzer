<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JumpForm
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
        Me.ExamineButton1 = New System.Windows.Forms.Button()
        Me.ExamineButton2 = New System.Windows.Forms.Button()
        Me.DescrBox1 = New System.Windows.Forms.TextBox()
        Me.DescrBox2 = New System.Windows.Forms.TextBox()
        Me.MesgBox = New System.Windows.Forms.TextBox()
        Me.okButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ExamineButton1
        '
        Me.ExamineButton1.Location = New System.Drawing.Point(328, 101)
        Me.ExamineButton1.Name = "ExamineButton1"
        Me.ExamineButton1.Size = New System.Drawing.Size(56, 23)
        Me.ExamineButton1.TabIndex = 0
        Me.ExamineButton1.Text = "Goto"
        Me.ExamineButton1.UseVisualStyleBackColor = True
        Me.ExamineButton1.Visible = False
        '
        'ExamineButton2
        '
        Me.ExamineButton2.Location = New System.Drawing.Point(328, 148)
        Me.ExamineButton2.Name = "ExamineButton2"
        Me.ExamineButton2.Size = New System.Drawing.Size(56, 23)
        Me.ExamineButton2.TabIndex = 1
        Me.ExamineButton2.Text = "Goto"
        Me.ExamineButton2.UseVisualStyleBackColor = True
        Me.ExamineButton2.Visible = False
        '
        'DescrBox1
        '
        Me.DescrBox1.Location = New System.Drawing.Point(12, 101)
        Me.DescrBox1.Name = "DescrBox1"
        Me.DescrBox1.Size = New System.Drawing.Size(310, 20)
        Me.DescrBox1.TabIndex = 2
        Me.DescrBox1.Visible = False
        '
        'DescrBox2
        '
        Me.DescrBox2.Location = New System.Drawing.Point(12, 148)
        Me.DescrBox2.Name = "DescrBox2"
        Me.DescrBox2.Size = New System.Drawing.Size(310, 20)
        Me.DescrBox2.TabIndex = 3
        Me.DescrBox2.Visible = False
        '
        'MesgBox
        '
        Me.MesgBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MesgBox.Location = New System.Drawing.Point(12, 12)
        Me.MesgBox.Multiline = True
        Me.MesgBox.Name = "MesgBox"
        Me.MesgBox.Size = New System.Drawing.Size(372, 70)
        Me.MesgBox.TabIndex = 4
        '
        'okButton
        '
        Me.okButton.Location = New System.Drawing.Point(249, 177)
        Me.okButton.Name = "okButton"
        Me.okButton.Size = New System.Drawing.Size(97, 35)
        Me.okButton.TabIndex = 5
        Me.okButton.Text = "Ok"
        Me.okButton.UseVisualStyleBackColor = True
        '
        'JumpForm
        '
        Me.AcceptButton = Me.okButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 221)
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.MesgBox)
        Me.Controls.Add(Me.DescrBox2)
        Me.Controls.Add(Me.DescrBox1)
        Me.Controls.Add(Me.ExamineButton2)
        Me.Controls.Add(Me.ExamineButton1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "JumpForm"
        Me.Text = "Options..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ExamineButton1 As System.Windows.Forms.Button
    Friend WithEvents ExamineButton2 As System.Windows.Forms.Button
    Friend WithEvents DescrBox1 As System.Windows.Forms.TextBox
    Friend WithEvents DescrBox2 As System.Windows.Forms.TextBox
    Friend WithEvents MesgBox As System.Windows.Forms.TextBox
    Friend WithEvents okButton As System.Windows.Forms.Button
End Class
