Imports GameEngine
Public Class CenteredMenu 'creates items, 
    Inherits GameObj
    Implements KeyboardActionMethods

    Public Property myButtons As List(Of MenuButton)
    Public Sub New(priority As Integer, location As (Integer, Integer), WidthHeight As (Integer, Integer), buttons As List(Of MenuButton))
        MyBase.New(priority, location, "none")
        Me.Height = WidthHeight.Item2 - 1
        Me.Width = WidthHeight.Item1 - 1
        Me.myButtons = buttons
        Me.spriteMap = New CharObj(Height, Width) {}
        addremoveupdateButtons()
    End Sub

    Public Sub addremoveupdateButtons(Optional changingbutton As MenuButton = Nothing)
        If changingbutton IsNot Nothing Then
            If myButtons.Contains(changingbutton) Then
                myButtons.Remove(changingbutton)
            Else
                myButtons.Add(changingbutton)
            End If
        End If
        Dim lastButtonPos As Integer = 0
        For Each button In Me.myButtons
            For i = 0 To button.Height - 1
                For j = 0 To button.Width - 1
                    Me.spriteMap(button.location.Item2 + i + lastButtonPos, button.location.Item1 + j) = button.spriteMap(i, j)
                Next
            Next
            'lastButtonPos += button.Height
        Next
    End Sub
    Public Sub KeyboardAction(keyboardaction As GameEnums.KeyboardActions) Implements KeyboardActionMethods.KeyboardAction
        'move selected button
    End Sub
End Class
