Public Class Engine 'dont make more than one Engine

    'starting a new thread to listen for keyboard inputs
    Private userinputthread As Threading.Thread = New Threading.Thread(New Threading.ThreadStart(AddressOf InputManager.ReadInput))
    Private result As GameEnums.KeyboardActions = Nothing

    'todo:let it have multipleactive windows
    Private windows As Dictionary(Of String, Window) = New Dictionary(Of String, Window)
    Private windowLocation As Dictionary(Of String, (Integer, Integer)) = New Dictionary(Of String, (Integer, Integer))

    'active windows
    'inactive windows

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



            'prints all the windows
            For Each windowname In windows.Keys

                If Me.windows.ContainsKey(windowname) Then

                    If windows(windowname).isActive Then

                        'runs when a button is pressed
                        If actionhappened Then 'todo: actions get passed to active windows
                            'update things according to action

                            'send result to windows
                            'forloop all windows window.keyboardaction


                        End If

                        Dim topleftX = Me.windowLocation(windowname).Item1
                        Dim topleftY = Me.windowLocation(windowname).Item2
                        windows(windowname).Print(topleftX, topleftY)

                    ElseIf windows(windowname).isActive = False Then


                    End If

                Else
                    Throw New ArgumentException("Cannot print a window that doesn't exist.")
                End If

            Next

            'CleanupScreen()

            Threading.Thread.Sleep(1)

        End While
    End Sub
    Public Function CreateWindow(windowname As String, Width As Integer, Height As Integer) As String 'todo: add name so we can store windows
        If Me.windows.ContainsKey(windowname) Then
            Throw New ArgumentException("Window already exists.")
        End If
        Me.windows.Add(windowname, New Window(Width, Height))
        Return windowname
    End Function
    Public Sub SetWindowLocation(windowname As String, topleftX As Integer, topleftY As Integer)
        If Me.windows.ContainsKey(windowname) Then
            Me.windowLocation.Add(windowname, (topleftX, topleftY))
        Else
            Throw New ArgumentException("Cannot set a location for a window that doesn't exist.")
        End If
    End Sub

    Public Sub doSomething()

    End Sub






End Class
