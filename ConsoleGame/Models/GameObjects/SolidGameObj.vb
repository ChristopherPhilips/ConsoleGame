Public Class SolidGameObj
    Inherits GameObj


    Public Sub New(priority As Integer, location As (Integer, Integer), parentWindow As Window, sprite As List(Of String))
        MyBase.New(priority, location, parentWindow, sprite)
        Me.isCollidable = True
    End Sub


    Public Overloads Sub render()

        If colourmap.Count > 0 Then
            Dim colourmap2 = colourmap
        Else
            Dim colourmap2 = ""
        End If

        For i = 0 To sprite.Count - 1 Step 1 'row loop
            For j = 0 To sprite(0).Length - 1 Step 1 'length loop

                If colourmap.Count > 0 Then 'will give colour if colour present
                    spritechars(i, j) = New SolidCharObj(sprite(i)(j), colourmap(i)(j), Me)
                Else
                    spritechars(i, j) = New SolidCharObj(sprite(i)(j), "", Me)
                End If

            Next j
        Next i

    End Sub


End Class
