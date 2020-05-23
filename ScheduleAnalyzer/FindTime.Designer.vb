<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindTime
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
        Me.roomBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FindItButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.durationBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.classCount = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.timeAndDateTab = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SatCheck = New System.Windows.Forms.CheckBox()
        Me.MonCheck = New System.Windows.Forms.CheckBox()
        Me.TueCheck = New System.Windows.Forms.CheckBox()
        Me.WedCheck = New System.Windows.Forms.CheckBox()
        Me.ThurCheck = New System.Windows.Forms.CheckBox()
        Me.friCheck = New System.Windows.Forms.CheckBox()
        Me.SunCheck = New System.Windows.Forms.CheckBox()
        Me.endTimeBox = New System.Windows.Forms.ComboBox()
        Me.startTimeBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.capabilitiesTab = New System.Windows.Forms.TabPage()
        Me.capabilitiesLabel = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.minSeats = New System.Windows.Forms.MaskedTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.matchAnyRB = New System.Windows.Forms.RadioButton()
        Me.matchAllRB = New System.Windows.Forms.RadioButton()
        Me.capabilitiesTable = New System.Windows.Forms.TableLayoutPanel()
        Me.errorLabel = New System.Windows.Forms.Label()
        Me.ResultView = New System.Windows.Forms.ListView()
        Me.roomHeader = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.daysH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.startH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.endH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.durationH = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.durationG = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.findTimeContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.copyMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.printMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindTimeToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FindMainMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.classCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.timeAndDateTab.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.capabilitiesTab.SuspendLayout()
        Me.findTimeContextMenuStrip.SuspendLayout()
        Me.FindMainMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'roomBox
        '
        Me.roomBox.FormattingEnabled = True
        Me.roomBox.Location = New System.Drawing.Point(212, 58)
        Me.roomBox.Name = "roomBox"
        Me.roomBox.Size = New System.Drawing.Size(143, 21)
        Me.roomBox.TabIndex = 2
        Me.roomBox.Text = "<any>"
        Me.FindTimeToolTip.SetToolTip(Me.roomBox, "Use commas (,) to seperate multiple rooms to search, and/or use * and ? for wildc" & _
        "ards")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Limit Search to the Following Room(s)"
        '
        'FindItButton
        '
        Me.FindItButton.Location = New System.Drawing.Point(12, 13)
        Me.FindItButton.Name = "FindItButton"
        Me.FindItButton.Size = New System.Drawing.Size(75, 23)
        Me.FindItButton.TabIndex = 0
        Me.FindItButton.Text = "Find!"
        Me.FindItButton.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(546, 20)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Find Available Class Times"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'durationBox
        '
        Me.durationBox.Location = New System.Drawing.Point(281, 30)
        Me.durationBox.Name = "durationBox"
        Me.durationBox.Size = New System.Drawing.Size(76, 20)
        Me.durationBox.TabIndex = 1
        Me.durationBox.Text = "1:15"
        Me.durationBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FindTimeToolTip.SetToolTip(Me.durationBox, "Duration of time in hours & minutes")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Class meets..."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 348)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(345, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Multiple rooms can be searched using the | character (e.g. B208A|C218)"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 34)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.classCount)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.durationBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.roomBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.errorLabel)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ResultView)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel2.Controls.Add(Me.FindItButton)
        Me.SplitContainer1.Size = New System.Drawing.Size(557, 593)
        Me.SplitContainer1.SplitterDistance = 286
        Me.SplitContainer1.TabIndex = 35
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(363, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "...each class"
        '
        'classCount
        '
        Me.classCount.Location = New System.Drawing.Point(100, 30)
        Me.classCount.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.classCount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.classCount.Name = "classCount"
        Me.classCount.Size = New System.Drawing.Size(76, 20)
        Me.classCount.TabIndex = 0
        Me.classCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FindTimeToolTip.SetToolTip(Me.classCount, "# of times a class meets")
        Me.classCount.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left
        Me.classCount.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(178, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "...times a week, for..."
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.timeAndDateTab)
        Me.TabControl1.Controls.Add(Me.capabilitiesTab)
        Me.TabControl1.Location = New System.Drawing.Point(8, 85)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(540, 198)
        Me.TabControl1.TabIndex = 3
        '
        'timeAndDateTab
        '
        Me.timeAndDateTab.Controls.Add(Me.GroupBox1)
        Me.timeAndDateTab.Location = New System.Drawing.Point(4, 22)
        Me.timeAndDateTab.Name = "timeAndDateTab"
        Me.timeAndDateTab.Padding = New System.Windows.Forms.Padding(3)
        Me.timeAndDateTab.Size = New System.Drawing.Size(532, 172)
        Me.timeAndDateTab.TabIndex = 0
        Me.timeAndDateTab.Text = "Time & Date"
        Me.timeAndDateTab.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SatCheck)
        Me.GroupBox1.Controls.Add(Me.MonCheck)
        Me.GroupBox1.Controls.Add(Me.TueCheck)
        Me.GroupBox1.Controls.Add(Me.WedCheck)
        Me.GroupBox1.Controls.Add(Me.ThurCheck)
        Me.GroupBox1.Controls.Add(Me.friCheck)
        Me.GroupBox1.Controls.Add(Me.SunCheck)
        Me.GroupBox1.Controls.Add(Me.endTimeBox)
        Me.GroupBox1.Controls.Add(Me.startTimeBox)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 136)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Limit Search To"
        '
        'SatCheck
        '
        Me.SatCheck.AutoSize = True
        Me.SatCheck.Location = New System.Drawing.Point(376, 113)
        Me.SatCheck.Name = "SatCheck"
        Me.SatCheck.Size = New System.Drawing.Size(42, 17)
        Me.SatCheck.TabIndex = 8
        Me.SatCheck.Text = "Sat"
        Me.SatCheck.UseVisualStyleBackColor = True
        '
        'MonCheck
        '
        Me.MonCheck.AutoSize = True
        Me.MonCheck.Checked = True
        Me.MonCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MonCheck.Location = New System.Drawing.Point(87, 82)
        Me.MonCheck.Name = "MonCheck"
        Me.MonCheck.Size = New System.Drawing.Size(47, 17)
        Me.MonCheck.TabIndex = 4
        Me.MonCheck.Text = "Mon"
        Me.MonCheck.UseVisualStyleBackColor = True
        '
        'TueCheck
        '
        Me.TueCheck.AutoSize = True
        Me.TueCheck.Checked = True
        Me.TueCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TueCheck.Location = New System.Drawing.Point(159, 82)
        Me.TueCheck.Name = "TueCheck"
        Me.TueCheck.Size = New System.Drawing.Size(45, 17)
        Me.TueCheck.TabIndex = 5
        Me.TueCheck.Text = "Tue"
        Me.TueCheck.UseVisualStyleBackColor = True
        '
        'WedCheck
        '
        Me.WedCheck.AutoSize = True
        Me.WedCheck.Checked = True
        Me.WedCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.WedCheck.Location = New System.Drawing.Point(229, 82)
        Me.WedCheck.Name = "WedCheck"
        Me.WedCheck.Size = New System.Drawing.Size(49, 17)
        Me.WedCheck.TabIndex = 6
        Me.WedCheck.Text = "Wed"
        Me.WedCheck.UseVisualStyleBackColor = True
        '
        'ThurCheck
        '
        Me.ThurCheck.AutoSize = True
        Me.ThurCheck.Checked = True
        Me.ThurCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ThurCheck.Location = New System.Drawing.Point(303, 82)
        Me.ThurCheck.Name = "ThurCheck"
        Me.ThurCheck.Size = New System.Drawing.Size(48, 17)
        Me.ThurCheck.TabIndex = 7
        Me.ThurCheck.Text = "Thur"
        Me.ThurCheck.UseVisualStyleBackColor = True
        '
        'friCheck
        '
        Me.friCheck.AutoSize = True
        Me.friCheck.Checked = True
        Me.friCheck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.friCheck.Location = New System.Drawing.Point(376, 82)
        Me.friCheck.Name = "friCheck"
        Me.friCheck.Size = New System.Drawing.Size(37, 17)
        Me.friCheck.TabIndex = 37
        Me.friCheck.Text = "Fri"
        Me.friCheck.UseVisualStyleBackColor = True
        '
        'SunCheck
        '
        Me.SunCheck.AutoSize = True
        Me.SunCheck.Location = New System.Drawing.Point(87, 113)
        Me.SunCheck.Name = "SunCheck"
        Me.SunCheck.Size = New System.Drawing.Size(45, 17)
        Me.SunCheck.TabIndex = 3
        Me.SunCheck.Text = "Sun"
        Me.SunCheck.UseVisualStyleBackColor = True
        '
        'endTimeBox
        '
        Me.endTimeBox.FormattingEnabled = True
        Me.endTimeBox.Items.AddRange(New Object() {"9:15 AM", "10:45 AM", "12:15 PM", "2:15 PM", "3:45 PM", "8:00 PM"})
        Me.endTimeBox.Location = New System.Drawing.Point(87, 54)
        Me.endTimeBox.Name = "endTimeBox"
        Me.endTimeBox.Size = New System.Drawing.Size(149, 21)
        Me.endTimeBox.TabIndex = 1
        Me.endTimeBox.Text = "8:00 PM"
        '
        'startTimeBox
        '
        Me.startTimeBox.FormattingEnabled = True
        Me.startTimeBox.Items.AddRange(New Object() {"8:00 AM", "9:30 AM", "11:00 AM", "1:00 PM", "2:30 PM", "4:00 PM", "5:30 PM"})
        Me.startTimeBox.Location = New System.Drawing.Point(87, 22)
        Me.startTimeBox.Name = "startTimeBox"
        Me.startTimeBox.Size = New System.Drawing.Size(149, 21)
        Me.startTimeBox.TabIndex = 0
        Me.startTimeBox.Text = "8:00 AM"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(240, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "(e.g. 2:30 PM)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "On..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "From..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(56, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "...to"
        '
        'capabilitiesTab
        '
        Me.capabilitiesTab.Controls.Add(Me.capabilitiesLabel)
        Me.capabilitiesTab.Controls.Add(Me.Label13)
        Me.capabilitiesTab.Controls.Add(Me.Label12)
        Me.capabilitiesTab.Controls.Add(Me.minSeats)
        Me.capabilitiesTab.Controls.Add(Me.Label11)
        Me.capabilitiesTab.Controls.Add(Me.matchAnyRB)
        Me.capabilitiesTab.Controls.Add(Me.matchAllRB)
        Me.capabilitiesTab.Controls.Add(Me.capabilitiesTable)
        Me.capabilitiesTab.Location = New System.Drawing.Point(4, 22)
        Me.capabilitiesTab.Name = "capabilitiesTab"
        Me.capabilitiesTab.Padding = New System.Windows.Forms.Padding(3)
        Me.capabilitiesTab.Size = New System.Drawing.Size(532, 172)
        Me.capabilitiesTab.TabIndex = 1
        Me.capabilitiesTab.Text = "Capabilities & Resources"
        Me.capabilitiesTab.UseVisualStyleBackColor = True
        '
        'capabilitiesLabel
        '
        Me.capabilitiesLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.capabilitiesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capabilitiesLabel.Location = New System.Drawing.Point(3, 3)
        Me.capabilitiesLabel.Name = "capabilitiesLabel"
        Me.capabilitiesLabel.Size = New System.Drawing.Size(526, 166)
        Me.capabilitiesLabel.TabIndex = 7
        Me.capabilitiesLabel.Text = "No capabilities defined in the spreadsheet, please add them first"
        Me.capabilitiesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.capabilitiesLabel.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(292, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(212, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "(leave blank for no limit based on room size)"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(227, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "... students"
        '
        'minSeats
        '
        Me.minSeats.BackColor = System.Drawing.Color.Gainsboro
        Me.minSeats.HidePromptOnLeave = True
        Me.minSeats.Location = New System.Drawing.Point(150, 6)
        Me.minSeats.Mask = "9999"
        Me.minSeats.Name = "minSeats"
        Me.minSeats.Size = New System.Drawing.Size(80, 20)
        Me.minSeats.TabIndex = 11
        Me.minSeats.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FindTimeToolTip.SetToolTip(Me.minSeats, "Enter a number or leave blank for all classroom sizes")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(145, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Limit to rooms that can hold..."
        '
        'matchAnyRB
        '
        Me.matchAnyRB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.matchAnyRB.AutoSize = True
        Me.matchAnyRB.Location = New System.Drawing.Point(264, 152)
        Me.matchAnyRB.Name = "matchAnyRB"
        Me.matchAnyRB.Size = New System.Drawing.Size(258, 17)
        Me.matchAnyRB.TabIndex = 9
        Me.matchAnyRB.Text = "Rooms must have ANY one of the checked items"
        Me.matchAnyRB.UseVisualStyleBackColor = True
        '
        'matchAllRB
        '
        Me.matchAllRB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.matchAllRB.AutoSize = True
        Me.matchAllRB.Checked = True
        Me.matchAllRB.Location = New System.Drawing.Point(6, 152)
        Me.matchAllRB.Name = "matchAllRB"
        Me.matchAllRB.Size = New System.Drawing.Size(234, 17)
        Me.matchAllRB.TabIndex = 8
        Me.matchAllRB.TabStop = True
        Me.matchAllRB.Text = "Rooms must have ALL of the checked items"
        Me.matchAllRB.UseVisualStyleBackColor = True
        '
        'capabilitiesTable
        '
        Me.capabilitiesTable.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.capabilitiesTable.AutoScroll = True
        Me.capabilitiesTable.ColumnCount = 3
        Me.capabilitiesTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.capabilitiesTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.capabilitiesTable.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.capabilitiesTable.Location = New System.Drawing.Point(4, 29)
        Me.capabilitiesTable.Name = "capabilitiesTable"
        Me.capabilitiesTable.RowCount = 1
        Me.capabilitiesTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.capabilitiesTable.Size = New System.Drawing.Size(522, 122)
        Me.capabilitiesTable.TabIndex = 0
        '
        'errorLabel
        '
        Me.errorLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.errorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.errorLabel.Location = New System.Drawing.Point(18, 43)
        Me.errorLabel.Name = "errorLabel"
        Me.errorLabel.Size = New System.Drawing.Size(525, 194)
        Me.errorLabel.TabIndex = 36
        Me.errorLabel.Text = "errorString"
        Me.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.errorLabel.Visible = False
        '
        'ResultView
        '
        Me.ResultView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ResultView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.roomHeader, Me.daysH, Me.startH, Me.endH, Me.durationH, Me.durationG})
        Me.ResultView.ContextMenuStrip = Me.findTimeContextMenuStrip
        Me.ResultView.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultView.FullRowSelect = True
        Me.ResultView.Location = New System.Drawing.Point(15, 43)
        Me.ResultView.Name = "ResultView"
        Me.ResultView.ShowItemToolTips = True
        Me.ResultView.Size = New System.Drawing.Size(528, 214)
        Me.ResultView.TabIndex = 35
        Me.ResultView.UseCompatibleStateImageBehavior = False
        Me.ResultView.View = System.Windows.Forms.View.Details
        '
        'roomHeader
        '
        Me.roomHeader.Text = "Room"
        Me.roomHeader.Width = 70
        '
        'daysH
        '
        Me.daysH.Text = "On Days"
        Me.daysH.Width = 70
        '
        'startH
        '
        Me.startH.Text = "From"
        Me.startH.Width = 100
        '
        'endH
        '
        Me.endH.Text = "Until"
        Me.endH.Width = 100
        '
        'durationH
        '
        Me.durationH.Text = "Duration"
        Me.durationH.Width = 70
        '
        'durationG
        '
        Me.durationG.Text = ""
        Me.durationG.Width = 160
        '
        'findTimeContextMenuStrip
        '
        Me.findTimeContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.copyMenuItem, Me.printMenuItem})
        Me.findTimeContextMenuStrip.Name = "findTimeContextMenuStrip"
        Me.findTimeContextMenuStrip.ShowImageMargin = False
        Me.findTimeContextMenuStrip.Size = New System.Drawing.Size(78, 48)
        '
        'copyMenuItem
        '
        Me.copyMenuItem.Name = "copyMenuItem"
        Me.copyMenuItem.Size = New System.Drawing.Size(77, 22)
        Me.copyMenuItem.Text = "Copy"
        '
        'printMenuItem
        '
        Me.printMenuItem.Name = "printMenuItem"
        Me.printMenuItem.Size = New System.Drawing.Size(77, 22)
        Me.printMenuItem.Text = "Print"
        '
        'FindTimeToolTip
        '
        Me.FindTimeToolTip.AutoPopDelay = 10000
        Me.FindTimeToolTip.InitialDelay = 500
        Me.FindTimeToolTip.ReshowDelay = 100
        '
        'FindMainMenuStrip
        '
        Me.FindMainMenuStrip.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.FindMainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem})
        Me.FindMainMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.FindMainMenuStrip.Name = "FindMainMenuStrip"
        Me.FindMainMenuStrip.Size = New System.Drawing.Size(555, 24)
        Me.FindMainMenuStrip.TabIndex = 36
        Me.FindMainMenuStrip.Text = "Top Menu"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(102, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'FindTime
        '
        Me.AcceptButton = Me.FindItButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 596)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.FindMainMenuStrip)
        Me.Name = "FindTime"
        Me.Text = "Find Class Time"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.classCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.timeAndDateTab.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.capabilitiesTab.ResumeLayout(False)
        Me.capabilitiesTab.PerformLayout()
        Me.findTimeContextMenuStrip.ResumeLayout(False)
        Me.FindMainMenuStrip.ResumeLayout(False)
        Me.FindMainMenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents roomBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FindItButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents durationBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents timeAndDateTab As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SatCheck As System.Windows.Forms.CheckBox
    Friend WithEvents MonCheck As System.Windows.Forms.CheckBox
    Friend WithEvents TueCheck As System.Windows.Forms.CheckBox
    Friend WithEvents WedCheck As System.Windows.Forms.CheckBox
    Friend WithEvents ThurCheck As System.Windows.Forms.CheckBox
    Friend WithEvents friCheck As System.Windows.Forms.CheckBox
    Friend WithEvents SunCheck As System.Windows.Forms.CheckBox
    Friend WithEvents endTimeBox As System.Windows.Forms.ComboBox
    Friend WithEvents startTimeBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents capabilitiesTab As System.Windows.Forms.TabPage
    Friend WithEvents capabilitiesTable As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents matchAnyRB As System.Windows.Forms.RadioButton
    Friend WithEvents matchAllRB As System.Windows.Forms.RadioButton
    Friend WithEvents capabilitiesLabel As System.Windows.Forms.Label
    Friend WithEvents classCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents FindTimeToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ResultView As System.Windows.Forms.ListView
    Friend WithEvents roomHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents daysH As System.Windows.Forms.ColumnHeader
    Friend WithEvents startH As System.Windows.Forms.ColumnHeader
    Friend WithEvents endH As System.Windows.Forms.ColumnHeader
    Friend WithEvents durationH As System.Windows.Forms.ColumnHeader
    Friend WithEvents errorLabel As System.Windows.Forms.Label
    Friend WithEvents durationG As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents minSeats As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents FindMainMenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents findTimeContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents copyMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents printMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
