Public Class ResizablePanel

    '
    '  Based on http://social.msdn.microsoft.com/Forums/en-US/a184f136-0e54-4b56-86be-9a1c57212344/resizing-panel-control
    '

    Inherits Panel
    Private Const cGripSize As Integer = 20
    Private mDragging As Boolean
    Private mDragPos As Point

    Public Sub New()

        Me.BackColor = Color.White
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.ResizeRedraw, True)

    End Sub


    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        ControlPaint.DrawSizeGrip(e.Graphics, Me.BackColor,
                                  New Rectangle(Me.ClientSize.Width - cGripSize,
                                                Me.ClientSize.Height - cGripSize,
                                                cGripSize, cGripSize))

        MyBase.OnPaint(e)
    End Sub

    Private Function IsOnGrip(pos As Point) As Boolean
        Return ((pos.X >= (Me.ClientSize.Width - cGripSize)) And
               (pos.Y >= (Me.ClientSize.Height - cGripSize)))

    End Function

    Protected Overrides Sub OnMouseDown(e As System.Windows.Forms.MouseEventArgs)
        mDragging = IsOnGrip(e.Location)
        mDragPos = e.Location

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As System.Windows.Forms.MouseEventArgs)
        mDragging = False

        MyBase.OnMouseUp(e)
    End Sub


    Protected Overrides Sub OnMouseMove(e As System.Windows.Forms.MouseEventArgs)
        If (mDragging) Then
            Me.Size = New Size(Me.Width + e.X - mDragPos.X,
                               Me.Height + e.Y - mDragPos.Y)

            mDragPos = e.Location
        ElseIf (IsOnGrip(e.Location)) Then
            Me.Cursor = Cursors.SizeNWSE
        Else
            Me.Cursor = Cursors.Default
        End If

        MyBase.OnMouseMove(e)
    End Sub

End Class
