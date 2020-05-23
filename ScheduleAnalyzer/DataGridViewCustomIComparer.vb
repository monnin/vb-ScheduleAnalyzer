Public Class DataGridViewCustomIComparer
    Implements System.Collections.IComparer

    Private sortOrderModifier As Integer = 1

    Public Sub New(ByVal sortOrder As SortOrder)
        If sortOrder = sortOrder.Descending Then
            sortOrderModifier = -1
        ElseIf sortOrder = sortOrder.Ascending Then

            sortOrderModifier = 1
        End If
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
        Implements System.Collections.IComparer.Compare

        Dim DataGridViewRow1 As DataGridViewRow = CType(x, DataGridViewRow)
        Dim DataGridViewRow2 As DataGridViewRow = CType(y, DataGridViewRow)

        ' Try to sort based on the First column. 
        Dim CompareResult As Integer = System.String.Compare( _
            DataGridViewRow1.Cells(0).Value.ToString(), _
            DataGridViewRow2.Cells(0).Value.ToString())

        ' If the First column are equal, sort based on the second. 
        If CompareResult = 0 Then
            CompareResult = System.String.Compare( _
                DataGridViewRow1.Cells(1).Value.ToString(), _
                DataGridViewRow2.Cells(1).Value.ToString())
        End If

        ' If the first and second columns are equal, sort based on the third
        '   (in reverse order)
        If CompareResult = 0 Then
            CompareResult = System.String.Compare( _
                DataGridViewRow2.Cells(2).Value.ToString(), _
                DataGridViewRow1.Cells(2).Value.ToString())
        End If

        Return CompareResult * sortOrderModifier
    End Function

End Class
