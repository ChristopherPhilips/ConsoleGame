Imports GameEngine
Public Class StickyFloorManager
    Inherits ICharObjManager

    'Stickyfloor is "s"

    Public Overrides Sub onEnter(otherCharObj As CharObj)
    End Sub

    Public Overrides Sub EnteringMe(otherCharObj As CharObj)
        Console.SetCursorPosition(0, 21)
        Console.WriteLine(otherCharObj.CellChar + "|entered me.")
    End Sub


End Class
