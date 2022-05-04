﻿Imports GameEngine
Public Class Crewmate_WASD
    Inherits ActionableGameObj

    Public Sub New(priority As Integer, location As (Integer, Integer), parentWindow As Window, spriteFile As String)
        MyBase.New(priority, location, parentWindow, spriteFile)
    End Sub

    Public Overrides Sub KeyboardAction(keyboardaction As GameEnums.KeyboardActions)
        Select Case keyboardaction
            Case GameEnums.KeyboardActions.S
                Me.move((1, 0))
            Case GameEnums.KeyboardActions.W
                Me.move((-1, 0))
            Case GameEnums.KeyboardActions.D
                Me.move((0, 1))
            Case GameEnums.KeyboardActions.A
                Me.move((0, -1))
        End Select
    End Sub
End Class
