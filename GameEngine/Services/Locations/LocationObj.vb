Public Class LocationObj
    Public Property toPrint As String = "$"
    Public Property competingChars As List(Of CharObj) = New List(Of CharObj)
    Public Sub New()
        competingChars.Add(New CharObj("#", 0, "N"c))
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
        For Each charObj In competingChars
            If highestprio < charObj.priority Then
                toPrint = charObj.CellChar
            End If
        Next
    End Sub

    Public Function getCharObjs(parentGameObj As GameObj) As List(Of CharObj) 'used to find out what is on the square
        Dim CharObjects = New List(Of CharObj)
        For Each obj In competingChars
            If obj.CharObjType = "C"c Then
                Dim setopplase = "stop"
            End If
            If ReferenceEquals(obj.parentGameObj, parentGameObj) = False Then
                CharObjects.Add(obj)
            End If
        Next
        Return CharObjects
    End Function

End Class
