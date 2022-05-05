Public Class GameObj
    Public Property priority As Integer
    Public Property didChange As Boolean = True
    Public Property location As (Integer, Integer)


    Private Property sprite As Sprite
    Public Property spriteMap As CharObj(,) 'populated by sprite.getSprite()


    Public Property Height As Integer 'todo: get rid of this, take size from spriteMap
    Public Property Width As Integer


    Public Property occupying As Array 'array of tiles occupied, boolean(x,y)
    Public Property proposedMovement As (Integer, Integer) 'deltaXY


    Public Sub New(priority As Integer, location As (Integer, Integer), spriteFile As String)
        Me.priority = priority
        Me.location = location

        Me.sprite = New Sprite(spriteFile, Me)
        Me.spriteMap = sprite.getSprite()

        Me.Height = sprite.Height
        Me.Width = sprite.Width

        Me.occupying = New Boolean(Height, Width) {}

    End Sub

    Public Sub queueMove(deltaxy As (Integer, Integer)) 'queues a move action, move actions handled at window.updateGameObjects
        Me.proposedMovement = deltaxy
        Me.didChange = True
    End Sub

    Public Sub upDateSprite() 'function spot for telling the sprite to update (animations??)
        'change the sprite in some way

        'call sprite.get
        sprite.getSprite()
    End Sub
End Class
