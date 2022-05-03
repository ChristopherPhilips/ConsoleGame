Public MustInherit Class InteractiveChar 'char that occupys space and does something when it interacts with another gameobj
    Inherits CharObj

    Public Sub New(CellChar As Char, parentGameObj As GameObj)
        MyBase.New(CellChar, parentGameObj)
    End Sub

    'todo: make this class abstract

    'when you walk on me (first frame on)
    Public MustOverride Sub EnterTile()

    'when you are standing (first frame on doesnt count)
    Public MustOverride Sub StayonTile()

    'when you leave
    Public MustOverride Sub LeaveTile()


End Class
