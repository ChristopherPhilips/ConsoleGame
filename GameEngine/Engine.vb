Public Class Engine 'dont make more than one Engine

    'starting a new thread to listen for keyboard inputs
    Private userinputthread As Threading.Thread = New Threading.Thread(New Threading.ThreadStart(AddressOf InputManager.ReadInput))
    Private result As GameEnums.KeyboardActions = Nothing

    Public Shared Property CharacterManagers As Dictionary(Of Char, ICharObjManager)

    'todo:let it have multipleactive windows
    Private Property windows As Dictionary(Of String, Window) = New Dictionary(Of String, Window)
    Private Property windowLocation As Dictionary(Of String, (Integer, Integer)) = New Dictionary(Of String, (Integer, Integer))

    'active windows
    Private Property activeWindows As Dictionary(Of String, Window) = New Dictionary(Of String, Window)
    'inactive windows
    Private Property inactiveWindows As Dictionary(Of String, Window) = New Dictionary(Of String, Window)

    Public Sub New()
        'setting window settings
        Console.Clear()
        Console.CursorVisible = False


        userinputthread.Start()
    End Sub
    Public Sub start()
        Dim windowHeight = Console.WindowHeight
        Dim windowWidth = Console.WindowWidth

        Dim gamerunning = True
        While gamerunning

            Dim actionhappened As Boolean = InputManager.KeyboardActions.TryDequeue(result)


            'result is the keyboardaction enum
            If activeWindows.Count = 0 Then
                Exit While
            End If

            Dim newwindowHeight = Console.WindowHeight
            Dim newwindowwidth = Console.WindowWidth

            If newwindowHeight <> windowHeight Or newwindowwidth <> windowWidth Then  'reprints the game if window size changes??
                windowHeight = newwindowHeight
                windowWidth = newwindowwidth

                For Each window In activeWindows
                    Dim topleftX = Me.windowLocation(window.Key).Item1
                    Dim topleftY = Me.windowLocation(window.Key).Item2

                    window.Value.Print(topleftX, topleftY)
                Next
                Continue While
            End If

            For Each window In activeWindows
                'deactivate the window if its no longer active
                If window.Value.isActive = False Then
                    Continue For
                End If


                If actionhappened Then 'keyboard actions get passed to active windows
                    window.Value.KeyboardAction(result)
                End If

                Dim topleftX = Me.windowLocation(window.Key).Item1
                Dim topleftY = Me.windowLocation(window.Key).Item2


                'todo add try catch for window being too small
                window.Value.updateGameObjs()
                window.Value.Print(topleftX, topleftY) 'updates and prints

                For Each inactiveWindow In window.Value.setActive
                    If windows.ContainsKey(inactiveWindow) Then
                        Dim newactivewindow = windows(inactiveWindow)

                        inactiveWindows.Remove(inactiveWindow)
                        activeWindows.Add(inactiveWindow, newactivewindow)

                        newactivewindow.isActive = True
                    End If
                Next
            Next
            'CleanupScreen()

            Threading.Thread.Sleep(1)

        End While
    End Sub
    Public Function CreateWindow(windowname As String, Width As Integer, Height As Integer) As String
        If Me.windows.ContainsKey(windowname) Then
            Throw New ArgumentException("Window already exists.")
        End If
        Me.windows.Add(windowname, New Window(Width, Height))
        Return windowname
    End Function
    'sets topleft coord for a window, todo: maybe throw exception when windows have an invalid location relative to the terminalsize
    Public Sub SetWindowLocation(windowname As String, topleftX As Integer, topleftY As Integer)
        If Me.windows.ContainsKey(windowname) Then
            Me.windowLocation.Add(windowname, (topleftX, topleftY))
        Else
            Throw New ArgumentException("Cannot set a location for a window that doesn't exist.")
        End If
    End Sub
    'reflection example
    '   Public Function createGameObj(priority As Integer, location As (Integer, Integer), spriteFile As String, gameobjType As Type) As GameObj
    '
    '       'this should create the specified gameobj
    '
    '       Dim argTypes As Type() = New Type(2) {GetType(Integer), GetType((Integer, Integer)), GetType(String)} 'shouldnt have to change as long as new obj types dont need special constructors
    '
    '       Dim constructorInfo As System.Reflection.ConstructorInfo = gameobjType.GetConstructor(argTypes) 'gets constuctor for given arg types
    '
    '       Dim args As Object() = New Object(2) {priority, location, spriteFile} 'makes args
    '
    '       Dim newGameObj = constructorInfo.Invoke(args) 'creates new instance of class with list of args
    '
    '       Return newGameObj
    '
    '   End Function

    Public Sub addGameObj(windowname As String, newGameObject As GameObj)
        If Me.windows.ContainsKey(windowname) Then

            windows(windowname).create(newGameObject)

        Else
            Throw New ArgumentException("Cannot create a gameobj in a window that doesn't exist.")
        End If
    End Sub
    Public Sub setActive(windowname As String)
        If Me.windows.ContainsKey(windowname) Then
            windows(windowname).isActive = True
            activeWindows.Add(windowname, windows(windowname))
        Else
            Throw New ArgumentException("Cannot activate a window that doesn't exist.")
        End If
    End Sub
    Public Sub setInActive(windowname As String)
        If Me.windows.ContainsKey(windowname) Then
            windows(windowname).isActive = False
            inactiveWindows.Add(windowname, windows(windowname))
        Else
            Throw New ArgumentException("Cannot deactivate a window that doesn't exist.")
        End If
    End Sub

    Public Sub setCharacterManagers(ManagerDict As Dictionary(Of Char, ICharObjManager))
        Me.CharacterManagers = ManagerDict
    End Sub






End Class
