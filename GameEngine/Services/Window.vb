Imports Spectre.Console
Public Class Window

    Private Property locationObjAry As LocationObj(,) = New LocationObj(2, 2) {}
    Private Property screenHeight As Integer
    Private Property screenWidth As Integer
    Private Property gameObjects As List(Of GameObj) = New List(Of GameObj) From {}
    Private Property locationManager As LocationManager
    Private Property interactionManager As InteractionManager
    Public Property isActive As Boolean = False

    Public Sub New(width As Integer, height As Integer)
        Me.screenWidth = width
        Me.screenHeight = height

        Me.locationManager = New LocationManager(height, width)
        Me.interactionManager = New InteractionManager(locationManager)

    End Sub

    Public Sub move(gameobject As GameObj, deltaxy As (Integer, Integer)) 'just for window to use
        Me.RemoveGameObj(gameobject)

        'move the gameoject
        Dim oldx = gameobject.location.Item1
        Dim newx = oldx + deltaxy.Item1

        Dim oldy = gameobject.location.Item2
        Dim newy = oldy + deltaxy.Item2


        gameobject.location = (newx, newy)

        Me.addGameObj(gameobject)
    End Sub
    Public Sub create(newGameObject As GameObj) 'adds a gameobject to its updatelist
        gameObjects.Add(newGameObject)
        Me.addGameObj(newGameObject)
    End Sub


    Public Sub Print(topleftx As Integer, toplefty As Integer) 'writes renderedscreen to terminal
        updateGameObjs()

        Dim screen = Me.locationManager.RenderScreen()

        For i = 0 To screen.Count - 1 Step 1
            Console.SetCursorPosition(topleftx, toplefty + i) 'this is what gets changed when we want to move the game's (0,0) points
            AnsiConsole.Markup(screen(i))
        Next i
    End Sub

    Public Sub addGameObj(gameobject As GameObj) 'adds gameobjects chars to locationobjects through the location manager
        'call addcharobj to add charObj to locationObj
        Dim ourZeroX = gameobject.location.Item1
        Dim ourZeroY = gameobject.location.Item2

        Dim spriteHeight = gameobject.Height 'change this to take from spritemap instead
        Dim spriteWidth = gameobject.Width

        For i = 0 To spriteHeight Step 1 'rowloop
            For j = 0 To spriteWidth Step 1 'length loop

                'only add the charobjs that actually exist 'this is where "empty" space in the spriteMap is handled
                If gameobject.spriteMap(i, j) IsNot Nothing Then
                    Me.locationManager.AddCharObj(gameobject.spriteMap(i, j), ourZeroX + i, ourZeroY + j)
                    gameobject.occupying(i, j) = True

                    'interactionmanager check for add interactions
                    ' Me.interactionManager.checkEnter()
                End If

            Next j
        Next i
    End Sub
    Public Sub RemoveGameObj(gameobj As GameObj) 'removes charobjs from locationobjs

        Dim objZeroX As Integer = gameobj.location.Item1
        Dim objZeroY As Integer = gameobj.location.Item2

        For i = 0 To gameobj.occupying.GetUpperBound(0) Step 1
            For j = 0 To gameobj.occupying.GetUpperBound(1) Step 1
                If gameobj.occupying(i, j) Then

                    'interactionmanaer.checkRemove(gameobj, list(of charobjs) in the locationobj the gameobj wants to leave)
                    'this need to be in the remove method
                    '    Me.interactionManager.checkRemove()


                    Me.locationManager.RemoveChar(gameobj, objZeroX + i, objZeroY + j)
                End If
            Next j
        Next i

    End Sub

    Private Sub updateGameObjs()
        For Each gameobject In Me.gameObjects 'updates the sprites (in locationObjAry) for gameObjects reporting a change

            'this if statement hold all of the possible kinds of checks we need to do for didChange gameobjects
            'requested movement
            'animation changes
            'moving cursor on menus
            If gameobject.didChange = True Then
                While gameobject.didChange



                    'check if can move with ProposedMovement
                    If gameobject.proposedMovement.Item1 <> 0 Or gameobject.proposedMovement.Item2 <> 0 Then

                        Dim validMove As Boolean = interactionManager.checkMove(gameobject, gameobject.proposedMovement) 'runs all interactions then reports back with it being a valid move or not, it handles changing proposed movement.

                        If validMove Then 'if can move, move it
                            Me.move(gameobject, gameobject.proposedMovement) 'removes+adds object
                            gameobject.proposedMovement = (0, 0)
                            gameobject.didChange = False
                        Else 'if cant move, need to call standing interaction
                            gameobject.didChange = False
                            Me.interactionManager.checkStand()
                        End If






                    End If


                    gameobject.didChange = False
                End While
            Else
                'interactionmanager check for standing
            End If
        Next
    End Sub

    Public Sub KeyboardAction(keyboardaction As GameEnums.KeyboardActions)
        'gives charobjs that want keyboard commands thier commands
        For Each gameobject In gameObjects

            If TypeOf gameobject Is KeyboardActionMethods Then

                Dim actionable As KeyboardActionMethods = gameobject
                actionable.KeyboardAction(keyboardaction)

            End If
        Next

    End Sub




End Class
