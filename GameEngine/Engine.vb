Imports Spectre.Console
Public Class Engine 'dont make more than one Engine

    Private Shared oInstance As Engine = New Engine
    Public Shared ReadOnly Property Instance As Engine
        Get
            Return oInstance
        End Get
    End Property
    Private Sub New()
    End Sub

    'starting a new thread to listen for keyboard inputs
    Private Shared userinputthread As Threading.Thread = New Threading.Thread(New Threading.ThreadStart(AddressOf InputManager.ReadInput))
    Private result As GameEnums.KeyboardActions = Nothing

    Public Shared Property CharacterManagers As Dictionary(Of Char, ICharObjManager)

    Friend Shared Property locationManager As LocationManager
    Public Function GetLocationManager() As LocationManager
        Return locationManager
    End Function
    Friend Shared Property interactionManager As InteractionManager
    Public Function GetInteractionManager() As LocationManager
        Return locationManager
    End Function

    Public Shared Function Create(height As Integer, Width As Integer) As Engine
        'setting window settings
        Console.Clear()
        Console.CursorVisible = False

        userinputthread.Start()
        locationManager = New LocationManager(height, Width)


        Return oInstance
    End Function


    Public Sub start()

        Dim gamerunning = True
        While gamerunning



            ' Dim actionhappened As Boolean = InputManager.KeyboardActions.TryDequeue(result)

            'keyboard actions -> gameobjects

            'gameupdate happened -> gameobjects



            'CleanupScreen()


            'PrintScreen

            Threading.Thread.Sleep(1)

        End While
    End Sub


    Public Sub addGameObj(windowname As String, newGameObject As GameObj)

    End Sub


    Public Sub setCharacterManagers(ManagerDict As Dictionary(Of Char, ICharObjManager))
        Me.CharacterManagers = ManagerDict
    End Sub

    Public Sub Print(topleftx As Integer, toplefty As Integer) 'writes renderedscreen to terminal


        Dim screen = Me.GetLocationManager().RenderScreen()

        For i = 0 To screen.Count - 1 Step 1
            Console.SetCursorPosition(topleftx, toplefty + i) 'this is what gets changed when we want to move the game's (0,0) points
            AnsiConsole.Markup(screen(i))
        Next i
    End Sub





End Class
