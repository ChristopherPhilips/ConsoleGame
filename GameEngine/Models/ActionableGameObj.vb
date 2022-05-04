Public MustInherit Class ActionableGameObj 'intended to be a base for gameobjects that want keyboard inputs to be built on.
    Inherits GameObj

    Public Sub New(priority As Integer, location As (Integer, Integer), parentWindow As Window, spriteFile As String)
        MyBase.New(priority, location, parentWindow, spriteFile)
    End Sub



    Public MustOverride Sub KeyboardAction(keyboardaction As GameEnums.KeyboardActions)


End Class
