Option Compare Text         ' Allow LIKE to match "aaa" to "AAA"

Module StringRoutines

    '
    '   isSameInstructor(inst1, inst2) as Boolean
    '
    '  See if two instructors are the same person
    '       (ignoring "TBA" et. al.)
    '
    '
    Public Function isSameIgnoreTBA(ByVal inst1 As String, ByVal inst2 As String) As Boolean
        Dim result As Boolean = False

        inst1 = inst1.ToUpper
        inst2 = inst2.ToUpper


        '
        '  TODO: Don't hardcode "TBA" - use a list provided by the person
        '
        If ((inst1 = inst2) And (Not isTBA(inst1)) And (Not isTBA(inst2))) Then
            result = True
        End If

        Return result
    End Function



    '
    '   splitStringToPatterns
    '
    '   Given a string with seperators (comma, vertical bar, forward slash, and/or semicolor)
    '     break it up into pieces
    '
    Public Function splitStringToPatterns(ByVal inputString As String, _
                                           Optional ByVal appendWildcard As Boolean = False) As String()
        Dim result As String()
        Dim i As Integer

        inputString = inputString.Replace(","c, "|"c)
        inputString = inputString.Replace(";"c, "|"c)
        inputString = inputString.Replace("/"c, "|"c)

        result = inputString.Split("|"c)

        '
        '  Trim all of the resulting components
        '
        For i = 0 To result.Count - 1
            result(i) = result(i).Trim

            If ((appendWildcard) AndAlso (result(i).Count > 0)) Then
                result(i) &= "*"
            End If
        Next

        Return result
    End Function

    Public Function stringMatchesPatterns(ByVal str As String, ByRef patterns As String()) As Boolean
        Dim matchNegative As Boolean = False
        Dim matchPositive As Boolean = False
        Dim pattern As String
        Dim i As Integer = 0
        Dim maxCount As Integer = patterns.Count

        '
        '  Go through the list
        '
        '  Optimization: No need to go further when matching a negative
        '
        While ((i < maxCount) And (Not matchNegative))
            pattern = patterns(i)


            If (pattern.Count = 0) Then
                '
                '  Do nothing - ignore it
                '
            ElseIf (pattern.Substring(0, 1) = "!") Then
                pattern = pattern.Substring(1)
                '
                '  Did it match?
                '
                If (str Like pattern) Then
                    matchNegative = True
                End If
            Else
                '
                '  Did it match?
                '
                '   Optimization: if it matched one - no need to check any more
                '
                If ((Not matchPositive) AndAlso (str Like pattern)) Then
                    matchPositive = True
                End If
            End If

            i = i + 1
        End While


        '
        '  If you matched a negative - don't use it
        '  Otherwise, matching a positive is fine
        '
        Return matchPositive And (Not matchNegative)
    End Function


    '
    '   StringMatchesPatternString - Helper function that combines two functions together:
    '
    '           stringMatchesPatterns & splitStringToPatterns
    '       
    Public Function StringMatchesPatternString(ByVal str As String, _
                                               ByVal patternString As String, _
                                               Optional ByVal appendWildcard As Boolean = False)

        Return stringMatchesPatterns(str, splitStringToPatterns(patternString, appendWildcard))
    End Function

    Public Function stringToTokens(ByVal s As String, _
                                   Optional seperator As Char = ","c, _
                                   Optional keepEmptyTokens As Boolean = False) As List(Of String)
        Dim lOfS As New List(Of String)
        Dim parenLevel As Integer = 0
        Dim newStr As String = ""
        Dim ch As Char

        While (s.Length > 0)
            '
            '  Eat the first character
            '
            ch = s.Substring(0, 1)
            s = s.Substring(1)

            If (Char.IsWhiteSpace(ch)) Then
                '
                '  Ignore leading whitespace
                '
                If (s <> "") Then newStr &= ch

            ElseIf (ch = "\"c) Then
                '
                '   Mimic C's backslash for literal next char
                '
                '   TODO:  Handle the special cases (TAB, NL, etc)
                '
                '
                '  Consume the next character
                '
                If (s.Length > 0) Then
                    ch = s.Substring(0, 1)
                    s = s.Substring(1)

                    newStr = newStr & ch
                End If


            ElseIf (ch = seperator) Then

                '
                '  is this a seperator of tokens
                '
                If ((newStr <> "") Or (keepEmptyTokens)) Then
                    lOfS.Add(newStr.TrimEnd)
                End If

                newStr = ""

            Else
                '
                ' Add it (we'll remove the trailing whitespace later)
                '
                newStr = newStr & ch
            End If

        End While

        '
        '  Did we have something left?  If so, then add it?
        '
        If (newStr <> "") Then
            lOfS.Add(newStr.TrimEnd)
        End If

        Return lOfS
    End Function

    Public Function keyvalue(ByVal s As String, ByRef keyword As String, ByRef value As String) As Boolean
        Dim isPair As Boolean = False

        If (s.Contains("=")) Then
            isPair = True

            keyword = s.Substring(0, s.IndexOf("=")).Trim
            value = s.Substring(s.IndexOf("=") + 1).Trim

        End If

        Return isPair
    End Function

    '
    '  TBA is matched if the string is "TBA", "tba", or starts with "TBA<space>"
    '
    '
    '  TODO: Don't hardcode "TBA" - use a list provided by the person
    '
    Public Function isTBA(ByVal s As String) As Boolean
        Dim result As Boolean

        s = s.Trim.ToUpper

        result = ((s = "") OrElse (s = "TBA"))

        If ((Not result) And (s.Length >= 4)) Then
            result = (s.Substring(0, 4) = "TBA ")
        End If

        Return result
    End Function
End Module
