Imports Spectre.Console
Public Class Window

    Private Property locationObjAry As LocationObj(,) = New LocationObj(2, 2) {}
    Private Property screenHeight As Integer
    Private Property screenWidth As Integer


    Private Property gameObjects As List(Of GameObj) = New List(Of GameObj) From {}

    Public Sub New(width As Integer, height As Integer)
        Me.screenWidth = width
        Me.screenHeight = height
        Dim vbMsgBoxHasdelp(5, 5) As LocationObj

        Me.locationObjAry = New LocationObj(height, width) {}


        InitlocationObjAry()

    End Sub

    Public Sub AddCharObj(charobj As CharObj, coordx As Integer, coordy As Integer) 'puts charobjs into locationobjs
        locationObjAry(coordx, coordy).addChar(charobj)
    End Sub
    Public Sub AddObj(gameobj As GameObj)
        Me.gameObjects.Add(gameobj)
    End Sub

    Public Sub Print(topleftx As Integer, toplefty As Integer) 'writes renderedscreen to terminal

        Dim screen = RenderScreen()

        For i = 0 To screen.Count - 1 Step 1
            Console.SetCursorPosition(topleftx, toplefty + i) 'this is what gets changed when we want to move the game's (0,0) points
            AnsiConsole.Markup(screen(i))
        Next i
    End Sub

    Public Sub updateGameObj()
        For Each gameobject In Me.gameObjects 'updates the sprites (in locationObj) for gameObjects reporting a change
            If gameobject.didChange = True Then

                'call addcharobj to add charObj to locationObj
                Dim ourZeroX = gameobject.location.Item1
                Dim ourZeroY = gameobject.location.Item2

                Dim spriteHeight = gameobject.spritechars.GetUpperBound(0)
                Dim spriteWidth = gameobject.spritechars.GetUpperBound(1)


                For i = 0 To spriteHeight Step 1 'rowloop
                    For j = 0 To spriteWidth Step 1 'length loop

                        If gameobject.spritechars(i, j).CellChar = "Ý"c Then 'do nothing if the char in a slot is &

                        ElseIf gameobject.spritechars(i, j).CellChar = "ý"c Then 'this reserved for if we want squares to be part of the gameObj but not shown

                        Else

                            AddCharObj(gameobject.spritechars(i, j), ourZeroX + i, ourZeroY + j)

                            'occupying(i, j) = locationObjAry(ourZeroX + i, ourZeroY + j) 'todo: update occupying


                        End If
                    Next j
                Next i
                gameobject.didChange = False
            End If
        Next
    End Sub
    Private Sub InitlocationObjAry() 'used to fill the locationObjAry with locationobj

        'should iterate over the rows
        For i = 0 To screenHeight - 1 Step 1
            'should put locationobjs in the row
            For j = 0 To screenWidth - 1 Step 1
                Me.locationObjAry(i, j) = New LocationObj((i, j))
            Next j
        Next i

    End Sub
    Private Function RenderScreen() As List(Of String) 'goes through location objs and grabs their highest prio char

        Dim array As LocationObj(,) = Me.locationObjAry
        Dim renderedscreen As List(Of String) = New List(Of String)

        'should iterate over the 60 rows
        For i = 0 To array.GetUpperBound(0) - 1 Step 1
            Dim currow As String = ""
            'should iterate over the 140 locationobjs in the row
            For j = 0 To array.GetUpperBound(1) - 1 Step 1
                currow += (array(i, j).toPrint)
            Next j
            renderedscreen.Add(currow)
        Next i
        Return renderedscreen

    End Function


End Class
