Option Compare Text

Public Class RoomData

    Private Class oneRoom
        Public maxStudents As Integer
        Public description As String
        Public capabilities As HashSet(Of String)
    End Class

    Private allRoomCapabilities As New Dictionary(Of String, oneRoom)

    Private allRooms As New List(Of String)
    Private allRoomsIsSorted As Boolean = False

    Private capabilities As New List(Of String)
    Private capabilitiesIsSorted As Boolean = False

    Public Function capCount() As Integer
        Return capabilities.Count()
    End Function


    Public Function roomCount() As Integer
        Return allRooms.Count()
    End Function

    Public Function roomCapCount() As Integer
        Return allRoomCapabilities.Count()
    End Function

    Public Function roomExists(ByVal s As String) As Boolean
        Return allRooms.Contains(s)
    End Function

    Public Sub Clear()
        allRoomCapabilities.Clear()
        allRooms.Clear()
        capabilities.Clear()
    End Sub

    Public Function allcapabilities() As List(Of String)
        If (Not capabilitiesIsSorted) Then
            capabilities.Sort()
            capabilitiesIsSorted = True
        End If

        Return capabilities
    End Function

    Public Function roomHasNeededCapabilities(ByVal room As String, _
                               ByRef desiredCapabilities As HashSet(Of String),
                               ByRef matchAllCapabilities As Boolean) As Boolean
        Dim roomOk As Boolean = False
        Dim roomData As oneRoom = Nothing

        If ((desiredCapabilities IsNot Nothing) AndAlso (desiredCapabilities.Count > 0)) Then

            '
            '  If they want some capabilities, by definition, only defined rooms can satisfy them
            ' 
            If (allRoomCapabilities.TryGetValue(room.ToLower, roomData) = True) Then
                '
                '  Is it an all or nothing?  (or is it "any of the above")?
                '
                If (matchAllCapabilities) Then
                    roomOk = desiredCapabilities.IsSubsetOf(roomData.capabilities)
                Else
                    roomOk = desiredCapabilities.Overlaps(roomData.capabilities)
                End If
            End If
        Else
            '
            '  No desired capabilities, then the room is ok
            '
            roomOk = True
        End If


        Return roomOk

    End Function


    Public Function roomSize(ByVal room As String, ByVal defaultRoomSize As Integer)
        Dim roomData As oneRoom = Nothing
        Dim size As Integer = defaultRoomSize

        If (allRoomCapabilities.TryGetValue(room.ToLower, roomData) = True) Then
            size = roomData.maxStudents
        End If

        Return size

    End Function


    Public Function roomToDescr(ByVal r As String) As String
        Dim s As String = ""
        Dim one As oneRoom

        r = r.ToLower

        If (allRoomCapabilities.ContainsKey(r)) Then
            one = allRoomCapabilities(r)

            If (one IsNot Nothing) Then
                s = one.description
            End If
        End If


        Return s
    End Function


    '
    '   ListAllRooms()
    '
    '   Provide a (sorted) list of all rooms mentioned in the spreadsheet
    '
    Public Function ListAllRooms() As String()
        If (Not allRoomsIsSorted) Then

            allRooms.Sort()
            allRoomsIsSorted = True

        End If

        Return allRooms.ToArray()
    End Function



    Public Sub addRoom(ByVal room As String)
        room = room.Trim

        If ((room <> "") AndAlso (Not allRooms.Contains(room))) Then
            allRooms.Add(room)
            allRoomsIsSorted = False
        End If
    End Sub

    Public Function addRoomWithCapabilties(ByVal name As String, _
                                      ByVal maxstudents As Integer, _
                                      ByVal description As String, _
                                      ByRef hash As HashSet(Of String)) As Boolean
        Dim cap As String
        Dim one As New oneRoom
        Dim result As Boolean = False
        name = name.Trim()

        If ((hash IsNot Nothing) And (name <> "")) Then
            For Each cap In hash
                '
                '  Add it to the master list if necessary
                '
                If (Not capabilities.Contains(cap)) Then
                    capabilities.Add(cap)
                    capabilitiesIsSorted = False
                End If
            Next

            one.maxStudents = maxstudents
            one.description = description
            one.capabilities = hash

            allRoomCapabilities.Add(name.ToLower, one)

            '
            ' Make sure it is in the master list too
            '
            addRoom(name)

            result = True
        End If

        Return result
    End Function
End Class
