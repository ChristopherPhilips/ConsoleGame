Imports Newtonsoft.Json


Public Class SpriteManager 'takes care of putting CharObjs together as a group, from a spritesheet
    Private Property parentGameObj As GameObj

    Public Property Height As Integer 'column 0 is height
    Public Property Width As Integer 'column 1 is length

    'one still image of a gameObj is a compilation of 4 maps, charMap ,colourMap ,backgroundMap, typeMap
    Private Property spriteSheet As SpriteSheet   'needs to store animation name->list of frames as 4 long array

    Public Sub New(parentGameObj As GameObj) 'reads file, make the charObjArray
        Me.parentGameObj = parentGameObj
    End Sub

    'methods



    Public Function getSprite(animationName As String, frameNumber As Integer) 'gameobj will tell us animationName+Frame
        Dim frame As frame = spriteSheet.animations.getFrame(animationName, frameNumber)
        Me.Height = frame.Height
        Me.Width = frame.Width
        'spriteSheet(animationName)(frameNumber)  will give us an array of the 4 maps. empty maps will be 1 element arrays of boolean False

        Return frame.charObjArray
    End Function

    Public Function update()
        'functionality to have animations?

        'change maps
        'render again

    End Function
End Class
