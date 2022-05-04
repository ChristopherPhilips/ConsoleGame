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

        Dim gamerunning = True
        While gamerunning

            Dim actionhappened As Boolean = Program.KeyboardActions.TryDequeue(result)

            'todo: look at gameobj and make it so other things cant delete thier parents


            'runs when a button is pressed
            If actionhappened Then 'todo: actions get passed to window
                'update things according to action
            End If


            gamescreen.Print(1, 1)

            CleanupScreen()

            Threading.Thread.Sleep(1)

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

    Function buildSpaceship8() As List(Of String)
        Dim spaceshit8 As List(Of String) = New List(Of String) From {
        "       /=\                            ",
        "      /=-=\>                          ",
        "     /=-----=\                        ",
        "    (}/    \-\-=\>            /=--=\  ",
        " >=O/        \+  +\=-=---=--=/     }) ",
        "    |                              @()",
        " >=O\        /+  +/=--=-=---=\     }) ",
        "    (}\    /-/-=/>            \=--=/  ",
        "     \=-----=/                        ",
        "      \=-=/>                          ",
        "       \=/                            "
        }
        'specialCharmap
        'colourmap
        'backgroundmap

        Return spaceshit8
    End Function
    Function wallwithdoor() As List(Of String)

        Dim charmap = New List(Of String) From {
            "==0=="
        }
        Dim colourmap = New List(Of String) From {
            "RRWBB"
        }
        Dim backgroundmap = New List(Of String) From {
            "GGGGG"
        }
        Dim typemap = New List(Of String) From {
            "SSDSS"
        }

    End Function



End Module
