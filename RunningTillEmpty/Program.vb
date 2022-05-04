Imports System
Imports Spectre.Console
Imports GameEngine
Module Program

    Dim gameWidth As Integer = 140
    Dim gameHeight As Integer = 30

    Sub Main(args As String())

        Dim game As Engine = New Engine
        Dim MainMenu = game.CreateWindow("Main Menu", gameWidth, gameHeight)

        'game is built here




        game.SetWindowLocation(MainMenu, 2, 2)





        game.start()
        'roll credits
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
