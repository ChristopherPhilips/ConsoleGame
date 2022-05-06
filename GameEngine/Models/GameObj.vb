Imports Newtonsoft.Json

Public MustInherit Class GameObj
    Public Property priority As Integer
    Public Property didChange As Boolean = True
    Public Property location As (Integer, Integer)


    Public Property spriteMap As CharObj(,) 'populated by sprite.getSprite()
    Public Property spritesheet As SpriteSheet

    Public Property Height As Integer 'todo: get rid of this, take size from spriteMap
    Public Property Width As Integer

    Public Property occupying As Array 'array of tiles occupied, boolean(x,y) (controlled by window.move)

    Public Property proposedMovement As (Integer, Integer) 'deltaXY



    Public Sub New(priority As Integer, location As (Integer, Integer), spriteFile As String)
        Me.priority = priority
        Me.location = location


        'open the file and put everything into animations

        Me.spritesheet = parseFile(spriteFile)
        updateSprite("init", 0) ' "init" sprite is the base sprite, frame 0 is first frame (leave it up to gameObj to update the sprite for animations.)

    End Sub

    Public Sub queueMove(deltaxy As (Integer, Integer)) 'queues a move action, move actions handled at window.updateGameObjects
        Me.proposedMovement = deltaxy
        Me.didChange = True
    End Sub


    Public Sub updateSprite(animationName As String, frameNumber As Integer) 'function spot for getting the sprite and setting information related to the sprite(size mostly) 
        Me.spriteMap = Me.spritesheet.getFrame(animationName, frameNumber, Me)
        Me.Height = spriteMap.GetLength(0) - 1
        Me.Width = spriteMap.GetLength(1) - 1
        Me.occupying = New Boolean(Height, Width) {}
    End Sub


    Private Function parseFile(spriteFileName As String) As SpriteSheet 'opens + reads file, stores as spritesheet

        Dim filereader2 = New System.IO.StreamReader(spriteFileName)
        Dim rawJSON As String = filereader2.ReadToEnd

        Dim parsedJson As SpriteSheet = JsonConvert.DeserializeObject(rawJSON, GetType(SpriteSheet))
        'this took me actually 4 hours to figure out


        Return JsonConvert.DeserializeObject(rawJSON, GetType(SpriteSheet))
    End Function

End Class











''todo: maybe have these be an interface? so the window only tells objects that care about animations to change their animation
'Private Property currentAnimation As String 'gets changed by who?
'    Private Property currentFrame As Integer 'gets updated by window, if currentFrame>the last frame number in anim, currentframe = 0
'    Private Sub nextAnimationFrame(animationName As String, frameNumber As Integer)
'
'        'change the sprite in some way (animations?)
'        'call sprite.get with wanted change
'        'if wanted anim = last anim, frame ++
'
'        'change size of gameobj in here to reflect new sprite
'        '        Me.Height = sprite.Height
'        '        Me.Width = sprite.Width
'
'        'sprite.getSprite("idle", frameNumber)
'    End Sub
