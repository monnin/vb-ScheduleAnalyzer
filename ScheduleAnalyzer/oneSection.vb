Public Class oneSection
    Public coursenum As String

    Public days As Integer  ' Bitwise representation of the days of the week
    Public starttime As Integer
    Public endtime As Integer
    Public contactHours As Integer = -1
    Public instructor As String
    Public room As String
    Public loc As String
    Public sectionIsFull As Boolean = False
    Public isGhostedSection As Boolean = False   ' Ghosts are checked for conflicts with other sections
    Public notes As String
    '  but are not counted to satisfy a sequence (in case they are not ran)

End Class
