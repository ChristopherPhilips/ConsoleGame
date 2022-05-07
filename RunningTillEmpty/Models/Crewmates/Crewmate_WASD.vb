Imports GameEngine
Public Class Crewmate_WASD
    Inherits GameObj
    Implements KeyboardActionMethods



    Public Sub New(priority As Integer, location As (Integer, Integer), spriteFile As String)
        MyBase.New(priority, location, spriteFile)
    End Sub


    Public Sub KeyboardAction(keyboardaction As GameEnums.KeyboardActions) Implements KeyboardActionMethods.KeyboardAction
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
