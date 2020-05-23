<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowFacultyCourses
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.facNameBox = New System.Windows.Forms.TextBox()
        Me.courseView = New System.Windows.Forms.ListView()
        Me.Course = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Days = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.startTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.endTime = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Loc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.popupMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.copyMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.printMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.showButton = New System.Windows.Forms.Button()
        Me.popupMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Courses for..."
        '
        'facNameBox
        '
        Me.facNameBox.Location = New System.Drawing.Point(101, 10)
        Me.facNameBox.Name = "facNameBox"
        Me.facNameBox.Size = New System.Drawing.Size(205, 20)
        Me.facNameBox.TabIndex = 1
        '
        'courseView
        '
        Me.courseView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.courseView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Course, Me.Days, Me.startTime, Me.endTime, Me.Loc})
        Me.courseView.ContextMenuStrip = Me.popupMenu
        Me.courseView.Font = New System.Drawing.Font("Consolas", 9.0!)
        Me.courseView.FullRowSelect = True
        Me.courseView.Location = New System.Drawing.Point(13, 47)
        Me.courseView.Name = "courseView"
        Me.courseView.Size = New System.Drawing.Size(393, 307)
        Me.courseView.TabIndex = 2
        Me.courseView.UseCompatibleStateImageBehavior = False
        Me.courseView.View = System.Windows.Forms.View.Details
        '
        'Course
        '
        Me.Course.Text = "Course"
        Me.Course.Width = 110
        '
        'Days
        '
        Me.Days.Text = "Days"
        Me.Days.Width = 75
        '
        'startTime
        '
        Me.startTime.Text = "Start"
        Me.startTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.startTime.Width = 87
        '
        'endTime
        '
        Me.endTime.Text = "End"
        Me.endTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.endTime.Width = 87
        '
        'Loc
        '
        Me.Loc.Text = "Loc"
        Me.Loc.Width = 0
        '
        'popupMenu
        '
        Me.popupMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.copyMenuItem, Me.printMenuItem})
        Me.popupMenu.Name = "popupMenu"
        Me.popupMenu.ShowImageMargin = False
        Me.popupMenu.Size = New System.Drawing.Size(78, 48)
        '
        'copyMenuItem
        '
        Me.copyMenuItem.Name = "copyMenuItem"
        Me.copyMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.copyMenuItem.Text = "Copy"
        '
        'printMenuItem
        '
        Me.printMenuItem.Name = "printMenuItem"
        Me.printMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.printMenuItem.Text = "Print"
        '
        'showButton
        '
        Me.showButton.Location = New System.Drawing.Point(325, 8)
        Me.showButton.Name = "showButton"
        Me.showButton.Size = New System.Drawing.Size(50, 23)
        Me.showButton.TabIndex = 3
        Me.showButton.Text = "Show"
        Me.showButton.UseVisualStyleBackColor = True
        '
        'ShowFacultyCourses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 406)
        Me.Controls.Add(Me.showButton)
        Me.Controls.Add(Me.courseView)
        Me.Controls.Add(Me.facNameBox)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ShowFacultyCourses"
        Me.Text = "Courses for..."
        Me.popupMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents facNameBox As System.Windows.Forms.TextBox
    Friend WithEvents courseView As System.Windows.Forms.ListView
    Friend WithEvents Course As System.Windows.Forms.ColumnHeader
    Friend WithEvents Days As System.Windows.Forms.ColumnHeader
    Friend WithEvents startTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents endTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents showButton As System.Windows.Forms.Button
    Friend WithEvents Loc As System.Windows.Forms.ColumnHeader
    Friend WithEvents popupMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents copyMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents printMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
