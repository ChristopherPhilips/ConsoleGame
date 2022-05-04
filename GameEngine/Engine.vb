Public Class Engine 'dont make more than one Engine

    'starting a new thread to listen for keyboard inputs
    Private userinputthread As Threading.Thread = New Threading.Thread(New Threading.ThreadStart(AddressOf InputManager.ReadInput))
    Private result As GameEnums.KeyboardActions = Nothing

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

        Dim gamerunning = True
        While gamerunning

            Dim actionhappened As Boolean = InputManager.KeyboardActions.TryDequeue(result)

            'result is the keyboardaction enum


            'checks to see which windows need to be printed every frame
            For Each windowname In windows.Keys

                If Me.windows.ContainsKey(windowname) And windows(windowname).isActive Then 'only prints/updates active windows


                    If actionhappened Then 'keyboard actions get passed to active windows
                        windows(windowname).KeyboardAction(result)
                    End If

                    Dim topleftX = Me.windowLocation(windowname).Item1
                    Dim topleftY = Me.windowLocation(windowname).Item2
                    windows(windowname).Print(topleftX, topleftY)

                End If



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
    'passthrough to create new gameobjects in a specific window
    Public Sub createGameObj(windowname As String, priority As Integer, location As (Integer, Integer), spriteFile As String)
        If Me.windows.ContainsKey(windowname) Then
            windows(windowname).create(priority, location, spriteFile)
        Else
            Throw New ArgumentException("Cannot create a gameobj in a window that doesn't exist.")
        End If
    End Sub
    Public Sub setActive(windowname As String)
        If Me.windows.ContainsKey(windowname) Then
            windows(windowname).isActive = True
            activeWindows.Add(windowname, windows(windowname))
        Else
            Throw New ArgumentException("Cannot activate n a window that doesn't exist.")
        End If
    End Sub

    Public Sub doSomething()

    End Sub






End Class
