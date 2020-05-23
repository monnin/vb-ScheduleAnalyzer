Public Class oneSequence
    Implements IComparable(Of oneSequence)

    Public name As String
    Public semesters As String      ' Encoded with a / between semester
    ' and a ? at the end if it is optional
    Public critera As ScheduleCriteria = Nothing
    Public courses As List(Of String)      ' List of courses (with | used as a choice)
    Public loc As String

    Public Function CompareTo(other As oneSequence) As Integer Implements System.IComparable(Of oneSequence).CompareTo
        Return String.Compare(name, other.name)
    End Function

End Class
