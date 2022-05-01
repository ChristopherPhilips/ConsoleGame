Public Class Crewmate
    Inherits GameObj



    Public Sub New(priority As Integer, location As (Integer, Integer), sprite As List(Of String))
        MyBase.New(priority, location, sprite)
    End Sub
    Public Sub New(priority As Integer, location As (Integer, Integer), sprite As List(Of String), colourmap As List(Of String))
        MyBase.New(priority, location, sprite, colourmap)
    End Sub

    Public Overloads Sub move(deltaxy As (Integer, Integer))
        remove()

        Dim oldx = location.Item1
        Dim newx = oldx + deltaxy.Item1

        Dim oldy = location.Item2
        Dim newy = oldy + deltaxy.Item2



        Me.location = (newx, newy)

        Me.didChange = True
    End Sub

    Public Sub isCollide()

    End Sub

End Class

