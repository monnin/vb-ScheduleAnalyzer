Module CapabilitiesHelper

    Function tablelayouttohash(ByRef capabilitiesTable As TableLayoutPanel) As HashSet(Of String)
        Dim hash As New HashSet(Of String)
        Dim cb As CheckBox

        '
        '  Load the HASHSET
        '
        For Each c As Control In capabilitiesTable.Controls
            cb = TryCast(c, CheckBox)

            If (cb IsNot Nothing) Then
                If (cb.Checked) Then
                    hash.Add(cb.Text)
                End If
            End If
        Next

        Return hash
    End Function

    Function load_capabilities_table(ByRef capabilitiesTable As TableLayoutPanel) As Integer
        Dim cb As CheckBox
        Dim row As Integer = 0
        Dim col As Integer = 0
        Dim capabilities As List(Of String)

        '
        '  Stop making updates while we create the table
        '
        capabilitiesTable.SuspendLayout()

        '
        '  Remove the horizontal scrollbar
        '
        '   http://stackoverflow.com/questions/2197452/how-to-disable-horizontal-scrollbar-for-table-panel-in-winforms
        '
        capabilitiesTable.Padding = New Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0)


        capabilitiesTable.Controls.Clear()
        capabilitiesTable.RowStyles.Clear()

        capabilities = SCHED_DATA.rooms.allcapabilities()

        For i As Integer = 0 To capabilities.Count - 1
            cb = New CheckBox
            cb.Text = capabilities(i)
            cb.AutoSize = True
            cb.AutoEllipsis = True

            ' cb.Dock = DockStyle.Top + DockStyle.Left

            capabilitiesTable.Controls.Add(cb, col, row)

            col = col + 1

            If (col > 2) Then
                col = 0
                row = row + 1
            End If
        Next

        For i As Integer = 0 To row
            ' capabilitiesTable.RowStyles.Add(New RowStyle(SizeType.Absolute, capabilitiesTable.Parent.Font.Height() + 10))

            capabilitiesTable.RowStyles.Add(New RowStyle(SizeType.Absolute, capabilitiesTable.Font.Height() + 10))
        Next

        capabilitiesTable.ResumeLayout()

        Return capabilities.Count
    End Function

End Module
