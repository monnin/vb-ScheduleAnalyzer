'
'   http://wiki.lessthandot.com/index.php/VB.Net:_Extension_method_Print_RichTextBox
'
'   http://blogs.lessthandot.com/index.php/DesktopDev/MSTech/vb-net-printing-the-content-of-a-richtex/
'
'  http://msdn.microsoft.com/en-us/library/ms996492.aspx
'

Imports System
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing

'Namespace Controls.RichTextBox.Extensions
' An extension to RichTextBox suitable for printing
''' <summary>
'''
''' </summary>
''' <remarks></remarks>
Public Module PrintRichTextBox

#Region " private methods "
    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Private _RichTextBox As System.Windows.Forms.RichTextBox
    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Private _Footer As String
    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Private _Header As String
    ''' <summary>
    ''' variable to trace text to print for pagination
    ''' </summary>
    ''' <remarks></remarks>
    Private _FirstCharOnPage As Integer
    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Private Const WM_USER As Int32 = &H400&
    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    Private Const EM_FORMATRANGE As Int32 = WM_USER + 57
#End Region

#Region " Extension Method "
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="RichTextBox"></param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub Print(ByVal RichTextBox As System.Windows.Forms.RichTextBox)
        Print(RichTextBox, False, "", "")
    End Sub

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="RichTextBox"></param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub Print(ByVal RichTextBox As System.Windows.Forms.RichTextBox, ByVal Dialog As Boolean, ByVal Header As String, ByVal Footer As String)
        _RichTextBox = RichTextBox
        _Header = Header
        _Footer = Footer
        Dim printDoc As New PrintDocument()
        AddHandler printDoc.BeginPrint, AddressOf BeginPrint
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        AddHandler printDoc.EndPrint, AddressOf EndPrint
        ' Start printing process
        If Dialog Then
            Dim _PrintDialog As New System.Windows.Forms.PrintDialog

            _PrintDialog.AllowPrintToFile = True
            _PrintDialog.AllowSomePages = True
            _PrintDialog.ShowHelp = True
            _PrintDialog.ShowNetwork = True

            If _PrintDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
                printDoc.PrinterSettings = _PrintDialog.PrinterSettings
                printDoc.Print()
            End If
        Else
            printDoc.Print()
        End If
    End Sub

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="RichTextBox"></param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub PrintPreview(ByVal RichTextBox As System.Windows.Forms.RichTextBox)
        PrintPreview(RichTextBox, "", "")
    End Sub

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="RichTextBox"></param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub PrintPreview(ByVal RichTextBox As System.Windows.Forms.RichTextBox, ByVal Header As String, ByVal Footer As String)
        _RichTextBox = RichTextBox
        _Header = Header
        _Footer = Footer
        Dim printDoc As New PrintDocument()
        AddHandler printDoc.BeginPrint, AddressOf BeginPrint
        AddHandler printDoc.PrintPage, AddressOf PrintPage
        AddHandler printDoc.EndPrint, AddressOf EndPrint
        ' Start printing process
        Dim _PrintPreviewDialog As New System.Windows.Forms.PrintPreviewDialog
        _PrintPreviewDialog.Document = printDoc
        _PrintPreviewDialog.ShowDialog()
    End Sub
#End Region

#Region " Structures "
    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure Rect
        Public left As Int32
        Public top As Int32
        Public right As Int32
        Public bottom As Int32
    End Structure

    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure CharRange
        Public cpMin As Int32
        Public cpMax As Int32
    End Structure

    ''' <summary>
    '''
    ''' </summary>
    ''' <remarks></remarks>
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure FormatRangeStructure
        Public hdc As IntPtr
        Public hdcTarget As IntPtr
        Public rc As Rect
        Public rcPage As Rect
        Public chrg As CharRange
    End Structure
#End Region

#Region " Private Methods "
    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="hWnd"></param>
    ''' <param name="msg"></param>
    ''' <param name="wParam"></param>
    ''' <param name="lParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("user32.dll")> _
    Private Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Int32, ByVal wParam As Int32, ByVal lParam As IntPtr) As Int32
    End Function

    ''' <summary>
    ''' Calculate or render the contents of our RichTextBox for printing
    ''' </summary>
    ''' <param name="measureOnly">If true, only the calculation is performed,
    ''' otherwise the text is rendered as well</param>
    ''' <param name="e">The PrintPageEventArgs object from the PrintPage event</param>
    ''' <param name="charFrom">Index of first character to be printed</param>
    ''' <param name="charTo">Index of last character to be printed</param>
    ''' <returns>(Index of last character that fitted on the page) + 1</returns>
    ''' <remarks></remarks>
    Private Function FormatRange(ByVal measureOnly As Boolean, ByVal e As PrintPageEventArgs, ByVal charFrom As Integer, ByVal charTo As Integer) As Integer
        ' Specify which characters to print
        Dim cr As CharRange
        cr.cpMin = charFrom
        cr.cpMax = charTo

        ' Specify the area inside page margins
        Dim rc As Rect
        rc.top = HundredthInchToTwips(e.MarginBounds.Top)
        rc.bottom = HundredthInchToTwips(e.MarginBounds.Bottom)
        rc.left = HundredthInchToTwips(e.MarginBounds.Left)
        rc.right = HundredthInchToTwips(e.MarginBounds.Right)

        ' Specify the page area
        Dim rcPage As Rect
        rcPage.top = HundredthInchToTwips(e.PageBounds.Top)
        rcPage.bottom = HundredthInchToTwips(e.PageBounds.Bottom)
        rcPage.left = HundredthInchToTwips(e.PageBounds.Left)
        rcPage.right = HundredthInchToTwips(e.PageBounds.Right)

        ' Get device context of output device
        Dim hdc As IntPtr
        hdc = e.Graphics.GetHdc()

        ' Fill in the FORMATRANGE structure
        Dim fr As FormatRangeStructure
        fr.chrg = cr
        fr.hdc = hdc
        fr.hdcTarget = hdc
        fr.rc = rc
        fr.rcPage = rcPage

        ' Non-Zero wParam means render, Zero means measure
        Dim wParam As Int32
        If measureOnly Then
            wParam = 0
        Else
            wParam = 1
        End If

        ' Allocate memory for the FORMATRANGE struct and
        ' copy the contents of our struct to this memory
        Dim lParam As IntPtr
        lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr))
        Marshal.StructureToPtr(fr, lParam, False)

        ' Send the actual Win32 message
        Dim res As Integer
        res = SendMessage(_RichTextBox.Handle, EM_FORMATRANGE, wParam, lParam)

        ' Free allocated memory
        Marshal.FreeCoTaskMem(lParam)

        ' and release the device context
        e.Graphics.ReleaseHdc(hdc)

        Return res
    End Function

    ''' <summary>
    ''' Convert between 1/100 inch (unit used by the .NET framework) and twips (1/1440 inch, used by Win32 API calls)
    ''' </summary>
    ''' <param name="n">Parameter "n": Value in 1/100 inch</param>
    ''' <returns>Return value: Value in twips</returns>
    ''' <remarks>Convert between 1/100 inch (unit used by the .NET framework)
    ''' and twips (1/1440 inch, used by Win32 API calls)
    ''' </remarks>
    Private Function HundredthInchToTwips(ByVal n As Integer) As Int32
        Return Convert.ToInt32(n * 14.4)
    End Function

    ''' <summary>
    ''' Free cached data from rich edit control after printing
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FormatRangeDone()
        Dim lParam As New IntPtr(0)
        SendMessage(_RichTextBox.Handle, EM_FORMATRANGE, 0, lParam)
    End Sub

    ''' <summary>
    ''' Start at the beginning of the text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        _FirstCharOnPage = 0
    End Sub

    ''' <summary>
    '''
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        ' To print the boundaries of the current page margins
        ' uncomment the next line:
        ' e.Graphics.DrawRectangle(System.Drawing.Pens.Blue, e.MarginBounds)

        ' make the RichTextBoxEx calculate and render as much text as will
        ' fit on the page and remember the last character printed for the
        ' beginning of the next page
        e.Graphics.DrawString(_Header, New System.Drawing.Font("Arial", 10), Drawing.Brushes.Black, 50, 30)
        e.Graphics.DrawString(_Footer, New System.Drawing.Font("Arial", 10), Drawing.Brushes.Black, 50, e.PageBounds.Bottom - 50)
        _FirstCharOnPage = FormatRange(False, e, _FirstCharOnPage, _RichTextBox.TextLength)

        ' check if there are more pages to print
        If (_FirstCharOnPage < _RichTextBox.TextLength) Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    ''' <summary>
    ''' Clean up cached information
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EndPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        FormatRangeDone()
    End Sub
#End Region

End Module
' End Namespace