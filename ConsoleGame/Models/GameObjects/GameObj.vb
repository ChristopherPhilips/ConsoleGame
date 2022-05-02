Public Class GameObj
    Public Property priority As Integer
    Public Property didChange As Boolean = True
    Public Property location As (Integer, Integer)
    Public Property sprite As List(Of String) 'raw art as list(str)
    Public Property colourmap As List(Of String) = New List(Of String) From {}
    Public Property spritechars As Array 'populated by render()
    Public Property isCollidable = False
    Public Property occupying As Array 'array of tiles occupied, locationObj(x,y)

    Private defaultColourmap As List(Of String) = New List(Of String) From {""}
    Public Sub New(priority As Integer, location As (Integer, Integer), sprite As List(Of String))
        Me.location = location
        Me.sprite = sprite
        Me.priority = priority

        Me.spritechars = New CharObj(sprite.Count - 1, sprite(0).Length - 1) {}
        Me.occupying = New LocationObj(sprite.Count - 1, sprite(0).Length - 1) {}
    End Sub
    Public Sub New(priority As Integer, location As (Integer, Integer), sprite As List(Of String), colourmap As List(Of String)) 'todo: combine new methods and implement a default colourmap
        Me.location = location
        Me.sprite = sprite
        Me.priority = priority
        Me.colourmap = colourmap

        Me.spritechars = New CharObj(sprite.Count - 1, sprite(0).Length - 1) {}
        Me.occupying = New LocationObj(sprite.Count - 1, sprite(0).Length - 1) {}
    End Sub
    Public Overridable Sub move(deltaxy As (Integer, Integer))
        remove()

        Dim oldx = location.Item1
        Dim newx = oldx + deltaxy.Item1

        Dim oldy = location.Item2
        Dim newy = oldy + deltaxy.Item2

        Me.location = (newx, newy)

        Me.didChange = True

    End Sub

    Public Function lookAhead(deltaxy As (Integer, Integer)) As List(Of LocationObj)
        Dim returnList As List(Of LocationObj) = New List(Of LocationObj)

        'iterate over my size
        'write a reference to the location objects at those idicies
        Dim ourZeroX = location.Item1 + deltaxy.Item1
        Dim ourZeroY = location.Item2 + deltaxy.Item2

        For i = 0 To spritechars.GetUpperBound(0) Step 1 'rowloop
            For j = 0 To spritechars.GetUpperBound(1) Step 1 'length loop
                returnList.Add(locationObjAry(ourZeroX + i, ourZeroY + j)) 'todo:replace this with reference to parent
            Next j
        Next i

        Return returnList
    End Function




    Public Sub remove()
        Dim ourZeroX = location.Item1
        Dim ourZeroY = location.Item2

        For Each locationobj As LocationObj In occupying
            If locationobj IsNot Nothing Then
                locationobj.removeChar(Me)
            End If
        Next

    End Sub
    Public Sub write() 'adds chars to the locationObj they need to be added to

        Dim ourZeroX = location.Item1
        Dim ourZeroY = location.Item2

        Dim spriteHeight = spritechars.GetUpperBound(0)
        Dim spriteWidth = spritechars.GetUpperBound(1)

        Dim charAndLocation As List(Of (CharObj, Integer, Integer)) = New List(Of (CharObj, Integer, Integer)) From {}

        For i = 0 To spriteHeight Step 1 'rowloop
            For j = 0 To spriteWidth Step 1 'length loop
                If spritechars(i, j).CellChar = "Ý"c Then 'do nothing if the char in a slot is &

                ElseIf spritechars(i, j).CellChar = "ý"c Then 'this reserved for if we want squares to be part of the gameObj but not shown

                Else


                    charAndLocation.Add((spritechars(i, j), ourZeroX + i, ourZeroY + j))


                    'occupying(i, j) = locationObjAry(ourZeroX + i, ourZeroY + j) 'todo: change who handles collision handling?? rn its done in the object


                End If
            Next j
        Next i




    End Sub
    Public Sub render() 'takes the sprite and turns it into charobjs

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
