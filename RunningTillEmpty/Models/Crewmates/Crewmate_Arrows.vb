Imports GameEngine
Public Class Crewmate_Arrows
    Inherits GameObj
    Implements KeyboardActionMethods


    Public Sub New(priority As Integer, location As (Integer, Integer), spriteFile As String)
        MyBase.New(priority, location, spriteFile)
    End Sub

    Public Sub KeyboardAction(keyboardaction As GameEnums.KeyboardActions) Implements KeyboardActionMethods.KeyboardAction
        Select Case keyboardaction
            Case GameEnums.KeyboardActions.DownArrow
                Me.queueMove((1, 0))
            Case GameEnums.KeyboardActions.UpArrow
                Me.queueMove((-1, 0))
            Case GameEnums.KeyboardActions.RightArrow
                Me.queueMove((0, 1))
            Case GameEnums.KeyboardActions.LeftArrow
                Me.queueMove((0, -1))
        End Select
    End Sub
End Class
