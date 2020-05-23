'
'  RTF docs begin with {\rtf1\ansi\deff0 ... and end with ... }
'
'   Rows in RTF begin with \trowd ... and end with ... \row
'
'   Each column in RTF must have all "headers" first  \cellx####  
'       ...and then each data begins with \intbl ... and ends with ... \cell
'
'   First "newrow" before each row, and then use "newcol" for each desired column in the row
'
'
'   Usage: [f.clear(),] f.newrow(), f.newcol("data") [, f.newcol("data")...,] [f.newrow()... ,] f.output()
'

Public Class rtfTableBuilder
    Private rowPadding As Integer = 100
    Private rtfText As String = ""
    Private tempRowHeader As String = ""
    Private tempRowData As String = ""

    Public Sub clear()
        rtfText = "{\rtf1\ansi\deff0" & vbCrLf
        tempRowHeader = ""
        tempRowData = ""
    End Sub

    Public Sub New()
        clear()
    End Sub

    Private Sub emitRow()
        If (tempRowHeader <> "") Then
            rtfText &= tempRowHeader & tempRowData & "\row" & vbCrLf

            tempRowHeader = ""
            tempRowData = ""
        End If
    End Sub


    Public Sub newRow()
        emitRow()
        tempRowHeader = "\trowd\trautofit1\trgaph" & rowPadding.ToString & vbCrLf
    End Sub

    Public Sub newCol(s As String, Optional bold As Boolean = False)
        If (tempRowHeader = "") Then
            newRow()
        End If

        tempRowHeader &= "\clftsWidth1\cellx1" & vbCrLf

        If (bold) Then
            tempRowData &= "\intbl \b " & s & " \b0 \cell" & vbCrLf
        Else
            tempRowData &= "\intbl " & s & " \cell" & vbCrLf
        End If

    End Sub

    Public Function output() As String
        Dim s As String

        emitRow()
        s = rtfText

        If (s <> "") Then
            s &= "}" & vbCrLf
        End If

        Return s
    End Function

End Class
