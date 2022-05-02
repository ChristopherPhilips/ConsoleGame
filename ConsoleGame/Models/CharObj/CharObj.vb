Public Class CharObj
    Public Property CellChar As String
    Public Property colour As String
    Public Property priority As Integer
    Public Property notPassable = False
    Public Property parentGameObj As GameObj 'i believe this just passes a pointer
    Public Sub New(parentGameObj As GameObj)
        Me.CellChar = " "c
        Me.parentGameObj = parentGameObj
    End Sub
    Public Sub New(CellChar As Char, colour As String, parentGameObj As GameObj)
        If colour.Length > 0 Then
            Me.CellChar = colour + CellChar + "[/]" 'todo, have colours come in as enums??
        Else
            Me.CellChar = CellChar
        End If
        Me.colour = colour
        Me.parentGameObj = parentGameObj
        Me.priority = parentGameObj.priority
    End Sub


End Class
