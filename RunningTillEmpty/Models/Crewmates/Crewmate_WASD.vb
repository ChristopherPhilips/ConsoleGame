Imports GameEngine
Public Class Crewmate_WASD
    Inherits GameObj
    Implements ActionableGameObj

    Public Sub New(priority As Integer, location As (Integer, Integer), sprite As SpriteSheet)
        MyBase.New(priority, location, sprite)
    End Sub

    Public Function Animations() As List(Of String)

    End Function

    Public Sub KeyboardAction(keyboardaction As GameEnums.KeyboardActions) Implements ActionableGameObj.KeyboardAction
        Select Case keyboardaction
            Case GameEnums.KeyboardActions.S
                Me.queueMove((1, 0))
            Case GameEnums.KeyboardActions.W
                Me.queueMove((-1, 0))
            Case GameEnums.KeyboardActions.D
                Me.queueMove((0, 1))
            Case GameEnums.KeyboardActions.A
                Me.queueMove((0, -1))
        End Select
    End Sub


End Class
