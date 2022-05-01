Public Class GameObj
    Public Property priority As Integer
    Public Property didChange As Boolean = True
    Public Property location As (Integer, Integer)
    Public Property sprite As List(Of String) 'raw art as list(str)
    Public Property colourmap As List(Of String) = New List(Of String) From {}
    Public Property spritechars As Array
    Public Property isCollidable = False
    Public Property occupying As Array 'array of tiles occupied, locationObj(x,y)

    Public Sub New(priority As Integer, location As (Integer, Integer), sprite As List(Of String))
        Me.location = location
        Me.sprite = sprite
        Me.priority = priority

        Me.spritechars = New CharObj(sprite.Count, sprite(0).Length) {}
        Me.occupying = New LocationObj(sprite.Count, sprite(0).Length) {}
        render()
    End Sub
    Public Sub New(priority As Integer, location As (Integer, Integer), sprite As List(Of String), colourmap As List(Of String))
        Me.location = location
        Me.sprite = sprite
        Me.priority = priority
        Me.colourmap = colourmap

        Me.spritechars = New CharObj(sprite.Count, sprite(0).Length) {}
        Me.occupying = New LocationObj(sprite.Count, sprite(0).Length) {}
        render()
    End Sub
    Public Sub move(deltaxy As (Integer, Integer))
        remove()

        Dim oldx = location.Item1
        Dim newx = oldx + deltaxy.Item1

        Dim oldy = location.Item2
        Dim newy = oldy + deltaxy.Item2

        Me.location = (newx, newy)

        Me.didChange = True

    End Sub
    Public Sub remove()
        Dim ourZeroX = location.Item1
        Dim ourZeroY = location.Item2

        For Each locationobj As LocationObj In occupying
            If locationobj IsNot Nothing Then
                locationobj.removeChar(Me)
            End If
        Next

        ' For i = 0 To spritechars.GetUpperBound(0) - 1 Step 1 'rowloop
        '     For j = 0 To spritechars.GetUpperBound(1) - 1 Step 1 'length loop
        '         locationObjAry(ourZeroX + i, ourZeroY + j).removeChar(Me)
        '     Next j
        ' Next i
    End Sub
    Public Sub write() 'adds chars to the locationObj they need to be added to

        Dim ourZeroX = location.Item1
        Dim ourZeroY = location.Item2

        For i = 0 To spritechars.GetUpperBound(0) - 1 Step 1 'rowloop
            For j = 0 To spritechars.GetUpperBound(1) - 1 Step 1 'length loop
                If spritechars(i, j).CellChar = "&"c Then
                    'do nothing if the char in a slot is &
                ElseIf spritechars(i, j).CellChar = "ý"c Then
                    'this reserved for if we want squares to be part of the gameObj but not rendered as a char
                    locationObjAry(ourZeroX + i, ourZeroY + j).addChar(spritechars(i, j))
                    occupying(ourZeroX + i, ourZeroY + j) = locationObjAry(ourZeroX + i, ourZeroY + j)
                Else
                    locationObjAry(ourZeroX + i, ourZeroY + j).addChar(spritechars(i, j))
                    occupying(i, j) = locationObjAry(ourZeroX + i, ourZeroY + j)
                End If

            Next j
        Next i

    End Sub
    Public Sub render()
        'assumes every line is same length????? needs #of lines + length of longest line to find the 0,0 point
        If colourmap.Count > 0 Then
            Dim colourmap2 = colourmap
        Else
            Dim colourmap2 = ""
        End If

        For i = 0 To sprite.Count - 1 Step 1 'row loop
            For j = 0 To sprite(0).Length - 1 Step 1 'length loop

                If colourmap.Count > 0 Then 'will read colourmap
                    spritechars(i, j) = New CharObj(sprite(i)(j), colourmap(i)(j), Me)
                Else
                    spritechars(i, j) = New CharObj(sprite(i)(j), "", Me)
                End If

            Next j
        Next i

    End Sub
End Class
