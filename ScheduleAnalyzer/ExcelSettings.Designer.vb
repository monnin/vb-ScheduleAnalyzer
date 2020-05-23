<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExcelSettings
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.firstCapBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.maxCapacityBox = New System.Windows.Forms.TextBox()
        Me.roomSizeBox = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ExcelTabControl = New System.Windows.Forms.TabControl()
        Me.SheetTab = New System.Windows.Forms.TabPage()
        Me.resetButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.scheduleBox = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.enrollTypeBox = New System.Windows.Forms.ComboBox()
        Me.curEnrollBox = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.maxEnrollBox = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.roomBox = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.timeBox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.daysBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.instructorBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.courseNumBox = New System.Windows.Forms.TextBox()
        Me.SequencesTab = New System.Windows.Forms.TabPage()
        Me.sequenceBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RoomTab = New System.Windows.Forms.TabPage()
        Me.capabilitiesBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.roomDescription = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.notesBox = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.contactHoursBox = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.roomSizeBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExcelTabControl.SuspendLayout()
        Me.SheetTab.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SequencesTab.SuspendLayout()
        Me.RoomTab.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 500)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(211, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "(First) Column name for a room's capabilities"
        '
        'firstCapBox
        '
        Me.firstCapBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.firstCapBox.Location = New System.Drawing.Point(223, 56)
        Me.firstCapBox.Name = "firstCapBox"
        Me.firstCapBox.Size = New System.Drawing.Size(151, 20)
        Me.firstCapBox.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(184, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Column name for room's max capacity"
        '
        'maxCapacityBox
        '
        Me.maxCapacityBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maxCapacityBox.Location = New System.Drawing.Point(223, 27)
        Me.maxCapacityBox.Name = "maxCapacityBox"
        Me.maxCapacityBox.Size = New System.Drawing.Size(151, 20)
        Me.maxCapacityBox.TabIndex = 4
        '
        'roomSizeBox
        '
        Me.roomSizeBox.Location = New System.Drawing.Point(169, 298)
        Me.roomSizeBox.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.roomSizeBox.Name = "roomSizeBox"
        Me.roomSizeBox.Size = New System.Drawing.Size(66, 20)
        Me.roomSizeBox.TabIndex = 6
        Me.roomSizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.roomSizeBox.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 300)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Default size of a classroom"
        '
        'ExcelTabControl
        '
        Me.ExcelTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExcelTabControl.Controls.Add(Me.SheetTab)
        Me.ExcelTabControl.Controls.Add(Me.SequencesTab)
        Me.ExcelTabControl.Controls.Add(Me.RoomTab)
        Me.ExcelTabControl.Location = New System.Drawing.Point(-2, 10)
        Me.ExcelTabControl.Name = "ExcelTabControl"
        Me.ExcelTabControl.SelectedIndex = 0
        Me.ExcelTabControl.Size = New System.Drawing.Size(425, 484)
        Me.ExcelTabControl.TabIndex = 6
        '
        'SheetTab
        '
        Me.SheetTab.Controls.Add(Me.resetButton)
        Me.SheetTab.Controls.Add(Me.Label1)
        Me.SheetTab.Controls.Add(Me.scheduleBox)
        Me.SheetTab.Controls.Add(Me.GroupBox1)
        Me.SheetTab.Controls.Add(Me.Label9)
        Me.SheetTab.Location = New System.Drawing.Point(4, 22)
        Me.SheetTab.Name = "SheetTab"
        Me.SheetTab.Padding = New System.Windows.Forms.Padding(3)
        Me.SheetTab.Size = New System.Drawing.Size(417, 458)
        Me.SheetTab.TabIndex = 1
        Me.SheetTab.Text = "Sections"
        Me.SheetTab.UseVisualStyleBackColor = True
        '
        'resetButton
        '
        Me.resetButton.Location = New System.Drawing.Point(3, 429)
        Me.resetButton.Name = "resetButton"
        Me.resetButton.Size = New System.Drawing.Size(107, 23)
        Me.resetButton.TabIndex = 7
        Me.resetButton.Text = "Reset to Defaults"
        Me.resetButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Tab/Sheet Name for the schedule"
        '
        'scheduleBox
        '
        Me.scheduleBox.Location = New System.Drawing.Point(217, 19)
        Me.scheduleBox.Name = "scheduleBox"
        Me.scheduleBox.Size = New System.Drawing.Size(186, 20)
        Me.scheduleBox.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.contactHoursBox)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.notesBox)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.enrollTypeBox)
        Me.GroupBox1.Controls.Add(Me.curEnrollBox)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.maxEnrollBox)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.roomBox)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.timeBox)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.daysBox)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.instructorBox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.courseNumBox)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(414, 314)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Column Names for..."
        '
        'enrollTypeBox
        '
        Me.enrollTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.enrollTypeBox.FormattingEnabled = True
        Me.enrollTypeBox.Items.AddRange(New Object() {"Current Enrollment", "Number of Slots Available"})
        Me.enrollTypeBox.Location = New System.Drawing.Point(3, 177)
        Me.enrollTypeBox.Name = "enrollTypeBox"
        Me.enrollTypeBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.enrollTypeBox.Size = New System.Drawing.Size(154, 21)
        Me.enrollTypeBox.TabIndex = 16
        '
        'curEnrollBox
        '
        Me.curEnrollBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.curEnrollBox.Location = New System.Drawing.Point(162, 178)
        Me.curEnrollBox.Name = "curEnrollBox"
        Me.curEnrollBox.Size = New System.Drawing.Size(241, 20)
        Me.curEnrollBox.TabIndex = 14
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(53, 211)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Maximum Enrollment"
        '
        'maxEnrollBox
        '
        Me.maxEnrollBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maxEnrollBox.Location = New System.Drawing.Point(162, 211)
        Me.maxEnrollBox.Name = "maxEnrollBox"
        Me.maxEnrollBox.Size = New System.Drawing.Size(241, 20)
        Me.maxEnrollBox.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 398)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(401, 28)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Notes: Use * for wildcards, | for multiple options, UPPER and lowercase are consi" & _
    "dered identical"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(41, 153)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(115, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Room (Building+Room)"
        '
        'roomBox
        '
        Me.roomBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.roomBox.Location = New System.Drawing.Point(162, 146)
        Me.roomBox.Name = "roomBox"
        Me.roomBox.Size = New System.Drawing.Size(241, 20)
        Me.roomBox.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(34, 122)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Time (start-end)  of class"
        '
        'timeBox
        '
        Me.timeBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.timeBox.Location = New System.Drawing.Point(162, 115)
        Me.timeBox.Name = "timeBox"
        Me.timeBox.Size = New System.Drawing.Size(241, 20)
        Me.timeBox.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(38, 87)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Weekdays Class Meets"
        '
        'daysBox
        '
        Me.daysBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.daysBox.Location = New System.Drawing.Point(162, 84)
        Me.daysBox.Name = "daysBox"
        Me.daysBox.Size = New System.Drawing.Size(241, 20)
        Me.daysBox.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(74, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Instructor Name"
        '
        'instructorBox
        '
        Me.instructorBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.instructorBox.Location = New System.Drawing.Point(162, 53)
        Me.instructorBox.Name = "instructorBox"
        Me.instructorBox.Size = New System.Drawing.Size(241, 20)
        Me.instructorBox.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(76, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Course Number"
        '
        'courseNumBox
        '
        Me.courseNumBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.courseNumBox.Location = New System.Drawing.Point(162, 22)
        Me.courseNumBox.Name = "courseNumBox"
        Me.courseNumBox.Size = New System.Drawing.Size(241, 20)
        Me.courseNumBox.TabIndex = 2
        '
        'SequencesTab
        '
        Me.SequencesTab.Controls.Add(Me.sequenceBox)
        Me.SequencesTab.Controls.Add(Me.Label2)
        Me.SequencesTab.Location = New System.Drawing.Point(4, 22)
        Me.SequencesTab.Name = "SequencesTab"
        Me.SequencesTab.Padding = New System.Windows.Forms.Padding(3)
        Me.SequencesTab.Size = New System.Drawing.Size(417, 413)
        Me.SequencesTab.TabIndex = 0
        Me.SequencesTab.Text = "Sequences"
        Me.SequencesTab.UseVisualStyleBackColor = True
        '
        'sequenceBox
        '
        Me.sequenceBox.Location = New System.Drawing.Point(211, 22)
        Me.sequenceBox.Name = "sequenceBox"
        Me.sequenceBox.Size = New System.Drawing.Size(185, 20)
        Me.sequenceBox.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(178, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Tab/Sheet Name for the sequences"
        '
        'RoomTab
        '
        Me.RoomTab.Controls.Add(Me.capabilitiesBox)
        Me.RoomTab.Controls.Add(Me.Label4)
        Me.RoomTab.Controls.Add(Me.GroupBox2)
        Me.RoomTab.Controls.Add(Me.roomSizeBox)
        Me.RoomTab.Controls.Add(Me.Label5)
        Me.RoomTab.Location = New System.Drawing.Point(4, 22)
        Me.RoomTab.Name = "RoomTab"
        Me.RoomTab.Size = New System.Drawing.Size(417, 413)
        Me.RoomTab.TabIndex = 2
        Me.RoomTab.Text = "Room Capabilities"
        Me.RoomTab.UseVisualStyleBackColor = True
        '
        'capabilitiesBox
        '
        Me.capabilitiesBox.Location = New System.Drawing.Point(220, 20)
        Me.capabilitiesBox.Name = "capabilitiesBox"
        Me.capabilitiesBox.Size = New System.Drawing.Size(185, 20)
        Me.capabilitiesBox.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(204, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Tab/Sheet Name for the room capabilities"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.roomDescription)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.firstCapBox)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.maxCapacityBox)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(380, 161)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Column Names"
        '
        'roomDescription
        '
        Me.roomDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.roomDescription.Location = New System.Drawing.Point(223, 87)
        Me.roomDescription.Name = "roomDescription"
        Me.roomDescription.Size = New System.Drawing.Size(151, 20)
        Me.roomDescription.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(119, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Description Column"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(112, 250)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Notes"
        '
        'notesBox
        '
        Me.notesBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.notesBox.Location = New System.Drawing.Point(162, 243)
        Me.notesBox.Name = "notesBox"
        Me.notesBox.Size = New System.Drawing.Size(241, 20)
        Me.notesBox.TabIndex = 18
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(82, 287)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 13)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Contact Hours"
        '
        'contactHoursBox
        '
        Me.contactHoursBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.contactHoursBox.Location = New System.Drawing.Point(162, 280)
        Me.contactHoursBox.Name = "contactHoursBox"
        Me.contactHoursBox.Size = New System.Drawing.Size(241, 20)
        Me.contactHoursBox.TabIndex = 20
        '
        'ExcelSettings
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(435, 541)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.ExcelTabControl)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExcelSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Excel Settings"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.roomSizeBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExcelTabControl.ResumeLayout(False)
        Me.SheetTab.ResumeLayout(False)
        Me.SheetTab.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SequencesTab.ResumeLayout(False)
        Me.SequencesTab.PerformLayout()
        Me.RoomTab.ResumeLayout(False)
        Me.RoomTab.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents roomSizeBox As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents firstCapBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents maxCapacityBox As System.Windows.Forms.TextBox
    Friend WithEvents ExcelTabControl As System.Windows.Forms.TabControl
    Friend WithEvents SequencesTab As System.Windows.Forms.TabPage
    Friend WithEvents sequenceBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SheetTab As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents courseNumBox As System.Windows.Forms.TextBox
    Friend WithEvents RoomTab As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents scheduleBox As System.Windows.Forms.TextBox
    Friend WithEvents capabilitiesBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents instructorBox As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents daysBox As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents timeBox As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents roomBox As System.Windows.Forms.TextBox
    Friend WithEvents resetButton As System.Windows.Forms.Button
    Friend WithEvents curEnrollBox As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents maxEnrollBox As System.Windows.Forms.TextBox
    Friend WithEvents enrollTypeBox As System.Windows.Forms.ComboBox
    Friend WithEvents roomDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents notesBox As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents contactHoursBox As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label

End Class
