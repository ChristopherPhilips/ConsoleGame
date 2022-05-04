Imports GameEngine
Public Class Crewmate_Arrows
    Inherits ActionableGameObj

    Public Sub New(priority As Integer, location As (Integer, Integer), parentWindow As Window, spriteFile As String)
        MyBase.New(priority, location, parentWindow, spriteFile)
    End Sub

    Public Overrides Sub KeyboardAction(keyboardaction As GameEnums.KeyboardActions)
        Select Case keyboardaction
            Case GameEnums.KeyboardActions.DownArrow
                Me.move((1, 0))
            Case GameEnums.KeyboardActions.UpArrow
                Me.move((-1, 0))
            Case GameEnums.KeyboardActions.RightArrow
                Me.move((0, 1))
            Case GameEnums.KeyboardActions.LeftArrow
                Me.move((0, -1))
        End Select
    End Sub
End Class
