Public Class SolidCharObj
    Inherits CharObj


    Public Sub New(parentGameObj As GameObj)
        MyBase.New(parentGameObj)
        Me.notPassable = True
    End Sub
    Public Sub New(CellChar As Char, colour As String, parentGameObj As GameObj)
        MyBase.New(CellChar, colour, parentGameObj)
        Me.notPassable = True
    End Sub


End Class
