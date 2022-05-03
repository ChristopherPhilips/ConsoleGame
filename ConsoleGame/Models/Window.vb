﻿Imports Spectre.Console
Public Class Window

    Private Property locationObjAry As LocationObj(,) = New LocationObj(2, 2) {}
    Private Property screenHeight As Integer
    Private Property screenWidth As Integer
    Private Property gameObjects As List(Of GameObj) = New List(Of GameObj) From {}
    Private Property locationManager As LocationManager

    Public Sub New(width As Integer, height As Integer)
        Me.screenWidth = width
        Me.screenHeight = height
        Dim vbMsgBoxHasdelp(5, 5) As LocationObj

        Me.locationManager = New LocationManager(height, width)

    End Sub

    Public Sub move(gameobject As GameObj, deltaxy As (Integer, Integer))
        'remove gameobject
        Me.RemoveGameObj(gameobject)

        'move the gameoject
        Dim oldx = gameobject.location.Item1
        Dim newx = oldx + deltaxy.Item1

        Dim oldy = gameobject.location.Item2
        Dim newy = oldy + deltaxy.Item2

        gameobject.location = (newx, newy)

        'set gameobject didchange to true
        gameobject.didChange = True

    End Sub
    Public Function add(priority As Integer, location As (Integer, Integer), sprite As List(Of String)) As GameObj
        Dim newGameObject As GameObj = New GameObj(priority, location, Me, sprite)
        gameObjects.Add(newGameObject)
        Return newGameObject
    End Function
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

        Dim spriteHeight = gameobject.spritechars.GetUpperBound(0)
        Dim spriteWidth = gameobject.spritechars.GetUpperBound(1)

        For i = 0 To spriteHeight Step 1 'rowloop
            For j = 0 To spriteWidth Step 1 'length loop

                Me.locationManager.AddCharObj(gameobject.spritechars(i, j), ourZeroX + i, ourZeroY + j)
                gameobject.occupying(i, j) = True

            Next j
        Next i
        gameobject.didChange = False
    End Sub
    Public Sub RemoveGameObj(gameobj As GameObj) 'removes charobjs from locationobjs

        Dim objZeroX As Integer = gameobj.location.Item1
        Dim objZeroY As Integer = gameobj.location.Item2

        For i = 0 To gameobj.occupying.GetUpperBound(0) Step 1
            For j = 0 To gameobj.occupying.GetUpperBound(1) Step 1
                If gameobj.occupying(i, j) Then
                    Me.locationManager.RemoveChar(gameobj, objZeroX + i, objZeroY + j)
                End If
            Next j
        Next i

    End Sub

    Private Sub updateGameObjs()
        For Each gameobject In Me.gameObjects 'updates the sprites (in locationObj) for gameObjects reporting a change
            If gameobject.didChange = True Then
                Me.addGameObj(gameobject)
            End If
        Next
    End Sub






End Class
