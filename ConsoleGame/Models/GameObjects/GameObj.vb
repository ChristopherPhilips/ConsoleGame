Public Class GameObj
    Public Property priority As Integer
    Public Property didChange As Boolean = True
    Public Property location As (Integer, Integer)
    Public Property sprite As List(Of String) 'raw art as list(str)
    Public Property colourmap As List(Of String) = New List(Of String) From {}
    Public Property spritechars As Array 'populated by render()
    Public Property isCollidable = False
    Public Property occupying As Array 'array of tiles occupied, boolean(x,y)
    Public Property parentWindow As Window

    Public Sub New(priority As Integer, location As (Integer, Integer), parentWindow As Window, sprite As List(Of String))
        Me.location = location
        Me.sprite = sprite
        Me.parentWindow = parentWindow
        Me.priority = priority

        Me.spritechars = New CharObj(sprite.Count - 1, sprite(0).Length - 1) {}
        Me.occupying = New Boolean(sprite.Count - 1, sprite(0).Length - 1) {}

        render()
    End Sub

    Public Overridable Sub move(deltaxy As (Integer, Integer))
        parentWindow.move(Me, deltaxy)
    End Sub

    Public Sub render() 'takes the sprite and turns it into charobjs

        For i = 0 To sprite.Count - 1 Step 1 'row loop
            For j = 0 To sprite(0).Length - 1 Step 1 'length loop

                spritechars(i, j) = New CharObj(sprite(i)(j), "", Me)

            Next j
        Next i

    End Sub
End Class
