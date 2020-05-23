Module TimeAndDateStuff

    Public Function daysToNumDays(ByVal days As Integer) As Integer
        Dim count As Integer = 0

        While (days > 0)
            If ((days And 1) = 1) Then
                count = count + 1
            End If

            days = days >> 1
        End While

        Return count
    End Function

    Public Function timeToInt(timeStr As String) As Integer
        Dim result As Integer = -1
        Dim hhStr As String
        Dim mmStr As String
        Dim hh As Integer
        Dim mm As Integer

        timeStr = timeStr.ToLower.Trim

        If (timeStr.Contains(":")) Then
            hhStr = timeStr.Substring(0, timeStr.IndexOf(":"))

            mmStr = timeStr.Substring(timeStr.IndexOf(":") + 1)

            '
            '   Remove the seconds if necessary
            '
            If (mmStr.Contains(":")) Then
                mmStr = mmStr.Substring(0, mmStr.IndexOf(":"))
            End If

            '
            '   Remove any words after the minutes
            '
            If (mmStr.Contains(" ")) Then
                mmStr = mmStr.Substring(0, mmStr.IndexOf(" "))
            End If

            '
            '  Now make sure both are integers before converting them
            '
            If (Integer.TryParse(hhStr, hh) And _
                Integer.TryParse(mmStr, mm)) Then

                result = (hh * 60) + mm

                '
                '  Adjust for PM
                '
                If ((timeStr.Contains("pm")) And (hh < 12)) Then
                    result = result + (12 * 60)
                End If

                '
                '  Fix for 12 AM
                '
                If ((timeStr.Contains("am")) And (hh = 12)) Then
                    result = result - (12 * 60)
                End If

            End If
        End If

        Return result
    End Function

    Public Function timeIntToDateTime(ByVal i As Integer) As DateTime
        Dim h As Integer
        Dim m As Integer

        m = i Mod 60
        h = (i - m) \ 60

        Return New DateTime(2015, 1, 1, h, m, 0)
    End Function

    Private Function formatDay(ByVal valid As Boolean, ByVal format As Integer, _
                               ByVal yes1 As String, ByVal no1 As String, _
                               ByVal yes2 As String, ByVal no2 As String, _
                               ByVal yes3 As String, ByVal no3 As String) As String
        Dim result As String = ""

        If (valid) Then
            Select Case format

                Case 2
                    result = yes2
                Case 3
                    result = yes3
                Case Else
                    result = yes1
            End Select

        Else
            Select Case format
                Case 2
                    result = no2
                Case 3
                    result = no3
                Case Else
                    result = no1
            End Select
        End If


        Return result
    End Function

    Public Function dayBitmaskToStr(days As Integer, Optional ByVal format As Integer = 1) As String
        Dim s As String = ""
        Dim format2 As Integer = format

        If (format > 3) Then
            format2 = format Mod 4
        End If

        s = s & formatDay((days And 64), format2, "Sun ", "", "Su", "", "S", ".")
        s = s & formatDay((days And 1), format2, "Mon ", "", "M", "", "M", ".")
        s = s & formatDay((days And 2), format2, "Tue ", "", "T", "", "T", ".")
        s = s & formatDay((days And 4), format2, "Wed ", "", "W", "", "W", ".")
        s = s & formatDay((days And 8), format2, "Thur ", "", "R", "", "R", ".")
        s = s & formatDay((days And 16), format2, "Fri ", "", "F", "", "F", ".")
        s = s & formatDay((days And 32), format2, "Sat ", "", "Sa", "", "S", ".")

        If ((days = 0) And (format > 3)) Then
            s = "(none)"
        End If

        Return s.TrimEnd
    End Function

    Public Function hasMonday(ByVal days As Integer) As Boolean
        Return days And 1
    End Function

    Public Function hasTuesday(ByVal days As Integer) As Boolean
        Return days And 2
    End Function

    Public Function hasWednesday(ByVal days As Integer) As Boolean
        Return days And 4
    End Function

    Public Function hasThursday(ByVal days As Integer) As Boolean
        Return days And 8
    End Function

    Public Function hasFriday(ByVal days As Integer) As Boolean
        Return days And 16
    End Function

    Public Function hasSaturday(ByVal days As Integer) As Boolean
        Return days And 32
    End Function

    Public Function hasSunday(ByVal days As Integer) As Boolean
        Return days And 64
    End Function

    Public Function daysToBitmask(days As String) As Integer
        Dim mask As Integer = 0

        days = days.ToLower

        If (days.Contains("mon")) Then
            mask = mask Or 1
        End If

        If (days.Contains("tue")) Then
            mask = mask Or 2
        End If

        If (days.Contains("wed")) Then
            mask = mask Or 4
        End If

        If (days.Contains("thu")) Then
            mask = mask Or 8
        End If

        If (days.Contains("fri")) Then
            mask = mask Or 16
        End If

        If (days.Contains("sat")) Then
            mask = mask Or 32
        End If

        If (days.Contains("sun")) Then
            mask = mask Or 64
        End If

        Return mask

    End Function


    Public Sub computeTimes(ByVal s As String, _
                             ByRef starttime As Integer, _
                             ByRef endtime As Integer)
        Dim startStr As String
        Dim endStr As String

        s = s.ToLower

        '
        ' Handle either a xxx - yyy or xxx to yyy time spans
        '
        s = s.Replace("-", "to")

        If (s.Contains("to")) Then

            startStr = s.Substring(0, s.IndexOf("to"))
            endStr = s.Substring(s.IndexOf("to") + 2)

            starttime = timeToInt(startStr)
            endtime = timeToInt(endStr)

        Else
            starttime = -1
            endtime = -1
        End If

        '
        ' Hack: Convert the 12:00am to 12:00am sections to NOT having a time at all
        '
        If ((starttime = 0) And (endtime = 0)) Then
            starttime = -1
            endtime = -1
        End If
    End Sub



    Public Function timeOverlap(start1 As Integer, end1 As Integer, _
                              start2 As Integer, end2 As Integer)
        Dim result As Boolean = True

        '
        '  If either starts after the other ends, then it doesn't
        '   overlap
        '
        If ((start1 >= end2) Or (start2 >= end1)) Then
            result = False
        End If

        Return result
    End Function


    Public Function daysOverlap(days1 As Integer, days2 As Integer) As Boolean
        Dim result As Integer

        result = days1 And days2

        Return (result <> 0)
    End Function




    Public Function DurationIntToStr(dur As Integer) As String
        Dim h As Integer
        Dim m As Integer

        m = dur Mod 60
        h = dur \ 60

        Return String.Format("{0:D}:{1:D2}", h, m)
    End Function

    Public Function TimeIntToStr(time As Integer) As String
        Dim ampm As String = "AM"
        Dim h As Integer
        Dim m As Integer
        Dim s As String

        If (time < 0) Then

            s = "(n/a)"

        Else
            m = time Mod 60
            h = time \ 60

            If (h >= 12) Then
                h = h - 12
                ampm = "PM"

                '
                '  Fix for midnight
                '
                If (h = 12) Then
                    ampm = "AM"
                End If


            End If

            '
            '  Fix for noon/midnight
            '
            If (h = 0) Then
                h = 12
            End If


            s = String.Format("{0:D}:{1:D2}", h, m) & " " & ampm
        End If

        Return s

    End Function
End Module
