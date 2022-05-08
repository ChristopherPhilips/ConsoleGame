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
    Property TravelScreen = game.CreateWindow("TravelScreen", gameWidth, gameHeight)

    Property objectTypes As Dictionary(Of Char, ICharObjManager) = New Dictionary(Of Char, ICharObjManager) From {}
    Sub Main(args As String())


        game.setCharacterManagers(objectTypes)

        'game is built here
        createMainMenu()


        game.SetWindowLocation(Mainmenu, 1, 1) 'this method needs to center window
        game.SetWindowLocation(TravelScreen, 1, 1)

        game.setActive(Mainmenu)
        Dim starMap = New StarMap(1, (0, 0), (gameWidth, gameHeight))
        game.addGameObj(TravelScreen, starMap)

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
        Dim MainMenusMenu = New CenteredMenu(5, (menuX, menuY), (gameWidth, gameHeight), MainMenuButtons)

        Dim starMap = New StarMap(1, (0, 0), (gameWidth, gameHeight))
        game.addGameObj(Mainmenu, starMap)



        game.addGameObj(Mainmenu, MainMenusMenu)

    End Sub


End Module
