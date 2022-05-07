Imports System
Imports Spectre.Console
Imports GameEngine
Imports System.IO
Module Program
    Property pathToJsons As String = Path.Combine(Directory.GetCurrentDirectory(), "Assets/Sprites")

    Property gameWidth As Integer = 140
    Property gameHeight As Integer = 30
    Property centerOfgame As Integer = gameWidth / 2


    Public Property game As Engine = New Engine
    Property Mainmenu = game.CreateWindow("Main Menu", gameWidth, gameHeight)
    Property TravelScreen = game.CreateWindow("ShipScreen", gameWidth, gameHeight)

    Property objectTypes As Dictionary(Of Char, ICharObjManager) = New Dictionary(Of Char, ICharObjManager) From {}
    Sub Main(args As String())


        game.setCharacterManagers(objectTypes)

        'game is built here
        createMainMenu()


        game.SetWindowLocation(MainMenu, 1, 1) 'this method needs to center window

        game.setActive(Mainmenu)

        game.setInActive(TravelScreen)

        game.start() 'this gives control to the gameengine
        'roll credits
    End Sub

    Sub createMainMenu()

        Dim MainMenuButtons As List(Of MenuObject) = New List(Of MenuObject)

        Dim title As GameObj = New MenuObject(5, (0, 0), Path.Combine(pathToJsons, "Title.json"), False)
        MainMenuButtons.Add(title)

        Dim play As GameObj = New PlayButton(5, (0, 0), Path.Combine(pathToJsons, "Play.json"), True)
        MainMenuButtons.Add(play)

        Dim exitGame As GameObj = New ExitButton(5, (0, 0), Path.Combine(pathToJsons, "Exit.json"), True)
        MainMenuButtons.Add(exitGame)

        Dim menuY As Integer = centerOfgame - (80 / 2) '80 is width of title
        Dim menuX As Integer = 1
        Dim MainMenusMenu As GameObj = New CenteredMenu(5, (menuX, menuY), (gameWidth, gameHeight), MainMenuButtons)

        game.addGameObj(Mainmenu, MainMenusMenu)

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
        "    (}/=---=\=\-=\>            /=--=\  ",
        " >=O/        \+  +\=-=---=--=/       ) ",
        "    |              +-=----=-+        ()",
        " >=O\        /+  +/=--=-=---=\       ) ",
        "    (}\=---=/=/-=/>            \=--=/  ",
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
