Class ScheduleData

    '
    '   TODO:  Handle an & in sequences for lab/lecture combos "B101&B102|C101&C102|D101&D102"
    '

    '
    '  TODO: There are two different ways of finding sequences (one finds only one, and the other finds them all)
    '                - change it to one only method
    '

    Class freeSlot
        ' Public startFreeTime() As Integer
        Public endFreeStartBusyTime() As Integer
        Public endBusyTime() As Integer
    End Class

    '
    '   Enum neededState
    '
    '   Used to indicate if a specific sequence is needed or optional
    '
    Enum neededState
        isNotNeeded
        isOptional
        isRequired
    End Enum


    ' Const MAX_ROWS As Integer = 2000

    Private SCHEDULE_SHEETNAME As String = "Courses"
    Private SEQUENCE_SHEETNAME As String = "Sequences"
    Private CAPABILTIIES_SHEETNAME As String = "Rooms"

    '
    '
    Private allSections As New List(Of oneSection)
    Private allSequences As New List(Of oneSequence)

    Public rooms As New RoomData()

    Private semesters As New List(Of String)

    ' Public numSections As Integer = 0
    ' Public numSequences As Integer = 0


    Private earliestStartOfClass As Integer = -1
    Private latestEndOfClass As Integer = -1


    '
    '   Main tab
    '
    Private coursenumCol As Integer = -1
    Private daysCol As Integer = -1
    Private timeCol As Integer = -1
    Private instructorCol As Integer = -1
    Private roomCol As Integer = -1
    Private notesCol As Integer = -1
    Private contactHrCol As Integer = -1

    Private maxEnrollCol As Integer = -1
    Private enrollCol As Integer = -1

    Private headerRow As Integer = -1

    Public errStr As String = "Spreadsheet loaded ok"

    Public Function hasEnrollmentData() As Boolean
        Dim result As Boolean = False

        If (My.Settings.EnrollTypeIsCurEnroll) Then
            result = (enrollCol > -1) And (maxEnrollCol > -1)
        Else
            result = (enrollCol > -1)
        End If

        Return result
    End Function

    Public Sub set_worksheet_names(ByVal ScheduleTab As String, ByVal SequenceTab As String, ByVal capabilitiesTab As String)
        SCHEDULE_SHEETNAME = ScheduleTab
        SEQUENCE_SHEETNAME = SequenceTab
        CAPABILTIIES_SHEETNAME = capabilitiesTab
    End Sub

    Public Function numSequences() As Integer
        Return allSequences.Count()
    End Function

    Public Function numSections() As Integer
        Return allSections.Count()
    End Function

    Public Function get_num_semesters() As Integer
        Return semesters.Count
    End Function

    Public Function get_semesters() As String()
        Return semesters.ToArray()
    End Function

    Private Function isCourseNum(ByVal s As String) As Boolean
        s = s.ToLower

        Return StringMatchesPatternString(s, My.Settings.CourseNumColumn)
    End Function

    Public Function allSequenceNames(Optional ByVal format As Integer = 1) As String()
        Dim l As New List(Of String)

        For i = 0 To allSequences.Count - 1
            If (format = 1) Then
                l.Add(allSequences(i).name & " (" & allSequences(i).semesters & ")")
            Else
                l.Add(allSequences(i).name)
            End If

        Next

        Return l.ToArray()
    End Function

    Public Function getCoursesInSequenceByNum(ByVal i As Integer) As String()
        Dim s As String() = {}

        If ((i >= 0) And (i < allSequences.Count)) Then
            s = allSequences(i).courses.ToArray
        End If

        Return s
    End Function

    '
    '  getCriteriaForSequenceByNum
    '
    '  Get any criteria for a specific sequence.  Returns "Nothing" if no criteria exists for that sequence
    '
    Public Function getCriteriaForSequenceByNum(ByVal i As Integer) As ScheduleCriteria
        Dim c As ScheduleCriteria = Nothing

        If ((i >= 0) And (i < allSequences.Count)) Then
            c = allSequences(i).critera
        End If

        Return c
    End Function

    Public Function getCourseData(ByVal i As Integer, _
                                  ByRef name As String, _
                                  ByRef days As String, _
                                  ByRef room As String, _
                                  ByRef startTime As Integer, _
                                  ByRef endtime As Integer, _
                                  Optional ByVal daysformat As Integer = 3) As Boolean
        Dim result As Boolean = False

        If ((i >= 0) And (i < allSections.Count)) Then
            result = True

            name = allSections(i).coursenum
            days = dayBitmaskToStr(allSections(i).days, daysformat)
            room = allSections(i).room
            startTime = allSections(i).starttime
            endtime = allSections(i).endtime
        End If

        Return result
    End Function

    '   Find the row that contains all of the header
    '
    Private Function FindHeaderRow(ByVal del As Action(Of Integer, String), ByVal min As Integer, ByVal max As Integer) As Boolean
        Dim isErrored As Boolean = False
        Dim row As Integer = 1
        Dim col As Integer = 1

        coursenumCol = -1
        daysCol = -1
        timeCol = -1
        instructorCol = -1
        roomCol = -1
        notesCol = -1
        contactHrCol = -1

        maxEnrollCol = -1
        enrollCol = -1

        While ((row < 100) And (headerRow = -1))
            '
            '  Find the magic cell with "Course Number"
            '
            If (isCourseNum(getCellStr(col, row))) Then
                headerRow = row
            Else
                If (col > 26) Then
                    updateMain(del, min, max, row, 100, "Loading classes")

                    row = row + 1
                    col = 1
                Else
                    col = col + 1
                End If
            End If
        End While

        If (headerRow = -1) Then
            isErrored = True
            errStr = "Could not find a header row (no cell matching """ & _
                        My.Settings.CourseNumColumn & """"
        End If

        Return isErrored
    End Function


    Private Function newStringMatchesPatternString(ByVal col As Integer, ByVal str As String, ByVal pattern As String) As Boolean
        Dim result = False

        If (col = -1) Then
            result = StringMatchesPatternString(str, pattern)
        End If

        Return result

    End Function

    Private Function FindAllColumns(ByVal del As Action(Of Integer, String), ByVal min As Integer, ByVal max As Integer) As Boolean
        Dim numFound As Integer = 0
        Dim s As String
        Dim isErrored As Boolean = False

        For col = 1 To 26
            s = getCellStr(col, headerRow).Trim

            If (newStringMatchesPatternString(instructorCol, s, My.Settings.InstructorCol)) Then
                instructorCol = col
                numFound = numFound + 1
            ElseIf (isCourseNum(s)) Then

                If (coursenumCol = -1) Then
                    coursenumCol = col
                    numFound = numFound + 1
                End If

            ElseIf (newStringMatchesPatternString(daysCol, s, My.Settings.DaysCol)) Then
                daysCol = col
                numFound = numFound + 1
            ElseIf (newStringMatchesPatternString(timeCol, s, My.Settings.TimeCol)) Then
                timeCol = col
                numFound = numFound + 1
            ElseIf (newStringMatchesPatternString(roomCol, s, My.Settings.RoomCol)) Then
                roomCol = col
                numFound = numFound + 1
            ElseIf (newStringMatchesPatternString(maxEnrollCol, s, My.Settings.MaxEnroll)) Then
                maxEnrollCol = col
                numFound = numFound + 1
            ElseIf (newStringMatchesPatternString(enrollCol, s, My.Settings.CurEnroll)) Then
                enrollCol = col
                numFound = numFound + 1
            ElseIf (newStringMatchesPatternString(contactHrCol, s, My.Settings.contactHoursCol)) Then
                contactHrCol = col
                numFound = numFound + 1
            ElseIf (newStringMatchesPatternString(notesCol, s, My.Settings.notesCol)) Then
                notesCol = col
                numFound = numFound + 1
            End If

            updateMain(del, (col * (max - min)) \ col + min, "Finding columns")
        Next


        If (numFound < 5) Then
            isErrored = True
            errStr = "Could not find the correct column headings"
        End If

        Return isErrored
    End Function


    '
    '------------------------------------------------------------------------------------
    '
    Public Sub handleSectionRow(ByVal row As Integer, _
                                ByVal interval As Integer, _
                                ByVal wsprefix As String, _
                                ByVal useCurrent As Boolean, _
                                ByVal lastY As Integer, _
                                ByVal del As Action(Of Integer, String), _
                                ByVal min As Integer, ByVal max As Integer,
                                ByRef rowCount As Integer)
        Dim curE As Integer
        Dim courseNum As String
        Dim needToUpdate As Boolean = False
        Dim s As String
        Dim days As String
        Dim i As Integer


        courseNum = getCellStr(coursenumCol, row)

        '
        '  See if it's been striked out (via the font)
        '   (if so, ignore it)
        '
        If ((Not isStrikethrough(coursenumCol, row)) And (courseNum.Trim <> "")) Then
            Dim one As oneSection

            one = New oneSection

            one.coursenum = courseNum.Trim
            one.room = getCellStr(roomCol, row).Trim
            one.instructor = getCellStr(instructorCol, row).Trim
            one.loc = wsprefix + row.ToString

            days = getCellStr(daysCol, row)

            ' Does the days line spill into multiple lines
            ' (ugly hack for YCCC website)

            i = 1

            While ((getCellStr(coursenumCol, row + i) = "") And (getCellStr(daysCol, row + i) <> ""))

                days = days & " " & getCellStr(daysCol, row + i)
                i = i + 1

            End While

            one.days = daysToBitmask(days)

            computeTimes(getCellStr(timeCol, row), one.starttime, one.endtime)

            '
            '  Find the end of the day
            '
            If ((latestEndOfClass = -1) Or (one.endtime > latestEndOfClass)) Then
                latestEndOfClass = one.endtime
            End If

            '
            '   Find the beginning of the day
            '
            If ((earliestStartOfClass = -1) Or (one.starttime < earliestStartOfClass)) Then
                earliestStartOfClass = one.starttime
            End If

            '
            '  Is this a ghost section (if yes = use for room/time conflicts, but not to satisfy sequences)
            '
            If (notesCol > -1) Then
                s = getCellStr(notesCol, row).ToLower

                one.notes = s

                '
                '  TODO: remove hardcoded words for ghost section
                '
                If (StringMatchesPatternString(s, "*ghost*|*shadow*|*hide*")) Then
                    one.isGhostedSection = True
                End If
            End If


            If (contactHrCol > -1) Then
                one.contactHours = getCellInt(contactHrCol, row)
            End If

            ' alldays = (alldays Or one.days)

            '
            '  See if this section is "full"
            '
            If (enrollCol > -1) Then
                curE = getCellInt(enrollCol, row)

                '
                '  Depending on if "curEnroll" is a count-up or a 
                '   count-down, do the correct math to determine if
                '   the class is full
                '
                If (Not useCurrent) Then
                    one.sectionIsFull = (curE > 0)
                ElseIf (maxEnrollCol > -1) Then
                    one.sectionIsFull = (curE < getCellInt(maxEnrollCol, row))
                End If
            End If


            ''
            ''  If all blank EXCEPT for coursenum, assume the line is actually a comment
            ''   (or a mistake) and don't add it
            ''
            ''If ((one.room <> "") Or (one.starttime > -1) Or (one.endtime > -1) Or _
            ''    (one.days <> 0) Or (one.instructor <> "")) Then

            SyncLock allSections
                allSections.Add(one)

                rowCount = rowCount + 1
                needToUpdate = (rowCount Mod interval = 0)
            End SyncLock


            'The spinlock has been released, now 
            '  update the progress bar only when necessary 
            '  (ok, we can't do this without a deadlock occuring :-( )
            '          
            If (needToUpdate) Then
                ' updateMain(del, min, max, rowCount, lastY, "Loading sections")
            End If


            If (Not rooms.roomExists(one.room)) Then
                SyncLock rooms
                    rooms.addRoom(one.room)
                End SyncLock
            End If

        End If
    End Sub


    '
    '----------------------------------------------------------------------------------
    '


    Private Sub LoadAllSections(ByVal del As Action(Of Integer, String), _
                                ByVal min As Integer, ByVal max As Integer)
        Dim wsprefix As String
        Dim lastX, lastY As Integer
        Dim interval As Integer
        Dim useCurrent As Boolean = My.Settings.EnrollTypeIsCurEnroll
        Dim rowCount As Integer = 0

        '
        '  Recompute the days and start/end of the school as a whole
        '
        earliestStartOfClass = -1
        latestEndOfClass = -1

        If (openworksheet(SCHEDULE_SHEETNAME, 1)) Then
            wsprefix = activeWorksheetName() + "!A"
            getLastUsedRowAndColumn(lastX, lastY)

            interval = lastY \ (max - min)       ' We want updates to the progress bar that we will see

            '
            'For row As Integer = headerRow + 1 To lastY
            'handleSectionRow(row, interval, wsprefix, useCurrent, lastY, del, min, max)
            'Next row

            Threading.Tasks.Parallel.For(headerRow + 1, lastY + 1, Sub(row)
                                                                       handleSectionRow(row, interval, wsprefix, useCurrent, lastY, del, min, max, rowCount)
                                                                   End Sub)
        End If

    End Sub



    Private Sub LoadAllRoomCapabilities(ByVal del As Action(Of Integer, String), _
                             ByVal min As Integer, ByVal max As Integer)
        Dim wsprefix As String
        Dim row As Integer = 1
        Dim numBlank As Integer = 0
        Dim hash As HashSet(Of String)
        Dim lastX, lastY As Integer
        Dim s As String
        Dim roomName As String
        Dim roomNameCol As Integer = 1
        Dim roomSizeCol As Integer = 2
        Dim descrCol As Integer = -1
        Dim roomCapabilitiesCol As Integer = 3
        Dim matchedOne As Boolean = False
        Dim maxStudents As Integer
        Dim descr As String

        If (openworksheet(CAPABILTIIES_SHEETNAME, 3)) Then
            getLastUsedRowAndColumn(lastX, lastY)
            wsprefix = activeWorksheetName() + "!A"


            For col As Integer = 1 To 26
                s = getCellStr(col, row)
                Select Case s.ToLower

                    Case My.Settings.RoomCapabilityColumn.ToLower
                        roomCapabilitiesCol = col
                        matchedOne = True

                    Case My.Settings.MaxCapacityColumn.ToLower
                        roomSizeCol = col
                        matchedOne = True

                    Case My.Settings.roomDescription.ToLower
                        descrCol = col
                        matchedOne = True
                End Select
            Next

            If (matchedOne) Then
                row = row + 1
            End If

            While (row <= lastY)
                roomName = getCellStr(roomNameCol, row)

                If (roomName = "") Then
                    numBlank = numBlank + 1
                Else
                    numBlank = 0

                    If (Not isStrikethrough(1, row)) Then

                        '
                        '  Get the description if possible
                        '
                        If (descrCol > -1) Then
                            descr = getCellStr(descrCol, row)
                        Else
                            descr = ""
                        End If

                        Integer.TryParse(getCellStr(roomSizeCol, row), maxStudents)

                        hash = New HashSet(Of String)

                        For i As Integer = roomCapabilitiesCol To lastX
                            s = getCellStr(i, row).Trim.ToLower

                            '
                            '  Is there data here?
                            '
                            If (s <> "") Then
                                hash.Add(s)
                            End If
                        Next i

                        rooms.addRoomWithCapabilties(roomName, maxStudents, descr, hash)
                    End If
                End If

                row = row + 1

                updateMain(del, min, max, row, lastY, "All room capabilities loaded")

                ' capabilities.Sort()

            End While
        End If

    End Sub

    '
    '   Gather a list of semesters from each sequence
    '
    '
    Private Sub AddSemesters(ByVal mySemesters As String)
        Dim s As String

        For Each s In (mySemesters.Split("/"c))
            s = s.Trim
            s = s.TrimEnd("?"c) ' Ignore the character indicating optional

            If ((s <> "") AndAlso (Not semesters.Contains(s, StringComparer.OrdinalIgnoreCase))) Then
                semesters.Add(s)
            End If
        Next

    End Sub


    '
    '-------------------------------------------------------------------------------------
    '
    Private Sub LoadAllSequences(ByVal del As Action(Of Integer, String), _
                                 ByVal min As Integer, ByVal max As Integer)
        Dim row As Integer = 2      ' Ignore the title row
        Dim numBlank As Integer = 0
        Dim sequenceName As String
        Dim col As Integer
        Dim cell As String
        Dim newstrings As String()
        Dim wsprefix As String
        Dim one As oneSequence
        Dim lastX, lastY As Integer
        Dim criteriaCol As Integer = -1
        Dim semesterCol As Integer = 2
        Dim courseStartCol As Integer = 3
        Dim s As String

        If (openworksheet(SEQUENCE_SHEETNAME, 2)) Then

            getLastUsedRowAndColumn(lastX, lastY)

            wsprefix = activeWorksheetName() + "!A"

            '
            ' TODO: Don't hardcode the names of the columns, nor tie it to the first row
            '
            For col = 1 To lastX
                Select Case getCellStr(col, 1).ToLower.Trim
                    Case "courses", "course"
                        courseStartCol = col
                    Case "criteria"
                        criteriaCol = col
                    Case "semester", "semesters"
                        semesterCol = col
                End Select
            Next

            '
            '  End when we see 5 blank lines in a row (or fill the array )
            '
            While (row <= lastY)
                sequenceName = getCellStr(1, row)

                If (sequenceName = "") Then
                    numBlank = numBlank + 1
                Else
                    numBlank = 0

                    '
                    '  Ignore the items that are struck out
                    '
                    If (Not isStrikethrough(1, row)) Then
                        one = New oneSequence

                        one.name = sequenceName.Trim
                        one.semesters = getCellStr(semesterCol, row).Trim
                        AddSemesters(one.semesters)

                        '
                        '  Add the criteria if necessary
                        '
                        If (criteriaCol > -1) Then
                            s = getCellStr(criteriaCol, row).Trim

                            If (s <> "") Then
                                one.critera = New ScheduleCriteria(s)
                            End If

                        End If


                        '
                        '   Create an array of all of the courses in a sequence
                        '
                        col = courseStartCol
                        cell = getCellStr(col, row)


                        While (cell <> "")
                            '
                            '  Ignore the items that are visually have strikeout
                            '
                            If (Not isStrikethrough(row, col)) Then
                                newstrings = cell.Split(","c)

                                '
                                '  Need to add this to the list.  Does the list already exist?
                                '   (if so, just append the new items)
                                '
                                If (one.courses Is Nothing) Then
                                    one.courses = New List(Of String)
                                End If

                                one.courses.AddRange(newstrings)

                            End If

                            col = col + 1
                            cell = getCellStr(col, row)
                        End While

                        one.loc = wsprefix & row.ToString

                        allSequences.Add(one)

                    End If
                    End If

                    updateMain(del, min, max, row, lastY, "All sequences loaded")

                    row = row + 1
            End While


            '
            '  Sort the master list of semesters
            '
            semesters.Sort()
            allSequences.Sort()
        End If


    End Sub

    '
    '-------------------------------------------------------------------------------------
    '
    Private Sub updateMain(ByVal del As Action(Of Integer, String), ByVal i As Integer, ByVal s As String)

        If (del IsNot Nothing) Then
            del(i, s)
        End If
    End Sub

    Private Sub updateMain(ByVal del As Action(Of Integer, String), _
                           ByVal displayMin As Integer, ByVal displayMax As Integer, _
                           ByVal countCur As Integer, ByVal countMax As Integer, _
                           ByVal s As String)
        Dim displayDelta As Integer
        Dim mypercent As Integer

        If (del IsNot Nothing) Then
            displayDelta = displayMax - displayMin
            mypercent = (countCur * displayDelta \ countMax)

            del(mypercent + displayMin, s)
        End If
    End Sub

    Public Function loadData(ByVal filename As String, _
                             Optional ByVal useOpenFile As Boolean = False, _
                             Optional ByVal del As Action(Of Integer, String) = Nothing) As Boolean
        Dim isErrored As Boolean = False

        updateMain(del, 0, "Resetting internal array")

        allSections.Clear()
        allSequences.Clear()
        rooms.Clear()

        ' Array.Clear(allSections, 0, allSections.Length)


        updateMain(del, 2, "Opening Excel")

        openExcel(filename, useOpenFile)
        updateMain(del, 5, "Finding header row of the data")

        isErrored = FindHeaderRow(del, 5, 30)

        If (Not isErrored) Then
            updateMain(del, 20, "Finding all data columns")
            isErrored = FindAllColumns(del, 30, 50)
        End If

        If (Not isErrored) Then
            updateMain(del, 40, "Loading all sections")
            LoadAllSections(del, 50, 65)
        End If

        If (Not isErrored) Then
            updateMain(del, 75, "Loading sequences")
            LoadAllSequences(del, 65, 80)
        End If

        If (Not isErrored) Then
            updateMain(del, 75, "Loading Room Capabilities")
            LoadAllRoomCapabilities(del, 80, 95)
        End If


        If (Not isErrored) Then
            updateMain(del, 95, "Closing Excel")
        End If

        CloseExcel()
        updateMain(del, 100, "Loading raw data complete")

        Return Not isErrored
    End Function


    Public Function countFaculty(hideAtOrBelow As Integer) As List(Of oneFacCount)
        Dim instructor As String
        Dim i As Integer
        Dim h As New Dictionary(Of String, Integer)
        Dim l As New List(Of oneFacCount)
        Dim oneCount As oneFacCount

        For i = 0 To numSections() - 1
            instructor = allSections(i).instructor

            If (h.ContainsKey(instructor)) Then
                h(instructor) = h(instructor) + 1
            Else
                h(instructor) = 1
            End If
        Next

        '
        '  Now go through and find the keys 
        '    (but go through the list to create a numerically descending list)
        '

        For Each instructor In h.Keys
            If (h(instructor) > hideAtOrBelow) Then
                oneCount = New oneFacCount
                oneCount.name = instructor
                oneCount.count = h(instructor)

                l.Add(oneCount)
            End If
        Next

        Return l
    End Function

    Private Function overlapStr(s As String, s2 As String, _
                                i As Integer, j As Integer) As String
        Dim result As String

        result = allSections(i).coursenum & " and " & _
                 allSections(j).coursenum & " both use the same " & _
                 s & " (" & s2 & ") at the same time"

        Return result
    End Function



    '
    '   findOverlaps()
    '
    '       Find out of two classes use the same room at the same time
    '       or two instructors are scheduled for two classes at the same time
    '
    Public Function findOverlaps() As List(Of scheduleMessage)
        Dim result As New List(Of scheduleMessage)
        Dim mesg As scheduleMessage
        Dim totalRoomTBAs As Integer = 0
        Dim totalInstructorTBAs As Integer = 0

        For i As Integer = 0 To numSections() - 1
            '
            '  Check for TBA's
            '
            If (isTBA(allSections(i).room)) Then totalRoomTBAs = totalRoomTBAs + 1
            If (isTBA(allSections(i).instructor)) Then totalInstructorTBAs = totalInstructorTBAs + 1

            '
            '   Don't try to check against all others on the last entry
            '
            If (i < numSections() - 1) Then
                For j As Integer = i + 1 To numSections() - 1

                    '
                    '  Do the two sections overlap?
                    '
                    If ((daysOverlap(allSections(i).days, _
                                    allSections(j).days)) AndAlso _
                        (timeOverlap(allSections(i).starttime, _
                                     allSections(i).endtime, _
                                     allSections(j).starttime, _
                                     allSections(j).endtime))) Then

                        If (isSameIgnoreTBA(allSections(i).room, allSections(j).room) AndAlso _
                            (Not isColistedClass(i, j))) Then
                            mesg = New scheduleMessage

                            mesg.severity = "Alert"
                            mesg.type = "Overlap"
                            mesg.description = overlapStr("room", allSections(j).room, i, j)

                            mesg.loc1 = allSections(i).loc
                            mesg.loc2 = allSections(j).loc

                            mesg.text1 = allSections(i).coursenum
                            mesg.text2 = allSections(j).coursenum

                            result.Add(mesg)
                        End If

                        If (isSameIgnoreTBA(allSections(i).instructor, allSections(j).instructor) AndAlso _
                            (Not isColistedClass(i, j))) Then

                            mesg = New scheduleMessage

                            mesg.severity = "Alert"
                            mesg.type = "Overlap"
                            mesg.description = overlapStr("instructor", allSections(j).instructor, i, j)

                            mesg.loc1 = allSections(i).loc
                            mesg.loc2 = allSections(j).loc

                            mesg.text1 = allSections(i).coursenum
                            mesg.text2 = allSections(j).coursenum

                            result.Add(mesg)
                        End If

                    End If

                Next j
            End If
        Next i


        If (totalInstructorTBAs > 0) Then
            addSingleMessage(result, -1, totalInstructorTBAs.ToString & " sections do not have an instructor", "TBA")
        End If

        If (totalRoomTBAs > 0) Then
            addSingleMessage(result, -1, totalRoomTBAs.ToString & " sections do not have a room assigned", "TBA")
        End If

        Return result
    End Function


    Sub addSingleMessage(ByRef l As List(Of scheduleMessage), _
                         ByVal i As Integer, _
                         ByVal partialdescription As String, _
                         Optional ByVal type As String = "Time", _
                         Optional ByVal severity As String = "Warning")
        Dim mesg As scheduleMessage

        mesg = New scheduleMessage

        mesg.severity = severity
        mesg.type = type

        If (i >= 0) Then
            mesg.text1 = allSections(i).coursenum
            mesg.loc1 = allSections(i).loc

            mesg.description = allSections(i).coursenum & " " & partialdescription
        Else
            mesg.text1 = ""
            mesg.loc1 = ""
            mesg.description = partialdescription
        End If

        mesg.loc2 = ""
        mesg.text2 = ""

        l.Add(mesg)
    End Sub

    '
    '----------------------------------------------------------------------------------------
    '
    Public Function findOddTimes() As List(Of scheduleMessage)
        Dim actualMinutes, contactMinutes As Integer

        Dim result As New List(Of scheduleMessage)

        If ((contactHrCol = -1) And (My.Settings.checkContactHours)) Then
            addSingleMessage(result, -1, "Did not find ""Contact Hour"" column, cannot check minmum contact hour", "Contact Hours")
        End If

        For i As Integer = 0 To numSections() - 1
            If (allSections(i).starttime > -1) And (allSections(i).endtime < 0) Then

                addSingleMessage(result, i, "has a valid start time (" & _
                                   TimeIntToStr(allSections(i).starttime) & _
                                   ") but no valid end time", , "Error")

            ElseIf (allSections(i).endtime > -1) And (allSections(i).starttime < 0) Then

                addSingleMessage(result, i, "has a valid end time (" & _
                                   TimeIntToStr(allSections(i).endtime) & _
                                   ") but no valid start time", , "Error")

            ElseIf (allSections(i).endtime < allSections(i).starttime) Then

                addSingleMessage(result, i, "ends (" & _
                                   TimeIntToStr(allSections(i).endtime) & _
                                   ") before it starts (" & TimeIntToStr(allSections(i).starttime) & _
                                   ")", , "Error")

            ElseIf ((allSections(i).starttime > -1) And (allSections(i).days = 0)) Then

                addSingleMessage(result, i, "has a valid start time (" & _
                                   TimeIntToStr(allSections(i).starttime) & _
                                   ") but no valid days of the week", , "Error")

            ElseIf ((allSections(i).starttime < 0) And (allSections(i).days > 0)) Then

                addSingleMessage(result, i, "has a valid week days (" & _
                                   dayBitmaskToStr(allSections(i).days, 2) & _
                                   ") but no valid start time", , "Error")

            End If

            If ((allSections(i).starttime > 0) And (allSections(i).room = "")) Then
                addSingleMessage(result, i, "has no room assigned", "Room")
            End If

            If (allSections(i).instructor = "") Then
                addSingleMessage(result, i, "has no instructor assigned, nor TBA", "Instr")
            End If

            '
            '  Check only if the column exists and the person wants to check the info
            '
            If ((My.Settings.checkContactHours) And (allSections(i).contactHours > 0)) Then

                contactMinutes = 50 * allSections(i).contactHours ' TODO: Don't hardcode 50 minute hours
                actualMinutes = (allSections(i).endtime - allSections(i).starttime) * daysToNumDays(allSections(i).days)

                '
                '  Ignore online (or other non-time courses)
                '
                '
                '  TODO: Hack to avoid hybrids
                '
                If ((actualMinutes > 0) AndAlso (actualMinutes < contactMinutes) AndAlso _
                    (Not allSections(i).coursenum.EndsWith("HY"))) Then

                    addSingleMessage(result, i, _
                                     "does not meet long enough for " & allSections(i).contactHours.ToString & " contact hours", _
                                     "Contact hours")
                End If
            End If

        Next i

        Return result
    End Function

    '
    '----------------------------------------------------------------------------------------
    '
    Public Function findOddSections() As List(Of scheduleMessage)
        Dim result As New List(Of scheduleMessage)
        Dim delta As Integer
        Dim startTime As Integer
        Dim endTime As Integer
        Dim mesg As scheduleMessage

        For i As Integer = 0 To numSections() - 1
            endTime = allSections(i).endtime
            startTime = allSections(i).starttime

            '
            '  Ignore the classes without times
            '
            If ((startTime <> -1) Or (endTime <> -1)) Then
                delta = endTime - startTime

                '
                '  Valid durations (hh:mm):  
                '       0:50  (1 credit hr, aka a bio lab)
                '       1:15  (3 credit hr/2x a week, aka a normal LC class)
                '       1:40  (4 credit/2x a week)
                '       2:30  (3 credit hr/1x a week, aka a normal LC class)
                '       3:20  (4 credit hr/1x a week)
                '

                If ((delta <> 50) And (delta <> 75) And (delta <> 100) And (delta <> 150) And (delta <> 200)) Then

                    mesg = New scheduleMessage

                    mesg.severity = "Warning"
                    mesg.type = "Duration"
                    mesg.description = allSections(i).coursenum & " has an odd class length (" & delta.ToString & " minutes)"

                    mesg.text1 = allSections(i).coursenum
                    mesg.loc1 = allSections(i).loc

                    mesg.loc2 = ""
                    mesg.text2 = ""

                    result.Add(mesg)
                End If
            End If

        Next

        Return result
    End Function



    Private Function findAllSectionsInRoom(room As String, starttime As Integer, endtime As Integer, days As Integer) As List(Of Integer)
        Dim i As Integer
        Dim matched As New List(Of Integer)

        room = room.ToUpper

        For i = 0 To numSections() - 1
            '
            '  Find all uses of the room in the desired time slice
            '
            If (allSections(i).room.ToUpper = room) Then

                If (daysOverlap(allSections(i).days, days) And _
                timeOverlap(allSections(i).starttime, allSections(i).endtime, _
                            starttime, endtime)) Then

                    matched.Add(i)
                End If
            End If
        Next

        Return matched
    End Function


    Private Sub resetCurrentSlots(ByRef currentSlots As freeSlot, ByVal startFree As Integer, endFree As Integer, days As Integer)
        Dim i As Integer

        For i = 0 To 6
            If (daysOverlap(days, 1 << i)) Then
                'currentSlots.startFreeTime(i) = startFree
                currentSlots.endFreeStartBusyTime(i) = endFree
                currentSlots.endBusyTime(i) = endFree
            Else
                'currentSlots.startFreeTime(i) = -1
                currentSlots.endFreeStartBusyTime(i) = -1
                currentSlots.endBusyTime(i) = -1
            End If
        Next i

    End Sub


    Private Sub findCurrentSlotsStartingAtTime(ByRef currentSlots As freeSlot, ByRef matched As List(Of Integer), _
                                               ByVal startFree As Integer, endFree As Integer, days As Integer)

        Dim i As Integer
        Dim j As Integer

        For j = 0 To matched.Count - 1
            '
            '  Use only matches matches that are within the correct period
            '
            If ((allSections(matched(j)).starttime < endFree) And (allSections(matched(j)).endtime > startFree)) Then


                For i = 0 To 6

                    '
                    '  Start with Mon, then Tue, ... and check...
                    '

                    '   1 - does this class occur on this day?
                    '   2 - is this day a day we are interested in?
                    '
                    If ((daysOverlap(allSections(matched(j)).days, 1 << i)) And (daysOverlap(days, 1 << i))) Then

                        '
                        '  Okay, this class does occur on the day we are interested in...
                        '
                        '

                        '
                        '   There are three different cases  
                        '
                        '   a - the class does not meet in the period we are interested in (startFree<=x<=endFree)
                        '       (this does not affect the room's availability for the purposes of this search)
                        '
                        '   b - the class begins before (or at) the beginning period, hence the room is not available
                        '       (but record when the next period that we "could" be interested in)
                        '
                        '   c - the class starts sometime during the period (so there is some availability, but not unlimited availability)
                        '       (record the time that the room will NOT available)
                        '





                        If ((allSections(matched(j)).starttime <= startFree) And (allSections(matched(j)).endtime > startFree)) Then
                            '
                            '    Handle case "B" - course occurs at the beginning of the requested period
                            '
                            '   Does this class overlap the start of our period?  If so, then bump the startFree upward
                            '
                            '

                            '
                            '   THIS CASE IS NO FREE TIME ON THIS DAY
                            '


                            ' Indicate no free time first
                            '
                            currentSlots.endFreeStartBusyTime(i) = startFree


                            '
                            '  Compute the next free time 
                            '
                            '
                            If (currentSlots.endBusyTime(i) > allSections(matched(j)).endtime) Then
                                currentSlots.endBusyTime(i) = allSections(matched(j)).endtime
                            End If


                            '
                            '  Handle case "C" - course occurs in the period, but not at the beginning of the period
                            '
                            '
                        ElseIf (allSections(matched(j)).starttime <= endFree) Then
                            '
                            '   THIS CASE IS SOME FREE TIME ON THIS DAY
                            '

                            '
                            '  Multiple courses could be in the requested period, so find the first class that starts
                            '
                            If (allSections(matched(j)).starttime < currentSlots.endFreeStartBusyTime(i)) Then
                                currentSlots.endFreeStartBusyTime(i) = allSections(matched(j)).starttime
                            End If

                            '
                            '  This could take less than the whole rest of the period, so see when it ends and update the endtime too
                            '

                            If (allSections(matched(j)).endtime < endFree) Then
                                '  Compute the next free time 
                                '
                                If (currentSlots.endBusyTime(i) > allSections(matched(j)).endtime) Then
                                    currentSlots.endBusyTime(i) = allSections(matched(j)).endtime
                                End If
                            End If


                        End If

                    End If    ' Matching day

                Next i

            End If

        Next j
    End Sub

    '
    '  findLargestFreeTime
    '
    '  This routine looks at the currentSlots for a time that begins at the appropriate time and
    '   find the # of days that match it
    '
    '

    Private Sub findLargestFreeTime(ByRef currentSlots As freeSlot, _
                                    ByRef daysFound As Integer, ByRef daysAsNum As Integer, _
                                    ByRef largestEndTime As Integer, _
                                    ByVal startFree As Integer, ByVal endFree As Integer, _
                                    ByVal duration As Integer, ByVal maxblock As Integer)
        Dim i As Integer = 0

        daysFound = 0
        largestEndTime = startFree

        While (i <= 6)
            '
            '  If the block will not fit the proposed duration - then ignore it
            '
            If (currentSlots.endFreeStartBusyTime(i) >= startFree + duration) Then


                If ((maxblock > 0) And ((currentSlots.endFreeStartBusyTime(i) - startFree) >= maxblock)) Then
                    '
                    '   This is only used on second or third or... rounds through the same time period
                    '   to find other periods that also satisfy the time
                    '
                    daysFound = daysFound + 1
                    daysAsNum = daysAsNum + (1 << i)

                ElseIf (currentSlots.endFreeStartBusyTime(i) > largestEndTime) Then

                    '
                    '  Did we find a longer timeslot, if so use it & reset the parameters so far
                    '

                    largestEndTime = currentSlots.endFreeStartBusyTime(i)

                    daysFound = 0
                    daysAsNum = 0

                    i = -1      ' (the i=i+1 will make it 0 to do a proper reset)

                ElseIf (currentSlots.endFreeStartBusyTime(i) = largestEndTime) Then

                    daysFound = daysFound + 1
                    daysAsNum = daysAsNum + (1 << i)

                End If

            End If

            i = i + 1
        End While


        '
        '  If we only found blocks above the "maxblock" size, then ignore them
        '   (this prevents a second message from appearing)
        '
        If (largestEndTime = startFree) Then
            daysFound = 0
            daysAsNum = 0
        End If

    End Sub


    Private Function isSubsetOfExistingReport(ByRef newReport As roomReportEntry, ByRef allReports As List(Of roomReportEntry)) As Boolean
        Dim result As Boolean = False
        Dim i As Integer = 0

        While ((i < allReports.Count) And (result = False))
            '
            '  Subsets must have the same day combinations
            '
            If ((newReport.days = allReports(i).days) And (newReport.room = allReports(i).room)) Then
                '
                '  Subsets (or duplicates) will be within the original range
                '   (note: due to the ordering of the search - the larger range will be first)
                '
                If ((newReport.startTime >= allReports(i).startTime) And (newReport.endTime <= allReports(i).endTime)) Then
                    result = True
                End If
            End If

            i = i + 1
        End While


        Return result
    End Function

    Private Sub updateStartEndTimes(ByVal n As Integer, _
                                    ByRef startt() As Integer, _
                                    ByRef endt() As Integer, _
                                    ByRef timeInClass As Integer)
        Dim i As Integer
        Dim bit As Integer = 1

        For i = 0 To 6
            If (allSections(n).days And bit) Then
                startt(i) = newMin(startt(i), allSections(n).starttime)
                endt(i) = newMax(endt(i), allSections(n).endtime)

                timeInClass += allSections(n).endtime - allSections(n).starttime
            End If

            bit = bit << 1
        Next

    End Sub


    Public Sub computeDaysAndOnline(ByRef l As List(Of Integer), _
                             ByRef daysOnCampus As Integer, _
                             ByRef numOnline As Integer, _
                             ByRef timeOnCampus As Integer)
        Dim i As Integer
        Dim totalMask As Integer = 0
        Dim oneMask As Integer
        Dim starttime(6) As Integer
        Dim endtime(6) As Integer
        Dim timeInClass As Integer = 0

        daysOnCampus = 0
        numOnline = 0

        If (l IsNot Nothing) Then

            '
            '   Initialize the starttime/endtime arrays
            '
            For i = 0 To 6
                starttime(i) = -1
                endtime(i) = -1
            Next

            For i = 0 To l.Count - 1
                oneMask = allSections(l(i)).days

                totalMask = totalMask Or oneMask

                If (oneMask = 0) Then
                    numOnline = numOnline + 1
                Else
                    updateStartEndTimes(l(i), starttime, endtime, timeInClass)
                End If
            Next

            daysOnCampus = countBits(totalMask)
            timeOnCampus = 0

            For i = 0 To 6
                timeOnCampus += endtime(i) - starttime(i)
            Next

            '
            '  FIXME: Efficiency rating HACK
            '
            If (timeOnCampus > 0) Then
                timeOnCampus = 100 * timeInClass / timeOnCampus
            Else
                timeOnCampus = 100
            End If

        End If
    End Sub

    Private Sub computeTotalDays(ByRef l As List(Of Integer), _
                                 ByRef daysWithOnline As Integer, _
                                 ByRef daysWithoutOnline As Integer)
        Dim i As Integer
        Dim usesOnline As Boolean = False  ' Assume it doesn't use an online course
        Dim totalMask As Integer = 0
        Dim oneMask As Integer

        daysWithOnline = -1
        daysWithoutOnline = -1

        If (l IsNot Nothing) Then
            For i = 0 To l.Count - 1
                oneMask = allSections(l(i)).days

                totalMask = totalMask Or oneMask

                If (oneMask = 0) Then
                    usesOnline = True
                End If
            Next


            daysWithOnline = countBits(totalMask)

            If (Not usesOnline) Then
                daysWithoutOnline = daysWithOnline
            End If

        End If

    End Sub




    Public Sub MaxDaysForSchedule(ByRef allscheds As List(Of List(Of Integer)), _
                                 ByRef maxDaysWithOnline As Integer, _
                                 ByRef maxDaysWithoutOnline As Integer)

        Dim i As Integer
        Dim daysWithoutOnline, daysWithOnline As Integer

        maxDaysWithOnline = -1
        maxDaysWithoutOnline = -1

        If (allscheds IsNot Nothing) Then

            For i = 0 To allscheds.Count - 1
                computeTotalDays(allscheds(i), daysWithOnline, daysWithoutOnline)

                maxDaysWithOnline = newMin(maxDaysWithOnline, daysWithOnline)
                maxDaysWithoutOnline = newMin(maxDaysWithoutOnline, daysWithoutOnline)
            Next i

        End If

    End Sub



    '
    '   findAllOccurancesAtStartTime
    '
    '   One startTime could have multiple "reports", such as one with a few days but long duration and another
    '   that has more days but a shorter duration.   So, find all of the possibilities
    '
    '

    Private Sub findAllOccurancesAtStartTime(ByRef currentSlots As freeSlot, _
                                             ByVal room As String, ByVal duration As Integer, _
                                             ByVal classCount As Integer, ByVal days As Integer, _
                                             ByVal startFree As Integer, ByVal endFree As Integer, _
                                             ByRef allpossibilities As List(Of roomReportEntry))

        Dim daysFound As Integer = 0
        Dim largestEndTime As Integer
        Dim daysAsNum As Integer
        Dim prevDays As Integer
        Dim maxDuration As Integer = -1
        Dim newReport As roomReportEntry

        Do
            prevDays = daysFound

            findLargestFreeTime(currentSlots, daysFound, daysAsNum, _
                                largestEndTime, _
                                startFree, endFree, duration, maxDuration)

            '
            '  Limit the search for the next round
            '
            maxDuration = largestEndTime - startFree

            If (daysFound >= classCount) Then

                '
                '  Report a valid hole
                '

                newReport = New roomReportEntry

                newReport.room = room.ToUpper
                newReport.descr = rooms.roomToDescr(room)
                newReport.startTime = startFree
                newReport.endTime = largestEndTime
                newReport.days = daysAsNum

                If (Not isSubsetOfExistingReport(newReport, allpossibilities)) Then
                    allpossibilities.Add(newReport)
                End If

            End If

        Loop While ((daysFound > prevDays) And (daysFound > 0))
    End Sub



    Private Function findNextStartTime(ByRef currentSlots As freeSlot, ByVal endFree As Integer) As Integer
        Dim i As Integer
        Dim newStart As Integer

        newStart = endFree

        For i = 0 To 6
            If ((currentSlots.endBusyTime(i) < newStart) And (currentSlots.endBusyTime(i) > 0)) Then
                newStart = currentSlots.endBusyTime(i)
            End If
        Next

        Return newStart
    End Function

    Private Sub findFreeTimeSingleRoom(room As String, duration As Integer, _
                                    classCount As Integer, _
                                    startFree As Integer, endFree As Integer, _
                                    days As Integer, _
                                    ByRef allPossibilities As List(Of roomReportEntry))

        Dim matched As List(Of Integer)
        Dim currentSlots As New freeSlot

        ' ReDim currentSlots.startFreeTime(6)
        ReDim currentSlots.endFreeStartBusyTime(6)
        ReDim currentSlots.endBusyTime(6)

        '
        '   We now have a list of all classes during that time
        '    so look for free periods
        '
        matched = findAllSectionsInRoom(room, startFree, endFree, days)

        If (matched.Count > 0) Then

            While (startFree < endFree)
                '
                ' 1 - Reset the array to look at this time (assume free the entire time)
                '
                resetCurrentSlots(currentSlots, startFree, endFree, days)

                '
                '  2 - Create the "currentSlots" structure listing free times and busy times
                '       
                findCurrentSlotsStartingAtTime(currentSlots, matched, startFree, endFree, days)


                '
                ' 3 - Find all possibilities starting at this particular time
                '
                findAllOccurancesAtStartTime(currentSlots, room, duration, classCount, days, startFree, endFree, allPossibilities)


                '
                ' 4 - Determine where to look 
                '
                startFree = findNextStartTime(currentSlots, endFree)
            End While
        End If


        ''
        ''  Did the user enter a room not listed in the spreadsheet?
        ''
        'If (Not quiet) Then
        '    If (matched.Count = 0) Then
        '        result = "*** There was no use of room """ & room & """ in the spreadsheet at all!"
        '    End If

        '    If (result = "") Then
        '        result = "No free times found for " & room
        '    End If
        'End If

    End Sub


    Private Function findFreeTimeHlp(roombox As String, duration As Integer, _
                                classCount As Integer, _
                                starttime As Integer, endtime As Integer, days As Integer, _
                                ByRef desiredCapabilities As HashSet(Of String), _
                                ByVal matchAllCapabilities As Boolean, _
                                ByVal minroomsize As Integer, ByVal defaultRoomSize As Integer, _
                                ByRef allPossibilities As List(Of roomReportEntry), _
                                ByRef errorString As String) As Boolean

        Dim isError As Boolean = False
        Dim selectedrooms() As String
        Dim room As String
        Dim numRoomsMatchedName As Integer = 0
        Dim numRoomsMatchedCapabilities As Integer = 0
        Dim origRoomBox As String = roombox

        roombox = roombox.Trim

        If ((roombox = "") Or (roombox.ToLower = "<any>")) Then
            '
            '  Check each room individually
            '
            For Each room In rooms.ListAllRooms()
                numRoomsMatchedName += 1

                '
                '    Check room capability first
                '

                If (rooms.roomHasNeededCapabilities(room, desiredCapabilities, matchAllCapabilities)) Then

                    If ((minroomsize < 1) OrElse (rooms.roomSize(room, defaultRoomSize) >= minroomsize)) Then

                        numRoomsMatchedCapabilities += 1
                        findFreeTimeSingleRoom(room.Trim, duration, classCount, _
                                                starttime, endtime, days, allPossibilities)
                    End If
                End If

            Next
        Else
            selectedrooms = splitStringToPatterns(roombox)

            '
            '   Treat each as a pattern and find matching rooms
            '
            For Each room In rooms.ListAllRooms()

                If (stringMatchesPatterns(room, selectedrooms)) Then
                    numRoomsMatchedName += 1

                    '
                    '    Check room capability first
                    '

                    If (rooms.roomHasNeededCapabilities(room, desiredCapabilities, matchAllCapabilities)) Then

                        If ((minroomsize < 1) OrElse (rooms.roomSize(room, defaultRoomSize) >= minroomsize)) Then

                            numRoomsMatchedCapabilities += 1
                            findFreeTimeSingleRoom(room.Trim, duration, classCount, _
                                                    starttime, endtime, days, allPossibilities)
                        End If
                    End If
                End If

            Next
        End If

        '
        '   See if there was a problem
        '
        If (numRoomsMatchedName = 0) Then
            errorString = "No rooms matched the name """ & origRoomBox & """."
            isError = True
        ElseIf (numRoomsMatchedCapabilities = 0) Then
            errorString = "No rooms had the required capabilities."
            isError = True
        End If

        Return isError
    End Function

    Public Function findFreeTime(room As String, durationstr As String, _
                                 classCount As Integer, _
                                 starttimestr As String, endtimestr As String, _
                                 daysstr As String, _
                                 ByRef capabilitiesHash As HashSet(Of String), _
                                 ByVal matchAllCapabilities As Boolean, _
                                 ByVal minSeats As Integer, ByVal defaultRoomSize As Integer, _
                                 ByRef allPossibilities As List(Of roomReportEntry), _
                                 ByRef errorString As String) As Boolean

        Dim starttime As Integer
        Dim endtime As Integer
        Dim duration As Integer = timeToInt(durationstr)
        Dim days As Integer
        Dim iserror As Boolean = False

        errorString = ""

        '
        '   Blank times = take the opening and closing of the school
        '
        If (starttimestr.Trim = "") Then
            starttime = earliestStartOfClass
        Else
            starttime = timeToInt(starttimestr)
        End If

        If (endtimestr.Trim = "") Then
            endtime = latestEndOfClass
        Else
            endtime = timeToInt(endtimestr)
        End If


        '
        '   Blank days = don't care which day (take all days the school is open)
        '
        If (daysstr.Trim = "") Then
            days = daysToBitmask("MTWRF")          ' All days the school is open
        Else
            days = daysToBitmask(daysstr)
        End If


        If (starttime = -1) Then
            errorString = errorString & "Please enter a valid start time" & vbCrLf
            iserror = True
        End If

        If (endtime = -1) Then
            errorString = errorString & "Please enter a valid end time" & vbCrLf
            iserror = True
        End If

        If (duration <= 0) Then
            errorString = errorString & "Please enter a valid class duration" & vbCrLf
            iserror = True
        End If

        If (days = 0) Then
            errorString = errorString & "Please select at least one day" & vbCrLf
            iserror = True
        End If

        If (Not iserror) Then
            iserror = findFreeTimeHlp(room, duration, classCount, _
                            starttime, endtime, days, capabilitiesHash, matchAllCapabilities, _
                            minSeats, defaultRoomSize, _
                            allPossibilities, errorString)
        End If

        Return Not iserror
    End Function

    '
    '   Given a course name and a string representing multiple courses (with | between them),
    '   see if the one course is in the match
    '
    Private Function courseMatches(ByVal oneCourse As String, ByVal possibleCourses As String) As Boolean
        Dim courses As String()
        Dim matched As Boolean = False   ' Assume no match

        ' Remove all spaces in the single course for the matching
        oneCourse = oneCourse.Replace(" ", "").ToLower

        possibleCourses = possibleCourses.Replace(" ", "").ToLower

        courses = splitStringToPatterns(possibleCourses, True)

        matched = stringMatchesPatterns(oneCourse, courses)

        Return matched
    End Function



    '
    '   classDoesntOverlapAnyClass(oneclass,classes())
    '
    '   Given a list of (indexes to) classes, determine if an new course could
    '   also be taken
    '
    '
    Function classDoesntOverlapAnyClass(ByVal oneclass As Integer, ByRef classes As List(Of Integer)) As Boolean
        Dim result As Boolean = True ' Assume that the classes do not overlap works
        Dim classi As Integer

        For i As Integer = 0 To classes.Count - 1
            classi = classes(i)

            '
            '  Do the two sections overlap?  (and are not the same)
            '
            If ((classi <> oneclass) AndAlso _
                (daysOverlap(allSections(classi).days, _
                                allSections(oneclass).days)) AndAlso _
                (timeOverlap(allSections(classi).starttime, _
                                 allSections(classi).endtime, _
                                 allSections(oneclass).starttime, _
                                 allSections(oneclass).endtime))) Then

                result = False
            End If
        Next

        Return result
    End Function


    '
    '   scheduleWorks(classes())
    '
    '   Given a list of (indexes to) classes, determine if a student could
    '   actually take all of those classes or that they overlap
    '
    '
    Function scheduleWorks(ByRef classes As List(Of Integer)) As Boolean
        Dim result As Boolean = True ' Assume that the schedule works
        Dim classi As Integer
        Dim classj As Integer

        For i As Integer = 0 To classes.Count - 2
            For j As Integer = i + 1 To classes.Count - 1

                classi = classes(i)
                classj = classes(j)

                '
                '  Do the two sections overlap?
                '   (and are different classes?)
                '
                If ((classi <> classj) AndAlso _
                    (daysOverlap(allSections(classi).days, _
                                    allSections(classj).days)) AndAlso _
                    (timeOverlap(allSections(classi).starttime, _
                                     allSections(classi).endtime, _
                                     allSections(classj).starttime, _
                                     allSections(classj).endtime))) Then

                    result = False
                End If


            Next
        Next

        Return result
    End Function

    '
    '   findValidSubSequence
    '
    '
    '       sequenceNum = What sequence are we working on?
    '       currentEntry = Where in the sequence are we trying to make work?
    '       classes      = What other classes do we have to make sure will fit?
    '       criteria     = What special criteria (online only, evenings, etc) are neccessary?
    '
    '   Returns true if a student can take a (sub)list of classes or false if they would
    '   have to be in two different places at the same time, or that a required course
    '   is not present.
    '
    '   Routine is called recursively
    '
    Private Function findValidSubSequence(ByRef listOfCourses As List(Of String), _
                                          ByVal currentEntry As Integer, _
                                          ByRef classes As List(Of Integer), _
                                          ByRef criteria As ScheduleCriteria) As Boolean
        Dim result As Boolean = False   ' Assume that there is no possible sequence that works
        Dim i As Integer = 0
        Dim currentClass As String


        '
        '  Make sure asking for a non-empty sequence
        '
        If ((listOfCourses IsNot Nothing) AndAlso (listOfCourses.Count > 0)) Then

            '
            '  If we are at the end of the possible courses, then by definition
            '  the schedule works - otherwise it needs to be checked
            '
            If (currentEntry >= listOfCourses.Count) Then
                result = True
            Else
                currentClass = listOfCourses(currentEntry)

                '
                '  Did we just get a blank cell?  if so, just skip it
                '
                If (currentClass = "") Then

                    result = findValidSubSequence(listOfCourses, currentEntry + 1, classes, criteria)

                Else
                    '
                    '   Ok.   A non-trivial sequence needs checked.  Start with all of
                    '   the possible courses that match the currentClass and check to
                    '   see if ANY possible schedule matches them
                    '
                    While ((i < numSections()) And (result = False))

                        If (((Not allSections(i).isGhostedSection) Or (My.Settings.allowGhosts)) AndAlso _
                            courseMatches(allSections(i).coursenum, currentClass)) Then
                            If ((criteria Is Nothing) OrElse _
                                criteria.matchesCourseCriteria(allSections(i).room, allSections(i).days, _
                                                               allSections(i).starttime, allSections(i).endtime, _
                                                               allSections(i).sectionIsFull)) Then

                                '
                                '  Thid one is a possible match to our list of courses, so
                                '  add it to our (temporary) list of classes, and see if the
                                '  resulting schedule is (still) viable
                                '
                                classes.Add(i)

                                If (scheduleWorks(classes)) Then
                                    '
                                    '  Recursively check to see if this is a viable choice
                                    '
                                    result = findValidSubSequence(listOfCourses, currentEntry + 1, classes, criteria)
                                End If

                                '
                                '  We are done with it, so remove it to our (temporary) list of classes
                                '
                                '
                                If (Not result) Then
                                    classes.Remove(i)
                                End If
                            End If

                        End If


                        i = i + 1
                    End While

                End If
            End If
        End If

        '
        '  Note: if result = true, then classes() will contain a viable schedule (if we care)
        '
        Return result
    End Function


    Function MergeSequenceLists(ByVal newCourse As Integer, _
                                ByRef allPartialSequences As List(Of List(Of Integer)), _
                                ByRef AllValidSequences As List(Of List(Of Integer))) As Boolean

        Dim result As Boolean = False
        Dim newList As List(Of Integer)

        If (allPartialSequences.Count = 0) Then
            '
            '   No partial list?  If so, then we are the starting point, so
            '   we just add to the list of "all valid sequences"
            '

            '
            ' Create a list with just us
            '
            newList = New List(Of Integer)
            newList.Add(newCourse)

            AllValidSequences.Add(newList)

            result = True   ' Hey! A good sequence
        Else

            '
            '  If the partial list is already started, then all
            '  we can do is use that as the basis
            '


            '
            '  Ok, a potential thing to add to the sequence, but
            '   two things could prevent it
            '
            '   1 - we already used this course for a different requirement
            '   2 - the course occurs concurrently with a different requirement
            '

            For j As Integer = 0 To allPartialSequences.Count - 1

                If ((Not isInSet(newCourse, allPartialSequences(j))) AndAlso _
                    (classDoesntOverlapAnyClass(newCourse, allPartialSequences(j)))) Then

                    '
                    '  Copy the list and add the new item
                    '
                    newList = New List(Of Integer)
                    newList.AddRange(allPartialSequences(j))
                    newList.Add(newCourse)

                    AllValidSequences.Add(newList)

                    result = True   ' Hey! A good sequence
                End If

            Next j

        End If

        Return result
    End Function

    '
    '   findValidSubSequence
    '
    '
    '       sequenceNum = What sequence are we working on?
    '       currentEntry = Where in the sequence are we trying to make work?
    '       classes      = What other classes do we have to make sure will fit?
    '       upd          = Callback to update the progress (not carried forward during recursion)
    '
    '   Returns true if a student can take a (sub)list of classes or false if they would
    '   have to be in two different places at the same time, or that a required course
    '   is not present.
    '
    '   Routine is called recursively
    '
    Private Function getAllValidSubSequences(ByRef listofcourses As List(Of String), _
                                          ByVal currentEntry As Integer, _
                                          ByRef AllValidSequences As List(Of List(Of Integer)), _
                                          ByRef criteria As ScheduleCriteria, _
                                          Optional ByVal upd As Action(Of Integer) = Nothing) As Boolean
        Dim result As Boolean = False   ' Assume that there is no possible sequence that works
        Dim currentClass As String
        Dim allPartialSequences As New List(Of List(Of Integer))

        If ((listofcourses Is Nothing) OrElse (listofcourses.Count = 0)) Then
            '
            '  Protect against sequence # being invalid
            '
            result = False


        ElseIf (currentEntry >= listofcourses.Count) Then
            '
            '  If we are at the end of the possible courses, then by definition
            '  the schedule works - otherwise it needs to be checked
            '
            result = True
        Else
            currentClass = listofcourses(currentEntry)

            '
            '  Did we just get a blank cell?  if so, just skip it
            '
            If (currentClass = "") Then

                result = getAllValidSubSequences(listofcourses, currentEntry + 1, _
                                                 AllValidSequences, criteria)

            Else

                '
                '  See if there is a partial subsequence viable
                '   (go tail recursion!)
                '
                result = getAllValidSubSequences(listofcourses, currentEntry + 1, _
                                                 allPartialSequences, criteria)

                '
                '  If no valid subsequence, then no valid full sequence - but if there
                '  is a valid subsequence, we need to add the new class and see if it still works
                '
                If (result) Then

                    '
                    '   Ok.   A non-trivial sequence needs checked.  Start with all of
                    '   the possible courses that match the currentClass and check to
                    '   see if ANY possible schedule matches them
                    '

                    result = False      ' Assume we are going to break things here...

                    For i As Integer = 0 To numSections() - 1
                        '
                        '  Update the calling routine (if it asks to be...)
                        '
                        If (upd IsNot Nothing) Then
                            upd(10 + (40 * i / numSections()))
                        End If
                        '
                        '  Does this section match the one in the sequence?
                        '
                        If (((Not allSections(i).isGhostedSection) Or (My.Settings.allowGhosts)) AndAlso _
                            (courseMatches(allSections(i).coursenum, currentClass)) AndAlso _
                             (criteria.matchesCourseCriteria(allSections(i).room, _
                                                       allSections(i).days, _
                                                       allSections(i).starttime, _
                                                       allSections(i).endtime, _
                                                       allSections(i).sectionIsFull))) Then

                            result = result Or MergeSequenceLists(i, allPartialSequences, AllValidSequences)

                        End If

                    Next i

                End If
            End If


        End If


        '
        '  Note: if result = true, then classes() will contain a viable schedule (if we care)
        '
        Return result
    End Function


    Private Function neededStateToString(ByVal state As neededState) As String
        Dim result As String = "<unknown type>"

        Select Case state
            Case neededState.isNotNeeded
                result = "Not needed"
            Case neededState.isOptional
                result = "Optional"
            Case neededState.isRequired
                result = "Required"
        End Select

        Return result
    End Function



    Private Function checkOneSequence(ByVal id As Integer, ByVal myState As neededState) As String
        Dim result As String = ""
        Dim classes As New List(Of Integer)

        If (findValidSubSequence(allSequences(id).courses, 0, classes, allSequences(id).critera) = False) Then
            result = neededStateToString(myState) & _
                     " sequence """ & _
                     allSequences(id).name & _
                     """ has no viable schedule."
        End If

        Return result
    End Function

    Private Sub pruneMaxDays(ByRef r As List(Of List(Of Integer)), maxDays As Integer)
        Dim dayMask As Integer
        Dim i As Integer

        i = 0
        While (i < r.Count)
            dayMask = 0
            For j As Integer = 0 To r(i).Count - 1
                dayMask = dayMask Or allSections(r(i)(j)).days
            Next j

            '
            '   See if this entry is too long
            '
            If (countBits(dayMask) > maxDays) Then
                r.RemoveAt(i)
            Else
                i = i + 1
            End If

        End While
    End Sub


    '
    '   getAllSchedulesForOneSequence
    '
    '   Mostly, a helper function for recursive call to getAllValidSubSequences
    '
    '
    Public Function getAllSchedulesForOneSequence(ByRef listOfCourses As List(Of String), _
                                                  ByRef criteria As ScheduleCriteria, _
                                                  Optional ByVal upd As Action(Of Integer) = Nothing) As List(Of List(Of Integer))
        Dim result As New List(Of List(Of Integer))

        If (upd IsNot Nothing) Then
            upd(5)
        End If

        getAllValidSubSequences(listOfCourses, 0, result, criteria, upd)

        If (upd IsNot Nothing) Then
            upd(95)
        End If

        pruneMaxDays(result, criteria.maxDays)

        Return result
    End Function


    '
    '
    '
    Private Function semesterNeedsChecked(ByVal thisSemester As String, _
                                          ByVal requestedSemesters As String()) As neededState
        Dim result As neededState = neededState.isNotNeeded
        Dim isOptional As Boolean = False
        Dim requestedSemester As String

        '
        '  If the semester column is blank, then assume every semester it is required
        '
        If (thisSemester = "") Then

            result = neededState.isRequired

            '
            '  Any semesters at all given?
            '
        ElseIf (requestedSemesters.Length > 0) Then

            thisSemester = "/" & thisSemester & "/"

            For Each requestedSemester In requestedSemesters
                requestedSemester = requestedSemester.Trim


                If (requestedSemester <> "") Then
                    '
                    '  Required takes precidence, so force it (but keep track of the optionals)
                    '
                    If (thisSemester.Contains("/" & requestedSemester & "/")) Then
                        result = neededState.isRequired
                    ElseIf (thisSemester.Contains("/" & requestedSemester & "?/")) Then
                        isOptional = True
                    End If
                End If

            Next

            If ((isOptional) And (result = neededState.isNotNeeded)) Then
                result = neededState.isOptional
            End If


        End If

        Return result
    End Function


    Public Function findMissingSequences(Optional ByVal semesters As String = "") As List(Of scheduleMessage)
        Dim result As New List(Of scheduleMessage)
        Dim thisSeqState As neededState
        Dim mesg As scheduleMessage
        Dim s As String
        Dim mesgCount As Integer = 0
        Dim checkCount As Integer = 0
        Dim semesterList As String()

        semesterList = splitStringToPatterns(semesters.ToLower)

        For i As Integer = 0 To allSequences.Count - 1
            '
            '   See if we need to check this sequence or not
            '

            thisSeqState = semesterNeedsChecked(allSequences(i).semesters.ToLower, semesterList)

            '
            '  Ok, it's necessary  - so check it
            '
            If (thisSeqState = neededState.isRequired) Then
                checkCount = checkCount + 1
                s = checkOneSequence(i, thisSeqState)


                If (s <> "") Then
                    mesgCount = mesgCount + 1
                    mesg = New scheduleMessage

                    mesg.severity = "Warning"
                    mesg.type = "Sequence"
                    mesg.description = s

                    mesg.loc1 = allSequences(i).loc
                    mesg.text1 = allSequences(i).name

                    mesg.loc2 = ""
                    mesg.text2 = ""

                    result.Add(mesg)
                End If


                '
                '  Ok, it's necessary  - so check it
                '
            ElseIf (thisSeqState = neededState.isOptional) Then
                checkCount = checkCount + 1
                s = checkOneSequence(i, thisSeqState)


                If (s <> "") Then
                    mesgCount = mesgCount + 1

                    mesg = New scheduleMessage

                    mesg.severity = "Informational"
                    mesg.type = "Sequence"
                    mesg.description = s

                    mesg.loc1 = allSequences(i).loc
                    mesg.text1 = allSequences(i).name

                    mesg.loc2 = ""
                    mesg.text2 = ""

                    result.Add(mesg)
                End If
            End If
        Next

        If (mesgCount = 0) Then
            mesg = New scheduleMessage

            mesg.type = "Sequence"

            If (checkCount > 0) Then
                mesg.severity = "Normal"
                mesg.description = "No sequence problems detected, checked " & checkCount.ToString & " sequences"
            ElseIf (allSequences.Count > 0) Then
                mesg.severity = "Informational"
                mesg.description = "No sequences matched the desired semesters."
            Else
                mesg.severity = "Informational"
                mesg.description = "Did not find any sequences to check.  Empty sequence page?"
            End If

            mesg.loc1 = ""
            mesg.text1 = ""

            mesg.loc2 = ""
            mesg.text2 = ""

            result.Add(mesg)
        End If

        Return result
    End Function

    '
    '  Colisted classes have (at least) one of the classes listed in the notes
    '   for the other
    '
    Public Function isColistedClass(ByVal i As Integer, ByVal j As Integer) As Boolean
        Dim result As Boolean = False

        If (allSections(i).notes Is Nothing) Then
            result = False ' No note, no co-listing
        ElseIf (allSections(i).notes.ToLower.Contains(allSections(j).coursenum.ToLower.Trim)) Then
            result = True
        ElseIf (allSections(j).notes.ToLower.Contains(allSections(i).coursenum.ToLower.Trim)) Then
            result = True
        End If

        Return result
    End Function


    Public Function getAllSectionsForInstructor(ByVal instr As String) As List(Of oneSection)
        Dim l As New List(Of oneSection)
        Dim i As Integer

        instr = instr.Trim.ToLower

        For i = 0 To allSections.Count - 1
            If (allSections(i).instructor.ToLower = instr) Then
                l.Add(allSections(i))
            End If
        Next

        Return l
    End Function
End Class
