Public Class Crewmate
    Inherits GameObj


    Public Sub New(priority As Integer, location As (Integer, Integer), sprite As List(Of String))
        MyBase.New(priority, location, sprite)
    End Sub
    Public Sub New(priority As Integer, location As (Integer, Integer), sprite As List(Of String), colourmap As List(Of String))
        MyBase.New(priority, location, sprite, colourmap)
    End Sub

    Public Overrides Sub move(deltaxy As (Integer, Integer))
        Me.remove()

        Dim oldx = location.Item1
        Dim newx = oldx + deltaxy.Item1

        Dim oldy = location.Item2
        Dim newy = oldy + deltaxy.Item2

        Dim potentialOccupying = Me.lookAhead(deltaxy)

        'check for not allowed movement at our new potential location
        For Each locationobj As LocationObj In potentialOccupying
            For Each charobj As CharObj In locationobj.otherObjects(Me)
                If charobj.notPassable Then
                    Me.location = (oldx, oldy)
                    GoTo end_of_for 'used to exit nested for when any of our potential spaces is an invalid move
                Else
                    Me.location = (newx, newy)
                End If
            Next
        Next
end_of_for:

        Me.didChange = True
    End Sub

    Public Overloads Function toString() As String
        Dim standingon = ""
        For Each locationobj As LocationObj In Me.occupying
            For Each charobj As CharObj In locationobj.otherObjects(Me)
                standingon += $":<{charobj.notPassable.ToString},{charobj.CellChar}>"
            Next
        Next
        Return $"<{location.Item1},{location.Item2}|Standing on{standingon}>"
    End Function

End Class

