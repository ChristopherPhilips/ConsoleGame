Public Class ActionableGameObj
    Inherits GameObj

    Public Sub New(priority As Integer, location As (Integer, Integer), parentWindow As Window, spriteFile As String)
        MyBase.New(priority, location, parentWindow, spriteFile)
    End Sub

    'gameobj that takes keyboard inputs

End Class
