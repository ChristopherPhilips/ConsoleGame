Public Class SolidCharObj
    Inherits CharObj

    Public Overloads Property notPassable = True

    Public Sub New(parentGameObj As GameObj)
        MyBase.New(parentGameObj)
    End Sub
    Public Sub New(CellChar As Char, colour As String, parentGameObj As GameObj)
        MyBase.New(CellChar, colour, parentGameObj)
    End Sub


End Class
