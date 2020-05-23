'
'   http://support.microsoft.com/kb/319401
'  Converted from C# 
'


Public Class ListViewColumnSorter
    Implements IComparer

    Delegate Function columnComparer(ByVal a As String, ByVal b As String) As Integer

    Private exceptions As New Dictionary(Of Integer, columnComparer)

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


    Public Sub addColumnCompare(ByVal columNum As Integer, ByRef func As columnComparer)
        '
        '  Remove if already there
        '
        If (exceptions.ContainsKey(columNum)) Then
            exceptions.Remove(columNum)
        End If

        exceptions.Add(columNum, func)
    End Sub


    Public Sub removeColumnCompare(ByVal columNum As Integer)
        '
        '  Remove if already there
        '
        If (exceptions.ContainsKey(columNum)) Then
            exceptions.Remove(columNum)
        End If
    End Sub

    ' !!  <summary>
    ' !!  This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
    ' !!  </summary>
    ' !!  <param name="x">First object to be compared</param>
    ' !!  <param name="y">Second object to be compared</param>
    ' !!  <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
    Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
        Dim compareResult As Integer
        Dim listviewX, listviewY As ListViewItem
        Dim func As columnComparer

        ' Cast the objects to be compared to ListViewItem objects
        listviewX = CType(x, ListViewItem)
        listviewY = CType(y, ListViewItem)

        '
        '  Special column sorter?
        '
        If (exceptions.ContainsKey(ColumnToSort)) Then
            func = exceptions(ColumnToSort)

            compareResult = func(listviewX.SubItems(ColumnToSort).Text, _
                                                  listviewY.SubItems(ColumnToSort).Text)
        Else
            ' Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, _
                                                  listviewY.SubItems(ColumnToSort).Text)

        End If

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
