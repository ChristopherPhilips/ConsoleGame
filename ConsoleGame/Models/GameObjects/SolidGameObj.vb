Public Class SolidGameObj
    Inherits GameObj


    Public Sub New(priority As Integer, location As (Integer, Integer), parentWindow As Window, sprite As List(Of String))
        MyBase.New(priority, location, parentWindow, sprite)
        Me.isCollidable = True
    End Sub


    Public Overloads Sub render()

        For i = 0 To sprite.Count - 1 Step 1 'row loop
            For j = 0 To sprite(0).Length - 1 Step 1 'length loop

                spritechars(i, j) = New SolidCharObj(sprite(i)(j), Me)

            Next j
        Next i

    End Sub


End Class
