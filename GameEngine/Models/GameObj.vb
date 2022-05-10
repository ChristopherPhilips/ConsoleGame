Imports Newtonsoft.Json

Public Class GameObj
    Public Property isActive As Boolean = False

    Public Property priority As Integer
    Public Property didChange As Boolean = True
    Public Property location As (Integer, Integer)


    Public Property spriteMap As CharObj(,) 'populated by spritesheet.updatesprite()
    Public Property spritesheet As SpriteSheet

    Public Property Height As Integer 'todo: get rid of this, take size from spriteMap
    Public Property Width As Integer

    Public Property occupying As Array 'array of tiles occupied, boolean(x,y) (controlled by window.move)

    Public Sub New(priority As Integer, location As (Integer, Integer), Optional spriteFile As String = "none")
        Me.priority = priority
        Me.location = location


        'open the file and put everything into animations
        If spriteFile <> "none" Then 'lets gameobjects set their own sprites/size
            Me.spritesheet = parseFile(spriteFile)
            spritesheet.getFrame("idle", Me) ' "idle" sprite is the base sprite
            Me.Height = spriteMap.GetLength(0) - 1
            Me.Width = spriteMap.GetLength(1) - 1
        End If

    End Sub

    Public Sub RequestMove(deltaxy As (Integer, Integer)) 'queues a move action, move actions handled in interactionManager
        'ask interaction manager if can move
    End Sub


    Public Overridable Sub updateSprite(animationName As String) 'function for getting the sprite and setting information related to the sprite(size mostly) 
        Me.spriteMap = Me.spritesheet.getFrame(animationName, Me)
        Me.Height = spriteMap.GetLength(0) - 1
        Me.Width = spriteMap.GetLength(1) - 1
    End Sub



    Private Function parseFile(spriteFileName As String) As SpriteSheet 'opens + reads file, stores as spritesheet

        Dim filereader2 = New System.IO.StreamReader(spriteFileName)
        Dim rawJSON As String = filereader2.ReadToEnd

        Dim parsedJson As SpriteSheet = JsonConvert.DeserializeObject(rawJSON, GetType(SpriteSheet))
        'this took me actually 4 hours to figure out


        Return JsonConvert.DeserializeObject(rawJSON, GetType(SpriteSheet))
    End Function

End Class
