Imports System
Imports Spectre.Console
Imports GameEngine
Imports System.IO
Module Program
    Property pathToJsons As String = Path.Combine(Directory.GetCurrentDirectory(), "Assets/Sprites")

    Property gameWidth As Integer = Console.WindowWidth - 5
    Property gameHeight As Integer = Console.WindowHeight - 5
    Property centerOfgame As Integer = gameWidth / 2


    Public Property game As Engine = Engine.Create(12, 6)


    Property objectTypes As Dictionary(Of Char, ICharObjManager) = New Dictionary(Of Char, ICharObjManager) From {}
    Sub Main(args As String())

        game.setCharacterManagers(objectTypes)

        'game is built here


        game.start() 'this gives control to the gameengine
        'roll credits
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
