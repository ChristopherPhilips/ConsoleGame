Public Class GameObj
    Public Property priority As Integer
    Public Property didChange As Boolean = True
    Public Property location As (Integer, Integer)


    Private Property sprite As Sprite
    Public Property spriteMap As CharObj(,) 'populated by sprite.getSprite()


    Public Property Height As Integer 'todo: get rid of this, take size from spriteMap
    Public Property Width As Integer

    Public Property occupying As Array 'array of tiles occupied, boolean(x,y)


    Private _parentWindowStore As Window  'very cool get set example, useful for when we dont want the property to get changed outside this class
    Public ReadOnly Property parentWindow As Window
        Get
            Return _parentWindowStore
        End Get
    End Property

    Public Sub New(priority As Integer, location As (Integer, Integer), parentWindow As Window, spriteFile As String)
        Me.priority = priority
        Me.location = location
        Me._parentWindowStore = parentWindow

        Me.sprite = New Sprite(spriteFile)
        Me.spriteMap = sprite.getSprite()

        Me.Height = sprite.Height
        Me.Width = sprite.Width

        Me.occupying = New Boolean(sprite.Height - 1, sprite.Width - 1) {}

        render()
    End Sub

    Public Sub move(deltaxy As (Integer, Integer)) 'have manager do this?
        parentWindow.move(Me, deltaxy)
    End Sub

    Public Sub render() 'takes the sprite and turns it into charobjs 
        'call sprite.get
        sprite.getSprite()
    End Sub
End Class
