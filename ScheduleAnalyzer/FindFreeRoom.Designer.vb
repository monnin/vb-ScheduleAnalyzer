<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindFreeRoom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindFreeRoom))
        Me.findButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ResultBox = New System.Windows.Forms.TextBox()
        Me.daysBox = New System.Windows.Forms.ComboBox()
        Me.startTimeBox = New System.Windows.Forms.ComboBox()
        Me.endTimeBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.searchTabControl = New System.Windows.Forms.TabControl()
        Me.timeDateTab = New System.Windows.Forms.TabPage()
        Me.capabilitiesTab = New System.Windows.Forms.TabPage()
        Me.matchAnyRB = New System.Windows.Forms.RadioButton()
        Me.matchAllRB = New System.Windows.Forms.RadioButton()
        Me.capabilitiesLabel = New System.Windows.Forms.Label()
        Me.capabilitiesTable = New System.Windows.Forms.TableLayoutPanel()
        Me.initialLabel = New System.Windows.Forms.Label()
        Me.endInitialLabel = New System.Windows.Forms.Label()
        Me.minSizeBox = New System.Windows.Forms.TextBox()
        Me.verticalSplitContainer = New System.Windows.Forms.SplitContainer()
        Me.searchTabControl.SuspendLayout()
        Me.timeDateTab.SuspendLayout()
        Me.capabilitiesTab.SuspendLayout()
        CType(Me.verticalSplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.verticalSplitContainer.Panel1.SuspendLayout()
        Me.verticalSplitContainer.Panel2.SuspendLayout()
        Me.verticalSplitContainer.SuspendLayout()
        Me.SuspendLayout()
        '
        'findButton
        '
        Me.findButton.Location = New System.Drawing.Point(16, 13)
        Me.findButton.Name = "findButton"
        Me.findButton.Size = New System.Drawing.Size(75, 23)
        Me.findButton.TabIndex = 0
        Me.findButton.Text = "Find!"
        Me.findButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Days"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(62, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Start Time"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "End Time"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(286, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "(e.g. 2:30 PM)"
        '
        'ResultBox
        '
        Me.ResultBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ResultBox.Location = New System.Drawing.Point(16, 41)
        Me.ResultBox.Multiline = True
        Me.ResultBox.Name = "ResultBox"
        Me.ResultBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ResultBox.Size = New System.Drawing.Size(549, 249)
        Me.ResultBox.TabIndex = 9
        '
        'daysBox
        '
        Me.daysBox.FormattingEnabled = True
        Me.daysBox.Items.AddRange(New Object() {"Mon Wed", "Tue Thur", "Mon", "Tue", "Wed", "Thur", "Fri", "Sat"})
        Me.daysBox.Location = New System.Drawing.Point(87, 7)
        Me.daysBox.Name = "daysBox"
        Me.daysBox.Size = New System.Drawing.Size(213, 21)
        Me.daysBox.TabIndex = 10
        '
        'startTimeBox
        '
        Me.startTimeBox.FormattingEnabled = True
        Me.startTimeBox.Items.AddRange(New Object() {"8:00 AM", "9:30 AM", "11:00 AM", "1:00 PM", "2:30 PM", "4:00 PM", "5:30 PM"})
        Me.startTimeBox.Location = New System.Drawing.Point(133, 44)
        Me.startTimeBox.Name = "startTimeBox"
        Me.startTimeBox.Size = New System.Drawing.Size(149, 21)
        Me.startTimeBox.TabIndex = 11
        '
        'endTimeBox
        '
        Me.endTimeBox.FormattingEnabled = True
        Me.endTimeBox.Items.AddRange(New Object() {"9:15 AM", "10:45 AM", "12:15 PM", "2:15 PM", "3:45 PM", "8:00 PM"})
        Me.endTimeBox.Location = New System.Drawing.Point(133, 76)
        Me.endTimeBox.Name = "endTimeBox"
        Me.endTimeBox.Size = New System.Drawing.Size(149, 21)
        Me.endTimeBox.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(350, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "(e.g. Mon Wed)"
        '
        'searchTabControl
        '
        Me.searchTabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.searchTabControl.Controls.Add(Me.timeDateTab)
        Me.searchTabControl.Controls.Add(Me.capabilitiesTab)
        Me.searchTabControl.Location = New System.Drawing.Point(13, 0)
        Me.searchTabControl.Name = "searchTabControl"
        Me.searchTabControl.SelectedIndex = 0
        Me.searchTabControl.Size = New System.Drawing.Size(556, 188)
        Me.searchTabControl.TabIndex = 13
        '
        'timeDateTab
        '
        Me.timeDateTab.Controls.Add(Me.Label1)
        Me.timeDateTab.Controls.Add(Me.endTimeBox)
        Me.timeDateTab.Controls.Add(Me.Label2)
        Me.timeDateTab.Controls.Add(Me.startTimeBox)
        Me.timeDateTab.Controls.Add(Me.Label3)
        Me.timeDateTab.Controls.Add(Me.daysBox)
        Me.timeDateTab.Controls.Add(Me.Label4)
        Me.timeDateTab.Controls.Add(Me.Label5)
        Me.timeDateTab.Location = New System.Drawing.Point(4, 22)
        Me.timeDateTab.Name = "timeDateTab"
        Me.timeDateTab.Padding = New System.Windows.Forms.Padding(3)
        Me.timeDateTab.Size = New System.Drawing.Size(548, 162)
        Me.timeDateTab.TabIndex = 0
        Me.timeDateTab.Text = "Time & Date"
        Me.timeDateTab.UseVisualStyleBackColor = True
        '
        'capabilitiesTab
        '
        Me.capabilitiesTab.Controls.Add(Me.matchAnyRB)
        Me.capabilitiesTab.Controls.Add(Me.matchAllRB)
        Me.capabilitiesTab.Controls.Add(Me.capabilitiesLabel)
        Me.capabilitiesTab.Controls.Add(Me.capabilitiesTable)
        Me.capabilitiesTab.Controls.Add(Me.initialLabel)
        Me.capabilitiesTab.Controls.Add(Me.endInitialLabel)
        Me.capabilitiesTab.Controls.Add(Me.minSizeBox)
        Me.capabilitiesTab.Location = New System.Drawing.Point(4, 22)
        Me.capabilitiesTab.Name = "capabilitiesTab"
        Me.capabilitiesTab.Padding = New System.Windows.Forms.Padding(3)
        Me.capabilitiesTab.Size = New System.Drawing.Size(548, 162)
        Me.capabilitiesTab.TabIndex = 1
        Me.capabilitiesTab.Text = "Capabilities & Resources"
        Me.capabilitiesTab.UseVisualStyleBackColor = True
        '
        'matchAnyRB
        '
        Me.matchAnyRB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.matchAnyRB.AutoSize = True
        Me.matchAnyRB.Location = New System.Drawing.Point(301, 139)
        Me.matchAnyRB.Name = "matchAnyRB"
        Me.matchAnyRB.Size = New System.Drawing.Size(237, 17)
        Me.matchAnyRB.TabIndex = 6
        Me.matchAnyRB.Text = "Rooms must have ANY of the checked items"
        Me.matchAnyRB.UseVisualStyleBackColor = True
        '
        'matchAllRB
        '
        Me.matchAllRB.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.matchAllRB.AutoSize = True
        Me.matchAllRB.Checked = True
        Me.matchAllRB.Location = New System.Drawing.Point(10, 139)
        Me.matchAllRB.Name = "matchAllRB"
        Me.matchAllRB.Size = New System.Drawing.Size(234, 17)
        Me.matchAllRB.TabIndex = 5
        Me.matchAllRB.TabStop = True
        Me.matchAllRB.Text = "Rooms must have ALL of the checked items"
        Me.matchAllRB.UseVisualStyleBackColor = True
        '
        'capabilitiesLabel
        '
        Me.capabilitiesLabel.AutoSize = True
        Me.capabilitiesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capabilitiesLabel.Location = New System.Drawing.Point(49, 9)
        Me.capabilitiesLabel.Name = "capabilitiesLabel"
        Me.capabilitiesLabel.Size = New System.Drawing.Size(460, 20)
        Me.capabilitiesLabel.TabIndex = 0
        Me.capabilitiesLabel.Text = "No capabilities defined in the spreadsheet, please add them first"
        Me.capabilitiesLabel.Visible = False
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
        Me.capabilitiesTable.Location = New System.Drawing.Point(10, 32)
        Me.capabilitiesTable.Name = "capabilitiesTable"
        Me.capabilitiesTable.RowCount = 1
        Me.capabilitiesTable.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.capabilitiesTable.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102.0!))
        Me.capabilitiesTable.Size = New System.Drawing.Size(528, 102)
        Me.capabilitiesTable.TabIndex = 4
        '
        'initialLabel
        '
        Me.initialLabel.AutoSize = True
        Me.initialLabel.Location = New System.Drawing.Point(7, 9)
        Me.initialLabel.Name = "initialLabel"
        Me.initialLabel.Size = New System.Drawing.Size(160, 13)
        Me.initialLabel.TabIndex = 3
        Me.initialLabel.Text = "Find rooms that can hold at least"
        '
        'endInitialLabel
        '
        Me.endInitialLabel.AutoSize = True
        Me.endInitialLabel.Location = New System.Drawing.Point(269, 9)
        Me.endInitialLabel.Name = "endInitialLabel"
        Me.endInitialLabel.Size = New System.Drawing.Size(217, 13)
        Me.endInitialLabel.TabIndex = 2
        Me.endInitialLabel.Text = "students, and has the following capabilities..."
        '
        'minSizeBox
        '
        Me.minSizeBox.Location = New System.Drawing.Point(172, 6)
        Me.minSizeBox.Name = "minSizeBox"
        Me.minSizeBox.Size = New System.Drawing.Size(91, 20)
        Me.minSizeBox.TabIndex = 1
        '
        'verticalSplitContainer
        '
        Me.verticalSplitContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.verticalSplitContainer.Location = New System.Drawing.Point(1, 2)
        Me.verticalSplitContainer.Name = "verticalSplitContainer"
        Me.verticalSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'verticalSplitContainer.Panel1
        '
        Me.verticalSplitContainer.Panel1.Controls.Add(Me.searchTabControl)
        '
        'verticalSplitContainer.Panel2
        '
        Me.verticalSplitContainer.Panel2.Controls.Add(Me.ResultBox)
        Me.verticalSplitContainer.Panel2.Controls.Add(Me.findButton)
        Me.verticalSplitContainer.Size = New System.Drawing.Size(572, 501)
        Me.verticalSplitContainer.SplitterDistance = 191
        Me.verticalSplitContainer.TabIndex = 14
        '
        'FindFreeRoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 507)
        Me.Controls.Add(Me.verticalSplitContainer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FindFreeRoom"
        Me.Text = "Find Free Room"
        Me.searchTabControl.ResumeLayout(False)
        Me.timeDateTab.ResumeLayout(False)
        Me.timeDateTab.PerformLayout()
        Me.capabilitiesTab.ResumeLayout(False)
        Me.capabilitiesTab.PerformLayout()
        Me.verticalSplitContainer.Panel1.ResumeLayout(False)
        Me.verticalSplitContainer.Panel2.ResumeLayout(False)
        Me.verticalSplitContainer.Panel2.PerformLayout()
        CType(Me.verticalSplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.verticalSplitContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents findButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ResultBox As System.Windows.Forms.TextBox
    Friend WithEvents daysBox As System.Windows.Forms.ComboBox
    Friend WithEvents startTimeBox As System.Windows.Forms.ComboBox
    Friend WithEvents endTimeBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents searchTabControl As System.Windows.Forms.TabControl
    Friend WithEvents capabilitiesTab As System.Windows.Forms.TabPage
    Friend WithEvents capabilitiesTable As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents initialLabel As System.Windows.Forms.Label
    Friend WithEvents endInitialLabel As System.Windows.Forms.Label
    Friend WithEvents minSizeBox As System.Windows.Forms.TextBox
    Friend WithEvents capabilitiesLabel As System.Windows.Forms.Label
    Friend WithEvents timeDateTab As System.Windows.Forms.TabPage
    Friend WithEvents verticalSplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents matchAnyRB As System.Windows.Forms.RadioButton
    Friend WithEvents matchAllRB As System.Windows.Forms.RadioButton
End Class
