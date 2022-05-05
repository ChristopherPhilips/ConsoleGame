Public Class CharObj 'on the map, doesnt care what else is in its tile
    Public Property CellChar As String
    Public Property priority As Integer
    Public Property parentGameObj As GameObj 'i believe this just passes a pointer
    Public Property CharObjType As Char

    Public Sub New(CellChar As String, priority As Integer, CharObjType As Char)
        Me.CellChar = " "
        Me.priority = priority
        Me.CharObjType = CharObjType
    End Sub

    Public Sub New(CellChar As String, parentGameObj As GameObj)
        Me.CellChar = CellChar
        Me.parentGameObj = parentGameObj
        Me.priority = parentGameObj.priority
    End Sub


End Class
