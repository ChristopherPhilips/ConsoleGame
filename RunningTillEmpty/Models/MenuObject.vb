Imports GameEngine
Public Class MenuObject
    Inherits GameObj

    Public Property isSelectable As Boolean = False

    Public Sub New(priority As Integer, location As (Integer, Integer), spriteFile As String, selectable As Boolean)
        MyBase.New(priority, location, spriteFile) 'doesnt really use these??(does use spritefile)
        Me.isSelectable = selectable


    End Sub

    Public Sub toggleSelected(newState As Boolean)
        If newState Then
            Me.spriteMap = Me.spritesheet.getFrame("Selected", 0, Me)
        Else
            Me.spriteMap = Me.spritesheet.getFrame("NotSelected", 0, Me)
        End If
    End Sub


End Class
