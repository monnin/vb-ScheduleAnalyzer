Module tableHelper


    '
    '  Based on http://dotnetref.blogspot.com/2007/06/copy-listview-to-clipboard.html
    '
    Public Sub copyListViewToClipboard(ByRef view As ListView, Optional maxCols As Integer = -1, Optional maxRows As Integer = -1)
        Dim s As String = ""
        Dim r As String = ""
        Dim dobj As New DataObject()

        getTextFromListView(view, s, r, maxCols, maxRows)

        dobj.SetData(DataFormats.Text, s)
        dobj.SetData(DataFormats.Rtf, r)

        Clipboard.Clear()
        Clipboard.SetDataObject(dobj)
    End Sub


    Public Sub copyDataGridViewToClipboard(ByRef view As DataGridView, Optional maxCols As Integer = -1, Optional maxRows As Integer = -1)
        Dim s As String = ""
        Dim r As String = ""
        Dim dobj As New DataObject()

        getTextFromDataGridView(view, s, r, maxCols, maxRows)

        dobj.SetData(DataFormats.Text, s)
        dobj.SetData(DataFormats.Rtf, r)

        Clipboard.Clear()
        Clipboard.SetDataObject(dobj)
    End Sub

    Public Sub getTextFromListView(ByRef view As ListView, ByRef outText As String, ByRef outRTF As String, _
                                   Optional maxCols As Integer = -1, _
                                   Optional maxRows As Integer = -1)
        Dim s As String = ""
        Dim i, j As Integer
        Dim colmax As Integer = view.Columns.Count - 1
        Dim rowmax As Integer = view.Items.Count - 1

        Dim rtfOut As New rtfTableBuilder


        '
        '   Force a limit if desired
        '
        If ((maxCols > 0) And (maxCols <= colmax)) Then
            colmax = maxCols - 1
        End If

        If ((maxRows > 0) And (maxRows <= rowmax)) Then
            rowmax = maxRows - 1
        End If


        '
        '   Handle the header
        '
        rtfOut.newRow()

        For i = 0 To colmax
            If (i > 0) Then
                s = s & vbTab
            End If

            s = s & view.Columns(i).Text
            rtfOut.newCol(view.Columns(i).Text, True)
        Next

        s = s & vbCrLf


        '
        '  Now handle the data
        '
        For i = 0 To rowmax

            rtfOut.newRow()

            For j = 0 To colmax
                If (j > 0) Then
                    s = s & vbTab
                End If

                s = s & view.Items(i).SubItems(j).Text

                rtfOut.newCol(view.Items(i).SubItems(j).Text)
            Next

            s = s & vbCrLf
        Next

        outText = s
        outRTF = rtfOut.output()
    End Sub




    Public Sub getTextFromDataGridView(ByRef view As DataGridView, ByRef outText As String, ByRef outRTF As String, _
                                   Optional maxCols As Integer = -1, _
                                   Optional maxRows As Integer = -1)
        Dim s As String = ""
        Dim i, j As Integer
        Dim colmax As Integer = view.Columns.Count - 1
        Dim rowmax As Integer = view.Rows.Count - 1

        Dim rtfOut As New rtfTableBuilder


        '
        '   Force a limit if desired
        '
        If ((maxCols > 0) And (maxCols <= colmax)) Then
            colmax = maxCols - 1
        End If

        If ((maxRows > 0) And (maxRows <= rowmax)) Then
            rowmax = maxRows - 1
        End If


        '
        '   Handle the header
        '
        rtfOut.newRow()

        For i = 0 To colmax
            If (i > 0) Then
                s = s & vbTab
            End If

            s = s & view.Columns(i).HeaderText
            rtfOut.newCol(view.Columns(i).HeaderText, True)
        Next

        s = s & vbCrLf


        '
        '  Now handle the data
        '
        For i = 0 To rowmax

            rtfOut.newRow()

            For j = 0 To colmax
                If (j > 0) Then
                    s = s & vbTab
                End If

                s = s & view.Item(j, i).Value.ToString
                's = s & view.Rows(i).SubItems(j).Text

                'rtfOut.newCol(view.Items(i).SubItems(j).Text)
                rtfOut.newCol(view.Item(j, i).Value.ToString)
            Next

            s = s & vbCrLf
        Next

        outText = s
        outRTF = rtfOut.output()
    End Sub

    Public Sub findAndCopyListView(ByRef sender As Object, Optional maxcols As Integer = -1, Optional maxrows As Integer = -1)
        Dim ts As ToolStripMenuItem = Nothing
        Dim cs As ContextMenuStrip = Nothing
        Dim ctrl As Control = Nothing
        Dim lv As ListView = Nothing

        ts = TryCast(sender, ToolStripMenuItem)

        If (ts IsNot Nothing) Then
            cs = TryCast(ts.Owner, ContextMenuStrip)
        End If

        If (cs IsNot Nothing) Then
            ctrl = cs.SourceControl
        End If

        If (ctrl IsNot Nothing) Then
            lv = TryCast(ctrl, ListView)
        End If

        copyListViewToClipboard(lv, maxcols, maxrows)
    End Sub


    '
    ' TODO: FINISH ME!!!
    '

    Public Sub printView(ByRef view As ListView, Optional ByVal dialog As Boolean = False, _
                         Optional ByVal header As String = "", Optional ByVal footer As String = "", _
                         Optional maxCols As Integer = -1, Optional maxRows As Integer = -1)
        Dim s As String = ""
        Dim r As String = ""
        Dim pdoc As New Printing.PrintDocument
        Dim pview As New PrintPreviewDialog
        Dim rtb As New RichTextBox

        getTextFromListView(view, s, r, maxCols, maxRows)
        rtb.Rtf = r

        rtb.Print(dialog, header, footer)
    End Sub

    Public Function longdatetime() As String
        Return Now.ToLongDateString() & " " & Now.ToShortDateString()
    End Function


End Module
