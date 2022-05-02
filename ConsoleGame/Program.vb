Imports System
Imports Spectre.Console
Module Program
    Dim gameWidth As Integer = 140
    Dim gameHeight As Integer = 60


    '60rows,140column array to be filled with location objects
    Public locationObjAry(60, 140) As LocationObj 'public so gameobjs can read it

    'whats getting printed, gets rewritten every frame
    Dim renderedscreen As List(Of String)

    Public KeyboardActions As Queue(Of GameEnums.KeyboardActions) = New Queue(Of GameEnums.KeyboardActions)


    Dim background As GameObj = New GameObj(1, (0, 0), backgroundsprite)

    'used to update sprites
    Public gameObjects As List(Of GameObj) = New List(Of GameObj) From {background}
    Sub Main(args As String())
        'starting a new thread to listen for keyboard inputs
        Dim userinputthread As Threading.Thread = New Threading.Thread(New Threading.ThreadStart(AddressOf keyboardinputs.ReadInput))
        userinputthread.Start()
        Dim result As GameEnums.KeyboardActions = Nothing 'initializing result for idk


        'setting window settings
        'Console.SetBufferSize(140, 60) 'todo: remove
        'Console.SetWindowSize(140, 60) 'todo: remove
        Console.Clear()
        Console.CursorVisible = False

        InitlocationObjAry()

        Dim player = New Crewmate(5, (6, 100), New List(Of String) From {"OO", "OO"})
        gameObjects.Add(player)

        Dim spaceship = New SolidGameObj(3, (5, getSpaceship.Count - 1), getSpaceship)
        gameObjects.Add(spaceship)

        Dim gamerunning = True
        While gamerunning

            Dim actionhappened As Boolean = Program.KeyboardActions.TryDequeue(result)
            'runs when a button is pressed
            If actionhappened Then
                Select Case result
                    Case GameEnums.KeyboardActions.DownArrow
                        player.move((1, 0))
                    Case GameEnums.KeyboardActions.UpArrow
                        player.move((-1, 0))
                    Case GameEnums.KeyboardActions.RightArrow
                        player.move((0, 1))
                    Case GameEnums.KeyboardActions.LeftArrow
                        player.move((0, -1))
                End Select

            End If

            For Each gameobject In gameObjects 'updates the sprites for gameObjects reporting a change
                If gameobject.didChange = True Then
                    gameobject.write()
                    gameobject.didChange = False
                End If
            Next

            'locationObjAry(1, 1).addChar(New CharObj("O", "[Aqua]", New GameObj(spaceship, (5, 5), 10)))

            RenderScreen(locationObjAry)   'takes locationobj and makes a writable list of strings
            PrintScreen(renderedscreen, (0, 0))  'writes to screen 
            CleanupScreen()
            Threading.Thread.Sleep(1)
            Console.SetCursorPosition(0, 61)
            Console.WriteLine(player.ToString)

        End While

    End Sub

    Sub InitlocationObjAry() 'used to fill the locationObjAry with locationobj
        'should iterate over the 60 rows
        For i = 0 To gameHeight - 1 Step 1
            'should iterate over the 140 locationobjs in the row
            For j = 0 To gameWidth - 1 Step 1
                locationObjAry(i, j) = New LocationObj((i, j))
            Next j
        Next i
    End Sub
    Sub RenderScreen(array As LocationObj(,))
        Dim screen As List(Of String) = New List(Of String)
        'should iterate over the 60 rows
        For i = 0 To array.GetUpperBound(0) - 1 Step 1
            Dim currow As String = ""
            'should iterate over the 140 locationobjs in the row
            For j = 0 To array.GetUpperBound(1) - 1 Step 1
                currow += (array(i, j).toPrint)
            Next j
            screen.Add(currow)
        Next i
        renderedscreen = screen
    End Sub
    Sub PrintScreen(screen As List(Of String), topleftcoord As (Integer, Integer))
        For i = 0 To screen.Count - 1 Step 1
            Console.SetCursorPosition(topleftcoord.Item1, topleftcoord.Item2 + i) 'this is what gets changed when we want to move the game's (0,0) points
            AnsiConsole.Markup(screen(i))
        Next i
    End Sub

    Sub CleanupScreen() 'todo: write in whitespace around the game

    End Sub

    Function backgroundsprite() As List(Of String) 'todo:generate the background
        Dim background As List(Of String) = New List(Of String)
        Dim oneRow As String = "|==========================================================================================================================================|"
        For i = 0 To 60 - 1 Step 1
            Dim builder As New System.Text.StringBuilder
            For ColIter As Integer = 1 To 140
                Dim ranNumer As Integer = Int((5 * Rnd()) + 1)
                If ranNumer = 3 Then
                    builder.Append("*"c)
                Else
                    builder.Append(" "c)
                End If
            Next

            background.Add(builder.ToString)
        Next
        Return background
    End Function

    Function getSpaceship() As List(Of String)
        Dim spaceshit8 As List(Of String) = New List(Of String) From {
        "ÝÝÝÝÝÝÝ/=\ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝÝÝ/=-=\>ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝÝ/=-----=\ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝ(}/    \-\-=\>ÝÝÝÝÝÝÝÝÝÝÝÝ/=--=\ÝÝ",
        "Ý>=O/        \+  +\=-=---=--=/     })Ý",
        "ÝÝÝÝ|                              @()",
        "Ý>=O\        /+  +/=--=-=---=\     })Ý",
        "ÝÝÝÝ(}\    /-/-=/>ÝÝÝÝÝÝÝÝÝÝÝÝ\=--=/ÝÝ",
        "ÝÝÝÝÝ\=-----=/ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝÝÝ\=-=/>ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝÝÝÝ\=/ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ"
        }
        Return spaceshit8
        Dim smallspaceship As List(Of String) = New List(Of String) From {
            "   __       ",
            "   \ \_____. ",
            "###[==_____>",
            "   /_/      "
        }
    End Function

End Module
