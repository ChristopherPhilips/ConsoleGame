Imports System
Imports Spectre.Console
Module Program

    Dim gameWidth As Integer = 140
    Dim gameHeight As Integer = 30

    Public KeyboardActions As Queue(Of GameEnums.KeyboardActions) = New Queue(Of GameEnums.KeyboardActions)

    Sub Main(args As String())

        'starting a new thread to listen for keyboard inputs
        Dim userinputthread As Threading.Thread = New Threading.Thread(New Threading.ThreadStart(AddressOf keyboardinputs.ReadInput))
        userinputthread.Start()
        Dim result As GameEnums.KeyboardActions = Nothing 'initializing result for idk

        'setting window settings
        Console.Clear()
        Console.CursorVisible = False

        Dim gamescreen = New Window(gameWidth, gameHeight)


        Dim gameObjects As List(Of GameObj) = New List(Of GameObj) From {}



        Dim background = gamescreen.add(1, (0, 0), backgroundsprite)

        Dim player = gamescreen.add(5, (1, 1), New List(Of String) From {"OO", "OO"})

        Dim spaceship = gamescreen.add(3, (5, getSpaceship8.Count - 1), getSpaceship8)


        Dim gamerunning = True
        While gamerunning

            Dim actionhappened As Boolean = Program.KeyboardActions.TryDequeue(result)

            'todo: look at gameobj and make it so other things cant delete thier parents


            'runs when a button is pressed
            If actionhappened Then 'todo: actions get passed to window
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
            Else
                'check for standing interactions with interactiveChars
            End If


            gamescreen.Print(1, 1)

            CleanupScreen()

            Threading.Thread.Sleep(1)

            'debug printing, todo:remove
            'Console.SetCursorPosition(0, gameHeight + 2)
            'Console.WriteLine(player.toString + "                               ")

        End While

    End Sub

    Sub CleanupScreen() 'todo: write in whitespace around the game

    End Sub

    Function backgroundsprite() As List(Of String) 'todo:generate the background
        Dim background As List(Of String) = New List(Of String)
        For i = 0 To gameHeight - 1 Step 1
            Dim builder As New System.Text.StringBuilder
            For ColIter As Integer = 1 To gameWidth
                Dim ranNumer As Integer = Int((5 * Rnd()) + 1)
                If ranNumer = 3 Then
                    builder.Append("*"c)
                Else
                    builder.Append("Ý"c)
                End If
            Next

            background.Add(builder.ToString)
        Next
        Return background
    End Function

    Function getSpaceship8() As List(Of String)
        Dim spaceshit8 As List(Of String) = New List(Of String) From {
        "ÝÝÝÝÝÝÝ/=\ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝÝÝ/=-=\>ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝÝ/=-----=\ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝ(}/    \-\-=\>ÝÝÝÝÝÝÝÝÝÝÝÝ/=--=\ÝÝ",
        "Ý>=O/        \+  +\=-=---=--=/     })Ý",
        "ÝÝÝÝ|                              @()",
        "Ý>=O\        /+  +/=--=-=---=\     })Ý",
        "ÝÝÝÝ(}\    /-/-=/>ÝÝÝÝÝÝÝÝÝÝÝÝ\=--=/ÝÝ",
        "ÝÝÝÝÝ\=-----=/                        ",
        "ÝÝÝÝÝÝ\=-=/>                          ",
        "       \=/                            "
        }
        'specialCharmap
        Dim spaceshit8Charmap As List(Of String) = New List(Of String) From {
        "ÝÝÝÝÝÝÝ   ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝÝÝ      ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝÝ         ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝ              ÝÝÝÝÝÝÝÝÝÝÝÝ      ÝÝ",
        "Ý                                    Ý",
        "ÝÝÝÝ                                  ",
        "Ý                                    Ý",
        "ÝÝÝÝ              ÝÝÝÝÝÝÝÝÝÝÝÝ      ÝÝ",
        "ÝÝÝÝÝ         ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝÝÝ      ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ",
        "ÝÝÝÝÝÝÝ   ÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝÝ"
        }
        'colourmap

        Return spaceshit8
    End Function
    Function getSpaceship15() As List(Of String)

        Dim spaceshit15 As List(Of String) = New List(Of String) From {
        "ÝÝÝ__ÝÝÝÝÝÝÝÝ",
        "ÝÝÝ\ \_____ÝÝ",
        "###{==_____>Ý",
        "ÝÝÝ/_/ÝÝÝÝÝÝÝ"
        }
        Return spaceshit15
    End Function



End Module
