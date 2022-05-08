Imports System
Imports Spectre.Console
Imports GameEngine
Imports System.IO
Module Program
    Property pathToJsons As String = Path.Combine(Directory.GetCurrentDirectory(), "Assets/Sprites")

    Property gameWidth As Integer = Console.WindowWidth - 5
    Property gameHeight As Integer = Console.WindowHeight - 5
    Property centerOfgame As Integer = gameWidth / 2


    Public Property game As Engine = New Engine
    Property Mainmenu = game.CreateWindow("Main Menu", gameWidth, gameHeight)
    Property TravelScreen = game.CreateWindow("TravelScreen", gameWidth, gameHeight)

    Property EndGameScreen = game.CreateWindow("EndGameScreen", gameWidth, gameHeight)

    Property objectTypes As Dictionary(Of Char, ICharObjManager) = New Dictionary(Of Char, ICharObjManager) From {}
    Sub Main(args As String())

        game.setCharacterManagers(objectTypes)

        'game is built here
        createMainMenu()


        game.SetWindowLocation(Mainmenu, 1, 1) 'this method needs to center window
        game.SetWindowLocation(TravelScreen, 1, 1)
        game.SetWindowLocation(EndGameScreen, 1, 1)


        Dim spaceY As Integer = centerOfgame - 15
        Dim spaceX As Integer = 1
        Dim spaceshit8 As GameObj = New GameObj(10, (8, 20), Path.Combine(pathToJsons, "SpaceShit8.json"))
        game.addGameObj(TravelScreen, spaceshit8)

        game.setActive(Mainmenu)
        Dim starMap = New StarMap(1, (0, 0), (gameWidth, gameHeight), False, True)
        game.addGameObj(TravelScreen, starMap)



        game.setInActive(TravelScreen)


        Dim endGameObject = New EndGameObject(1, (0, centerOfgame - 106 / 2), Path.Combine(pathToJsons, "GameOverPopup.json"))
        game.addGameObj(EndGameScreen, endGameObject)
        game.setInActive(EndGameScreen)


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

        Dim menuY As Integer = centerOfgame - (86 / 2) '80 is width of title
        Dim menuX As Integer = 1
        Dim MainMenusMenu = New CenteredMenu(5, (0, centerOfgame - 106 / 2), (90, gameHeight - 1), MainMenuButtons)

        Dim starMap = New StarMap(1, (0, 0), (gameWidth, gameHeight), True, False)
        game.addGameObj(Mainmenu, starMap)



        game.addGameObj(Mainmenu, MainMenusMenu)

    End Sub

    Function buildSpaceship8() As List(Of String)
        Dim spaceshit8 As List(Of String) = New List(Of String) From {
        "        /==\                  ",
        "       /=--=|                 ",
        "   >=O/=---|-=)>              ",
        "     |=|---\--=\              ",
        "    (}/=/|\=\=\-\\>           ",
        " >=O/ \ db / \+\ +\\  ,//=-=\ ",
        "    |( -oo- ) {   |=-=|     ()",
        " >=O\ / qp \ /+/ +//  '\\=-=/ ",
        "    (}\=\|/=/=/-//>           ",
        "     |=|---/--=/              ",
        "   >=O\=---|-=)>              ",
        "       \=--=|                 ",
        "        \==/                  "
        }
        '   Dim spaceshit82 As List(Of String) = New List(Of List(Of String)) From {
        '   [" ", " ", " ", " ", " ", " ", " ", " ", "grey", "grey", "grey", "grey", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "],
        '   [" ", " ", " ", " ", " ", " ", " ", "grey", "grey", "grey", "grey", "grey", "grey", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "],
        '   [" ", " ", " ", "yellow", "darkorange3_1", "maroon", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "red", "red", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "],
        '   [" ", " ", " ", " ", " ", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "],
        '   [" ", " ", " ", " ", "darkorange3_1", "maroon", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "red", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "],
        '   [" ", "yellow", "darkorange3_1", "maroon", "grey", " ", "grey", " ", "blue3_1", "blue3_1", " ", "grey", " ", "grey", "grey", "grey", " ", "grey", "grey", "grey", " ", " ", ",", "grey", "grey", "grey", "grey", "grey", "grey", " "],
        '   [" ", " ", " ", " ", "grey", "silver", " ", "blue3_1", "blue3_1", "blue3_1", "blue3_1", " ", "silver", " ", "grey", " ", " ", " ", "grey", "grey", "grey", "grey", "grey", " ", " ", " ", " ", " ", "grey93", "grey93"],
        '   [" ", "yellow", "darkorange3_1", "maroon", "grey", " ", "grey", " ", "blue3_1", "blue3_1", " ", "grey", " ", "grey", "grey", "grey", " ", "grey", "grey", "grey", " ", " ", "'", "grey", "grey", "grey", "grey", "grey", "grey", " "],
        '   [" ", " ", " ", " ", "darkorange3_1", "maroon", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "red", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "],
        '   [" ", " ", " ", " ", " ", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "],
        '   [" ", " ", " ", "yellow", "darkorange3_1", "maroon", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "grey", "red", "red", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "],
        '   [" ", " ", " ", " ", " ", " ", " ", "grey", "grey", "grey", "grey", "grey", "grey", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "],
        '   [" ", " ", " ", " ", " ", " ", " ", " ", "grey", "grey", "grey", "grey", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " "]
        '   }
        'specialCharmap
        'colourmap
        'backgroundmap

        Return spaceshit8
    End Function
End Module
