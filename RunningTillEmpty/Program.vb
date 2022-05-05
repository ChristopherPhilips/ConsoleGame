Imports System
Imports Spectre.Console
Imports GameEngine
Imports System.IO
Module Program

    Dim gameWidth As Integer = 140
    Dim gameHeight As Integer = 30

    Sub Main(args As String())

        Dim game As Engine = New Engine
        Dim MainMenu = game.CreateWindow("Main Menu", 40, 20)

        Dim objectTypes As Dictionary(Of Char, ICharObjManager) = New Dictionary(Of Char, ICharObjManager) From {
            {"C"c, New CrewmateManager}
            }


        game.setCharacterManagers(objectTypes)

        'game is built here

        Dim pathToJsons As String = Path.Combine(Directory.GetCurrentDirectory(), "Assets/Sprites")

        Dim crewmate1 As GameObj = New Crewmate_WASD(10, (2, 2), Path.Combine(pathToJsons, "Crewmate_Red.json"))
        Dim crewmate2 As GameObj = New Crewmate_Arrows(10, (2, 5), Path.Combine(pathToJsons, "Crewmate_Red.json"))
        game.addGameObj(MainMenu, crewmate1)
        game.addGameObj(MainMenu, crewmate2)



        game.SetWindowLocation(MainMenu, 1, 1)

        game.setActive(MainMenu)






        game.start() 'this gives control to the gameengine
        'roll credits
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

End Module
