
Public Class ScheduleCriteria

    Enum classFormat
        onlineonly
        classroom
        either
    End Enum

    Private _starttime As Integer
    Private _endtime As Integer
    Private _days As Integer
    Private _rooms As String()
    Private _format As classFormat
    Private _maxDays As Integer
    Private _onlyNonFull As Boolean

    Private Sub loadDefaults()
        _starttime = -1
        _endtime = -1
        _days = -1
        _format = classFormat.either
        _maxDays = 7
        _rooms = Nothing
        _onlyNonFull = False
    End Sub

    Sub New()
        loadDefaults()
    End Sub

    Sub New(ByVal rooms As String, _
            ByVal starttime As String, _
            ByVal endtime As String, _
            ByVal days As String, _
            ByVal maxDays As Integer, _
            ByVal format As String,
            ByVal onlyNonFull As Boolean)

        setStart(starttime)
        setEnd(endtime)
        setDays(days)
        setFormat(format)
        setRooms(rooms)
        setMaxDays(maxDays)
        setNonFullOnly(onlyNonFull)
    End Sub

    Sub New(ByVal s As String)
        loadDefaults()
        parseStr(s)
    End Sub


    Public Function format() As classFormat
        Return _format
    End Function

    Public Function rooms() As String
        Dim s As String = ""

        If (_rooms IsNot Nothing) Then
            s = String.Join("|", _rooms)
        End If

        Return s
    End Function

    Public Function maxDays() As Integer
        Return _maxDays
    End Function

    Public Sub setStart(ByVal t As Integer)
        _starttime = t
    End Sub

    Public Function nonFullOnly() As Boolean
        Return _onlyNonFull
    End Function

    Public Sub setStart(ByVal s As String)
        _starttime = timeToInt(s)
    End Sub

    Public Sub setEnd(ByVal t As Integer)
        _endtime = t
    End Sub

    Public Sub setEnd(ByVal s As String)
        _endtime = timeToInt(s)
    End Sub

    Public Sub setMaxDays(ByVal t As Integer)
        _maxDays = t
    End Sub

    Public Sub setDays(ByVal s As String)
        _days = daysToBitmask(s)
    End Sub

    Public Function startTimeStr() As String
        Dim s As String = "12:00 AM"

        If (_starttime > -1) Then
            s = TimeIntToStr(_starttime)
        End If

        Return s
    End Function


    Public Function startTime() As DateTime
        Dim dt As DateTime = New DateTime(2015, 1, 1, 0, 0, 0)

        If (_starttime > -1) Then
            dt = timeIntToDateTime(_starttime)
        End If

        Return dt
    End Function


    Public Function endTimeStr() As String
        Dim s As String = "11:59 PM"

        If (_endtime > -1) Then
            s = TimeIntToStr(_endtime)
        End If

        Return s
    End Function

    Public Function endTime() As DateTime
        Dim dt As DateTime = New DateTime(2015, 1, 1, 23, 59, 59)

        If (_endtime > -1) Then
            dt = timeIntToDateTime(_endtime)
        End If

        Return dt
    End Function

    '
    '  Helper functions to see if _days has a specific date
    '  (used by ShowPotentialSchedules when loading a criteria)
    '
    Public Function hasMonday() As Boolean
        Return TimeAndDateStuff.hasMonday(_days)
    End Function

    Public Function hasTuesday() As Boolean
        Return TimeAndDateStuff.hasTuesday(_days)
    End Function

    Public Function hasWednesday() As Boolean
        Return TimeAndDateStuff.hasWednesday(_days)
    End Function

    Public Function hasThursday() As Boolean
        Return TimeAndDateStuff.hasThursday(_days)
    End Function
    Public Function hasFriday() As Boolean
        Return TimeAndDateStuff.hasFriday(_days)
    End Function

    Public Function hasSaturday() As Boolean
        Return TimeAndDateStuff.hasSaturday(_days)
    End Function

    Public Function hasSunday() As Boolean
        Return TimeAndDateStuff.hasSunday(_days)
    End Function

    Public Sub setDays(ByVal t As Integer)
        _days = t
    End Sub

    Public Sub setFormat(ByVal s As String)
        _format = strToFormatPref(s)
    End Sub

    Public Sub setNonFullOnly(ByVal v As Boolean)
        _onlyNonFull = v
    End Sub

    Public Sub setRooms(ByVal s As String)
        s = s.Trim
        If (s <> "") Then
            _rooms = splitStringToPatterns(s)
        Else
            _rooms = Nothing
        End If

    End Sub

    Public Shared Function strToFormatPref(ByVal s As String) As classFormat
        Dim result As classFormat = classFormat.either

        s = s.ToLower.Trim

        If (s.Contains("online")) Then
            result = classFormat.onlineonly
        ElseIf (s.Contains("class")) Then
            result = classFormat.classroom
        End If

        Return result
    End Function


    Public Function matchesCourseCriteria(ByVal room As String, _
                                    ByVal days As Integer, _
                                    ByVal starttime As Integer, _
                                    ByVal endtime As Integer, _
                                    ByVal format As classFormat, _
                                    ByVal isFull As Boolean) As Boolean
        Dim isOk As Boolean = True ' Assume is fine

        '
        '   Non-matching starttime?
        '
        If ((starttime > -1) And (_starttime > -1) And (starttime < _starttime)) Then
            isOk = False
        End If

        '
        '   Non-matching endtime?
        '
        If ((endtime > -1) And (_endtime > -1) And (endtime > _endtime)) Then
            isOk = False
        End If

        '
        '  Did the days not match
        '
        If ((days And Not (_days)) > 0) Then
            isOk = False
        End If

        '
        '  Is the format wrong
        '
        If ((format <> classFormat.either) AndAlso (_format <> classFormat.either) AndAlso _
            (format <> _format)) Then
            isOk = False
        End If

        '
        '  Ignore full sections if necessary
        '
        If ((isFull) And (_onlyNonFull)) Then
            isOk = False
        End If

        If ((isOk) AndAlso (_rooms IsNot Nothing) AndAlso (_rooms.Count > 0)) Then
            isOk = stringMatchesPatterns(room, _rooms)
        End If

        Return isOk
    End Function


    Public Function matchesCourseCriteria(ByVal room As String, _
                                   ByVal days As Integer, _
                                   ByVal starttime As Integer, _
                                   ByVal endtime As Integer, _
                                   ByVal isFull As Boolean) As Boolean
        Dim format As classFormat = classFormat.classroom

        '
        '  Assume online if doesn't take any time
        '
        If (starttime = endtime) Then
            format = classFormat.onlineonly
        End If

        Return matchesCourseCriteria(room, days, starttime, endtime, format, isFull)
    End Function

    Private Function parseStr(ByVal s As String) As Boolean
        Dim isOk As Boolean = True
        Dim lOfS As List(Of String)
        Dim key As String = ""
        Dim val As String = ""
        Dim numval As Integer
        Dim validNum As Boolean

        lOfS = stringToTokens(s)

        '
        ' TODO: Error check some of the "set" results
        '
        For Each s In lOfS
            If (keyvalue(s, key, val)) Then

                validNum = Integer.TryParse(val, numval)

                Select Case key
                    Case "format"
                        setFormat(val)

                    Case "maxdays"
                        If (validNum) Then
                            setMaxDays(numval)
                        Else
                            isOk = False
                        End If


                    Case "days"
                        setDays(val)

                    Case "starttime"
                        setStart(val)

                    Case "endtime"
                        setEnd(val)

                    Case "room"
                        setRooms(val)

                        '
                        '  Invalid keyword?
                        '
                    Case Else
                        isOk = False

                End Select
            End If
        Next

        Return isOk
    End Function
End Class
