Imports Newtonsoft.Json

Public Class SpriteSheet
    Public Property animations As animations
    Public Sub New(spriteFileName As String, listofAnimationNames As List(Of String))
        'open the file and put everything into animations
        Me.animations = New animations(spriteFileName, listofAnimationNames)

    End Sub
    Private Sub parseFile(spriteFileName As String) 'opens + reads file, stores in animations 

        Dim filereader2 = New System.IO.StreamReader(spriteFileName)
        Dim rawJSON As String = filereader2.ReadToEnd

        Dim parsedJson As SpriteSheet = JsonConvert.DeserializeObject(rawJSON, GetType(animations))

    End Sub

End Class


Public Class animations
    <JsonProperty("idle")>
    Public Property idle As List(Of frame)

    <JsonProperty("animations")>
    Public Property animations As Dictionary(Of String, String)
    Private Property animationDict As Dictionary(Of String, List(Of frame))

    Public Sub New(spriteFileName As String, listofAnimationNames As List(Of String))

    End Sub
    Public Function getFrame(animationName As String, framenumber As Integer)
        Return animationDict(animationName)(framenumber).render()
    End Function

End Class
Public Class frame 'renders a group of 4 (or less) maps into an array of char objs
    <JsonProperty("charmap")>
    Public Property charmap As List(Of String)
    <JsonProperty("colourmap")>
    Public Property colourmap As List(Of List(Of String))
    <JsonProperty("backgroundmap")>
    Public Property backgroundmap As List(Of List(Of String))

    <JsonProperty("typemap")>
    Public Property typemap As List(Of String)

    Public Property charObjArray As CharObj(,)

    Public Property Height
    Public Property Width

    'Dim emptyary As Array = New Boolean() {} 'has length 0, used to indicate needing defaults
    Public Function render() As frame 'turns 4 arrays into array of charobjs, called when we want the sprite

        'empty maps will be 0 element arrays, otherwise they are sized to charMap's size


        'populate height+width from charmap
        Me.Height = charmap.Count - 1
        Me.Width = charmap(0).Length - 1 'gets column 2 of array 

        Me.charObjArray = New CharObj(,) {}

        For i = 0 To Height
            For j = 0 To Width
                Dim character As Char = charmap(i)(j) 'given char for the space

                Dim charBuilder As System.Text.StringBuilder = New System.Text.StringBuilder(character)


                If colourmap.Count <> 0 Then 'colour, default behavior is to do nothing
                    charBuilder.Insert(0, $"[{colourmap(i)(j)}]")
                    charBuilder.Append("[/]")
                End If
                If backgroundmap.Count <> 0 Then 'background, default behavior is to do nothing
                    charBuilder.Insert(0, $"[{backgroundmap(i)(j)}]")
                    charBuilder.Append("[/]")
                End If
                If typemap.Count <> 0 Then 'type default behavior is to display as just chars, if we're given a type map we will make special charobjs

                    Me.charObjArray(i, j) = New CharObj(charBuilder.ToString)
                    Me.charObjArray(i, j).CharObjType = typemap(i)(j)


                    If charmap(i)(j) = "¿" Then 'check to lower prio on Charobjects we dont wanna see
                        Me.charObjArray(i, j).priority = -69
                    End If
                Else
                    Me.charObjArray(i, j) = New CharObj(charBuilder.ToString) 'this gives ¿ in charmap -priority, so it can be in a square but not visible
                    If Me.charObjArray(i, j).CharObjType = "¿" Then
                        Me.charObjArray(i, j).priority = -69
                    End If
                End If

            Next
        Next

        Return Me
    End Function

End Class