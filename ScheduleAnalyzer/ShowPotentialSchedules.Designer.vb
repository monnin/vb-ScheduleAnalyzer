<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShowPotentialSchedules
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ShowPotentialSchedules))
        Me.inputTabControl = New System.Windows.Forms.TabControl()
        Me.generalTabPage = New System.Windows.Forms.TabPage()
        Me.coursesBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.preDefinedComboBox = New System.Windows.Forms.ComboBox()
        Me.criteriaTabPage = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.maxDaysUD = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.roomBox = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.FriBox = New System.Windows.Forms.CheckBox()
        Me.SatBox = New System.Windows.Forms.CheckBox()
        Me.WedBox = New System.Windows.Forms.CheckBox()
        Me.ThurBox = New System.Windows.Forms.CheckBox()
        Me.TueBox = New System.Windows.Forms.CheckBox()
        Me.MonBox = New System.Windows.Forms.CheckBox()
        Me.sunBox = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.eitherRadioButton = New System.Windows.Forms.RadioButton()
        Me.onlineRadioButton = New System.Windows.Forms.RadioButton()
        Me.classroomRadioButton = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.toDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.fromDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.checkButton = New System.Windows.Forms.Button()
        Me.outputDataGridView = New System.Windows.Forms.DataGridView()
        Me.ResultsContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.copyOneRow = New System.Windows.Forms.ToolStripMenuItem()
        Me.copyTenRows = New System.Windows.Forms.ToolStripMenuItem()
        Me.copy100rows = New System.Windows.Forms.ToolStripMenuItem()
        Me.errorLabel = New System.Windows.Forms.Label()
        Me.extraDataLabel = New System.Windows.Forms.Label()
        Me.ShowScheduleToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.NotFullCheckBox = New System.Windows.Forms.CheckBox()
        Me.CheckProgressBar = New System.Windows.Forms.ProgressBar()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CopyAllRowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyFirst4RowsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.inputTabControl.SuspendLayout()
        Me.generalTabPage.SuspendLayout()
        Me.criteriaTabPage.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.maxDaysUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.outputDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ResultsContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'inputTabControl
        '
        Me.inputTabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.inputTabControl.Controls.Add(Me.generalTabPage)
        Me.inputTabControl.Controls.Add(Me.criteriaTabPage)
        Me.inputTabControl.Location = New System.Drawing.Point(1, 12)
        Me.inputTabControl.Name = "inputTabControl"
        Me.inputTabControl.SelectedIndex = 0
        Me.inputTabControl.Size = New System.Drawing.Size(652, 100)
        Me.inputTabControl.TabIndex = 0
        '
        'generalTabPage
        '
        Me.generalTabPage.Controls.Add(Me.coursesBox)
        Me.generalTabPage.Controls.Add(Me.Label1)
        Me.generalTabPage.Controls.Add(Me.preDefinedComboBox)
        Me.generalTabPage.Location = New System.Drawing.Point(4, 22)
        Me.generalTabPage.Name = "generalTabPage"
        Me.generalTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.generalTabPage.Size = New System.Drawing.Size(644, 74)
        Me.generalTabPage.TabIndex = 0
        Me.generalTabPage.Text = "General"
        Me.generalTabPage.UseVisualStyleBackColor = True
        '
        'coursesBox
        '
        Me.coursesBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.coursesBox.Location = New System.Drawing.Point(11, 31)
        Me.coursesBox.Multiline = True
        Me.coursesBox.Name = "coursesBox"
        Me.coursesBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.coursesBox.Size = New System.Drawing.Size(627, 37)
        Me.coursesBox.TabIndex = 2
        Me.ShowScheduleToolTip.SetToolTip(Me.coursesBox, "You may enter any list of courses, seperated by commas.  Use | between choices (M" & _
        "AT122|MAT127), and use * for wildcards (PSY2* for 200-level PSY courses)")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Predefined Sequences:"
        '
        'preDefinedComboBox
        '
        Me.preDefinedComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.preDefinedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.preDefinedComboBox.FormattingEnabled = True
        Me.preDefinedComboBox.Location = New System.Drawing.Point(132, 4)
        Me.preDefinedComboBox.Name = "preDefinedComboBox"
        Me.preDefinedComboBox.Size = New System.Drawing.Size(431, 21)
        Me.preDefinedComboBox.TabIndex = 0
        Me.ShowScheduleToolTip.SetToolTip(Me.preDefinedComboBox, "Sequences defined in the Excel spreadsheet")
        '
        'criteriaTabPage
        '
        Me.criteriaTabPage.Controls.Add(Me.GroupBox5)
        Me.criteriaTabPage.Controls.Add(Me.GroupBox4)
        Me.criteriaTabPage.Controls.Add(Me.GroupBox2)
        Me.criteriaTabPage.Controls.Add(Me.GroupBox1)
        Me.criteriaTabPage.Controls.Add(Me.GroupBox3)
        Me.criteriaTabPage.Location = New System.Drawing.Point(4, 22)
        Me.criteriaTabPage.Name = "criteriaTabPage"
        Me.criteriaTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.criteriaTabPage.Size = New System.Drawing.Size(644, 74)
        Me.criteriaTabPage.TabIndex = 1
        Me.criteriaTabPage.Text = "Limit to Criteria"
        Me.criteriaTabPage.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.maxDaysUD)
        Me.GroupBox5.Location = New System.Drawing.Point(320, 7)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(105, 64)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Max # Days"
        Me.ShowScheduleToolTip.SetToolTip(Me.GroupBox5, "Max number of days on campus")
        '
        'maxDaysUD
        '
        Me.maxDaysUD.Location = New System.Drawing.Point(23, 28)
        Me.maxDaysUD.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
        Me.maxDaysUD.Name = "maxDaysUD"
        Me.maxDaysUD.Size = New System.Drawing.Size(61, 20)
        Me.maxDaysUD.TabIndex = 0
        Me.maxDaysUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.maxDaysUD.Value = New Decimal(New Integer() {7, 0, 0, 0})
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.roomBox)
        Me.GroupBox4.Location = New System.Drawing.Point(557, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(81, 68)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Rooms"
        '
        'roomBox
        '
        Me.roomBox.Location = New System.Drawing.Point(7, 18)
        Me.roomBox.Multiline = True
        Me.roomBox.Name = "roomBox"
        Me.roomBox.Size = New System.Drawing.Size(68, 44)
        Me.roomBox.TabIndex = 0
        Me.ShowScheduleToolTip.SetToolTip(Me.roomBox, "A list of rooms you want to limit to (mostly for multi-campus uses)")
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.FriBox)
        Me.GroupBox2.Controls.Add(Me.SatBox)
        Me.GroupBox2.Controls.Add(Me.WedBox)
        Me.GroupBox2.Controls.Add(Me.ThurBox)
        Me.GroupBox2.Controls.Add(Me.TueBox)
        Me.GroupBox2.Controls.Add(Me.MonBox)
        Me.GroupBox2.Controls.Add(Me.sunBox)
        Me.GroupBox2.Location = New System.Drawing.Point(115, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(206, 68)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Days"
        '
        'FriBox
        '
        Me.FriBox.AutoSize = True
        Me.FriBox.Checked = True
        Me.FriBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FriBox.Location = New System.Drawing.Point(113, 22)
        Me.FriBox.Name = "FriBox"
        Me.FriBox.Size = New System.Drawing.Size(37, 17)
        Me.FriBox.TabIndex = 6
        Me.FriBox.Text = "Fri"
        Me.FriBox.UseVisualStyleBackColor = True
        '
        'SatBox
        '
        Me.SatBox.AutoSize = True
        Me.SatBox.Checked = True
        Me.SatBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SatBox.Location = New System.Drawing.Point(156, 22)
        Me.SatBox.Name = "SatBox"
        Me.SatBox.Size = New System.Drawing.Size(42, 17)
        Me.SatBox.TabIndex = 5
        Me.SatBox.Text = "Sat"
        Me.SatBox.UseVisualStyleBackColor = True
        '
        'WedBox
        '
        Me.WedBox.AutoSize = True
        Me.WedBox.Checked = True
        Me.WedBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.WedBox.Location = New System.Drawing.Point(58, 22)
        Me.WedBox.Name = "WedBox"
        Me.WedBox.Size = New System.Drawing.Size(49, 17)
        Me.WedBox.TabIndex = 4
        Me.WedBox.Text = "Wed"
        Me.WedBox.UseVisualStyleBackColor = True
        '
        'ThurBox
        '
        Me.ThurBox.AutoSize = True
        Me.ThurBox.Checked = True
        Me.ThurBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ThurBox.Location = New System.Drawing.Point(59, 45)
        Me.ThurBox.Name = "ThurBox"
        Me.ThurBox.Size = New System.Drawing.Size(48, 17)
        Me.ThurBox.TabIndex = 3
        Me.ThurBox.Text = "Thur"
        Me.ThurBox.UseVisualStyleBackColor = True
        '
        'TueBox
        '
        Me.TueBox.AutoSize = True
        Me.TueBox.Checked = True
        Me.TueBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.TueBox.Location = New System.Drawing.Point(8, 44)
        Me.TueBox.Name = "TueBox"
        Me.TueBox.Size = New System.Drawing.Size(45, 17)
        Me.TueBox.TabIndex = 2
        Me.TueBox.Text = "Tue"
        Me.TueBox.UseVisualStyleBackColor = True
        '
        'MonBox
        '
        Me.MonBox.AutoSize = True
        Me.MonBox.Checked = True
        Me.MonBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.MonBox.Location = New System.Drawing.Point(8, 22)
        Me.MonBox.Name = "MonBox"
        Me.MonBox.Size = New System.Drawing.Size(47, 17)
        Me.MonBox.TabIndex = 1
        Me.MonBox.Text = "Mon"
        Me.MonBox.UseVisualStyleBackColor = True
        '
        'sunBox
        '
        Me.sunBox.AutoSize = True
        Me.sunBox.Checked = True
        Me.sunBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.sunBox.Location = New System.Drawing.Point(156, 44)
        Me.sunBox.Name = "sunBox"
        Me.sunBox.Size = New System.Drawing.Size(45, 17)
        Me.sunBox.TabIndex = 0
        Me.sunBox.Text = "Sun"
        Me.sunBox.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.eitherRadioButton)
        Me.GroupBox1.Controls.Add(Me.onlineRadioButton)
        Me.GroupBox1.Controls.Add(Me.classroomRadioButton)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(98, 68)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Format"
        '
        'eitherRadioButton
        '
        Me.eitherRadioButton.AutoSize = True
        Me.eitherRadioButton.Checked = True
        Me.eitherRadioButton.Location = New System.Drawing.Point(6, 48)
        Me.eitherRadioButton.Name = "eitherRadioButton"
        Me.eitherRadioButton.Size = New System.Drawing.Size(79, 17)
        Me.eitherRadioButton.TabIndex = 2
        Me.eitherRadioButton.TabStop = True
        Me.eitherRadioButton.Text = "Both/Either"
        Me.ShowScheduleToolTip.SetToolTip(Me.eitherRadioButton, "Selects any format (in class, online, hybrid, etc.)")
        Me.eitherRadioButton.UseVisualStyleBackColor = True
        '
        'onlineRadioButton
        '
        Me.onlineRadioButton.AutoSize = True
        Me.onlineRadioButton.Location = New System.Drawing.Point(6, 32)
        Me.onlineRadioButton.Name = "onlineRadioButton"
        Me.onlineRadioButton.Size = New System.Drawing.Size(55, 17)
        Me.onlineRadioButton.TabIndex = 1
        Me.onlineRadioButton.Text = "Online"
        Me.ShowScheduleToolTip.SetToolTip(Me.onlineRadioButton, "Only consider fully-online sections")
        Me.onlineRadioButton.UseVisualStyleBackColor = True
        '
        'classroomRadioButton
        '
        Me.classroomRadioButton.AutoSize = True
        Me.classroomRadioButton.Location = New System.Drawing.Point(6, 16)
        Me.classroomRadioButton.Name = "classroomRadioButton"
        Me.classroomRadioButton.Size = New System.Drawing.Size(73, 17)
        Me.classroomRadioButton.TabIndex = 0
        Me.classroomRadioButton.Text = "Classroom"
        Me.ShowScheduleToolTip.SetToolTip(Me.classroomRadioButton, "Classroom includes both fully-in-class and ""hybrid"" options")
        Me.classroomRadioButton.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.toDateTimePicker)
        Me.GroupBox3.Controls.Add(Me.fromDateTimePicker)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(425, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(125, 68)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Time of Day"
        '
        'toDateTimePicker
        '
        Me.toDateTimePicker.CustomFormat = "hh:mm tt"
        Me.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.toDateTimePicker.Location = New System.Drawing.Point(42, 42)
        Me.toDateTimePicker.Name = "toDateTimePicker"
        Me.toDateTimePicker.ShowUpDown = True
        Me.toDateTimePicker.Size = New System.Drawing.Size(76, 20)
        Me.toDateTimePicker.TabIndex = 5
        Me.ShowScheduleToolTip.SetToolTip(Me.toDateTimePicker, "Latest time a class can end to be considered")
        Me.toDateTimePicker.Value = New Date(2014, 3, 31, 23, 59, 0, 0)
        '
        'fromDateTimePicker
        '
        Me.fromDateTimePicker.CustomFormat = "hh:mm tt"
        Me.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fromDateTimePicker.Location = New System.Drawing.Point(42, 17)
        Me.fromDateTimePicker.Name = "fromDateTimePicker"
        Me.fromDateTimePicker.ShowUpDown = True
        Me.fromDateTimePicker.Size = New System.Drawing.Size(76, 20)
        Me.fromDateTimePicker.TabIndex = 4
        Me.ShowScheduleToolTip.SetToolTip(Me.fromDateTimePicker, "Earliest time a class can begin to be considered")
        Me.fromDateTimePicker.Value = New Date(2014, 3, 31, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "From"
        '
        'checkButton
        '
        Me.checkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.checkButton.Enabled = False
        Me.checkButton.Location = New System.Drawing.Point(574, 432)
        Me.checkButton.Name = "checkButton"
        Me.checkButton.Size = New System.Drawing.Size(75, 37)
        Me.checkButton.TabIndex = 3
        Me.checkButton.Text = "Check"
        Me.ShowScheduleToolTip.SetToolTip(Me.checkButton, "Click here to see all possible schedules")
        Me.checkButton.UseVisualStyleBackColor = True
        '
        'outputDataGridView
        '
        Me.outputDataGridView.AllowUserToAddRows = False
        Me.outputDataGridView.AllowUserToDeleteRows = False
        Me.outputDataGridView.AllowUserToOrderColumns = True
        Me.outputDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.outputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.outputDataGridView.ContextMenuStrip = Me.ResultsContextMenu
        Me.outputDataGridView.Location = New System.Drawing.Point(5, 119)
        Me.outputDataGridView.Name = "outputDataGridView"
        Me.outputDataGridView.ReadOnly = True
        Me.outputDataGridView.RowHeadersVisible = False
        Me.outputDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.outputDataGridView.ShowEditingIcon = False
        Me.outputDataGridView.Size = New System.Drawing.Size(644, 290)
        Me.outputDataGridView.TabIndex = 1
        '
        'ResultsContextMenu
        '
        Me.ResultsContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.copyOneRow, Me.ToolStripSeparator1, Me.CopyFirst4RowsToolStripMenuItem, Me.copyTenRows, Me.copy100rows, Me.CopyAllRowsToolStripMenuItem})
        Me.ResultsContextMenu.Name = "ResultsContextMenu"
        Me.ResultsContextMenu.Size = New System.Drawing.Size(180, 142)
        '
        'copyOneRow
        '
        Me.copyOneRow.Name = "copyOneRow"
        Me.copyOneRow.Size = New System.Drawing.Size(179, 22)
        Me.copyOneRow.Text = "Copy Current Row"
        '
        'copyTenRows
        '
        Me.copyTenRows.Name = "copyTenRows"
        Me.copyTenRows.Size = New System.Drawing.Size(179, 22)
        Me.copyTenRows.Text = "Copy First 10 Rows"
        '
        'copy100rows
        '
        Me.copy100rows.Name = "copy100rows"
        Me.copy100rows.Size = New System.Drawing.Size(179, 22)
        Me.copy100rows.Text = "Copy First 100 Rows"
        '
        'errorLabel
        '
        Me.errorLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.errorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.errorLabel.Location = New System.Drawing.Point(12, 195)
        Me.errorLabel.Name = "errorLabel"
        Me.errorLabel.Size = New System.Drawing.Size(631, 91)
        Me.errorLabel.TabIndex = 2
        Me.errorLabel.Text = "Select a sequence to validate, and then " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "press the ""Check"" button"
        Me.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'extraDataLabel
        '
        Me.extraDataLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.extraDataLabel.Location = New System.Drawing.Point(13, 412)
        Me.extraDataLabel.Name = "extraDataLabel"
        Me.extraDataLabel.Size = New System.Drawing.Size(555, 46)
        Me.extraDataLabel.TabIndex = 3
        '
        'NotFullCheckBox
        '
        Me.NotFullCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NotFullCheckBox.AutoSize = True
        Me.NotFullCheckBox.Enabled = False
        Me.NotFullCheckBox.Location = New System.Drawing.Point(5, 461)
        Me.NotFullCheckBox.Name = "NotFullCheckBox"
        Me.NotFullCheckBox.Size = New System.Drawing.Size(177, 17)
        Me.NotFullCheckBox.TabIndex = 4
        Me.NotFullCheckBox.Text = "Limit Search to Non-Full Classes"
        Me.NotFullCheckBox.UseVisualStyleBackColor = True
        '
        'CheckProgressBar
        '
        Me.CheckProgressBar.Location = New System.Drawing.Point(16, 415)
        Me.CheckProgressBar.Name = "CheckProgressBar"
        Me.CheckProgressBar.Size = New System.Drawing.Size(552, 40)
        Me.CheckProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.CheckProgressBar.TabIndex = 5
        Me.CheckProgressBar.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(176, 6)
        '
        'CopyAllRowsToolStripMenuItem
        '
        Me.CopyAllRowsToolStripMenuItem.Name = "CopyAllRowsToolStripMenuItem"
        Me.CopyAllRowsToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.CopyAllRowsToolStripMenuItem.Text = "Copy All Rows"
        '
        'CopyFirst4RowsToolStripMenuItem
        '
        Me.CopyFirst4RowsToolStripMenuItem.Name = "CopyFirst4RowsToolStripMenuItem"
        Me.CopyFirst4RowsToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.CopyFirst4RowsToolStripMenuItem.Text = "Copy First 4 Rows"
        '
        'ShowPotentialSchedules
        '
        Me.AcceptButton = Me.checkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 478)
        Me.Controls.Add(Me.CheckProgressBar)
        Me.Controls.Add(Me.NotFullCheckBox)
        Me.Controls.Add(Me.checkButton)
        Me.Controls.Add(Me.extraDataLabel)
        Me.Controls.Add(Me.errorLabel)
        Me.Controls.Add(Me.outputDataGridView)
        Me.Controls.Add(Me.inputTabControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ShowPotentialSchedules"
        Me.Text = "Show Potential Schedules"
        Me.inputTabControl.ResumeLayout(False)
        Me.generalTabPage.ResumeLayout(False)
        Me.generalTabPage.PerformLayout()
        Me.criteriaTabPage.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.maxDaysUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.outputDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResultsContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents inputTabControl As System.Windows.Forms.TabControl
    Friend WithEvents generalTabPage As System.Windows.Forms.TabPage
    Friend WithEvents checkButton As System.Windows.Forms.Button
    Friend WithEvents coursesBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents preDefinedComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents criteriaTabPage As System.Windows.Forms.TabPage
    Friend WithEvents outputDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents errorLabel As System.Windows.Forms.Label
    Friend WithEvents extraDataLabel As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents eitherRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents onlineRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents classroomRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents toDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents fromDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents FriBox As System.Windows.Forms.CheckBox
    Friend WithEvents SatBox As System.Windows.Forms.CheckBox
    Friend WithEvents WedBox As System.Windows.Forms.CheckBox
    Friend WithEvents ThurBox As System.Windows.Forms.CheckBox
    Friend WithEvents TueBox As System.Windows.Forms.CheckBox
    Friend WithEvents MonBox As System.Windows.Forms.CheckBox
    Friend WithEvents sunBox As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents roomBox As System.Windows.Forms.TextBox
    Friend WithEvents ShowScheduleToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents maxDaysUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents NotFullCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents CheckProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents ResultsContextMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents copyOneRow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents copyTenRows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents copy100rows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CopyAllRowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyFirst4RowsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
