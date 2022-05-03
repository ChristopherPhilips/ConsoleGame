Public Class LocationObj
    Public Property toPrint As String = "$"
    Public Property HighestPriorityChar As CharObj
    Public Property competingChars As List(Of CharObj) = New List(Of CharObj) 'todo: make this work lol
    Public Property location As (Integer, Integer)

    Private Property emptycharj = New CharObj()
    Public Sub New(location As (Integer, Integer))
        Me.location = (location.Item1, location.Item2)

        emptycharj.priority = 0
        emptycharj.cellChar = " "
        competingChars.Add(emptycharj)
        updatetoPrint()
    End Sub
    Public Sub addChar(newchar As CharObj, priority As Integer)

        competingChars.Add(newchar)

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

        updatetoPrint()

    End Sub
    Private Sub updatetoPrint() 'todo: change how to decide who has prio
        Dim highestprio = -10000
        For Each thing In competingChars
            If highestprio < thing.priority Then
                HighestPriorityChar = thing
                toPrint = HighestPriorityChar.CellChar
            End If
        Next
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
