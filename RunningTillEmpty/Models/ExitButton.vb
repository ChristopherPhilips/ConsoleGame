Public Class ExitButton
    Inherits MenuObject


    Public Sub New(priority As Integer, location As (Integer, Integer), spriteFile As String, selectable As Boolean)
        MyBase.New(priority, location, spriteFile, selectable)
    End Sub

    Public Overrides Sub onSelect()
        parentMenu.turnWindowOff = True
    End Sub
End Class
