Imports GameEngine
Public Class MenuButton
    Inherits GameObj


    Public Property isSelected As Boolean = False
    Public Property isSelectable As Boolean = False

    Public Sub New(priority As Integer, WidthHeight As (Integer, Integer), spriteFile As String, selectable As Boolean)
        MyBase.New(priority, WidthHeight, spriteFile) 'doesnt really use these??(does use spritefile)
        Me.isSelectable = selectable


        Me.spriteMap = Me.spritesheet.getFrame("init", 0, Me)
    End Sub

    Public Sub toggleSelected()
        If isSelected Then
            Me.spriteMap = Me.spritesheet.getFrame("Selected", 0, Me)
        Else
            Me.spriteMap = Me.spritesheet.getFrame("NotSelected", 0, Me)
        End If
    End Sub


End Class
