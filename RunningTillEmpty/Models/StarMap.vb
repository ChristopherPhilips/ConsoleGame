Imports GameEngine
Public Class StarMap 'creates items, 
    Inherits GameObj
    Implements KeyboardActionMethods


    Public Sub New(priority As Integer, location As (Integer, Integer), WidthHeight As (Integer, Integer))
        MyBase.New(priority, location, "none")
        Me.Height = WidthHeight.Item2 - 1
        Me.Width = WidthHeight.Item1 - 1

        Me.spriteMap = New CharObj(Height, Width) {}
        Me.occupying = New Boolean(Height, Width) {}
        InitialzeSpriteMap()
    End Sub

    Private Sub FillColumn(column As Integer)
        If column < 0 Or column > Width Then
            Throw New ArgumentOutOfRangeException(Width)
        End If

        For row = 0 To Height
            Dim shouldIPlaceAStar As Boolean = True
            If column <> 0 AndAlso spriteMap(row, column - 1) IsNot Nothing Then
                shouldIPlaceAStar = False
            End If
            If row <> 0 AndAlso spriteMap(row - 1, column) IsNot Nothing Then
                shouldIPlaceAStar = False
            End If
            If column <> 0 Then
                If row <> 0 AndAlso spriteMap(row - 1, column - 1) IsNot Nothing Then
                    shouldIPlaceAStar = False
                End If
                If row <> Height AndAlso spriteMap(row + 1, column - 1) IsNot Nothing Then
                    shouldIPlaceAStar = False
                End If
            End If
            If column <> Width Then
                If row <> 0 AndAlso (spriteMap(row - 1, column + 1) IsNot Nothing) Then
                    shouldIPlaceAStar = False
                End If
                If row <> Height AndAlso (spriteMap(row + 1, column + 1)) IsNot Nothing Then
                    shouldIPlaceAStar = False
                End If
            End If
            If shouldIPlaceAStar Then
                Dim ranNumer As Integer = Int((10 * Rnd()) + 1)
                If ranNumer = 3 Then
                    spriteMap(row, column) = New CharObj("*", priority:=Me.priority, parentGameObj:=Me, CharObjType:="$"c)
                End If
            End If
        Next
    End Sub

    Private Sub FillRow(row As Integer)
        If row < 0 Or row > Height Then
            Throw New ArgumentOutOfRangeException(Height)
        End If

        For column = 0 To Width
            Dim shouldIPlaceAStar As Boolean = True
            If column <> 0 AndAlso spriteMap(row, column - 1) IsNot Nothing Then
                shouldIPlaceAStar = False
            End If
            If row <> 0 AndAlso spriteMap(row - 1, column) IsNot Nothing Then
                shouldIPlaceAStar = False
            End If
            If row <> 0 Then
                If column <> 0 AndAlso spriteMap(row - 1, column - 1) IsNot Nothing Then
                    shouldIPlaceAStar = False
                End If
                If column <> Width AndAlso spriteMap(row - 1, column + 1) IsNot Nothing Then
                    shouldIPlaceAStar = False
                End If
            End If
            If row <> Height Then
                If column <> 0 AndAlso spriteMap(row + 1, column - 1) IsNot Nothing Then
                    shouldIPlaceAStar = False
                End If
                If column <> Width AndAlso spriteMap(row + 1, column + 1) IsNot Nothing Then
                    shouldIPlaceAStar = False
                End If
            End If
            If shouldIPlaceAStar Then
                Dim ranNumer As Integer = Int((10 * Rnd()) + 1)
                If ranNumer = 3 Then
                    spriteMap(row, column) = New CharObj("*", priority:=Me.priority, parentGameObj:=Me, CharObjType:="$"c)
                    occupying(row, column) = True
                End If
            End If
        Next
    End Sub

    Private Sub InitialzeSpriteMap()
        For col = 0 To Height
            FillRow(col)
        Next
        didChange = True
    End Sub

    Public Overrides Sub MoveMyself(deltaxy As (Integer, Integer))
        Dim x As Integer = deltaxy.Item1
        Dim y As Integer = deltaxy.Item2

        If x = 0 And y = 1 Then
            spriteMap = ArrayExtensions.TrimArray(Height, -1, spriteMap)
            FillRow(0)
        ElseIf x = 0 And y = -1 Then
            spriteMap = ArrayExtensions.TrimArray(0, -1, spriteMap)
            FillRow(Height)

        ElseIf x = 1 And y = 0 Then
            spriteMap = ArrayExtensions.TrimArray(-1, 0, spriteMap)
            FillColumn(Width)
        ElseIf x = -1 And y = 0 Then
            spriteMap = ArrayExtensions.TrimArray(-1, Width, spriteMap)
            FillColumn(0)

        ElseIf x = 1 And y = 1 Then
            spriteMap = ArrayExtensions.TrimArray(0, 0, spriteMap)
            FillRow(Height)
            FillColumn(Width)

        End If
        occupying = New Boolean(Height, Width) {}
        doIWantToMoveMyself = False



    End Sub

    Public Sub KeyboardAction(keyboardaction As GameEnums.KeyboardActions) Implements KeyboardActionMethods.KeyboardAction
        'move selected button

        If keyboardaction = GameEnums.KeyboardActions.D Then

            proposedMovement = (1, 0)
            doIWantToMoveMyself = True
            didChange = True
        ElseIf keyboardaction = GameEnums.KeyboardActions.A Then

            proposedMovement = (-1, 0)
            doIWantToMoveMyself = True
            didChange = True

        ElseIf keyboardaction = GameEnums.KeyboardActions.S Then

            proposedMovement = (0, -1)
            doIWantToMoveMyself = True
            didChange = True
        ElseIf keyboardaction = GameEnums.KeyboardActions.W Then

            proposedMovement = (0, 1)
            doIWantToMoveMyself = True
            didChange = True

        End If


    End Sub
End Class
