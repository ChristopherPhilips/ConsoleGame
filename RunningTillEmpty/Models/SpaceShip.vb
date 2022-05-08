Imports GameEngine
Public Class SpaceShip 'creates items, 
    Inherits GameObj
    Implements KeyboardActionMethods
    Implements IHasAnimation

    'Public Property animationChange As Boolean = False

    Public Property AlwaysAnimate As Boolean = False

    Public Sub New(priority As Integer, location As (Integer, Integer), spriteFile As String)
        MyBase.New(priority, location, spriteFile)

    End Sub


    Public Overrides Sub MoveMyself(deltaxy As (Integer, Integer))

    End Sub

    Public Sub KeyboardAction(keyboardaction As GameEnums.KeyboardActions) Implements KeyboardActionMethods.KeyboardAction
        'move selected button



    End Sub

    Public Sub Animate() Implements IHasAnimation.Animate
        If Me.AlwaysAnimate Then
            proposedMovement = (1, 0)
            doIWantToMoveMyself = True
            didChange = True
        End If

    End Sub
End Class
