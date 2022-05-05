Imports Newtonsoft.Json.Linq
Public Class Sprite 'takes care of putting CharObjs together as a group
    Private Property parentGameObj As GameObj

    Public Property Height As Integer
    Public Property Width As Integer

    'one still image of a gameObj is a compilation of 4 maps, charMap ,colourMap ,backgroundMap, typeMap
    Private Property spriteSheet As Dictionary(Of String, Array) = New Dictionary(Of String, Array) 'needs to store animation name->list of frames?

    Public Sub New(spriteFileName As String, parentGameObj As GameObj) 'reads file, make the charObjArray
        Me.parentGameObj = parentGameObj
        'open the file and pull in all the sprites

        'wants json of form string:List(of dictionary(of string, list)
        '{ 
        ' animationName1: [                                           sprite only needs "idle":[{charMap:list(of string)}]
        '                  {
        '                   charMap : list(of String),                Frame 1
        '                   colourMap : list(of list(of String),
        '                   backgroundMap : list(of list(of String),
        '                   typeMap : list(of String)
        '                  }, 
        '                  {                                          Frame 2
        '                   charMap : list(of String),
        '                   colourMap : list(of list(of String),
        '                   backgroundMap : list(of list(of String),
        '                   typeMap : list(of String)
        '                  }
        '                 ],
        ' animationName2:[
        '                 {...
        '}

        parseFile(spriteFileName)

    End Sub

    'methods
    Private Sub parseFile(spriteFileName As String) 'opens + reads file, stores in spriteSheet 

        Dim filereader2 = New System.IO.StreamReader(spriteFileName)
        Dim rawJSON = filereader2.ReadToEnd
        Dim parsedJson As JObject = JObject.Parse(rawJSON)

        Dim emptyary As Array = New Boolean() {} 'has length 0, used to indicate needing defaults
        'todo: this \/|/\

        'store data by animation
        'animationName -> animation as array (4 elements) {4 arrays of char,colour,background,type}

    End Sub
    Private Function render(frame As Array) As CharObj(,) 'turns 4 arrays into array of charobjs, called when we want the sprite

        'empty maps will be 0 element arrays, otherwise they are sized to charMap's size
        Dim charMap As Array = frame(0)
        Dim colourMap As Array = frame(1)
        Dim backgroundMap As Array = frame(2)
        Dim typeMap As Array = frame(3)

        'populate height+width from charmap
        Me.Height = charMap.GetLength(0) - 1
        Me.Width = charMap.GetLength(1) - 1 'gets column 2 of array 

        Dim renderedFrame As CharObj(,) = New CharObj(,) {}

        For i = 0 To Me.Height
            For j = 0 To Me.Width
                Dim character As Char = charMap(i)(j) 'given char for the space

                Dim charBuilder As System.Text.StringBuilder = New System.Text.StringBuilder(character)


                If colourMap.Length <> 0 Then 'colour, default behavior is to do nothing
                    charBuilder.Insert(0, $"[{colourMap(i)(j)}]")
                    charBuilder.Append("[/]")
                End If
                If backgroundMap.Length <> 0 Then 'background, default behavior is to do nothing
                    charBuilder.Insert(0, $"[{backgroundMap(i)(j)}]")
                    charBuilder.Append("[/]")
                End If
                If typeMap.Length <> 0 Then 'type default behavior is to display as just chars, if we're given a type map we will make special charobjs

                    renderedFrame(i, j) = New CharObj(charBuilder.ToString, Me.parentGameObj)
                    renderedFrame(i, j).CharObjType = typeMap(i, j)


                    If charMap(i, j) = "¿" Then 'check to lower prio on Charobjects we dont wanna see
                        renderedFrame(i, j).priority = -69
                    End If
                Else
                    renderedFrame(i, j) = New CharObj(charBuilder.ToString, parentGameObj) 'this gives ¿ in charmap -priority, so it can be in a square but not visible
                    If renderedFrame(i, j).CharObjType = "¿" Then
                        renderedFrame(i, j).priority = -69
                    End If
                End If

            Next
        Next

        Return renderedFrame
    End Function

    Public Function getSprite(animationName As String, frameNumber As Integer) 'gameobj will tell us animationName+Frame
        ' spriteSheet(animationName)(frameNumber)  will give us an array of the 4 maps. empty maps will be 1 element arrays of boolean False
        Dim charobjArray As CharObj(,) = render(spriteSheet(animationName)(frameNumber))
        Return charObjArray
    End Function

    Public Function update()
        'functionality to have animations?

        'change maps
        'render again

    End Function
End Class
