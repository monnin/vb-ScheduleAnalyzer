Option Strict On

'
' NOTE: See http://www.velocityreviews.com/forums/showpost.php?s=f87f0674feda4442dcbd40019cbca65b&p=528575&postcount=2 &
'           http://stackoverflow.com/questions/158706/how-to-properly-clean-up-excel-interop-objects 
'        ...about avoiding extra Excel instances
'

Module excelModule


    Dim excel As Microsoft.Office.Interop.Excel.Application = Nothing
    Dim workbooks As Microsoft.Office.Interop.Excel.Workbooks = Nothing
    Dim wb As Microsoft.Office.Interop.Excel.Workbook = Nothing
    Dim sheets As Microsoft.Office.Interop.Excel.Sheets = Nothing
    Dim ws As Microsoft.Office.Interop.Excel.Worksheet = Nothing
    Dim quitApp As Boolean = False
    Dim shouldCloseWorkbook As Boolean = True

    '
    '----------------------------------------------------------------------
    '    All of these "Private Declares" et. al. are used by ShowExcel
    '----------------------------------------------------------------------
    '

    Private Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As IntPtr) As IntPtr
    'Private Declare Function SetFocus Lib "user32.dll" (ByVal hwnd As Int32) As Int32
    'Private Declare Function ShowWindowAsync Lib "user32.dll" (ByVal hwnd As Long, ByVal nCmdShow As Int32) As Int32
    Private Declare Function ShowWindow Lib "user32.dll" (ByVal hwnd As IntPtr, ByVal nCmdShow As Int32) As Boolean

    Private Const SW_SHOW As Integer = 5
    'Private Const SW_SHOWDEFAULT As Integer = 10

    Private Declare Function GetWindowThreadProcessId Lib "user32" (ByVal hwnd As IntPtr, _
                          ByRef lpdwProcessId As IntPtr) As IntPtr

    Private Declare Function BringWindowToTop Lib "user32.dll" (ByVal hwnd As IntPtr) As Boolean
    Private Declare Function GetForegroundWindow Lib "user32.dll" () As IntPtr
    Public Declare Function AttachThreadInput Lib "user32.dll" (ByVal idAttach As IntPtr, ByVal idAttachTo As IntPtr, ByVal fAttach As Boolean) As Boolean


    '
    '----------------------------------------------------------------------
    '

    Public Function activeWorksheetName() As String
        Dim s As String = ""

        If (ws IsNot Nothing) Then
            s = ws.Name
        End If

        Return s
    End Function

    Private Function rowIntToStr(ByVal x As Integer) As String
        Dim x2 As Integer
        Dim row As String = ""

        Const chrOffset As Integer = Asc("A"c)  ' Used to convert columns into numbers

        x = x - 1       ' Convert from a first column = 1 to a first column = 0
        '
        '  Larger than row "Z", then "AA", "AB", ..., "AAA", "AAB", etc...
        '
        While (x > 0)
            '
            '   Seperate into last digit (x, and all the upper digits x2)
            '
            x2 = x \ 26
            x = x Mod 26

            '
            '    Convert the part we know and then loop
            '
            row = Chr(chrOffset + x) & row

            '
            '  Ready for tackling the rest
            '
            x = x2
        End While

        If (row = "") Then
            row = "A"
        End If

        Return row
    End Function

    '
    '   FindRunningExcel
    '
    '   Get an instance of an already running Excel program
    '   (otherwise return Nothing)
    '
    Private Function FindRunningExcel() As Microsoft.Office.Interop.Excel.Application
        Dim excel As Microsoft.Office.Interop.Excel.Application = Nothing

        '
        '  TODO:  Not sure why I needed a Try around a TryCast block - but it crashed
        '         without it.  :-(
        '
        Try
            excel = TryCast(System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application"),  _
                               Microsoft.Office.Interop.Excel.Application)
        Catch ex As Exception
            excel = Nothing
        End Try

        If (excel IsNot Nothing) Then
            workbooks = excel.Workbooks
        End If

        Return excel
    End Function

    '
    '
    '
    '   Note:  Has a side-effect of attaching "excel" var to a process if the process
    '          is found
    '

    Private Function FindOpenWorkbook(ByVal fullpath As String) As Microsoft.Office.Interop.Excel.Workbook
        Dim result As Boolean = False
        Dim wb As Microsoft.Office.Interop.Excel.Workbook
        Dim foundwb As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim full2 As String

        '
        '   Find a running instance of Excel, if it doesn't exist, then
        '   the file can't be open (by definition)
        '
        If (excel Is Nothing) Then
            excel = FindRunningExcel()
        End If


        If (excel IsNot Nothing) Then
            fullpath = fullpath.ToLower

            If (workbooks Is Nothing) Then
                workbooks = excel.Workbooks
            End If

            '
            '  Iterate over the list of items
            '
            For Each wb In workbooks
                full2 = wb.Path.ToLower & "\" & wb.Name.ToLower

                '
                '   Compare then (they have already been made into lowercase)
                '
                If (fullpath = full2) Then
                    foundwb = wb
                Else
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
                End If

            Next

        End If

        Return foundwb
    End Function


    '
    '   Simple front-end into FindOpenWorkbook
    '   (provides True/False result)
    '
    Public Function isWorkbookOpen(ByVal fullpath As String) As Boolean
        Return (FindOpenWorkbook(fullpath) IsNot Nothing)
    End Function


    '
    '   findWorksheetNamed
    '
    '   Given a worksheet (tab) name, convert it into an unsigned integer
    '   (aka the index # into the array)
    '

    Public Function findWorksheetNamed(ByVal s As String) As Integer
        Dim result As Integer = -1   ' Assume an error has occurred
        Dim i As Integer
        Dim tempws As Microsoft.Office.Interop.Excel.Worksheet

        If ((sheets Is Nothing) And (wb IsNot Nothing)) Then
            sheets = wb.Sheets
        End If

        If (sheets IsNot Nothing) Then
            For i = 1 To sheets.Count
                tempws = TryCast(sheets(i), Microsoft.Office.Interop.Excel.Worksheet)

                If (tempws.Name = s) Then
                    result = i
                End If

                System.Runtime.InteropServices.Marshal.ReleaseComObject(tempws)
            Next
        End If

        Return result
    End Function

    '
    '   openworksheet(num)
    '
    '   Given a number, open the worksheet (aka a tab in a workbook) by its placement
    '

    Public Function openworksheet(ByVal sheetnum As Integer) As Boolean
        Dim result As Boolean = False

        If ((sheets Is Nothing) And (wb IsNot Nothing)) Then
            sheets = wb.Sheets
        End If

        If (sheets IsNot Nothing) Then

            Try
                ws = TryCast(sheets(sheetnum), Microsoft.Office.Interop.Excel.Worksheet)
            Catch ex As Exception
                ws = Nothing
            End Try

            result = (ws IsNot Nothing)
        End If

        Return result
    End Function


    '
    '   openworksheet(name,num)
    '
    '   Try to open the worksheet by name, if that fails, try by number
    '
    Public Function openworksheet(ByVal name As String, ByVal num As Integer) As Boolean
        Dim id As Integer = -1
        Dim result As Boolean = False

        '
        '  Given a valid name for a worksheet, try it first
        '
        If (name <> "") Then
            id = findWorksheetNamed(name)
        End If

        '
        '  No worksheet by name, try the number
        '   (but ignore the sheetnames that are already "reserved")
        '
        If ((id = -1) AndAlso (Not ExcelSettings.isSheetName(worksheetName(num)))) Then
            id = num
        End If

        If (id > -1) Then
            result = openworksheet(id)
        End If

        Return result
    End Function
    '
    '       openExcel
    '
    '       Try to open an excel file (as wb), and point ws to the first 
    '           worksheet in the workbook
    '
    Public Function openExcel(ByRef filename As String, _
                              Optional useopenfile As Boolean = False) As Boolean

        '
        '   Make sure that the system was closed if necessary
        '
        '   (but keep Excel running if possible - since we are going to turn around
        '    and just reopen Excel)
        '
        CloseExcel(False)

        shouldCloseWorkbook = True        ' Assume we will need to close the workbook

        If (useopenfile) Then
            '
            '  See if there is a running version already
            '
            excel = FindRunningExcel()
        End If


        '
        '  No running version, then start one
        '
        If (excel Is Nothing) Then
            excel = New Microsoft.Office.Interop.Excel.Application()
            quitApp = True
        Else
            '
            '   Found a running version, so make sure not to kill it when we are done
            '
            quitApp = False
        End If

        '
        '  Find the COM object for the workbooks
        '
        workbooks = excel.Workbooks


        '
        '  Try to use the existing file if "useopenfile" mode is enabled
        '
        If (useopenfile) Then
            wb = FindOpenWorkbook(filename)

            shouldCloseWorkbook = (wb IsNot Nothing)  ' Don't close it if we didn't open it
        End If

        '
        '  If useopenfile is not specified (or the file is not open) then
        '  go ahead and open it
        '
        If (wb Is Nothing) Then
            wb = workbooks.Open(filename, , True) ' Open it readonly
        End If


        '
        ' TODO: Better error check the open
        '

        openworksheet(1)


        '
        '  Return if successful
        '
        Return (ws IsNot Nothing)
    End Function

    '
    '   worksheetCount()
    '
    '   Returns the number of worksheets in an open workbook
    '
    '   (Returns -1 if the workbook is not open)
    '
    Public Function worksheetCount() As Integer
        Dim result As Integer = -1

        If (sheets IsNot Nothing) Then
            result = sheets.Count()
        End If

        Return result
    End Function


    Public Function worksheetName(ByVal num As Integer) As String
        Dim s As String = ""
        Dim tempws As Microsoft.Office.Interop.Excel.Worksheet

        If (sheets IsNot Nothing) Then
            If ((num >= 0) And (num < sheets.Count)) Then
                tempws = TryCast(sheets(num), Microsoft.Office.Interop.Excel.Worksheet)

                If (tempws IsNot Nothing) Then
                    s = tempws.Name

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(tempws)
                End If

            End If
        End If

        Return s
    End Function

    '
    '   getCellStr(x,y)
    '
    '   Given a cell location (provided as two integers), 
    '       get the value of the cell

    '   
    '   TODO:  Speed this up by grabbing the entire spreadsheet in a single operation
    '           and then piecemealing it out
    '
    '       http://msdn.microsoft.com/en-us/library/office/ff838238.aspx
    '
    Public Function getCellStr(x As Integer, y As Integer) As String
        Dim row As String = rowIntToStr(x)
        Dim result As String = ""
        Dim range As Microsoft.Office.Interop.Excel.Range

        If (ws IsNot Nothing) Then
            range = ws.Range(row & y.ToString)

            '
            '  Did I get something back?
            '
            If (range IsNot Nothing) Then
                result = TryCast(range.Text, String)

                '
                '  Release the range
                '
                System.Runtime.InteropServices.Marshal.ReleaseComObject(range)
            End If

        End If

        Return result
    End Function


    '
    '   Get an integer value from a cell
    '
    '   RETURNS ZERO IF THE CELL DOES NOT CONTAIN A NUMBER
    '
    Public Function getCellInt(x As Integer, y As Integer) As Integer
        Dim result As Integer = 0
        Dim s As String

        s = getCellStr(x, y)

        '
        '  If it is a decimal - just truncate it
        '
        If (s.Contains("."c)) Then
            s = s.Substring(0, s.IndexOf("."))
        End If

        If (Integer.TryParse(s, result) = False) Then
            result = 0
        End If

        Return result
    End Function

    '
    '   getLastUsedRowAndColumn
    '
    '   Find the last cell that has data
    '
    Public Sub getLastUsedRowAndColumn(ByRef x As Integer, ByRef y As Integer)
        ' http://stackoverflow.com/questions/7674573/programmatically-getting-the-last-filled-excel-row-using-c-sharp

        If (ws IsNot Nothing) Then

            'x = ws.Range("A1").SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Column
            ' y = ws.Range("A1").SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row

            y = ws.UsedRange.Row + ws.UsedRange.Rows.Count - 1
            x = ws.UsedRange.Column + ws.UsedRange.Columns.Count - 1
        Else
            x = -1
            y = -1
        End If
    End Sub
    '
    '       isStrikethrough(x,y)
    '
    '       Given a cell location (provided as two integers), return True
    '           if the cell's font is a strikethrough format
    '
    '
    Public Function isStrikethrough(x As Integer, y As Integer) As Boolean
        Dim row As String = rowIntToStr(x)

        Return CBool(ws.Range(row & y.ToString).Font.Strikethrough)
    End Function

    Public Sub closeWorkbook()

        '
        '   Close the workbook (if one was ever opened)
        '

        If (wb IsNot Nothing) Then
            If (sheets IsNot Nothing) Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(sheets)
                sheets = Nothing
            End If

            '
            '   Close it only if we opened it
            '
            If (shouldCloseWorkbook) Then


                wb.Close()

            End If

            System.Runtime.InteropServices.Marshal.ReleaseComObject(wb)
            wb = Nothing
        End If
    End Sub

    Public Sub closeWorksheet()
        '
        ' Close the Worksheet COM object
        '
        If (ws IsNot Nothing) Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(ws)

            ws = Nothing        ' I don't think you can close a worksheet seperately
        End If
    End Sub

    '
    '   closeExcel()
    '
    '   Close and release all resources related to an open excel spreadsheet
    '
    Public Sub CloseExcel(Optional ByVal closeApp As Boolean = True)
        closeWorksheet()
        closeWorkbook()

        '
        '   Close the workbooks COM object
        '
        If (workbooks IsNot Nothing) Then
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbooks)
            workbooks = Nothing
        End If

        '
        '   Quit the app (unless it never started or the user doesn't want it closed) 
        '
        If ((excel IsNot Nothing) And (closeApp) And (quitApp)) Then
            excel.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel)
        End If

        excel = Nothing
    End Sub


    '
    '   ShowExcel
    '
    '   Goes to a cell location based on a worksheet name and a cell location
    '   (which can include a sheet name)
    '
    '  Roughly based on http://svn.assembla.com/svn/hallym_project/emotion/WindowsHelper.cs
    '   and http://www.pinvoke.net/default.aspx/user32/SetForegroundWindow.html
    '
    Public Sub ShowExcel()
        Dim excel As Microsoft.Office.Interop.Excel.Application = FindRunningExcel()
        Dim hwndAsPtr As IntPtr = New IntPtr(excel.Hwnd)
        Dim excelThread As IntPtr = GetWindowThreadProcessId(hwndAsPtr, IntPtr.Zero)
        Dim myThread As IntPtr = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero)

        ' Temp attach their thread to us
        AttachThreadInput(myThread, excelThread, True)

        BringWindowToTop(hwndAsPtr)
        ShowWindow(hwndAsPtr, SW_SHOW)
        'SetForegroundWindow(excel.Hwnd)
        'SetFocus(excel.Hwnd)

        ' Dirty work done, un-attach their thread
        AttachThreadInput(myThread, excelThread, False)
    End Sub


    Public Function GoToSheetAndCell(ByVal filename As String, ByVal loc As String) As Boolean
        Dim wsName As String
        Dim cellName As String
        Dim excel As Microsoft.Office.Interop.Excel.Application = FindRunningExcel()
        Dim wb As Microsoft.Office.Interop.Excel.Workbook = Nothing
        Dim ws As Microsoft.Office.Interop.Excel.Worksheet = Nothing
        Dim result As Boolean = False   ' Assume it didn't work

        '
        '  No running excel?  Then don't do anything
        '
        If (excel IsNot Nothing) Then
            '
            '  Excel only stores the "name" of workbooks as their filename without
            '   the path - so remove any path from the filename
            '
            If (filename.Contains("\")) Then
                filename = filename.Substring(filename.LastIndexOf("\") + 1)
            End If


            If (loc.Contains("!")) Then
                wsName = loc.Substring(0, loc.IndexOf("!"))
                cellName = loc.Substring(loc.IndexOf("!") + 1)
            Else
                wsName = activeWorksheetName()
                cellName = loc
            End If

            Try
                wb = CType(workbooks(filename), Microsoft.Office.Interop.Excel.Workbook)
            Catch ex As Exception
                wb = Nothing
            End Try

            If (wb IsNot Nothing) Then
                '
                '  TODO:  Should we open it?
                '
            End If

            '
            '  A valid workbook?  Then find the correct worksheet
            '
            If (sheets IsNot Nothing) Then
                ws = CType(sheets(wsName), Microsoft.Office.Interop.Excel.Worksheet)

                If (ws IsNot Nothing) Then

                    excel.Goto(ws.Range(cellName))
                    ShowExcel()

                End If ' Worksheet

            End If  ' Workbook


        End If  ' Excel 

        Return result

    End Function
End Module
