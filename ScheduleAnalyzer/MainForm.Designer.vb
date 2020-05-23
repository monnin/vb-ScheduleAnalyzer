<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.openButton = New System.Windows.Forms.Button()
        Me.facultyLabel = New System.Windows.Forms.Label()
        Me.StatusBox = New System.Windows.Forms.Label()
        Me.outputLabel = New System.Windows.Forms.Label()
        Me.retestButton = New System.Windows.Forms.Button()
        Me.TopMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReLoadTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyConflictsAndWarningsToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyCourseLoadListToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FreeTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindAllSchedulesThatMatchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowSequenceWarningsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowCourseLengthWarningsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UseOpenSpreadsheetifPossibleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.IncludeInformationalResultsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckCourseMeetsContactHoursMinimumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.FacultyLimitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcelSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReleaseNotesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YCCCWebsiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.findTimeButton = New System.Windows.Forms.Button()
        Me.LargeProgressBar = New System.Windows.Forms.ProgressBar()
        Me.workingLabel = New System.Windows.Forms.Label()
        Me.outputView = New System.Windows.Forms.ListView()
        Me.Type = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Severity = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Description = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Text1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Loc1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Text2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Loc2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mainContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.copyMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.printMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConflictFacSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.SubStatusLabel = New System.Windows.Forms.Label()
        Me.logoPictureBox = New System.Windows.Forms.PictureBox()
        Me.startHerePictureBox = New System.Windows.Forms.PictureBox()
        Me.findSchedulesButton = New System.Windows.Forms.Button()
        Me.facCountView = New System.Windows.Forms.ListView()
        Me.ColName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCount = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AllowGhostSectionsForSequencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TopMenu.SuspendLayout()
        Me.mainContextMenuStrip.SuspendLayout()
        CType(Me.ConflictFacSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ConflictFacSplitContainer.Panel1.SuspendLayout()
        Me.ConflictFacSplitContainer.Panel2.SuspendLayout()
        Me.ConflictFacSplitContainer.SuspendLayout()
        CType(Me.logoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.startHerePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'openButton
        '
        Me.openButton.Location = New System.Drawing.Point(12, 30)
        Me.openButton.Name = "openButton"
        Me.openButton.Size = New System.Drawing.Size(149, 23)
        Me.openButton.TabIndex = 0
        Me.openButton.Text = "Load Spreadsheet..."
        Me.openButton.UseVisualStyleBackColor = True
        '
        'facultyLabel
        '
        Me.facultyLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facultyLabel.AutoSize = True
        Me.facultyLabel.Location = New System.Drawing.Point(3, 1)
        Me.facultyLabel.Name = "facultyLabel"
        Me.facultyLabel.Size = New System.Drawing.Size(147, 13)
        Me.facultyLabel.TabIndex = 4
        Me.facultyLabel.Text = "Faculty With Course Load > 3"
        '
        'StatusBox
        '
        Me.StatusBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatusBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusBox.Location = New System.Drawing.Point(362, 24)
        Me.StatusBox.Name = "StatusBox"
        Me.StatusBox.Size = New System.Drawing.Size(274, 50)
        Me.StatusBox.TabIndex = 6
        '
        'outputLabel
        '
        Me.outputLabel.AutoSize = True
        Me.outputLabel.Location = New System.Drawing.Point(3, 1)
        Me.outputLabel.Name = "outputLabel"
        Me.outputLabel.Size = New System.Drawing.Size(125, 13)
        Me.outputLabel.TabIndex = 7
        Me.outputLabel.Text = "Conflicts and Warnings..."
        '
        'retestButton
        '
        Me.retestButton.Enabled = False
        Me.retestButton.Location = New System.Drawing.Point(176, 30)
        Me.retestButton.Name = "retestButton"
        Me.retestButton.Size = New System.Drawing.Size(170, 23)
        Me.retestButton.TabIndex = 8
        Me.retestButton.Text = "Re-Check Spreadsheet"
        Me.retestButton.UseVisualStyleBackColor = True
        '
        'TopMenu
        '
        Me.TopMenu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TopMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.FindToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.TopMenu.Location = New System.Drawing.Point(0, 0)
        Me.TopMenu.Name = "TopMenu"
        Me.TopMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.TopMenu.Size = New System.Drawing.Size(825, 24)
        Me.TopMenu.TabIndex = 10
        Me.TopMenu.Text = "Top Menu"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ReLoadTestToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.OpenToolStripMenuItem.Text = "Open..."
        '
        'ReLoadTestToolStripMenuItem
        '
        Me.ReLoadTestToolStripMenuItem.Enabled = False
        Me.ReLoadTestToolStripMenuItem.Name = "ReLoadTestToolStripMenuItem"
        Me.ReLoadTestToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.ReLoadTestToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ReLoadTestToolStripMenuItem.Text = "Re-Load and Test"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyConflictsAndWarningsToClipboardToolStripMenuItem, Me.CopyCourseLoadListToClipboardToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'CopyConflictsAndWarningsToClipboardToolStripMenuItem
        '
        Me.CopyConflictsAndWarningsToClipboardToolStripMenuItem.Name = "CopyConflictsAndWarningsToClipboardToolStripMenuItem"
        Me.CopyConflictsAndWarningsToClipboardToolStripMenuItem.Size = New System.Drawing.Size(297, 22)
        Me.CopyConflictsAndWarningsToClipboardToolStripMenuItem.Text = "Copy Conflicts and Warnings to Clipboard"
        '
        'CopyCourseLoadListToClipboardToolStripMenuItem
        '
        Me.CopyCourseLoadListToClipboardToolStripMenuItem.Name = "CopyCourseLoadListToClipboardToolStripMenuItem"
        Me.CopyCourseLoadListToClipboardToolStripMenuItem.Size = New System.Drawing.Size(297, 22)
        Me.CopyCourseLoadListToClipboardToolStripMenuItem.Text = "Copy Course Load List to Clipboard"
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FreeTimeToolStripMenuItem, Me.FindAllSchedulesThatMatchToolStripMenuItem})
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
        Me.FindToolStripMenuItem.Text = "Find"
        '
        'FreeTimeToolStripMenuItem
        '
        Me.FreeTimeToolStripMenuItem.Enabled = False
        Me.FreeTimeToolStripMenuItem.Name = "FreeTimeToolStripMenuItem"
        Me.FreeTimeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.FreeTimeToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.FreeTimeToolStripMenuItem.Text = "Find Time for a Class..."
        '
        'FindAllSchedulesThatMatchToolStripMenuItem
        '
        Me.FindAllSchedulesThatMatchToolStripMenuItem.Enabled = False
        Me.FindAllSchedulesThatMatchToolStripMenuItem.Name = "FindAllSchedulesThatMatchToolStripMenuItem"
        Me.FindAllSchedulesThatMatchToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.FindAllSchedulesThatMatchToolStripMenuItem.Text = "Find All Schedules that Match..."
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowSequenceWarningsToolStripMenuItem, Me.ShowCourseLengthWarningsToolStripMenuItem, Me.AllowGhostSectionsForSequencesToolStripMenuItem, Me.ToolStripSeparator1, Me.UseOpenSpreadsheetifPossibleToolStripMenuItem, Me.ToolStripSeparator2, Me.IncludeInformationalResultsToolStripMenuItem, Me.CheckCourseMeetsContactHoursMinimumToolStripMenuItem, Me.ToolStripSeparator3, Me.FacultyLimitToolStripMenuItem, Me.ExcelSettingsToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ShowSequenceWarningsToolStripMenuItem
        '
        Me.ShowSequenceWarningsToolStripMenuItem.Name = "ShowSequenceWarningsToolStripMenuItem"
        Me.ShowSequenceWarningsToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.ShowSequenceWarningsToolStripMenuItem.Text = "Show Sequence Warnings"
        '
        'ShowCourseLengthWarningsToolStripMenuItem
        '
        Me.ShowCourseLengthWarningsToolStripMenuItem.Name = "ShowCourseLengthWarningsToolStripMenuItem"
        Me.ShowCourseLengthWarningsToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.ShowCourseLengthWarningsToolStripMenuItem.Text = "Show Course Length Warnings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(315, 6)
        '
        'UseOpenSpreadsheetifPossibleToolStripMenuItem
        '
        Me.UseOpenSpreadsheetifPossibleToolStripMenuItem.Name = "UseOpenSpreadsheetifPossibleToolStripMenuItem"
        Me.UseOpenSpreadsheetifPossibleToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.UseOpenSpreadsheetifPossibleToolStripMenuItem.Text = "Use Open Spreadsheet (when possible)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(315, 6)
        '
        'IncludeInformationalResultsToolStripMenuItem
        '
        Me.IncludeInformationalResultsToolStripMenuItem.Name = "IncludeInformationalResultsToolStripMenuItem"
        Me.IncludeInformationalResultsToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.IncludeInformationalResultsToolStripMenuItem.Text = "Include Informational Results"
        '
        'CheckCourseMeetsContactHoursMinimumToolStripMenuItem
        '
        Me.CheckCourseMeetsContactHoursMinimumToolStripMenuItem.Name = "CheckCourseMeetsContactHoursMinimumToolStripMenuItem"
        Me.CheckCourseMeetsContactHoursMinimumToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.CheckCourseMeetsContactHoursMinimumToolStripMenuItem.Text = "Check Course Meets Contact Hours Minimum"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(315, 6)
        '
        'FacultyLimitToolStripMenuItem
        '
        Me.FacultyLimitToolStripMenuItem.Name = "FacultyLimitToolStripMenuItem"
        Me.FacultyLimitToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.FacultyLimitToolStripMenuItem.Text = "Faculty Limit..."
        '
        'ExcelSettingsToolStripMenuItem
        '
        Me.ExcelSettingsToolStripMenuItem.Name = "ExcelSettingsToolStripMenuItem"
        Me.ExcelSettingsToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.ExcelSettingsToolStripMenuItem.Text = "Excel Settings..."
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.ReleaseNotesToolStripMenuItem, Me.YCCCWebsiteToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AboutToolStripMenuItem.Text = "About..."
        '
        'ReleaseNotesToolStripMenuItem
        '
        Me.ReleaseNotesToolStripMenuItem.Name = "ReleaseNotesToolStripMenuItem"
        Me.ReleaseNotesToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ReleaseNotesToolStripMenuItem.Text = "Release Notes..."
        '
        'YCCCWebsiteToolStripMenuItem
        '
        Me.YCCCWebsiteToolStripMenuItem.Name = "YCCCWebsiteToolStripMenuItem"
        Me.YCCCWebsiteToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.YCCCWebsiteToolStripMenuItem.Text = "YCCC Website..."
        '
        'findTimeButton
        '
        Me.findTimeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.findTimeButton.Enabled = False
        Me.findTimeButton.Location = New System.Drawing.Point(28, 393)
        Me.findTimeButton.Name = "findTimeButton"
        Me.findTimeButton.Size = New System.Drawing.Size(131, 25)
        Me.findTimeButton.TabIndex = 11
        Me.findTimeButton.Text = "Find Time for a Class..."
        Me.findTimeButton.UseVisualStyleBackColor = True
        '
        'LargeProgressBar
        '
        Me.LargeProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LargeProgressBar.Location = New System.Drawing.Point(102, 62)
        Me.LargeProgressBar.Name = "LargeProgressBar"
        Me.LargeProgressBar.Size = New System.Drawing.Size(637, 40)
        Me.LargeProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.LargeProgressBar.TabIndex = 12
        Me.LargeProgressBar.Visible = False
        '
        'workingLabel
        '
        Me.workingLabel.AutoSize = True
        Me.workingLabel.BackColor = System.Drawing.SystemColors.Control
        Me.workingLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.workingLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.workingLabel.Location = New System.Drawing.Point(318, 30)
        Me.workingLabel.Name = "workingLabel"
        Me.workingLabel.Size = New System.Drawing.Size(130, 29)
        Me.workingLabel.TabIndex = 13
        Me.workingLabel.Text = "Working..."
        Me.workingLabel.Visible = False
        '
        'outputView
        '
        Me.outputView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.outputView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Type, Me.Severity, Me.Description, Me.Text1, Me.Loc1, Me.Text2, Me.Loc2})
        Me.outputView.ContextMenuStrip = Me.mainContextMenuStrip
        Me.outputView.FullRowSelect = True
        Me.outputView.Location = New System.Drawing.Point(6, 17)
        Me.outputView.Name = "outputView"
        Me.outputView.OwnerDraw = True
        Me.outputView.Size = New System.Drawing.Size(629, 431)
        Me.outputView.TabIndex = 15
        Me.outputView.UseCompatibleStateImageBehavior = False
        Me.outputView.View = System.Windows.Forms.View.Details
        '
        'Type
        '
        Me.Type.Text = "Type"
        Me.Type.Width = 75
        '
        'Severity
        '
        Me.Severity.Text = "Severity"
        Me.Severity.Width = 25
        '
        'Description
        '
        Me.Description.Text = "Description"
        Me.Description.Width = 600
        '
        'Text1
        '
        Me.Text1.DisplayIndex = 5
        Me.Text1.Text = "Text1"
        Me.Text1.Width = 0
        '
        'Loc1
        '
        Me.Loc1.DisplayIndex = 3
        Me.Loc1.Text = "Loc 1"
        Me.Loc1.Width = 0
        '
        'Text2
        '
        Me.Text2.DisplayIndex = 6
        Me.Text2.Text = "Text2"
        Me.Text2.Width = 0
        '
        'Loc2
        '
        Me.Loc2.DisplayIndex = 4
        Me.Loc2.Text = "Loc 2"
        Me.Loc2.Width = 0
        '
        'mainContextMenuStrip
        '
        Me.mainContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.copyMenuItem, Me.printMenuItem})
        Me.mainContextMenuStrip.Name = "mainContextMenuStrip"
        Me.mainContextMenuStrip.ShowImageMargin = False
        Me.mainContextMenuStrip.Size = New System.Drawing.Size(78, 48)
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
        'ConflictFacSplitContainer
        '
        Me.ConflictFacSplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConflictFacSplitContainer.Location = New System.Drawing.Point(0, 59)
        Me.ConflictFacSplitContainer.Name = "ConflictFacSplitContainer"
        '
        'ConflictFacSplitContainer.Panel1
        '
        Me.ConflictFacSplitContainer.Panel1.Controls.Add(Me.SubStatusLabel)
        Me.ConflictFacSplitContainer.Panel1.Controls.Add(Me.LargeProgressBar)
        Me.ConflictFacSplitContainer.Panel1.Controls.Add(Me.outputView)
        Me.ConflictFacSplitContainer.Panel1.Controls.Add(Me.workingLabel)
        Me.ConflictFacSplitContainer.Panel1.Controls.Add(Me.outputLabel)
        Me.ConflictFacSplitContainer.Panel1.Controls.Add(Me.logoPictureBox)
        Me.ConflictFacSplitContainer.Panel1.Controls.Add(Me.startHerePictureBox)
        '
        'ConflictFacSplitContainer.Panel2
        '
        Me.ConflictFacSplitContainer.Panel2.Controls.Add(Me.findSchedulesButton)
        Me.ConflictFacSplitContainer.Panel2.Controls.Add(Me.findTimeButton)
        Me.ConflictFacSplitContainer.Panel2.Controls.Add(Me.facCountView)
        Me.ConflictFacSplitContainer.Panel2.Controls.Add(Me.facultyLabel)
        Me.ConflictFacSplitContainer.Size = New System.Drawing.Size(825, 460)
        Me.ConflictFacSplitContainer.SplitterDistance = 635
        Me.ConflictFacSplitContainer.TabIndex = 16
        '
        'SubStatusLabel
        '
        Me.SubStatusLabel.AutoSize = True
        Me.SubStatusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubStatusLabel.Location = New System.Drawing.Point(331, 109)
        Me.SubStatusLabel.Name = "SubStatusLabel"
        Me.SubStatusLabel.Size = New System.Drawing.Size(32, 17)
        Me.SubStatusLabel.TabIndex = 17
        Me.SubStatusLabel.Text = "???"
        Me.SubStatusLabel.Visible = False
        '
        'logoPictureBox
        '
        Me.logoPictureBox.Image = CType(resources.GetObject("logoPictureBox.Image"), System.Drawing.Image)
        Me.logoPictureBox.Location = New System.Drawing.Point(24, 141)
        Me.logoPictureBox.Name = "logoPictureBox"
        Me.logoPictureBox.Size = New System.Drawing.Size(510, 315)
        Me.logoPictureBox.TabIndex = 16
        Me.logoPictureBox.TabStop = False
        '
        'startHerePictureBox
        '
        Me.startHerePictureBox.Image = Global.ScheduleAnalyzer.My.Resources.Resources.start_here
        Me.startHerePictureBox.Location = New System.Drawing.Point(110, 5)
        Me.startHerePictureBox.Name = "startHerePictureBox"
        Me.startHerePictureBox.Size = New System.Drawing.Size(226, 67)
        Me.startHerePictureBox.TabIndex = 17
        Me.startHerePictureBox.TabStop = False
        '
        'findSchedulesButton
        '
        Me.findSchedulesButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.findSchedulesButton.Enabled = False
        Me.findSchedulesButton.Location = New System.Drawing.Point(28, 424)
        Me.findSchedulesButton.Name = "findSchedulesButton"
        Me.findSchedulesButton.Size = New System.Drawing.Size(131, 23)
        Me.findSchedulesButton.TabIndex = 12
        Me.findSchedulesButton.Text = "Find Schedules..."
        Me.findSchedulesButton.UseVisualStyleBackColor = True
        '
        'facCountView
        '
        Me.facCountView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.facCountView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColName, Me.ColCount})
        Me.facCountView.ContextMenuStrip = Me.mainContextMenuStrip
        Me.facCountView.FullRowSelect = True
        Me.facCountView.Location = New System.Drawing.Point(3, 18)
        Me.facCountView.Name = "facCountView"
        Me.facCountView.Size = New System.Drawing.Size(180, 367)
        Me.facCountView.Sorting = System.Windows.Forms.SortOrder.Descending
        Me.facCountView.TabIndex = 10
        Me.facCountView.UseCompatibleStateImageBehavior = False
        Me.facCountView.View = System.Windows.Forms.View.Details
        '
        'ColName
        '
        Me.ColName.Text = "Name"
        Me.ColName.Width = 115
        '
        'ColCount
        '
        Me.ColCount.Text = "Count"
        Me.ColCount.Width = 40
        '
        'AllowGhostSectionsForSequencesToolStripMenuItem
        '
        Me.AllowGhostSectionsForSequencesToolStripMenuItem.Name = "AllowGhostSectionsForSequencesToolStripMenuItem"
        Me.AllowGhostSectionsForSequencesToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.AllowGhostSectionsForSequencesToolStripMenuItem.Text = "Allow Ghost Sections for Sequences"
        Me.AllowGhostSectionsForSequencesToolStripMenuItem.ToolTipText = "Normally a ghosted section is ignored in seeing if a schedule is viable, but with" & _
    " this option the sequence will use these sections too"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 522)
        Me.Controls.Add(Me.retestButton)
        Me.Controls.Add(Me.StatusBox)
        Me.Controls.Add(Me.openButton)
        Me.Controls.Add(Me.TopMenu)
        Me.Controls.Add(Me.ConflictFacSplitContainer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.TopMenu
        Me.Name = "MainForm"
        Me.Text = "Schedule Analyzer"
        Me.TopMenu.ResumeLayout(False)
        Me.TopMenu.PerformLayout()
        Me.mainContextMenuStrip.ResumeLayout(False)
        Me.ConflictFacSplitContainer.Panel1.ResumeLayout(False)
        Me.ConflictFacSplitContainer.Panel1.PerformLayout()
        Me.ConflictFacSplitContainer.Panel2.ResumeLayout(False)
        Me.ConflictFacSplitContainer.Panel2.PerformLayout()
        CType(Me.ConflictFacSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ConflictFacSplitContainer.ResumeLayout(False)
        CType(Me.logoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.startHerePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents openButton As System.Windows.Forms.Button
    Friend WithEvents facultyLabel As System.Windows.Forms.Label
    Friend WithEvents StatusBox As System.Windows.Forms.Label
    Friend WithEvents outputLabel As System.Windows.Forms.Label
    Friend WithEvents retestButton As System.Windows.Forms.Button
    Friend WithEvents TopMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReLoadTestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents findTimeButton As System.Windows.Forms.Button
    Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FreeTimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YCCCWebsiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FacultyLimitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowCourseLengthWarningsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LargeProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents workingLabel As System.Windows.Forms.Label
    Friend WithEvents UseOpenSpreadsheetifPossibleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExcelSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ShowSequenceWarningsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents outputView As System.Windows.Forms.ListView
    Friend WithEvents Type As System.Windows.Forms.ColumnHeader
    Friend WithEvents Severity As System.Windows.Forms.ColumnHeader
    Friend WithEvents Description As System.Windows.Forms.ColumnHeader
    Friend WithEvents Loc1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Loc2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Text1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Text2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyConflictsAndWarningsToClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyCourseLoadListToClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConflictFacSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents facCountView As System.Windows.Forms.ListView
    Friend WithEvents ColName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColCount As System.Windows.Forms.ColumnHeader
    Friend WithEvents SubStatusLabel As System.Windows.Forms.Label
    Friend WithEvents mainContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents copyMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents printMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FindAllSchedulesThatMatchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents findSchedulesButton As System.Windows.Forms.Button
    Friend WithEvents IncludeInformationalResultsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CheckCourseMeetsContactHoursMinimumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReleaseNotesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents logoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents startHerePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AllowGhostSectionsForSequencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
