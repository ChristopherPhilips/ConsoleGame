Public Class PlayButton
    Inherits MenuObject

    Public Sub New(priority As Integer, location As (Integer, Integer), spriteFile As String, selectable As Boolean)
        MyBase.New(priority, location, spriteFile, selectable)
    End Sub

    Public Overrides Sub onSelect()
        parentMenu.setActiveWindows.Add("TravelScreen")
        parentMenu.turnWindowOff = True
    End Sub

End Class
