Module MathModule


    Public Function countBits(ByVal bitmask As Integer)
        Dim numBits As Integer = 0

        While (bitmask > 0)
            If (bitmask And 1) Then
                numBits = numBits + 1
            End If

            bitmask = bitmask >> 1
        End While

        Return numBits
    End Function

    Public Function newMin(ByVal currMin As Integer, ByVal newval As Integer)
        Dim v As Integer = currMin

        '
        '  Ignore if newval = -1
        '
        If (newval >= 0) Then

            '
            '  If currval = -1 OR if newval is better, then use it
            '
            If (currMin < 0) Then
                v = newval
            ElseIf (currMin > newval) Then
                v = newval
            End If
        End If

        Return v
    End Function



    Public Function newMax(ByVal currMax As Integer, ByVal newval As Integer)
        Dim v As Integer = currMax

        If (currMax < newval) Then
            v = newval
        End If

        Return v
    End Function

    '
    '  isInSet(#,list)
    '
    '   See if # is in the list
    '
    Public Function isInSet(ByVal num As Integer, ByVal l As List(Of Integer)) As Boolean
        Return l.Contains(num)
    End Function
End Module
