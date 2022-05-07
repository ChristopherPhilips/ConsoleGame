Public Class ArrayExtensions

    Public Shared Function TrimArray(rowToRemove As Integer, colToRemove As Integer, originalArr As CharObj(,)) As CharObj(,)
        Dim result As CharObj(,)
        'If rowToRemove <> Nothing And colToRemove <> Nothing Then
        '    result = New CharObj(originalArr.GetUpperBound(0), originalArr.GetUpperBound(1)) {}
        '
        'ElseIf rowToRemove <> Nothing Then
        '    result = New CharObj(originalArr.GetUpperBound(0), originalArr.GetUpperBound(1) + 1) {}
        'Else
        '    result = New CharObj(originalArr.GetUpperBound(0) + 1, originalArr.GetUpperBound(1)) {}
        'End If
        result = New CharObj(originalArr.GetUpperBound(0), originalArr.GetUpperBound(1)) {}


        Dim startingRow = 0
        Dim startingCol = 0
        If rowToRemove = originalArr.GetUpperBound(0) Then
            startingRow = 1
        End If
        If colToRemove = originalArr.GetUpperBound(1) Then
            startingCol = 1
        End If
        Dim j = startingRow
        For i = 0 To originalArr.GetUpperBound(0)

            If i = rowToRemove Then
                Continue For
            End If

            Dim u = startingCol
            For k = 0 To originalArr.GetUpperBound(1)

                If k = colToRemove Then
                    Continue For
                End If

                result(j, u) = originalArr(i, k)
                u += 1
            Next

            j += 1
        Next
        Return result
    End Function

    Public Shared Function TrimArrayOccupying(rowToRemove As Integer, colToRemove As Integer, originalArr As Boolean(,)) As Boolean(,)
        Dim result As Boolean(,)
        'Dim result As Boolean(,) = New Boolean(originalArr.GetUpperBound(0), originalArr.GetUpperBound(1)) {}
        result = New Boolean(originalArr.GetUpperBound(0), originalArr.GetUpperBound(1)) {}


        Dim startingRow = 0
        Dim startingCol = 0
        If rowToRemove = originalArr.GetUpperBound(0) Then
            startingRow = 1
        End If
        If colToRemove = originalArr.GetUpperBound(1) Then
            startingCol = 1
        End If
        Dim j = startingRow
        For i = 0 To originalArr.GetUpperBound(0)

            If i = rowToRemove Then
                Continue For
            End If

            Dim u = startingCol
            For k = 0 To originalArr.GetUpperBound(1)


                If k = colToRemove Then
                    Continue For
                End If

                result(j, u) = originalArr(i, k)
                u += 1
            Next

            j += 1
        Next
        Return result
    End Function


    Public Shared Function TrimArrayOccupying2(rowToRemove As Integer, colToRemove As Integer, originalArr As Boolean(,)) As Boolean(,)
        Dim result As Boolean(,)
        'Dim result As Boolean(,) = New Boolean(originalArr.GetUpperBound(0), originalArr.GetUpperBound(1)) {}
        result = New Boolean(originalArr.GetUpperBound(0), originalArr.GetUpperBound(1)) {}

        Dim j = 0
        For i = 0 To originalArr.GetUpperBound(0)

            If i = rowToRemove Then
                Continue For
            End If

            Dim u = 0
            For k = 0 To originalArr.GetUpperBound(1)

                If k = colToRemove Then
                    Continue For
                End If

                result(j, u) = originalArr(i, k)
                u += 1
            Next

            j += 1
        Next
        Return result
    End Function
End Class
