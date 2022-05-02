Public Class LocationObj
    Public Property toPrint As String = " "
    Public Property HighestPriorityChar As CharObj
    Private Property competingChars As List(Of CharObj) = New List(Of CharObj) 'todo: make this work lol
    Public Property location As (Integer, Integer)

    Dim emptycharj = New CharObj(New GameObj(-50, (0, 0), New List(Of String) From {" "}))
    Public Sub New(location As (Integer, Integer))
        Me.location = (location.Item1, location.Item2)
        HighestPriorityChar = emptycharj
    End Sub
    Public Sub addChar(newchar As CharObj, Optional priority As Integer = Nothing)
        If priority <> Nothing Then
            Dim newchar2 = newchar
            newchar2.priority = -10 'this doesnt carry back right?
            competingChars.Add(newchar2)
        Else
            competingChars.Add(newchar)
        End If

        updatetoPrint()
    End Sub

    Public Sub removeChar(parentGameObj As GameObj)
        'removes old chars by checking if it belongs to parentGameObj
        For Each obj In competingChars
            If ReferenceEquals(obj.parentGameObj, parentGameObj) Then
                competingChars.Remove(obj)
                Exit For
            End If
        Next

        HighestPriorityChar = emptycharj

        updatetoPrint()

    End Sub
    Private Sub updatetoPrint() 'todo: change how to decide who has prio
        Dim highestprio = HighestPriorityChar.priority
        For Each thing In competingChars
            If highestprio < thing.priority Then
                HighestPriorityChar = thing
                toPrint = HighestPriorityChar.CellChar
            End If
        Next
        If competingChars.Count = 0 Then
            'HighestPriorityChar = " "
            toPrint = " "
        End If
    End Sub

    Public Function otherObjects(parentGameObj As GameObj) As List(Of CharObj) 'used to find out what is on the square
        Dim notMine = competingChars
        For Each obj In competingChars
            If ReferenceEquals(obj.parentGameObj, parentGameObj) Then
                notMine.Remove(obj)
                Exit For
            End If
        Next
        Return notMine
    End Function

    Public Overloads Function toString() As String
        Return $"<{location.Item1},{location.Item2}|Contains:""{toPrint}""c>"
    End Function

End Class
