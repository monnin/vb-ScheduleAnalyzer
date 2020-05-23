Public Class ReportViewColumnSorter
    '
    '   http://support.microsoft.com/kb/319401
    '  Converted from C# 
    '

    Implements IComparer(Of ListViewItem), IComparer


    ' !!  <summary>
    ' !!  Specifies the column to be sorted
    ' !!  </summary>
    Private ColumnToSort As Integer

    ' !!  <summary>
    ' !!  Specifies the order in which to sort (i.e. 'Ascending').
    ' !!  </summary>
    Private OrderOfSort As SortOrder

    ' !!  <summary>
    ' !!  Case insensitive comparer object
    ' !!  </summary>
    Private ObjectCompare As CaseInsensitiveComparer


    ' !!  <summary>
    ' !!  Class constructor.  Initializes various elements
    ' !!  </summary>
    Public Sub New()


        ' Initialize the column to '0'
        ColumnToSort = 0

        ' Initialize the sort order to 'none'
        OrderOfSort = SortOrder.None

        ' Initialize the CaseInsensitiveComparer object
        ObjectCompare = New CaseInsensitiveComparer()
    End Sub


    Private Function timeCompare(ByVal x As String, ByVal y As String) As Integer
        Dim xInt As Integer = timeToInt(x)
        Dim yInt As Integer = timeToInt(y)
        Dim result As Integer = 0

        If (xInt < yInt) Then
            result = -1
        End If

        If (xInt > yInt) Then
            result = 1
        End If

        Return result
    End Function


    ' !!  <summary>
    ' !!  This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
    ' !!  </summary>
    ' !!  <param name="x">First object to be compared</param>
    ' !!  <param name="y">Second object to be compared</param>
    ' !!  <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
    Public Function Compare(listviewX As ListViewItem, listviewY As ListViewItem) As Integer Implements IComparer(Of ListViewItem).Compare
        Dim compareResult As Integer

        Select Case ColumnToSort
            Case 2 To 4
                compareResult = timeCompare(listviewX.SubItems(ColumnToSort).Text, _
                                                      listviewY.SubItems(ColumnToSort).Text)

            Case Else
                ' Compare the two items
                compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, _
                                                      listviewY.SubItems(ColumnToSort).Text)

        End Select

        ' Calculate correct return value based on object comparison
        If (OrderOfSort = SortOrder.Ascending) Then
            ' Ascending sort is selected, return normal result of compare operation

            ' Do nothing

        ElseIf (OrderOfSort = SortOrder.Descending) Then
            ' Descending sort is selected, return negative result of compare operation
            compareResult = -compareResult
        Else
            ' Return '0' to indicate they are equal
            compareResult = 0
        End If

        Return compareResult
    End Function


    '
    '  TODO:  This is ugly, and needs a real fix 
    '  (but solves a non-debugging error of casting error to system.collections.icomparer
    '
    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim x1, y1 As ListViewItem
        Dim result = 0

        x1 = TryCast(x, ListViewItem)
        y1 = TryCast(y, ListViewItem)

        If ((x1 IsNot Nothing) And (y1 IsNot Nothing)) Then
            result = Compare(x1, y1)
        End If

        Return result
    End Function


    ' !!  <summary>
    ' !!  Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
    ' !!  </summary>
    Public Property SortColumn As Integer
        Get

            Return ColumnToSort
        End Get


        Set(value As Integer)

            ColumnToSort = value
        End Set

    End Property



    ' !!  <summary>
    ' !!  Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
    ' !!  </summary>
    Public Property Order As SortOrder

        Set(value As SortOrder)
            OrderOfSort = value
        End Set

        Get
            Return OrderOfSort
        End Get

    End Property





End Class


